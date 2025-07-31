using EagleBank.Domain.Enums;

namespace EagleBank.Application.Dtos.Requests;

public record CreateTransactionRequest(string TransactionName, TransactionType TransactionType,  decimal Amount);