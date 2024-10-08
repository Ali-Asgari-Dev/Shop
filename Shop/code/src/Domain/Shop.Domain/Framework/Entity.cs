namespace Framework.Domain;

public class Entity<TKey>
{
    public TKey Id { get; protected set; }
    public DateTime CreateDateTime { get; protected set; }=DateTime.Now;
    public DateTime? UpdateDateTime { get; protected set; }
}