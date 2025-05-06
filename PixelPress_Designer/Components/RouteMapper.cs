using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DotNetNuke.Web.Api;
using System.Diagnostics;

namespace PixelPress_DesignerPixelPress_Designer.Components
{
    public class RouteMapper : IServiceRouteMapper
    {
        public void RegisterRoutes(IMapRoute mapRouteManager)
        {
            mapRouteManager.MapHttpRoute(
                moduleFolderName: "PixelPress_Designer",
                routeName: "default",
                url: "{controller}/{action}",
                //defaults: new { action = "GetRandomNumber" },
                namespaces: new[] { "PixelPress_DesignerPixelPress_Designer.Controllers" }
            );
        }
    }
}
