using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ImageSearch.Web.Models;

namespace ImageSearch.Web.Models
{
    public class WorldContext : DbContext
    {
        public WorldContext(DbContextOptions<WorldContext> options) :
            base(options)
        {

        }

        public DbSet<ImageSearch.Web.Models.Schedule> Schedule { get; set; }
        public DbSet<ImageSearch.Web.Models.Car> Car { get; set; }
        public DbSet<ImageSearch.Web.Models.Dish> Dish { get; set; }
        public DbSet<ImageSearch.Web.Models.Face> Face { get; set; }
        public DbSet<ImageSearch.Web.Models.Identity> Identity { get; set; }
    }
}
