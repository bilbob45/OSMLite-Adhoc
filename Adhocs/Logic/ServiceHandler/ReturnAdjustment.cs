using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;
using System.ComponentModel.DataAnnotations;
using System.Web.UI.WebControls;
using System.Transactions;
using Adhocs.Logic.ServiceHandler;
using Adhocs.Logic.DatabaseHandler;
using Adhocs.Logic.Infrastructure;

namespace Adhocs.Logic.ServiceHandler
{
    public class ReturnAdjustmentModel
    {
        [Required]
        public int schedule_id { get; set; }
        [Required]
        public int run_id { get; set; }
        [Required]
        public String analyst_comment { get; set; }
        [Required]
        public int ri_id { get; set; }
        [Required]
        public DateTime work_collection_date { get; set; }
        public String CommandText { get; set; }
    }

    public class ReturnAdjustmentQB
    {
        public static String Query { get; set; }
        public enum QueryType
        {
            INSERT = 1,
            SELECT = 2
        }
        public void GetReturnAdjustmentQuery(string ritypeid)
        {
            
        }

        public static string GetQuery(string tablename, QueryType qtype)
        {
            if(qtype == QueryType.SELECT)
            {
                switch (tablename)
                {
                    case "cb.t_rtn_submission_mbr300":
                        Query = @"SELECT [id] AS 'Id', [schedule_id] AS 'Schedule Id', [work_collection_date] AS 'Work Collection Date' 
                                  ,[ri_id] AS 'RI Id', [ri_code] AS 'RI Code', [ri_name] AS 'RI Name'
                                  ,[item_code] AS 'Item Code'
                                  ,[item_desc] AS 'Item Description'
                                  ,[amt_lcy] AS 'Amount Local Currency'
                                  ,[submission_by] AS 'Submission By'
                                  ,[submission_date] AS 'Submission Date'
                                  ,[adj_reason] AS 'Adjustment Reason'
                                  ,[run_id] AS 'Run Id'
                              FROM [cb].[t_rtn_submission_mbr300]";
                        break;
                    case "dh.t_rtn_submission_mdhr300":
                        Query = @"SELECT[id] AS 'Id', [schedule_id] AS 'Schedule Id', [work_collection_date] AS 'Work Collection Date' 
                                  ,[ri_id] AS 'RI Id', [ri_code] AS 'RI Code', [ri_name] AS 'RI Name'
                                  ,[item_code] AS 'Item Code'
                                  ,[item_description] AS 'Item Description'
                                  ,[amount_1] AS 'Amount 1'
                                  ,[amount_2] AS 'Amount 2'
                                  ,[submission_by] AS 'Submission By'
                                  ,[submission_date] AS 'Submission Date'
                                  ,[adj_reason] AS 'Adjustment Reason'
                                  ,[run_id] AS 'Run Id'
                              FROM [dh].[t_rtn_submission_mdhr300]";
                        break;
                    case "nib.t_rtn_submission_mnbr300":
                        Query = @"SELECT [id] AS 'Id', [schedule_id] AS 'Schedule Id', [work_collection_date] AS 'Work Collection Date'
                                  ,[ri_id] AS 'RI Id', [ri_code] AS 'RI Code', [ri_name] AS 'RI Name'
                                  ,[item_code] AS 'Item Code'
                                  ,[item_desc] AS 'Item Description'
                                  ,[amt_lcy] AS 'Local Amount'
                                  ,[submission_by] AS 'Submission By'
                                  ,[submission_date] AS 'Submission Date'
                                  ,[adj_reason] AS 'Adjustment Reason'
                                  ,[run_id] AS 'Run Id'
                              FROM [nib].[t_rtn_submission_mnbr300]";
                        break;
                    case "cb.t_rtn_submission_mbr1000":
                        Query = @"SELECT [id] AS 'Id', [schedule_id] AS 'Schedule Id', [work_collection_date] AS 'Work Collection Date'
                                  ,[ri_id] AS 'RI Id', [ri_code] AS 'RI Code', [ri_name] AS 'RI Name'
                                  ,[item_code] AS 'Item Code'
                                  ,[item] AS 'Item Description'
                                  ,[latest_moth_lcy] AS 'Amount Local Curr.'
                                  ,[year_to_dt_lcy] AS 'Amount'
                                  ,[submission_by] AS 'Submission By'
                                  ,[submission_date] AS 'Submission Date'
                                  ,[adj_reason] AS 'Adjustment Reason'
                                  ,[run_id] AS 'Run Id'
                              FROM [cb].[t_rtn_submission_mbr1000]";
                        break;
                    case "dh.t_rtn_submission_mdhr1000":
                        Query = @"SELECT [id] AS 'Id', [schedule_id] AS 'Schedule Id', [work_collection_date] AS 'Work Collection Date'
                              ,[ri_id] AS 'RI Id', [ri_code] AS 'RI Code', [ri_name] AS 'RI Name'
                              ,[item_code] AS 'Item Code'
                              ,[item_desc] AS 'Item Description'
                              ,[latest_month] AS 'Latest Month'
                              ,[year_to_date_ngn] AS 'Year to Date(N)'
                              ,[submission_by] AS 'Submission By'
                              ,[submission_date] AS 'Submission Date'
                              ,[adj_reason] AS 'Adjustment Reason'
                              ,[run_id] AS 'Run Id'
                          FROM [dh].[t_rtn_submission_mdhr1000]";
                        break;
                    case "nib.t_rtn_submission_mnbr1000":
                        Query = @"SELECT [id] AS 'Id', [schedule_id] AS 'Schedule Id', [work_collection_date] AS 'Work Collection Date'
                          ,[ri_id] AS 'RI Id', [ri_code] AS 'RI Code', [ri_name] AS 'RI Name'
                          ,[item_code] AS 'Item Code'
                          ,[item] AS 'Item Description'
                          ,[latest_month] AS 'Latest Month'
                          ,[year_to_date_ngn] AS 'Year to Date(N)'
                          ,[submission_by] AS 'Submission By'
                          ,[submission_date] AS 'Submission Date'
                          ,[adj_reason] AS 'Adjustment Reason'
                          ,[run_id] AS 'Run Id'
                      FROM [nib].[t_rtn_submission_mnbr1000]";
                        break;
                    default:
                        Query = string.Empty;
                        break;
                }
            }
            else if(qtype == QueryType.INSERT)
            {
                switch (tablename)
                {
                    case "cb.t_rtn_submission_mbr300":
                        Query = @"INSERT INTO cb.t_rtn_submission_mbr300                    
                                    VALUES (@schedule_id, @work_collection_date, @ri_id, @ri_code, @ri_name
                                  ,@item_code
                                  ,@item_desc
                                  ,@amt_lcy
                                  ,@submission_by
                                  ,@submission_date
                                  ,@adj_reason
                                  ,@run_id)";
                        break;
                    case "dh.t_rtn_submission_mdhr300":
                        Query = @"INSERT INTO dh.t_rtn_submission_mdhr300                   
                                    VALUES (@schedule_id, @work_collection_date, @ri_id, @ri_code, @ri_name
                                  ,@item_code
                                  ,@item_description
                                  ,@amount_1
                                  ,@amount_2
                                  ,@submission_by
                                  ,@submission_date
                                  ,@adj_reason
                                  ,@run_id)";
                        break;
                    case "nib.t_rtn_submission_mnbr300":
                        Query = @"INSERT INTO nib.t_rtn_submission_mnbr300                  
                                    VALUES (@schedule_id, @work_collection_date, @ri_id, @ri_code, @ri_name
                                  ,@item_code
                                  ,@item_desc
                                  ,@amt_lcy
                                  ,@submission_by
                                  ,@submission_date
                                  ,@adj_reason
                                  ,@run_id)";
                        break;
                    case "cb.t_rtn_submission_mbr1000":
                        Query = @"INSERT INTO cb.t_rtn_submission_mbr1000                   
                                    VALUES (@schedule_id, @work_collection_date, @ri_id, @ri_code, @ri_name
                                  ,@item_code
                                  ,@item
                                  ,@latest_moth_lcy
                                  ,@year_to_dt_lcy
                                  ,@submission_by
                                  ,@submission_date
                                  ,@adj_reason
                                  ,@run_id)";
                        break;
                    case "dh.t_rtn_submission_mdhr1000":
                        Query = @"INSERT INTO dh.t_rtn_submission_mdhr1000                  
                                    VALUES (@schedule_id, @work_collection_date, @ri_id, @ri_code, @ri_name
                                  ,@item_code
                                  ,@item_desc
                                  ,@latest_month
                                  ,@year_to_date_ngn
                                  ,@submission_by
                                  ,@submission_date
                                  ,@adj_reason
                                  ,@run_id)";
                        break;
                    case "nib.t_rtn_submission_mnbr1000":
                        Query = @"INSERT INTO nib.t_rtn_submission_mnbr1000                 
                                    VALUES (@schedule_id, @work_collection_date, @ri_id, @ri_code, @ri_name
                                  ,@item_code
                                  ,@item
                                  ,@latest_month
                                  ,@year_to_date_ngn
                                  ,@submission_by
                                  ,@submission_date
                                  ,@adj_reason
                                  ,@run_id)";
                        break;
                    default:
                        Query = string.Empty;
                        break;
                }
            }
            else
            {
                Query = null;
            }
            return Query;
        }
    }

