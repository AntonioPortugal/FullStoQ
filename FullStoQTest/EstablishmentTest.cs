using Microsoft.VisualStudio.TestTools.UnitTesting;
using Recodme.RD.FullStoQ.Business.Commercial;
using Recodme.RD.FullStoQ.Data.Commercial;

namespace FullStoQTest
{
    [TestClass]
    public class TypeTest
    {
        [TestMethod]
        public void TestCreateEstablishment()
        {
            var obj = new RegionBusinessObject();
            var reg = new Region("Continental");
            obj.Create(reg);

            var objCom = new CompanyBusinessObject();
            var com = new Company("Quitanda da dona Luzia", 123456);
            objCom.Create(com);

            var objEst = new EstablishmentBusinessObject();
            var est = new Establishment("Avenida da liberdade, numero 230, Lisboa", "08:00", "20:00", "Domingo",
                reg.Id, com.Id);
            var re = objEst.Create(est);

            Assert.IsTrue(re.Success);
        }
    }
}
