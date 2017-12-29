using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http;

namespace SelfHost.ConsoleServer.Controllers
{
    public class ProductController :ApiController
    {
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value1", "value3" };
        }
    }
}
