using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using UdemyApiWithToken.Domain.Services;
using UdemyApiWithToken.Extensions;
using UdemyApiWithToken.Resources;

namespace UdemyApiWithToken.Controllers
{
    [Route("api/[controller]/[Action]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        private readonly IAuthenticationService authenticationService;

        public LoginController(IAuthenticationService authenticationService)
        {
            this.authenticationService = authenticationService;
        }

        [HttpPost]
        public IActionResult AccessToken(LoginResource loginResource)
        {
            IActionResult result;
            if (!ModelState.IsValid){
                result = BadRequest(ModelState.GetErrorMessages());
            }
            else{
                var accessTokenResponse=authenticationService.CreateAccessToken(loginResource.Email, loginResource.Password);
                
                result = donder(accessTokenResponse);
            }
            return result;
        }

        [HttpPost]
        public IActionResult RefreshToken(TokenResource tokenResource)
        {
            IActionResult result;
            var response = authenticationService.CreateAccessTokenByRefreshToken(tokenResource.RefreshToken);
            result = donder(response);
            return result;
        }

        [HttpPost]
        public IActionResult RemoveRefreshToken(TokenResource tokenResource)
        {
            IActionResult result;
            var response = authenticationService.RemoveRefreshToken(tokenResource.RefreshToken);
            result= donder(response);
            return result;
        }

        private IActionResult donder(dynamic response)
        {
            IActionResult result;
            if (response.Success)
            {
                result = Ok(response.Entity);
            }
            else
            {
                result = BadRequest(response.Message);
            }
            return result;
        }
    }
}
