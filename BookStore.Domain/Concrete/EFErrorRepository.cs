using BookStore.Domain.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BookStore.Domain.Entities;

namespace BookStore.Domain.Concrete
{
    public class EFErrorRepository : IErrorRepository
    {
        private EFDbContext context = new EFDbContext();

        public IQueryable<Error> errors
        {
            get
            {
                return context.Errors;
            }
           
        }
            

        public void addError(Error error)
        {
            context.Errors.Add(error);
            context.SaveChanges();
        }
    }
}
