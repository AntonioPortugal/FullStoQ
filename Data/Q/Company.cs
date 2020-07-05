using Data.Base;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Data.Queues
{
    public class Company : NamedEntity
    {
        private int _vatNumber;

        [Required]
        public int VatNumber
        {
            get => _vatNumber;
            set
            {
                _vatNumber = value;
                RegisterChange();
            }
        }

        public virtual ICollection<Establishment> Establishments { get; set; }

        public Company(string name, int vatNumber) : base(name)
        {
            VatNumber = vatNumber;
        }

        public Company(Guid id, DateTime createdAt, DateTime updatedAt, bool isDeleted, string name, 
            int vatNumber) : base(id, createdAt, updatedAt, isDeleted, name)
        {
            VatNumber = vatNumber;
        }
    }
}
