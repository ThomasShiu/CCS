using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CCS.Common
{
    public class GridPager
    {
        public int rows { get; set; }// 每頁行數
        public int page { get; set; }// 當前頁是第幾頁
        public string order { get; set; }// 排序方式
        public string sort { get; set; }// 排序列
        public int totalRows { get; set; }// 總行數

        public int totalPages // 總頁數
        {
            get
            {
                return (int)Math.Ceiling((float)totalRows / (float)rows);
            }
        }
    }
}
