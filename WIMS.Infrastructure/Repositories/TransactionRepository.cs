using Microsoft.EntityFrameworkCore;
using WIMS.Application.Common.Interfaces;
using WIMS.Domain.Transactions;
using WIMS.Infrastructure.Persistence;

namespace WIMS.Infrastructure.Repositories;

public class TransactionRepository : ITransactionRepository
{
    public readonly AppDbContext _db;

    public TransactionRepository(AppDbContext db)
    {
        _db = db;
    }
    public Task AddAsync(Transaction transaction, CancellationToken cancellationToken)
    {
        _db.Transactions.Add(transaction);
        return Task.CompletedTask;
    }

    public Task<Transaction?> GetByIdAsync(TransactionId id, Guid userId, CancellationToken cancellationToken)
        => _db.Transactions.FirstOrDefaultAsync(x=>x.Id == id && x.UserId == userId, cancellationToken);
        
    

    public void Remove(Transaction transaction) => _db.Transactions.Remove(transaction);
   

    public async Task<IReadOnlyList<Transaction>> ListAsync(Guid userId, CancellationToken ct)
        => await _db.Transactions
            .Where(x => x.UserId == userId)
            .OrderByDescending(x => x.OccuredAt)
            .ToListAsync(ct);
}