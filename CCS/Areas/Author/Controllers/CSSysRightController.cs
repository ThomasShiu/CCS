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
    public class CSSysRightController : BaseController
    {
        // GET: Author/CSSysRight
        //
        // GET: /SysRight/
        [Dependency]
        public Ics_sysrightBLL sysRightBLL { get; set; }
        [Dependency]
        public Ics_sysroleBLL sysRoleBLL { get; set; }
        [Dependency]
        public Ics_sysmoduleBLL sysModuleBLL { get; set; }

        ValidationErrors errors = new ValidationErrors();

        [SupportFilter]
        public ActionResult Index()
        {
            ViewBag.Perm = GetPermission();
            return View();
        }

        //獲取角色列表
        [SupportFilter(ActionName = "Index")]
        [HttpPost]
        public JsonResult GetRoleList(GridPager pager)
        {
            List<cs_sysroleModel> list = sysRoleBLL.GetList(ref pager, "");
            var json = new
            {
                total = pager.totalRows,
                rows = (from r in list
                        select new cs_sysroleModel()
                        {

                            Id = r.Id,
                            Name = r.Name,
                            Description = r.Description,
                            CreateTime = r.CreateTime,
                            CreatePerson = r.CreatePerson

                        }).ToArray()

            };

            return Json(json);
        }

        //獲取模組列表
        [SupportFilter(ActionName = "Index")]
        [HttpPost]
        public JsonResult GetModelList(string id)
        {
            if (id == null)
                id = "0";
            List<cs_sysmoduleModel> list = sysModuleBLL.GetList(id);
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
                           state = (sysModuleBLL.GetList(r.Id).Count > 0) ? "closed" : "open"
                       };


            return Json(json);
        }

        //根據角色與模組得出許可權
        [SupportFilter(ActionName = "Index")]
        [HttpPost]
        public JsonResult GetRightByRoleAndModule(GridPager pager, string roleId, string moduleId)
        {
            pager.rows = 100000;
            var right = sysRightBLL.GetRightByRoleAndModule(roleId, moduleId);
            var json = new
            {
                total = pager.totalRows,
                rows = (from r in right
                        select new cs_SysRightModelByRoleAndModuleModel()
                        {
                            Ids = r.RightId + r.KeyCode,
                            Name = r.Name,
                            KeyCode = r.KeyCode,
                            IsValid = r.isvalid,
                            RightId = r.RightId
                        }).ToArray()

            };

            return Json(json);
        }

        //保存
        [HttpPost]
        [SupportFilter(ActionName = "Save")]
        public int UpdateRight(cs_sysrightoperateModel model)
        {
            return sysRightBLL.UpdateRight(model);
        }


        [SupportFilter(ActionName ="Index")]
        public ActionResult IndexRight()
        {
            ViewBag.Perm = GetPermission();
            return View();
        }

        //獲取角色列表
        [SupportFilter(ActionName = "Index")]
        [HttpPost]
        public JsonResult GetRightList(GridPager pager, string queryStr)
        {
            List<cs_sysrightModel> list = sysRightBLL.GetList(ref pager, queryStr);
            var json = new
            {
                total = pager.totalRows,
                rows = (from r in list
                        select new cs_sysrightModel()
                        {
                            Id = r.Id,
                            ModuleId = r.ModuleId,
                            RoleId = r.RoleId,
                            Rightflag = r.Rightflag

                        }).ToArray()

            };

            return Json(json);

            //List<cs_sysrightModel> list = sysRightBLL.GetList( queryStr);
            //var json = from r in list
            //            select new cs_sysrightModel()
            //            {
            //                Id = r.Id,
            //                ModuleId = r.ModuleId,
            //                RoleId = r.RoleId,
            //                Rightflag = r.Rightflag

            //            };

            //return Json(json);
        }
        #region 修改
        [SupportFilter]
        public ActionResult Edit(string id)
        {
            ViewBag.Perm = GetPermission();
            cs_sysrightModel entity = sysRightBLL.GetById(id);
            return View(entity);
        }

        [HttpPost]
        [SupportFilter]
        public JsonResult Edit(cs_sysrightModel model)
        {
            if (model != null && ModelState.IsValid)
            {

                if (sysRightBLL.Edit(ref errors, model))
                {
                    LogHandler.WriteServiceLog(GetUserId(), "Id" + model.Id + ",ModuleId" + model.ModuleId, "成功", "修改", "CS_SYSRIGHT");
                    return Json(JsonHandler.CreateMessage(1, Suggestion.EditSucceed));
                }
                else
                {
                    string ErrorCol = errors.Error;
                    LogHandler.WriteServiceLog(GetUserId(), "Id" + model.Id + ",ModuleId" + model.ModuleId + "," + ErrorCol, "失敗", "修改", "CS_SYSRIGHT");
                    return Json(JsonHandler.CreateMessage(0, Suggestion.EditFail + ErrorCol));
                }
            }
            else
            {
                return Json(JsonHandler.CreateMessage(0, Suggestion.EditFail));
            }
        }
        #endregion


    }
}