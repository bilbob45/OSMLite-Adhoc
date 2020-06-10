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
    public class TCoreUsers : ServiceBaseHandler
    {
        TCoreUsersObject _tcoreUserObject;
        DatabaseOps _databaseOperations;
        DataTable _resultTable;
        int rowsAffected = 0;

        private List<TCoreDeptUnit> _tcoreUserObjectList;
        private List<VRTNUserDeptRoleForQbObject> _vRTNUserDeptRoleForQbObjects;
        public TCoreUsers(TCoreUsersObject tcoreuserobj)
        {
            _tcoreUserObject = tcoreuserobj;
            _databaseOperations = new DatabaseOps();
            _resultTable = new DataTable();
            _tcoreUserObjectList = new List<TCoreDeptUnit>();
            _vRTNUserDeptRoleForQbObjects = new List<VRTNUserDeptRoleForQbObject>();
        }

        public TCoreUsers()
        {
            _tcoreUserObject = new TCoreUsersObject();
            _databaseOperations = new DatabaseOps();
            _resultTable = new DataTable();
            _tcoreUserObjectList = new List<TCoreDeptUnit>();
            _vRTNUserDeptRoleForQbObjects = new List<VRTNUserDeptRoleForQbObject>();
        }

        public string Get(TCoreUsersObject username)
        {
            return Get(username.user_name);
        }

        public string Get(string username)
        {
            var sqlText = $@"select user_name from t_core_users where user_name = @user_name and is_active = 1";
            using (SqlCommand command = new SqlCommand(sqlText, DatabaseOps.OpenSqlConnection()))
            {
                command.Parameters.AddWithValue("@user_name", username);
                RealData = _databaseOperations.GetData(command);
                if (string.IsNullOrWhiteSpace(RealData))
                {
                    RealData = string.Empty;
                }
            }

            return RealData;
        }

        public DataTable GetAllUser(TCoreUsersObject username)
        {
            if (username == null || username.user_name.Length < 1)
                throw new ArgumentException("TCoreUsers username is required");

            try
            {
                var sqlText = @"SELECT a.app_user_id AS 'Application User ID', a.user_name AS 'Username', a.last_name AS 'Last Name', a.first_name AS 'First Name', a.middle_name AS 'Middle Name', a.email AS 'Email Address', CASE WHEN a.is_active = 1 THEN 'Active' WHEN a.is_active = 0 THEN 'Not Active' ELSE 'Not Set' END AS 'Is Active', CASE WHEN b.EmailConfirmed = 1 THEN 'Confirmed' WHEN b.EmailConfirmed = 0 THEN 'Not Confirmed' ELSE 'Not Set' END AS 'Email Confirmation', CASE WHEN b.TwoFactorEnabled = 0 THEN 'Disabled' WHEN b.TwoFactorEnabled = 1 THEN 'Enable' ELSE 'Not Set' End AS 'Two Factor Authentication', CASE WHEN b.LockoutEnabled = 1 THEN 'Enable' WHEN b.LockoutEnabled = 0 THEN 'Disabled' ELSE 'Not Set' END AS 'Lock Out Enabled' FROM t_core_users a INNER JOIN t_application_users b ON a.user_name = b.UserName WHERE a.user_name != @username";
                using (SqlCommand command = new SqlCommand(sqlText, DatabaseOps.OpenSqlConnection()))
                {
                    command.Parameters.AddWithValue("@username", username.user_name);
                    _resultTable = _databaseOperations.GetDataTable(command);
                    return _resultTable;
                }
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }

        public int SetTwoFactor(TCoreUsersObject appuserid, bool enable)
        {
            if (appuserid == null)
                throw new ArgumentNullException("User object - User ID is required");
            try
            {
                int value = (enable == true) ? 1 : 0;
                var sqlText = $@"update t_application_users set TwoFactorEnabled = @twofactorenable where UserId = @userid";
                using (SqlCommand command = new SqlCommand(sqlText, DatabaseOps.OpenSqlConnection()))
                {
                    command.Parameters.AddWithValue("@twofactorenable", value);
                    command.Parameters.AddWithValue("@userid", appuserid.app_user_id);
                    rowsAffected = _databaseOperations.ExecuteNonQuery(command);
                    return rowsAffected;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public int ActivateUser(TCoreUsersObject appuserid, bool enable)
        {
            if (appuserid == null)
                throw new ArgumentNullException("User object - User ID is required");
            try
            {
                var sqlText = $@"update t_core_users set is_active = {(enable == true ? 1 : 0)} where app_user_id = @app_user_id";
                using (SqlCommand command = new SqlCommand(sqlText, DatabaseOps.OpenSqlConnection()))
                {
                    command.Parameters.AddWithValue("@app_user_id", appuserid.app_user_id);
                    rowsAffected = _databaseOperations.ExecuteNonQuery(command);
                    return rowsAffected;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public int ConfirmEmail(TCoreUsersObject appuserid, bool enable)
        {
            if (appuserid == null)
                throw new ArgumentNullException("User object - User ID is required");
            try
            {
                var sqlText = $@"update t_application_users set emailconfirmed = {(enable == true ? 1 : 0)} where userid = @app_user_id";
                using (SqlCommand command = new SqlCommand(sqlText, DatabaseOps.OpenSqlConnection()))
                {
                    command.Parameters.AddWithValue("@app_user_id", appuserid.app_user_id);
                    rowsAffected = _databaseOperations.ExecuteNonQuery(command);
                    return rowsAffected;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<TCoreDeptUnit> Units(TCoreUsersObject username)
        {
            _tcoreUserObjectList = Units(username.user_name);
            return _tcoreUserObjectList;
        }

        public List<TCoreDeptUnit> Units(string username)
        {
            var sqlText = "select a.unit_name from t_core_dept_unit a inner join t_core_dept_members b on a.unit_id = b.unit_id inner join t_core_users c on b.user_id = c.user_id where c.user_name = @user_name";
            using (SqlCommand command = new SqlCommand(sqlText, Connection))
            {
                command.CommandType = CommandType.Text;
                command.Parameters.AddWithValue("@user_name", username);
                DataTable = DatabaseOps.GetDataTable(command);
                _tcoreUserObjectList = TransformerUtil.DataTableUtil.ToClassList<TCoreDeptUnit>(DataTable);
                if (_tcoreUserObjectList.Count > 0)
                    return _tcoreUserObjectList;
                else
                    _tcoreUserObjectList = null;
            }

            return _tcoreUserObjectList;
        }

        public List<VRTNUserDeptRoleForQbObject> Roles(TCoreUsersObject username)
        {
            _vRTNUserDeptRoleForQbObjects = Roles(username.user_name);
            return _vRTNUserDeptRoleForQbObjects;
        }

        public List<VRTNUserDeptRoleForQbObject> Roles(string username)
        {
            var sqlText = "select role_name from v_rtn_user_dept_role_for_qb where user_name = @user_name";
            using (SqlCommand command = new SqlCommand(sqlText, Connection))
            {
                command.CommandType = CommandType.Text;
                command.Parameters.AddWithValue("@user_name", username);
                DataTable = DatabaseOps.GetDataTable(command);
                _vRTNUserDeptRoleForQbObjects = TransformerUtil.DataTableUtil.ToClassList<VRTNUserDeptRoleForQbObject>(DataTable);
                if (_vRTNUserDeptRoleForQbObjects.Count > 0)
                    return _vRTNUserDeptRoleForQbObjects;
                else
                    _vRTNUserDeptRoleForQbObjects = null;
            }

            return _vRTNUserDeptRoleForQbObjects;
        }

        public string AppUserRole(TCoreUsersObject userobj)
        {
            var sqlText = "select a.role_name from t_application_roles a inner join t_app_user_role b on a.role_id = b.role_id inner join t_core_users c on b.user_id = c.app_user_id where c.user_name = @user_name";
            
            using (SqlCommand command = new SqlCommand(sqlText, DatabaseOps.OpenSqlConnection()))
            {
                command.Parameters.AddWithValue("@user_name", userobj.user_name);
                RealData = _databaseOperations.GetData(command);
                if (string.IsNullOrWhiteSpace(RealData))
                {
                    RealData = string.Empty;
                }
                else
                    return RealData;
            }

            return RealData;
        }

        public string UserInst(TCoreUsersObject username)
        {
            string data = null;
            var sqlText = $@"select user_inst from t_core_users where user_name = @user_name and is_regulator = 1";
            using (SqlCommand command = new SqlCommand(sqlText, DatabaseOps.OpenSqlConnection()))
            {
                command.Parameters.AddWithValue("@user_name", username.user_name);
                data = _databaseOperations.GetData(command);
                if (string.IsNullOrWhiteSpace(data))
                {
                    data = string.Empty;
                }
                else
                    return data;
            }

            return data;
        }
    }
}