﻿using Microsoft.VisualStudio.TestTools.UnitTesting;
using Recodme.RD.FullStoQ.Business.Goods;
using Recodme.RD.FullStoQ.Data.Goods;
using Recodme.RD.FullStoQ.DataAccess.Seeders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Recodme.RD.FullStoQ.FullStoQTest.Goods
{
    [TestClass]
    public class CategoryTest
    {
        [TestMethod]
        public void TestCreateAndReadCategorys()
        {
            ContextSeeder.Seed();
            var bo = new CategoryBusinessObject();
            var reg = new Category("Alcoholic Beverages");
            var resCreate = bo.Create(reg);
            var resGet = bo.Read(reg.Id);
            Assert.IsTrue(resCreate.Success && resGet.Success && resGet.Result != null);
        }

        [TestMethod]
        public void TestCreateAndReadCategoryAsync()
        {
            ContextSeeder.Seed();
            var bo = new CategoryBusinessObject();
            var reg = new Category("Alcoholic Beverages");
            var resCreate = bo.CreateAsync(reg).Result;
            var resGet = bo.ReadAsync(reg.Id).Result;
            Assert.IsTrue(resCreate.Success && resGet.Success && resGet.Result != null);
        }

        [TestMethod]
        public void TestListCategorys()
        {
            ContextSeeder.Seed();
            var bo = new CategoryBusinessObject();
            var resList = bo.List();
            Assert.IsTrue(resList.Success && resList.Result.Count == 1);
        }

        [TestMethod]
        public void TestListCategoryAsync()
        {
            ContextSeeder.Seed();
            var bo = new CategoryBusinessObject();
            var resList = bo.ListAsync().Result;
            Assert.IsTrue(resList.Success && resList.Result.Count == 1);
        }

        [TestMethod]
        public void TestUpdateCategorys()
        {
            ContextSeeder.Seed();
            var bo = new CategoryBusinessObject();
            var resList = bo.List();
            var item = resList.Result.FirstOrDefault();
            item.Name = "It's just wine";
            var resUpdate = bo.Update(item);
            var resNotList = bo.ListNotDeleted().Result;
            Assert.IsTrue(resUpdate.Success && resNotList.First().Name == "It's just wine");
        }

        [TestMethod]
        public void TestUpdateCategorynAsync()
        {
            ContextSeeder.Seed();
            var bo = new CategoryBusinessObject();
            var resList = bo.ListAsync().Result;
            var item = resList.Result.FirstOrDefault();
            item.Name = "It's just wine";
            var resUpdate = bo.UpdateAsync(item).Result;
            resList = bo.ListNotDeletedAsync().Result;
            Assert.IsTrue(resList.Success && resUpdate.Success && resList.Result.First().Name == "It's just wine");
        }

        [TestMethod]
        public void TestDeleteCategorys()
        {
            ContextSeeder.Seed();
            var bo = new CategoryBusinessObject();
            var resList = bo.List();
            var resDelete = bo.Delete(resList.Result.First().Id);
            var resNotList = bo.List().Result.Where(x => !x.IsDeleted).ToList();
            Assert.IsTrue(resDelete.Success && resNotList.Count == 0);
        }

        [TestMethod]
        public void TestDeleteCategoryAsync()
        {
            ContextSeeder.Seed();
            var bo = new CategoryBusinessObject();
            var resList = bo.ListAsync().Result;
            var resDelete = bo.DeleteAsync(resList.Result.First().Id).Result;
            resList = bo.ListNotDeletedAsync().Result;
            Assert.IsTrue(resDelete.Success && resList.Success && resList.Result.Count == 0);
        }
    }
}
