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
            if (IsValid(street))
            {
                repository.Add(street);
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
            repository.Delete(id);
        }

        public void Update(Street street)
        {
            if (IsValid(street))
            {
                repository.Update(street);
            }
        }

        public bool IsValid(Street street)
        {
            if (street.IsValid(out _))
                return true;

            throw new Exception("Переданный объект не прошел валидацию");
        }


    }
}
