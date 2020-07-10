using Recodme.RD.FullStoQ.Data.Commercial;
using System;

namespace WebApi.Models.CommercialModelView
{
    public class EstablishmentViewModel
    {
        public string Address { get; set; }
        public string ClosingDays { get; set; }
        public string OpeningHours { get; set; }
        public string ClosingHours { get; set; }
        public Guid Id { get; set; }
        public Guid RegionId { get; set; }
        public Guid CompanyId { get; set; }
        public Guid ReservedQueueId { get; set; }

        public Establishment ToEstablishment()
        {
            return new Establishment(Address, OpeningHours, ClosingHours, ClosingDays, RegionId, CompanyId);
        }

        public static EstablishmentViewModel Parse(Establishment establishment)
        {
            return new EstablishmentViewModel()
            {
                Id = establishment.Id,
                Address = establishment.Address,
                OpeningHours = establishment.OpeningHours,
                ClosingHours = establishment.ClosingHours,
                ClosingDays = establishment.ClosingDays,
                RegionId = establishment.RegionId,
                CompanyId = establishment.CompanyId               
            };
        }
    }
}
