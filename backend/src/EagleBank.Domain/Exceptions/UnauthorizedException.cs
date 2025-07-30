namespace EagleBank.Domain.Exceptions;

public class UnauthorizedException(string? message = null) : Exception(message  ?? "Unauthorized");
