using Microsoft.EntityFrameworkCore;
using System.Data.Entity;
using WebApiZoo.Models;
using DbContext = Microsoft.EntityFrameworkCore.DbContext;

namespace WebApiZoo.Databse
{
    public class ZooDbContext(DbContextOptions<ZooDbContext> options) : DbContext(options)
    {
        public System.Data.Entity.DbSet<Animal> Animals { get; set; }
        public System.Data.Entity.DbSet<Food> Foods { get; set; }
    }
}
