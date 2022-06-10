using Microsoft.EntityFrameworkCore;
using UdemyApiWithToken.Domain.Entities;

namespace UdemyApiWithToken.Domain.Repositorys
{
    public class BaseRepository<TContext>where TContext: DbContext
    {
        protected TContext context;
        public BaseRepository(TContext context)
        {
            this.context = context;
        }
    }
}
