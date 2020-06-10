using Adhocs.Logic.DatabaseHandler;
using Adhocs.Logic.Infrastructure;
using Adhocs.Logic.Object;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Reflection;
using System.Web;
using System.Web.UI.WebControls;

namespace Adhocs.Logic.ServiceHandler
{
    public class TRPTLiqStressTestDataDefnHandler
    {
        TRPTLiqStressTestDataDefnObject _testDefnObject;
        DatabaseOps _databaseOps;
        DataTable _dataTable;
        Utility _util;
        public TRPTLiqStressTestDataDefnHandler(TRPTLiqStressTestDataDefnObject testdefnobject)
        {
            _testDefnObject = testdefnobject;
            _databaseOps = new DatabaseOps();
            _dataTable = new DataTable();
            _util = new Utility();
        }

        public TRPTLiqStressTestDataDefnHandler()
        {
            _databaseOps = new DatabaseOps();
            _dataTable = new DataTable();
            _testDefnObject = new TRPTLiqStressTestDataDefnObject();
            _util = new Utility();
        }

        public List<TRPTLiqStressTestDataDefnObject> GetAllLiquidityStressTest(string bankratingcode)
        {
            if (string.IsNullOrWhiteSpace(bankratingcode))
                throw new ArgumentNullException("bank rating code is required");

            int _rowsAffected = 0;
            var sqlText = "UPDATE t_rpt_computation_bank_rating_setup SET rating_score = @rating_score WHERE bank_rating_code = @bank_rating_code";
            using (SqlCommand cmd = new SqlCommand(sqlText, DatabaseOps.OpenSqlConnection()))
            {
                cmd.CommandType = CommandType.Text;
                cmd.Parameters.AddWithValue("@bank_rating_code", bankratingcode);
                _rowsAffected = cmd.ExecuteNonQuery();
            }

            return new List<TRPTLiqStressTestDataDefnObject>();
        }

        public Dictionary<string, string> GetLiquidityStressTestByInputReq(int userreq)
        {
            Dictionary<string, string> liqStressListDic = new Dictionary<string, string>();
            var sqlText = "SELECT report_code, item_code, item_description FROM t_rpt_liq_stress_test_data_defn where user_input_reqd = @user_input_reqd";
            using (SqlCommand cmd = new SqlCommand(sqlText, DatabaseOps.OpenSqlConnection()))
            {
                cmd.CommandType = CommandType.Text;
                cmd.Parameters.AddWithValue("@user_input_reqd", userreq);
                _dataTable = _databaseOps.GetDataTable(cmd);
                foreach (DataRow row in _dataTable.Rows)
                {
                    liqStressListDic.Add(row.Field<string>("item_code"), row.Field<string>("item_description"));
                }
            }
            return liqStressListDic;
        }

        public void BindStressTestRiType(DropDownList ddplist)
        {
            string sqlQuery = $"SELECT ri_type_id, description FROM t_core_ri_type WHERE ri_type_code IN ('CB')";
            _util.OptionBinder(ddplist, sqlQuery, new string[] { "description", "ri_type_id" });
        }

        public void BindStressTestRI(DropDownList ddplist, int ritypeid)
        {
            if (ritypeid > 0)
            {
                //List<QueryStore> result = new List<QueryStore>();
                string sqlQuery = $"SELECT a.ri_id, a.fullname from t_core_reporting_institution a inner join t_core_ri_mapping b on a.ri_id = b.ri_id where b.ri_type_id = {ritypeid}";
                _util.OptionBinder(ddplist, sqlQuery, new string[] { "fullname", "ri_id" });
            }
        }
    }
}