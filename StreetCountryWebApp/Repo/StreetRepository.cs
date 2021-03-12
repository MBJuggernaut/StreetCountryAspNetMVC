using StreetCountryWebApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace StreetCountryWebApp.Repo
{
    public class StreetRepository : IStreetRepository
    {
        private readonly DBContext context;
        public StreetRepository(DBContext context)
        {
            this.context = context;
        }

        public void Add(Street street)
        {
            context.Streets.Add(street);
            context.SaveChanges();
        }

        public void Delete(int id)
        {
            var streetToDelete = Find(id);

            context.Streets.Remove(streetToDelete);
            context.SaveChanges();
        }

        public List<Street> GetByString(string search)
        {
            return context.Streets.Where(x => x.Name.Contains(search)).ToList();
        }

        public List<Street> GetAll()
        {
            return context.Streets.ToList();
        }

        public void Update(Street street)
        {
            var streetToUpdate = Find(street.Id);

            streetToUpdate.Name = street.Name;
            streetToUpdate.CountryId = street.CountryId;
            context.SaveChanges();
        }

        public Country GetCountryForStreet(int id)
        {
            var street = Find(id);

            return context.Countrys.FirstOrDefault(x => x.Id == street.CountryId);
        }

        public Street Find(int id)
        {
            var street = context.Streets.FirstOrDefault(x => x.Id == id);
            return street ?? throw new Exception("Not found");                        
        }


    }
}
