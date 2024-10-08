// namespace Framework.Domain;
//
// public class DelegatingSubscription : ISubscription
// {
//     private readonly Action _unsubscribeAction;
//     public DelegatingSubscription(Action unsubscribeAction)
//     {
//         _unsubscribeAction = unsubscribeAction;
//     }
//     public void Unsubscribe()
//     {
//         _unsubscribeAction.Invoke();
//     }
//     public void Dispose()
//     {
//         this.Unsubscribe();
//     }
// }