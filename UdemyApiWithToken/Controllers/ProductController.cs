using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using UdemyApiWithToken.Domain.Services;
using AutoMapper;

namespace UdemyApiWithToken.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProductService _productService;
        private readonly IMapper _mapper;

        public ProductController(IProductService productService, IMapper mapper)
        {
            _productService = productService;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult> GetList()
        {
            var response = await _productService.ListAsync();

            return donder(response);
        }

        [HttpGet("{id:int}")]
        public async Task<ActionResult> GetFindById(int id)
        {
            return donder(await _productService.FindByIdAsync(id));
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
