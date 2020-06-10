using Adhocs.Logic.DatabaseHandler;
using Adhocs.Logic.Object;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Transactions;
using System.Web;

namespace Adhocs.Logic.ServiceHandler
{
    public class TRPTComputationBankRatingSetupHandler
    {
        public TRPComputationBankRatingSetupObject _computationSetupObj;
        DatabaseOps _databaseOperations = new DatabaseOps();
        DataTable _resultTable;
        int _rowsAffected = 0;
        public TRPTComputationBankRatingSetupHandler(TRPComputationBankRatingSetupObject setupobj)
        {
            this._computationSetupObj = setupobj;
            _computationSetupObj = new TRPComputationBankRatingSetupObject();
        }

        public TRPTComputationBankRatingSetupHandler()
        {
            _computationSetupObj = new TRPComputationBankRatingSetupObject();
        }

        public DataTable GetBankRatingSetupDetails(int ritypeid, int riid)
        {
            var sqlText = "SELECT a.bank_rating_code AS 'Bank Rating Code', a.param AS 'Param', a.description AS 'Description', a.component_weight AS 'Component Weight', b.rating_score AS 'Rating Score' FROM t_rpt_computation_bank_rating_setup a left join t_rpt_computation_bank_rating_scoring b on a.bank_rating_code = b.bank_rating_code and a.ri_type_id = b.ri_type_id and b.rating_date BETWEEN a.start_validity_date and ISNULL(a.end_validity_date, @min_date) and b.rating_date = '20191231' and b.ri_id = @ri_id where a.ri_type_id = @ri_type_id";
            sqlText = "SELECT a.bank_rating_code, a.param, a.description, a.component_weight, b.rating_score FROM t_rpt_computation_bank_rating_setup a left join t_rpt_computation_bank_rating_scoring b on a.bank_rating_code = b.bank_rating_code and a.ri_type_id = b.ri_type_id and b.rating_date BETWEEN a.start_validity_date and ISNULL(a.end_validity_date, @min_date) and b.rating_date = '20191231' and b.ri_id = @ri_id where a.ri_type_id = @ri_type_id";
            using (SqlCommand cmd = new SqlCommand(sqlText, DatabaseOps.OpenSqlConnection()))
            {

                cmd.CommandType = CommandType.Text;
                cmd.Parameters.AddWithValue("@min_date", DateTime.MaxValue);
                cmd.Parameters.AddWithValue("@ri_id", riid); //'99991231'
                cmd.Parameters.AddWithValue("@ri_type_id", ritypeid);
                _resultTable = new DataTable();
                _resultTable = _databaseOperations.GetDataTable(cmd);
                return _resultTable;
            }
        }

        public DataTable GetBankRatingSetupDetails()
        {
            var sqlText = "SELECT * FROM t_rpt_computation_bank_rating_setup";
            sqlText = "SELECT bank_rating_code AS 'Bank Rating Code', param AS 'Param', description AS 'Description', component_weight AS 'Component Weight',start_validity_date AS 'Start Validity Date' FROM t_rpt_computation_bank_rating_setup";
            using (SqlCommand cmd = new SqlCommand(sqlText, DatabaseOps.OpenSqlConnection()))
            {
                cmd.CommandType = CommandType.Text;
                _resultTable = _databaseOperations.GetDataTable(cmd);
                return _resultTable;
            }
        }

        public TRPComputationBankRatingSetupObject GetBankRatingSetupDetails(string bankratingcode)
        {
            var sqlText = "SELECT * FROM t_rpt_computation_bank_rating_setup WHERE bank_rating_code = @bank_rating_code";
            using (SqlCommand cmd = new SqlCommand(sqlText, DatabaseOps.OpenSqlConnection()))
            {
                cmd.CommandType = CommandType.Text;
                cmd.Parameters.AddWithValue("@bank_rating_code", bankratingcode);
                _resultTable = _databaseOperations.GetDataTable(cmd);
                if (_resultTable.Rows.Count > 0)
                {
                    foreach (DataRow row in _resultTable.Rows)
                    {
                        _computationSetupObj.bank_rating_code = row.Field<string>("bank_rating_code");
                        _computationSetupObj.ri_type_id = row.Field<int>("ri_type_id");
                        _computationSetupObj.param = row.Field<string>("param");
                        _computationSetupObj.description = row.Field<string>("description");
                        _computationSetupObj.component_weight = row["component_weight"].ToString();
                        _computationSetupObj.start_validity_date = row.Field<DateTime>("start_validity_date");
                        _computationSetupObj.end_validity_date = row.Field<DateTime?>("end_validity_date");
                    }
                }
            }

            return _computationSetupObj;
        }

