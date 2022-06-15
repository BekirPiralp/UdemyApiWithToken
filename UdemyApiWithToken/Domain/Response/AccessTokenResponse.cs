using UdemyApiWithToken.Security.Token;

namespace UdemyApiWithToken.Domain.Response
{
    public class AccessTokenResponse : BaseResponse<AccessToken>
    {
        public AccessTokenResponse(AccessToken entity) : base(entity)
        {
        }
        public AccessTokenResponse(string message) : base(message)
        {
        }
    }
}
