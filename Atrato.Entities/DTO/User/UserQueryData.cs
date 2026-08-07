namespace Atrato.Entities.DTO.User;

public class UserQueryData
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public string LastName { get; set; }
    public string Initials { get; set; }
    public string Email { get; set; }
    public string Phone { get; set; }
    public bool State { get; set; }
    public bool isSuperAdmin { get; set; }
}