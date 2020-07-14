using Recodme.RD.FullStoQ.Data.Base;
using Recodme.RD.FullStoQ.Data.Commercial;
using Recodme.RD.FullStoQ.Data.Person;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace Recodme.RD.FullStoQ.Data.Goods
{
    public class ShoppingBasket : Entity
    {
        public virtual ICollection<EssentialGood> EssentialGoods { get; set; }

        [ForeignKey("Establishment")]
        public Guid EstablishmentId { get; set; }
        public virtual Establishment Establishment { get; set; }

        //[ForeignKey("Profile")]
        //public Guid ProfileId { get; set; }
        //public virtual Profile Profile { get; set; }

        public ShoppingBasket(/*Guid profileId,*/ Guid establishmentId) : base()
        {
            //ProfileId = profileId;
            EstablishmentId = establishmentId;

        }

        public ShoppingBasket(Guid id, DateTime createdAt, DateTime updatedAt, bool isDeleted/*, Guid profileId*/, Guid establishmentId) 
            : base(id, createdAt, updatedAt, isDeleted)
        {
            //ProfileId = profileId;
            EstablishmentId = establishmentId;
        }
    }
}
