using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BookStore.Domain.Abstract;
using BookStore.Domain.Entities;
using System.Data.Entity.Infrastructure;
using Castle.Core.Logging;

namespace BookStoreWebsite.Controllers
{
    public class BookController : Controller
    {
        private IBookRepository respository;
        private IErrorRepository _logger;
        private IOpinionRepository opinionRepository;

        public BookController(IBookRepository bookRespository, IOpinionRepository opinionRepository, IErrorRepository logger)
        {
            this.opinionRepository = opinionRepository;
            respository = bookRespository;
            _logger = logger;
        }

        public ViewResult Details(int id)
        {
            Book book;
            try
            {
                book = respository.GetBook(id);
                return View(book);
            }
            catch(Exception e)
            {
                _logger.addError(new Error("error bookid:"+e.Data.ToString() + " in "+ this.ToString()));
                return null;
            }
            
        }
        // GET: Book
        public ViewResult List()
        {
            var books = respository.BooksData;
            //foreach (var item in books)
            //{
            //    item.BookAuthor = respository.GetAuthor(item.AuthorID);
            //}
            return View(books);
        }
        public ActionResult Search(string searchString, string searchType)
        {
            var books = from b in respository.BooksData
                        select b;
            switch (searchType)
            {
                case "title":
                    if (!String.IsNullOrEmpty(searchString))
                    {
                        books = books.Where(s => s.Title.Contains(searchString));
                    }
                    break;
                case "author":
                    if (!String.IsNullOrEmpty(searchString))
                    {
                        books = books.Where(s => s.BookAuthor.LastName.Contains(searchString));
                    }
                    break;
                case "publisher":
                    if (!String.IsNullOrEmpty(searchString))
                    {
                        books = books.Where(s => s.BookPublisher.PublisherName.Contains(searchString));
                    }
                    break;
            }
            return View(books);
        }

        public ActionResult OpinionDetails(int id)
        {
            Opinion opinion = opinionRepository.GetOpinion(id);
            return View(opinion);
        }

        // GET: Opinion/Create
        public ActionResult OpinionCreate(int bookId)
        {
            
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult OpinionCreate(Opinion opinion)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    opinionRepository.AddOpinion(opinion);
                    return View();
                }
            }
            catch (RetryLimitExceededException e/* dex */)
            {
                //Log the error(uncomment dex variable name and add a line here to write a log.
                ModelState.AddModelError("", "Unable to save changes. Try again, and if the problem persists see your system administrator.");
                _logger.addError(new Error(e.Data.ToString()));
            }
            return View();
        }
    }
}