    public class ReturnAdjustment
    {
        public String CommandText { get; set; }
        public ReturnAdjustment()
        {
        }

        public bool IsRestrictedItem(int itemcode)
        {
            DatabaseOps ops = new DatabaseOps();
            var commandQuery = "select item_code from t_dis_submission_reference_calc where item_code = @itemcode";
            bool canEdit = false;
            using (SqlCommand cmd = new SqlCommand(commandQuery, DatabaseOps.OpenSqlConnection()))
            {
                cmd.CommandType = CommandType.Text;
                cmd.Parameters.Add("@itemcode", SqlDbType.Int).Value = itemcode;

                object result = cmd.ExecuteScalar();
                if (result == null)
                    canEdit = true;
                else
                    canEdit = false;
            }

            return canEdit;
        }

        public List<string> IsRestrictedItem()
        {
            DatabaseOps ops = new DatabaseOps();
            List<string> canEdit = new List<string>();
            var commandQuery = "select item_code from t_dis_submission_reference_calc";
            using (SqlCommand cmd = new SqlCommand(commandQuery, DatabaseOps.OpenSqlConnection()))
            {
                cmd.CommandType = CommandType.Text;
                canEdit = DatabaseOps.ConvertToStringList(ops.GetDataTable(cmd));
            }
            return canEdit;
        }

