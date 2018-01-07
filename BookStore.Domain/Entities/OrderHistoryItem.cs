using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookStore.Domain.Entities
{
    public class OrderHistoryItem
    {
        public DateTime OrderDate { get; set; }
        public List<OrderDetails> Details { get; set; }
         
    }
}
