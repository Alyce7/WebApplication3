using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Interfaces
{
    public interface IReviewRepository : IDisposable
    {
        IEnumerable<Review> GetReviews();
        
        IEnumerable<Review> GetReviewsForBookId(int bookId);

        Review GetReviewByID(int reviewId);

        void AddReview(Review review);

        void DeleteReview(int reviewId);

        void UpdateReview(Review review);

        void Save();
    }
}
