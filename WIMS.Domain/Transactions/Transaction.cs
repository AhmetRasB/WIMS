using WIMS.Domain.Common;

namespace WIMS.Domain.Transactions;

public sealed class Transaction : Entity<TransactionId>, IAggregateRoot
{
    private Transaction(){}
    public Guid UserId { get; private set; }
    public AssetType AssetType { get;private set; }
    public TransactionType TransactionType { get;private set; }

    public decimal Quantity { get;private set; }
    public decimal UnitPriceTry { get;private set; }
    public decimal FeeTry { get;private set; }

    public DateTimeOffset OccuredAt { get; private set; }
    public string? Note { get; private set; }

    public static Transaction Create(
        Guid userId,
        AssetType assetType,
        TransactionType transactionType,
        decimal quantity,
        decimal unitPriceTry,
        decimal feeTry,
        DateTimeOffset occuredAt,
        string? note)
    {
        if (quantity <= 0) throw new ArgumentException("Quantity must be bigger than 0");
        if (unitPriceTry <= 0) throw new ArgumentException("Unit Price must be bigger than 0");
        if (feeTry < 0) throw new ArgumentException("FeeTry cannot be negative");

        return new Transaction()
        {
            Id = new TransactionId(userId),
            UserId = userId,
            AssetType = assetType,
            Quantity = quantity,
            FeeTry = feeTry,
            OccuredAt = occuredAt,
            Note = note,

        };
    }
    
}