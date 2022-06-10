using UdemyApiWithToken.Domain.Model;
using UdemyApiWithToken.Domain.Response;

namespace UdemyApiWithToken.Domain.Services
{
    public interface IProductService:IBaseService<Product,ProductResponse>
    {
    }
}
