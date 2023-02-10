using Microsoft.EntityFrameworkCore;
using PokemonReviewApp.Data;
using PokemonReviewApp.Interface;
using PokemonReviewApp.Models;

namespace PokemonReviewApp.Repository
{
    public class PokemonRepository : IPokemonRepository
    {
        private readonly DataContext _context;

        public PokemonRepository(DataContext context)
        {
            _context = context;
        }

        public bool CreatePokemon(int ownerId, int categoryId, Pokemon pokemon)
        {
            Owner pokemonOwnerEntity = _context.Owners.FirstOrDefault(x => x.Id == ownerId);
            Category pokemonCategoryEntity = _context.Categories.FirstOrDefault(x => x.Id!= categoryId);

            var pokemonOwner = new PokemonOwner()
            {
                Owner = pokemonOwnerEntity,
                Pokemon = pokemon
            };

            _context.Add(pokemonOwner);

            var pokemonCategory = new PokemonCategory()
            { 
                Pokemon = pokemon,
                Category = pokemonCategoryEntity
            };
            _context.Add(pokemonCategory);

/*            pokemon.PokemonOwners.Add(pokemonOwner);
            pokemon.PokemonCategories.Add(pokemonCategory);*/

            _context.Add(pokemon);

            return Save();
        }

        public bool DeletePokemon(Pokemon pokemon)
        {
            _context.Remove(pokemon);
            return Save();
        }

        public Pokemon GetPokemon(int id)
        {
            return _context.Pokemon.FirstOrDefault(x => x.Id == id);
        }

        public Pokemon GetPokemon(string name)
        {
            return _context.Pokemon.FirstOrDefault(x => x.Name == name);
        }

        public decimal GetPokemonRating(int pokemonId)
        {
            return (decimal)_context.Reviews.Where(x => x.Pokemon.Id == pokemonId)
                                            .Average(x => x.Rating);
        }

        public ICollection<Pokemon> GetPokemons()
        {
            return _context.Pokemon.OrderBy(x => x.Id).ToList();
        }

        public bool PokemonExists(int pokemonId)
        {
            return _context.Pokemon.Any(x => x.Id == pokemonId);
        }

        public bool Save()
        {
            return _context.SaveChanges() > 0;
        }

        public bool UpdatePokemon(Pokemon pokemon)
        {
            _context.Update(pokemon);
            return Save();
        }
    }
}
