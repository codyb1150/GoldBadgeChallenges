using System;
using System.Collections.Generic;
using System.Diagnostics.Eventing.Reader;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _05_Challenge_Repository
{
    public class BadgeRepo
    {
        private static Dictionary<string, object> dict = new Dictionary<string, object>();
        

        public void AddToDictionary(string strKey, object dateType)
        {
            if (!dict.ContainsKey(strKey))
            {
                dict.Add(strKey, dateType);
            }
            else
            {
                dict[strKey] = dateType;
            }
        }

        public Dictionary<string, object> GetDictionary()
        {
            return dict;
        }


         
        

        //private static T GetAnyValue<T>(string strKey)
        //{
        //    object obj;
        //    T returnType;

        //    dict.TryGetValue(strKey, out obj);

        //    try
        //    {
        //        returnType = (T)obj;

        //    }
        //    catch
        //    {
        //        returnType = default(T);
        //    }
        //    return returnType;
        //}
    }
}
