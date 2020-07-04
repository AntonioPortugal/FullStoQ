using RECODME.RD.Jade.Data.Base;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Data.Queues
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

        public virtual ICollection<Establishment> Establishments { get; set; }

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
