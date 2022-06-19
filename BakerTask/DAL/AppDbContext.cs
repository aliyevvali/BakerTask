using BakerTask.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BakerTask.DAL
{
    public class AppDbContext:DbContext
    {
        public AppDbContext(DbContextOptions opt):base(opt)
        {
        }
        public DbSet<Category> Categories{ get; set; }
        public DbSet<Product> Products { get; set; }
    }
}
