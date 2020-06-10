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
    public class TDbQueryGroupMemberHandler : ServiceBaseHandler
    {
        private TDbQueryGroupMemberObject _tDbQueryGroupMemberObj;
        private List<TDbQueryGroupMemberObject> _tDbQueryGroupMemberObjList;
        public TDbQueryGroupMemberHandler()
        {
            _tDbQueryGroupMemberObj = new TDbQueryGroupMemberObject();
            _tDbQueryGroupMemberObjList = new List<TDbQueryGroupMemberObject>();
        }

        public List<TDbQueryGroupMemberObject> GetAll()
        {
            var sqlText = @"select * from t_db_query_group_member";
            using (SqlCommand command = new SqlCommand(sqlText, Connection))
            {
                command.CommandType = CommandType.Text;
                DataTable = DatabaseOps.GetDataTable(command);
                _tDbQueryGroupMemberObjList = TransformerUtil.DataTableUtil.ToClassList<TDbQueryGroupMemberObject>(DataTable);
                if (_tDbQueryGroupMemberObjList.Count > 0)
                    return _tDbQueryGroupMemberObjList;
                else
                    _tDbQueryGroupMemberObjList = null;
            }

            return _tDbQueryGroupMemberObjList;
        }

        public TDbQueryGroupMemberObject Get(string groupid)
        {
            var sqlText = @"select * from t_db_query_group_member where group_id = @group_id";
            using (SqlCommand command = new SqlCommand(sqlText, Connection))
            {
                command.CommandType = CommandType.Text;
                command.Parameters.AddWithValue("@group_id", groupid);
                DataTable = DatabaseOps.GetDataTable(command);
                _tDbQueryGroupMemberObj = TransformerUtil.DataTableUtil.SingRowToClass<TDbQueryGroupMemberObject>(DataTable);
                if (_tDbQueryGroupMemberObj.group_id != 0)
                    return _tDbQueryGroupMemberObj;
                else
                    _tDbQueryGroupMemberObj = null;
            }

            return _tDbQueryGroupMemberObj;
        }

        public int GetGroupId(int userid)
        {
            var sqlText = "";
            RealData =  DatabaseOps.GetData(sqlText) ?? null;
            int groupId = (string.IsNullOrWhiteSpace(RealData) ? 0 : Convert.ToInt32(RealData));
            return groupId;
        }
    }
}