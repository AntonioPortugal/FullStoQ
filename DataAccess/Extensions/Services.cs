using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Recodme.RD.FullStoQ.DataAccess.Contexts;
using Recodme.RD.FullStoQ.DataAccess.Properties;
using System;
using System.Collections.Generic;
using System.Text;

namespace Recodme.RD.FullStoQ.DataAccess.Extensions
{
    public static class Services
    {
        public static void AddDataAccessContext(this IServiceCollection serviceCollection)
        {
            serviceCollection.AddDbContext<Context>(item =>
            item.UseSqlServer(Resources.ConnectionString));
        }
    }
}
