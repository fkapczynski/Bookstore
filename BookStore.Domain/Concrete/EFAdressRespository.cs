using BookStore.Domain.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BookStore.Domain.Entities;
using System.Data.Entity;

namespace BookStore.Domain.Concrete
{
    public class EFAdressRespository : IAdressRepository
    {
        private EFDbContext context = new EFDbContext();

        public IQueryable<Adress> Adresses
        {
            get { return context.Adresses; }
        }
        public Adress GetAdress(String id)
        {
            Adress dbEntry = context.Adresses.Find(id);
            return dbEntry;
        }
        public void SaveAdress(Adress adress)
        {
            Adress dbEntry = context.Adresses.Find(adress.UserId);
            if (dbEntry == null) { 
                context.Adresses.Add(adress);
            }
            else
            {
                ChangeAdress(adress);
            }
            context.SaveChanges();
        }
        public void ChangeAdress(Adress adress)
        {
            Adress dbEntry = context.Adresses.Find(adress.UserId);
            if (dbEntry != null)
            {
                dbEntry.Country = adress.Country;
                dbEntry.City = adress.City;
                dbEntry.Street = adress.Street;
                dbEntry.PostalCode = adress.PostalCode;
                dbEntry.HouseNumber = adress.HouseNumber;
                dbEntry.ApartmentNumber = adress.ApartmentNumber;
                context.SaveChanges();
            }
        }
    }

}