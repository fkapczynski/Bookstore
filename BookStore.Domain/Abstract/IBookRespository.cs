using BookStore.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookStore.Domain.Abstract
{
    public interface IBookRepository
    {
        IQueryable<Book> Books { get; }
        IQueryable<Book> BooksData { get; }
        Author GetAuthor(int authorId);
        Publisher GetPublisher(int publisherId);
        Category GetCategory(int categoryId);
        Series GetSeries(int seriesId);

    }
}
