using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;
using System.Data.SqlClient;
using System.Data;
using Adhocs.Logic.DatabaseHandler;

namespace Adhocs.Logic.Infrastructure
{
    public class Utility
    {
        DataTable _resultTable;
        DatabaseOps _databaseOperations;
        public Utility()
        {
            _resultTable = new DataTable();
            _databaseOperations = new DatabaseOps();
        }

        public void OptionBinder(DropDownList controlid, string sqlcommand, params string[] datafields)
        {
            try
            {
                controlid.Items.Clear();
                if (datafields.Length < 1)
                    throw new ArgumentException("Data text and value field are required");

                using (SqlCommand cmd = new SqlCommand(sqlcommand, DatabaseOps.OpenSqlConnection()))
                {
                    cmd.CommandType = CommandType.Text;
                    _resultTable = _databaseOperations.GetDataTable(cmd);

                    controlid.DataSource = _resultTable;
                    controlid.DataTextField = datafields[0];
                    controlid.DataValueField = datafields[1];
                    controlid.DataBind();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}