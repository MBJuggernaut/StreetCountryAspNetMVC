using StreetCountryWebApp.Models;
using System;

namespace StreetCountryWebApp.Repo
{
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
