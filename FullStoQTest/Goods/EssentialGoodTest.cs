using Microsoft.VisualStudio.TestTools.UnitTesting;
using Recodme.RD.FullStoQ.Business.Goods;
using Recodme.RD.FullStoQ.Data.Goods;
using Recodme.RD.FullStoQ.DataAccess.Seeders;
using System.Linq;

namespace Recodme.RD.FullStoQ.FullStoQTest.Goods
{
    [TestClass]
    public class EssentialGoodTest
    {
        public void TestCreateAndReadEssentialGoods()
        {
            ContextSeeder.Seed();
            var bo = new EssentialGoodBusinessObject();
            var reg = new EssentialGood("Lisboa");
            var resCreate = bo.Create(reg);
            var resGet = bo.Read(reg.Id);
            Assert.IsTrue(resCreate.Success && resGet.Success && resGet.Result != null);
        }

        [TestMethod]
        public void TestCreateAndReadEssentialGoodAsync()
        {
            ContextSeeder.Seed();
            var bo = new EssentialGoodBusinessObject();
            var reg = new EssentialGood("Lisboa");
            var resCreate = bo.CreateAsync(reg).Result;
            var resGet = bo.ReadAsync(reg.Id).Result;
            Assert.IsTrue(resCreate.Success && resGet.Success && resGet.Result != null);
        }

        [TestMethod]
        public void TestListEssentialGoods()
        {
            ContextSeeder.Seed();
            var bo = new EssentialGoodBusinessObject();
            var resList = bo.List();
            Assert.IsTrue(resList.Success && resList.Result.Count == 1);
        }

        [TestMethod]
        public void TestListEssentialGoodAsync()
        {
            ContextSeeder.Seed();
            var bo = new EssentialGoodBusinessObject();
            var resList = bo.ListAsync().Result;
            Assert.IsTrue(resList.Success && resList.Result.Count == 1);
        }

        [TestMethod]
        public void TestUpdateEssentialGoods()
        {
            ContextSeeder.Seed();
            var bo = new EssentialGoodBusinessObject();
            var resList = bo.List();
            var item = resList.Result.FirstOrDefault();
            item.Name = "another";
            var resUpdate = bo.Update(item);
            var resNotList = bo.ListNotDeleted().Result;
            Assert.IsTrue(resUpdate.Success && resNotList.First().Name == "another");
        }

        [TestMethod]
        public void TestUpdateEssentialGoodnAsync()
        {
            ContextSeeder.Seed();
            var bo = new EssentialGoodBusinessObject();
            var resList = bo.ListAsync().Result;
            var item = resList.Result.FirstOrDefault();
            item.Name = "another";
            var resUpdate = bo.UpdateAsync(item).Result;
            resList = bo.ListNotDeletedAsync().Result;
            Assert.IsTrue(resList.Success && resUpdate.Success && resList.Result.First().Name == "another");
        }

        [TestMethod]
        public void TestDeleteEssentialGoods()
        {
            ContextSeeder.Seed();
            var bo = new EssentialGoodBusinessObject();
            var resList = bo.List();
            var resDelete = bo.Delete(resList.Result.First().Id);
            var resNotList = bo.List().Result.Where(x => !x.IsDeleted).ToList();
            Assert.IsTrue(resDelete.Success && resNotList.Count == 0);
        }

        [TestMethod]
        public void TestDeleteEssentialGoodAsync()
        {
            ContextSeeder.Seed();
            var bo = new EssentialGoodBusinessObject();
            var resList = bo.ListAsync().Result;
            var resDelete = bo.DeleteAsync(resList.Result.First().Id).Result;
            resList = bo.ListNotDeletedAsync().Result;
            Assert.IsTrue(resDelete.Success && resList.Success && resList.Result.Count == 0);
        }
    }
}
