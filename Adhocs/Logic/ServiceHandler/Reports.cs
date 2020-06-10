using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.Data;
using System.Data.SqlClient;
using Adhocs.Logic.DatabaseHandler;
using Adhocs.Logic.ServiceHandler;

namespace Adhocs.Logic.ServiceHandler
{
    public class ReportsModel
    {
        [Required]
        public Int32 report_id { get; set; }

        [Required]
        [MaxLength(128)]
        public String report_code { get; set; }

        [Required]
        [MaxLength(128)]
        public String report_name { get; set; }

        [Required]
        [MaxLength(1024)]
        public String report_desc { get; set; }

        [Required]
        public String is_dashboard_report { get; set; }

        [Required]
        public String is_editable { get; set; }

        [Required]
        public String is_active { get; set; }

        [Required]
        public DateTime created_date { get; set; }

        [Required]
        [MaxLength(255)]
        public String created_by { get; set; }

        public DateTime last_modified { get; set; }

        [MaxLength(255)]
        public String modified_by { get; set; }

    }

    public class Reports
    {
        ReportsModel _reportModel;
        DatabaseOps _databaseOperations;
        DataTable _resultTable;
        public Reports(ReportsModel reportmodel)
        {
            _reportModel = reportmodel;
            _databaseOperations = new DatabaseOps();
            _resultTable = new DataTable();
        }

        public Reports()
        {
            _databaseOperations = new DatabaseOps();
            _resultTable = new DataTable();
        }

        public void GetAllReports()
        {

        }

        /// <summary>
        /// Count the total number of reports available to the currently logged in user
        /// </summary>
        /// <returns>string</returns>
        public String CountUsersReports(string username)
        {
            try
            {
                //var sqlWhiteList = @"select count(*) from t_rpt_report";
                var sqlWhiteList = @"Select DISTINCT count(report_id) from t_rpt_report_group a inner join t_rpt_group_members b on a.group_id = b.group_id where b.user_name = @username";
                sqlWhiteList = @"Select DISTINCT count(a.report_id) from t_rpt_report_group a inner join t_rpt_group_members b on a.group_id = b.group_id INNER JOIN t_rpt_report C ON a.report_id = c.report_id where b.user_name = @username and c.is_active = 1";
                using (SqlCommand cmd = new SqlCommand(sqlWhiteList, DatabaseOps.OpenSqlConnection()))
                { 
                    cmd.Parameters.AddWithValue("@username", username);
                    cmd.CommandType = CommandType.Text;
                    return _databaseOperations.GetData(cmd);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// Count the total number of reports in a department
        /// </summary>
        /// <param name="deptid">department Id</param>
        /// <returns>string</returns>
        public String CountReportsByDept(string deptid)
        {
            try
            {
                var sqlWhiteList = @"select count(*) from t_rpt_report_group where group_id = @input";
                using (SqlCommand cmd = new SqlCommand(sqlWhiteList, DatabaseOps.OpenSqlConnection()))
                {
                    cmd.CommandType = CommandType.Text;
                    cmd.Parameters.AddWithValue("@input", deptid);
                    return _databaseOperations.GetData(cmd);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// Get all the department names the user has reports assigned to
        /// </summary>
        /// <param name="username">username</param>
        /// <returns>Datatable</returns>
        public DataTable GetReportDepartments(string username)
        {
            try
            {
                var sqlWhiteList = @"Select a.group_id, a.group_name, a.group_desc from t_rpt_group a inner join t_rpt_group_members b on a.group_id = b.group_id 
                                    where b.user_name = @username";
                using (SqlCommand cmd = new SqlCommand(sqlWhiteList, DatabaseOps.OpenSqlConnection()))
                {
                    if(username != null)
                        cmd.Parameters.AddWithValue("@username", username);
                    _resultTable = _databaseOperations.GetDataTable(cmd);
                    return _resultTable;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// Get all the reports assigned to a particular department
        /// </summary>
        /// <param name="deptid">Department Id</param>
        /// <returns>Datatable</returns>
        public DataTable GetReportsByDepartments(string deptid)
        {
            try
            {
                var sqlWhiteList = @"SELECT DISTINCT c.group_name, c.group_desc As 'Department', a.report_code, a.report_name AS 'Report Name', a.report_desc AS 'Report Description' FROM t_rpt_report a INNER JOIN t_rpt_report_group b ON a.report_id = b.report_id INNER JOIN t_rpt_group c ON b.group_id = c.group_id inner join t_rpt_group_members d on d.group_id = b.group_id where b.group_id = @deptid AND a.is_active = 1";
                using (SqlCommand cmd = new SqlCommand(sqlWhiteList, DatabaseOps.OpenSqlConnection()))
                {
                    cmd.Parameters.AddWithValue("@deptid", deptid);
                    _resultTable = _databaseOperations.GetDataTable(cmd);
                    return _resultTable;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// Get all the reports assigned to a particular user regardless of there department
        /// </summary>
        /// <param name="username">username</param>
        /// <returns>Datatable</returns>
        public DataTable GeAlltUserReports(string username)
        {
            try
            {
                var sqlWhiteList = @"SELECT DISTINCT c.group_name, c.group_desc As 'Department', a.report_code, a.report_name AS 'Report Name', a.report_desc AS 'Report Description' FROM t_rpt_report a INNER JOIN t_rpt_report_group b ON a.report_id = b.report_id INNER JOIN t_rpt_group c ON b.group_id = c.group_id inner join t_rpt_group_members d on d.group_id = b.group_id where d.user_name = @username AND a.is_active = 1 ";
                using (SqlCommand cmd = new SqlCommand(sqlWhiteList, DatabaseOps.OpenSqlConnection()))
                {
                    cmd.Parameters.AddWithValue("@username", username);
                    _resultTable = _databaseOperations.GetDataTable(cmd);
                    return _resultTable;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}