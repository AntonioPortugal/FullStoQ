using Microsoft.AspNetCore.Mvc;
using Recodme.RD.FullStoQ.Business.Commercial;
using System;
using System.Collections.Generic;
using WebApi.Models.CommercialViewModel;

namespace WebApi.Controllers.CommercialControllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CompanyController : BaseController
    {
        private CompanyBusinessObject _bo = new CompanyBusinessObject();

        [HttpPost]
        public ActionResult Create([FromBody]CompanyViewModel vm)
        {
            var comp = vm.ToCompany();
            var res = _bo.Create(comp);
            return (res.Success ? Ok() : InternalServerError());
        }

        [HttpGet("{id}")]
        public ActionResult<CompanyViewModel> Get(Guid id)
        {
            var res = _bo.Read(id);
            if (res.Success)
            {
                if (res.Result == null) return NotFound();
                var vm = CompanyViewModel.Parse(res.Result);
                return vm;
            }
            else return InternalServerError();
        }

        [HttpGet]
        public ActionResult<List<CompanyViewModel>> List()
        {
            var res = _bo.List();
            if (!res.Success) return InternalServerError();
            var list = new List<CompanyViewModel>();
            foreach (var item in res.Result)
            {
                list.Add(CompanyViewModel.Parse(item));
            }
            return list;
        }

        [HttpPut]
        public ActionResult Update([FromBody]CompanyViewModel comp)
        {
            var currentResult = _bo.Read(comp.Id);
            if (!currentResult.Success) return InternalServerError();
            var current = currentResult.Result;
            if (current == null) return NotFound();

            if (current.Name == comp.Name && current.VatNumber == comp.VatNumber) return NotModified();

            if (current.Name != comp.Name) current.Name = comp.Name;
            if (current.VatNumber != comp.VatNumber) current.VatNumber = comp.VatNumber;

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