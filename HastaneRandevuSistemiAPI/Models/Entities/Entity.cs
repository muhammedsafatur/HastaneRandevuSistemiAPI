namespace HastaneRandevuSistemiAPI.Models.Entities
{
    public abstract class Entity<TId>
    {
        public TId Id { get; set; }
        public string? Name { get; set; }
        public string? Surname { get; set; }

        // Eşitlik karşılaştırması için Equals ve GetHashCode metotları ekleyelim.
        public override bool Equals(object? obj)
        {
            if (obj is Entity<TId> entity)
            {
                return EqualityComparer<TId>.Default.Equals(Id, entity.Id);
            }
            return false;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(Id);
        }
    }
}
