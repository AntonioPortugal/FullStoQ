using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Recodme.RD.FullStoQ.Business.Q;
using WebApi.Models.QModelViews;

namespace WebApi.Controllers.QController
{
    [Route("api/[controller]")]
    [ApiController]
    public class StoreQueueController : BaseController
    {
        private StoreQueueBusinessObject _bo = new StoreQueueBusinessObject();

        [HttpPost]
        public ActionResult Create([FromBody]StoreQueueViewModel vm)
        {
            var rt = vm.ToStoreQueue();
            var res = _bo.Create(rt);
            return (res.Success ? Ok() : InternalServerError());
        }

        [HttpGet("{id}")]
        public ActionResult<StoreQueueViewModel> Get(Guid id)
        {
            var res = _bo.Read(id);
            if (res.Success)
            {
                if (res.Result == null) return NotFound();
                var vm = StoreQueueViewModel.Parse(res.Result);
                return vm;
            }
            else return InternalServerError();
        }

        [HttpGet]
        public ActionResult<List<StoreQueueViewModel>> List()
        {
            var res = _bo.List();
            if (!res.Success) return InternalServerError();
            var list = new List<StoreQueueViewModel>();
            foreach (var item in res.Result)
            {
                list.Add(StoreQueueViewModel.Parse(item));
            }
            return list;
        }

        [HttpPut]
        public ActionResult Update([FromBody]StoreQueueViewModel ds)
        {
            var currentResult = _bo.Read(ds.Id);
            if (!currentResult.Success) return InternalServerError();
            var current = currentResult.Result;
            if (current == null) return NotFound();

            if (current.Quantity == ds.Quantity && current.IsUpdated == ds.IsUpdated) return NotModified();

            if (current.Quantity != ds.Quantity) current.Quantity = ds.Quantity;
            if (current.IsUpdated != ds.IsUpdated) current.IsUpdated = ds.IsUpdated;

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