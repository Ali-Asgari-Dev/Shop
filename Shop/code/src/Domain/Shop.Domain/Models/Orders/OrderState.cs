namespace Shop.Domain.Models.Orders;


public abstract class OrderState
{
    internal OrderState()
    {
        
    }
    public static OrderRegisteredState RegisteredState() => OrderStatePool.GetState<OrderRegisteredState>();
    public static OrderPendingPaymentState PendingPaymentState() => OrderStatePool.GetState<OrderPendingPaymentState>();
    public static OrderPaidState PaidState() => OrderStatePool.GetState<OrderPaidState>();
    public abstract bool IsOpen();
    public abstract string PersianTitle();
    public abstract string Description();
}
public class OrderRegisteredState : OrderState
{
    internal OrderRegisteredState()
    {
        
    }
    
    public override bool IsOpen() => true;

    public override string PersianTitle() => "ثبت شده";

    public override string Description()
        => "سفارش شما ثبت شد";
}

public class OrderPendingPaymentState : OrderState
{
    internal OrderPendingPaymentState()
    {
        
    }
    
    public override bool IsOpen() => true;
    public override string PersianTitle() => "درانتظار پرداخت";

    public override string Description()
        => "";
}

public class OrderPaidState : OrderState
{
    internal OrderPaidState()
    {
        
    }
    
    public override bool IsOpen() => false;
    public override string PersianTitle() =>   "پرداخت شده";
    public override string Description() => "سفارش شما پرداخت شد";
}
public static class OrderStatePool
{
    private static Dictionary<string, object> _states = new Dictionary<string, object>()
    {
        { nameof(OrderRegisteredState), new OrderRegisteredState()},
        { nameof(OrderPendingPaymentState), new OrderPendingPaymentState()},
        { nameof(OrderPaidState), new OrderPaidState()},
    };
    public static T GetState<T>() where T : OrderState
    {
        return GetState(typeof(T)) as T;
    }

    public static OrderState GetState(Type type)
    {
        return _states[type.Name] as OrderState;
    }
}
public static class OrderStateValueFactory
{
    private static Dictionary<Type, int> _values = new Dictionary<Type, int>()
    {
        { typeof(OrderRegisteredState), 1 },
        { typeof(OrderPendingPaymentState), 2},
        { typeof(OrderPaidState), 3},
    };

    public static int GetValue(Type type)
    {
        return _values[type];
    }
    public static OrderState GetState(int value)
    {
        var type = _values.FirstOrDefault(a => a.Value == value);
        return OrderStatePool.GetState(type.Key);
    }
}