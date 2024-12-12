using Microsoft.AspNetCore.Mvc;
using PokemonAPI.Data;
using PokemonAPI.Models;

namespace PokemonAPI.Controllers
{
    [ApiController]
    [Route("/api/[controller]")]
    public class PokemonController : ControllerBase
    {
        private AppDBContext DBContext { get; }

        public PokemonController(AppDBContext dBContext)
        {
            DBContext = dBContext;
        }

        [HttpGet]
        public IEnumerable<Pokemon> Get()
        {
            // SELECT * FROM Pokemons ORDER BY Id;
            return DBContext.Pokemons.OrderBy(p => p.Id).ToArray();
        }

        [HttpGet("{id}")]
        public ActionResult<Pokemon> GetById(int id)
        {
            var pokemon = DBContext.Pokemons.Find(id);

            if (pokemon is null)
            {
                return NotFound();
            }

            return Ok(pokemon);
        }

        [HttpPut]
        public ActionResult<Pokemon> Update(Pokemon input)
        {
            var pokemon = DBContext.Pokemons.Find(input.Id);

            if (pokemon is null)
            {
                DBContext.Pokemons.Add(input);
                DBContext.SaveChanges();
                return Created("", input);
            }
            else
            {
                pokemon.Name = input.Name;
                pokemon.TypeId = input.TypeId;
                pokemon.Description = input.Description;
                DBContext.SaveChanges();
                return Ok(pokemon);
            }
        }

        [HttpPost]
        public ActionResult<Pokemon> Create(Pokemon input)
        {
            DBContext.Pokemons.Add(input);
            DBContext.SaveChanges();
            return Created("", input);
        }

        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            var pokemon = DBContext.Pokemons.Find(id);

            if (pokemon == null)
            {
                return NotFound();
            }

            DBContext.Pokemons.Remove(pokemon);
            DBContext.SaveChanges();

            return Ok();
        }
    }
}
