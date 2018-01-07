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

        public void AddOrder(Order order,List<OrderDetails> details)
        {
            context.Orders.Add(order);
            foreach (var item in details)
            {
                context.OrderDetails.Add(item);
            }
        }

        public IQueryable<Order> GetOrders(string userId)
        {
            return context.Orders.Where(o => o.UserId.Equals(userId));
            //return context.Orders;
        }

        IList<OrderDetails> IOrderRepository.GetDetails(int orderId)
        {
            throw new NotImplementedException();
        }
    }
}
