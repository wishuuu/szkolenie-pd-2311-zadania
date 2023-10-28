using Microsoft.Extensions.DependencyInjection;

namespace example5
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            ServiceCollection services = new ServiceCollection();

            services.AddSingleton<MyInterface, A>();
            services.AddSingleton<MyInterface, B>();
            
            ServiceProvider serviceProvider = services.BuildServiceProvider();
            
            var coto = serviceProvider.GetService<MyInterface>();
            
            coto.DoSomething();
        }
    }
}