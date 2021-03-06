﻿using Recodme.RD.FullStoQ.Data.Base;
using Recodme.RD.FullStoQ.Data.Commercial;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Recodme.RD.FullStoQ.Data.Q
{
    public class StoreQueue : Entity
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

        [ForeignKey("Establishment")]
        public Guid EstablishmentId { get; set; }
        public virtual Establishment Establishment { get; set; }

        public StoreQueue(int quantity, Guid establishmentId) : base()
        {
            Quantity = quantity;
            EstablishmentId = establishmentId;

        }

        public StoreQueue(Guid id, DateTime createdAt, DateTime updatedAt, bool isDeleted, int quantity, Guid establishmentId) : base
            (id, createdAt, updatedAt, isDeleted)
        {
            Quantity = quantity;
            EstablishmentId = establishmentId;

        }
    }

}
