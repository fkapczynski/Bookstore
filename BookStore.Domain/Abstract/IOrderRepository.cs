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
        IQueryable<Order> GetOrders(string userId);
        void AddOrder(Order order,List<OrderDetails> details);
        IList<OrderDetails> GetDetails(int orderId);
    }
}
