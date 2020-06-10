using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Configuration;
using System.Data.SqlClient;

namespace Adhocs.Logic.ServiceHandler
{
    public class ConnectionString
    {
        /// <summary>
        /// Get the connection string from the web.config file
        /// </summary>
        /// <returns></returns>
        public static String GetConnectionString()
        {
            var conString = ConfigurationManager.ConnectionStrings["OSMLiteDBConnectionString3"].ConnectionString;
            return conString;
        }

        /// <summary>
        /// Get the connection string from the web.config file with the specified name
        /// </summary>
        /// <param name="constringname">The connectionstring name within <connectionString> section</param>
        /// <returns>String</returns>
        public static String GetConnectionString(string constringname)
        {
            return ConfigurationManager.ConnectionStrings[constringname].ConnectionString;
        }
    }
}