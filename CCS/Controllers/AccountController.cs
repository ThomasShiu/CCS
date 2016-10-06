using CCS.App_Start;
using CCS.Common;
using CCS.Core;
using CCS.IBLL;
using CCS.Models;
using CCS.Models.SYS;
using Microsoft.Owin.Security;
using Microsoft.Practices.Unity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CCS.Controllers
{
    public class AccountController : Controller
    {
        [Dependency]
        public IAccountBLL accountBLL { get; set; }
        // GET: Account
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public JsonResult Login(string UserName, string Password, string Code)
        {
            if (Session["Code"] == null)
                return Json(JsonHandler.CreateMessage(0, "請重新刷新驗證碼"), JsonRequestBehavior.AllowGet);

            if (Session["Code"].ToString().ToLower() != Code.ToLower())
                return Json(JsonHandler.CreateMessage(0, "驗證碼錯誤"), JsonRequestBehavior.AllowGet);

            CS_SYSUSER user = accountBLL.Login(UserName, ValueConvert.MD5(Password));

            if (user == null)
            {
                return Json(JsonHandler.CreateMessage(0, "用戶名或密碼錯誤"), JsonRequestBehavior.AllowGet);
            }
            else if (!Convert.ToBoolean(user.State))//被禁用
            {
                return Json(JsonHandler.CreateMessage(0, "帳戶被系統禁用"), JsonRequestBehavior.AllowGet);
            }

            AccountModel account = new AccountModel();
            account.Id = user.Id;
            account.TrueName = user.TrueName;
            Session["Account"] = account;

            LogHandler.WriteServiceLog("虛擬用戶", "Id:" + account.Id + ",Name:" + account.TrueName, "成功", "登入", "範例程序");
            return Json(JsonHandler.CreateMessage(1, ""), JsonRequestBehavior.AllowGet);

        }

        public ActionResult Logout()
        {

            //清除所有的 session
            Session.RemoveAll();
            return RedirectToAction("Login", "Account",new { Areas=""});
        }
    }
}