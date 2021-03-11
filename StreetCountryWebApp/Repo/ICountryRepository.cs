using StreetCountryWebApp.Models;

namespace StreetCountryWebApp.Repo
{
    public interface ICountryRepository
    {
        void Add(Street street);
        void Delete(int id);
        void Update(int id, Country country);
        void Find(int id);
        void GetAll();
    }
}
