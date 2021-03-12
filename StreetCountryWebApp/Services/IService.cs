using System.Collections.Generic;

namespace StreetCountryWebApp.Services
{
    public interface IService<T>
    {
        void Create(T item);
        List<T> Read(string searchString);
        T Read(int id);
        void Delete(int id);
        void Update(T item);
        bool IsValid(T item);
    }
}
