using System.IdentityModel.Tokens.Jwt;
using System.Linq.Expressions;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;
using System.IO;
using Atrato.Commands.InvitationCommands.Create;
using Atrato.Commands.InvitationCommands.RegisterFailedAttempt;
using Atrato.Commands.InvitationCommands.Update;
using Atrato.Commands.RefreshTokenCommands.Create;
using Atrato.Commands.RefreshTokenCommands.Update;
using Atrato.Entities.Documents;
using Atrato.Entities.DTO.Invitation;
using Atrato.Entities.DTO.RefreshToken;
using Atrato.Entities.DTO.User;
using Atrato.Entities.SupportDTO;
using Atrato.QueryObjects.InvitationQueryObject;
using Atrato.QueryObjects.RefreshTokenQueryObject;
using Atrato.QueryObjects.UserQueryObject;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.JsonWebTokens;
using Microsoft.IdentityModel.Tokens;
using JwtRegisteredClaimNames = System.IdentityModel.Tokens.Jwt.JwtRegisteredClaimNames;

namespace Atrato.Services.AuthService;

public class AuthService : IAuthService
{
    private readonly IConfiguration _configuration;
    private readonly IUserQueryObject _userQueryObject;
    private readonly IRefreshTokenCreateCommand _refreshTokenCreateCommand;
    private readonly IRefreshTokenUpdateCommand _refreshTokenUpdateCommand;
    private readonly IRefreshTokenQueryObject _refreshTokenQueryObject;
    private readonly IInvitationQueryObject _invitationQueryObject;
    private readonly IInvitationCreateCommand _invitationCreateCommand;
    private readonly IInvitationUpdateCommand _invitationUpdateCommand;
    private readonly IInvitationRegisterFailedAttemptCommand _invitationRegisterFailedAttemptCommand;

    public AuthService(
        IConfiguration configuration,
        IUserQueryObject userQueryObject,
        IRefreshTokenCreateCommand refreshTokenCreateCommand,
        IRefreshTokenUpdateCommand refreshTokenUpdateCommand,
        IRefreshTokenQueryObject refreshTokenQueryObject,
        IInvitationQueryObject invitationQueryObject,
        IInvitationCreateCommand invitationCreateCommand,
        IInvitationUpdateCommand invitationUpdateCommand,
        IInvitationRegisterFailedAttemptCommand invitationRegisterFailedAttemptCommand
    )
    {
        _configuration = configuration;
        _userQueryObject = userQueryObject;
        _refreshTokenCreateCommand = refreshTokenCreateCommand;
        _refreshTokenUpdateCommand = refreshTokenUpdateCommand;
        _refreshTokenQueryObject = refreshTokenQueryObject;
        _invitationQueryObject = invitationQueryObject;
        _invitationCreateCommand = invitationCreateCommand;
        _invitationUpdateCommand = invitationUpdateCommand;
        _invitationRegisterFailedAttemptCommand = invitationRegisterFailedAttemptCommand;
    }

    private const int MaxAttempts = 5;
    private static readonly TimeSpan RaceWindow = TimeSpan.FromSeconds(10);
    private static readonly TimeSpan RefreshTokenLifetime = TimeSpan.FromDays(7);
    private static readonly TimeSpan InvitationCodeLifetime = TimeSpan.FromMinutes(10);

    private static readonly Expression<Func<User, LoginUserData>> LoginUserProjection = u => new LoginUserData
    {
        Id = u.Id,
        Name = u.Name,
        LastName = u.LastName,
        Initials = u.Initials,
        Email = u.Email,
        Phone = u.Phone,
        State = u.State,
        isSuperAdmin = u.isSuperAdmin,
        Enterprises = u.UserEnterprises
            .Select(ue => new EnterpriseMembershipData
            {
                EnterpriseId = ue.EnterpriseId,
                Enterprise = ue.Enterprise.Name,
                IsAdminEnterprise = ue.IsAdminEnterprise,
                ReservationsByMonth = ue.ReservationsByMonth
            }).ToList()
    };

