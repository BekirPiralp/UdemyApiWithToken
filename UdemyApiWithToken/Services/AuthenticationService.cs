using UdemyApiWithToken.Domain.Response;
using UdemyApiWithToken.Domain.Services;
using UdemyApiWithToken.Security.Token;

namespace UdemyApiWithToken.Services
{
    public class AuthenticationService : IAuthenticationService
    {
        private readonly IUserService service;
        private readonly ITokenHandler handler;

        public AuthenticationService(IUserService service, ITokenHandler handler)
        {
            this.service = service;
            this.handler = handler;
        }

        public AccessTokenResponse CreateAccessToken(string email, string password)
        {
            throw new NotImplementedException();
        }

        public AccessTokenResponse CreateAccessTokenByRefreshToken(string refreshToken)
        {
            throw new NotImplementedException();
        }

        public AccessTokenResponse RemoveRefreshToken(string refreshToken)
        {
            throw new NotImplementedException();
        }
    }
}
