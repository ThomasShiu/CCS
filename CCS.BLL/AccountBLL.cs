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
    public class AccountBLL : BaseBLL, IAccountBLL
    {
        [Dependency]
        public IAccountRepository accountRepository { get; set; }
        public CS_SYSUSER Login(string username, string pwd)
        {
            return accountRepository.Login(username, pwd);

        }
    }
}
