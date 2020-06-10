using Adhocs.Logic.DatabaseHandler;
using Adhocs.Logic.Objects;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace Adhocs.Logic.ServiceHandler
{
    public class TRPTComputationRuleAdjustmentHandler
    {
        DatabaseOps _databaseOperations;
        DataTable _resultTable;
        public TRPTComputationRuleAdjustmentHandler()
        {
            _databaseOperations = new DatabaseOps();
            _resultTable = new DataTable();
        }

        //public int Save(TRPTComputationRuleAdjustmentObject trptcomputationruleadjustmentobject)
        //{
        //    int rowsAffected = 0;
        //    string sqlText = @"INSERT INTO t_rpt_computation_rule_adjustment VALUES(@schedule_id, @run_id, @process_flag, @analyst_comment, @created_date, @created_by, @last_modified, @modified_by)";
        //    using (SqlCommand cmd = new SqlCommand(sqlText, DatabaseOps.OpenSqlConnection()))
        //    {
        //        cmd.CommandType = CommandType.Text;
        //        cmd.Parameters.AddWithValue("@schedule_id", trptcomputationruleadjustmentobject.schedule_id);
        //        cmd.Parameters.AddWithValue("@run_id", trptcomputationruleadjustmentobject.run_id);
        //        cmd.Parameters.AddWithValue("@process_flag", trptcomputationruleadjustmentobject.process_flag);
        //        cmd.Parameters.AddWithValue("@analyst_comment", trptcomputationruleadjustmentobject.analyst_comment);
        //        cmd.Parameters.Add("@created_date", SqlDbType.DateTime).SqlValue = trptcomputationruleadjustmentobject.created_date;
        //        cmd.Parameters.AddWithValue("@created_by", trptcomputationruleadjustmentobject.created_by);
        //        //cmd.Parameters.AddWithValue("@last_modified", trptcomputationruleadjustmentobject.last_modified);
        //        //cmd.Parameters.AddWithValue("@modified_by", trptcomputationruleadjustmentobject.modified_by);

        //        rowsAffected = cmd.ExecuteNonQuery();
        //    }
        //    return rowsAffected;
        //}
    }
}