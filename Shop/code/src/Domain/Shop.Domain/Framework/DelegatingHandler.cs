// namespace Framework.Domain;
//
// public class DelegatingHandler<T> : IEventHandler<T> where T : IEvent
// {
//     private readonly Action<T> _handler;
//
//     public DelegatingHandler(Action<T> handler)
//     {
//         _handler = handler;
//     }
//
//     public void Handle(T @event)
//     {
//         _handler.Invoke(@event);
//     }
// }