using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using Adhocs.Logic.ServiceHandler;
using System.Data;
using System.Data.SqlClient;
using Adhocs.Logic.DatabaseHandler;
using System.Web.UI.WebControls;
using System.Collections.Specialized;

namespace Adhocs.Logic.ServiceHandler
{
    public class SubmissionReferenceCalcModel
    {
        [Required]
        [MaxLength(40)]
        public String return_code { get; set; }

        [Required]
        [MaxLength(40)]
        public String item_code { get; set; }

        [Required]
        [MaxLength(1024)]
        public String formula { get; set; }

        [Required]
        public Int32 calc_order { get; set; }

        [Required]
        public Int32 version { get; set; }

        [Required]
        public DateTime created_date { get; set; }

        [Required]
        [MaxLength(255)]
        public String created_by { get; set; }

        public DateTime last_modified { get; set; }

        [MaxLength(255)]
        public String modified_by { get; set; }
    }

    public class SubmissionReferenceCalc
    {
        DataTable _resultTable;
        DatabaseOps _databaseOps;
        Dictionary<int, int> cleanedCalcOrder = new Dictionary<int, int>();

        public SubmissionReferenceCalc()
        {
            _databaseOps = new DatabaseOps();
        }

        public String CalculateAdjustedReturn()
        {
            return "";
        }

        private void GetFormularSign(string formular, bool hasaddition, bool hassubtraction)
        {
            String formularHolder = formular;
            formularHolder = formularHolder.Replace("[", "").Replace("]", "");
            if(formularHolder.Contains("+"))
            {
                hasaddition = true;
            }

            if (formularHolder.Contains("-"))
            {
                hassubtraction = true;
            }
        }

        public string BuildQuery(string returncode, int itemcode, int level = 0)
        {
            //if(level == 0)
            //    return string.Format("select * from t_dis_submission_reference_calc where item_code = {0} or formula like '{1}' and return_code = '{2}'", itemcode, String.Format("%{0}%", itemcode), returncode);
            //else
                //select * from t_dis_submission_reference_calc where formula like '%10300%' and return_code = 'mbr300'
                return string.Format("select return_code, item_code, formula from t_dis_submission_reference_calc where formula like '{0}' and return_code = '{1}'", String.Format("%{0}%", itemcode), returncode);
        }

        public Dictionary<int, string> GetFormularDependencies(string returncode, String itemcode)
        {
            Dictionary<int, string> cleanedFormulaData = new Dictionary<int, string>();
            try
            {
                var procName = "p_rpt_computation_rule_adjustment_get_item_code_dependencies";
                using (SqlCommand cmd = new SqlCommand(procName, DatabaseOps.OpenSqlConnection()))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@return_code", returncode);
                    cmd.Parameters.AddWithValue("@item_code", itemcode);
                    var resultDataTable = _databaseOps.GetDataTable(cmd);
                    var Counter = resultDataTable.Rows.Count;
                    if (Counter > 0)
                    {
                        foreach (DataRow row in resultDataTable.Rows)
                        {
                            cleanedFormulaData.Add(Convert.ToInt32(row["item_code"].ToString()), CleanFormular(row["formula"].ToString()));
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return cleanedFormulaData;
        }

        Dictionary<int, string> cleanedFormulaData = new Dictionary<int, string>();
        public Dictionary<int, string> GetDependencies(string returncode, int itemcode, int querylevel = 0)
        {
            try
            {
                var sqlWhiteList = BuildQuery(returncode, itemcode, querylevel);
                using (SqlCommand cmd = new SqlCommand(sqlWhiteList, DatabaseOps.OpenSqlConnection()))
                {
                    var resultDataTable = _databaseOps.GetDataTable(cmd);
                    var Counter = resultDataTable.Rows.Count;
                    if (Counter == 1 || Counter > 1)
                    {
                        foreach (DataRow row in resultDataTable.Rows)
                        {
                            if (String.IsNullOrWhiteSpace(row["item_code"].ToString()))
                                break;
                            cleanedFormulaData.Add(Convert.ToInt32(row["item_code"].ToString()), CleanFormular(row["formula"].ToString()));
                            GetDependencies(returncode, Convert.ToInt32(row["item_code"]), 0);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return cleanedFormulaData;
        }

        public Dictionary<int, string> GetFormulars(string returncode, int itemcode, int querylevel = 0)
        {
            Dictionary<int, string> cleanedFormulaData = new Dictionary<int, string>();
            try
            {
                var sqlWhiteList = BuildQuery(returncode, itemcode, querylevel);
                using (SqlCommand cmd = new SqlCommand(sqlWhiteList, DatabaseOps.OpenSqlConnection()))
                {
                    var resultDataTable = _databaseOps.GetDataTable(cmd);
                    var Counter = resultDataTable.Rows.Count;
                    if (Counter == 1 || Counter >= 1)
                    {
                        foreach (DataRow row in resultDataTable.Rows)
                        {
                            var formula = row["formula"].ToString();
                            formula = CleanFormular(formula);
                            cleanedFormulaData.Add(Convert.ToInt32(row["item_code"].ToString()), formula);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return cleanedFormulaData;
        }

        public Dictionary<int, string> GetFormulars()
        {
            //List<Dictionary<int, string>> resultListData = new List<Dictionary<int, string>>();
            Dictionary<int, string> resultDictionaryData = new Dictionary<int, string>();

            var sqlWhiteList = @"select item_code, formula from t_dis_submission_reference_calc";
            using (SqlCommand cmd = new SqlCommand(sqlWhiteList, DatabaseOps.OpenSqlConnection()))
            {
                var resultDataTable = _databaseOps.GetDataTable(cmd);
                var Counter = resultDataTable.Rows.Count;
                if (Counter >= 1)
                {
                    foreach (DataRow row in resultDataTable.Rows)
                    {
                        resultDictionaryData.Add(Convert.ToInt32(row["item_code"].ToString()), CleanFormular(row["formula"].ToString()));
                    }
                }
            }

            return resultDictionaryData;
        }

        public static String CleanFormular(string formula)
        {
            return formula.Replace("[", "").Replace("]", "");
        }
    }
}