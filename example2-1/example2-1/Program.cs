using Microsoft.Extensions.DependencyInjection;

namespace example2_1
{
    internal class Program
    {
        // Nuget package: Microsoft.Extensions.DependencyInjection
        public static void Main(string[] args)
        {
            ServiceCollection services = new ServiceCollection();

            services.AddSingleton<A>();
            services.AddScoped<B>();
            services.AddTransient<C>();
            
            ServiceProvider serviceProvider = services.BuildServiceProvider();
            
            A a1 = serviceProvider.GetService<A>();
            A a2 = serviceProvider.GetService<A>();
            B b1 = serviceProvider.GetService<B>();
            B b2 = serviceProvider.GetService<B>();
            C c1 = serviceProvider.GetService<C>();
            C c2 = serviceProvider.GetService<C>();

            
            
            
            
            
            
            
            
            
            
            // using (var scope = serviceProvider.CreateScope())
            // {
            //     A a3 = scope.ServiceProvider.GetService<A>();
            //     A a4 = scope.ServiceProvider.GetService<A>();
            //     B b3 = scope.ServiceProvider.GetService<B>();
            //     B b4 = scope.ServiceProvider.GetService<B>();
            //     C c3 = scope.ServiceProvider.GetService<C>();
            //     C c4 = scope.ServiceProvider.GetService<C>();
            // }
        }
    }
}