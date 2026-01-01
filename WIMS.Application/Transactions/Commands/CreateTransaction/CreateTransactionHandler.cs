using WIMS.Application.Common.Interfaces;
using WIMS.Domain.Transactions;

namespace WIMS.Application.Transactions.Commands.CreateTransaction;

public sealed class CreateTransactionHandler
{
    private readonly ITransactionRepository _repository;
    private readonly IUnitOfWork _unitOfWork;
    private readonly ICurrentUser _currentUser;

    public CreateTransactionHandler(ITransactionRepository repository, IUnitOfWork unitOfWork, ICurrentUser currentUser)
    {
        _repository = repository;
        _unitOfWork = unitOfWork;
        _currentUser = currentUser;
    }

    public async Task<Guid> Handle(CreateTransactionCommand cmd, CancellationToken ct)
    {
        var tx = Transaction.Create(
            _currentUser.userId,
            cmd.AssetType,
            cmd.Type,
            cmd.Quantity,
            cmd.UnitPriceTry,
            cmd.FeeTry,
            cmd.OccurredAt,
            cmd.Note
        );


        await _repository.AddAsync(tx, ct);
        await _unitOfWork.SaveChangesAsync(ct);


        return tx.Id.Value;
    }
}