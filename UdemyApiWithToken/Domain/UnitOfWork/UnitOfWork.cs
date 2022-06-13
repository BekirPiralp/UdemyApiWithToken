using Microsoft.EntityFrameworkCore;
using UdemyApiWithToken.Domain.Entities;

namespace UdemyApiWithToken.Domain.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly DbContext _context;

        public UnitOfWork(UdemyApiWithTokenContext context)
        {
            _context = context;
        }

        public async Task ComplateAsync()
        {
            await _context.SaveChangesAsync();
        }
    }
}
