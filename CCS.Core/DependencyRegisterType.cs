using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using CCS.IBLL;
using CCS.BLL;
using CCS.IDAL;
using CCS.DAL;
using Microsoft.Practices.Unity;
using CCS.Models.SAL;

namespace CCS.Core
{
    public class DependencyRegisterType
    {
        //系統注入
        public static void Container_Sal(ref UnityContainer container)
        {
            container.RegisterInstance<cs_comtModel>(new cs_comtModel());

            // CS_COMT
            container.RegisterType<Ics_comtBLL, cs_comtBLL>(); //詳例
            container.RegisterType<Ics_comtRepository, CS_COMTRepository>();

            //CS_SYSMODULE
            container.RegisterType<Ics_sysmoduleBLL, cs_sysmoduleBLL>();
            container.RegisterType<Ics_sysmoduleRepository, cs_sysmoduleRepository>();

            //CS_SYSLOG
            container.RegisterType<Ics_syslogBLL, cs_syslogBLL>();
            container.RegisterType<Ics_syslogRepository, cs_syslogRepository>();

            // CS_SYSEXCEPTION
            container.RegisterType<ISysExceptionBLL, SysExceptionBLL>();
            container.RegisterType<ISysExceptionRepository, SysExceptionRepository>();

            // CS_SYSUSER
            container.RegisterType<IAccountBLL, AccountBLL>();
            container.RegisterType<IAccountRepository, AccountRepository>();

            // CS_SYSUSER
            container.RegisterType<IcustomerBLL, customerBLL>();
            container.RegisterType<IcustomerRepository, customerRepository>();
        }
    }
}
