using Recodme.RD.FullStoQ.Data.Base;
using Recodme.RD.FullStoQ.Data.Commercial;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Recodme.RD.FullStoQ.Data.Q
{
    public class StoreQueue : NamedEntity
    {
        private int _quantity;

        [Required]
        public int Quantity
        {
            get => _quantity;

            set
            {
                _quantity = value;
                RegisterChange();

            }

        }

        private bool _isUpdated;

        [Required]
        public bool IsUpdated
        {
            get => _isUpdated;

            set
            {
                _isUpdated = value;
                RegisterChange();

            }

        }

        [ForeignKey("Establishment")]
        public Guid EstablishmentId { get; set; }
        public virtual Establishment Establishment { get; set; }

        public StoreQueue(string name, int quantity, bool isUpdated) : base(name)
        {
            Quantity = quantity;
            IsUpdated = isUpdated;

        }

        public StoreQueue(Guid id, DateTime createdAt, DateTime updatedAt, bool isDeleted, string name, int quantity, bool isUpdated) : base(id, createdAt, updatedAt, isDeleted, name)
        {
            Quantity = quantity;
            IsUpdated = isUpdated;

        }

    }

}
