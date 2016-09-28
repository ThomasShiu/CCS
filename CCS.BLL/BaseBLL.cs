using CCS.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CCS.BLL
{
    public class BaseBLL
    {
        //用base類去做統一的產生實體
        private CCSEntities _entity = new CCSEntities();

        public CCSEntities entity
        {
            get { return _entity; }
        }
    }


}
