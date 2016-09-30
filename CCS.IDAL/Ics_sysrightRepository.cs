using CCS.Models.SYS;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CCS.IDAL
{
    public interface Ics_sysrightRepository
    {
        List<permModel> GetPermission(string accountid, string controller);
    }
}
