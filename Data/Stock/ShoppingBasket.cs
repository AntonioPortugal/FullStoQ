using Data.Base;
using System;
using System.Collections.Generic;

namespace Data.Stock
{
    public class ShoppingBasket : Entity
    {
        public virtual ICollection<EssentialGood> EssentialGoods { get; set; }

        public ShoppingBasket() : base()
        {

        }

        public ShoppingBasket(Guid id, DateTime createdAt, DateTime updatedAt, bool isDeleted) : base(id, createdAt, updatedAt, isDeleted)
        {

        }

    }

}
