using Recodme.RD.FullStoQ.DataAccess.Contexts;
using System;

namespace App
{
    class Program
    {
        static void Main(string[] args)
        {
            var dao = new Context();
            dao.Database.EnsureCreated();
        }
    }
}
