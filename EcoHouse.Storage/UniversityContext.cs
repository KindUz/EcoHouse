using EcoHouse.Storage.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EcoHouse.Storage
{
    public class UniversityContext : DbContext
    {
        public UniversityContext(DbContextOptions<UniversityContext> options) : base(options)
        {
        }

        public DbSet<Dish> dishes { get; set; }
        public DbSet<Structure> structures { get; set; }
        public DbSet<Main_Address> main_Addresses { get; set; }
        public DbSet<Another_Adresses> Another_Adresses { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Delivery> Deliveries { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Array_Of_Phones> Array_Of_Phones { get; set; }


    }
}
