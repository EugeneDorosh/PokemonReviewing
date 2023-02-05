using PokemonReviewApp.Models;

namespace PokemonReviewApp.Interface
{
    public interface IPokemonRepository
    {
        public ICollection<Pokemon> GetPokemons();
        
    }
}
