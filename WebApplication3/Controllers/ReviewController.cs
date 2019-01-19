using DataAccess;
using DataAccess.Implementation;
using DataAccess.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebApplication3.Controllers
{
    public class ReviewController : Controller
    {
        private IReviewRepository reviewRepository;

        public ReviewController()
        {
            this.reviewRepository = new ReviewRepository(new Entities());
        }

        // GET: Review
        public ActionResult Index()
        {
            return View();
        }

        // GET: Review/Details/5
        public ActionResult Details()
        {
            return View();
        }

        // GET: Review/Create
        public ActionResult Create(int bookId)
        {
            var review = new Review { BookID = bookId };

            return View(review);
        }

        // POST: Review/Create
        [HttpPost]
        public ActionResult Create(Review review)
        {
            try
            {
                review.Date = DateTime.Now;
                review.UserID = 1;

                this.reviewRepository.AddReview(review);
                //Book/Details/2
                return RedirectToAction("Details","Book",new { id= review.BookID});
            }
            catch(Exception e)
            {
                return View();
            }
        }

        // GET: Review/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Review/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Review/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Review/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
