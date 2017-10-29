using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookStore.Domain.Entities
{
    public class Book
    {
        public int BookID { get; set; }
        public string Title { get; set; }
        public double Price { get; set; }
        public int QunatityInStore { get; set; }
        public int PublisherID { get; set; }
        public int CategoryID { get; set; }
        public int AuthorID { get; set; }
        public int SeriesID { get; set; }
    }
}
