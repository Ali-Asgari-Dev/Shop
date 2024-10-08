namespace Framework.Domain;

public interface IEventBus
{
    void Dispatch<T>(T @event) where T : IEvent;
}