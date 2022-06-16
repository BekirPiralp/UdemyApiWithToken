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
            AccessTokenResponse response;
            var userResponse = service.FindByEmailAndPassword(email, password);
            if(userResponse.Success)
            {
                var accessToken = handler.CreateAccessToken(userResponse.Entity);
                service.SaveRefreshToken(userResponse.Entity.Id, accessToken.RefreshToken);
                response = new AccessTokenResponse(accessToken);
            }
            else
            {
                response = new AccessTokenResponse(userResponse.Message);
            }
            return response;
        }

        public AccessTokenResponse CreateAccessTokenByRefreshToken(string refreshToken)
        {
            AccessTokenResponse response;
            var userResponse = service.GetUserWithRefreshToken(refreshToken);
            if(userResponse.Success){

                if (userResponse.Entity.RefreshTokenEndDate >= DateTime.Now){

                    var accessToken = handler.CreateAccessToken(userResponse.Entity);
                    service.SaveRefreshToken(userResponse.Entity.Id, accessToken.RefreshToken);

                    response = new AccessTokenResponse(accessToken);
                }
                else{
                    response = new AccessTokenResponse($"{userResponse.Entity.Name.ToUpper()} " +
                        $"isimli kullanıcının tekrar giriş yapması lazım.");
                }
                
            }
            else{
                response = new AccessTokenResponse
                (userResponse.Message);
            }
            return response;
        }

        public AccessTokenResponse RemoveRefreshToken(string refreshToken)
        {
            AccessTokenResponse response;
            var userResponse = service.GetUserWithRefreshToken(refreshToken);
            if(userResponse.Success){
                service.RemoveRefreshToken(userResponse.Entity);
                //handler.RemoveRefreshToken(userResponse.Entity)
                response = new AccessTokenResponse(new AccessToken());//başarılı
            }
            else{
                response = new AccessTokenResponse(userResponse.Message);
            }
            return response;
        }
    }
}
