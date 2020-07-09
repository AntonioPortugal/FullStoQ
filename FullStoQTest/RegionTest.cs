using Microsoft.VisualStudio.TestTools.UnitTesting;
using Recodme.RD.FullStoQ.Business.Commercial;
using Recodme.RD.FullStoQ.Data.Commercial;

namespace FullStoQTest
{
    [TestClass]
    public class RegionTest
    {
        [TestMethod]
        public void TestCreateRegion()
        {
            var obj = new RegionBusinessObject();
            var reg = new Region("Continental");
            var resul = obj.Create(reg);

            Assert.IsTrue(resul.Success);

        }
    }
}
