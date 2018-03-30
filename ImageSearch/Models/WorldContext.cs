using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ImageSearchApp.Models;

namespace ImageSearchApp.Models
{
    public class WorldContext : DbContext
    {
        public WorldContext(DbContextOptions<WorldContext> options) :
            base(options)
        {

        }

        public DbSet<City> City { get; set; }
        public DbSet<Schedule> Schedule { get; set; }
        public DbSet<ImageSearchApp.Models.Car> Car { get; set; }
        public DbSet<ImageSearchApp.Models.Dish> Dish { get; set; }
    }
}
