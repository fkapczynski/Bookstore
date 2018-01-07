using BookStore.Domain.Abstract;
using BookStore.Domain.Entities;
using BookStoreWebsite.Models;
using Microsoft.AspNet.Identity;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BookStoreWebsite.Controllers
{
    public class CartController : Controller
    {
        private IBookRespository repository;
        private IOrderRepository orderRepostiory;

        public CartController(IBookRespository repository,IOrderRepository orderRepository)
        {
            this.repository = repository;
            this.orderRepostiory = orderRepository;
        }
        public RedirectToRouteResult AddToCart(Cart cart,int bookId, string returnUrl)
        {
            Book book = getBookWithID(bookId);
            if (book != null)
                cart.Add(book, 1);
            return RedirectToAction("Index", new { returnUrl });
        }
        public RedirectToRouteResult RemoveFromCart(Cart cart,int bookId, string returnUrl)
        {
            Book book = getBookWithID(bookId);
            if (book != null)
                cart.Remove(book);
            return RedirectToAction("Index", new { returnUrl });
        }
        private Book getBookWithID(int id)
        {
            return repository.Books.FirstOrDefault(b => b.BookID == id);
        }
        //private Cart Cart
        //{
        //    get
        //    {
        //        Cart cart = (Cart)Session["Cart"];
        //        if (cart == null)
        //        {
        //            cart = new Cart();
        //            Session["Cart"] = cart;
        //        }
        //        return cart;
        //    }
        //}
        // GET: Cart
        public ActionResult Index(Cart cart,string returnUrl)
        {
            return View(new CartIndexViewModel
            {
                Cart = cart,
                ReturnUrl = returnUrl
            });
        }
        public ViewResult Summary(Cart cart)
        {
            //cart = cart == null ? new Cart() : cart;
            return View(cart);
        }
        
        public ViewResult Checkout(Cart cart)
        {
            if (cart.Lines.Count() == 0)
            {
                ModelState.AddModelError("", "Sorry, your cart is empty!");
            }
            User.Identity.GetUserId();
            if (ModelState.IsValid)
            {
                orderRepostiory.UserID = User.Identity.GetUserId();
                orderRepostiory.AddOrder(cart);
                cart.Clear();
                return View("Index",new CartIndexViewModel() { Cart=cart,ReturnUrl="/Home/Index"});
            }
            else
            {
                return View();
            }
        }
    }
}