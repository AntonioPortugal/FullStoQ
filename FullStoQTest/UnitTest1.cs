using Microsoft.VisualStudio.TestTools.UnitTesting;
using Recodme.RD.FullStoQ.Business.Commercial;
using Recodme.RD.FullStoQ.Business.Q;
using Recodme.RD.FullStoQ.Data.Commercial;
using Recodme.RD.FullStoQ.Data.Q;
using System;

namespace FullStoQTest
{
    [TestClass]
    public class FullStoqTest
    {
        [TestMethod]
        public void TestCreatQueue()
        {
            var obj = new StoreQueueBusinessObject();
            var x = new StoreQueue(2333, true, Guid.NewGuid());
            var result = obj.Create(x);
            Assert.IsTrue(result.Success);

        }

        [TestMethod]
        public void TestCreatEstablishment()
        {
            var rbo = new RegionBusinessObject();
            var y = new Region("Madeira");
            var cbo = new CompanyBusinessObject();
            var z = new Company("Lidl", 12222);
            var qbo = new StoreQueueBusinessObject();
            var q = new StoreQueue(234, true, Guid.NewGuid());


            var obj = new EstablishmentBusinessObject();
            var x = new Establishment("Avenida da liberdadade, numero 20", "07:00", "20:00", "Domingo",
                y.Id, z.Id, q.Id);
            var result = obj.Create(x);
            Assert.IsTrue(result.Success);

        }
    }

}
