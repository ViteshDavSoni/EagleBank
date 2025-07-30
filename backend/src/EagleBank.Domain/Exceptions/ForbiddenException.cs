namespace EagleBank.Domain.Exceptions;

public class ForbiddenException(string? message = null) : Exception(message ?? "Forbidden");
