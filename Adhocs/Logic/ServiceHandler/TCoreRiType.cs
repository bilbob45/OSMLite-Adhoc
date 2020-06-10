using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.ComponentModel.DataAnnotations;
using Adhocs.Logic.ServiceHandler;
using Adhocs.Logic.DatabaseHandler;
using Adhocs.Logic.Objects;
using Adhocs.Logic.Infrastructure;

namespace Adhocs.Logic.ServiceHandler
{
    public class TCoreRiType
    {
        //String _conString;
        DataTable _resultTable;
        DatabaseOps _databaseOperations;
        Utility _util;
        public TCoreRiType()
        {
            //_conString = ConnectionString.GetConnectionString();
            _resultTable = new DataTable();
            _databaseOperations = new DatabaseOps();
            _util = new Utility();
        }

        public void GetAdjustmentRiType(DropDownList ddplist)
        {
            string sqlQuery = String.Format("SELECT * FROM t_core_ri_type WHERE ri_type_code IN ('CB','NIB','DH')");
            _util.OptionBinder(ddplist, sqlQuery, new string[] { "description", "ri_type_id" });
        }

        public void GetAllRiTypes(DropDownList ddplist)
        {
            ddplist.Items.Clear();
            string sqlQuery = @"Select ri_type_id, description from t_core_ri_type";
            //using (SqlCommand cmd = new SqlCommand(sqlQuery, DatabaseOps.OpenSqlConnection()))
            //{
            //    cmd.CommandType = CommandType.Text;
            //    _resultTable = _databaseOperations.GetDataTable(cmd);

            //    ddplist.DataSource = _resultTable;
            //    ddplist.DataTextField = "description";
            //    ddplist.DataValueField = "ri_type_id";
            //    ddplist.DataBind();
            //}
            _util.OptionBinder(ddplist, sqlQuery, new string[] {"description", "ri_type_id" });
        }

        public List<String> GetTableSurfixByRIType(String bindingparameter)
        {
            List<String> ddpTable = new List<string>();
            if (bindingparameter == null)
                throw new NullReferenceException();
            ddpTable.Clear();
            switch (bindingparameter)
            {
                case "CB":
                    ddpTable.Add("MBR300");
                    ddpTable.Add("MBR1000");
                    break;
                case "NIB":
                    ddpTable.Add("NIB300");
                    ddpTable.Add("NIB1000");
                    break;
                case "DH":
                    ddpTable.Add("MDHR300");
                    ddpTable.Add("MDHR1000");
                    break;
                default:
                    ddpTable.Add("");
                    break;
            }

            return ddpTable;
        }

        /// <summary>
        /// Return reporting institution code by id
        /// </summary>
        /// <param name="ritypeid"></param>
        /// <returns></returns>
        public String GetRICodeByID(String ritypeid)
        {
            String returnCode = null;
            var sqlQuery = $"SELECT ri_type_code FROM t_core_ri_type where ri_type_id = {ritypeid}";
            using (SqlCommand command = new SqlCommand(sqlQuery, DatabaseOps.OpenSqlConnection()))
            {
                returnCode = _databaseOperations.GetData(command);
            }

            return returnCode;
        }

        /// <summary>
        /// Method created for returning the articles
        /// </summary>
        /// <param name="article"></param>
        /// <returns></returns>
        public List<TCoreRiTypeObject> GetAllRIType()
        {

            List<TCoreRiTypeObject> result = new List<TCoreRiTypeObject>();

            //Create the SQL Query for returning all the articles
            string sqlQuery = String.Format("SELECT * FROM t_core_ri_type");

            //Create and open a connection to SQL Server 
            SqlConnection connection = new SqlConnection(ConnectionString.GetConnectionString());
            connection.Open();

            SqlCommand command = new SqlCommand(sqlQuery, connection);

            //Create DataReader for storing the returning table into server memory
            SqlDataReader dataReader = command.ExecuteReader();
            TCoreRiTypeObject riResult;
            //load into the result object the returned row from the database
            if (dataReader.HasRows)
            {
                while (dataReader.Read())
                {
                    riResult = new TCoreRiTypeObject()
                    {
                        ri_type_id = Convert.ToInt32(dataReader.GetString(0)),
                        ri_type_code = dataReader.GetString(1),
                        description = dataReader.GetString(2),
                        start_validity_date = Convert.ToDateTime(dataReader.GetString(3)),
                        end_validity_date = Convert.ToDateTime(dataReader.GetString(4)),
                        admin_user_limit = Convert.ToInt32(dataReader.GetString(5)),
                        created_date = Convert.ToDateTime(dataReader.GetString(6)),
                        created_by = dataReader.GetString(7),
                        last_modified = Convert.ToDateTime(dataReader.GetString(8)),
                        modified_by = dataReader.GetString(9),
                    };
                    result.Add(riResult);
                }
            }

            return result;
        }
    }
}