using BookStore.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookStore.Domain.Abstract
{
    public interface IOpinionRepository
    {
        void AddOpinion(Opinion opinion);
        IQueryable<Opinion> Opinions { get; }

        Opinion GetOpinion(int id);
    }
}
