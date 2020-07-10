using Microsoft.VisualStudio.TestTools.UnitTesting;
using Recodme.RD.FullStoQ.Business.Commercial;
using Recodme.RD.FullStoQ.Data.Commercial;

namespace FullStoQTest
{
    [TestClass]
    public class CompanyTest
    {
        [TestMethod]
        public void TestCreateCompany()
        {
            var obj = new CompanyBusinessObject();
            var com = new Company("Sonae", 12345);
            var res = obj.Create(com);
            Assert.IsTrue(res.Success);
        }


        [TestMethod]
        public void TestReadCompany()
        {
            var obj = new CompanyBusinessObject();
            var com = new Company("Sonae", 12345);
            obj.Create(com);

            var result = obj.Read(com.Id);


            Assert.IsTrue(result.Success);
        }


        [TestMethod]
        public void TestDeleteCompany()
        {
            var obj = new CompanyBusinessObject();
            var com = new Company("Sonae", 12345);
            obj.Create(com);

            var result = obj.Delete(com.Id);


            Assert.IsTrue(result.Success);
        }


        [TestMethod]
        public void TestUpdateCompany()
        {
            var obj = new CompanyBusinessObject();
            var com = new Company("Sonae", 12345);
            obj.Create(com);

            var result = obj.Update(com);

            Assert.IsTrue(result.Success);
        }


        [TestMethod]
        public void TestListCompany()
        {
            var bo = new CompanyBusinessObject();

            var com1 = new Company("Sonae", 12345);
            bo.Create(com1);

            var com2 = new Company("Sonic", 54321);
            bo.Create(com2);

            var com3 = new Company("Mário", 32451);
            bo.Create(com3);

            var result = bo.List();

            Assert.IsTrue(result.Success);
        }

    }
}
