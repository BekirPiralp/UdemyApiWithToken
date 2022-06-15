using UdemyApiWithToken.Domain.Response;

namespace UdemyApiWithToken.Domain.Services
{
    public interface IAuthenticationService
    {
        AccessTokenResponse CreateAccessToken(string email,string password);
        AccessTokenResponse CreateAccessTokenByRefreshToken(string refreshToken);
        AccessTokenResponse RemoveRefreshToken(string refreshToken);
    }
}
