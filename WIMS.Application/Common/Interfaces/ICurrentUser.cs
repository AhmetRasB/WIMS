namespace WIMS.Application.Common.Interfaces;

public interface ICurrentUser
{
    Guid userId { get; }
}