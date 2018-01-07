using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookStore.Domain.Entities
{
    public class Book
    {
        public Book()
        {
            
        }
        public Book(int bookID, string title, double price, int qunatityInStore, int publisherID, int categoryID, int authorID, int seriesID)
        {
            BookID = bookID;
            Title = title;
            Price = price;
            QunatityInStore = qunatityInStore;
            PublisherID = publisherID;
            CategoryID = categoryID;
            AuthorID = authorID;
            SeriesID = seriesID;
        }
        public int BookID { get; set; }
        public string Title { get; set; }
        public double Price { get; set; }
        public int QunatityInStore { get; set; }
        public int PublisherID { get; set; }
        public Publisher BookPublisher { get; set; }
        public int AuthorID { get; set; }
        public Author BookAuthor { get; set; }
        public int? CategoryID { get; set; }
        public Category BookCategory { get; set; }
        public int? SeriesID { get; set; }
        public Series BookSeries { get; set; }
    }
}
