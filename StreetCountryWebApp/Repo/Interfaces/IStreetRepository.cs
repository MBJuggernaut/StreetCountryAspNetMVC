using StreetCountryWebApp.Models;
using System.Collections.Generic;

namespace StreetCountryWebApp.Repo
{
    public interface IStreetRepository
    {
        void Add(Street street);
        void Delete(int id);
        void Update(Street street);
        Street Find(int id);
        List<Street> GetByString(string search);
        List<Street> GetAll();
        Country GetCountryForStreet(int id);
    }
}
