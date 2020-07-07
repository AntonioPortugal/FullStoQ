using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Recodme.RD.FullStoQ.Business.Commercial;
using Recodme.RD.FullStoQ.Data.Commercial;
using System;
using System.Collections.Generic;
using WebApi.Models.CommercialModelView;

namespace WebApi.Controllers.QController
{
    [Route("api/[controller]")]
    [ApiController]
    public class EstablishmentController : BaseController
    {

        private EstablishmentBusinessObject _bo = new EstablishmentBusinessObject();

        [Authorize]
        [HttpPost]
        public ActionResult Create([FromBody] EstablishmentViewModel vm)
        {
            var r = new Establishment(vm.Address, vm.OpeningHours, vm.ClosingHours, vm.ClosingDays, vm.RegionId,
                vm.CompanyId, vm.QueueId);

            var res = _bo.Create(r);
            return res.Success ? Ok() : InternalServerError();
        }

        [HttpGet("{id}")]
        public ActionResult<EstablishmentViewModel> Get(Guid id)
        {
            var res = _bo.Read(id);
            if (res.Success)
            {
                if (res.Result == null) return NotFound();
                var vm = EstablishmentViewModel.Parse(res.Result);
                return vm;
            }
            else return InternalServerError();
        }

        [Authorize]
        [HttpGet]
        public ActionResult<List<EstablishmentViewModel>> List()
        {
            var res = _bo.List();
            if (!res.Success) return InternalServerError();
            var list = new List<EstablishmentViewModel>();
            foreach (var establishment in res.Result)
            {
                list.Add(EstablishmentViewModel.Parse(establishment));
            }
            return list;
        }

        [HttpPut]
        public ActionResult Update([FromBody] EstablishmentViewModel vm)
        {
            var currentResult = _bo.Read(vm.Id);
            if (!currentResult.Success) return InternalServerError();
            var current = currentResult.Result;
            if (current == null) return NotFound();

            if (current.Address == vm.Address && current.OpeningHours == vm.OpeningHours &&
                current.ClosingHours == vm.ClosingHours && current.ClosingDays == vm.ClosingDays)
                return NotModified();

            if (current.Address != vm.Address) current.Address = vm.Address;
            if (current.OpeningHours != vm.OpeningHours) current.OpeningHours = vm.OpeningHours;
            if (current.ClosingHours != vm.ClosingHours) current.ClosingHours = vm.ClosingHours;
            if (current.ClosingDays != vm.ClosingDays) current.ClosingDays = vm.ClosingDays;
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