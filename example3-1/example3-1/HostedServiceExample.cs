namespace example3_1;

public class HostedServiceExample : IHostedService, IDisposable, IAsyncDisposable
{
    private Timer? _timer = null;
    private readonly IServiceScopeFactory _scopeFactory;

    public HostedServiceExample(IServiceScopeFactory scopeFactory)
    {
        _scopeFactory = scopeFactory;
    }

    public Task StartAsync(CancellationToken cancellationToken)
    {
        _timer = new Timer(DoWork, null, TimeSpan.Zero, TimeSpan.FromSeconds(5));
        return Task.CompletedTask;
    }
    
    private void DoWork(object? state)
    {
        Console.WriteLine("DoWork");
    }

    public Task StopAsync(CancellationToken cancellationToken)
    {
        _timer?.Change(Timeout.Infinite, 0);
        return Task.CompletedTask;
    }

    public void Dispose()
    {
        _timer?.Dispose();
    }

    public async ValueTask DisposeAsync()
    {
        if (_timer != null) await _timer.DisposeAsync();
    }
}