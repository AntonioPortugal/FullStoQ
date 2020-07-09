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
    }
}