        public DataTable GetScheduleForAnalystAdjustment(ReturnAdjustmentModel rtobject)
        {
            String commandText = "SELECT schedule_id, max(run_id) AS run_id, MAX(analyst_comment) AS analyst_comment FROM fn_get_schedule_for_analyst_adjustment(@ri_id, @work_collection_date) group by schedule_id";
            this.CommandText = commandText;
            using (SqlCommand cmd = new SqlCommand(commandText, DatabaseOps.OpenSqlConnection()))
            {
                cmd.CommandType = CommandType.Text;
                cmd.Parameters.AddWithValue("@ri_id", rtobject.ri_id.ToString());
                cmd.Parameters.Add("@work_collection_date", SqlDbType.DateTime).Value = rtobject.work_collection_date;
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                DataTable dataTable = new DataTable();
                adapter.Fill(dataTable);
                return dataTable;
            }
        }

        public DataTable MBR300ReturnAdjustment(String tablename, String riid, String scheduleid, string runid)
        {
            var plainQuery = ReturnAdjustmentQB.GetQuery(tablename, ReturnAdjustmentQB.QueryType.SELECT);
            //
            //Check if runid is null or empty or white space
            //
            bool runidStatus = String.IsNullOrWhiteSpace(runid);
            this.CommandText = ((runid == "0" || runid.Equals("0")) || runidStatus == true) ? String.Concat(plainQuery, String.Format(" WHERE (ri_id = {0} AND schedule_id = {1}) AND run_id IS NULL", riid, scheduleid)) : String.Concat(plainQuery, String.Format(" WHERE (ri_id = {0} AND schedule_id = {1}) AND run_id = {2}", riid, scheduleid, runid));

            using (SqlConnection con = new SqlConnection(ConnectionString.GetConnectionString()))
            {
                using (SqlCommand cmd = new SqlCommand(this.CommandText, con))
                {
                    cmd.CommandType = CommandType.Text;
                    if (con.State == ConnectionState.Closed)
                        con.Open();

                    SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                    DataTable dataTable = new DataTable();
                    adapter.Fill(dataTable);

                    con.Close();
                    return dataTable;
                }
            }
        }

