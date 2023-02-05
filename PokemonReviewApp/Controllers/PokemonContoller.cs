using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PokemonReviewApp.Interface;
using PokemonReviewApp.Models;
using PokemonReviewApp.Repository;

namespace PokemonReviewApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PokemonContoller : ControllerBase
    {
        private readonly IPokemonRepository _pokemonRepository;

        public PokemonContoller(IPokemonRepository pokemonRepository)
        {
            _pokemonRepository = pokemonRepository;
        }

        [HttpGet]
        [ProducesResponseType(200, Type = typeof(IEnumerable<Pokemon>))]
        public IActionResult GetPokemons()
        {
            if (!ModelState.IsValid) { return BadRequest(ModelState); }
            return Ok(_pokemonRepository.GetPokemons());
        }
    }
}
