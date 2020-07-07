using Microsoft.AspNetCore.Identity;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Recodme.RD.FullStoQ.Data.Person

{
    public class Account : IdentityUser<Guid>
    {
        [Key]
        public override Guid Id { get; set; }

        [ForeignKey("Profile")]
        public Guid ProfileId { get; set; }
        public virtual Profile Profile { get; set; }

        public Account(Guid profileId)
        {
            Id = Guid.NewGuid();
            ProfileId = profileId;
        }

    }
}