        public DataTable MBR1000ReturnAdjustment(String tablename, String riid, String scheduleid, string runid)
        {
            var plainQuery = ReturnAdjustmentQB.GetQuery(tablename, ReturnAdjustmentQB.QueryType.SELECT);
            //
            //Check if runid is null or empty or white space
            //
            bool runidStatus = String.IsNullOrWhiteSpace(runid);
            this.CommandText = ((runid == "0" || runid.Equals("0")) || runidStatus == true) ? String.Concat(plainQuery, String.Format(" WHERE (ri_id = {0} AND schedule_id = {1}) AND run_id IS NULL", riid, scheduleid)) : String.Concat(plainQuery, String.Format(" WHERE (ri_id = {0} AND schedule_id = {1}) AND run_id = {2}", riid, scheduleid, runid));

            using (SqlConnection con = new SqlConnection(ConnectionString.GetConnectionString()))
            {
                using (SqlCommand cmd = new SqlCommand(this.CommandText, con))
                {
                    cmd.CommandType = CommandType.Text;
                    if (con.State == ConnectionState.Closed)
                        con.Open();

                    SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                    DataTable dataTable = new DataTable();
                    adapter.Fill(dataTable);

                    con.Close();
                    return dataTable;
                }
            }
        }

        public String GetAjustmentTable(String ritypeid, string tablename)
        {
            String tableName = "";
            //
            //convert RI Type ID (eg, 3, 6, 7) to code (eg, CB, DH, NIB) to formulate a table (eg cb.t_rtn_submission_mbr300 or dh.t_rtn_submission_mnbr300)
            //
            var ritypecode = new TCoreRiType().GetRICodeByID(ritypeid).ToLower();
            tableName = string.Concat(ritypecode, ".", SharedConst.SHARED_SUBMISSION_TABLE_NAME, tablename).ToLower();
            return tableName;
            #region Uncomment if code breaks
            //switch (ritypecode)
            //{
            //    case "cb":
            //        returnCode = string.Concat(SharedConst.SHARED_SUBMISSION_TABLE_NAME, tablename);
            //        break;
            //    case "dh":
            //        returnCode = string.Concat(SharedConst.SHARED_SUBMISSION_TABLE_NAME, tablename);
            //        break;
            //    case "nib":
            //        returnCode = string.Concat(SharedConst.SHARED_SUBMISSION_TABLE_NAME, tablename);
            //        break;
            //    default:
            //        returnCode = string.Concat(SharedConst.SHARED_SUBMISSION_TABLE_NAME, tablename);
            //        break;
            //}
            //return String.Concat(ritypecode, ".", returnCode).ToLower();
            #endregion
        }

        public int GetIncrementRunId(string scheduleid)
        {
            string commandText = "SELECT  max(ISNULL(run_id,0)) + 1 FROM t_rpt_computation_rule_adjustment WHERE schedule_id = @schedule_id";
            int row;
            using (SqlConnection con = new SqlConnection(ConnectionString.GetConnectionString()))
            {
                using (SqlCommand cmd = new SqlCommand(commandText, con))
                {
                    cmd.CommandType = CommandType.Text;
                    cmd.Parameters.AddWithValue("@schedule_id", scheduleid);
                    if (con.State == ConnectionState.Closed)
                        con.Open();

                    String x = cmd.ExecuteScalar().ToString();
                    if (string.IsNullOrWhiteSpace(x) || x.Length < 1)
                        row = 1;
                    else
                        row = Convert.ToInt32(x);
                }
            }
            return row;
        }

