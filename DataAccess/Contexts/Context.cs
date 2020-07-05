using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Recodme.RD.FullStoQ.Data.Commercial;
using Recodme.RD.FullStoQ.Data.Goods;
using Recodme.RD.FullStoQ.Data.Users;
using Recodme.RD.FullStoQ.DataAccess.Properties;
using System.Collections;

namespace Recodme.RD.FullStoQ.DataAccess.Contexts
{
    public class Context : IdentityDbContext
    {
        public Context() : base()
        {

        }

        public Context(DbContextOptions<Context> options) : base(options)
        {

        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(Resources.ConnectionString);
            }
        }

        //protected override void OnModelCreating(ModelBuilder builder)
        //{
        //    builder.Entity<Person>().HasOne(x => x.LennyouseUser).WithOne(x => x.Person);
        //    base.OnModelCreating(builder);
        //}

        public DbSet<Account> Account { get; set; }
        public DbSet<Profile> Profile { get; set; }
        public DbSet<EssentialGood> EssentialGood { get; set; }
        public DbSet<ShoppingBasket> ShoppingBasket { get; set; }
        public DbSet<Type> Type { get; set; }
        public DbSet<Brand> Brand { get; set; }
        public DbSet<Queue> Queue { get; set; }
        public DbSet<Establishment> Establishment { get; set; }
        public DbSet<Region> Region { get; set; }
        public DbSet<Company> Company { get; set; }

    }
}
