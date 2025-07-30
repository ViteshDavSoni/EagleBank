namespace EagleBank.Domain.Exceptions;

public class NotFoundException(string? message = null) : Exception(message ?? "Not Found");