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
                var country = new Country() { Name = "TestCountry" };
                context.Countrys.Add(country);
                context.SaveChanges();

                var id = context.Countrys.First().Id;

                var street = new Street() { Name = "TestStreet", CountryId = id };
                var street2 = new Street() { Name = "TestStreet2", CountryId = id };

                context.Streets.AddRange(street, street2);

                context.SaveChanges();
            }
        }
    }
}
