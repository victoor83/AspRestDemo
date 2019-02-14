using System.Net;
using System.Web;
using System.Web.Http;

namespace RestDemo.Controllers
{
    public class ClientController : ApiController
    {

        [HttpGet]
        public string[] GetClientData()
        {
            var data = new string[3];
            data[0] = "Your host address: " + HttpContext.Current.Request.UserHostAddress;
            data[1] = "Your host name: "+ HttpContext.Current.Request.UserHostName;
            data[2] = HttpContext.Current.Request.UserHostAddress;
            return data;
        }
    }
}
