using Dataflow.Models;

namespace Dataflow.Dtos;

public class GetUserDTO
{
    public string Username { get; set; } = string.Empty;
    public string FirstName { get; set; } = string.Empty;
    public string LastName { get; set; } = string.Empty;
    public string Email { get; set; } = string.Empty;
    public string Password { get; set; } = string.Empty;
    public DateTime RegistrationDate { get; set; } = DateTime.Today;
}