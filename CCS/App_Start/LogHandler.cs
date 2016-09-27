using CCS.Common;
using CCS.DAL;
using CCS.IBLL;
using CCS.Models;
using Microsoft.Practices.Unity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CCS.App_Start
{
    public static class LogHandler
    {
        [Dependency]
        public static Ics_syslogBLL logBLL { get; set; }
        /// <summary>
        /// 写入日志
        /// </summary>
        /// <param name="oper">操作人</param>
        /// <param name="mes">操作信息</param>
        /// <param name="result">结果</param>
        /// <param name="type">类型</param>
        /// <param name="module">操作模块</param>
        public static void WriteServiceLog(string oper, string mes, string result, string type, string module)
        {


            CS_SYSLOG entity = new CS_SYSLOG();
            entity.Id = ResultHelper.NewId;
            entity.Operator = oper;
            entity.Message = mes;
            entity.Result = result;
            entity.Type = type;
            entity.Module = module;
            entity.CreateTime = ResultHelper.NowTime;
            using (cs_syslogRepository logRepository = new cs_syslogRepository())
            {
                logRepository.Create(entity);
            }

        }
    }
}