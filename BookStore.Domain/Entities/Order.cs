using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookStore.Domain.Entities
{
    public class Order
    {
        public int OrderId { get; set; }
        public int EmployeeId { get; set; }
        public string UserId { get; set; }
        public DateTime OrderDate { get; set; }
    }
}
