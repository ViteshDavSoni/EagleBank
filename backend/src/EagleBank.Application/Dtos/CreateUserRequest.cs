namespace EagleBank.Application.Dtos;

public record CreateUserRequest(string FirstName, string LastName, string Email, string Password);