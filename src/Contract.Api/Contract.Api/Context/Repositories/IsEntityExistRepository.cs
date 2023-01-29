namespace Contract.Api.Context.Repositories;

public interface IsEntityExistRepository
{
    Task<bool> IsEntityExist(Guid id);
}