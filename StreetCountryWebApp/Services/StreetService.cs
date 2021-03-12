using StreetCountryWebApp.Repo;
using System;
using System.Collections.Generic;

namespace StreetCountryWebApp.Services
{
    public class StreetService<Street> : IService<Models.Street>
    {
        private readonly StreetRepository repository;
        public StreetService(StreetRepository repository)
        {
            this.repository = repository;
        }

        public void Create(Models.Street street)
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

        public List<Models.Street> Read(string searchString)
        {
            if (string.IsNullOrEmpty(searchString))
                return repository.GetAll();
            else return repository.GetByString(searchString);
        }

        public Models.Street Read(int id)
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

        public void Update(Models.Street street)
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

        public bool IsValid(Models.Street street)
        {
            bool result = street != null && MyValidator.Validate(street).Count == 0;

            if (result) return true;
            else throw new Exception("Переданный объект не прошел валидацию");
        }


    }
}
