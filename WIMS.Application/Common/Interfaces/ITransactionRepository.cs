
using WIMS.Domain.Transactions;

namespace WIMS.Application.Common.Interfaces;

public interface ITransactionRepository
{
    Task AddAsync(Transaction transaction, CancellationToken cancellationToken);
    Task<Transaction?> GetByIdAsync(TransactionId id, Guid userId, CancellationToken cancellationToken);
    void Remove(Transaction transaction);
    Task<IReadOnlyList<Transaction>> ListAsync(Guid userId, CancellationToken ct);
}