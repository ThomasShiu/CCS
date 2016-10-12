using CCS.App_Start;
using CCS.Common;
using CCS.Core;
using CCS.IBLL;
using CCS.Models.SYS;
using Microsoft.Practices.Unity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CCS.Areas.Author.Controllers
{

    public class CSSysModuleController : BaseController
    {
        /// <summary>
        /// 業務層注入
        /// </summary>
        [Dependency]
        public Ics_sysmoduleBLL m_BLL { get; set; }
        [Dependency]
        public Ics_sysmoduleoperateBLL operateBLL { get; set; }
        ValidationErrors errors = new ValidationErrors();

        /// <summary>
        /// 主頁
        /// </summary>
        /// <returns>視圖</returns>
        [SupportFilter]
        public ActionResult Index()
        {
            ViewBag.Perm = GetPermission();
            return View();

        }
        /// <summary>
        /// 獲取列表
        /// </summary>
        /// <param name="pager">分頁</param>
        /// <param name="queryStr">查詢準則</param>
        /// <returns></returns>
        [SupportFilter(ActionName = "Index")]
        [HttpPost]
        public JsonResult GetList(string id)
        {
            if (id == null)
                id = "0";
            List<cs_sysmoduleModel> list = m_BLL.GetList(id);
            var json = from r in list
                       select new cs_sysmoduleModel()
                       {
                           Id = r.Id,
                           Name = r.Name,
                           EnglishName = r.EnglishName,
                           ParentId = r.ParentId,
                           Url = r.Url,
                           Iconic = r.Iconic,
                           Sort = r.Sort,
                           Remark = r.Remark,
                           Enable = r.Enable,
                           CreatePerson = r.CreatePerson,
                           CreateTime = r.CreateTime,
                           IsLast = r.IsLast,
                           state = (m_BLL.GetList(r.Id).Count > 0) ? "closed" : "open"
                       };


            return Json(json);
        }

        [HttpPost]
        [SupportFilter(ActionName = "Index")]
        public JsonResult GetOptListByModule(GridPager pager, string mid)
        {
            pager.rows = 1000;
            pager.page = 1;
            List<cs_sysmoduleopertaeModel> list = operateBLL.GetList(ref pager, mid);
            var json = new
            {
                total = pager.totalRows,
                rows = (from r in list
                        select new cs_sysmoduleopertaeModel()
                        {
                            Id = r.Id,
                            Name = r.Name,
                            KeyCode = r.KeyCode,
                            ModuleId = r.ModuleId,
                            IsValid = r.IsValid,
                            Sort = r.Sort

                        }).ToArray()

            };

            return Json(json);
        }


        #region 創建模組
        [SupportFilter]
        public ActionResult Create(string id)
        {
            ViewBag.Perm = GetPermission();
            cs_sysmoduleModel entity = new cs_sysmoduleModel()
            {
                ParentId = id,
                Enable = true,
                Sort = 0
            };
            return View(entity);
        }

        [HttpPost]
        [SupportFilter]
        public JsonResult Create(cs_sysmoduleModel model)
        {
            //model.Id = ResultHelper.NewId;
            model.CreateTime = ResultHelper.NowTime;
            model.CreatePerson = GetUserId();
            if (model != null && ModelState.IsValid)
            {

                if (m_BLL.Create(ref errors, model))
                {
                    LogHandler.WriteServiceLog(GetUserId(), "Id" + model.Id + ",Name" + model.Name, "成功", "創建", "SysModule");
                    return Json(JsonHandler.CreateMessage(1, Suggestion.InsertSucceed));
                }
                else
                {
                    string ErrorCol = errors.Error;
                    LogHandler.WriteServiceLog(GetUserId(), "Id" + model.Id + ",Name" + model.Name + "," + ErrorCol, "失敗", "創建", "SysModule");
                    return Json(JsonHandler.CreateMessage(0, Suggestion.InsertFail + ErrorCol));
                }
            }
            else
            {
                return Json(JsonHandler.CreateMessage(0, Suggestion.InsertFail));
            }
        }
        #endregion


        #region 創建
        [SupportFilter(ActionName = "Create")]
        public ActionResult CreateOpt(string moduleId)
        {
            ViewBag.Perm = GetPermission();
            cs_sysmoduleopertaeModel sysModuleOptModel = new cs_sysmoduleopertaeModel();
            sysModuleOptModel.ModuleId = moduleId;
            sysModuleOptModel.IsValid = true;
            return View(sysModuleOptModel);
        }


        [HttpPost]
        [SupportFilter(ActionName = "Create")]
        public JsonResult CreateOpt(cs_sysmoduleopertaeModel info)
        {
            if (info != null && ModelState.IsValid)
            {
                cs_sysmoduleopertaeModel entity = operateBLL.GetById(info.Id);
                if (entity != null)
                    return Json(JsonHandler.CreateMessage(0, Suggestion.PrimaryRepeat), JsonRequestBehavior.AllowGet);
                entity = new cs_sysmoduleopertaeModel();
                entity.Id = info.ModuleId + info.KeyCode;
                entity.Name = info.Name;
                entity.KeyCode = info.KeyCode;
                entity.ModuleId = info.ModuleId;
                entity.IsValid = info.IsValid;
                entity.Sort = info.Sort;

                if (operateBLL.Create(ref errors, entity))
                {
                    LogHandler.WriteServiceLog(GetUserId(), "Id:" + info.Id + ",Name:" + info.Name, "成功", "創建", "SysModule");
                    return Json(JsonHandler.CreateMessage(1, Suggestion.InsertSucceed), JsonRequestBehavior.AllowGet);
                }
                else
                {
                    string ErrorCol = errors.Error;
                    LogHandler.WriteServiceLog(GetUserId(), "Id:" + info.Id + ",Name:" + info.Name + "," + ErrorCol, "失敗", "創建", "SysModule");
                    return Json(JsonHandler.CreateMessage(0, Suggestion.InsertFail + ErrorCol), JsonRequestBehavior.AllowGet);
                }
            }
            else
            {
                return Json(JsonHandler.CreateMessage(0, Suggestion.InsertFail), JsonRequestBehavior.AllowGet);
            }
        }
        #endregion

        #region 修改模組
        [SupportFilter]
        public ActionResult Edit(string id)
        {
            ViewBag.Perm = GetPermission();
            cs_sysmoduleModel entity = m_BLL.GetById(id);
            return View(entity);
        }

        [HttpPost]
        [SupportFilter]
        public JsonResult Edit(cs_sysmoduleModel model)
        {
            if (model != null && ModelState.IsValid)
            {
                if (m_BLL.Edit(ref errors, model))
                {
                    LogHandler.WriteServiceLog(GetUserId(), "Id" + model.Id + ",Name" + model.Name, "成功", "修改", "SysModule");
                    return Json(JsonHandler.CreateMessage(1, Suggestion.EditSucceed));
                }
                else
                {
                    string ErrorCol = errors.Error;
                    LogHandler.WriteServiceLog(GetUserId(), "Id" + model.Id + ",Name" + model.Name + "," + ErrorCol, "失敗", "修改", "SysModule");
                    return Json(JsonHandler.CreateMessage(0, Suggestion.EditFail + ErrorCol));
                }
            }
            else
            {
                return Json(JsonHandler.CreateMessage(0, Suggestion.EditFail));
            }
        }
        #endregion



        #region 刪除
        [HttpPost]
        [SupportFilter]
        public JsonResult Delete(string id)
        {
            if (!string.IsNullOrWhiteSpace(id))
            {
                if (m_BLL.Delete(ref errors, id))
                {
                    LogHandler.WriteServiceLog(GetUserId(), "Ids:" + id, "成功", "刪除", "SysModule");
                    return Json(JsonHandler.CreateMessage(1, Suggestion.DeleteSucceed), JsonRequestBehavior.AllowGet);
                }
                else
                {
                    string ErrorCol = errors.Error;
                    LogHandler.WriteServiceLog(GetUserId(), "Id:" + id + "," + ErrorCol, "失敗", "刪除", "SysModule");
                    return Json(JsonHandler.CreateMessage(0, Suggestion.DeleteFail + ErrorCol), JsonRequestBehavior.AllowGet);
                }
            }
            else
            {
                return Json(JsonHandler.CreateMessage(0, Suggestion.DeleteFail), JsonRequestBehavior.AllowGet);
            }


        }


        [HttpPost]
        [SupportFilter(ActionName = "Delete")]
        public JsonResult DeleteOpt(string id)
        {
            if (!string.IsNullOrWhiteSpace(id))
            {
                if (operateBLL.Delete(ref errors, id))
                {
                    LogHandler.WriteServiceLog(GetUserId(), "Id:" + id, "成功", "刪除", "SysModule");
                    return Json(JsonHandler.CreateMessage(1, Suggestion.DeleteSucceed), JsonRequestBehavior.AllowGet);
                }
                else
                {
                    string ErrorCol = errors.Error;
                    LogHandler.WriteServiceLog(GetUserId(), "Id:" + id + "," + ErrorCol, "失敗", "刪除", "SysModule");
                    return Json(JsonHandler.CreateMessage(0, Suggestion.DeleteFail + ErrorCol), JsonRequestBehavior.AllowGet);
                }
            }
            else
            {
                return Json(JsonHandler.CreateMessage(0, Suggestion.DeleteFail), JsonRequestBehavior.AllowGet);
            }


        }

        #endregion
    }


}