using UdemyApiWithToken.Domain.Model;

namespace UdemyApiWithToken.Security.Token
{
    public interface ITokenHandler
    {
        AccessToken CreateAccessToken(User user);
        void RemoveRefreshToken(User user);
    }
}
