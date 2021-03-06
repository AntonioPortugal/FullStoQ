﻿using Microsoft.VisualStudio.TestTools.UnitTesting;
using Recodme.RD.FullStoQ.Business.Commercial;
using Recodme.RD.FullStoQ.Data.Commercial;
using Recodme.RD.FullStoQ.DataAccess.Seeders;
using System.Linq;

namespace Recodme.RD.FullStoQ.FullStoQTest.Commercial
{
    [TestClass]
    public class EstablishmentTest
    {
        #region Create and Read
        [TestMethod]
        public void TestCreateReadEstablishment()
        {
            ContextSeeder.Seed();
            var boReg = new RegionBusinessObject();
            var reg1 = boReg.List().Result.First();

            var boComp = new CompanyBusinessObject();           
            var com1 = boComp.List().Result.First();

            var bo = new EstablishmentBusinessObject();
            var est = new Establishment("Avenida da liberdade, numero 1029, Lisboa", "09:00", "20:00", "Domingo", reg1.Id, com1.Id);
            var resCreate = bo.Create(est);
            var resGet = bo.Read(est.Id);

            Assert.IsTrue(resCreate.Success && resGet.Success && resGet.Result != null);
        }
        #endregion

        #region Create and Read Async
        [TestMethod]
        public void TestCreateAndReadEstablishmentAsync()
        {
            ContextSeeder.Seed();
            
            var boReg = new RegionBusinessObject();
            var reg1 = boReg.List().Result.First();

            var boComp = new CompanyBusinessObject();            
            var com1 = boComp.List().Result.First();

            var bo = new EstablishmentBusinessObject();
            var est = new Establishment("Avenida da liberdade, numero 1029, Lisboa", "09:00", "20:00", "Domingo", reg1.Id, com1.Id);
            var resCreate = bo.CreateAsync(est).Result;
            var resGet = bo.ReadAsync(est.Id).Result;

            Assert.IsTrue(resCreate.Success && resGet.Success && resGet.Result != null);
        }
        #endregion

        #region Update
        [TestMethod]
        public void TestUpdateEstablishment()
        {
            ContextSeeder.Seed();

            var boReg = new RegionBusinessObject();
            var reg1 = boReg.List().Result.First();

            var boComp = new CompanyBusinessObject();            
            var com1 = boComp.List().Result.First();

            var bo = new EstablishmentBusinessObject();           
            var resList = bo.List();
            var item = resList.Result.FirstOrDefault();
            item.Address = "Rua Augusta, n 1213, Lisboa";
            var resUpdate = bo.Update(item);
            var resNotList = bo.List().Result.Where(x => !x.IsDeleted);

            Assert.IsTrue(resUpdate.Success && resNotList.First().Address == "Rua Augusta, n 1213, Lisboa");
        }
        #endregion

        #region Update Async
        [TestMethod]
        public void TestUpdateEstablishmentAsync()
        {
            ContextSeeder.Seed();
            var bo = new EstablishmentBusinessObject();
            var restList = bo.ListAsync().Result;
            var item = restList.Result.FirstOrDefault();
            item.ClosingDays = "Terça-feira";
            var resUpdate = bo.UpdateAsync(item).Result;
            restList = bo.ListNotDeletedAsync().Result;
            Assert.IsTrue(restList.Success && resUpdate.Success && restList.Result.First().ClosingDays == "Terça-feira");
        }
        #endregion

        #region Delete
        [TestMethod]
        public void TestDeleteEstablishment()
        {
            var boReg = new RegionBusinessObject();
            var boComp = new CompanyBusinessObject();
            var reg1 = boReg.List().Result.First();
            var com1 = boComp.List().Result.First();

            var objEst = new EstablishmentBusinessObject();
            var est = new Establishment("Rua da pitaia, numero 1234, Açores", "07:00",
                "20:00", "Domingo", reg1.Id, com1.Id);
            objEst.Create(est);
            var res = objEst.Delete(est);
            Assert.IsTrue(res.Success);
        }
        #endregion

        #region Async Delete
        [TestMethod]
        public void TestDeleteEstablishmentAsync()
        {
            ContextSeeder.Seed();
            var bo = new EstablishmentBusinessObject();
            var resList = bo.ListAsync().Result;
            var resDelete = bo.DeleteAsync(resList.Result.First().Id).Result;
            resList = bo.ListNotDeletedAsync().Result;
            Assert.IsTrue(resDelete.Success && resList.Success && resList.Result.Count == 0);
        }
        #endregion

        #region List
        [TestMethod]
        public void TestListEstablishment()
        {
            var bo = new EstablishmentBusinessObject();
            var resList = bo.List();
            Assert.IsTrue(resList.Success && resList.Result.Count == 1);
        }
        #endregion

        #region List Async
        [TestMethod]
        public void TestListEstablishmentAsync()
        {
            ContextSeeder.Seed();
            var bo = new EstablishmentBusinessObject();
            var restList = bo.ListAsync().Result;
            Assert.IsTrue(restList.Success && restList.Result.Count == 1);
        }
        #endregion

    }
}

