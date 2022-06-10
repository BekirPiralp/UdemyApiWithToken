using Microsoft.EntityFrameworkCore;

namespace UdemyApiWithToken.Domain.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly DbContext _context;

        public UnitOfWork(DbContext context)
        {
            _context = context;
        }

        public async Task ComplateAsync()
        {
            await _context.SaveChangesAsync();
        }
    }
}
