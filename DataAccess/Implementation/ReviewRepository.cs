using DataAccess.Interfaces;
using DataAccess;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Implementation
{
    public class ReviewRepository : IReviewRepository, IDisposable
    {
        private Entities context;

        public ReviewRepository(Entities context)
        {
            this.context = context;
        }

        public void AddReview(Review review)
        {
            context.Review.Add(review);
            context.SaveChanges();
        }

        public void DeleteReview(int reviewId)
        {
            Review review = context.Review.Find(reviewId);
            context.Review.Remove(review);
        }

        public IEnumerable<Review> GetReviews()
        {
            return context.Review.ToList();
        }

        public IEnumerable<Review>GetReviewsForBookId(int bookId)
        {
            return context.Review
                .Include(b => b.Users)
                .Where(r => r.BookID == bookId).ToList();
        }

        public Review GetReviewByID(int reviewId)
        {
            return context.Review.Find(reviewId);
        }

        public void UpdateReview(Review review)
        {
            context.Entry(review).State = EntityState.Modified;
        }

        public void Save()
        {
            context.SaveChanges();
        }

        private bool disposed = false;

        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    context.Dispose();
                }
            }
            this.disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}

