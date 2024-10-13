namespace HastaneRandevuSistemiAPI.Models.Entities;

public class EntityBase<T,TId>
{
    public T? Id { get; set; }
    public string? Name { get; set; }
    public string? Surname { get; set; }
}
