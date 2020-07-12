using Microsoft.VisualStudio.TestTools.UnitTesting;
using Recodme.RD.FullStoQ.Business.Commercial;
using Recodme.RD.FullStoQ.Data.Commercial;
using Recodme.RD.FullStoQ.DataAccess.Seeders;
using System.Linq;

namespace Recodme.RD.FullStoQ.FullStoQTest
{
    [TestClass]
    public class CompanyTest
    {
        #region Create
        [TestMethod]
        public void TestCreateCompany()
        {
            ContextSeeder.Seed();
            var bo = new CompanyBusinessObject();
            var com = new Company("Sonae", 12345);
            var res = bo.Create(com);
            Assert.IsTrue(res.Success);
        }
        #endregion

        #region Read
        [TestMethod]
        public void TestReadCompany()
        {
            ContextSeeder.Seed();
            var obj = new CompanyBusinessObject();
            var com = new Company("Sonae", 12345);
            obj.Create(com);
            var resGet = obj.Read(com.Id);
            Assert.IsTrue(resGet.Success && resGet.Result != null);
        }
        #endregion

        #region Update
        [TestMethod]
        public void TestUpdateCompany()
        {
            ContextSeeder.Seed();
            var bo = new CompanyBusinessObject();
            var com = new Company("Sonae", 12345);
            var resList = bo.List();
            var item = resList.Result.FirstOrDefault();
            item.Name = "Jerónimo Martins";
            var resUpdate = bo.Update(item);
            var resNotList = bo.List().Result.Where(x => !x.IsDeleted);
            Assert.IsTrue(resUpdate.Success && resNotList.First().Name == "Jerónimo Martins");
        }
        #endregion

        #region Delete
        [TestMethod]
        public void TestDeleteCompany()
        {
            ContextSeeder.Seed();
            var bo = new CompanyBusinessObject();
            var com = new Company("Sonae", 12345);
            bo.Create(com);

            var result = bo.Delete(com.Id);
            Assert.IsTrue(result.Success);
        }
        #endregion        

        #region List
        [TestMethod]
        public void TestListCompany()
        {
            ContextSeeder.Seed();
            var bo = new CompanyBusinessObject();
            var resList = bo.List();
            Assert.IsTrue(resList.Success && resList.Result.Count == 1);
        }
        #endregion

        #region Assync 
        [TestMethod]
        public void TestDeleteEstablishmentAsync()
        {
            ContextSeeder.Seed();
            var bo = new CompanyBusinessObject();
            var resList = bo.ListAsync().Result;
            var resDelete = bo.DeleteAsync(resList.Result.First().Id).Result;
            resList = bo.ListNotDeletedAsync().Result;
            Assert.IsTrue(resDelete.Success && resList.Success && resList.Result.Count == 0);
        }
        #endregion
    }
}