    public async Task<StandardResult<bool>> RequestCode(CheckUserRequest request, CancellationToken cancellationToken)
    {
        var user = await _userQueryObject.Clear().ForEmail(request.Email).ForState(true).FirstOrDefault(cancellationToken);

        if (user == null)
        {
            return new StandardResult<bool>()
            {
                Success = true,
                Data = true
            };
        }

        var codesByUser = await _invitationQueryObject.Clear().ForUser(user.Id).ForState(true)
            .GetAll(cancellationToken);

        foreach (var code in codesByUser)
        {
            var updateRequestInvitation = new InvitationUpdateRequest()
            {
                Id = code.Id,
                Code = code.Code,
                CreationDate = code.CreationDate,
                ExpirationDate = code.ExpirationDate,
                UserId = user.Id,
                NumberAttempts = code.NumberAttempts,
                State = false,
                UsedAt = code.UsedAt,
            };

            await _invitationUpdateCommand.Execute(updateRequestInvitation, user.Id);
        }

        var plainCode = CreateCode();

        string path = "code.txt";
        string content = plainCode;
        
        File.WriteAllText(path, content);
        Console.WriteLine($"Archivo en {Path.GetFullPath(path)}");

        var createRequestInvitation = new InvitationCreateRequest()
        {
            UserId = user.Id,
            CreationDate = DateTime.UtcNow,
            ExpirationDate = DateTime.UtcNow.Add(InvitationCodeLifetime),
            Code = HashSecret(plainCode),
            NumberAttempts = 0,
            UsedAt = null,
            State = true
        };

        await _invitationCreateCommand.Execute(createRequestInvitation, user.Id);

        return new StandardResult<bool>()
        {
            Success = true,
            Data = true
        };
    }

    public async Task<StandardResult<AuthToken>> Login(AuthRequest request, CancellationToken cancellationToken)
    {
        AuthToken response = new();

        var user = await _userQueryObject.Clear()
            .ForEmail(request.Email)
            .ForState(true)
            .Query()
            .Select(LoginUserProjection)
            .FirstOrDefaultAsync(cancellationToken);

        if (user == null)
        {
            return new StandardResult<AuthToken>
            {
                Success = false,
                Data = response,
            };
        }

        var code = await _invitationQueryObject.Clear().ForUser(user.Id).ForState(true)
            .FirstOrDefault(cancellationToken);

        if (code == null)
        {
            return new StandardResult<AuthToken>()
            {
                Success = false,
                Data = response,
            };
        }

        if (code.ExpirationDate <= DateTime.UtcNow)
        {
            var expiredRequestInvitation = new InvitationUpdateRequest()
            {
                Id = code.Id,
                Code = code.Code,
                CreationDate = code.CreationDate,
                ExpirationDate = code.ExpirationDate,
                NumberAttempts = code.NumberAttempts,
                State = false,
                UserId = user.Id,
                UsedAt = code.UsedAt,
            };

            await _invitationUpdateCommand.Execute(expiredRequestInvitation, user.Id);

            return new StandardResult<AuthToken>()
            {
                Success = false,
                Data = response,
            };
        }

        if (!SecretsMatch(code.Code, HashSecret(request.Code)))
        {
            await _invitationRegisterFailedAttemptCommand.Execute(code.Id, MaxAttempts, cancellationToken);

            return new StandardResult<AuthToken>()
            {
                Success = false,
                Data = response,
            };
        }
        
        var updateRequestInvitation = new InvitationUpdateRequest()
        {
            Code = code.Code,
            CreationDate = code.CreationDate,
            ExpirationDate = code.ExpirationDate,
            Id = code.Id,
            NumberAttempts = code.NumberAttempts,
            State = false,
            UserId = user.Id,
            UsedAt = DateTime.UtcNow,
        };

        await _invitationUpdateCommand.Execute(updateRequestInvitation, user.Id);

        response.Token = GenerateToken(user.Id, user.Email);
        response.RefreshToken = GenerateRefreshToken();
        response.User = user;

        var createRequestRefreshToken = new RefreshTokenCreateRequest()
        {
            UserId = user.Id,
            CreationDate = DateTime.UtcNow,
            ExpirationDate = DateTime.UtcNow.Add(RefreshTokenLifetime),
            isExpired = false,
            ExpiredAt = null,
            Token = HashSecret(response.RefreshToken),
        };

        await _refreshTokenCreateCommand.Execute(createRequestRefreshToken, user.Id);

        return new StandardResult<AuthToken>()
        {
            Success = true,
            Data = response,
        };
    }

