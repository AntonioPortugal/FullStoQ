using Data.Base;
using System;
using System.Collections.Generic;

namespace Data.Stock
{
    public class Type : NamedEntity
    {
        public virtual ICollection<EssentialGood> EssentialGoods { get; set; }

        public Type(string name) : base(name)
        {

        }

        public Type(Guid id, DateTime createdAt, DateTime updatedAt, bool isDeleted, string name) : base(id, createdAt, updatedAt, isDeleted, name)
        {

        }

    }

}
