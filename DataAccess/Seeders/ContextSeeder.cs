﻿using Recodme.RD.FullStoQ.Data.Commercial;
using Recodme.RD.FullStoQ.Data.Goods;
using Recodme.RD.FullStoQ.Data.Q;
using Recodme.RD.FullStoQ.DataAccess.Contexts;

namespace Recodme.RD.FullStoQ.DataAccess.Seeders
{
    public static class ContextSeeder
    {
        public static void Seed()
        {
            using var _ctx = new Context();
            _ctx.Database.EnsureDeleted();
            _ctx.Database.EnsureCreated();
            var comp1 = new Company("pingo ácido", 123456789);
            var reg1 = new Region("Covilhã");
            var est1 = new Establishment("rua das papoilas", "09h00", "20h00", "sundays and holidays", reg1.Id, comp1.Id);
            var reQ1 = new ReservedQueue(est1.Id);
            var stQ1 = new StoreQueue(12, est1.Id);

            var cat1 = new Category("Non-Alcoholic Beverages");
            var bra1 = new Brand("Luso");
            var eg1 = new EssentialGood("Água", false, "560-3187-922", 0.39, 0.5);
            var spb1 = new ShoppingBasket(est1.Id);


            _ctx.Companies.AddRange(comp1);
            _ctx.Regions.AddRange(reg1);
            _ctx.Establishments.AddRange(est1);
            _ctx.ReservedQueues.AddRange(reQ1);
            _ctx.StoreQueues.AddRange(stQ1);
            _ctx.ShoppingBaskets.AddRange(spb1);
            _ctx.SaveChanges();
        }
    }
}
