using WIMS.Application.Common.Interfaces;

namespace WIMS.Infrastructure.Identity;

public sealed class CurrentUser : ICurrentUser
{
    public Guid userId => Guid.Parse("11111111-1111-1111-1111-111111111111");
}