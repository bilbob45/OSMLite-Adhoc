using Adhocs.Logic.DatabaseHandler;
using Adhocs.Logic.Object;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace Adhocs.Logic.ServiceHandler
{
    public class TRPTLiqStressTestScoringHandler
    {
        TRPTLiqStressTestScoringObject _testScoreObject;
        int _rowsAffected = 0;
        public TRPTLiqStressTestScoringHandler(TRPTLiqStressTestScoringObject testscoreobject)
        {
            _testScoreObject = testscoreobject;
        }

        public TRPTLiqStressTestScoringHandler()
        {
            _testScoreObject = new TRPTLiqStressTestScoringObject();
        }

        public int SaveComputationBankRatingSetup(TRPTLiqStressTestScoringObject scoreobj)
        {
            if (scoreobj == null)
                throw new ArgumentNullException("Computation bank rating setup can't be null");

            var sqlText = "INSERT INTO t_rpt_liq_stress_test_scoring(item_code, item_description, ri_id, valuation_date, amount, last_modified, modified_by) VALUES(@item_code, @item_description, @ri_id, @valuation_date, @amount, @last_modified, @modified_by)";

            using (SqlCommand cmd = new SqlCommand(sqlText, DatabaseOps.OpenSqlConnection()))
            {
                cmd.CommandType = CommandType.Text;
                cmd.Parameters.AddWithValue("@item_code", scoreobj.item_code);
                if (string.IsNullOrWhiteSpace(scoreobj.item_description))
                    cmd.Parameters.Add("@item_description", SqlDbType.NVarChar).SqlValue = DBNull.Value;
                else
                    cmd.Parameters.AddWithValue("@item_description", scoreobj.item_description);

                cmd.Parameters.AddWithValue("@ri_id", scoreobj.ri_id);
                cmd.Parameters.Add("@valuation_date", SqlDbType.DateTime).SqlValue = scoreobj.valuation_date;
                cmd.Parameters.AddWithValue("@amount", scoreobj.amount);
                cmd.Parameters.Add("@last_modified", SqlDbType.DateTime).SqlValue = DBNull.Value;
                cmd.Parameters.Add("@modified_by", SqlDbType.DateTime).SqlValue = DBNull.Value;

                _rowsAffected = cmd.ExecuteNonQuery();
            }
            return _rowsAffected;
        }
    }
}