namespace EagleBank.Domain.Exceptions;

public class BadRequestException(string? message = null) : Exception(message ?? "Bad Request");
