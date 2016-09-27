using CCS.Common;
using CCS.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CCS.IBLL
{
    public interface ISysExceptionBLL
    {
        List<CS_SYSEXCEPTION> GetList(ref GridPager pager, string queryStr);
        CS_SYSEXCEPTION GetById(string id);
    }
}
