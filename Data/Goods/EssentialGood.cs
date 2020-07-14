using Recodme.RD.FullStoQ.Data.Commercial;
using Recodme.RD.FullStoQ.Data.Base;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Recodme.RD.FullStoQ.Data.Goods
{
    public class EssentialGood : NamedEntity
    {
        private bool _isReserved;

        [Required]
        public bool IsReserved
        {
            get => _isReserved;
            set
            {
                _isReserved = value;
                RegisterChange();
            }

        }
        private string _barCode;

        [Required]
        public string BarCode
        {
            get => _barCode;
            set
            {
                _barCode = value;
                RegisterChange();
            }
        }

        private double _price;

        [Required]
        public double Price
        {
            get => _price;
            set
            {
                _price = value;
                RegisterChange();
            }
        }

        private double _weight;

        [Required]
        public double Weight
        {
            get => _weight;
            set
            {
                _weight = value;
                RegisterChange();
            }
        }

        [ForeignKey("Brand")]
        public Guid BrandId { get; set; }
        public virtual Brand Brand { get; set; }

        [ForeignKey("Type")]
        public Guid TypeId { get; set; }
        public virtual Type Type { get; set; }

        [ForeignKey("ShoppingBasket")]
        public Guid ShoppingBasketId { get; set; }
        public virtual ShoppingBasket ShoppingBasket { get; set; }

        [ForeignKey("Establishment")]
        public Guid EstablishmentId { get; set; }
        public virtual Establishment Establishment { get; set; }

        public EssentialGood(string name, bool isReserved, string barCode, double price, double weight)
            : base(name)
        {
            IsReserved = isReserved;
            BarCode = barCode;
            Price = price;
            Weight = weight;
        }

        public EssentialGood(Guid id, DateTime createdAt, DateTime ReservedAt, bool isDeleted, 
            string name, bool isReserved, string barCode, double price, double weight) 
            : base(id, createdAt, ReservedAt, isDeleted, name)
        {
            IsReserved = isReserved;
            BarCode = barCode;
            Price = price;
            Weight = weight;
        }
    }
}
