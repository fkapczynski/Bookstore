using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookStore.Domain.Entities
{
    public class CartLine
    {
        public CartLine(Book book, int quantity)
        {
            Book = book;
            Quantity = quantity;
        }
        public Book Book { get; set; }
        public int Quantity { get; set; }
    }
}
