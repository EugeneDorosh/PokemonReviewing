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
    }
}
