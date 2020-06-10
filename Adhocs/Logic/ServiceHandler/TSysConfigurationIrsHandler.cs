using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using Adhocs.Logic.DatabaseHandler;
using Adhocs.Logic.Object;

namespace Adhocs.Logic.ServiceHandler
{
    public class TSysConfigurationIrsHandler : ServiceBaseHandler
    {
        private List<TSysConfigurationIrsObject> _sysConfigurationIrsObjList;
        private TSysConfigurationIrsObject _sysConfigurationIrsObj;
        public TSysConfigurationIrsHandler()
        {
            _sysConfigurationIrsObjList = new List<TSysConfigurationIrsObject>();
            _sysConfigurationIrsObj = new TSysConfigurationIrsObject();
        }

        public TSysConfigurationIrsObject Get(int configid)
        {
            var sqlText = "select * from t_sys_configuration_irs where config_id = @config_id";
            using (SqlCommand command = new SqlCommand(sqlText, base.Connection))
            {
                command.Parameters.AddWithValue("@config_id", configid);
                DataTable = DatabaseOps.GetDataTable(command);
                _sysConfigurationIrsObj = TransformerUtil.DataTableUtil.SingRowToClass<TSysConfigurationIrsObject>(DataTable);
                if (_sysConfigurationIrsObj.config_id != 0)
                    return _sysConfigurationIrsObj;
                else
                    _sysConfigurationIrsObj = null;
            }

            return _sysConfigurationIrsObj;
        }

        public List<TSysConfigurationIrsObject> GetAll()
        {
            var sqlText = "select * from t_sys_configuration_irs where config_value_desc like '%password%'";
            using (SqlCommand command = new SqlCommand(sqlText, base.Connection))
            {
                DataTable = DatabaseOps.GetDataTable(command);
                _sysConfigurationIrsObjList = TransformerUtil.DataTableUtil.ToClassList<TSysConfigurationIrsObject>(DataTable);
                if (_sysConfigurationIrsObjList.Count > 0)
                    return _sysConfigurationIrsObjList;
                else
                    _sysConfigurationIrsObjList = null;
            }

            return _sysConfigurationIrsObjList;
        }
    }
}