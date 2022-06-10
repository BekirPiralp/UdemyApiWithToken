using UdemyApiWithToken.Domain.Response;

namespace UdemyApiWithToken.Domain.Services
{
    public interface IBaseService<TEntity,IRespose>
        where TEntity : class
        where IRespose : IBaseResponse<TEntity>,new()
    {
        Task<IRespose> ListAsync();
        Task<IRespose> AddAsync(TEntity entity);
        Task<IRespose> RemoveAsync(int entityId);
        Task<IRespose> UpdateAsync(TEntity entity,int entityId);
        Task<IRespose> FindByIdAsync(int entityId);
    }
}
