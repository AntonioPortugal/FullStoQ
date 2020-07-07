using Recodme.RD.FullStoQ.Data.Q;
using System;

namespace WebApi.Models.QModelViews
{
    public class StoreQueueViewModel
    {
        public Guid Id { get; set; }
        public int Quantity { get; set; }
        public bool IsUpdated { get; set; }

        public StoreQueue ToStoreQueue()
        {
            return new StoreQueue(Id, DateTime.UtcNow, DateTime.UtcNow, false, Quantity, IsUpdated);
        }

        public static StoreQueueViewModel Parse(StoreQueue StoreQueue)
        {
            return new StoreQueueViewModel()
            {
                Id = StoreQueue.Id,
                Quantity = StoreQueue.Quantity,
                IsUpdated = StoreQueue.IsUpdated,

            };

        }

    }

}
