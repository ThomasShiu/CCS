using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
/*
 機台管理
 TABLE:CS_MACHINE
     
 */
namespace CCS.Areas.Manufact.Controllers
{
    public class MAN12Controller : Controller
    {
        // GET: Manufact/MAN12
        public ActionResult Index()
        {
            return View();
        }
    }
}