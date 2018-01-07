using BookStore.Domain.Abstract;
using BookStore.Domain.Concrete;
using BookStore.Domain.Entities;
using Moq;
using Ninject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace BookStoreWebsite.Infrastructure
{
    public class NinjectControllerFactory:DefaultControllerFactory
    {
        private IKernel ninjectKernel;
        public NinjectControllerFactory()
        {
            ninjectKernel = new StandardKernel();
            AddBindings();
        }
        protected override IController GetControllerInstance(RequestContext context, Type controllerType)
        {
            return controllerType == null ? null : (IController)ninjectKernel.Get(controllerType);
        }
        private void AddBindings()
        {
            //Mock<IBookRespository> mockRespository = new Mock<IBookRespository>();
            //mockRespository.Setup(b => b.Books).Returns(new List<Book> {
            //    new Book() {Title = "Harry Potter 1",BookID=1,Price=34.99 },
            //    new Book() {Title = "Harry Potter 2",BookID=2,Price=39.99 },
            //    new Book() {Title = "C# dla bysztrzków",BookID=3,Price=49.95 }
            //}.AsQueryable());
            //ninjectKernel.Bind<IBookRespository>().ToConstant(mockRespository.Object);
            ninjectKernel.Bind<IBookRespository>().To<EFBooksRespository>();
            ninjectKernel.Bind<IOrderRepository>().To<EFOrderRepository>();
        }
    }
}