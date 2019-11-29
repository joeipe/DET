using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DET.Web.Controllers
{
    public abstract class ApiController : ControllerBase
    {
        protected new ActionResult Response(object result = null)
        {
            return Ok(result);
        }

        protected new ActionResult Response(string link, object result = null)
        {
            return Created(link, result);
        }

        protected ActionResult ResponseNotFound()
        {
            return NotFound();
        }
    }
}
