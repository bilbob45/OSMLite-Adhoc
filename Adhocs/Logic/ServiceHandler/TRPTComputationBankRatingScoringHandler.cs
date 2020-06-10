using Adhocs.Logic.DatabaseHandler;
using Adhocs.Logic.Infrastructure;
using Adhocs.Logic.Object;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Transactions;
using System.Web;
using System.Web.UI.WebControls;

namespace Adhocs.Logic.ServiceHandler
{
    public class TRPTComputationBankRatingScoringHandler
    {
        public TRPTComputationBankRatingScoringObject _computationSscoring;
        DataTable _resultTable;
        DatabaseOps _databaseOperations;
        Utility _util;
        int _rowsAffected = 0;
        public TRPTComputationBankRatingScoringHandler(TRPTComputationBankRatingScoringObject scoring)
        {
            this._computationSscoring = scoring;
            _resultTable = new DataTable();
            _databaseOperations = new DatabaseOps();
            _util = new Utility();
        }

        public TRPTComputationBankRatingScoringHandler()
        {
            _resultTable = new DataTable();
            _databaseOperations = new DatabaseOps();
            _util = new Utility();
        }

        public int SaveComputationBankRatingScore(TRPTComputationBankRatingScoringObject scoring)
        {
            if (scoring == null)
                throw new ArgumentNullException("Computation bank rating scoring can't be null");

            var sqlText = "INSERT INTO t_rpt_computation_bank_rating_scoring(bank_rating_code, ri_type_id, ri_id, rating_date, rating_score, last_modified, modified_by)                            VALUES(@bank_rating_code, @ri_type_id, @ri_id, @rating_date, @rating_score, @last_modified, @modified_by)";

            using (TransactionScope scope = new TransactionScope(TransactionScopeOption.Required))
            {
                using (SqlCommand cmd = new SqlCommand(sqlText, DatabaseOps.OpenSqlConnection()))
                {
                    cmd.CommandType = CommandType.Text;
                    cmd.Parameters.AddWithValue("@bank_rating_code", scoring.bank_rating_code);
                    cmd.Parameters.AddWithValue("@ri_type_id", scoring.ri_type_id);
                    cmd.Parameters.AddWithValue("@ri_id", scoring.ri_id);
                    cmd.Parameters.AddWithValue("@rating_date", scoring.rating_date);
                    if(string.IsNullOrWhiteSpace(scoring.rating_score))
                        cmd.Parameters.AddWithValue("@rating_score", SharedConst.CONST_MONEY_INT_VALUE);
                    else
                        cmd.Parameters.AddWithValue("@rating_score", scoring.rating_score);

                    if (scoring.last_modified == null || scoring.last_modified == DateTime.MinValue)
                        cmd.Parameters.AddWithValue("@last_modified", DateTime.Now);
                    else
                        cmd.Parameters.AddWithValue("@last_modified", scoring.last_modified);

                    if (string.IsNullOrWhiteSpace(scoring.modified_by))
                        cmd.Parameters.AddWithValue("@modified_by", DBNull.Value);
                    else
                        cmd.Parameters.AddWithValue("@modified_by", scoring.modified_by);

                    _rowsAffected = cmd.ExecuteNonQuery();
                }
                scope.Complete();
            }
            
            return _rowsAffected;
        }

        public DataTable GetBankRatingSetupRiTypes()
        {
            var sqlText = "Select distinct a.ri_type_id, a.description from t_core_ri_type a inner join t_rpt_computation_bank_rating_setup b on a.ri_type_id = b.ri_type_id";
            using (SqlCommand cmd = new SqlCommand(sqlText, DatabaseOps.OpenSqlConnection()))
            {
                cmd.CommandType = CommandType.Text;
                _resultTable = _databaseOperations.GetDataTable(cmd);
                return _resultTable;
            }
        }

        public void BindBankRatingSetupRiTypes(DropDownList ddp)
        {
            var sqlText = "Select distinct a.ri_type_id, a.description from t_core_ri_type a inner join t_rpt_computation_bank_rating_setup b on a.ri_type_id = b.ri_type_id";
            _util.OptionBinder(ddp, sqlText, new string[] { "description", "ri_type_id" });
        }

        public bool CheckDataExists(string valuetocheck)
        {
            if (valuetocheck == null)
                throw new ArgumentNullException("Value to check can't be null");

            var sqlText = $"SELECT DISTINCT bank_rating_code FROM t_rpt_computation_bank_rating_scoring  WHERE bank_rating_code = @bank_rating_code";
            using (SqlCommand cmd = new SqlCommand(sqlText, DatabaseOps.OpenSqlConnection()))
            {
                cmd.CommandType = CommandType.Text;
                cmd.Parameters.AddWithValue("@bank_rating_code", valuetocheck);
                if(_databaseOperations.GetDataTable(cmd).Rows.Count < 1)
                    return false;
                else
                    return true;
            }
        }

        public int UpdateComputationBankRatingScore(TRPTComputationBankRatingScoringObject scoring)
        {
            if (scoring == null)
                throw new ArgumentNullException("Computation bank rating scoring can't be null");

            var sqlText = "UPDATE t_rpt_computation_bank_rating_scoring SET rating_score = @rating_score WHERE bank_rating_code = @bank_rating_code";
            using (TransactionScope scope = new TransactionScope(TransactionScopeOption.Required))
            {
                using (SqlCommand cmd = new SqlCommand(sqlText, DatabaseOps.OpenSqlConnection()))
                {
                    cmd.CommandType = CommandType.Text;
                    cmd.Parameters.AddWithValue("@rating_score", scoring.rating_score);
                    cmd.Parameters.AddWithValue("@bank_rating_code", scoring.bank_rating_code);

                    _rowsAffected = cmd.ExecuteNonQuery();
                }
                scope.Complete();
            }
            return _rowsAffected;
        }
    }
}