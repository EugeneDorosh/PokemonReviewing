using PokemonReviewApp.Models;

namespace PokemonReviewApp.Interface
{
    public interface IReviewRepository
    {
        public ICollection<Review> GetReviews();
        public Review GetReview(int reviewId);
        public ICollection<Review> GetReviewsOfAPokemon(int pokemonId);
        public bool ReviewExists(int reviewId);
        public bool CreateReview(Review Review, int reviewerId, int pokemonId);
        public bool UpdateReview(Review review);
        public bool DeleteReview(Review review);
        public bool DeleteReviews(List<Review> reviews);
        bool Save();
    }
}
