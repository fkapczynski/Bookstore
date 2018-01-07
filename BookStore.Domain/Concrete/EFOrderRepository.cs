using BookStore.Domain.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BookStore.Domain.Entities;

namespace BookStore.Domain.Concrete
{
    public class EFOrderRepository : IOrderRepository
    {
        private EFDbContext context = new EFDbContext();
        private string userId;
        public string UserID
        {
            set
            {
                userId = value;
            }
        }

        public void AddOrder(Order order,List<OrderDetails> details)
        {
            context.Orders.Add(order);
            foreach (var item in details)
            {
                context.OrderDetails.Add(item);
            }
        }
        public void AddOrder(Cart cart)
        {
            Order order = new Order();
            order.OrderDate = DateTime.Now;
            order.UserId = userId;
            order.EmployeeId = 2;
            context.Orders.Add(order);
            context.SaveChanges();
            int orderId = order.OrderId;
            List<OrderDetails> details = new List<OrderDetails>();
            foreach (var line in cart.Lines)
            {
                var detail = new OrderDetails();
                detail.BookId = line.Book.BookID;
                detail.NumberOfCopies = line.Quantity;
                detail.PricePerBook = line.Book.Price;
                detail.OrderId = orderId;
                context.OrderDetails.Add(detail);
            }
            context.SaveChanges();
        }

        public IQueryable<Order> GetOrders(string userId)
        {
            return context.Orders.Where(o => o.UserId.Equals(userId));
            //return context.Orders;
        }

        IList<OrderDetails> IOrderRepository.GetDetails(int orderId)
        {
            return context.OrderDetails.Where(od => od.OrderId == orderId).ToList();
        }
    }
}
