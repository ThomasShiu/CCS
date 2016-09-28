using CCS.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CCS.IDAL
{
    public interface Ics_sysmoduleRepository
    {
        //List<CS_SYSMODULE> GetMenuByPersonId(string moduleId);
        List<CS_SYSMODULE> GetMenuByPersonId(string personId, string moduleId);
    }
}