    public async Task<StandardResult<AuthToken>> Refresh(RefreshRequest request, CancellationToken cancellationToken)
    {
        AuthToken response = new();
        var principal = await GetInfoFromExpiredToken(request.Token);

        if (principal == null)
        {
            return new StandardResult<AuthToken>()
            {
                Success = false,
                Data = response,
            };
        }

        if (!Guid.TryParse(principal.FindFirstValue(JwtRegisteredClaimNames.Sub), out var userId))
        {
            return new StandardResult<AuthToken>()
            {
                Success = false,
                Data = response,
            };
        }

        var user = await _userQueryObject.Clear()
            .ForId(userId)
            .ForState(true)
            .Query()
            .Select(LoginUserProjection)
            .FirstOrDefaultAsync(cancellationToken);

        if (user == null)
        {
            return new StandardResult<AuthToken>()
            {
                Success = false,
                Data = response,
            };
        }

        var existingRefreshToken =
            await _refreshTokenQueryObject.Clear().ForUser(userId).ForToken(HashSecret(request.RefreshToken))
                .FirstOrDefault(cancellationToken);

        if (existingRefreshToken == null)
        {
            return new StandardResult<AuthToken>()
            {
                Success = false,
                Data = response,
            };
        }

        if (existingRefreshToken.isExpired)
        {
            var isRace = existingRefreshToken.ExpiredAt is { } rotatedAt
                         && DateTime.UtcNow - rotatedAt < RaceWindow;

            if (!isRace)
            {
                await ExpireAllRefreshTokens(userId, cancellationToken);
            }

            return new StandardResult<AuthToken>()
            {
                Success = false,
                Data = response,
            };
        }

        if (existingRefreshToken.ExpirationDate <= DateTime.UtcNow)
        {
            return new StandardResult<AuthToken>()
            {
                Success = false,
                Data = response,
            };
        }

        var updateRequestPresentedRefreshToken = new RefreshTokenUpdateRequest()
        {
            CreationDate = existingRefreshToken.CreationDate,
            ExpirationDate = existingRefreshToken.ExpirationDate,
            ExpiredAt = DateTime.UtcNow,
            Id = existingRefreshToken.Id,
            isExpired = true,
            Token = existingRefreshToken.Token,
            UserId = userId,
        };

        await _refreshTokenUpdateCommand.Execute(updateRequestPresentedRefreshToken, userId);

        var newToken = GenerateToken(userId, user.Email);
        var newRefreshToken = GenerateRefreshToken();

        var createRequestRefreshToken = new RefreshTokenCreateRequest()
        {
            UserId = userId,
            CreationDate = DateTime.UtcNow,
            ExpirationDate = DateTime.UtcNow.Add(RefreshTokenLifetime),
            Token = HashSecret(newRefreshToken),
            ExpiredAt = null,
            isExpired = false
        };

        await _refreshTokenCreateCommand.Execute(createRequestRefreshToken, userId);

        response.RefreshToken = newRefreshToken;
        response.Token = newToken;
        response.User = user;

        return new StandardResult<AuthToken>()
        {
            Success = true,
            Data = response,
        };
    }

    public async Task<StandardResult<LoginUserData?>> RehydrateUser(Guid userId, CancellationToken cancellationToken)
    {
        var user = await _userQueryObject.Clear()
            .ForId(userId)
            .ForState(true)
            .Query()
            .Select(LoginUserProjection)
            .FirstOrDefaultAsync(cancellationToken);

        return new StandardResult<LoginUserData?>()
        {
            Success = user != null,
            Data = user,
        };
    }

    public async Task<StandardResult<bool>> Logout(LogoutRequest request, CancellationToken cancellationToken)
    {
        var existingRefreshToken = await _refreshTokenQueryObject.Clear()
            .ForToken(HashSecret(request.RefreshToken))
            .FirstOrDefault(cancellationToken);

        if (existingRefreshToken == null || existingRefreshToken.isExpired)
        {
            return new StandardResult<bool>()
            {
                Success = true,
                Data = true,
            };
        }

        var updateRequestRefreshToken = new RefreshTokenUpdateRequest()
        {
            Id = existingRefreshToken.Id,
            CreationDate = existingRefreshToken.CreationDate,
            ExpirationDate = existingRefreshToken.ExpirationDate,
            Token = existingRefreshToken.Token,
            UserId = existingRefreshToken.UserId,
            ExpiredAt = DateTime.UtcNow,
            isExpired = true,
        };

        await _refreshTokenUpdateCommand.Execute(updateRequestRefreshToken, existingRefreshToken.UserId);

        return new StandardResult<bool>()
        {
            Success = true,
            Data = true,
        };
    }

