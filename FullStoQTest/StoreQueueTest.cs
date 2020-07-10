using Microsoft.VisualStudio.TestTools.UnitTesting;
using Recodme.RD.FullStoQ.Business.Commercial;
using Recodme.RD.FullStoQ.Business.Q;
using Recodme.RD.FullStoQ.Data.Commercial;
using Recodme.RD.FullStoQ.Data.Q;

namespace Recodme.RD.FullStoQ.FullStoQTest
{
    [TestClass]
    public class StoreQueueTest
    {
        #region Create
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
        #endregion

        #region Read
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
            Assert.IsTrue(res.Success);
        }
        #endregion

        #region Update
        [TestMethod]
        public void TestUpdateStoreQueue()
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
            var res = objSq.Update(sq);
            Assert.IsTrue(res.Success);
        }

        #endregion

        #region Delete
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
            var res = objSq.Delete(sq);
            Assert.IsTrue(res.Success);
        }
        #endregion

        #region List

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
            var sq1 = new StoreQueue(2, est.Id);
            var sq2 = new StoreQueue(5, est.Id);
            var sq3 = new StoreQueue(3, est.Id);

            var res = objSq.List();
            Assert.IsTrue(res.Success);

            #endregion


        //    #region CreateAsync
        //[TestMethod]
        //public void TestCreateAsyncStoreQueue()
        //{
        //    var objReg = new RegionBusinessObject();
        //    var reg = new Region("Continental");
        //    objReg.Create(reg);

        //    var objCom = new CompanyBusinessObject();
        //    var com = new Company("Quitanda da dona Luzia", 123456);
        //    objCom.Create(com);

        //    var objEst = new EstablishmentBusinessObject();
        //    var est = new Establishment("Avenida Augusta, numero 1910, Lisboa", "07:00", "20:00",
        //        "Domingo", reg.Id, com.Id);
        //    objEst.Create(est);

        //    var objSq = new StoreQueueBusinessObject();
        //    var sq = new StoreQueue(2, est.Id);
        //    var res = objSq.CreateAsync(sq);
        //    Assert.IsTrue(res.Success);
        //}
        //#endregion

        //#region ReadAsync
        //[TestMethod]
        //public void TestReadAsyncStoreQueue()
        //{
        //    var objReg = new RegionBusinessObject();
        //    var reg = new Region("Continental");
        //    objReg.Create(reg);

        //    var objCom = new CompanyBusinessObject();
        //    var com = new Company("Quitanda da dona Luzia", 123456);
        //    objCom.Create(com);

        //    var objEst = new EstablishmentBusinessObject();
        //    var est = new Establishment("Avenida Augusta, numero 1910, Lisboa", "07:00", "20:00",
        //        "Domingo", reg.Id, com.Id);
        //    objEst.Create(est);

        //    var objSq = new StoreQueueBusinessObject();
        //    var sq = new StoreQueue(2, est.Id);
        //    var res = objSq.ReadAsync(sq);
        //    Assert.IsTrue(res.Success);
        //}
        //#endregion

        //#region UpdateAsync
        //[TestMethod]
        //public void TestUpdateAsyncStoreQueue()
        //{
        //    var objReg = new RegionBusinessObject();
        //    var reg = new Region("Continental");
        //    objReg.Create(reg);

        //    var objCom = new CompanyBusinessObject();
        //    var com = new Company("Quitanda da dona Luzia", 123456);
        //    objCom.Create(com);

        //    var objEst = new EstablishmentBusinessObject();
        //    var est = new Establishment("Avenida Augusta, numero 1910, Lisboa", "07:00", "20:00",
        //        "Domingo", reg.Id, com.Id);
        //    objEst.Create(est);

        //    var objSq = new StoreQueueBusinessObject();
        //    var sq = new StoreQueue(2, est.Id);
        //    var res = objSq.UpdateAsync(sq);
        //    Assert.IsTrue(res.Success);
        //}

        //#endregion

        //#region DeleteAsync
        //[TestMethod]
        //public void TestDeleteAsyncStoreQueue()
        //{
        //    var objReg = new RegionBusinessObject();
        //    var reg = new Region("Continental");
        //    objReg.Create(reg);

        //    var objCom = new CompanyBusinessObject();
        //    var com = new Company("Quitanda da dona Luzia", 123456);
        //    objCom.Create(com);

        //    var objEst = new EstablishmentBusinessObject();
        //    var est = new Establishment("Avenida Augusta, numero 1910, Lisboa", "07:00", "20:00",
        //        "Domingo", reg.Id, com.Id);
        //    objEst.Create(est);

        //    var objSq = new StoreQueueBusinessObject();
        //    var sq = new StoreQueue(2, est.Id);
        //    var res = objSq.DeleteAsync(sq);
        //    Assert.IsTrue(res.Success);
        //}
        //#endregion

        //#region ListAsync

        //[TestMethod]
        //public void TestListAsyncStoreQueue()
        //{
        //    var objReg = new RegionBusinessObject();
        //    var reg = new Region("Continental");
        //    objReg.Create(reg);

        //    var objCom = new CompanyBusinessObject();
        //    var com = new Company("Quitanda da dona Luzia", 123456);
        //    objCom.Create(com);

        //    var objEst = new EstablishmentBusinessObject();
        //    var est = new Establishment("Avenida Augusta, numero 1910, Lisboa", "07:00", "20:00",
        //        "Domingo", reg.Id, com.Id);
        //    objEst.Create(est);

        //    var objSq = new StoreQueueBusinessObject();
        //    var sq = new StoreQueue(2, est.Id);
        //    var res = objSq.CreateAsync(sq);
        //    Assert.IsTrue(res.Success);

        //    #endregion
        }
    }
}
