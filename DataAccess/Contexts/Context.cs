﻿using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Recodme.RD.FullStoQ.Data.Commercial;
using Recodme.RD.FullStoQ.Data.Goods;
using Recodme.RD.FullStoQ.Data.Person;
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
        //    builder.Entity<Profile>().HasOne(x => x.AccountUser).WithOne(x => x.Profile);
        //    base.OnModelCreating(builder);
        //}

        public DbSet<Account> Accounts { get; set; }
        public DbSet<Brand> Brands { get; set; }
        public DbSet<Company> Companies { get; set; }
        public DbSet<Establishment> Establishments { get; set; }
        public DbSet<EssentialGood> EssentialGoods { get; set; }
        public DbSet<Profile> Profiles { get; set; }
        public DbSet<Message> Messages { get; set; }
        public DbSet<Queue> Queues { get; set; }
        public DbSet<Region> Regions { get; set; }
        public DbSet<ShoppingBasket> ShoppingBaskets { get; set; }
        public DbSet<Type> Types { get; set; }    

    }
}
