
using MyWebApi.Services; 

// Program.cs (针对 .NET 5 或更高版本)  
var builder = WebApplication.CreateBuilder(args);  
  
// 添加服务到依赖注入容器  
builder.Services.AddControllers();  
builder.Services.AddScoped<ProductService>(); // 将ProductService注册为Scoped服务  
  
var app = builder.Build();  
  
// 配置中间件  
if (app.Environment.IsDevelopment())  
{  
    app.UseDeveloperExceptionPage();  
}  
  
app.UseHttpsRedirection();  
app.UseAuthorization();  
  
app.MapControllers(); // 映射控制器路由  
  
app.Run();