using Adhocs.Logic.ServiceHandler;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Reflection;
using System.Web;

namespace Adhocs.Logic.DatabaseHandler
{
    public sealed class Connection
    {
        private static SqlConnection instance = null;
        private static readonly object padlock = new object();

        Connection()
        {
        }

        public static SqlConnection Instance
        {
            get
            {
                lock (padlock)
                {
                    if (instance == null)
                    {
                        instance = new SqlConnection();
                    }
                    return instance;
                }
            }
        }
    }
    public class DatabaseOps
    {
        private SqlDataAdapter sqldataAdapter = null;
        private SqlDataReader sqldataReader = null;
        static SqlConnection connection = new SqlConnection();

        public static SqlConnection OpenSqlConnection()
        {
            var conString = ConnectionString.GetConnectionString();
            if (connection == null)
            {
                using(connection = new SqlConnection(conString)){}
            }
            else
            {
                if(String.IsNullOrWhiteSpace(connection.ConnectionString))
                    connection.ConnectionString = conString;

                if (connection.State == ConnectionState.Closed)
                {
                    connection.Open();
                }
            }
            return connection;
        }

        /// <summary>
        /// Get the connectionn string from the web.config file
        /// </summary>
        /// <param name="constringname"></param>
        /// <returns></returns>
        public static string GetRawConnectionString(string constringname)
        {
            if (constringname == null)
                throw new NullReferenceException("Connection string name can't be null");

            var conString = ConfigurationManager.ConnectionStrings[$"{constringname}"].ConnectionString;
            return conString;
        }

        public static SqlConnection GetConnectionString(string connectionstringname)
        {
            if (connection == null)
            {
                connection = new SqlConnection(connectionstringname);
            }
            else
            {
                if (String.IsNullOrWhiteSpace(connection.ConnectionString))
                    connection.ConnectionString = connectionstringname;

                if (connection.State == ConnectionState.Closed)
                {
                    connection.Open();
                }
            }
            return connection;
        }

        public DataTable GetDataTable(SqlCommand command)
        {
            sqldataAdapter = new SqlDataAdapter(command);
            DataTable resultDataTable = new DataTable();
            sqldataAdapter.Fill(resultDataTable);
            return resultDataTable;
        }

        public SqlDataReader ReadData(SqlCommand command)
        {
            return sqldataReader = command.ExecuteReader(CommandBehavior.CloseConnection);
        }

        public SqlDataReader ReadData(string command)
        {
            using (SqlCommand cmd = new SqlCommand(command, OpenSqlConnection()))
            {
                return sqldataReader = cmd.ExecuteReader(CommandBehavior.CloseConnection);
            }
        }

        public String GetData(SqlCommand command)
        {
            return command.ExecuteScalar().ToString();
        }

        public String GetData(string command)
        {
            using (SqlCommand cmd = new SqlCommand(command, OpenSqlConnection()))
            {
                return cmd.ExecuteScalar().ToString();
            }
        }

        public int ExecuteNonQuery(SqlCommand command)
        {
            return command.ExecuteNonQuery();
        }

        public int InsertData(SqlConnection connection, SqlCommand command)
        {
            command.Connection = connection;
            return command.ExecuteNonQuery();
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
            var result = new List<DataRow>();
            result = table.AsEnumerable().ToList();
            return result;
        }

        /// <summary>
        /// Saves data from IDataReader to the list. Each record is represented as a list of field name-value pairs.
        /// </summary>
        /// <param name="reader">The Data Reader object.</param>
        /// <returns>List of records.</returns>
        public static List<String> ConvertToStringList(DataTable table)
        {
            var result = new List<String>();
            result = table.AsEnumerable().Select(dr => dr.Field<string>(0)).ToList();
            return result;
        }

        public void Dispose()
        {
            
        }
    }

    public class TransformerUtil
    {
        public static class DataTableUtil
        {
            /// <summary>
            /// Fills the public properties of a class from the first row of a DataTable
            ///  where the name of the property matches the column name from that DataTable.
            /// </summary>
            /// <param name="Table">A DataTable that contains the data.</param>
            /// <returns>A class of type T with its public properties matching column names
            ///      set to the values from the first row in the DataTable.</returns>
            public static T SingRowToClass<T>(DataTable Table, int rowindex = 0) where T : class, new()
            {
                T result = new T();
                if (Validate(Table))
                {  // Because reflection is slow, we will only pass the first row of the DataTable
                    result = FillPropertiesFromDataRow<T>(Table.Rows[rowindex]);
                }
                return result;
            }

