using Recodme.RD.FullStoQ.Data.Commercial;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApi.Models.CommercialViewModel
{
    public class CompanyViewModel
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public long VatNumber { get; set; }

        public Company ToCompany()
        {
            return new Company(Id, DateTime.UtcNow, DateTime.UtcNow, false, Name, VatNumber);
        }

        public static CompanyViewModel Parse(Company Company)
        {
            return new CompanyViewModel()
            {
                Id = Company.Id,
                Name = Company.Name,
                VatNumber = Company.VatNumber,

            };

        }
    }
}
