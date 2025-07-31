namespace EagleBank.Domain.Exceptions;

public class UnprocessableEntityException(string? message = null) : Exception(message ?? "Unprocessable entity");
