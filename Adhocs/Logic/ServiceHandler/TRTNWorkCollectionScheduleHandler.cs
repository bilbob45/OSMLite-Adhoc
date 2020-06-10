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
    public class TRTNWorkCollectionScheduleHandler
    {
        private TRTNWorkCollectionScheduleObject _workCollectionSheduler;

        DatabaseOps _databaseOperations;
        DataTable _resultTable;
        //SqlDataReader _reader;
        public TRTNWorkCollectionScheduleHandler()
        {
            _databaseOperations = new DatabaseOps();
            _resultTable = new DataTable();
            _workCollectionSheduler = new TRTNWorkCollectionScheduleObject();
        }

        public Dictionary<string, string> GetWorkCollectionSchedule(VRTNWorkCollectionObject vrtnworkcollectionobject, TRTNWorkCollectionScheduleObject trtnworkcollectionscheduleobject)
        {
            Dictionary<string, string> returnedValues = new Dictionary<string, string>();
            if (trtnworkcollectionscheduleobject.ri_id < 1 && String.IsNullOrEmpty(vrtnworkcollectionobject.frequency))
                throw new ArgumentException("Return institution ID and frequency is required");
            else
            {
                var comamndText = @"SELECT schedule_id, ri_id, work_collection_id, work_collection_date FROM t_rtn_work_collection_schedule WHERE work_collection_id =                        (SELECT DISTINCT a.work_collection_id/*, e.ri_type_id,e.frequency*/ FROM t_rtn_returns_work_collection_mapping a JOIN (SELECT DISTINCT return_code FROM t_rpt_computation_rulemakeup UNION SELECT DISTINCT c.return_code FROM t_rpt_computation_rulemakeup a JOIN t_rpt_computation_rulemakeup_formula c ON a.ruleBase_ID = c.ruleBase_ID) d ON a.return_code = d.return_code JOIN v_rtn_work_collection e ON e.work_collection_id = a.work_collection_id WHERE ri_type_id = @ritypeid AND frequency = @frequency) AND is_valid = @isvalid AND ri_id = @riid AND work_collection_date = @wcdate";
                using (SqlCommand command = new SqlCommand(comamndText, DatabaseOps.OpenSqlConnection()))
                {
                    command.CommandType = CommandType.Text;
                    command.Parameters.AddWithValue("@ritypeid", vrtnworkcollectionobject.ri_type_id);
                    command.Parameters.AddWithValue("@frequency", vrtnworkcollectionobject.frequency);
                    command.Parameters.AddWithValue("@isvalid", trtnworkcollectionscheduleobject.is_valid);
                    command.Parameters.AddWithValue("@riid", trtnworkcollectionscheduleobject.ri_id);
                    command.Parameters.Add("@wcdate", SqlDbType.DateTime).SqlValue = trtnworkcollectionscheduleobject.work_collection_date;

                    _resultTable = _databaseOperations.GetDataTable(command);
                    if (_resultTable.Rows.Count > 0)
                    {
                        for(int j = 0; j < _resultTable.Rows.Count; j++)
                        {
                            returnedValues.Add("schedule_id", _resultTable.Rows[j]["schedule_id"].ToString());
                            returnedValues.Add("ri_id", _resultTable.Rows[j]["ri_id"].ToString());
                            returnedValues.Add("work_collection_id", _resultTable.Rows[j]["work_collection_id"].ToString());
                            returnedValues.Add("work_collection_date", _resultTable.Rows[j]["work_collection_date"].ToString());
                        }
                    }
                    else
                        returnedValues = null;

                    return returnedValues;
                }
            }
        }
    }
}