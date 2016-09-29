using CCS.Common;
using CCS.Models.SYS;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Mvc;

namespace CCS.App_Start
{
    public class BaseController : Controller
    {
        /// <summary>
        /// 獲取當前頁或操作存取權限
        /// </summary>
        /// <returns>許可權列表</returns>
        public List<permModel> GetPermission()
        {
            string filePath = HttpContext.Request.FilePath;

            List<permModel> perm = (List<permModel>)Session[filePath];
            return perm;
        }



        /// <summary>
        /// 獲取當前用戶Id
        /// </summary>
        /// <returns></returns>
        public string GetUserId()
        {
            if (Session["Account"] != null)
            {
                AccountModel info = (AccountModel)Session["Account"];
                return info.Id;
            }
            else
            {

                return "";
            }
        }
        /// <summary>
        /// 獲取當前用戶Name
        /// </summary>
        /// <returns></returns>
        public string GetUserTrueName()
        {
            if (Session["Account"] != null)
            {
                AccountModel info = (AccountModel)Session["Account"];
                return info.TrueName;
            }
            else
            {
                return "";
            }
        }
        /// <summary>
        /// 獲取當前使用者資訊
        /// </summary>
        /// <returns>使用者資訊</returns>
        public AccountModel GetAccount()
        {
            if (Session["Account"] != null)
            {
                return (AccountModel)Session["Account"];
            }
            return null;
        }


        protected override JsonResult Json(object data, string contentType, Encoding contentEncoding, JsonRequestBehavior behavior)
        {
            return new ToJsonResult
            {
                Data = data,
                ContentEncoding = contentEncoding,
                ContentType = contentType,
                JsonRequestBehavior = behavior,
                FormateStr = "yyyy-MM-dd HH:mm:ss"
            };
        }
        /// <summary>
        /// 返回JsonResult.24         /// </summary>
        /// <param name="data">數據</param>
        /// <param name="behavior">行為</param>
        /// <param name="format">json中dateTime類型的格式</param>
        /// <returns>Json</returns>
        protected JsonResult MyJson(object data, JsonRequestBehavior behavior, string format)
        {
            return new ToJsonResult
            {
                Data = data,
                JsonRequestBehavior = behavior,
                FormateStr = format
            };
        }
        /// <summary>
        /// 返回JsonResult42         /// </summary>
        /// <param name="data">數據</param>
        /// <param name="format">資料格式</param>
        /// <returns>Json</returns>
        protected JsonResult MyJson(object data, string format)
        {
            return new ToJsonResult
            {
                Data = data,
                FormateStr = format
            };
        }
        /// <summary>
        /// 檢查SQL語句合法性
        /// </summary>
        /// <param name="sql"></param>
        /// <returns></returns>
        public bool ValidateSQL(string sql, ref string msg)
        {
            if (sql.ToLower().IndexOf("delete") > 0)
            {
                msg = "查詢參數中含有非法語句 DELETE";
                return false;
            }
            if (sql.ToLower().IndexOf("update") > 0)
            {
                msg = "查詢參數中含有非法語句 UPDATE";
                return false;
            }

            if (sql.ToLower().IndexOf("insert") > 0)
            {
                msg = "查詢參數中含有非法語句 INSERT";
                return false;
            }
            return true;
        }

    }


}