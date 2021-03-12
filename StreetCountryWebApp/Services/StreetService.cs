using StreetCountryWebApp.Models;
using StreetCountryWebApp.Repo;
using System;
using System.Collections.Generic;

namespace StreetCountryWebApp.Services
{
    public class StreetService : IStreetService
    {
        private readonly IStreetRepository repository;
        public StreetService(IStreetRepository repository)
        {
            this.repository = repository;
        }

        public void Create(Street street)
        {
            try
            {
                if (IsValid(street))
                {
                    repository.Add(street);
                }
            }
            catch
            {
                //log it
                throw;
            }
        }

        public List<Street> Read(string searchString)
        {
            if (string.IsNullOrEmpty(searchString))
                return repository.GetAll();
            else return repository.GetByString(searchString);
        }

        public Street Read(int id)
        {
            return repository.Find(id);
        }

        public void Delete(int id)
        {
            try
            {
                repository.Delete(id);
            }
            catch
            {
                //log it
                throw;
            }
        }

        public void Update(Street street)
        {
            try
            {
                if (IsValid(street))
                {
                    repository.Update(street);
                }
            }
            catch
            {
                //log it
                throw;
            }
        }        

        public bool IsValid(Street street)
        {
            bool result = street != null && MyValidator.Validate(street).Count == 0;

            if (result) return true;
            else throw new Exception("Переданный объект не прошел валидацию");
        }


    }
}
