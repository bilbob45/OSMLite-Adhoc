using Adhocs.Logic.DatabaseHandler;
using Adhocs.Logic.Object;
using System;
using System.Collections.Generic;
using System.Collections;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace Adhocs.Logic.ServiceHandler
{
    public class TRTNBuilderUploadHandler : ServiceBaseHandler
    {
        private List<TRTNBuilderUploadObject> _trtnbuilderObjectList;
        private TRTNBuilderUploadObject _trtnbuilderObject;
        public TRTNBuilderUploadHandler()
        {
            _trtnbuilderObjectList = new List<TRTNBuilderUploadObject>();
            _trtnbuilderObject = new TRTNBuilderUploadObject();
        }

        public List<TRTNBuilderUploadObject> GetAll()
        {
            var sqlText = "select * from t_rtn_builder_upld";
            using (SqlCommand command = new SqlCommand(sqlText, base.Connection))
            {
                DataTable = DatabaseOps.GetDataTable(command);
                _trtnbuilderObjectList = TransformerUtil.DataTableUtil.ToClassList<TRTNBuilderUploadObject>(DataTable);
                if (_trtnbuilderObjectList.Count > 0)
                    return _trtnbuilderObjectList;
                else
                    _trtnbuilderObjectList = null;
            }
            return _trtnbuilderObjectList;
        }

        public TRTNBuilderUploadObject Get(TRTNBuilderUploadObject id)
        {
            return Get(id.id);
        }

        public TRTNBuilderUploadObject Get(int id)
        {
            var sqlText = "select file_name AS 'File Name', upload_date AS 'Upload Date', CASE WHEN build_number = NULL THEN '---' END AS 'Build Number', CASE WHEN  is_current = 0 THEN 'No' WHEN is_current = 1 THEN 'Yes' ELSE 'Not Specified' END AS 'Most Recent', uploaded_by AS 'Uploaded By' from t_rtn_builder_upld where id = @id";
            using (SqlCommand command = new SqlCommand(sqlText, base.Connection))
            {
                command.Parameters.AddWithValue("@id", id);
                DataTable = DatabaseOps.GetDataTable(command);
                _trtnbuilderObject = TransformerUtil.DataTableUtil.SingRowToClass<TRTNBuilderUploadObject>(DataTable);
                if (_trtnbuilderObject.id != 0)
                    return _trtnbuilderObject;
                else
                    _trtnbuilderObject = null;
            }
            
            return _trtnbuilderObject;
        }

        public int Save(TRTNBuilderUploadObject id)
        {
            var sqlText = "insert into t_rtn_builder_upld values(@file_name, @upload_date, @build_number, @is_current, @uploaded_by);";
            using (SqlCommand command = new SqlCommand(sqlText, base.Connection))
            {
                command.Parameters.AddWithValue("@file_name", id.file_name);
                command.Parameters.AddWithValue("@upload_date", id.upload_date);
                if (string.IsNullOrWhiteSpace(id.build_number))
                    command.Parameters.AddWithValue("@build_number", DBNull.Value);
                else
                    command.Parameters.AddWithValue("@build_number", id.build_number);

                command.Parameters.AddWithValue("@is_current", id.is_current);
                command.Parameters.AddWithValue("@uploaded_by", id.uploaded_by);
                RowsAffected = DatabaseOps.ExecuteNonQuery(command);
            }
            return RowsAffected;
        }

        public int Update(TRTNBuilderUploadObject id)
        {
            var sqlText = "update t_rtn_builder_upld set file_name = @file_name, upload_date = @upload_date, build_number = @build_number, is_current = @is_current, uploaded_by = @uploaded_by where is_current = 1";
            using (SqlCommand command = new SqlCommand(sqlText, base.Connection))
            {
                command.Parameters.AddWithValue("@file_name", id.file_name);
                command.Parameters.AddWithValue("@upload_date", id.upload_date);
                if (string.IsNullOrWhiteSpace(id.build_number))
                    command.Parameters.AddWithValue("@build_number", DBNull.Value);
                else
                    command.Parameters.AddWithValue("@build_number", id.build_number);

                command.Parameters.AddWithValue("@is_current", id.is_current);
                command.Parameters.AddWithValue("@uploaded_by", id.uploaded_by);
                RowsAffected = DatabaseOps.ExecuteNonQuery(command);
            }
            return RowsAffected;
        }
    }
}