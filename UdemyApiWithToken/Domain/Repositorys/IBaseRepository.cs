namespace UdemyApiWithToken.Domain.Repositorys
{
    public interface IBaseRepository<TEntity>
    {
        Task<IEnumerable<TEntity>> ListAsync();

        Task AddAsync(TEntity entity);

        void UpdateAsync(TEntity entity);

        Task RemoveAsync(int entity);

        Task<TEntity> GetByIdAsync(int entityId);
    }
}
