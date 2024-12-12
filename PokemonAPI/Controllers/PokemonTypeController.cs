using Microsoft.AspNetCore.Mvc;
using PokemonAPI.Data;
using PokemonAPI.Models;

namespace PokemonAPI.Controllers
{
    [ApiController]
    [Route("/api/[controller]")]
    public class PokemonTypeController : ControllerBase
    {
        private AppDBContext DBContext { get; }

        public PokemonTypeController(AppDBContext dBContext)
        {
            DBContext = dBContext;
        }

        [HttpGet]
        public IEnumerable<PokemonType> Get()
        {
            // SELECT * FROM Types ORDER BY Id;
            return DBContext.Types.OrderBy(t => t.Id).ToArray();
        }

        [HttpGet("{id}")]
        public ActionResult<PokemonType> GetById(int id)
        {
            var type = DBContext.Types.Find(id);

            if (type is null)
            {
                return NotFound();
            }

            return Ok(type);
        }

        [HttpPut]
        public ActionResult<PokemonType> Update(PokemonType input)
        {
            var type = DBContext.Types.Find(input.Id);

            if (type is null)
            {
                DBContext.Types.Add(input);
                DBContext.SaveChanges();
                return Created("", input);
            }
            else
            {
                type.Name = input.Name;
                DBContext.SaveChanges();
                return Ok(type);
            }
        }

        [HttpPost]
        public ActionResult<PokemonType> Create(PokemonType input)
        {
            DBContext.Types.Add(input);
            DBContext.SaveChanges();
            return Created("", input);
        }

        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            var type = DBContext.Types.Find(id);

            if (type == null)
            {
                return NotFound();
            }

            DBContext.Types.Remove(type);
            DBContext.SaveChanges();

            return Ok();
        }
    }
}
