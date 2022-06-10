using Microsoft.EntityFrameworkCore;
using UdemyApiWithToken.Domain.Entities;
using UdemyApiWithToken.Domain.Model;

namespace UdemyApiWithToken.Domain.Repositorys
{
    public class ProsuctRepository : BaseRepository<UdemyApiWithTokenContext,Product>,IProductRepository
    {
        public ProsuctRepository(UdemyApiWithTokenContext context) : base(context)
        {
           
        }
    }
}
