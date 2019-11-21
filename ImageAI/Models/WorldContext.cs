using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ImageAI.Models;

namespace ImageAI.Models
{
    public class ImageAIContext : DbContext
    {
        public ImageAIContext(DbContextOptions<ImageAIContext> options) :
            base(options)
        {

        }

        public DbSet<Schedule> Schedule { get; set; }
        public DbSet<Car> Car { get; set; }
        public DbSet<Dish> Dish { get; set; }
        public DbSet<Face> Face { get; set; }
    }
}
