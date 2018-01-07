using BookStore.Domain.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;
using System.ComponentModel.DataAnnotations.Schema;

namespace BookStore.Domain.Entities
{
    public class OrderDetails
    {
        //public Pair PK_OrderDetail { get; set; };
        [Key]
        [Column(Order = 0)]
        public int BookId { get; set; }
        [Key]
        [Column(Order = 1)]
        public int OrderId { get; set; }
        public int NumberOfCopies { get; set; }
        public double PricePerBook { get; set; }
        public Book Book { get; set; }
    }

    
}
