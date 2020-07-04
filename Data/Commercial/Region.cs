using Recodme.RD.FullStoQ.Data.Base;
using System;
using System.Collections.Generic;

namespace Recodme.RD.FullStoQ.Data.Commercial
{
    public class Region : NamedEntity
    {
        public virtual ICollection<Establishment> Establishments { get; set; }

        public Region(string name) : base(name)
        {

        }

        public Region(Guid id, DateTime createdAt, DateTime updatedAt, bool isDeleted, string name) : base(id, createdAt, updatedAt, isDeleted, name)
        {

        }
    }
}
