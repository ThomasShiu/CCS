﻿using CCS.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CCS.IBLL
{
    public interface Ics_sysmoduleBLL
    {
        List<CS_SYSMODULE> GetMenuByPersonId(string moduleId);
    }
}
