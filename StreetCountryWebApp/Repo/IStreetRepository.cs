using StreetCountryWebApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace StreetCountryWebApp.Repo
{
    public interface IStreetRepository
    {
        void Add(Street street);
        void Delete(int id);
        void Update(int id, Street street);
        Street Find(int id);
        List<Street> GetAll();
        Country GetCountryForStreet(int id);
    }

    public class StreetRepository : IStreetRepository
    {
        private DBContext context;
        public StreetRepository(DBContext context)
        {
            this.context = context;
        }

        public void Add(Street street)
        {
            if (IsValid(street))
            {
                context.Streets.Add(street);
                context.SaveChanges();
            }
        }

        public void Delete(int id)
        {
            try
            {
                var streetToDelete = Find(id);

                context.Streets.Remove(streetToDelete);

            }
            catch
            {
                //log it
                throw;
            }
        }

        public List<Street> GetAll()
        {
            return context.Streets.ToList();
        }

        public void Update(int id, Street street)
        {
            try
            {
                if (IsValid(street))
                {
                    var streetToUpdate = Find(id);

                    streetToUpdate.Name = street.Name;
                    streetToUpdate.CountryId = street.CountryId;
                    context.SaveChanges();
                }
            }
            catch
            {
                //log it
                throw;
            }
        }

        public Country GetCountryForStreet(int id)
        {
            try
            {
                var street = Find(id);

                return context.Countrys.FirstOrDefault(x => x.Id == street.CountryId);
            }
            catch
            {
                //log it
                throw;
            }
        }

        public Street Find(int id)
        {
            var streetToReturn = context.Streets.FirstOrDefault(x => x.Id == id);

            if (streetToReturn != null)
            {
                return streetToReturn;
            }

            else throw new Exception("По данному Id не был найден элемент");

        }

        private bool IsValid(Street street)
        {
            bool result = street != null && MyValidator.Validate(street).Count == 0;

            if (result) return true;
            else throw new Exception("Переданный объект не прошел валидацию");
        }
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
        private DBContext context;
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
