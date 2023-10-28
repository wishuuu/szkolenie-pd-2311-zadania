namespace Infrastructure;

public class UnitOfWork : IDisposable
{
    public readonly MyContext Context;

    public UnitOfWork(MyContext context)
    {
        Context = context;
    }
    
    public void Commit()
    {
        Context.SaveChanges();
    }
    
    public Task CommitAsync()
    {
        return Context.SaveChangesAsync();
    }
    
    public void Dispose()
    {
        Context.Dispose();
    }
}