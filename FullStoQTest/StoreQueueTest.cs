using Microsoft.VisualStudio.TestTools.UnitTesting;
using Recodme.RD.FullStoQ.Business.Commercial;
using Recodme.RD.FullStoQ.Business.Q;
using Recodme.RD.FullStoQ.Data.Commercial;
using Recodme.RD.FullStoQ.Data.Q;
using System;

namespace FullStoQTest
{
    [TestClass]
    public class StoreQueueTest
    {
        [TestMethod]
        public void TestCreateStoreQueue()
        {
            var objReg = new RegionBusinessObject();
            var reg = new Region("Continental");
            objReg.Create(reg);

            var objCom = new CompanyBusinessObject();
            var com = new Company("Quitanda da dona Luzia", 123456);
            objCom.Create(com);

            var objEst = new EstablishmentBusinessObject();
            var est = new Establishment("Avenida Augusta, numero 1910, Lisboa", "07:00", "20:00", 
                "Domingo", reg.Id, com.Id);
            objEst.Create(est);

            var objSq = new StoreQueueBusinessObject();
            var sq = new StoreQueue(2,est.Id);
            var res = objSq.Create(sq);

            Assert.IsTrue(res.Success);
        }

        [TestMethod]
        public void TestReadStoreQueue()
        {
            var objReg = new RegionBusinessObject();
            var reg = new Region("Continental");
            objReg.Create(reg);

            var objCom = new CompanyBusinessObject();
            var com = new Company("Quitanda da dona Luzia", 123456);
            objCom.Create(com);

            var objEst = new EstablishmentBusinessObject();
            var est = new Establishment("Avenida Augusta, numero 1910, Lisboa", "07:00", "20:00",
                "Domingo", reg.Id, com.Id);
            objEst.Create(est);

            var objSq = new StoreQueueBusinessObject();
            var sq = new StoreQueue(2, est.Id);
            var res = objSq.Create(sq);

            var result = objSq.Read(com.Id);


            Assert.IsTrue(result.Success);
        }


        [TestMethod]
        public void TestUpdateStoreQueue()
        {
            var objSq = new StoreQueueBusinessObject();
            var id = Guid.Parse("122E641B-C9B6-4143-9A5A-02605202ADAC");
            var sq = objSq.Read(id).Result;
            sq.Quantity = 21;
            var result = objSq.Update(sq);

            Assert.IsTrue(result.Success);
        }


        [TestMethod]
        public void TestDeleteStoreQueue()
        {
            var objReg = new RegionBusinessObject();
            var reg = new Region("Continental");
            objReg.Create(reg);

            var objCom = new CompanyBusinessObject();
            var com = new Company("Quitanda da dona Luzia", 123456);
            objCom.Create(com);

            var objEst = new EstablishmentBusinessObject();
            var est = new Establishment("Avenida Augusta, numero 1910, Lisboa", "07:00", "20:00",
                "Domingo", reg.Id, com.Id);
            objEst.Create(est);

            var objSq = new StoreQueueBusinessObject();
            var sq = new StoreQueue(2, est.Id);
            objSq.Create(sq);

            var result = objSq.Delete(com.Id);


            Assert.IsTrue(result.Success);
        }

        [TestMethod]
        public void TestListStoreQueue()
        {
            var objReg = new RegionBusinessObject();
            var reg = new Region("Continental");
            objReg.Create(reg);

            var objCom = new CompanyBusinessObject();
            var com = new Company("Quitanda da dona Luzia", 123456);
            objCom.Create(com);

            var objEst = new EstablishmentBusinessObject();
            var est = new Establishment("Avenida Augusta, numero 1910, Lisboa", "07:00", "20:00",
                "Domingo", reg.Id, com.Id);
            objEst.Create(est);

            var objSq = new StoreQueueBusinessObject();
            var sq = new StoreQueue(2, est.Id);
            objSq.Create(sq);

            var result = objSq.List();

            Assert.IsTrue(result.Success);
        }
    }
}
