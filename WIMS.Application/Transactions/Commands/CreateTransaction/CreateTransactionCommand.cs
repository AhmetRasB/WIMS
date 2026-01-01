using WIMS.Domain.Transactions;

namespace WIMS.Application.Transactions.Commands.CreateTransaction;

public sealed record CreateTransactionCommand(
    AssetType AssetType,
    TransactionType Type,
    decimal Quantity,
    decimal UnitPriceTry,
    decimal FeeTry,
    DateTimeOffset OccurredAt,
    string? Note
);