using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using ShoppingCart.Models;
using System.Reflection.Metadata;

namespace ShoppingCart.Data
{
    public class ShoppingDbContext: IdentityDbContext<ApplicationUser>
    {
        public ShoppingDbContext(DbContextOptions<ShoppingDbContext> option)
            :base(option)
        {
            
        }
        public virtual DbSet<Category>  Categories { get; set; }
        public virtual DbSet<Product>  Products { get; set; }
        public virtual DbSet<Cart>  Carts { get; set; }

        //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //{
        //    optionsBuilder.UseSqlServer("");
        //    base.OnConfiguring(optionsBuilder);
        //}
        //protected override void OnModelCreating(ModelBuilder builder)
        //{
        //    builder.Entity<Product>().Property(p=>p.ProductPrice).HasColumnType("varchar");
        //}
        

    }
}
