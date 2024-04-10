// Controllers/ProductsController.cs  
using Microsoft.AspNetCore.Mvc;  
using MyWebApi.Services;  
using System.Threading.Tasks;  
  
namespace MyWebApi.Controllers  
{  
    [ApiController]  
    [Route("[controller]")]  
    public class ProductsController : ControllerBase  
    {  
        private readonly ProductService _productService;  
  
        public ProductsController(ProductService productService)  
        {  
            _productService = productService;  
        }  
  
        // GET: api/products  
        [HttpGet]  
        public async Task<IActionResult> GetProducts()  
        {  
            try  
            {  
                var products = await _productService.GetProductsAsync();  
                return Ok(products);  
            }  
            catch (Exception ex)  
            {  
                // 在这里可以记录异常或返回错误信息给客户端  
                return StatusCode(500, "Internal server error");  
            }  
        }  
  
        // GET: api/products/5  
        [HttpGet("{id}")]  
        public async Task<IActionResult> GetProduct(int id)  
        {  
            try  
            {  
                var product = await _productService.GetProductByIdAsync(id);  
                return Ok(product);  
            }  
            catch (NotFoundException ex)  
            {  
                // 特定的异常处理，返回404 Not Found状态码  
                return NotFound(ex.Message);  
            }  
            catch (Exception ex)  
            {  
                // 其他异常处理  
                return StatusCode(500, "Internal server error");  
            }  
        }  
    }  
}