using System;
using System.Linq;
using System.Web.Mvc;
using PixelPress_DesignerPixelPress_Designer.Components;
using PixelPress_DesignerPixelPress_Designer.Models;
using DotNetNuke.Web.Mvc.Framework.Controllers;
using DotNetNuke.Web.Mvc.Framework.ActionFilters;
using DotNetNuke.Entities.Users;
using DotNetNuke.Framework.JavaScriptLibraries;
using DotNetNuke.Framework;
using DotNetNuke.UI.Utilities;
using DotNetNuke.Web.Api;
using Newtonsoft.Json;
using DotNetNuke.Security;

namespace PixelPress_DesignerPixelPress_Designer.Controllers
{
    [DnnHandleError]
    public class TestController : DnnApiController
    {
        [AllowAnonymous]
        [System.Web.Http.HttpGet]
        [DotNetNuke.Web.Api.DnnAuthorize]
        [DotNetNuke.Web.Api.DnnModuleAuthorize(AccessLevel = SecurityAccessLevel.Anonymous)]

        public string Test()
        {
            return "Teszt naccerü sztring";
        }

        //public ActionResult Test()
        //{
        //    return Content("Teszt naccerü");
        //}
        
        //public JsonResult Test()
        //{
        //    return Json("Teszt sikeres", JsonRequestBehavior.AllowGet);
        //    //return Content("Teszt sikeres!");
        //}
    }
}