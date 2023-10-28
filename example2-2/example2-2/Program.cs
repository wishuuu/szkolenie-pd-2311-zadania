using Microsoft.Extensions.DependencyInjection;

namespace example2_2
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            ServiceCollection services = new ServiceCollection();

            services.AddScoped<A>();
            services.AddScoped<B>();
            services.AddScoped<C>();
            services.AddScoped<D>();
            services.AddScoped<E>();
            
            ServiceProvider serviceProvider = services.BuildServiceProvider();
            
            E e = serviceProvider.GetService<E>();
        }
    }
}