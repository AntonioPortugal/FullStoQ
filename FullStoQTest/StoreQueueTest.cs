using Microsoft.VisualStudio.TestTools.UnitTesting;
using Recodme.RD.FullStoQ.Business.Q;
using Recodme.RD.FullStoQ.Data.Q;

namespace FullStoQTest
{
    [TestClass]
    public class StoreQueueTest
    {
        [TestMethod]
        public void TestCreateStoreQueue()
        {
            var obj = new StoreQueueBusinessObject();
            var sq = new StoreQueue(2);
            var res = obj.Create(sq);
            Assert.IsTrue(res.Success);
        }
    }
}
