using UdemyApiWithToken.Domain.Response;

namespace UdemyApiWithToken.Domain.Services
{
    public interface IBaseService<TEntity,Respose,ListResponse>
        where TEntity : class
        where Respose : IBaseResponse<TEntity>
        where ListResponse : IBaseResponse<IEnumerable<TEntity>>
    {
        Task<ListResponse> ListAsync();
        Task<Respose> AddAsync(TEntity entity);
        Task<Respose> RemoveAsync(int entityId);
        Task<Respose> UpdateAsync(TEntity entity,int entityId);
        Task<Respose> FindByIdAsync(int entityId);

        
    }
}
