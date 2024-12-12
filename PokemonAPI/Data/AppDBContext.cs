using Microsoft.EntityFrameworkCore;
using PokemonAPI.Models;
using System.Collections.Generic;

namespace PokemonAPI.Data
{
    public class AppDBContext : DbContext
    {
        public AppDBContext(DbContextOptions<AppDBContext> options) : base(options) { }

        public DbSet<Pokemon> Pokemons { get; set; }
        public DbSet<PokemonType> Types { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<PokemonType>().HasData(
                new PokemonType { Id = 1, Name = "Fire" },
                new PokemonType { Id = 2, Name = "Water" },
                new PokemonType { Id = 3, Name = "Grass" }
            );

            modelBuilder.Entity<Pokemon>().HasData(
                new Pokemon { Id = 1, Name = "Charmander", TypeId = 1, Description = "A fire-type Pokémon." },
                new Pokemon { Id = 2, Name = "Squirtle", TypeId = 2, Description = "A water-type Pokémon." },
                new Pokemon { Id = 3, Name = "Bulbasaur", TypeId = 3, Description = "A grass-type Pokémon." }
            );
        }
    }
    }
