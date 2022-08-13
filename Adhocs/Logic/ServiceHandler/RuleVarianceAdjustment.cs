using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using Adhocs.Logic.DatabaseHandler;
using Adhocs.Logic.ServiceHandler;
using Adhocs.Logic.Objects;
using System.Configuration;
using System.Transactions;
using Adhocs.Logic.ServiceHandler;

namespace Adhocs.Logic.ServiceHandler
{
    public class RuleVarianceAdjustment
    {
        class DynamicQuery
        {
            public DynamicQuery()
            {

            }
        }

        private string _ritypecode;
        DatabaseOps _databaseOperations;
        DataTable _resultTable;
        TRPTComputationRuleAdjustmentHandler _trptComputationValueTable;
        TRPTComputationValueTableHandler _trptcomputationvaluetableobject;

        public TRTNWorkCollectionScheduleObject trtnworkcollectionscheduleobject;
        public RuleVarianceAdjustment()
        {
            _databaseOperations = new DatabaseOps();
            _resultTable = new DataTable();
        }

        public RuleVarianceAdjustment(string ritypecode)
        {
            _ritypecode = ritypecode;
            _databaseOperations = new DatabaseOps();
            _resultTable = new DataTable();
        }

        #region Dropdown control binding
        public void GetFrequency(DropDownList ddplist, string ritypecode)
        {
            try
            {
                var sqlWhiteList = @"SELECT freq_unit, freq_desc FROM t_lkup_frequency WHERE freq_name NOT IN ('Ad-Hoc')";
                sqlWhiteList = @"SELECT DISTINCT c.freq_unit, c.freq_desc from t_rpt_computation_rule_ri_type_mapping a JOIN t_rpt_computation_rule_frequency b ON a.computation_rule = b.computation_rule JOIN t_lkup_frequency c ON c.freq_unit = b.frequency WHERE a.ri_type_code = @ri_type_code";
                using (SqlCommand cmd = new SqlCommand(sqlWhiteList, DatabaseOps.OpenSqlConnection()))
                {
                    cmd.CommandType = CommandType.Text;
                    cmd.Parameters.AddWithValue("@ri_type_code", ritypecode.Trim());
                    _resultTable = _databaseOperations.GetDataTable(cmd);

                    foreach (DataRow row in _resultTable.Rows)
                    {
                        ddplist.Items.Add(new ListItem($"{row["freq_desc"].ToString()}", row["freq_unit"].ToString(), true));
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void GetRIType(DropDownList ddplist)
        {
            try
            {
                var sqlWhiteList = @"SELECT DISTINCT a.ri_type_id, a.ri_type_code, a.description FROM t_core_ri_type a inner join t_rpt_computation_rule_var c ON a.ri_type_id = c.ri_type_id";
                sqlWhiteList = "select * from [dbo].[fn_rtn_ri_type_computation_rule_adjustment] ('20191231')";

                using (SqlCommand cmd = new SqlCommand(sqlWhiteList, DatabaseOps.OpenSqlConnection()))
                {
                    cmd.CommandType = CommandType.Text;
                    _resultTable = _databaseOperations.GetDataTable(cmd);

                    foreach (DataRow row in _resultTable.Rows)
                    {
                        ddplist.Items.Add(new ListItem($"{row["ri_type_code"].ToString()} - {row["ri_type_name"].ToString()}", row["ri_type_id"].ToString(), true));
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void GetRI(DropDownList ddplist, int ritypeid)
        {
            DataTable dataTable = new DataTable();
            if (ritypeid > 0)
            {
                List<QueryStore> result = new List<QueryStore>();
                string sqlQuery = String.Format("SELECT a.ri_id, a.fullname, c.ri_type_id FROM t_core_reporting_institution a JOIN t_core_ri_mapping b  ON a.ri_id = b.ri_id JOIN t_core_ri_type c ON b.ri_type_id = c.ri_type_id WHERE c.ri_type_id = @ritypeid");
                using (SqlCommand command = new SqlCommand(sqlQuery, DatabaseOps.OpenSqlConnection()))
                {
                    command.CommandType = CommandType.Text;
                    command.Parameters.AddWithValue("@ritypeid", ritypeid);
                    _resultTable = _databaseOperations.GetDataTable(command);

                    foreach (DataRow row in _resultTable.Rows)
                    {
                        ddplist.Items.Add(new ListItem($"{row["fullname"].ToString()}", row["ri_id"].ToString(), true));
                    }
                }
            }
        }

        public void BindSpoolColumns(DropDownList ddplist, string columninclussion = "*")
        {
            DataTable dataTable = new DataTable();
            if (ddplist != null)
            {
                List<QueryStore> result = new List<QueryStore>();
                string sqlQuery = @"SELECT COLUMN_NAME, ORDINAL_POSITION FROM information_schema.columns WHERE TABLE_NAME = '##temp_table' ORDER BY COLUMN_NAME DESC";

                if (columninclussion != "*")
                    sqlQuery = $"SELECT COLUMN_NAME, ORDINAL_POSITION FROM information_schema.columns WHERE TABLE_NAME = '##temp_table' AND ORDINAL_POSITION NOT IN ({columninclussion}) ORDER BY COLUMN_NAME DESC";

                using (SqlCommand command = new SqlCommand(sqlQuery, new SqlConnection(ConfigurationManager.ConnectionStrings["OSMLiteDBConnectionString3"].ConnectionString)))
                {
                    command.CommandType = CommandType.Text;
                    _resultTable = _databaseOperations.GetDataTable(command);
                    var counter = _resultTable.Columns.Count;

                    foreach (DataRow row in _resultTable.Rows)
                    {
                        if(!row[1].ToString().Equals("1") || !row[1].ToString().Equals("2"))
                        {
                            ddplist.Items.Add(new ListItem($"{row["COLUMN_NAME"].ToString()}", $"{row["ORDINAL_POSITION"].ToString()}", true));
                        }
                    }
                }
            }
        }
        #endregion

        public DataTable CompRuleSpool(int scheduleid, int ruleid)
        {
            try
            {
                var sqlWhiteList = @"p_rpt_computation_rule_spool";
                using (SqlCommand cmd = new SqlCommand(sqlWhiteList, DatabaseOps.OpenSqlConnection()))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add(new SqlParameter("@schedule_id", SqlDbType.BigInt, 8, "schedule_id"));
                    cmd.Parameters.Add(new SqlParameter("@rule_id", SqlDbType.Int, 4, "rule_id"));

                    cmd.Parameters[0].Value = scheduleid;
                    cmd.Parameters[1].Value = ruleid;

                    _resultTable = _databaseOperations.GetDataTable(cmd);
                }

                return _resultTable;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public int CompuRuleMerge()
        {
            int returnMsg = 0;
            try
            {
                var proName = @"p_rpt_computation_rule_table_merge";
                using (SqlCommand cmd = new SqlCommand(proName, DatabaseOps.OpenSqlConnection()))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    SqlParameter param = new SqlParameter();
                    param.Direction = ParameterDirection.ReturnValue;
                    cmd.Parameters.Add(param);
                    int returnValue = _databaseOperations.ExecuteNonQuery(cmd);
                    returnValue = Convert.ToInt32(param.Value);
                    //if (!String.IsNullOrWhiteSpace(returnValue.ToString()) && returnValue.Equals(0))
                        return returnValue;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
