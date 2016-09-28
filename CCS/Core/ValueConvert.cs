using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Web;

namespace CCS.Core
{
    public static partial class ValueConvert
    {
        /// <summary>
        /// 使用MD5加密字串
        /// </summary>
        /// <param name="str">待加密的字元</param>
        /// <returns></returns>
        public static string MD5(this string str)
        {
            if (string.IsNullOrEmpty(str))
            {
                return string.Empty;
            }
            MD5CryptoServiceProvider md5 = new MD5CryptoServiceProvider();
            byte[] arr = UTF8Encoding.Default.GetBytes(str);
            byte[] bytes = md5.ComputeHash(arr);
            str = BitConverter.ToString(bytes);
            //str = str.Replace("-", "");
            return str;
        }
        /// <summary>
        /// 將最後一個字串的路徑path替換
        /// </summary>
        /// <param name="str"></param>
        /// <param name="path"></param>
        /// <returns></returns>
        public static string Path(this string str, string path)
        {
            int index = str.LastIndexOf('\\');
            int indexDian = str.LastIndexOf('.');
            return str.Substring(0, index + 1) + path + str.Substring(indexDian);
        }
        public static List<string> ToList(this string ids)
        {
            List<string> listId = new List<string>();
            if (!string.IsNullOrEmpty(ids))
            {
                var sort = new SortedSet<string>(ids.Split(','));
                foreach (var item in sort)
                {
                    listId.Add(item);

                }
            }
            return listId;
        }
        /// <summary>
        /// 從^分割的字串中獲取多個Id,先是用 ^ 分割，再使用 & 分割
        /// </summary>
        /// <param name="ids">先是用 ^ 分割，再使用 & 分割</param>
        /// <returns></returns>
        public static List<string> GetIdSort(this string ids)
        {
            List<string> listId = new List<string>();
            if (!string.IsNullOrEmpty(ids))
            {
                var sort = new SortedSet<string>(ids.Split('^')
                    .Where(w => !string.IsNullOrWhiteSpace(w) && w.Contains('&'))
                    .Select(s => s.Substring(0, s.IndexOf('&'))));
                foreach (var item in sort)
                {
                    listId.Add(item);
                }
            }
            return listId;
        }
        /// <summary>
        /// 從，分割的字串中獲取單個Id
        /// </summary>
        /// <param name="ids"></param>
        /// <returns></returns>
        public static string GetId(this string ids)
        {
            if (!string.IsNullOrEmpty(ids))
            {
                var sort = new SortedSet<string>(ids.Split('^')
                    .Where(w => !string.IsNullOrWhiteSpace(w) && w.Contains('&'))
                    .Select(s => s.Substring(0, s.IndexOf('&'))));
                foreach (var item in sort)
                {
                    if (!string.IsNullOrWhiteSpace(item))
                    {
                        return item;
                    }
                }
            }
            return null;
        }
        /// <summary>
        /// 將String轉換為Dictionary類型，過濾掉為空的值，首先 6 分割，再 7 分割
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static Dictionary<string, string> StringToDictionary(string value)
        {
            Dictionary<string, string> queryDictionary = new Dictionary<string, string>();
            string[] s = value.Split('^');
            for (int i = 0; i < s.Length; i++)
            {
                if (!string.IsNullOrWhiteSpace(s[i]) && !s[i].Contains("undefined"))
                {
                    var ss = s[i].Split('&');
                    if ((!string.IsNullOrEmpty(ss[0])) && (!string.IsNullOrEmpty(ss[1])))
                    {
                        queryDictionary.Add(ss[0], ss[1]);
                    }
                }

            }
            return queryDictionary;
        }
        /// <summary>
        /// 得到物件的 Int 類型的值，預設值0
        /// </summary>
        /// <param name="Value">要轉換的值</param>
        /// <returns>如果物件的值可正確返回， 返回物件轉換的值 ，否則， 返回預設值0</returns>
        public static int GetInt(this object Value)
        {
            return GetInt(Value, 0);
        }
        /// <summary>
        /// 得到物件的 Int 類型的值，預設值0
        /// </summary>
        /// <param name="Value">要轉換的值</param>
        /// <param name="defaultValue">如果轉換失敗，返回的預設值</param>
        /// <returns>如果物件的值可正確返回， 返回物件轉換的值 ，否則， 返回預設值0</returns>
        public static int GetInt(this object Value, int defaultValue)
        {

            if (Value == null) return defaultValue;
            if (Value is string && Value.GetString().HasValue() == false) return defaultValue;

            if (Value is DBNull) return defaultValue;

            if ((Value is string) == false && (Value is IConvertible) == true)
            {
                return (Value as IConvertible).ToInt32(CultureInfo.CurrentCulture);
            }

            int retVal = defaultValue;
            if (int.TryParse(Value.ToString(), NumberStyles.Any, CultureInfo.CurrentCulture, out retVal))
            {
                return retVal;
            }
            else
            {
                return defaultValue;
            }
        }
        /// <summary>
        /// 得到物件的 String 類型的值，預設值string.Empty
        /// </summary>
        /// <param name="Value">要轉換的值</param>
        /// <returns>如果物件的值可正確返回， 返回物件轉換的值 ，否則， 返回預設值string.Empty</returns>
        public static string GetString(this object Value)
        {
            return GetString(Value, string.Empty);
        }
        /// <summary>
        /// 得到物件的 String 類型的值，預設值string.Empty
        /// </summary>
        /// <param name="Value">要轉換的值</param>
        /// <param name="defaultValue">如果轉換失敗，返回的預設值</param>
        /// <returns>如果物件的值可正確返回， 返回物件轉換的值 ，否則， 返回預設值 。</returns>
        public static string GetString(this object Value, string defaultValue)
        {
            if (Value == null) return defaultValue;
            string retVal = defaultValue;
            try
            {
                var strValue = Value as string;
                if (strValue != null)
                {
                    return strValue;
                }

                char[] chrs = Value as char[];
                if (chrs != null)
                {
                    return new string(chrs);
                }

                retVal = Value.ToString();
            }
            catch
            {
                return defaultValue;
            }
            return retVal;
        }
        /// <summary>
        /// 得到物件的 DateTime 類型的值，預設值為DateTime.MinValue
        /// </summary>
        /// <param name="Value">要轉換的值</param>
        /// <returns>如果物件的值可正確返回， 返回物件轉換的值 ，否則， 返回的預設值為DateTime.MinValue </returns>
        public static DateTime GetDateTime(this object Value)
        {
            return GetDateTime(Value, DateTime.MinValue);
        }