        public int SaveReturnAdjustment(GridView grid300, GridView grid1000, string tablename300, string tablename1000, string scheduleid, string runid, string analystcomment)
        {
            int rows = 0;
            using (TransactionScope sc = new TransactionScope(TransactionScopeOption.Required))
            {
                using (SqlConnection con = new SqlConnection(ConnectionString.GetConnectionString()))
                {
                    if (con.State == ConnectionState.Closed)
                        con.Open();

                    String commandText1 = "INSERT INTO t_rpt_computation_rule_adjustment (schedule_id, run_id, analyst_comment) VALUES (@schedule_id, @run_id, @analyst_comment)";
                    using (SqlCommand cmd = new SqlCommand(commandText1, con))
                    {
                        cmd.CommandType = CommandType.Text;
                        cmd.Parameters.AddWithValue("@schedule_id", scheduleid);
                        cmd.Parameters.AddWithValue("@run_id", runid);
                        cmd.Parameters.AddWithValue("@analyst_comment", analystcomment);
                        rows = cmd.ExecuteNonQuery();
                    }

                    String commandText2 = "";
                    foreach (GridViewRow grdview in grid300.Rows)
                    {
                        //Generate the SQL query use to insert data
                        commandText2 = ReturnAdjustmentQB.GetQuery(tablename300, ReturnAdjustmentQB.QueryType.INSERT);

                        using (SqlCommand cmd2 = new SqlCommand(commandText2, con))
                        {
                            cmd2.CommandType = CommandType.Text;
                            //cmd2.Parameters.AddWithValue("@id", grdview.Cells[1].Text);
                            cmd2.Parameters.AddWithValue("@schedule_id", grdview.Cells[2].Text);
                            cmd2.Parameters.Add("@work_collection_date", SqlDbType.DateTime).SqlValue = Convert.ToDateTime(grdview.Cells[3].Text);
                            cmd2.Parameters.AddWithValue("@ri_id", grdview.Cells[4].Text);
                            cmd2.Parameters.AddWithValue("@ri_code", grdview.Cells[5].Text);
                            cmd2.Parameters.AddWithValue("@ri_name", grdview.Cells[6].Text);
                            cmd2.Parameters.AddWithValue("@item_code", grdview.Cells[7].Text);

                            if(tablename300.Equals("dh.t_rtn_submission_mdhr300"))
                            {
                                cmd2.Parameters.AddWithValue("@item_description", grdview.Cells[8].Text);
                                //cmd2.Parameters.AddWithValue("@amount_1", grdview.Cells[9].Text.Replace("₦", "").Replace(",",""));
                                //cmd2.Parameters.AddWithValue("@amount_2", grdview.Cells[10].Text.Replace("₦", "").Replace(",", ""));

                                cmd2.Parameters.Add("@amount_1", SqlDbType.Decimal).SqlValue = grdview.Cells[9].Text.Replace("₦", "").Replace(",", "");
                                cmd2.Parameters.Add("@amount_2", SqlDbType.Decimal).SqlValue = grdview.Cells[10].Text.Replace("₦", "").Replace(",", "");

                                cmd2.Parameters.AddWithValue("@submission_by", grdview.Cells[11].Text);
                                cmd2.Parameters.Add("@submission_date", SqlDbType.DateTime).SqlValue = Convert.ToDateTime(grdview.Cells[12].Text);
                                cmd2.Parameters.AddWithValue("@adj_reason", grdview.Cells[13].Text);
                                cmd2.Parameters.AddWithValue("@run_id", runid); //14
                            }
                            else
                            {
                                cmd2.Parameters.AddWithValue("@item_desc", grdview.Cells[8].Text);
                                cmd2.Parameters.Add("@amt_lcy", SqlDbType.Decimal).SqlValue = grdview.Cells[9].Text.Replace("₦", "").Replace(",", "");
                                cmd2.Parameters.AddWithValue("@submission_by", grdview.Cells[10].Text);
                                cmd2.Parameters.Add("@submission_date", SqlDbType.DateTime).SqlValue = Convert.ToDateTime(grdview.Cells[11].Text);
                                cmd2.Parameters.AddWithValue("@adj_reason", grdview.Cells[12].Text);
                                cmd2.Parameters.AddWithValue("@run_id", runid); //13
                            }                        

                            this.CommandText = cmd2.CommandText;

                            rows += cmd2.ExecuteNonQuery();
                        }
                    }

                    String commandText3 = "";
                    foreach (GridViewRow grdview in grid1000.Rows)
                    {
                        commandText3 = ReturnAdjustmentQB.GetQuery(tablename1000, ReturnAdjustmentQB.QueryType.INSERT);

                        using (SqlCommand cmd3 = new SqlCommand(commandText3, con))
                        {
                            cmd3.CommandType = CommandType.Text;
                            //cmd3.Parameters.AddWithValue("@id", grdview.Cells[1].Text);
                            cmd3.Parameters.AddWithValue("@schedule_id", grdview.Cells[2].Text);
                            cmd3.Parameters.Add("@work_collection_date", SqlDbType.DateTime).SqlValue = Convert.ToDateTime(grdview.Cells[3].Text);
                            cmd3.Parameters.AddWithValue("@ri_id", grdview.Cells[4].Text);
                            cmd3.Parameters.AddWithValue("@ri_code", grdview.Cells[5].Text);
                            cmd3.Parameters.AddWithValue("@ri_name", grdview.Cells[6].Text);
                            cmd3.Parameters.AddWithValue("@item_code", grdview.Cells[7].Text);

                            if (tablename1000.Equals("cb.t_rtn_submission_mbr1000"))
                            {
                                cmd3.Parameters.AddWithValue("@item", grdview.Cells[8].Text);
                                //cmd3.Parameters.AddWithValue("@latest_moth_lcy", grdview.Cells[9].Text.Replace("₦", "").Replace(",", ""));
                                //cmd3.Parameters.AddWithValue("@year_to_dt_lcy", grdview.Cells[10].Text.Replace("₦", "").Replace(",", ""));

                                cmd3.Parameters.Add("@latest_moth_lcy", SqlDbType.Decimal).SqlValue = grdview.Cells[9].Text.Replace("₦", "").Replace(",", "");
                                cmd3.Parameters.Add("@year_to_dt_lcy", SqlDbType.Decimal).SqlValue = grdview.Cells[10].Text.Replace("₦", "").Replace(",", "");
                            }
                            else if (tablename1000.Equals("dh.t_rtn_submission_mdhr1000"))
                            {
                                cmd3.Parameters.AddWithValue("@item_desc", grdview.Cells[8].Text);
                                cmd3.Parameters.Add("@latest_month", SqlDbType.Decimal).SqlValue = grdview.Cells[9].Text.Replace("₦", "").Replace(",", "");
                                cmd3.Parameters.Add("@year_to_date_ngn", SqlDbType.Decimal).SqlValue = grdview.Cells[10].Text.Replace("₦", "").Replace(",", "");
                            }
                            else if(tablename1000.Equals("nib.t_rtn_submission_mnbr1000"))
                            {
                                cmd3.Parameters.AddWithValue("@item", grdview.Cells[8].Text);
                                cmd3.Parameters.Add("@latest_month", SqlDbType.Decimal).SqlValue = grdview.Cells[9].Text.Replace("₦", "").Replace(",", "");
                                cmd3.Parameters.Add("@year_to_date_ngn", SqlDbType.Decimal).SqlValue = grdview.Cells[10].Text.Replace("₦", "").Replace(",", "");
                            }

                            cmd3.Parameters.AddWithValue("@submission_by", grdview.Cells[11].Text);
                            cmd3.Parameters.Add("@submission_date", SqlDbType.DateTime).SqlValue = Convert.ToDateTime(grdview.Cells[12].Text);
                            cmd3.Parameters.AddWithValue("@adj_reason", grdview.Cells[13].Text);
                            cmd3.Parameters.AddWithValue("@run_id", runid); //14

                            rows += cmd3.ExecuteNonQuery();
                        }
                    }

                    sc.Complete();
                    con.Close();
                    return rows;
                }
            }
        }
    }
}