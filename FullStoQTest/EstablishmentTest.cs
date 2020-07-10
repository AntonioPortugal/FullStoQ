using Microsoft.VisualStudio.TestTools.UnitTesting;
using Recodme.RD.FullStoQ.Business.Commercial;
using Recodme.RD.FullStoQ.Data.Commercial;
using Recodme.RD.FullStoQ.DataAccess.Seeders;
using System.Linq;

namespace Recodme.RD.FullStoQ.FullStoQTest
{
    [TestClass]
    public class EstablishmentTest
    {
        #region Create 
        [TestMethod]
        public void TestCreateEstablishment()
        {
            ContextSeeder.Seed();
            var boReg = new RegionBusinessObject();
            var boComp = new CompanyBusinessObject();
            var reg1 = boReg.List().Result.First();
            var com1 = boComp.List().Result.First();
            var bo = new EstablishmentBusinessObject();
            var est = new Establishment("Avenida da liberdade, numero 1029, Lisboa", "09:00", "20:00", "Domingo", reg1.Id, com1.Id);
            var resCreate = bo.Create(est);
            Assert.IsTrue(resCreate.Success);
        }
        #endregion

        #region Read
        public void TestReadEstablishment()
        {
            ContextSeeder.Seed();
            var boReg = new RegionBusinessObject();
            var boComp = new CompanyBusinessObject();
            var reg1 = boReg.List().Result.First();
            var com1 = boComp.List().Result.First();
            var bo = new EstablishmentBusinessObject();
            var est = new Establishment("Avenida da liberdade, numero 1029, Lisboa", "09:00", "20:00", "Domingo", reg1.Id, com1.Id);
            var resGet = bo.Read(est.Id);
            Assert.IsTrue(resGet.Success && resGet.Result != null);
        }

        #endregion

        #region Update
        [TestMethod]
        public void TestUpdateEstablishment()
        {
            ContextSeeder.Seed();
            var boReg = new RegionBusinessObject();
            var boComp = new CompanyBusinessObject();
            var reg1 = boReg.List().Result.First();
            var com1 = boComp.List().Result.First();
            var bo = new EstablishmentBusinessObject();
            var est = new Establishment("Avenida da liberdade, numero 1029, Lisboa", "09:00", "20:00", "Domingo", reg1.Id, com1.Id);
            var resList = bo.List();
            var item = resList.Result.FirstOrDefault();
            item.Address = "Rua Augusta, n 1213, Lisboa";
            var resUpdate = bo.Update(item);
            var resNotList = bo.List().Result.Where(x => !x.IsDeleted);

            Assert.IsTrue(resUpdate.Success && resNotList.First().Address == "Rua Augusta, n 1213, Lisboa");
        }
        #endregion

        #region Delete
        [TestMethod]
        public void TestDeleteEstablishment()
        {
            var obReg = new RegionBusinessObject();
            var reg = new Region("Continental");
            obReg.Create(reg);

            var objCom = new CompanyBusinessObject();
            var com = new Company("Quitanda da dona Luzia", 123456);
            objCom.Create(com);

            var objEst = new EstablishmentBusinessObject();
            var est = new Establishment("Rua da pitaia, numero 1234, Açores", "07:00",
                "20:00", "Domingo", reg.Id, com.Id);
            objEst.Create(est);

            var res = objEst.Delete(est);

            Assert.IsTrue(res.Success);
        }
        #endregion

        #region List
        [TestMethod]
        public void TestListEstablishment()
        {
            var boReg = new RegionBusinessObject();
            var boComp = new CompanyBusinessObject();
            var reg1 = boReg.List().Result.First();
            var com1 = boComp.List().Result.First();

            var objEst = new EstablishmentBusinessObject();
            var est = new Establishment("Rua da pitaia, numero 1234, Açores", "07:00",
                "20:00", "Domingo", reg1.Id, com1.Id);
            objEst.Create(est);

            var est2 = new Establishment("Rua da Manga, numero 10, Porto", "07:00",
               "20:00", "Domingo", reg1.Id, com1.Id);
            objEst.Create(est2);

            var est3 = new Establishment("Rua do girassol, numero 134, Alentejo", "07:00",
               "20:00", "Domingo", reg1.Id, com1.Id);
            objEst.Create(est3);

            var resList = objEst.List();
            Assert.IsTrue(resList.Success && resList.Result.Count == 1);
        }
        #endregion
    }
}

