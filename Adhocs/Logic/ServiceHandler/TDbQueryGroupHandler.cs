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
    public class TDbQueryGroupHandler : ServiceBaseHandler
    {
        private TDbQueryGroupObject _tDbQueryGroupObj;
        private List<TDbQueryGroupObject> _tDbQueryGroupObjList;
        public TDbQueryGroupHandler()
        {
            _tDbQueryGroupObj = new TDbQueryGroupObject();
            _tDbQueryGroupObjList = new List<TDbQueryGroupObject>();
        }

        public List<TDbQueryGroupObject> GetAll()
        {
            var sqlText = @"select * from t_db_query_group";
            using (SqlCommand command = new SqlCommand(sqlText, Connection))
            {
                command.CommandType = CommandType.Text;
                DataTable = DatabaseOps.GetDataTable(command);
                _tDbQueryGroupObjList = TransformerUtil.DataTableUtil.ToClassList<TDbQueryGroupObject>(DataTable);
                if (_tDbQueryGroupObjList.Count > 0)
                    return _tDbQueryGroupObjList;
                else
                    _tDbQueryGroupObjList = null;
            }

            return _tDbQueryGroupObjList;
        }

        public TDbQueryGroupObject Get(int groupid)
        {
            var sqlText = @"select * from t_db_query_group where group_id = @group_id";
            using (SqlCommand command = new SqlCommand(sqlText, Connection))
            {
                command.CommandType = CommandType.Text;
                command.Parameters.AddWithValue("@group_id", groupid);
                DataTable = DatabaseOps.GetDataTable(command);
                _tDbQueryGroupObj = TransformerUtil.DataTableUtil.SingRowToClass<TDbQueryGroupObject>(DataTable);
                if (_tDbQueryGroupObj.group_id != 0)
                    return _tDbQueryGroupObj;
                else
                    _tDbQueryGroupObj = null;
            }

            return _tDbQueryGroupObj;
        }

        public TDbQueryGroupObject Get(string groupname)
        {
            var sqlText = @"select * from t_db_query_group where group_name = @group_name";
            using (SqlCommand command = new SqlCommand(sqlText, Connection))
            {
                command.CommandType = CommandType.Text;
                command.Parameters.AddWithValue("@group_name", groupname);
                DataTable = DatabaseOps.GetDataTable(command);
                _tDbQueryGroupObj = TransformerUtil.DataTableUtil.SingRowToClass<TDbQueryGroupObject>(DataTable);
                if (_tDbQueryGroupObj.group_id != 0)
                    return _tDbQueryGroupObj;
                else
                    _tDbQueryGroupObj = null;
            }

            return _tDbQueryGroupObj;
        }

        public List<TDbQueryGroupObject> QueryGroupName(TCoreUsersObject username)
        {
            _tDbQueryGroupObjList = QueryGroupName(username.user_name);
            return _tDbQueryGroupObjList;
        }

        public List<TDbQueryGroupObject> QueryGroupName(string username)
        {
            var sqlText = "select a.group_name from t_db_query_group a inner join t_db_query_group_member b on a.group_id = b.group_id inner join t_core_users c on b.user_id = c.user_id where c.user_name = @user_name";
            using (SqlCommand command = new SqlCommand(sqlText, Connection))
            {
                command.CommandType = CommandType.Text;
                command.Parameters.AddWithValue("@user_name", username);
                DataTable = DatabaseOps.GetDataTable(command);
                _tDbQueryGroupObjList = TransformerUtil.DataTableUtil.ToClassList<TDbQueryGroupObject>(DataTable);
                if (_tDbQueryGroupObjList.Count > 0)
                    return _tDbQueryGroupObjList;
                else
                    _tDbQueryGroupObjList = null;
            }

            return _tDbQueryGroupObjList;
        }
    }
}