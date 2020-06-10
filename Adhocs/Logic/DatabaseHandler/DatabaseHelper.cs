using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.Sql;
using System.Data.SqlClient;
using System.Data.OleDb;
using System.Data.Odbc;
using System.IO;
using System.Configuration;

namespace Adhocs.App_Code.DatabaseHandler
{
    public class DatabaseHelpers
    {
        /// <summary>
        /// Executes a query and returns the result data as a list of records. Each record is represented as a list of field name-value pairs.
        /// </summary>
        /// <param name="conn">The DB connection object.</param>
        /// <param name="sql">The SQL query text.</param>
        /// <returns>List of records.</returns>
        public static int InsertData(IDbConnection conn, string sql)
        {
            IDbCommand cmd = conn.CreateCommand();
            cmd.CommandText = sql;

            if (string.IsNullOrEmpty(sql))
                return 0;

            int rowsAffected = 0;

            try
            {
                if (conn.State != ConnectionState.Open)
                    conn.Open();

                rowsAffected = cmd.ExecuteNonQuery();
                return rowsAffected;
            }
            finally
            {
                conn.Close();
            }
        }


        /// <summary>
        /// Executes a query and returns the result data as a list of records. Each record is represented as a list of field name-value pairs.
        /// </summary>
        /// <param name="conn">The DB connection object.</param>
        /// <param name="sql">The SQL query text.</param>
        /// <returns>List of records.</returns>
        public static List<Dictionary<string, object>> GetData(IDbConnection conn, string sql, CommandType type)
        {
            IDbCommand cmd = conn.CreateCommand();
            cmd.CommandType = type;
            cmd.CommandText = sql;

            if (string.IsNullOrEmpty(sql))
                return new List<Dictionary<string, object>>();

            try
            {
                if (conn.State != ConnectionState.Open)
                    conn.Open();

                IDataReader reader = cmd.ExecuteReader();
                return ConvertToList(reader);
            }
            finally
            {
                conn.Close();
            }
        }

        /// <summary>
        /// Executes a query and returns the result data as a list of records. Each record is represented as a list of field name-value pairs.
        /// </summary>
        /// <param name="conn">The DB connection object.</param>
        /// <param name="sql">The SQL query text.</param>
        /// <returns>List of records.</returns>
        public static List<Dictionary<string, object>> GetData(IDbConnection conn, string sql, IDbDataParameter param, CommandType type)
        {
            IDbCommand cmd = conn.CreateCommand();
            cmd.CommandType = type;
            cmd.CommandText = sql;

            if (string.IsNullOrEmpty(sql))
                return new List<Dictionary<string, object>>();

            try
            {
                if (conn.State != ConnectionState.Open)
                    conn.Open();

                IDataReader reader = cmd.ExecuteReader();
                return ConvertToList(reader);
            }
            finally
            {
                conn.Close();
            }
        }

        /// <summary>
        /// Saves data from IDataReader to the list. Each record is represented as a list of field name-value pairs.
        /// </summary>
        /// <param name="reader">The Data Reader object.</param>
        /// <returns>List of records.</returns>
        public static List<Dictionary<string, object>> ConvertToList(IDataReader reader)
        {
            var result = new List<Dictionary<string, object>>();

            while (reader.Read())
            {
                var row = new Dictionary<string, object>();

                for (int i = 0; i < reader.FieldCount; i++)
                    row.Add(reader.GetName(i), reader[i]);

                result.Add(row);
            }

            return result;
        }

        /// <summary>
        /// Saves data from IDataReader to the list. Each record is represented as a list of field name-value pairs.
        /// </summary>
        /// <param name="reader">The Data Reader object.</param>
        /// <returns>List of records.</returns>
        public static List<DataRow> ConvertToList(DataTable table)
        {
            var result = new List<DataRow> ();
            result = table.AsEnumerable().ToList();
            return result;
        }

        /// <summary>
        /// Saves data from IDataReader to the list. Each record is represented as a list of field name-value pairs.
        /// </summary>
        /// <param name="reader">The Data Reader object.</param>
        /// <returns>List of records.</returns>
        public static List<IQueryable> ConvertGridToList(System.Web.UI.Control grid)
        {
            var gridTable = grid as System.Web.UI.WebControls.GridView;

            var result = new List<IQueryable>();
            result.Add(gridTable.Rows.AsQueryable());
            return result;
        }

        /// <summary>
        /// Creates DBConnection object for MS Access database.
        /// </summary>
        /// <param name="AConfigurationName">Name of database configuration stored in the Web.Config file.</param>
        /// <returns>Returns an instance of OLEDBConnection.</returns>
        public static IDbConnection CreateAccessConnection(string AConfigurationName)
        {
            //var provider = "Microsoft.ACE.OLEDB.12.0";
            var provider = "Microsoft.Jet.OLEDB.4.0";            
            var file = Path.Combine(HttpContext.Current.Server.MapPath("~"), AConfigurationName);
            var connectionString = string.Format("Provider={0};Data Source={1};Persist Security Info=False;", provider, file);

            return new OleDbConnection(connectionString);
        }

        /// <summary>
        /// Creates DBConnection object for MS SQL Server database.
        /// </summary>
        /// <param name="AConfigurationName">Name of database configuration stored in the Web.Config file.</param>
        /// <returns>Returns an instance of OLEDBConnection.</returns>
        public static IDbConnection CreateMSSQLConnection(String AConfigurationName)
        {
            var connectionString = GetConnectionString(AConfigurationName);
            return new System.Data.SqlClient.SqlConnection(connectionString);
        }

        /// <summary>
        /// Creates DBConnection object for SQLite database.
        /// </summary>
        /// <param name="AConfigurationName">Name of database configuration stored in the Web.Config file.</param>
        /// <returns>Returns an instance of SQLiteConnection.</returns>
        //public static IDbConnection CreateSqLiteConnection(string AConfigurationName)
        //{
        //    // File name stored in the "/configuration/appSettings/<configuration name>" key
        //    var file = Path.Combine(HttpContext.Current.Server.MapPath("~"), AConfigurationName);
        //    var connectionString = string.Format("Data Source={0};Version=3;", file);
        //    return new SQLiteConnection(connectionString);
        //}

        public static String GetConnectionStringDefault()
        {
            return ConfigurationManager.ConnectionStrings["OSMLiteDBConnectionString2"].ConnectionString;
        }

        public static String GetConnectionString(string constringname)
        {
            return ConfigurationManager.ConnectionStrings[constringname].ConnectionString;
        }
    }
}