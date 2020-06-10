using Adhocs.Logic.DatabaseHandler;
using Adhocs.Logic.Objects;
using Adhocs.Logic.ServiceHandler;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Reflection;
using System.Transactions;
using System.Web;

namespace Adhocs.Logic.ServiceHandler
{
    public class TRPTComputationValueTableHandler
    {
        DatabaseOps _databaseOperations;
        RuleVarianceAdjustment _ruleVarianceAdjustment; //= new RuleVarianceAdjustment();
        //DataTable _resultTable;
        int rowsAffected = 0;
        int mergeAffected = 0;

        public TRPTComputationValueTableObject ComputationValueTable { get; set; }

        public TRPTComputationValueTableHandler()
        {
            _databaseOperations = new DatabaseOps();
            _ruleVarianceAdjustment = new RuleVarianceAdjustment();
            //_resultTable = new DataTable();
        }

        public Dictionary<string, string> GetVersionIdNRunId(string comprulename, int ritypeid, int riid, string frequency, int scheduleid, DateTime wcdate)
        {
            Dictionary<string, string> returnedvalues = new Dictionary<string, string>();
            string sqlText = $"SELECT run_id, version_id FROM t_rpt_computation_value_table WHERE computation_rule = '{comprulename}' AND ri_type_id = {ritypeid} and ri_id = {riid} and freq_unit = '{frequency}' and schedule_id = {scheduleid}";

            sqlText = $"SELECT DISTINCT run_id, version_id FROM t_rpt_computation_value_table WHERE computation_rule = @computation_rule AND ri_type_id = @ri_type_id AND ri_id = @ri_id AND freq_unit = @freq_unit AND schedule_id = @schedule_id"; //AND work_collection_date = @work_collection_date";

            using (SqlCommand cmd = new SqlCommand(sqlText, DatabaseOps.OpenSqlConnection()))
            {
                cmd.CommandType = CommandType.Text;
                cmd.Parameters.AddWithValue("@computation_rule", comprulename);
                cmd.Parameters.AddWithValue("@ri_type_id", ritypeid);
                cmd.Parameters.AddWithValue("@ri_id", riid);
                cmd.Parameters.AddWithValue("@freq_unit", frequency);
                cmd.Parameters.AddWithValue("@schedule_id", scheduleid);
                //cmd.Parameters.Add("@work_collection_date", SqlDbType.DateTime).Value = wcdate;
                var reader = _databaseOperations.ReadData(cmd);
                while (reader.Read())
                {
                    if(reader.HasRows)
                    {
                        returnedvalues.Add("run_id", reader["run_id"].ToString());
                        returnedvalues.Add("version_id", reader["version_id"].ToString());
                    }
                }

                reader.Close();

                return returnedvalues;
            }
        }

        public string GetRunId(int ritypeid, int riid, string frequency, DateTime wcdate, string comprulename, int scheduleid)
        {
            string sqlText = $"SELECT run_id FROM t_rpt_computation_value_table WHERE computation_rule = '{comprulename}' AND ri_type_id = {ritypeid} and ri_id = {riid} and freq_unit = '{frequency}' and schedule_id = {scheduleid}"; //and work_collection_date = '{wcdate}';
            return _databaseOperations.GetData(sqlText);
        }