    public async Task<StandardResult<bool>> LogoutAll(Guid userId, CancellationToken cancellationToken)
    {
        await ExpireAllRefreshTokens(userId, cancellationToken);

        return new StandardResult<bool>()
        {
            Success = true,
            Data = true,
        };
    }

    private async Task ExpireAllRefreshTokens(Guid userId, CancellationToken cancellationToken)
    {
        var currentRefreshTokens = await _refreshTokenQueryObject.Clear().ForUser(userId).ForExpired(false).GetAll(cancellationToken);

        foreach (var currentRefreshToken in currentRefreshTokens)
        {
            var updateRequestCurrentRefreshToken = new RefreshTokenUpdateRequest()
            {
                CreationDate = currentRefreshToken.CreationDate,
                ExpirationDate = currentRefreshToken.ExpirationDate,
                ExpiredAt = DateTime.UtcNow,
                Id = currentRefreshToken.Id,
                isExpired = true,
                Token = currentRefreshToken.Token,
                UserId = userId,
            };

            await _refreshTokenUpdateCommand.Execute(updateRequestCurrentRefreshToken, userId);
        }
    }

    private static string CreateCode()
    {
        return RandomNumberGenerator.GetInt32(0, 1_000_000).ToString("D6");
    }

    private string HashSecret(string value)
    {
        var hashKey = Convert.FromHexString(_configuration["Hash:Key"]!);

        using var hmac = new HMACSHA256(hashKey);

        return Convert.ToHexString(hmac.ComputeHash(Encoding.UTF8.GetBytes(value)));
    }

    private static bool SecretsMatch(string storedHash, string candidateHash)
    {
        return CryptographicOperations.FixedTimeEquals(
            Encoding.UTF8.GetBytes(storedHash),
            Encoding.UTF8.GetBytes(candidateHash));
    }

    private string GenerateToken(Guid userId, string userEmail)
    {
        var jwtSettings = _configuration.GetSection("JwtSettings");
        var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwtSettings["Key"]!));

        var claims = new[]
        {
            new Claim(JwtRegisteredClaimNames.Sub, userId.ToString()),
            new Claim(JwtRegisteredClaimNames.Email, userEmail),
            new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
        };

        var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

        var token = new JwtSecurityToken(
            issuer: jwtSettings["Issuer"],
            audience: jwtSettings["Audience"],
            claims: claims,
            expires: DateTime.UtcNow.AddMinutes(Convert.ToDouble(jwtSettings["Duration"])),
            signingCredentials: creds
        );

        return new JwtSecurityTokenHandler().WriteToken(token);
    }

    private static string GenerateRefreshToken()
    {
        var randomBytes = new byte[64];
        using var randomNumber = RandomNumberGenerator.Create();
        randomNumber.GetBytes(randomBytes);
        return Convert.ToBase64String(randomBytes);
    }

    private async Task<ClaimsPrincipal?> GetInfoFromExpiredToken(string token)
    {
        var jwtSettings = _configuration.GetSection("JwtSettings");

        var validation = new TokenValidationParameters
        {
            ValidateAudience = true,
            ValidAudience = jwtSettings["Audience"],
            ValidateIssuer = true,
            ValidIssuer = jwtSettings["Issuer"],
            ValidateIssuerSigningKey = true,
            IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwtSettings["Key"]!)),
            ValidateLifetime = false,
            ValidAlgorithms = [SecurityAlgorithms.HmacSha256],
        };

        var handler = new JsonWebTokenHandler { MapInboundClaims = false };
        var result = await handler.ValidateTokenAsync(token, validation);

        return !result.IsValid ? null : new ClaimsPrincipal(result.ClaimsIdentity);
    }
}