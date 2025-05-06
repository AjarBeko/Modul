/*
' Copyright (c) 2025 ITElite
'  All rights reserved.
' 
' THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR IMPLIED, INCLUDING BUT NOT LIMITED
' TO THE WARRANTIES OF MERCHANTABILITY, FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL
' THE AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER LIABILITY, WHETHER IN AN ACTION OF
' CONTRACT, TORT OR OTHERWISE, ARISING FROM, OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER
' DEALINGS IN THE SOFTWARE.
' 
*/

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
using Hotcakes.CommerceDTO.v1;
using Hotcakes.CommerceDTO.v1.Client;
using Hotcakes.CommerceDTO.v1.Contacts;
using Hotcakes.CommerceDTO.v1.Orders;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Data;
using DotNetNuke.Web.Mvc.Helpers;
using Hotcakes.CommerceDTO.v1.Catalog;
using System.Web.Http.Results;
using System.Web.Helpers;
using Hotcakes.Web;
using DotNetNuke.Common.Utilities;
using System.Data.SqlTypes;
using Hotcakes.Commerce.Dnn;

namespace PixelPress_DesignerPixelPress_Designer.Controllers
{
    [DnnHandleError]
    public class ItemController : DnnController
    {

        public ActionResult Delete(int itemId)
        {
            ItemManager.Instance.DeleteItem(itemId, ModuleContext.ModuleId);
            return RedirectToDefaultRoute();
        }

        public ActionResult Edit(int itemId = -1)
        {
            DotNetNuke.Framework.JavaScriptLibraries.JavaScript.RequestRegistration(CommonJs.DnnPlugins);

            var userlist = UserController.GetUsers(PortalSettings.PortalId);
            var users = from user in userlist.Cast<UserInfo>().ToList()
                        select new SelectListItem { Text = user.DisplayName, Value = user.UserID.ToString() };

            ViewBag.Users = users;

            var item = (itemId == -1)
                 ? new Item { ModuleId = ModuleContext.ModuleId }
                 : ItemManager.Instance.GetItem(itemId, ModuleContext.ModuleId);

            return View(item); //itt eredetileg az volt hogy View(item)
        }

        [HttpGet]
        [AllowAnonymous]
        public string GetApiKey()
        {
            //string key = "1-d820ce2a-9612-4001-95e5-187fdca8497e"; //saját dnndev.me-s
            string key = "1-35939070-0c15-468a-b98c-8da71a3e96ca"; //rendfejl10000 "fő" api
            return key;
        }

        public string GetProducts()
        {
            //string url = "http://dnndev.me";
            string url = "http://rendfejl10000.northeurope.cloudapp.azure.com:8080/";

            //string key = "1-d820ce2a-9612-4001-95e5-187fdca8497e"; //saját dnndev.me-s
            string key = "1-35939070-0c15-468a-b98c-8da71a3e96ca"; //rendfejl10000 "fő" api

            Api proxy = new Api(url, key);

            ApiResponse<List<ProductDTO>> response = proxy.ProductsFindAll();
            var json = JsonConvert.SerializeObject(response);
            return json;
            //return Json(json, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        [DotNetNuke.Web.Mvc.Framework.ActionFilters.ValidateAntiForgeryToken]
        public ApiResponse<ProductDTO> CreateProduct(string ProductName, string Sku, decimal ListPrice, decimal SitePrice, string LongDescription, bool IsSearchable)
        {
            //string url = "http://dnndev.me";
            string url = "http://rendfejl10000.northeurope.cloudapp.azure.com:8080/";
            
            //string key = "1-d820ce2a-9612-4001-95e5-187fdca8497e"; //saját dnndev.me-s
            string key = "1-35939070-0c15-468a-b98c-8da71a3e96ca"; //rendfejl10000 "fő" api

            Api proxy = new Api(url, key);

            var product = new ProductDTO();
            product.ProductName = ProductName;
            product.Sku = Sku;
            product.ListPrice = ListPrice;
            product.SitePrice = SitePrice;
            product.InventoryMode = ProductInventoryModeDTO.AlwayInStock;
            product.LongDescription = LongDescription;
            product.IsSearchable = IsSearchable;
            ApiResponse<ProductDTO> response = proxy.ProductsCreate(product, null);
            return response;
        }
        [HttpPost]
        [DotNetNuke.Web.Mvc.Framework.ActionFilters.ValidateAntiForgeryToken]
        public ActionResult Edit(Item item)
        {
            if (item.ItemId == -1)
            {
                item.CreatedByUserId = User.UserID;
                item.CreatedOnDate = DateTime.UtcNow;
                item.LastModifiedByUserId = User.UserID;
                item.LastModifiedOnDate = DateTime.UtcNow;

                ItemManager.Instance.CreateItem(item);
            }
            else
            {
                var existingItem = ItemManager.Instance.GetItem(item.ItemId, item.ModuleId);
                existingItem.LastModifiedByUserId = User.UserID;
                existingItem.LastModifiedOnDate = DateTime.UtcNow;
                existingItem.ItemName = item.ItemName;
                existingItem.ItemDescription = item.ItemDescription;
                existingItem.AssignedUserId = item.AssignedUserId;

                ItemManager.Instance.UpdateItem(existingItem);
            }

            return RedirectToDefaultRoute();
        }

        [ModuleAction(ControlKey = "Edit", TitleKey = "AddItem")]
        public ActionResult Index()
        {
            var items = ItemManager.Instance.GetItems(ModuleContext.ModuleId);
            return View(items);
        }
    }
}
