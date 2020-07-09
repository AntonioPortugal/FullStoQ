using Microsoft.VisualStudio.TestTools.UnitTesting;
using Recodme.RD.FullStoQ.Business.Commercial;
using Recodme.RD.FullStoQ.Business.Q;
using Recodme.RD.FullStoQ.Data.Commercial;
using Recodme.RD.FullStoQ.Data.Q;

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
    }
}
