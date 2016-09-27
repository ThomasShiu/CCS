using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CCS.Controllers
{
    public class SysExceptionController : Controller
    {
        // GET: SysException
        public ActionResult Error()
        {
            BaseException ex = new BaseException();
            return View(ex);
        }
    }
}