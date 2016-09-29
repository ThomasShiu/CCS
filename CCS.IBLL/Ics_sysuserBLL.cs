using CCS.Models.SYS;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CCS.IBLL
{
    public interface Ics_sysuserBLL
    {
        List<permModel> GetPermission(string accountid, string controller);
    }
}
