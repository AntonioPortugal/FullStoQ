using Recodme.RD.FullStoQ.Data.Goods;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApi.Models.GoodsViewModel
{
    public class CategoryViewModel
    {
        public Guid Id { get; set; }
        public string Name { get; set; }

        public Category ToCategory()
        {
            return new Category(Id, DateTime.UtcNow, DateTime.UtcNow, false, Name);
        }

        public static CategoryViewModel Parse(Category Category)
        {
            return new CategoryViewModel()
            {
                Id = Category.Id,
                Name = Category.Name,
            };

        }
    }
}
