using StreetCountryWebApp.Models;
using System.Collections.Generic;

namespace StreetCountryWebApp.Services
{
    public interface IStreetService
    {
        void Create(Street street);
        List<Street> Read(string searchString);
        Street Read(int id);
        void Delete(int id);
        void Update(Street street);
        bool IsValid(Street street);
    }
}