        public int SaveSimpleRule(TRPTComputationValueTableObject trptcomputationvaluetableobject)
        {
            //using (TransactionScope sc = new TransactionScope(TransactionScopeOption.Required))
            //{
                var sqlText = @"INSERT INTO t_rpt_computation_value_table_temp (computation_rule, version_id, ri_type_id, ri_id, work_collection_date, freq_unit, schedule_id, run_id, row_code, column_1, comment,last_modified, modified_by) VALUES(@computation_rule, @version_id, @ri_type_id, @ri_id, @work_collection_date, @freq_unit, @schedule_id, @run_id, @row_code, @column_1, @comment, @last_modified, @modified_by)";
                using (SqlCommand cmd = new SqlCommand(sqlText, DatabaseOps.OpenSqlConnection()))
                {
                    cmd.CommandType = CommandType.Text;
                    cmd.Parameters.AddWithValue("@computation_rule", trptcomputationvaluetableobject.computation_rule);
                    cmd.Parameters.AddWithValue("@version_id", trptcomputationvaluetableobject.version_id);
                    cmd.Parameters.AddWithValue("@ri_type_id", trptcomputationvaluetableobject.ri_type_id);
                    cmd.Parameters.AddWithValue("@ri_id", trptcomputationvaluetableobject.ri_id);
                    cmd.Parameters.Add("@work_collection_date", SqlDbType.DateTime).Value = trptcomputationvaluetableobject.work_collection_date;
                    cmd.Parameters.AddWithValue("@freq_unit", trptcomputationvaluetableobject.freq_unit);
                    cmd.Parameters.AddWithValue("@schedule_id", trptcomputationvaluetableobject.schedule_id);
                    cmd.Parameters.AddWithValue("@run_id", trptcomputationvaluetableobject.run_id);
                    cmd.Parameters.AddWithValue("@row_code", trptcomputationvaluetableobject.row_code);
                    cmd.Parameters.AddWithValue("@column_1", trptcomputationvaluetableobject.column_1);

                    if (string.IsNullOrWhiteSpace(trptcomputationvaluetableobject.comment))
                        cmd.Parameters.AddWithValue("@comment", DBNull.Value);
                    else
                        cmd.Parameters.AddWithValue("@comment", trptcomputationvaluetableobject.comment);

                    cmd.Parameters.Add("@last_modified", SqlDbType.DateTime).Value = DateTime.Now.ToShortDateString();
                    cmd.Parameters.AddWithValue("@modified_by", trptcomputationvaluetableobject.modified_by);

                    rowsAffected = cmd.ExecuteNonQuery();

                    //Call the comprulemerge procedure to for deep merging of column values
                    mergeAffected = _ruleVarianceAdjustment.CompuRuleMerge();

                    if (rowsAffected > 0 && mergeAffected == 0)
                        return rowsAffected + mergeAffected;
                    else
                        return 0;
                }

                //sc.Complete();
        }    

