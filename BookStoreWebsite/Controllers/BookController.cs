using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BookStore.Domain.Abstract;
namespace BookStoreWebsite.Controllers
{
    public class BookController : Controller
    {
        private IBookRepository respository;
        public BookController(IBookRepository bookRespository)
        {
            respository = bookRespository;
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
    }
}