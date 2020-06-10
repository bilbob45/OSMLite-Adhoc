using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.Data;
using System.Data.SqlClient;
using Adhocs.Logic.ServiceHandler;
using Adhocs.Logic.DatabaseHandler;

namespace Adhocs.Logic.ServiceHandler
{
    public class ReturnInstitutions
    {
        String _conString;
        public ReturnInstitutions()
        {
            _conString = ConnectionString.GetConnectionString();
        }

        public void GetReturnInstitutionsByTypeId(System.Web.UI.WebControls.DropDownList ddplist, int ritypeid)
        {
            DataTable dataTable = new DataTable();
            if (ritypeid > 0)
            {
                List<QueryStore> result = new List<QueryStore>();
                string sqlQuery = String.Format("SELECT a.ri_id, a.fullname, c.ri_type_id, d.config_value as ri_type_code FROM t_core_reporting_institution a JOIN t_core_ri_mapping b  ON a.ri_id = b.ri_id JOIN t_core_ri_type c ON b.ri_type_id = c.ri_type_id JOIN t_rpt_report_config d ON d.config_value = c.ri_type_code WHERE c.ri_type_id = @ritypeid");
                using (SqlCommand command = new SqlCommand(sqlQuery, DatabaseOps.OpenSqlConnection()))
                {
                    command.CommandType = CommandType.Text;
                    command.Parameters.AddWithValue("@ritypeid", ritypeid);
                    SqlDataAdapter adapter = new SqlDataAdapter(command);

                    adapter.Fill(dataTable);
                    
                    ddplist.DataSource = dataTable;
                    ddplist.DataValueField = "ri_id";
                    ddplist.DataTextField = "fullname";
                    ddplist.DataBind();

                    ddplist.Items.Insert(0, "-Select Institution-");
                }
            }
        }

        public void BindAllReturnInstitutions(System.Web.UI.WebControls.DropDownList ddplist, int ritypeid)
        {
            DataTable dataTable = new DataTable();
            if (ritypeid > 0)
            {
                List<QueryStore> result = new List<QueryStore>();
                string sqlQuery = String.Format("SELECT a.ri_id, a.fullname FROM t_core_reporting_institution a JOIN t_core_ri_mapping b  ON a.ri_id = b.ri_id JOIN t_core_ri_type c ON b.ri_type_id = c.ri_type_id WHERE c.ri_type_id = @ritypeid");
                using (SqlCommand command = new SqlCommand(sqlQuery, DatabaseOps.OpenSqlConnection()))
                {
                    command.CommandType = CommandType.Text;
                    command.Parameters.AddWithValue("@ritypeid", ritypeid);
                    SqlDataAdapter adapter = new SqlDataAdapter(command);

                    adapter.Fill(dataTable);

                    ddplist.DataSource = dataTable;
                    ddplist.DataValueField = "ri_id";
                    ddplist.DataTextField = "fullname";
                    ddplist.DataBind();

                    ddplist.Items.Insert(0, "-Select Institution-");
                }
            }
        }

        public void BindWorkCollectionDate(System.Web.UI.WebControls.DropDownList ddplist)
        {
            string sqlQuery = String.Format("Select distinct work_collection_date from t_rtn_work_collection_schedule order by work_collection_date desc");
            SqlConnection connection = new SqlConnection(_conString);
            connection.Open();

            SqlCommand command = new SqlCommand(sqlQuery, connection);

            DataTable dataTable = new DataTable();
            SqlDataAdapter adapter = new SqlDataAdapter(command);

            adapter.Fill(dataTable);

            ddplist.DataSource = dataTable;
            ddplist.DataValueField = "work_collection_date";
            ddplist.DataTextField = "work_collection_date";
            ddplist.DataBind();

            ddplist.Items.Insert(0, "-Select Work Collection Date-");
            connection.Close();
        }
    }
}