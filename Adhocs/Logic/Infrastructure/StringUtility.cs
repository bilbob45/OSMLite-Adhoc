using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Adhocs.Logic.Infrastructure
{
    public class StringUtility : IStringUtility
    {
        public string Decode(string text)
        {
            throw new NotImplementedException();
        }

        public string Encode(string text)
        {
            throw new NotImplementedException();
        }

        public static string FormatMoney()
        {
            return "0,0.00";
        }
    }

    public class QueryString
    {
        public QueryString()
        {

        }

        public static string Encrypt(string url)
        {
            string cookedUrl = url;

            if (url != null && url.Contains(".aspx?"))
            {
                cookedUrl = url.Substring(0, url.IndexOf('?') + 1);

                var queryStrings = url.Substring(url.IndexOf('?') + 1).Split('&');

                foreach (var queryString in queryStrings)
                {
                    if (!string.IsNullOrEmpty(queryString))
                        cookedUrl += queryString.Split('=')[0];// + "=" + Encrypting(queryString.Split('=')[1]) + "&";
                }
                cookedUrl = cookedUrl.Substring(0, cookedUrl.Length - 1);
                //cookedUrl = cookedUrl.Replace("?", "?" + PARAMETER_NAME);
            }
            return cookedUrl;

        }
    }
}