using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public abstract class BaseController : ControllerBase
    {
        protected StatusCodeResult InternalServerError()
        {
            return StatusCode((int)HttpStatusCode.InternalServerError);
        }

        protected StatusCodeResult NotModified()
        {
            return StatusCode((int)HttpStatusCode.NotModified);
        }

    }

}