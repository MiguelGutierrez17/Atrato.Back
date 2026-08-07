using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;
using Atrato.Commands.InvitationCommands.Create;
using Atrato.Commands.InvitationCommands.Update;
using Atrato.Commands.RefreshTokenCommands.Create;
using Atrato.Commands.RefreshTokenCommands.Update;
using Atrato.Entities.DTO.Invitation;
using Atrato.Entities.DTO.RefreshToken;
using Atrato.Entities.SupportDTO;
using Atrato.QueryObjects.InvitationQueryObject;
using Atrato.QueryObjects.RefreshTokenQueryObject;
using Atrato.QueryObjects.UserQueryObject;
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

    public AuthService(
        IConfiguration configuration,
        IUserQueryObject userQueryObject,
        IRefreshTokenCreateCommand refreshTokenCreateCommand,
        IRefreshTokenUpdateCommand refreshTokenUpdateCommand,
        IRefreshTokenQueryObject refreshTokenQueryObject,
        IInvitationQueryObject invitationQueryObject,
        IInvitationCreateCommand invitationCreateCommand,
        IInvitationUpdateCommand invitationUpdateCommand
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
    }

    private const int MaxAttempts = 5;

    public async Task<StandardResult<bool>> CheckUser(string email, CancellationToken cancellationToken)
    {
        var response = false;
        var user = await _userQueryObject.ForEmail(email).ForState(true).FirstOrDefault(cancellationToken);

        if (user == null)
        {
            return new StandardResult<bool>()
            {
                Success = true,
                Data = response
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

        var createRequestInvitation = new InvitationCreateRequest()
        {
            UserId = user.Id,
            CreationDate = DateTime.UtcNow,
            ExpirationDate = DateTime.UtcNow.AddMinutes(10),
            Code = CreateCode(),
            NumberAttempts = 0,
            UsedAt = null,
            State = true
        };

        await _invitationCreateCommand.Execute(createRequestInvitation, user.Id);
        response = true;

        return new StandardResult<bool>()
        {
            Success = true,
            Data = response
        };
    }

    public async Task<StandardResult<AuthToken>> Login(AuthRequest request, CancellationToken cancellationToken)
    {
        AuthToken response = new();

        var user = await _userQueryObject.Clear().ForEmail(request.Email).ForState(true)
            .FirstOrDefault(cancellationToken);

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

        if (code.ExpirationDate <= DateTime.UtcNow || code.NumberAttempts >= MaxAttempts)
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

        if (code.Code != request.Code)
        {
            var attempts = code.NumberAttempts + 1;

            var failedRequestInvitation = new InvitationUpdateRequest()
            {
                Id = code.Id,
                Code = code.Code,
                CreationDate = code.CreationDate,
                ExpirationDate = code.ExpirationDate,
                NumberAttempts = attempts,
                State = attempts < MaxAttempts,
                UserId = user.Id,
                UsedAt = code.UsedAt,
            };

            await _invitationUpdateCommand.Execute(failedRequestInvitation, user.Id);

            return new StandardResult<AuthToken>()
            {
                Success = false,
                Data = response,
            };
        }

        var currentRefreshTokens = await _refreshTokenQueryObject.Clear().ForUser(user.Id).ForExpired(false)
            .GetAll(cancellationToken);

        foreach (var refreshToken in currentRefreshTokens)
        {
            var updateRequestRefreshToken = new RefreshTokenUpdateRequest()
            {
                Id = refreshToken.Id,
                CreationDate = refreshToken.CreationDate,
                ExpirationDate = refreshToken.ExpirationDate,
                Token = refreshToken.Token,
                UserId = user.Id,
                ExpiredAt = DateTime.UtcNow,
                isExpired = true
            };

            await _refreshTokenUpdateCommand.Execute(updateRequestRefreshToken, user.Id);
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

        var createRequestRefreshToken = new RefreshTokenCreateRequest()
        {
            UserId = user.Id,
            CreationDate = DateTime.UtcNow,
            ExpirationDate = DateTime.UtcNow.AddDays(7),
            isExpired = false,
            ExpiredAt = null,
            Token = response.RefreshToken,
        };

        await _refreshTokenCreateCommand.Execute(createRequestRefreshToken, user.Id);

        return new StandardResult<AuthToken>()
        {
            Success = true,
            Data = response,
        };
    }

    public async Task<StandardResult<AuthToken>> Refresh(AuthToken request, CancellationToken cancellationToken)
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

        var user = await _userQueryObject.Clear().ForId(userId).ForState(true)
            .FirstOrDefault(cancellationToken);

        if (user == null)
        {
            return new StandardResult<AuthToken>()
            {
                Success = false,
                Data = response,
            };
        }

        var existingRefreshToken =
            await _refreshTokenQueryObject.Clear().ForUser(userId).ForToken(request.RefreshToken)
                .FirstOrDefault(cancellationToken);

        if (existingRefreshToken == null || existingRefreshToken.isExpired ||
            existingRefreshToken.ExpirationDate <= DateTime.UtcNow)
        {
            return new StandardResult<AuthToken>()
            {
                Success = false,
                Data = response,
            };
        }

        var currentRefreshTokens = await _refreshTokenQueryObject.Clear().ForUser(userId).ForExpired(false).GetAll(
            cancellationToken);

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

        var newToken = GenerateToken(userId, user.Email);
        var newRefreshToken = GenerateRefreshToken();

        var createRequestRefreshToken = new RefreshTokenCreateRequest()
        {
            UserId = userId,
            CreationDate = DateTime.UtcNow,
            ExpirationDate = DateTime.UtcNow.AddDays(7),
            Token = newRefreshToken,
            ExpiredAt = null,
            isExpired = false
        };

        await _refreshTokenCreateCommand.Execute(createRequestRefreshToken, userId);

        response.RefreshToken = newRefreshToken;
        response.Token = newToken;

        return new StandardResult<AuthToken>()
        {
            Success = true,
            Data = response,
        };
    }

    private static string CreateCode()
    {
        return RandomNumberGenerator.GetInt32(0, 1_000_000).ToString("D6");
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

        var Creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

        var Token = new JwtSecurityToken(
            issuer: jwtSettings["Issuer"],
            audience: jwtSettings["Audience"],
            claims: claims,
            expires: DateTime.UtcNow.AddMinutes(Convert.ToDouble(jwtSettings["Duration"])),
            signingCredentials: Creds
        );

        return new JwtSecurityTokenHandler().WriteToken(Token);
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
        var validation = new TokenValidationParameters
        {
            ValidateAudience = false,
            ValidateIssuer = false,
            ValidateIssuerSigningKey = true,
            IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["JwtSettings:Key"]!)),
            ValidateLifetime = false,
            ValidAlgorithms = [SecurityAlgorithms.HmacSha256],
        };

        var handler = new JsonWebTokenHandler { MapInboundClaims = false };
        var result = await handler.ValidateTokenAsync(token, validation);

        return !result.IsValid ? null : new ClaimsPrincipal(result.ClaimsIdentity);
    }
}