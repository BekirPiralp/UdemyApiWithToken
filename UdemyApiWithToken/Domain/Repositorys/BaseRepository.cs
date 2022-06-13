using Microsoft.EntityFrameworkCore;
using UdemyApiWithToken.Domain.Entities;
using UdemyApiWithToken.Domain.Model;

namespace UdemyApiWithToken.Domain.Repositorys
{
    public class BaseRepository<TContext,TEntity>:IBaseRepository<TEntity>
        where TContext: DbContext, new()
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
            return await context.Set<TEntity>().FindAsync(entityId);
        }

        public async Task<IEnumerable<TEntity>> ListAsync()
        {
            return await context.Set<TEntity>().ToListAsync();
        }

        public async Task RemoveAsync(int entityId)
        {
            context.Set<TEntity>().Remove(await GetByIdAsync(entityId));
        }

        public void Update(TEntity entity)
        {
            context.Entry(entity).State = EntityState.Modified;
            //context.Dispose();
            // context.Set<TEntity>().Update(entity);
            //tcontext = new TContext();
            //tcontext.Update(entity);
            //using (TContext tcontext = new TContext())
            //{
            //    var a = tcontext.Entry(entity);
            //    a.State = EntityState.Modified;
            //    tcontext.SaveChanges();
            //}

        }
    }
}
