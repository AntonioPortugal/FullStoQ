using Microsoft.VisualStudio.TestTools.UnitTesting;
using Recodme.RD.FullStoQ.Business.Commercial;
using Recodme.RD.FullStoQ.Business.Q;
using Recodme.RD.FullStoQ.Data.Commercial;
using Recodme.RD.FullStoQ.Data.Q;
using Recodme.RD.FullStoQ.DataAccess.Seeders;
using System.Linq;

namespace Recodme.RD.FullStoQ.FullStoQTest
{
    [TestClass]
    public class StoreQueueTest
    {
        [TestMethod]
        public void TestCreateAndReadStoreQueues()
        {
            ContextSeeder.Seed();
            var bo = new StoreQueueBusinessObject();
            var est = bo.List().Result.First();
            var reg = new StoreQueue(2, est.Id);
            var resCreate = bo.Create(reg);
            var resGet = bo.Read(reg.Id);
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
        public void TestUpdateStoreQueues()
        {
            ContextSeeder.Seed();
            var bo = new StoreQueueBusinessObject();
            var resultList = bo.List().Result.First();
            var item = new StoreQueue(3, resultList.Id);
            item.Quantity = 4;
            

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

        #region List

        [TestMethod]
        public void TestListStoreQueue()
        {
            
            //var res = objSq.List();
            //Assert.IsTrue(res.Success);


        }
        #endregion
    }
}
