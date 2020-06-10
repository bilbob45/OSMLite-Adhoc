using System;
using System.Collections.Generic;
using System.Collections;
using System.Linq;
using System.Web;

namespace Adhocs.Logic.ServiceHandler
{
    public class QueryStringHandler
    {
        public string Key { get; set; }
        public String Value { get; set; }
        
        public QueryStringHandler()
        {
        }

        public bool Exists(string key)
        {
            var queryStringCollection = HttpContext.Current.Request.QueryString;
            int keyCount = queryStringCollection.Count;
            if (keyCount < 1)
                throw new Exception("Query string 'uname' is empty");

            if (queryStringCollection.AllKeys.Contains<string>(key))
                return true;
            else
                return false;
        }

        public String[] GetKeys()
        {
            return HttpContext.Current.Request.QueryString.AllKeys;
        }

        public String GetValue(string key)
        {
            if (Exists(key) == true)
            {
                this.Key = HttpContext.Current.Request.QueryString[key];
                return HttpContext.Current.Request.QueryString[key];
            }
            else
                return string.Empty;
        }
    }
}