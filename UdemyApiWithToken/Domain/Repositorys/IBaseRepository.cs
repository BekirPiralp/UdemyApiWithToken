namespace UdemyApiWithToken.Domain.Repositorys
{
    public interface IBaseRepository<TEntity>
        where TEntity : class
    {
        Task<IEnumerable<TEntity>> ListAsync();

        Task AddAsync(TEntity entity);

        void Update(TEntity entity);

        Task RemoveAsync(int entityId);

        Task<TEntity> GetByIdAsync(int entityId);
    }
}
