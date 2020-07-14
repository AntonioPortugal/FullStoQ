using Microsoft.VisualStudio.TestTools.UnitTesting;
using Recodme.RD.FullStoQ.Business.Commercial;
using Recodme.RD.FullStoQ.Business.Goods;
using Recodme.RD.FullStoQ.Data.Commercial;
using Recodme.RD.FullStoQ.Data.Goods;
using Recodme.RD.FullStoQ.DataAccess.Seeders;
using System.Linq;

namespace Recodme.RD.FullStoQ.FullStoQTest
{
    [TestClass]
    public class ShoppingBasketTests
    {
        #region Create and Read
        [TestMethod]
        public void TestCreateAndReadShoppingBasket()
        {
            ContextSeeder.Seed();
            var sbo = new ShoppingBasketBusinessObject();
            var ebo = new EstablishmentBusinessObject();
            var resList = ebo.List();
            var item = resList.Result.FirstOrDefault();
            var sb = new ShoppingBasket(item.Id);
            var resCreate = sbo.Create(sb);
            var resGet = sbo.Read(sb.Id);
            Assert.IsTrue(resCreate.Success && resGet.Success && resGet.Result != null);
        }
        #endregion

        #region Create and Read Async
        [TestMethod]
        public void TestCreateAndReadShoppingBasketAsync()
        {
            ContextSeeder.Seed();
            var bo = new ShoppingBasketBusinessObject();
            var ebo = new EstablishmentBusinessObject();
            var resList = ebo.List();
            var item = resList.Result.FirstOrDefault();
            var sb = new ShoppingBasket(item.Id);
            var resCreate = bo.CreateAsync(sb).Result;
            var resGet = bo.ReadAsync(sb.Id).Result;
            Assert.IsTrue(resCreate.Success && resGet.Success && resGet.Result != null);
        }
        #endregion

        #region Update
        [TestMethod]
        public void TestUpdateShoppingBasket()
        {
            ContextSeeder.Seed();
            var bo = new ShoppingBasketBusinessObject();
            var ebo = new EstablishmentBusinessObject();
            var rbo = new RegionBusinessObject();
            var cbo = new CompanyBusinessObject();
            var reg = rbo.List().Result.FirstOrDefault();
            var com = cbo.List().Result.FirstOrDefault();
            var est = new Establishment("rua das papoilas", "09h00", "20h00", "sundays and holidays", reg.Id, com.Id);
            ebo.Create(est);
            var resList = bo.List();
            var item = resList.Result.FirstOrDefault();
            item.EstablishmentId = est.Id;
            var resUpdate = bo.Update(item);
            var resNotList = bo.ListNotDeleted().Result;
            Assert.IsTrue(resUpdate.Success && resNotList.First().EstablishmentId == est.Id);
        }
        #endregion

        #region Update Assync
        [TestMethod]
        public void TestUpdateShoppingBasketAsync()
        {
            ContextSeeder.Seed();
            var bo = new ShoppingBasketBusinessObject();
            var ebo = new EstablishmentBusinessObject();
            var rbo = new RegionBusinessObject();
            var cbo = new CompanyBusinessObject();
            var reg = rbo.ListAsync().Result.Result.FirstOrDefault();
            var com = cbo.ListAsync().Result.Result.FirstOrDefault();
            var est = new Establishment("rua das papoilas", "09h00", "20h00", "sundays and holidays", reg.Id, com.Id);
            ebo.Create(est);
            var resList = bo.ListAsync();
            var item = resList.Result.Result.FirstOrDefault();
            item.EstablishmentId = est.Id;
            var resUpdate = bo.UpdateAsync(item).Result;
            var resNotList = bo.ListNotDeletedAsync().Result.Result;
            Assert.IsTrue(resUpdate.Success && resNotList.First().EstablishmentId == est.Id);
        }
        #endregion

        #region Delete
        [TestMethod]
        public void TestDeleteShoppingBasket()
        {
            ContextSeeder.Seed();
            var bo = new ShoppingBasketBusinessObject();
            var resList = bo.List();
            var resDelete = bo.Delete(resList.Result.First().Id);
            var resNotList = bo.List().Result.Where(x => !x.IsDeleted).ToList();
            Assert.IsTrue(resDelete.Success && resNotList.Count == 0);
        }
        #endregion        

        #region Assync Delete
        [TestMethod]
        public void TestDeleteEstablishmentAsync()
        {
            ContextSeeder.Seed();
            var bo = new ShoppingBasketBusinessObject();
            var resList = bo.ListAsync().Result;
            var resDelete = bo.DeleteAsync(resList.Result.First().Id).Result;
            resList = bo.ListNotDeletedAsync().Result;
            Assert.IsTrue(resDelete.Success && resList.Success && resList.Result.Count == 0);
        }
        #endregion

        #region List
        [TestMethod]
        public void TestListShoppingBasket()
        {
            ContextSeeder.Seed();
            var bo = new ShoppingBasketBusinessObject();
            var resList = bo.List();
            Assert.IsTrue(resList.Success && resList.Result.Count == 1);
        }
        #endregion

        #region List Async
        [TestMethod]
        public void TestListShoppingBasketAsync()
        {
            ContextSeeder.Seed();
            var bo = new ShoppingBasketBusinessObject();
            var resList = bo.ListAsync().Result;
            Assert.IsTrue(resList.Success && resList.Result.Count == 1);
        }
        #endregion
    }
}
