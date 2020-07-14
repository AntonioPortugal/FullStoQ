using Microsoft.VisualStudio.TestTools.UnitTesting;
using Recodme.RD.FullStoQ.Business.Q;
using Recodme.RD.FullStoQ.Data.Commercial;
using Recodme.RD.FullStoQ.Data.Q;
using Recodme.RD.FullStoQ.DataAccess.Seeders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Recodme.RD.FullStoQ.FullStoQTest
{
    [TestClass]
    public class ReservedQueueTest
    {
        [TestMethod]
        public void TestCreateAndReadReservedQueues()
        {
            ContextSeeder.Seed();
            var bo = new ReservedQueueBusinessObject();
            var resList = bo.List();
            var item = resList.Result.FirstOrDefault();
            var reg = new ReservedQueue(item.EstablishmentId);
            var resCreate = bo.Create(reg);
            var resGet = bo.Read(reg.Id);
            Assert.IsTrue(resCreate.Success && resGet.Success && resGet.Result != null);
        }

        [TestMethod]
        public void TestCreateAndReadReservedQueueAsync()
        {
            ContextSeeder.Seed();
            var bo = new ReservedQueueBusinessObject();
            var resList = bo.List();
            var item = resList.Result.FirstOrDefault();
            var reg = new ReservedQueue(item.EstablishmentId);
            var resCreate = bo.CreateAsync(reg).Result;
            var resGet = bo.ReadAsync(reg.Id).Result;
            Assert.IsTrue(resCreate.Success && resGet.Success && resGet.Result != null);
        }

        [TestMethod]
        public void TestListReservedQueues()
        {
            ContextSeeder.Seed();
            var bo = new ReservedQueueBusinessObject();
            var resList = bo.List();
            Assert.IsTrue(resList.Success && resList.Result.Count == 1);
        }

        [TestMethod]
        public void TestListReservedQueueAsync()
        {
            ContextSeeder.Seed();
            var bo = new ReservedQueueBusinessObject();
            var resList = bo.ListAsync().Result;
            Assert.IsTrue(resList.Success && resList.Result.Count == 1);
        }

        [TestMethod]
        public void TestUpdateReservedQueues()
        {
            ContextSeeder.Seed();
            var bo = new ReservedQueueBusinessObject();
            var resList = bo.List();
            var item = resList.Result.FirstOrDefault();
            item.EstablishmentId = Guid.NewGuid();
            var resUpdate = bo.Update(item);
            var resNotList = bo.ListNotDeleted().Result;
            Assert.IsTrue(resUpdate.Success && resNotList.First().EstablishmentId == item.EstablishmentId);
        }

        [TestMethod]
        public void TestUpdateReservedQueuenAsync()
        {
            ContextSeeder.Seed();
            var bo = new ReservedQueueBusinessObject();
            var resList = bo.ListAsync().Result;
            var item = resList.Result.FirstOrDefault();
            item.EstablishmentId = Guid.NewGuid();
            var resUpdate = bo.UpdateAsync(item).Result;
            resList = bo.ListNotDeletedAsync().Result;
            Assert.IsTrue(resList.Success && resUpdate.Success && resList.Result.First().EstablishmentId == item.EstablishmentId);
        }

        [TestMethod]
        public void TestDeleteReservedQueues()
        {
            ContextSeeder.Seed();
            var bo = new ReservedQueueBusinessObject();
            var resList = bo.List();
            var resDelete = bo.Delete(resList.Result.First().Id);
            var resNotList = bo.List().Result.Where(x => !x.IsDeleted).ToList();
            Assert.IsTrue(resDelete.Success && resNotList.Count == 0);
        }

        [TestMethod]
        public void TestDeleteReservedQueueAsync()
        {
            ContextSeeder.Seed();
            var bo = new ReservedQueueBusinessObject();
            var resList = bo.ListAsync().Result;
            var resDelete = bo.DeleteAsync(resList.Result.First().Id).Result;
            resList = bo.ListNotDeletedAsync().Result;
            Assert.IsTrue(resDelete.Success && resList.Success && resList.Result.Count == 0);
        }
    }
}
