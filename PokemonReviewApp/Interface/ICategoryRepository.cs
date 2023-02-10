using PokemonReviewApp.Models;

namespace PokemonReviewApp.Interface
{
    public interface ICategoryRepository
    {
        public ICollection<Category> GetCategories();
        public Category GetCategory(int id);
        public ICollection<Pokemon> GetPokemonsByCategory(int categoryId);
        public bool CategoryExists(int categoryId);
        public bool CreateCategory(Category category);
        public bool UpdateCategory(Category category);
        public bool DeleteCategory(Category category);
        public bool Save();
    }
}