        /// <summary>
        /// 得到物件的 DateTime 類型的值，預設值為DateTime.MinValue
        /// </summary>
        /// <param name="Value">要轉換的值</param>
        /// <param name="defaultValue">如果轉換失敗，返回預設值為DateTime.MinValue</param>
        /// <returns>如果物件的值可正確返回， 返回物件轉換的值 ，否則， 返回的預設值為DateTime.MinValue</returns>
        public static DateTime GetDateTime(this object Value, DateTime defaultValue)
        {
            if (Value == null) return defaultValue;

            if (Value is DBNull) return defaultValue;

            string strValue = Value as string;
            if (strValue == null && (Value is IConvertible))
            {
                return (Value as IConvertible).ToDateTime(CultureInfo.CurrentCulture);
            }
            if (strValue != null)
            {
                strValue = strValue
                    .Replace("年", "-")
                    .Replace("月", "-")
                    .Replace("日", "-")
                    .Replace("點", ":")
                    .Replace("時", ":")
                    .Replace("分", ":")
                    .Replace("秒", ":")
                      ;
            }
            DateTime dt = defaultValue;
            if (DateTime.TryParse(Value.GetString(), out dt))
            {
                return dt;
            }

            return defaultValue;
        }
        /// <summary>
        /// 得到物件的布林類型的值，預設值false
        /// </summary>
        /// <param name="Value">要轉換的值</param>
        /// <returns>如果物件的值可正確返回， 返回物件轉換的值 ，否則， 返回預設值false</returns>
        public static bool GetBool(this object Value)
        {
            return GetBool(Value, false);
        }

        /// <summary>
        /// 得到物件的 Bool 類型的值，預設值false
        /// </summary>
        /// <param name="Value">要轉換的值</param>
        /// <param name="defaultValue">如果轉換失敗，返回的預設值</param>
        /// <returns>如果物件的值可正確返回， 返回物件轉換的值 ，否則， 返回預設值false</returns>
        public static bool GetBool(this object Value, bool defaultValue)
        {
            if (Value == null) return defaultValue;
            if (Value is string && Value.GetString().HasValue() == false) return defaultValue;

            if ((Value is string) == false && (Value is IConvertible) == true)
            {
                if (Value is DBNull) return defaultValue;

                try
                {
                    return (Value as IConvertible).ToBoolean(CultureInfo.CurrentCulture);
                }
                catch { }
            }

            if (Value is string)
            {
                if (Value.GetString() == "0") return false;
                if (Value.GetString() == "1") return true;
                if (Value.GetString().ToLower() == "yes") return true;
                if (Value.GetString().ToLower() == "no") return false;
            }
            ///  if (Value.GetInt(0) != 0) return true;
            bool retVal = defaultValue;
            if (bool.TryParse(Value.GetString(), out retVal))
            {
                return retVal;
            }
            else return defaultValue;
        }
        /// <summary>
        /// 檢測 GuidValue 是否包含有效的值，預設值Guid.Empty
        /// </summary>
        /// <param name="GuidValue">要轉換的值</param>
        /// <returns>如果物件的值可正確返回， 返回物件轉換的值 ，否則， 返回預設值Guid.Empty</returns>
        public static Guid GetGuid(string GuidValue)
        {
            try
            {
                return new Guid(GuidValue);
            }
            catch { return Guid.Empty; }
        }
        /// <summary>
        /// 檢測 Value 是否包含有效的值，預設值false
        /// </summary>
        /// <param name="Value"> 傳入的值</param>
        /// <returns> 包含，返回true，不包含，返回預設值false</returns>
        public static bool HasValue(this string Value)
        {
            if (Value != null)
            {
                return !string.IsNullOrEmpty(Value.ToString());
            }
            else return false;
        }

    }


}