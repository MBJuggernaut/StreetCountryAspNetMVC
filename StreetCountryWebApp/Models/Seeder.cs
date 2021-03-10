using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StreetCountryWebApp.Models
{
    public class Seeder
    {
        private DBContext context;
        public Seeder(DBContext context)
        {
            this.context = context;
        }

        public void Seed()
        {
            if(!context.Streets.Any()&& !context.Countrys.Any())
            {
                Country country = new Country() { Name = "TestCountry" };
                Street street = new Street() { Name = "TestStreet", CountryId = 1 };

                context.Countrys.Add(country);
                context.Streets.Add(street);

                context.SaveChanges();
            }
        }
    }
}
