using Microsoft.Extensions.Options;
using UdemyApiWithToken.Domain.Model;

namespace UdemyApiWithToken.Security.Token
{
    public class TokenHandler : ITokenHandler
    {
        TokenOptions _tokenOptions;
        public TokenHandler(IOptions<TokenOptions> tokenOptions)
        {
            _tokenOptions = tokenOptions.Value;
        }

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
