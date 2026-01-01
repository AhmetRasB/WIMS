using System.Security.Cryptography;
using WIMS.Application.Common.Interfaces;
using WIMS.Domain.Transactions;

namespace WIMS.Application.Transactions.Commands.DeleteTransaction;

public sealed class DeleteTransactionHandler
{
    private readonly ITransactionRepository _repository;
    private readonly IUnitOfWork _unitOfWork;
    private readonly ICurrentUser _currentUser;

    public DeleteTransactionHandler(ITransactionRepository repository, IUnitOfWork unitOfWork, ICurrentUser currentUser)
    {
        _repository = repository;
        _unitOfWork = unitOfWork;
        _currentUser = currentUser;
    }

    public async Task<bool> Handle(DeleteTransactionCommand request, CancellationToken cancellationToken)
    {
        var id = new TransactionId(request.TransactionId);
        var tx = _repository.GetByIdAsync(id, _currentUser.userId, cancellationToken);
        if (tx is null)
        {
            return false;
        }
        _repository.Remove(await tx);
         await _unitOfWork.SaveChangesAsync(cancellationToken);
         return true;
    }
}