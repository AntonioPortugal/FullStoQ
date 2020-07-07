using Recodme.RD.FullStoQ.Data.Commercial;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApi.Models.CommercialViewModel
{
    public class RegionViewModel
    {
        public Guid Id { get; set; }
        public string Name { get; set; }

        public Region ToRegion()
        {
            return new Region(Id, DateTime.UtcNow, DateTime.UtcNow, false, Name);
        }

        public static RegionViewModel Parse(Region region)
        {
            return new RegionViewModel()
            {
                Id = region.Id,
                Name = region.Name
            };
        }
    }
}
