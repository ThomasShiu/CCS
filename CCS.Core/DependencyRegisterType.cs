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
            container.RegisterType<Ics_comtRepository, cs_comtRepository>();

            // CS_CODL
            container.RegisterType<Ics_codlBLL, cs_codlBLL>(); //詳例
            container.RegisterType<Ics_codlRepository, cs_codlRepository>();

            // CS_WIRES
            container.RegisterType<Ics_wiresBLL, cs_wiresBLL>(); //詳例
            container.RegisterType<Ics_wiresRepository, cs_wiresRepository>();

            // CS_MOMT
            container.RegisterType<Ics_momtBLL, cs_momtBLL>(); //詳例
            container.RegisterType<Ics_momtRepository, cs_momtRepository>();

            //CS_SYSMODULE
            container.RegisterType<Ics_sysmoduleBLL, cs_sysmoduleBLL>();
            container.RegisterType<Ics_sysmoduleRepository, cs_sysmoduleRepository>();

            //CS_SYSLOG
            container.RegisterType<Ics_syslogBLL, cs_syslogBLL>();
            container.RegisterType<Ics_syslogRepository, cs_syslogRepository>();

            // CS_SYSEXCEPTION
            container.RegisterType<ISysExceptionBLL, SysExceptionBLL>();
            container.RegisterType<ISysExceptionRepository, SysExceptionRepository>();

            // CS_SYSMODULEOPERATE
            container.RegisterType<Ics_sysmoduleoperateBLL, cs_sysmoduleoperateBLL>();
            container.RegisterType<Ics_sysmoduleoperateRepository, cs_sysmoduleoperateRepository>();
            
            // CS_SYSROLE
            container.RegisterType<Ics_sysroleBLL, cs_sysroleBLL>();
            container.RegisterType<Ics_sysroleRepository, cs_sysroleRepository>();

            // CS_SYSRIGHT
            container.RegisterType<Ics_sysrightBLL, cs_sysrightBLL>();
            container.RegisterType<Ics_sysrightRepository, cs_sysrightRepository>();

            // CS_SYSUSER
            container.RegisterType<IAccountBLL, AccountBLL>();
            container.RegisterType<IAccountRepository, AccountRepository>();

            container.RegisterType<Ics_sysuserBLL, cs_sysuserBLL>();
            container.RegisterType<Ics_sysuserRepository, cs_sysuserRepository>();

            // customer
            container.RegisterType<IcustomerBLL, customerBLL>();
            container.RegisterType<IcustomerRepository, customerRepository>();

            // item
            container.RegisterType<IitemBLL, itemBLL>();
            container.RegisterType<IitemRepository, itemRepository>();

            // EMPNO
            container.RegisterType<IEMPNOBLL, EMPNOBLL>();
            container.RegisterType<IEMPNORepository, EMPNORepository>();
        }
    }
}
