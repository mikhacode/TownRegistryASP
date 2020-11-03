using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace TownRegistryASP.Models
{
    public class MyDbContext : DbContext
    {
        public MyDbContext()
        {

        }
        public DbSet<Citizen> Citizens { get; set; }
        public DbSet<Place> Places { get; set; }
    }
}