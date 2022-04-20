using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using FreshersManagement.Service;
using Fresher;

namespace FreshersManagement.WebAPI.Controllers
{
    public class ValuesController : ApiController
    {
        private readonly IService service = new FresherService();
        // GET api/values
        public IEnumerable<FresherDetail> Get()
        {
            return service.GetAllFreshers();
        }

        // GET api/values/5
        public FresherDetail Get(int id)
        {
            return service.GetFresher(id);
        }

        // POST api/values
        public IHttpActionResult Post([FromBody] FresherDetail fresher)
        {
            if (1 == service.SaveFresher(fresher))
            {
                return Ok();
            }
            else
            {
                return BadRequest("Invalid data.");
            }
        }

        // PUT api/values/5
        public IHttpActionResult Put([FromBody] FresherDetail fresher)
        {
            if (1 == service.SaveFresher(fresher))
            {
                return Ok();
            }
            else
            {
                return BadRequest("Invalid data.");
            }
        }

        // DELETE api/values/5
        public IHttpActionResult Delete(int id)
        {
            if (1 == service.DeleteFresher(id))
            {
                return Ok();
            }
            else
            {
                return BadRequest("Invalid data.");
            }
        }
    }
}
