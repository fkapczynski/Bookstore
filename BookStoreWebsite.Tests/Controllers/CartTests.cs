using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System.Web.Mvc;
using BookStoreWebsite.Controllers;
using BookStore.Domain.Entities;
using BookStore.Domain.Abstract;
using BookStoreWebsite.Models;

namespace BookStoreWebsite.Tests {
    [TestClass]
    public class CartTests {

        [TestMethod]
        public void Can_Add_New_Lines() {

            // Arrange - create some test products
            Book book1 = new Book(1, "Ania z gór", 20.5, 100, 1, 0, 1, 0);
            Book book2 = new Book(2, "Przygody .NEtowca", 40, 10, 2, 0, 1, 0);

            // Arrange - create a new cart
            Cart target = new Cart();

            // Act
            target.Add(book1, 1);
            target.Add(book2, 1);
            CartLine[] results = target.Lines.ToArray();

            // Assert
            Assert.AreEqual(results.Length, 2);
            Assert.AreEqual(results[0].Book, book1);
            Assert.AreEqual(results[1].Book, book2);
        }

        [TestMethod]
        public void Can_Add_Quantity_For_Existing_Lines() {
            Book book1 = new Book(1, "Ania z gór", 20.5, 100, 1, 0, 1, 0);
            Book book2 = new Book(2, "Przygody .NEtowca", 40, 10, 2, 0, 1, 0);

            // Arrange - create a new cart
            Cart target = new Cart();

            // Act
            target.Add(book1, 1);
            target.Add(book2, 1);
            target.Add(book1, 5);
            CartLine[] results = target.Lines.OrderBy(c => c.Book.BookID).ToArray();

            // Assert
            Assert.AreEqual(results.Length, 2);
            Assert.AreEqual(results[0].Quantity, 6);
            Assert.AreEqual(results[1].Quantity, 1);
        }

        [TestMethod]
        public void Can_Remove_Line() {

            // Arrange - create some test products
            Book book1 = new Book(1, "Ania z gór", 20.5, 100, 1, 0, 1, 0);
            Book book2 = new Book(2, "Przygody .NEtowca", 40, 10, 2, 0, 1, 0);
            Book book3 = new Book(3, "Przygody .NEtowca", 40, 10, 2, 0, 1, 0);

            // Arrange - create a new cart
            Cart target = new Cart();
            // Arrange - add some products to the cart
            target.Add(book1, 1);
            target.Add(book2, 3);
            target.Add(book3, 5);
            target.Add(book2, 1);

            // Act
            target.Remove(book2);

            // Assert
            Assert.AreEqual(target.Lines.Where(c => c.Book == book2).Count(), 0);//czy zadziała bez nadpisania equals() ?
            Assert.AreEqual(target.Lines.Count(), 2);
        }

        [TestMethod]
        public void Calculate_Cart_Total() {

            Book book1 = new Book(1, "Ania z gór", 20.5, 100, 1, 0, 1, 0);
            Book book2 = new Book(2, "Przygody .NEtowca", 40, 10, 2, 0, 1, 0);

            // Arrange - create a new cart
            Cart target = new Cart();

            // Act
            target.Add(book1, 1);
            target.Add(book2, 1);
            //target.Add(book1, 5);
            double result = target.ComputeTotalPrice();

            // Assert
            Assert.AreEqual(result, 60.5);
        }

        [TestMethod]
        public void Can_Clear_Contents() {

            // Arrange - create some test products
            Book book1 = new Book(1, "Ania z gór", 20.5, 100, 1, 0, 1, 0);
            Book book2 = new Book(2, "Przygody .NEtowca", 40, 10, 2, 0, 1, 0);

            // Arrange - create a new cart
            Cart target = new Cart();

            // Act
            target.Add(book1, 1);
            target.Add(book2, 1);
            // Act - reset the cart
            target.Clear();

            // Assert
            Assert.AreEqual(target.Lines.Count(), 0);
        }

        [TestMethod]
        public void Can_Add_To_Cart() {

            // Arrange - create the mock repository
            Mock<IBookRepository> mock = new Mock<IBookRepository>();
            mock.Setup(m => m.Books).Returns(new Book[] {
                 new Book(2, "Przygody .NEtowca", 40, 10, 2, 0, 1, 0),
            }.AsQueryable());

            // Arrange - create a Cart
            Cart cart = new Cart();

            // Arrange - create the controller
            CartController target = new CartController(mock.Object, null);

            // Act - add a product to the cart
            target.AddToCart(cart, 2, null);

            // Assert
            Assert.AreEqual(cart.Lines.Count(), 1);
            Assert.AreEqual(cart.Lines.ToArray()[0].Book.BookID, 2);
        }

