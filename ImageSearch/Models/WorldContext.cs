using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ImageSearch.Models;

namespace ImageSearch.Models
{
    public class WorldContext : DbContext
    {
        public WorldContext(DbContextOptions<WorldContext> options) :
            base(options)
        {

        }

        public DbSet<City> City { get; set; }
        public DbSet<Schedule> Schedule { get; set; }
        public DbSet<ImageSearch.Models.Car> Car { get; set; }
    }
}
