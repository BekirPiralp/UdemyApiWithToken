using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using UdemyApiWithToken.Domain.Services;
using AutoMapper;
using UdemyApiWithToken.Resources;
using UdemyApiWithToken.Extensions;
using UdemyApiWithToken.Domain.Model;

namespace UdemyApiWithToken.Controllers
{
    //[Route("api/[controller]/[action]")]
    [Route("api/[controller]")]
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

        [HttpPost]
        public async Task<IActionResult> AddProduct(ProductResource productResource)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState.GetErrorMessages());
            }
            else
            {
                Product product = _mapper.Map<ProductResource,Product>(productResource);
                
                return donder(await _productService.AddAsync(product));
            }
        }

        [HttpPut]
        public async Task<ActionResult> UpdateProduct(ProductResource productResource,int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState.GetErrorMessages());
            }
            else
            {
                Product product = _mapper.Map<ProductResource, Product>(productResource);
                var veri = await _productService.FindByIdAsync(id);
                veri.Entity.Price = product.Price;
                veri.Entity.Name = product.Name;
                veri.Entity.Category = product.Category;


                /**
                 * Sistemde getirilen nesne olup ta yeni nesne oluşturulup id eşitlemesi yapınca 
                 * hata veriyor, sisdemde bu idli izlenen bir nesne var diye
                 */
                //Product test = new Product { Id = id,Name = product.Name,Category = product.Category,Price = product.Price };
                //product.Id= id;
                return donder(await _productService.UpdateAsync(veri.Entity,id));
            }
        }

        [HttpDelete]
        public async Task<IActionResult> RemoveProduct(int id)
        {
            return donder(await _productService.RemoveAsync(id));
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
