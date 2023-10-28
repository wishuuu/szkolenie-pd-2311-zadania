using System;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;

namespace example4_1
{
    public interface IHostedService
    {
        Task Start();
        Task Stop();
    }
    
    public class HostedServiceExample : IHostedService
    {
        private Timer _timer = null;
        public Task Start()
        {
            _timer = new Timer(DoWork, null, 0, 1000);
            return Task.CompletedTask;
        }

        public Task Stop()
        {
            _timer?.Dispose();
            return Task.CompletedTask;
        }
        
        private void DoWork(object state)
        {
            Console.WriteLine("DoWork");
        }
    }
    
    public static class ServiceProviderExtensions
    {
        public static void StartHostedServices(this IServiceProvider serviceProvider)
        {
            var hostedServices = serviceProvider.GetServices<IHostedService>();
            foreach (var hostedService in hostedServices)
            {
                hostedService.Start();
            }
        }
    }
}