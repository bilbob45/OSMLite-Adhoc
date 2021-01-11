using System;
using System.Collections.Generic;
using System.Data;
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

        public DataTable GetAll()
        {
            //var sqlText = "select * from t_sys_configuration_irs where config_value_desc like '%password%'";
            var sqlText = "select config_id AS 'Configuration ID', default_value AS 'Default Value', config_value AS 'Configuration Value', case when enabled = 1 then 'Enable' when enabled = 0 then 'Disabled' else 'Not Specified' end AS 'Is Enabled', config_value_desc AS 'Configuration Value Description' from t_sys_configuration_irs where config_id IN (5010, 5011, 5013, 5014, 5015, 5016, 5017)";
            using (SqlCommand command = new SqlCommand(sqlText, base.Connection))
            {
                DataTable = DatabaseOps.GetDataTable(command);
                _sysConfigurationIrsObjList = TransformerUtil.DataTableUtil.ToClassList<TSysConfigurationIrsObject>(DataTable);
                if (DataTable.Rows.Count > 0)
                    return DataTable;
                else
                    DataTable = null;
            }

            return DataTable;
        }

        public int Save(TSysConfigurationIrsObject obj)
        {
            var sqlText = "Update t_sys_configuration_irs set default_value = @default_value, config_value = @config_value, enabled = @enabled where config_id = @config_id";
            using (SqlCommand command = new SqlCommand(sqlText, base.Connection))
            {
                command.Parameters.AddWithValue("@default_value", obj.default_value);
                command.Parameters.AddWithValue("@config_value", obj.config_value);
                command.Parameters.AddWithValue("@enabled", obj.enabled);
                command.Parameters.AddWithValue("@config_id", obj.config_id);
                RowsAffected = DatabaseOps.ExecuteNonQuery(command);
            }

            return RowsAffected;
        }

        public DataTable GetAllProc()
        {
            var sqlText = "p_get_password_policy";
            using (SqlCommand command = new SqlCommand(sqlText, base.Connection))
            {
                DataTable = DatabaseOps.GetDataTable(command);
                _sysConfigurationIrsObjList = TransformerUtil.DataTableUtil.ToClassList<TSysConfigurationIrsObject>(DataTable);
                if (DataTable.Rows.Count > 0)
                    return DataTable;
                else
                    DataTable = null;
            }

            return DataTable;
        }
    }
}