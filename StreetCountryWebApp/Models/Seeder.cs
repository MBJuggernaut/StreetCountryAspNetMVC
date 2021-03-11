using System.Linq;

namespace StreetCountryWebApp.Models
{
    public class Seeder
    {
        private readonly DBContext context;
        public Seeder(DBContext context)
        {
            this.context = context;
        }

        public void Seed()
        {
            if (!context.Streets.Any() && !context.Countrys.Any())
            {
                Country country = new Country() { Name = "TestCountry" };
                Street street = new Street() { Name = "TestStreet", CountryId = 1 };
                Street street2 = new Street() { Name = "TestStreet2", CountryId = 1 };

                context.Countrys.Add(country);
                context.Streets.AddRange(street, street2);                

                context.SaveChanges();
            }
        }
    }
}