            /// <summary>
            /// Fills the public properties of a class from each row of a DataTable where the name of
            /// the property matches the column name in the DataTable, returning a List of T.
            /// </summary>
            /// <param name="Table">A DataTable that contains the data.</param>
            /// <returns>A List class T with each class's public properties matching column names
            ///      set to the values of a diffrent row in the DataTable.</returns>
            public static List<T> ToClassList<T>(DataTable Table) where T : class, new()
            {
                List<T> result = new List<T>();

                if (Validate(Table))
                {
                    foreach (DataRow row in Table.Rows)
                    {
                        result.Add(FillPropertiesFromDataRow<T>(row));
                    }
                }
                return result;
            }

            /// <summary>
            /// Fills the public properties of a class from a DataRow where the name
            /// of the property matches a column name from that DataRow.
            /// </summary>
            /// <param name="Row">A DataRow that contains the data.</param>
            /// <returns>A class of type T with its public properties set to the
            ///      data from the matching columns in the DataRow.</returns>
            public static T FillPropertiesFromDataRow<T>(DataRow Row) where T : class, new()
            {
                T result = new T();
                Type classType = typeof(T);

                // Defensive programming, make sure there are properties to set,
                //   and columns to set from and values to set from.
                if (Row.Table.Columns.Count < 1
                    || classType.GetProperties().Length < 1
                    || Row.ItemArray.Length < 1)
                {
                    return result;
                }

                foreach (PropertyInfo property in classType.GetProperties())
                {
                    foreach (DataColumn column in Row.Table.Columns)
                    {
                        // Skip if Property name and ColumnName do not match
                        if (property.Name != column.ColumnName)
                            continue;
                        // This would throw if we tried to convert it below
                        if (Row[column] == DBNull.Value)
                            continue;

                        object newValue;

                        // If type is of type System.Nullable, do not attempt to convert the value
                        if (IsNullable(property.PropertyType))
                        {
                            newValue = Row[property.Name];
                        }
                        else
                        {   // Convert row object to type of property
                            newValue = Convert.ChangeType(Row[column], property.PropertyType);
                        }

                        // This is what sets the class properties of the class
                        property.SetValue(result, newValue, null);
                    }
                }
                return result;
            }

            /// <summary>
            /// Checks a DataTable for empty rows, columns or null.
            /// </summary>
            /// <param name="DataTable">The DataTable to check.</param>
            /// <returns>True if DataTable has data, false if empty or null.</returns>
            public static bool Validate(DataTable DataTable)
            {
                if (DataTable == null) return false;
                if (DataTable.Rows.Count == 0) return false;
                if (DataTable.Columns.Count == 0) return false;
                return true;
            }

            /// <summary>
            /// Checks if type is nullable, Nullable<T> or its reference is nullable.
            /// </summary>
            /// <param name="type">Type to check for nullable.</param>
            /// <returns>True if type is nullable, false if it is not.</returns>
            public static bool IsNullable(Type type)
            {
                if (!type.IsValueType) return true; // ref-type
                if (Nullable.GetUnderlyingType(type) != null) return true; // Nullable<T>
                return false; // value-type
            }
        }

        public static List<T> ConvertToList<T>(DataTable dt)
        {
            var columnNames = dt.Columns.Cast<DataColumn>().Select(c => c.ColumnName.ToLower()).ToList();
            var properties = typeof(T).GetProperties(); return dt.AsEnumerable().Select(row =>
            {
                var objT = Activator.CreateInstance<T>();
                foreach (var pro in properties)
                {
                    if (columnNames.Contains(pro.Name.ToLower()))
                    {
                        try
                        {
                            pro.SetValue(objT, row[pro.Name]);
                        }
                        catch (Exception ex)
                        {
                            throw ex;
                        }
                    }
                }
                return objT;
            }).ToList();
        }
    }
}