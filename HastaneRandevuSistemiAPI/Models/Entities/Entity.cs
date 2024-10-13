namespace HastaneRandevuSistemiAPI.Models.Entities;

public class Entity<T,TId>
{
    public TId Id { get; set; }
    public string? Name { get; set; }
    public string? Surname { get; set; }
}
