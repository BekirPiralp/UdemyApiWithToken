using Microsoft.EntityFrameworkCore;
using UdemyApiWithToken.Domain.Entities;
using UdemyApiWithToken.Domain.Model;

namespace UdemyApiWithToken.Domain.Repositorys
{
    public class ProsuctRepository : BaseRepository<UdemyApiWithTokenContext>,IProductRepository
    {
        public ProsuctRepository(UdemyApiWithTokenContext context) : base(context)
        {
        }

        public async Task AddProductAsync(Product product)
        {
           await context.Products.AddAsync(product);
        }

        public async Task<Product> GetProductByIdAsync(int productId)
        {
            return await context.Products.FindAsync(productId); //primary key'e göre
        }

        public async Task<IEnumerable<Product>> ListAsync()
        {
            return await context.Products.ToListAsync();
        }

        public async Task RemoveProductAsync(int product)
        {
            var entity = await GetProductByIdAsync(product);
            context.Products.Remove(entity);
        }

        public void UpdateProductAsync(Product product)
        {
             context.Products.Update(product);
        }
    }
}
