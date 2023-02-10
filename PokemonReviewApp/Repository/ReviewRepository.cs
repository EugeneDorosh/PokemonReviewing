using PokemonReviewApp.Data;
using PokemonReviewApp.Interface;
using PokemonReviewApp.Models;

namespace PokemonReviewApp.Repository
{
    public class ReviewRepository : IReviewRepository
    {
        private readonly DataContext _context;
        private readonly IReviewerRepository _reviewerRepository;
        private readonly IPokemonRepository _pokemonRepository;

        public ReviewRepository(DataContext context,
                                IReviewerRepository reviewerRepository,
                                IPokemonRepository pokemonRepository)
        {
            _context = context;
            _reviewerRepository = reviewerRepository;
            _pokemonRepository = pokemonRepository;
        }

        public bool CreateReview(Review review, int reviewerId, int pokemonId)
        {
            Pokemon pokemon = _pokemonRepository.GetPokemon(pokemonId);
            Reviewer reviewer = _reviewerRepository.GetReviewer(reviewerId);

            review.Reviewer = reviewer;
            review.Pokemon = pokemon;

            _context.Add(review);

            return Save();
        }

        public bool DeleteReview(Review review)
        {
            _context.Remove(review);
            return Save();
        }

        public bool DeleteReviews(List<Review> reviews)
        {
            _context.RemoveRange(reviews);
            return Save();
        }

        public Review GetReview(int reviewId)
        {
            return _context.Reviews.FirstOrDefault(x => x.Id == reviewId);
        }

        public ICollection<Review> GetReviews()
        {
            return _context.Reviews.ToList();
        }

        public ICollection<Review> GetReviewsOfAPokemon(int pokemonId)
        {
            return _context.Reviews.Where(x => x.Pokemon.Id == pokemonId).ToList();
        }

        public bool ReviewExists(int reviewId)
        {
            return _context.Reviews.Any(x => x.Id == reviewId);
        }

        public bool Save()
        {
            return _context.SaveChanges() > 0;
        }

        public bool UpdateReview(Review review)
        {
            _context.Update(review);
            return Save();
        }
    }
}
