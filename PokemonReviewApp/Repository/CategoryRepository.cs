using AutoMapper;
using PokemonReviewApp.Data;
using PokemonReviewApp.Dto;
using PokemonReviewApp.Interface;
using PokemonReviewApp.Models;

namespace PokemonReviewApp.Repository
{
    public class CategoryRepository : ICategoryRepository
    {
        private readonly DataContext _context;

        public CategoryRepository(DataContext context)
        {
            _context = context;
        }
        public bool CategoryExists(int categoryId)
        {
            return _context.Categories.Any(x => x.Id == categoryId);
        }

        public ICollection<Category> GetCategories()
        {
            var categories = _context.Categories.ToList();

            return categories;
        }

        public Category GetCategory(int id)
        {
            return _context.Categories.FirstOrDefault(x => x.Id == id);
        }

        public ICollection<Pokemon> GetPokemonsByCategory(int categoryId)
        {
            return _context.PokemonCategories.Where(x => x.CategoryId == categoryId).Select(x => x.Pokemon).ToList();
        }
    }
}