        [TestMethod]
        public void Adding_Product_To_Cart_Goes_To_Cart_Screen() {
            // Arrange - create the mock repository
            Mock<IBookRepository> mock = new Mock<IBookRepository>();
            mock.Setup(m => m.Books).Returns(new Book[] {
                 new Book(2, "Przygody .NEtowca", 40, 10, 2, 0, 1, 0),
            }.AsQueryable());

            // Arrange - create a Cart
            Cart cart = new Cart();

            // Arrange - create the controller
            CartController target = new CartController(mock.Object, null);

            // Act - add a product to the cart
            RedirectToRouteResult result = target.AddToCart(cart, 2, "myUrl");

            // Assert
            Assert.AreEqual(result.RouteValues["action"], "Index");
            Assert.AreEqual(result.RouteValues["returnUrl"], "myUrl");
        }

        //[TestMethod]
        //public void Can_View_Cart_Contents() {
        //    // Arrange - create a Cart
        //    Cart cart = new Cart();

        //    // Arrange - create the controller
        //    CartController target = new CartController(null, null);

        //    // Act - call the Index action method
        //    CartIndexViewModel result
        //        = ((CartIndexViewModel)target.Index(cart, "myUrl").ExecuteResult()).Cart;

        //    // Assert
        //    Assert.AreSame(result.Cart, cart);
        //    Assert.AreEqual(result.ReturnUrl, "myUrl");
        //}

        //[TestMethod]
        //public void Cannot_Checkout_Empty_Cart() {

        //    // Arrange - create a mock order processor
        //    Mock<IOrderProcessor> mock = new Mock<IOrderProcessor>();
        //    // Arrange - create an empty cart
        //    Cart cart = new Cart();
        //    // Arrange - create shipping details
        //    ShippingDetails shippingDetails = new ShippingDetails();
        //    // Arrange - create an instance of the controller
        //    CartController target = new CartController(null, mock.Object);

        //    // Act
        //    ViewResult result = target.Checkout(cart, shippingDetails);

        //    // Assert - check that the order hasn't been passed on to the processor
        //    mock.Verify(m => m.ProcessOrder(It.IsAny<Cart>(), It.IsAny<ShippingDetails>()),
        //        Times.Never());
        //    // Assert - check that the method is returning the default view
        //    Assert.AreEqual("", result.ViewName);
        //    // Assert - check that I am passing an invalid model to the view
        //    Assert.AreEqual(false, result.ViewData.ModelState.IsValid);
        //}

        //[TestMethod]
        //public void Cannot_Checkout_Invalid_ShippingDetails() {

        //    // Arrange - create a mock order processor
        //    Mock<IOrderProcessor> mock = new Mock<IOrderProcessor>();
        //    // Arrange - create a cart with an item
        //    Cart cart = new Cart();
        //    cart.AddItem(new Product(), 1);

        //    // Arrange - create an instance of the controller
        //    CartController target = new CartController(null, mock.Object);
        //    // Arrange - add an error to the model
        //    target.ModelState.AddModelError("error", "error");

        //    // Act - try to checkout
        //    ViewResult result = target.Checkout(cart, new ShippingDetails());

        //    // Assert - check that the order hasn't been passed on to the processor
        //    mock.Verify(m => m.ProcessOrder(It.IsAny<Cart>(), It.IsAny<ShippingDetails>()),
        //        Times.Never());
        //    // Assert - check that the method is returning the default view
        //    Assert.AreEqual("", result.ViewName);
        //    // Assert - check that I am passing an invalid model to the view
        //    Assert.AreEqual(false, result.ViewData.ModelState.IsValid);
        //}

        //[TestMethod]
        //public void Can_Checkout_And_Submit_Order() {
        //    // Arrange - create a mock order processor
        //    Mock<IOrderProcessor> mock = new Mock<IOrderProcessor>();
        //    // Arrange - create a cart with an item
        //    Cart cart = new Cart();
        //    cart.AddItem(new Product(), 1);
        //    // Arrange - create an instance of the controller
        //    CartController target = new CartController(null, mock.Object);

        //    // Act - try to checkout
        //    ViewResult result = target.Checkout(cart, new ShippingDetails());

        //    // Assert - check that the order has been passed on to the processor
        //    mock.Verify(m => m.ProcessOrder(It.IsAny<Cart>(), It.IsAny<ShippingDetails>()),
        //        Times.Once());
        //    // Assert - check that the method is returning the Completed view
        //    Assert.AreEqual("Completed", result.ViewName);
        //    // Assert - check that I am passing a valid model to the view
        //    Assert.AreEqual(true, result.ViewData.ModelState.IsValid);
        //}

    }
}
