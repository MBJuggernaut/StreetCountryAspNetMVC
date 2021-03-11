using StreetCountryWebApp.Models;
using System;
using System.Collections.Generic;

namespace StreetCountryWebApp.Repo
{
    public interface IStreetRepository
    {
        void Add(Street street);
        void Delete(int id);
        void Update(Street street);
        Street Find(int id);
        List<Street> GetAll();
        Country GetCountryForStreet(int id);
    }

    public interface ICountryRepository
    {
        void Add(Street street);
        void Delete(int id);
        void Update(int id, Country country);
        void Find(int id);
        void GetAll();
    }

    public class CountryRepository : ICountryRepository
    {
        private readonly DBContext context;
        public CountryRepository(DBContext context)
        {
            this.context = context;
        }
        public void Add(Street street)
        {
            throw new NotImplementedException();
        }

        public void Delete(int id)
        {
            throw new NotImplementedException();
        }

        public void Find(int id)
        {
            throw new NotImplementedException();
        }

        public void GetAll()
        {
            throw new NotImplementedException();
        }

        public void Update(int id, Country country)
        {
            throw new NotImplementedException();
        }
    }
}
