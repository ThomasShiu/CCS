using CCS.IBLL;
using CCS.Models;
using CCS.Models.SAL;
using Microsoft.Practices.Unity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CCS.Controllers
{
    public class HomeController : Controller
    {

        

        [Dependency]
        public Ics_sysmoduleBLL homeBLL { get; set; }
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Portal()
        {
            return View();
        }


        /// <summary>
        /// 獲取導航選單
        /// </summary>
        /// <param name="id">所屬</param>
        /// <returns>树</returns>
        public JsonResult GetTree(string id)
        {

            List<CS_SYSMODULE> menus = homeBLL.GetMenuByPersonId(id);
            var jsonData = (
                    from m in menus
                    select new
                    {
                        id = m.Id,
                        text = m.Name,
                        value = m.Url,
                        showcheck = false,
                        complete = false,
                        isexpand = false,
                        checkstate = 0,
                        hasChildren = m.IsLast ? false : true,
                        Icon = m.Iconic
                    }
                ).ToArray();
            return Json(jsonData, JsonRequestBehavior.AllowGet);

        }


        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}