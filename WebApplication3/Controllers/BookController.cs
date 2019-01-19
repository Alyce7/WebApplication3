
using DataAccess;
using DataAccess.Implementation;
using DataAccess.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication3.Models;

namespace WebApplication3.Controllers
{
    public class BookController : Controller
    {
        // GET: Book
        private IBookRepository bookRepository;
        private IReviewRepository reviewRepository;

        public BookController()
        {
            this.bookRepository = new BookRepository(new Entities());
            this.reviewRepository = new ReviewRepository(new Entities());
        }

        public ActionResult Index()
        {
            var models = this.bookRepository.GetBooks();

            return View(models);
        }

        // GET: Book/Details/5
        public ActionResult Details(int id)
        {
            var book = this.bookRepository.GetBookByID(id);

            return View(book);
        }

        // GET: Book/Create
        public ActionResult Create()
        {
          
            return View();
        }

        // POST: Book/Create
        [HttpPost]
        public ActionResult Create(Book book)
        {
            try
            {
                this.bookRepository.AddBook(book);

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Book/Edit/5
        public ActionResult Edit(int id)
        {
            var book = this.bookRepository.GetBookByID(id);

            return View(book);
        }

        // POST: Book/Edit/5
        [HttpPost]
        public ActionResult Edit(Book book)
        {
            try
            {
                this.bookRepository.UpdateBook(book);

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Book/Delete/5
        public ActionResult Delete(int id)
        {
            try
            {
                // TODO: Add delete logic here
                this.bookRepository.DeleteBook(id);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
            return View();

        }

        // POST: Book/Delete/5
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
