using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PokemonReviewApp.Dto;
using PokemonReviewApp.Interface;
using PokemonReviewApp.Models;
using PokemonReviewApp.Repository;
using System.Collections.Generic;

namespace PokemonReviewApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PokemonController : ControllerBase
    {
        private readonly IPokemonRepository _pokemonRepository;
        private readonly IMapper _mapper;

        public PokemonController(IPokemonRepository pokemonRepository, IMapper mapper)
        {
            _pokemonRepository = pokemonRepository;
            _mapper = mapper;
        }

        [HttpGet]
        [ProducesResponseType(200, Type = typeof(IEnumerable<Pokemon>))]
        public IActionResult GetPokemons()
        {
            List<PokemonDto> pokemons = _mapper.Map<List<PokemonDto>>(_pokemonRepository.GetPokemons());

            if (!ModelState.IsValid) { return BadRequest(ModelState); }

            return Ok(pokemons);
        }

        [HttpGet("{pokemonId}")]
        [ProducesResponseType(200, Type = typeof(Pokemon))]
        [ProducesResponseType(400)]
        public IActionResult GetPokemon(int pokemonId)
        {
            if (!_pokemonRepository.PokemonExists(pokemonId)) 
                return NotFound();

            PokemonDto pokemon = _mapper.Map<PokemonDto>(_pokemonRepository.GetPokemon(pokemonId));

            if (!ModelState.IsValid) 
                return BadRequest(ModelState); 

            return Ok(pokemon);
        }

        [HttpGet("{pokemonId}/rating")]
        [ProducesResponseType(200, Type = typeof(decimal))]
        [ProducesResponseType(400)]
        public IActionResult GetPokemonRating(int pokemonId)
        {
            if (!_pokemonRepository.PokemonExists(pokemonId)) 
                return NotFound(); 

            if (!ModelState.IsValid) 
                return BadRequest(ModelState); 

            return Ok(_pokemonRepository.GetPokemonRating(pokemonId));
        }
    }
}
