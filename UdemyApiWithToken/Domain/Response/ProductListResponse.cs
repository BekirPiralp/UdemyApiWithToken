using UdemyApiWithToken.Domain.Model;

namespace UdemyApiWithToken.Domain.Response
{
    public class ProductListResponse : BaseResponse<IEnumerable<Product>>
    {
        public ProductListResponse(IEnumerable<Product> entities) : base(entities)
        {
        }

        public ProductListResponse(string message) : base(message)
        {
        }

    }
}
