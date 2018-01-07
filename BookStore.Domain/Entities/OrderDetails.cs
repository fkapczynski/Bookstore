using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookStore.Domain.Entities
{
    public class OrderDetails
    {
        public int BookId { get; set; }
        public int OrderId { get; set; }
        public int NumberOfCopies { get; set; }
        public float PricePerBook { get; set; }
    }
}
