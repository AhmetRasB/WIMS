using WIMS.Domain.Common;

namespace WIMS.Domain.Users;

public sealed class User : Entity<Guid>, IAggregateRoot
{
    private User()
    {
        
    }
    public User(Guid id) => Id = id;
}