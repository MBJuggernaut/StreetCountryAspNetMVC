using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StreetCountryWebApp.Models
{
    public class DBContext : DbContext
    {
        public DbSet<Street> Streets { get; set; }
        public DbSet<Country> Countrys { get; set; }

        public DBContext(DbContextOptions<DBContext> options)
            : base(options)
        {
            Database.EnsureCreated();
        }
    }
}