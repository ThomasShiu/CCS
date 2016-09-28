using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using System.Web.Script.Serialization;

namespace CCS.Common
{
    public class ToJsonResult : JsonResult
    {
        const string error = "該請求已被封鎖，因為敏感資訊透露給協力廠商網站，這是一個GET請求時使用的。為了可以GET請求，請設置JsonRequestBehavior AllowGet。";
        /// <summary>
        /// 格式化字串
        /// </summary>
        public string FormateStr
        {
            get;
            set;
        }
        public override void ExecuteResult(ControllerContext context)
        {
            if (context == null)
            {
                throw new ArgumentNullException("context");
            }
            if (JsonRequestBehavior == JsonRequestBehavior.DenyGet &&
                String.Equals(context.HttpContext.Request.HttpMethod, "GET", StringComparison.OrdinalIgnoreCase))
            {
                throw new InvalidOperationException(error);
            }

            HttpResponseBase response = context.HttpContext.Response;

            if (!String.IsNullOrEmpty(ContentType))
            {
                response.ContentType = ContentType;
            }
            else
            {
                response.ContentType = "application/json";
            }
            if (ContentEncoding != null)
            {
                response.ContentEncoding = ContentEncoding;
            }
            if (Data != null)
            {
                JavaScriptSerializer serializer = new JavaScriptSerializer();
                string jsonstring = serializer.Serialize(Data);


                //string p = @"\\/Date\((\d+)\+\d+\)\\/";

                string p = @"\\/Date\(\d+\)\\/";

                MatchEvaluator matchEvaluator = new MatchEvaluator(ConvertJsonDateToDateString);

                Regex reg = new Regex(p);

                jsonstring = reg.Replace(jsonstring, matchEvaluator);
                response.Write(jsonstring);
            }
        }

        /// <summary>
        /// 將Json序列化的時間由/Date(1294499956278+0800)轉為字串
        /// </summary>
        private string ConvertJsonDateToDateString(Match m)
        {

            string result = string.Empty;

            string p = @"\d";
            var cArray = m.Value.ToCharArray();
            StringBuilder sb = new StringBuilder();

            Regex reg = new Regex(p);
            for (int i = 0; i < cArray.Length; i++)
            {
                if (reg.IsMatch(cArray[i].ToString()))
                {
                    sb.Append(cArray[i]);
                }
            }
            // reg.Replace(m.Value;

            DateTime dt = new DateTime(1970, 1, 1);

            dt = dt.AddMilliseconds(long.Parse(sb.ToString()));

            dt = dt.ToLocalTime();

            result = dt.ToString("yyyy-MM-dd HH:mm:ss");

            return result;

        }
    }

}
