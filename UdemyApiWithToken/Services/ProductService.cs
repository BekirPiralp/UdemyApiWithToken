using UdemyApiWithToken.Domain.Model;
using UdemyApiWithToken.Domain.Repositorys;
using UdemyApiWithToken.Domain.Response;
using UdemyApiWithToken.Domain.Services;
using UdemyApiWithToken.Domain.UnitOfWork;

namespace UdemyApiWithToken.Services
{
    public class ProductService : BaseService<Product, ProductResponse, ProductListResponse, ProductRepository>,IProductService
    {
        public ProductService(IProductRepository repository, IUnitOfWork unitOfWork) : base(repository, unitOfWork)
        {
        }
    }
}
