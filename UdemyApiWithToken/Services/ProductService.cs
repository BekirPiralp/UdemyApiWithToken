using UdemyApiWithToken.Domain.Model;
using UdemyApiWithToken.Domain.Repositorys;
using UdemyApiWithToken.Domain.Response;
using UdemyApiWithToken.Domain.UnitOfWork;

namespace UdemyApiWithToken.Services
{
    public class ProductService : BaseService<Product, ProductResponse, ProductListResponse, ProsuctRepository>
    {
        public ProductService(ProsuctRepository repository, IUnitOfWork unitOfWork) : base(repository, unitOfWork)
        {
        }
    }
}