        public bool CheckDataExists(string valuetocheck)
        {
            if (valuetocheck == null)
                throw new ArgumentNullException("Value to check can't be null");

            var sqlText = $"SELECT bank_rating_code from t_rpt_computation_bank_rating_setup  WHERE bank_rating_code = @bank_rating_code";
            using (SqlCommand cmd = new SqlCommand(sqlText, DatabaseOps.OpenSqlConnection()))
            {
                cmd.CommandType = CommandType.Text;
                cmd.Parameters.AddWithValue("@bank_rating_code", valuetocheck);

                string value = _databaseOperations.GetData(cmd);
                if (string.IsNullOrWhiteSpace(value))
                    return false;
                else
                    return true;
            }
        }

        public int SaveComputationBankRatingSetup(TRPComputationBankRatingSetupObject setup)
        {
            if (setup == null)
                throw new ArgumentNullException("Computation bank rating setup can't be null");

            var sqlText = "INSERT INTO t_rpt_computation_bank_rating_setup(bank_rating_code, ri_type_id, param, description, component_weight, start_validity_date, end_validity_date, created_date, created_by) VALUES(@bank_rating_code, @ri_type_id, @param, @description, @component_weight, @start_validity_date, @end_validity_date, @created_date, @created_by)";

            using (SqlCommand cmd = new SqlCommand(sqlText, DatabaseOps.OpenSqlConnection()))
            {
                cmd.CommandType = CommandType.Text;
                cmd.Parameters.AddWithValue("@bank_rating_code", setup.bank_rating_code);
                cmd.Parameters.AddWithValue("@ri_type_id", setup.ri_type_id);
                cmd.Parameters.AddWithValue("@param", setup.param);
                cmd.Parameters.AddWithValue("@description", setup.description);
                cmd.Parameters.AddWithValue("@component_weight", setup.component_weight);

                if (setup.start_validity_date == null || setup.start_validity_date == DateTime.MinValue)
                    cmd.Parameters.Add("@start_validity_date", SqlDbType.DateTime).SqlValue = DateTime.MinValue;
                else
                    cmd.Parameters.Add("@start_validity_date", SqlDbType.DateTime).SqlValue = setup.start_validity_date;

                if (setup.end_validity_date == null || setup.end_validity_date == DateTime.MinValue)
                    cmd.Parameters.Add("@end_validity_date", SqlDbType.DateTime).SqlValue = DBNull.Value;
                else
                    cmd.Parameters.Add("@end_validity_date", SqlDbType.DateTime).SqlValue = setup.end_validity_date;

                cmd.Parameters.AddWithValue("@created_date", setup.created_date);
                cmd.Parameters.AddWithValue("@created_by", setup.created_by);

                _rowsAffected = cmd.ExecuteNonQuery();
            }
            return _rowsAffected;
        }

        public int UpdateComputationBankRatingSetup(TRPComputationBankRatingSetupObject setup)
        {
            if (setup == null)
                throw new ArgumentNullException("Computation bank rating scoring can't be null");

            var sqlText = "UPDATE t_rpt_computation_bank_rating_setup SET ri_type_id = @ri_type_id, param = @param, description = @description, component_weight = @component_weight, start_validity_date = @start_validity_date, end_validity_date = @end_validity_date, last_modified = @last_modified, modified_by = @modified_by WHERE bank_rating_code = @bank_rating_code";
            using (TransactionScope scope = new TransactionScope(TransactionScopeOption.Required))
            {
                using (SqlCommand cmd = new SqlCommand(sqlText, DatabaseOps.OpenSqlConnection()))
                {
                    cmd.CommandType = CommandType.Text;
                    cmd.Parameters.AddWithValue("@ri_type_id", setup.ri_type_id);
                    cmd.Parameters.AddWithValue("@param", setup.param);
                    cmd.Parameters.AddWithValue("@description", setup.description);
                    cmd.Parameters.AddWithValue("@component_weight", setup.component_weight);

                    cmd.Parameters.AddWithValue("@start_validity_date", setup.start_validity_date);
                    cmd.Parameters.AddWithValue("@end_validity_date", setup.end_validity_date);

                    if (setup.start_validity_date == null || setup.start_validity_date == DateTime.MinValue)
                        cmd.Parameters.Add("@start_validity_date", SqlDbType.DateTime).SqlValue = DateTime.MinValue;
                    else
                        cmd.Parameters.Add("@start_validity_date", SqlDbType.DateTime).SqlValue = setup.start_validity_date;

                    if (setup.end_validity_date == null || setup.end_validity_date == DateTime.MinValue)
                        cmd.Parameters.Add("@end_validity_date", SqlDbType.DateTime).SqlValue = DBNull.Value;
                    else
                        cmd.Parameters.Add("@end_validity_date", SqlDbType.DateTime).SqlValue = setup.end_validity_date;

                    cmd.Parameters.AddWithValue("@bank_rating_code", setup.bank_rating_code);

                    _rowsAffected = cmd.ExecuteNonQuery();
                }
                scope.Complete();
            }
            return _rowsAffected;
        }
    }
}