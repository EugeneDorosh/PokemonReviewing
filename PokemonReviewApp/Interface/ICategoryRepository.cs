using PokemonReviewApp.Models;

namespace PokemonReviewApp.Interface
{
    public interface ICategoryRepository
    {
        public ICollection<Category> GetCategories();
        public Category GetCategory(int id);
        public ICollection<Pokemon> GetPokemonsByCategory(int categoryId);
        bool CategoryExists(int categoryId);
    }
}
