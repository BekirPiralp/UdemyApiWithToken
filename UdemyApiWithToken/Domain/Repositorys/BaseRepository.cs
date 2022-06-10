using Microsoft.EntityFrameworkCore;
using UdemyApiWithToken.Domain.Entities;

namespace UdemyApiWithToken.Domain.Repositorys
{
    public class BaseRepository<TContext,TEntity>:IBaseRepository<TEntity>
        where TContext: DbContext
        where TEntity : class
    {
        protected TContext context;
        public BaseRepository(TContext context)
        {
            this.context = context;
        }

        public async Task AddAsync(TEntity entity)
        {
            await (context.Set<TEntity>()).AddAsync(entity);
        }

        public async Task<TEntity> GetByIdAsync(int entityId)
        {
            return await (context.Set<TEntity>()).FindAsync(entityId);
        }

        public async Task<IEnumerable<TEntity>> ListAsync()
        {
            return await (context.Set<TEntity>()).ToListAsync();
        }

        public async Task RemoveAsync(int entityId)
        {
            (context.Set<TEntity>()).Remove(await GetByIdAsync(entityId));
        }

        public void Update(TEntity entity)
        {
            (context.Set<TEntity>()).Update(entity);
        }
    }
}
