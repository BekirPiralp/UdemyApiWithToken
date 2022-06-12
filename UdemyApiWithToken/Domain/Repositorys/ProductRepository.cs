using Microsoft.EntityFrameworkCore;
using UdemyApiWithToken.Domain.Entities;
using UdemyApiWithToken.Domain.Model;

namespace UdemyApiWithToken.Domain.Repositorys
{
    public class ProductRepository : BaseRepository<UdemyApiWithTokenContext,Product>,IProductRepository
    {
        public ProductRepository(UdemyApiWithTokenContext context) : base(context)
        {
           
        }
    }
}
