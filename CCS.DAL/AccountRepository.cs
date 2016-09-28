using CCS.IDAL;
using CCS.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CCS.DAL
{
    public class AccountRepository : IAccountRepository, IDisposable
    {
        public CS_SYSUSER Login(string username, string pwd)
        {
            using (CCSEntities db = new CCSEntities())
            {
                CS_SYSUSER user = db.CS_SYSUSER.SingleOrDefault(a => a.UserName == username && a.Password == pwd);
                return user;
            }
        }
        public void Dispose()
        {

        }
    }
}
