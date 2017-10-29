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
        private IBookRespository respository;
        public BookController(IBookRespository bookRespository)
        {
            respository = bookRespository;
        }
        // GET: Book
        public ViewResult List()
        {
            return View(respository.Books);
        }
    }
}