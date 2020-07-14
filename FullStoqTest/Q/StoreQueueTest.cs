using Microsoft.VisualStudio.TestTools.UnitTesting;
using Recodme.RD.FullStoQ.Business.Commercial;
using Recodme.RD.FullStoQ.Business.Q;
using Recodme.RD.FullStoQ.Data.Commercial;
using Recodme.RD.FullStoQ.Data.Q;
using Recodme.RD.FullStoQ.DataAccess.Seeders;
using System.Linq;

namespace Recodme.RD.FullStoQ.FullStoQTest.Q
{
    [TestClass]
    public class StoreQueueTest
    {
        [TestMethod]
        public void TestCreateAndReadStoreQueues()
        {
            ContextSeeder.Seed();
            var ebo = new EstablishmentBusinessObject();
            var sbo = new StoreQueueBusinessObject();
            var est = ebo.List().Result.First();
            var reg = new StoreQueue(2, est.Id);
            var resCreate = sbo.Create(reg);
            var resGet = sbo.Read(reg.Id);
            Assert.IsTrue(resCreate.Success && resGet.Success && resGet.Result != null);
        }

        [TestMethod]
        public void TestCreateAndReadStoreQueuesAsync()
        {
            ContextSeeder.Seed();
            var ebo = new EstablishmentBusinessObject();
            var sbo = new StoreQueueBusinessObject();
            var est = ebo.List().Result.First();
            var reg = new StoreQueue(2, est.Id);
            var resCreate = sbo.CreateAsync(reg).Result;
            var resGet = sbo.ReadAsync(reg.Id).Result;
            Assert.IsTrue(resCreate.Success && resGet.Success && resGet.Result != null);
        }

        [TestMethod]
        public void TestListStoreQueues()
        {
            ContextSeeder.Seed();
            var bo = new StoreQueueBusinessObject();
            var resList = bo.List();
            Assert.IsTrue(resList.Success && resList.Result.Count == 1);
        }

        [TestMethod]
        public void TestListStoreQueuesAsync()
        {
            ContextSeeder.Seed();
            var bo = new StoreQueueBusinessObject();
            var resList = bo.ListAsync().Result;
            Assert.IsTrue(resList.Success && resList.Result.Count == 1);
        }

        [TestMethod]
        public void TestUpdateStoreQueues()
        {
            ContextSeeder.Seed();
            var bo = new StoreQueueBusinessObject();
            var resultList = bo.List();
            var item = resultList.Result.FirstOrDefault();
            item.Quantity = 24;
            var resUpdate = bo.Update(item);
            var resNotList = bo.List().Result.Where(x => !x.IsDeleted);
            Assert.IsTrue(resUpdate.Success && resNotList.First().Quantity == 24);

        }

        [TestMethod]
        public void TestUpdateStoreQueuesAsync()
        {
            ContextSeeder.Seed();
            var bo = new StoreQueueBusinessObject();
            var resultList = bo.List();
            var item = resultList.Result.FirstOrDefault();
            item.Quantity = 24;
            var resUpdate = bo.UpdateAsync(item).Result;
            var resNotList = bo.List().Result.Where(x => !x.IsDeleted);
            Assert.IsTrue(resUpdate.Success && resNotList.First().Quantity == 24);

        }

        [TestMethod]
        public void TestDeleteStoreQueues()
        {
            ContextSeeder.Seed();
            var bo = new StoreQueueBusinessObject();
            var resList = bo.List();
            var resDelete = bo.Delete(resList.Result.First().Id);
            var resNotList = bo.List().Result.Where(x => !x.IsDeleted).ToList();
            Assert.IsTrue(resDelete.Success && resNotList.Count == 0);
        }

        [TestMethod]
        public void TestDeleteStoreQueuesAsync()
        {
            ContextSeeder.Seed();
            var bo = new StoreQueueBusinessObject();
            var resList = bo.ListAsync().Result;
            var resDelete = bo.DeleteAsync(resList.Result.First().Id).Result;
            resList = bo.ListNotDeletedAsync().Result;
            Assert.IsTrue(resDelete.Success && resList.Success && resList.Result.Count == 0);
        }

    }
}
