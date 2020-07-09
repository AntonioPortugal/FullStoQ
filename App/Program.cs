using Recodme.RD.FullStoQ.Business.Commercial;
using Recodme.RD.FullStoQ.Business.OperationResults;
using Recodme.RD.FullStoQ.Business.Q;
using Recodme.RD.FullStoQ.Data.Commercial;
using Recodme.RD.FullStoQ.Data.Q;
using Recodme.RD.FullStoQ.DataAccess.Contexts;
using System;

namespace App
{
    class Program
    {
        static void Main(string[] args)
        {
            //var dao = new Context();
            //dao.Database.EnsureCreated();


            var obj = new StoreQueueBusinessObject();
            var x = new StoreQueue(234, true );
            var resul = obj.Create(x);
        }
    }
}
