using CCS.IBLL;
using CCS.IDAL;
using CCS.Models.SYS;
using Microsoft.Practices.Unity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CCS.BLL
{
    public class cs_sysuserBLL : BaseBLL, Ics_sysuserBLL, IDisposable
    {
        [Dependency]
        public Ics_sysrightRepository cs_sysrightRepository { get; set; }
        public List<permModel> GetPermission(string accountid, string controller)
        {
            return cs_sysrightRepository.GetPermission(accountid, controller);
        }
        public void Dispose()
        {

        }
    }
}
