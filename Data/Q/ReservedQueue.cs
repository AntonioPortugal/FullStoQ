using Recodme.RD.FullStoQ.Data.Base;
using Recodme.RD.FullStoQ.Data.Commercial;
using Recodme.RD.FullStoQ.Data.Person;
using System;
using System.ComponentModel.DataAnnotations.Schema;
namespace Recodme.RD.FullStoQ.Data.Q
{
    public class ReservedQueue : Entity
    {
        [ForeignKey("Establishment")]
        public Guid EstablishmentId { get; set; }
        public virtual Establishment Establishment { get; set; }

        [ForeignKey("Profile")]
        public Guid ProfileId { get; set; }
        public virtual Profile Profiles { get; set; }

        public ReservedQueue() : base()
        {

        }

        public ReservedQueue(Guid id, DateTime createdAt, DateTime updatedAt, bool isDeleted) : base(id, createdAt, updatedAt, isDeleted)
        {

        }

    }

}
