using Microsoft.VisualStudio.TestTools.UnitTesting;
using Recodme.RD.FullStoQ.Business.Commercial;
using Recodme.RD.FullStoQ.Data.Commercial;
using Recodme.RD.FullStoQ.DataAccess.Seeders;
using System.Linq;

namespace FullStoQTest
{
    [TestClass]
    public class RegionTest
    {
        [TestMethod]
        public void TestCreateAndListRegions()
        {
            ContextSeeder.SeedCountries();
            var bo = new RegionBusinessObject();
            var reg = new Region("Lisboa");
            var resCreate = bo.Create(reg);
            var resGet = bo.Read(reg.Id);
            Assert.IsTrue(resCreate.Success && resGet.Success && resGet.Result != null);
        }

        [TestMethod]
        public void TestListRegions()
        {
            ContextSeeder.SeedCountries();
            var bo = new RegionBusinessObject();
            var resList = bo.List();
            Assert.IsTrue(resList.Success && resList.Result.Count == 1);
        }
        
        [TestMethod]
        public void TestUpdateRegions()
        {
            ContextSeeder.SeedCountries();
            var bo = new RegionBusinessObject();
            var resList = bo.List();
            var item = resList.Result.FirstOrDefault();
            item.Name = "another";
            var resUpdate = bo.Update(item);
            var resNotList = bo.List().Result.Where(x => !x.IsDeleted);
            Assert.IsTrue(resUpdate.Success && resNotList.First().Name == "another");
        }

        [TestMethod]
        public void TestDeleteRegions()
        {
            ContextSeeder.SeedCountries();
            var bo = new RegionBusinessObject();
            var resList = bo.List();
            var resDelete = bo.Delete(resList.Result.First().Id);
            var resNotList = bo.List().Result.Where(x => !x.IsDeleted).ToList();
            Assert.IsTrue(resDelete.Success && resNotList.Count == 0);
        }

    }
}