        public int SaveCompoundRule(TRPTComputationValueTableObject trptcomputationvaluetableobject)
        {
            var sqlText = @"INSERT INTO t_rpt_computation_value_table_temp (computation_rule, version_id, ri_type_id, ri_id, work_collection_date, freq_unit, schedule_id, run_id, row_code, column_1, column_2, column_3, column_4, column_5, column_6, column_7, column_8, column_9, column_10, column_11, column_12, column_13, column_14, column_15, column_16, column_17, column_18,column_19,column_20,column_21,column_22,column_23,column_24,column_25,column_26,column_27,column_28,column_29,column_30,column_31,column_32,column_33,column_34,column_35,column_36,column_37,column_38,column_39,column_40,comment,last_modified, modified_by) 
                        VALUES(@computation_rule, @version_id, @ri_type_id, @ri_id, @work_collection_date, @freq_unit, @schedule_id, @run_id, @row_code, @column_1, @column_2, @column_3, @column_4, @column_5, @column_6, @column_7, @column_8, @column_9, @column_10, @column_11, @column_12, @column_13, @column_14, @column_15, @column_16, @column_17, @column_18, @column_19, @column_20,  @column_21,  @column_22,  @column_23,  @column_24,  @column_25,  @column_26,  @column_27,  @column_28,  @column_29,  @column_30,  @column_31,  @column_32,  @column_33,  @column_34,  @column_35,  @column_36,  @column_37,  @column_38,  @column_39,  @column_40,@comment,@last_modified, @modified_by)";
            using (SqlCommand cmd = new SqlCommand(sqlText, DatabaseOps.OpenSqlConnection()))
            {
                cmd.CommandType = CommandType.Text;

                cmd.Parameters.AddWithValue("@computation_rule", trptcomputationvaluetableobject.computation_rule);
                cmd.Parameters.AddWithValue("@version_id", trptcomputationvaluetableobject.version_id);
                cmd.Parameters.AddWithValue("@ri_type_id", trptcomputationvaluetableobject.ri_type_id);
                cmd.Parameters.AddWithValue("@ri_id", trptcomputationvaluetableobject.ri_id);
                //cmd.Parameters.Add("@work_collection_date", SqlDbType.DateTime).SqlValue = trptcomputationvaluetableobject.work_collection_date;
                cmd.Parameters.Add("@work_collection_date", SqlDbType.DateTime).Value = trptcomputationvaluetableobject.work_collection_date;
                cmd.Parameters.AddWithValue("@freq_unit", trptcomputationvaluetableobject.freq_unit);
                cmd.Parameters.AddWithValue("@schedule_id", trptcomputationvaluetableobject.schedule_id);
                cmd.Parameters.AddWithValue("@run_id", trptcomputationvaluetableobject.run_id);
                cmd.Parameters.AddWithValue("@row_code", trptcomputationvaluetableobject.row_code);
                cmd.Parameters.AddWithValue("@column_1", trptcomputationvaluetableobject.column_1);

                #region column parameters
                if (string.IsNullOrWhiteSpace(trptcomputationvaluetableobject.comment))
                    cmd.Parameters.AddWithValue("@comment", DBNull.Value);
                else
                    cmd.Parameters.AddWithValue("@comment", trptcomputationvaluetableobject.comment);

                if (string.IsNullOrWhiteSpace(trptcomputationvaluetableobject.column_2))
                    cmd.Parameters.AddWithValue("@column_2", DBNull.Value);
                else
                    cmd.Parameters.AddWithValue("@column_2", trptcomputationvaluetableobject.column_2);

                if (string.IsNullOrWhiteSpace(trptcomputationvaluetableobject.column_3))
                    cmd.Parameters.AddWithValue("@column_3", DBNull.Value);
                else
                    cmd.Parameters.AddWithValue("@column_3", trptcomputationvaluetableobject.column_3);

                if (string.IsNullOrWhiteSpace(trptcomputationvaluetableobject.column_4))
                    cmd.Parameters.AddWithValue("@column_4", DBNull.Value);
                else
                    cmd.Parameters.AddWithValue("@column_4", trptcomputationvaluetableobject.column_4);

                if (string.IsNullOrWhiteSpace(trptcomputationvaluetableobject.column_5))
                    cmd.Parameters.AddWithValue("@column_5", DBNull.Value);
                else
                    cmd.Parameters.AddWithValue("@column_5", trptcomputationvaluetableobject.column_5);

                if (string.IsNullOrWhiteSpace(trptcomputationvaluetableobject.column_6))
                    cmd.Parameters.AddWithValue("@column_6", DBNull.Value);
                else
                    cmd.Parameters.AddWithValue("@column_6", trptcomputationvaluetableobject.column_6);

                if (string.IsNullOrWhiteSpace(trptcomputationvaluetableobject.column_7))
                    cmd.Parameters.AddWithValue("@column_7", DBNull.Value);
                else
                    cmd.Parameters.AddWithValue("@column_7", trptcomputationvaluetableobject.column_7);

                if (string.IsNullOrWhiteSpace(trptcomputationvaluetableobject.column_8))
                    cmd.Parameters.AddWithValue("@column_8", DBNull.Value);
                else
                    cmd.Parameters.AddWithValue("@column_8", trptcomputationvaluetableobject.column_8);

                if (string.IsNullOrWhiteSpace(trptcomputationvaluetableobject.column_9))
                    cmd.Parameters.AddWithValue("@column_9", DBNull.Value);
                else
                    cmd.Parameters.AddWithValue("@column_9", trptcomputationvaluetableobject.column_9);

                if (string.IsNullOrWhiteSpace(trptcomputationvaluetableobject.column_10))
                    cmd.Parameters.AddWithValue("@column_10", DBNull.Value);
                else
                    cmd.Parameters.AddWithValue("@column_10", trptcomputationvaluetableobject.column_10);

                if (string.IsNullOrWhiteSpace(trptcomputationvaluetableobject.column_11))
                    cmd.Parameters.AddWithValue("@column_11", DBNull.Value);
                else
                    cmd.Parameters.AddWithValue("@column_11", trptcomputationvaluetableobject.column_11);

                if (string.IsNullOrWhiteSpace(trptcomputationvaluetableobject.column_12))
                    cmd.Parameters.AddWithValue("@column_12", DBNull.Value);
                else
                    cmd.Parameters.AddWithValue("@column_12", trptcomputationvaluetableobject.column_12);

                if (string.IsNullOrWhiteSpace(trptcomputationvaluetableobject.column_13))
                    cmd.Parameters.AddWithValue("@column_13", DBNull.Value);
                else
                    cmd.Parameters.AddWithValue("@column_13", trptcomputationvaluetableobject.column_13);

                if (string.IsNullOrWhiteSpace(trptcomputationvaluetableobject.column_14))
                    cmd.Parameters.AddWithValue("@column_14", DBNull.Value);
                else
                    cmd.Parameters.AddWithValue("@column_14", trptcomputationvaluetableobject.column_14);

                if (string.IsNullOrWhiteSpace(trptcomputationvaluetableobject.column_15))
                    cmd.Parameters.AddWithValue("@column_15", DBNull.Value);
                else
                    cmd.Parameters.AddWithValue("@column_15", trptcomputationvaluetableobject.column_15);

                if (string.IsNullOrWhiteSpace(trptcomputationvaluetableobject.column_16))
                    cmd.Parameters.AddWithValue("@column_16", DBNull.Value);
                else
                    cmd.Parameters.AddWithValue("@column_16", trptcomputationvaluetableobject.column_16);

                if (string.IsNullOrWhiteSpace(trptcomputationvaluetableobject.column_17))
                    cmd.Parameters.AddWithValue("@column_17", DBNull.Value);
                else
                    cmd.Parameters.AddWithValue("@column_17", trptcomputationvaluetableobject.column_17);

                if (string.IsNullOrWhiteSpace(trptcomputationvaluetableobject.column_18))
                    cmd.Parameters.AddWithValue("@column_18", DBNull.Value);
                else
                    cmd.Parameters.AddWithValue("@column_18", trptcomputationvaluetableobject.column_18);

                if (string.IsNullOrWhiteSpace(trptcomputationvaluetableobject.column_19))
                    cmd.Parameters.AddWithValue("@column_19", DBNull.Value);
                else
                    cmd.Parameters.AddWithValue("@column_19", trptcomputationvaluetableobject.column_19);

                if (string.IsNullOrWhiteSpace(trptcomputationvaluetableobject.column_20))
                    cmd.Parameters.AddWithValue("@column_20", DBNull.Value);
                else
                    cmd.Parameters.AddWithValue("@column_20", trptcomputationvaluetableobject.column_20);

                if (string.IsNullOrWhiteSpace(trptcomputationvaluetableobject.column_21))
                    cmd.Parameters.AddWithValue("@column_21", DBNull.Value);
                else
                    cmd.Parameters.AddWithValue("@column_21", trptcomputationvaluetableobject.column_21);

                if (string.IsNullOrWhiteSpace(trptcomputationvaluetableobject.column_22))
                    cmd.Parameters.AddWithValue("@column_22", DBNull.Value);
                else
                    cmd.Parameters.AddWithValue("@column_22", trptcomputationvaluetableobject.column_22);

                if (string.IsNullOrWhiteSpace(trptcomputationvaluetableobject.column_23))
                    cmd.Parameters.AddWithValue("@column_23", DBNull.Value);
                else
                    cmd.Parameters.AddWithValue("@column_23", trptcomputationvaluetableobject.column_23);

                if (string.IsNullOrWhiteSpace(trptcomputationvaluetableobject.column_24))
                    cmd.Parameters.AddWithValue("@column_24", DBNull.Value);
                else
                    cmd.Parameters.AddWithValue("@column_24", trptcomputationvaluetableobject.column_24);

                if (string.IsNullOrWhiteSpace(trptcomputationvaluetableobject.column_25))
                    cmd.Parameters.AddWithValue("@column_25", DBNull.Value);
                else
                    cmd.Parameters.AddWithValue("@column_25", trptcomputationvaluetableobject.column_25);

                if (string.IsNullOrWhiteSpace(trptcomputationvaluetableobject.column_26))
                    cmd.Parameters.AddWithValue("@column_26", DBNull.Value);
                else
                    cmd.Parameters.AddWithValue("@column_26", trptcomputationvaluetableobject.column_26);

                if (string.IsNullOrWhiteSpace(trptcomputationvaluetableobject.column_27))
                    cmd.Parameters.AddWithValue("@column_27", DBNull.Value);
                else
                    cmd.Parameters.AddWithValue("@column_27", trptcomputationvaluetableobject.column_27);

                if (string.IsNullOrWhiteSpace(trptcomputationvaluetableobject.column_28))
                    cmd.Parameters.AddWithValue("@column_28", DBNull.Value);
                else
                    cmd.Parameters.AddWithValue("@column_28", trptcomputationvaluetableobject.column_28);

                if (string.IsNullOrWhiteSpace(trptcomputationvaluetableobject.column_29))
                    cmd.Parameters.AddWithValue("@column_29", DBNull.Value);
                else
                    cmd.Parameters.AddWithValue("@column_29", trptcomputationvaluetableobject.column_29);

                if (string.IsNullOrWhiteSpace(trptcomputationvaluetableobject.column_30))
                    cmd.Parameters.AddWithValue("@column_30", DBNull.Value);
                else
                    cmd.Parameters.AddWithValue("@column_30", trptcomputationvaluetableobject.column_30);

                if (string.IsNullOrWhiteSpace(trptcomputationvaluetableobject.column_31))
                    cmd.Parameters.AddWithValue("@column_31", DBNull.Value);
                else
                    cmd.Parameters.AddWithValue("@column_31", trptcomputationvaluetableobject.column_31);

                if (string.IsNullOrWhiteSpace(trptcomputationvaluetableobject.column_32))
                    cmd.Parameters.AddWithValue("@column_32", DBNull.Value);
                else
                    cmd.Parameters.AddWithValue("@column_32", trptcomputationvaluetableobject.column_32);

                if (string.IsNullOrWhiteSpace(trptcomputationvaluetableobject.column_33))
                    cmd.Parameters.AddWithValue("@column_33", DBNull.Value);
                else
                    cmd.Parameters.AddWithValue("@column_33", trptcomputationvaluetableobject.column_33);

                if (string.IsNullOrWhiteSpace(trptcomputationvaluetableobject.column_34))
                    cmd.Parameters.AddWithValue("@column_34", DBNull.Value);
                else
                    cmd.Parameters.AddWithValue("@column_34", trptcomputationvaluetableobject.column_34);

                if (string.IsNullOrWhiteSpace(trptcomputationvaluetableobject.column_35))
                    cmd.Parameters.AddWithValue("@column_35", DBNull.Value);
                else
                    cmd.Parameters.AddWithValue("@column_35", trptcomputationvaluetableobject.column_35);

                if (string.IsNullOrWhiteSpace(trptcomputationvaluetableobject.column_36))
                    cmd.Parameters.AddWithValue("@column_36", DBNull.Value);
                else
                    cmd.Parameters.AddWithValue("@column_36", trptcomputationvaluetableobject.column_36);

                if (string.IsNullOrWhiteSpace(trptcomputationvaluetableobject.column_37))
                    cmd.Parameters.AddWithValue("@column_37", DBNull.Value);
                else
                    cmd.Parameters.AddWithValue("@column_37", trptcomputationvaluetableobject.column_37);

                if (string.IsNullOrWhiteSpace(trptcomputationvaluetableobject.column_38))
                    cmd.Parameters.AddWithValue("@column_38", DBNull.Value);
                else
                    cmd.Parameters.AddWithValue("@column_38", trptcomputationvaluetableobject.column_38);

                if (string.IsNullOrWhiteSpace(trptcomputationvaluetableobject.column_39))
                    cmd.Parameters.AddWithValue("@column_39", DBNull.Value);
                else
                    cmd.Parameters.AddWithValue("@column_39", trptcomputationvaluetableobject.column_39);

                if (string.IsNullOrWhiteSpace(trptcomputationvaluetableobject.column_40))
                    cmd.Parameters.AddWithValue("@column_40", DBNull.Value);
                else
                    cmd.Parameters.AddWithValue("@column_40", trptcomputationvaluetableobject.column_40);

                #endregion
                cmd.Parameters.AddWithValue("@last_modified", SqlDbType.DateTime).SqlValue = trptcomputationvaluetableobject.last_modified;
                cmd.Parameters.AddWithValue("@modified_by", trptcomputationvaluetableobject.modified_by);

                rowsAffected = cmd.ExecuteNonQuery();

                //Call the comprulemerge procedure to for deep merging of column values
                mergeAffected = _ruleVarianceAdjustment.CompuRuleMerge();

                if (rowsAffected > 0 && mergeAffected == 0)
                    return rowsAffected + mergeAffected;
                else
                    return 0;
            }

            return rowsAffected;
        }
    }
}