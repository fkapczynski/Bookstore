using BookStore.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookStore.Domain.Abstract
{
    public interface IAdressRepository
    {
        IQueryable<Adress> Adresses { get; }

        Adress GetAdress(String id);
        void SaveAdress(Adress adress);
        void ChangeAdress(Adress adress);
    }
}