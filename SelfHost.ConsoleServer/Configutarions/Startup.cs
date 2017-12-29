using Microsoft.AspNet.SignalR;
using Microsoft.Owin.Cors;
using Owin;
using SelfHost.ConsoleServer.Configutarions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http;

namespace SelfHost.ConsoleServer
{
    public partial class Startup
    {
        public void AuthConfig(IAppBuilder app)
        {
            HttpConfiguration config = new HttpConfiguration();
            RouteConfig.RegisterRoutes(config);
            app.UseCors(CorsOptions.AllowAll);
            app.Map("/signalr", map =>
            {
                HubConfiguration hcf = new HubConfiguration();
                map.RunSignalR();
            });
        }
    }
}
