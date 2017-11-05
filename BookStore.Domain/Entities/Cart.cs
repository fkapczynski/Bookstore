using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookStore.Domain.Entities
{
    public class Cart
    {
        private List<CartLine> lineCollection = new List<CartLine>();
        public void Add(Book book, int quantity)
        {
            CartLine line = lineCollection
                .Where(cl => cl.Book.BookID == book.BookID)
                .FirstOrDefault();
            if (line == null)
                lineCollection.Add(new CartLine(book, quantity));
            else
                line.Quantity += quantity;
        }
        public void Remove(Book book)
        {
            lineCollection.RemoveAll(cl => cl.Book.BookID == book.BookID);
        }
        public void Clear()
        {
            lineCollection.Clear();
        }
        public void ChangeQuantity(Book book, int targetQuantity)
        {
            Remove(book);
            Add(book, targetQuantity);
        }
        public double ComputeTotalPrice()
        {
            return lineCollection.Sum(cl => cl.Book.Price * cl.Quantity);
        }
        public IEnumerable<CartLine> Lines
        {
            get
            {
                return lineCollection;
            }
        }
    }
}
