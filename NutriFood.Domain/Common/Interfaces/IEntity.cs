namespace NutriFood.Domain.Common.Interfaces
{
    public interface IEntity<TId>
    {
        TId Id { get; set; }
    }
}
