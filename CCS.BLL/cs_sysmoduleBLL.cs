using CCS.IBLL;
using CCS.IDAL;
using CCS.Models;
using Microsoft.Practices.Unity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CCS.BLL
{
    public class cs_sysmoduleBLL : Ics_sysmoduleBLL
    {
        [Dependency]
        public Ics_sysmoduleRepository cs_moduleRepository { get; set; }
        public List<CS_SYSMODULE> GetMenuByPersonId(string moduleId)
        {
            return cs_moduleRepository.GetMenuByPersonId(moduleId);
        }
    }
}
