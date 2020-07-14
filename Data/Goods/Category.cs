using Recodme.RD.FullStoQ.Data.Base;
using System;
using System.Collections.Generic;

namespace Recodme.RD.FullStoQ.Data.Goods
{
    public class Category : NamedEntity
    {
        public virtual ICollection<EssentialGood> EssentialGoods { get; set; }

        public Category(string name) : base(name)
        {
        }

        public Category(Guid id, DateTime createdAt, DateTime updatedAt, bool isDeleted, string name)
            : base(id, createdAt, updatedAt, isDeleted, name)
        {
        }
    }
}
