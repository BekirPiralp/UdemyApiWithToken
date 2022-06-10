using UdemyApiWithToken.Domain.Model;

namespace UdemyApiWithToken.Domain.Response
{
    public class ProductResponse : BaseResponse<Product>
    {
        public ProductResponse(Product entity) : base(entity)
        {
        }

        public ProductResponse(string message) : base(message)
        {
        }

    }
}
