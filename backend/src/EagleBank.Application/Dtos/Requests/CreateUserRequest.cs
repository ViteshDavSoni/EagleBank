namespace EagleBank.Application.Dtos.Requests;

public record CreateUserRequest(string FirstName, string LastName, string Email, string Password);