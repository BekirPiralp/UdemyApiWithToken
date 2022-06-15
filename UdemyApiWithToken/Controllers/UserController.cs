using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using UdemyApiWithToken.Domain.Model;
using UdemyApiWithToken.Domain.Response;
using UdemyApiWithToken.Domain.Services;
using UdemyApiWithToken.Resources;

namespace UdemyApiWithToken.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService service;
        private readonly IMapper mapper;

        public UserController(IUserService service, IMapper mapper)
        {
            this.service = service;
            this.mapper = mapper;
        }

        [Authorize]
        [HttpGet()]
        public IActionResult GetUser()
        {
            IEnumerable<Claim> claims = User.Claims;

            string userIdStr = claims.Where(c => c.Type == ClaimTypes.NameIdentifier).FirstOrDefault().Value;
            int userId = int.Parse(userIdStr);
            return donder(service.FindById(userId));
        }

        [AllowAnonymous]
        [HttpPost]
        public IActionResult AddUser(UserResource userResource)
        {
            User user = mapper.Map<User>(userResource);
            return donder(service.AddUser(user));
        }

        private ActionResult donder(dynamic response)
        {
            if (response.Success)
                return Ok(response.Entity);
            else
                return BadRequest(response.Message);

        }
    }
}
