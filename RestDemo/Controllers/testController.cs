using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace RestDemo.Controllers
{
    public class testController : ApiController
    {
        // GET: api/xxx
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET: api/xxx/5
        public string Get(string ids)
        {
            return "value " + ids;
        }

        // POST: api/xxx
        public void Post([FromBody]string value)
        {
        }

        // PUT: api/xxx/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/xxx/5
        public void Delete(int id)
        {
        }
    }
}
