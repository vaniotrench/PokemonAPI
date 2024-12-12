namespace PokemonAPI.Models
{
    public class PokemonType
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public ICollection<Pokemon> Pokemons { get; set; } // Navigation property
    }
}
