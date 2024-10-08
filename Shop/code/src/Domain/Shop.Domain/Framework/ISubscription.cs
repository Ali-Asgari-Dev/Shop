namespace Framework.Domain;

public interface ISubscription : IDisposable
{
    void Unsubscribe();
}