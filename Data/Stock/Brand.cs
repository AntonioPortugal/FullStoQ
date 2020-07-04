using Data.Base;
using System;
using System.Collections.Generic;

namespace Data.Stock
{
    public class Brand : NamedEntity
    {
        public virtual ICollection<EssentialGood> EssentialGoods { get; set; }

        public Brand(string name) : base(name)
        {

        }

        public Brand(Guid id, DateTime createdAt, DateTime updatedAt, bool isDeleted, string name) : base(id, createdAt, updatedAt, isDeleted, name)
        {

        }

    }

}
