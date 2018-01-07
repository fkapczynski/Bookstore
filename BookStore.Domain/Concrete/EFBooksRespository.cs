using BookStore.Domain.Abstract;
using BookStore.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookStore.Domain.Concrete
{
    public class EFBooksRespository: IBookRepository
    {
        private EFDbContext context = new EFDbContext();

        public IQueryable<Book> Books
        {
            get { return context.Books; }
        }

        public IQueryable<Book> BooksData
        {
            get
            {
                var books = context.Books;
                foreach (var book in books)
                {
                    book.BookAuthor = GetAuthor(book.AuthorID);
                    book.BookPublisher = GetPublisher(book.PublisherID);
                    if (book.SeriesID != null)
                        book.BookSeries = GetSeries((int)book.SeriesID);
                    if (book.CategoryID != null)
                        book.BookCategory = GetCategory((int)book.CategoryID);
                }
                return books;
            }
        }

        public Author GetAuthor(int authorId)
        {
            return context.Authors.First(a => a.AuthorId == authorId);
        }

        public Category GetCategory(int categoryId)
        {
            return context.Categories.First(c => c.CategoryId == categoryId);
        }

        public Publisher GetPublisher(int publisherId)
        {
            return context.Publishers.First(p => p.PublisherId == publisherId);
        }

        public Series GetSeries(int seriesId)
        {
            return context.Series.First(s => s.SeriesId == seriesId);
        }
    }
}
