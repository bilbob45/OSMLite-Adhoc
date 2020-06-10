using Adhocs.Logic.DatabaseHandler;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace Adhocs.Logic.ServiceHandler
{
    public class PenaltyWorkCollection
    {
        DatabaseOps _databaseOperations;
        DataTable _resultTable;
        string _conString;
        void PenaltyWorkcollection(Dictionary<int, string> workcollection)
        {
            _databaseOperations = new DatabaseOps();
            _resultTable = new DataTable();
            _conString = ConnectionString.GetConnectionString();
        }
        public int SavePenaltyWorkCollection(PenaltyWorkCollectionModel penaltyWcModel)
        {
            int rowsAffected = 0;
            var sqlText = @"insert into t_pnt_penalty_work_collection_mapping values (@penalty_code, @work_collection_id, @created_date, @created_by, @last_modified, @modified_by)";
            using (SqlConnection connection = new SqlConnection(_conString))
            {
                using (SqlCommand command = new SqlCommand(sqlText, connection))
                {
                    command.CommandType = CommandType.Text;

                    command.Parameters.AddWithValue("@penalty_code", penaltyWcModel.penalty_code);
                    command.Parameters.AddWithValue("@work_collection_id", penaltyWcModel.work_collection_id);
                    command.Parameters.AddWithValue("@created_date", penaltyWcModel.created_date);
                    command.Parameters.AddWithValue("@created_by", penaltyWcModel.created_by);
                    
                    command.Parameters.AddWithValue("@last_modified", SqlDbType.DateTime).SqlValue = DBNull.Value; //penaltymodel.last_modified;
                    command.Parameters.AddWithValue("@modified_by", DBNull.Value);

                    if (connection.State == ConnectionState.Closed)
                        connection.Open();

                    rowsAffected = command.ExecuteNonQuery();
                }
            }

            return rowsAffected;
        }
    }

    public class PenaltyWorkCollectionModel
    {
        [Required]
        [MaxLength(40)]
        public String penalty_code { get; set; }

        [Required]
        public Dictionary<int, string> work_collection_id { get; set; }

        [Required]
        public DateTime created_date { get; set; }

        [Required]
        [MaxLength(255)]
        public String created_by { get; set; }

        public DateTime? last_modified { get; set; }

        [MaxLength(255)]
        public String modified_by { get; set; }
    }
}