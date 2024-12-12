namespace PokemonAPI.Models
{
    public class Pokemon
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int TypeId { get; set; }
        public string Description { get; set; }
        public PokemonType? Type { get; set; } // Navigation property
    }
}
