using BookStore.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookStore.Domain.Abstract
{
    public interface IOrderRepository
    {
        string UserID { set; }
        IQueryable<Order> GetOrders(string userId);
        void AddOrder(Order order,List<OrderDetails> details);
        void AddOrder(Cart cart);
        IList<OrderDetails> GetDetails(int orderId);
    }
}
