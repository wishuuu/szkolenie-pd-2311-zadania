using Microsoft.Extensions.DependencyInjection;

namespace example4_1
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            ServiceCollection services = new ServiceCollection();

            services.AddSingleton<IHostedService, HostedServiceExample>();
            
            ServiceProvider serviceProvider = services.BuildServiceProvider();
            
            serviceProvider.StartHostedServices();
     
            System.Console.ReadKey();
        }
    }
}