using PokemonReviewApp.Models;

namespace PokemonReviewApp.Interface
{
    public interface IReviewerRepository
    {
        public ICollection<Reviewer> GetReviewers();
        public Reviewer GetReviewer(int reviewerId);
        public ICollection<Review> GetReviewsByReviewer(int reviewerId);
        public bool ReviewerExists(int reviewerId);
        public bool CreateReviewer(Reviewer reviewer);
        public bool UpdateReviewer(Reviewer reviewer);
        public bool DeleteReviewer(Reviewer reviewer);
        bool Save();
    }
}
