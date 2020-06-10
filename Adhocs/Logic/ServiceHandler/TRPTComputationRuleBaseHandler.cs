using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using Adhocs.Logic.DatabaseHandler;
using Adhocs.Logic.Objects;

namespace Adhocs.Logic.ServiceHandler
{
    public class TRPTComputationRuleBaseHandler
    {
        DatabaseOps _databaseOperations;
        DataTable _resultTable;

        private TRPTComputationRuleBaseObject _trptCompRuleObjects = null;
        public TRPTComputationRuleBaseHandler(TRPTComputationRuleBaseObject trptcomputationrulebaseobjects)
        {
            _trptCompRuleObjects = trptcomputationrulebaseobjects;
            _databaseOperations = new DatabaseOps();
            _resultTable = new DataTable();
        }

        public TRPTComputationRuleBaseHandler()
        {
            _databaseOperations = new DatabaseOps();
            _resultTable = new DataTable();
        }

        public DataTable GetComputationRuleBase(TCoreRiTypeObject tcoreritype)
        {
            if (tcoreritype.ri_type_id < 1)
                throw new ArgumentException("Return institution ID and frequency is required");
            else
            {
                var comamndText = @"SELECT rule_ID AS 'Rule ID', rule_Name AS 'Rule Name', rule_Desc AS 'Rule Description', type AS 'Rule Type' FROM t_rpt_computation_rulebase a WHERE a.rule_ri = (SELECT ri_type_code FROM t_core_ri_type WHERE ri_type_id = @ritypeid) AND rule_status = 'Active'";
                using (SqlCommand command = new SqlCommand(comamndText, DatabaseOps.OpenSqlConnection()))
                {
                    command.CommandType = CommandType.Text;
                    command.Parameters.AddWithValue("@ritypeid", tcoreritype.ri_type_id);
                    _resultTable = _databaseOperations.GetDataTable(command);
                    return _resultTable;
                }
            }
        }
    }
}