using Microsoft.AspNetCore.Mvc;
using Recodme.RD.FullStoQ.Business.Commercial;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApi.Models.CommercialViewModel;

namespace WebApi.Controllers.CommercialControllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RegionController : BaseController
    {
        private RegionBusinessObject _bo = new RegionBusinessObject();

        [HttpPost]
        public ActionResult Create([FromBody]RegionViewModel vm)
        {
            var comp = vm.ToRegion();
            var res = _bo.Create(comp);
            return (res.Success ? Ok() : InternalServerError());
        }

        [HttpGet("{id}")]
        public ActionResult<RegionViewModel> Get(Guid id)
        {
            var res = _bo.Read(id);
            if (res.Success)
            {
                if (res.Result == null) return NotFound();
                var vm = RegionViewModel.Parse(res.Result);
                return vm;
            }
            else return InternalServerError();
        }

        [HttpGet]
        public ActionResult<List<RegionViewModel>> List()
        {
            var res = _bo.List();
            if (!res.Success) return InternalServerError();
            var list = new List<RegionViewModel>();
            foreach (var item in res.Result)
            {
                list.Add(RegionViewModel.Parse(item));
            }
            return list;
        }

        [HttpPut]
        public ActionResult Update([FromBody]RegionViewModel comp)
        {
            var currentResult = _bo.Read(comp.Id);
            if (!currentResult.Success) return InternalServerError();
            var current = currentResult.Result;
            if (current == null) return NotFound();

            if (current.Name == comp.Name) return NotModified();

            if (current.Name != comp.Name) current.Name = comp.Name;

            var updateResult = _bo.Update(current);
            if (!updateResult.Success) return InternalServerError();
            return Ok();
        }

        [HttpDelete("{id}")]
        public ActionResult Delete(Guid id)
        {
            var result = _bo.Delete(id);
            if (result.Success) return Ok();
            return InternalServerError();

        }
    }
}
