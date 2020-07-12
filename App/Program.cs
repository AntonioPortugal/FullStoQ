using Recodme.RD.FullStoQ.DataAccess.Contexts;

namespace App
{
    class Program
    {
        static void Main(string[] args)
        {
            var dao = new Context();
            dao.Database.EnsureCreated();
            //dao.Database.EnsureDeleted();

            //var obj = new StoreQueueBusinessObject();
            //var x = new StoreQueue(234, true);
            //var resul = obj.Create(x);


        }
    }
}
