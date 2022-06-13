using UdemyApiWithToken.Domain.Model;

namespace UdemyApiWithToken.Security.Token
{
    public class TokenHandler : ITokenHandler
    {
        public AccessToken CreateAccessToken(User user)
        {
            throw new NotImplementedException();
        }

        public void RevokeRefreshToken(User user)
        {
            throw new NotImplementedException();
        }
    }
}
