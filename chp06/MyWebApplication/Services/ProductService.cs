// Services/ProductService.cs  
namespace MyWebApi.Services  
{  
    public class ProductService  
    {  
        // 模拟数据库中的数据  
        private List<Product> _products = new List<Product>  
        {  
            new Product { Id = 1, Name = "Product 1", Price = 100 },  
            new Product { Id = 2, Name = "Product 2", Price = 200 }  
        };  
  
        public async Task<IEnumerable<Product>> GetProductsAsync()  
        {  
            // 这里只是返回模拟数据，实际项目中可能会从数据库获取数据  
            await Task.Delay(100); // 模拟异步操作  
            return _products;  
        }  
  
        public async Task<Product> GetProductByIdAsync(int id)  
        {  
            var product = _products.FirstOrDefault(p => p.Id == id);  
            if (product == null)  
            {  
                throw new NotFoundException($"Product with ID {id} not found.");  
            }  
            await Task.Delay(100); // 模拟异步操作  
            return product;  
        }  
    }  
  
    public class NotFoundException : Exception  
    {  
        public NotFoundException(string message) : base(message) { }  
    }  
  
    // Product模型类  
    public class Product  
    {  
        public int Id { get; set; }  
        public string Name { get; set; }  
        public decimal Price { get; set; }  
    }  
}