using BookStore.Domain.Abstract;
using BookStore.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookStore.Domain.Concrete
{
    public class EFOpinionRepository : IOpinionRepository
    {
        private EFDbContext context = new EFDbContext();

        public IQueryable<Opinion> Opinions
        {
            get { return context.Opinions; }
        }

        //public IQueryable<Opinion> getAll(int bookId)
        //{
        //    IQueryable<Opinion> opinions;
        //    foreach (Opinion item in context.Opinions)
        //    {
        //        if(item.bookId == bookId)
        //            opinions.
        //    }
        //}
        public Opinion GetOpinion(int id)
        {
            Opinion dbEntry = context.Opinions.Find(id);
            return dbEntry;
        }
        public void AddOpinion(Opinion opinion)
        {
            context.Opinions.Add(opinion);
            context.SaveChanges();
        }
    }
}
