// dotnet ef migrations add InitialCreate --project ./Infrastructure --startup-project ./example-ef

using Infrastructure;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

ServiceCollection services = new();

services.AddDbContext<MyContext>(options =>
    options.UseInMemoryDatabase("localinMemo"));

services.AddScoped<UnitOfWork>();

ServiceProvider serviceProvider = services.BuildServiceProvider();

using IServiceScope scope = serviceProvider.CreateScope();
UnitOfWork unitOfWork = scope.ServiceProvider.GetRequiredService<UnitOfWork>();
unitOfWork.Context.Database.EnsureCreated();

var orders = unitOfWork.Context.Orders;

foreach (var order in orders)
{
    Console.WriteLine(order.OrderNumber);
}