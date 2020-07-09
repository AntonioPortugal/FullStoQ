using Microsoft.EntityFrameworkCore;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Recodme.RD.FullStoQ.Business.Commercial;
using Recodme.RD.FullStoQ.Data.Commercial;
using System.Threading.Tasks;

namespace FullStoQTest
{
    [TestClass]
    public class TypeTest
    {
        #region Create
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
        #endregion

        #region Read
        [TestMethod]
        public void TestReadEstablishment()
        {
            var obj = new RegionBusinessObject();
            var reg = new Region("Continental");
            obj.Create(reg);

            var objCom = new CompanyBusinessObject();
            var com = new Company("Quitanda da dona Luzia", 123456);
            objCom.Create(com);

            var objEst = new EstablishmentBusinessObject();
            var est = new Establishment("Rua da pitaia, numero 1234, Açores", "07:00",
                "20:00", "Domingo", reg.Id, com.Id);
            objEst.Create(est);

            var res = obj.Read(est.Id);
            Assert.IsTrue(res.Success);
        }
        #endregion

        #region Update      
        #endregion

        #region Delete

        #endregion

        #region List
        #endregion
    }
}
