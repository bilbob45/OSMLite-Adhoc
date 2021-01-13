using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using Adhocs.Logic.DatabaseHandler;
using Adhocs.Logic.ServiceHandler;
using System.ComponentModel.DataAnnotations;
using System.Transactions;
using Adhocs.Infrastructure;

namespace Adhocs.Logic.ServiceHandler
{
    public class Penalties
    {
        private string _ritypecode;
        DatabaseOps _databaseOperations;
        DataTable _resultTable;
        public Penalties()
        {
            _databaseOperations = new DatabaseOps();
            _resultTable = new DataTable();
        }

        public DataTable ListPenalties()
        {
            try
            {
                var sqlWhiteList = @"Select * from dbo.t_pnt_penalty_definition";
                sqlWhiteList = @"SELECT penalty_code as 'Penalty Code',penalty_desc as 'Penalty Description',ri_type_id as 'RI Type Id',penalty_type as 'Penalty Type',penalty_freq as 'Penalty Frequency',penalty_freq_unit as 'Penalty Frequency Unit',delivery_deadline_day,delivery_deadline_hr,delivery_deadline_min,penalty_value as 'Penalty Value',start_validity_date AS 'Start Validity Date',end_validity_date,created_date,created_by,last_modified,modified_by FROM dbo.t_pnt_penalty_definition";
                using (SqlCommand cmd = new SqlCommand(sqlWhiteList, DatabaseOps.OpenSqlConnection()))
                {
                    cmd.CommandType = CommandType.Text;
                    _resultTable = _databaseOperations.GetDataTable(cmd);
                    return _resultTable;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void BindPenaltyFrequncies(DropDownList ddplist)
        {
            try
            {
                var sqlWhiteList = @"Select freq_unit, freq_desc from t_lkup_frequency";
                using (SqlCommand cmd = new SqlCommand(sqlWhiteList, DatabaseOps.OpenSqlConnection()))
                {
                    cmd.CommandType = CommandType.Text;
                    _resultTable = _databaseOperations.GetDataTable(cmd);

                    foreach (DataRow drow in _resultTable.Rows)
                    {
                        ddplist.Items.Add(new ListItem(drow["freq_desc"].ToString(), drow["freq_unit"].ToString(), true));
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void BindFrequncies(DropDownList ddplist)
        {
            try
            {
                var sqlWhiteList = @"Select freq_unit, freq_desc from t_lkup_frequency"; //
                using (SqlCommand cmd = new SqlCommand(sqlWhiteList, DatabaseOps.OpenSqlConnection()))
                {
                    cmd.CommandType = CommandType.Text;
                    _resultTable = _databaseOperations.GetDataTable(cmd);

                    foreach (DataRow drow in _resultTable.Rows)
                    {
                        ddplist.Items.Add(new ListItem(drow["freq_desc"].ToString(), drow["freq_unit"].ToString(), true));
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        //Select work_collection_id, work_collection_code, description from t_rtn_work_collection_defn

        public void BindWorkCollection(DropDownList ddplist)
        {
            try
            {
                var sqlWhiteList = @"Select work_collection_id, work_collection_code, description from t_rtn_work_collection_defn";
                sqlWhiteList = @"Select a.work_collection_id, a.work_collection_code, a.description from t_rtn_work_collection_defn a where a.work_collection_id not in (Select work_collection_id from t_pnt_penalty_work_collection_mapping)";
                using (SqlCommand cmd = new SqlCommand(sqlWhiteList, DatabaseOps.OpenSqlConnection()))
                {
                    cmd.CommandType = CommandType.Text;
                    _resultTable = _databaseOperations.GetDataTable(cmd);

                    foreach (DataRow drow in _resultTable.Rows)
                    {
                        ddplist.Items.Add(new ListItem($"{drow["work_collection_code"].ToString()} - {drow["description"].ToString()}", drow["work_collection_id"].ToString().Trim(), true));
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void BindWorkCollection(ListBox ddplist)
        {
            try
            {
                var sqlWhiteList = @"Select work_collection_id, work_collection_code, description from t_rtn_work_collection_defn";
                sqlWhiteList = @"Select a.work_collection_id, a.work_collection_code, a.description from t_rtn_work_collection_defn a where a.work_collection_id not in (Select work_collection_id from t_pnt_penalty_work_collection_mapping)";
                using (SqlCommand cmd = new SqlCommand(sqlWhiteList, DatabaseOps.OpenSqlConnection()))
                {
                    cmd.CommandType = CommandType.Text;
                    _resultTable = _databaseOperations.GetDataTable(cmd);

                    foreach (DataRow drow in _resultTable.Rows)
                    {
                        ddplist.Items.Add(new ListItem($"{drow["work_collection_code"].ToString()} - {drow["description"].ToString()}", drow["work_collection_id"].ToString().Trim(), true));
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void BindPenalties(DropDownList ddplist)
        {
            try
            {
                var sqlWhiteList = @"Select penalty_type, description from t_lkup_penalty_type";
                using (SqlCommand cmd = new SqlCommand(sqlWhiteList, DatabaseOps.OpenSqlConnection()))
                {
                    cmd.CommandType = CommandType.Text;
                    _resultTable = _databaseOperations.GetDataTable(cmd);

                    foreach(DataRow drow in _resultTable.Rows)
                    {
                        ddplist.Items.Add(new ListItem(drow["description"].ToString(), drow["penalty_type"].ToString().Trim(), true));
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public int Save(t_pnt_penalty_definition penaltymodel, PenaltyWorkCollectionModel penaltyWCModel = null)
        {
            using(var dbContext = new IRSAdhocContext())
            {
                using (var tranx = dbContext.Database.BeginTransaction())
                {
                    var query = dbContext.t_pnt_penalty_definition.Find("", "");
                    if (query != null)
                    {
                        dbContext.Entry(query).State = System.Data.Entity.EntityState.Modified;
                    }
                    else
                    {
                        dbContext.t_pnt_penalty_definition.Add(penaltymodel);
                    }

                    tranx.Commit();
                }
            }

            return 1;
        }

        public int SavePenalty(PenaltiesModel penaltymodel, PenaltyWorkCollectionModel penaltyWCModel = null)
        {
            //penalty_limit, ,@penalty_limit
            int rowsAffected = 0;
            var sqlText2 = "";
            var sqlText = @"Insert into t_pnt_penalty_definition(penalty_code,penalty_desc,ri_type_id,penalty_type,penalty_freq,penalty_freq_unit,delivery_deadline_day,delivery_deadline_hr, 
                          delivery_deadline_min,penalty_value,start_validity_date,end_validity_date,created_date,created_by) values(@penalty_code,@penalty_desc,@ri_type_id,@penalty_type,@penalty_freq,@penalty_freq_unit,@delivery_deadline_day, @delivery_deadline_hr,@delivery_deadline_min,@penalty_value,@start_validity_date,@end_validity_date,@created_date,@created_by)";

            sqlText = @"INSERT INTO dbo.t_pnt_penalty_definition (penalty_code,penalty_desc,ri_type_id,frequency,penalty_type,penalty_freq,penalty_freq_unit,delivery_deadline_day
           ,delivery_deadline_hr,delivery_deadline_min,min_limit_accepted,max_limit_accepted,penalty_value,penalty_per_unit,failed_penalty_value,start_validity_date,end_validity_date
           ,created_date,created_by,last_modified,modified_by) VALUES (@penalty_code,@penalty_desc,@ri_type_id,@frequency,@penalty_type,@penalty_freq,@penalty_freq_unit
           ,@delivery_deadline_day,@delivery_deadline_hr,@delivery_deadline_min,@min_limit_accepted,@max_limit_accepted,@penalty_value,@penalty_per_unit,@failed_penalty_value
           ,@start_validity_date,@end_validity_date,@created_date,@created_by,@last_modified,@modified_by)";

            using (TransactionScope transScope = new TransactionScope(TransactionScopeOption.Required))
            {
                using (SqlCommand command = new SqlCommand(sqlText, DatabaseOps.OpenSqlConnection()))
                {
                    command.CommandType = CommandType.Text;

                    command.Parameters.AddWithValue("@penalty_code", penaltymodel.penalty_code);
                    command.Parameters.AddWithValue("@penalty_desc", penaltymodel.penalty_desc);
                    command.Parameters.AddWithValue("@ri_type_id", penaltymodel.ri_type_id);
                    command.Parameters.AddWithValue("@frequency", penaltymodel.frequncy);
                    command.Parameters.AddWithValue("@penalty_type", penaltymodel.penalty_type);
                    command.Parameters.AddWithValue("@penalty_freq", penaltymodel.penalty_freq);
                    command.Parameters.AddWithValue("@penalty_freq_unit", penaltymodel.penalty_freq_unit);

                    //min_limit_accepted,max_limit_accepted,failed_penalty_value,

                    #region conditional check
                    if (penaltymodel.delivery_deadline_day == null)
                        command.Parameters.AddWithValue("@delivery_deadline_day", DBNull.Value);
                    else
                        command.Parameters.AddWithValue("@delivery_deadline_day", penaltymodel.delivery_deadline_day);

                    if (penaltymodel.delivery_deadline_hr == null)
                        command.Parameters.AddWithValue("@delivery_deadline_hr", DBNull.Value);
                    else
                        command.Parameters.AddWithValue("@delivery_deadline_hr", penaltymodel.delivery_deadline_hr);

                    if (penaltymodel.delivery_deadline_min == null)
                        command.Parameters.Add("@delivery_deadline_min", DBNull.Value);
                    else
                        command.Parameters.Add("@delivery_deadline_min", penaltymodel.delivery_deadline_min);
                    #endregion

                    if (penaltymodel.min_limit_accepted == decimal.MinValue)
                        command.Parameters.AddWithValue("@min_limit_accepted", penaltymodel.min_limit_accepted);
                    else
                        command.Parameters.Add("@min_limit_accepted", penaltymodel.min_limit_accepted);

                    if (penaltymodel.max_limit_accepted == decimal.MinValue)
                        command.Parameters.AddWithValue("@max_limit_accepted", penaltymodel.max_limit_accepted);
                    else
                        command.Parameters.Add("@max_limit_accepted", penaltymodel.max_limit_accepted);

                    command.Parameters.AddWithValue("@penalty_value", penaltymodel.penalty_value);
                    command.Parameters.AddWithValue("@penalty_per_unit", penaltymodel.penalty_per_unit/*.Equals("0") ? false : true*/);

                    if(String.IsNullOrWhiteSpace(penaltymodel.failed_penalty_value))
                        command.Parameters.Add("@failed_penalty_value", DBNull.Value);
                    else
                        command.Parameters.AddWithValue("@failed_penalty_value", penaltymodel.failed_penalty_value);

                    command.Parameters.Add("@start_validity_date", SqlDbType.DateTime).SqlValue = penaltymodel.start_validity_date.ToShortDateString();

                    if (penaltymodel.end_validity_date == null || penaltymodel.end_validity_date == DateTime.MinValue)
                        command.Parameters.Add("@end_validity_date", SqlDbType.DateTime).SqlValue = DBNull.Value;
                    else
                        command.Parameters.Add("@end_validity_date", SqlDbType.DateTime).SqlValue = penaltymodel.end_validity_date;

                    command.Parameters.AddWithValue("@created_date", SqlDbType.DateTime).SqlValue = penaltymodel.created_date;
                    command.Parameters.AddWithValue("@created_by", penaltymodel.created_by);
                    command.Parameters.Add("@last_modified", SqlDbType.DateTime).SqlValue = DBNull.Value;
                    command.Parameters.AddWithValue("@modified_by", SqlDbType.NVarChar).SqlValue = DBNull.Value;

                    if (command.Connection.State == ConnectionState.Closed)
                        command.Connection.Open();

                    rowsAffected = command.ExecuteNonQuery();

                    if (penaltyWCModel != null)
                    {
                        //rowsAffected += new PenaltyWorkCollection().SavePenaltyWorkCollection(penaltyWCModel);
                        if (penaltyWCModel.work_collection_id.Count > 0) //More than one work collection was added to only one penalty
                        {
                            foreach (var key in penaltyWCModel.work_collection_id.Keys)
                            {
                                sqlText2 = @"insert into t_pnt_penalty_work_collection_mapping(penalty_code,work_collection_id,created_date,created_by) values (@penalty_code, @work_collection_id, @created_date, @created_by)";
                                using (SqlCommand command2 = new SqlCommand(sqlText2, DatabaseOps.OpenSqlConnection()))
                                {
                                    command2.CommandType = CommandType.Text;

                                    command2.Parameters.AddWithValue("@penalty_code", penaltyWCModel.penalty_code);
                                    command2.Parameters.AddWithValue("@work_collection_id", key);
                                    command2.Parameters.AddWithValue("@created_date", penaltyWCModel.created_date);
                                    command2.Parameters.AddWithValue("@created_by", penaltyWCModel.created_by);

                                    //command2.Parameters.AddWithValue("@last_modified", SqlDbType.DateTime).SqlValue = DBNull.Value; //penaltymodel.last_modified;
                                    //command2.Parameters.AddWithValue("@modified_by", DBNull.Value);

                                    if (command2.Connection.State == ConnectionState.Closed)
                                        command2.Connection.Open();

                                    rowsAffected += command2.ExecuteNonQuery();
                                }
                            }
                        }
                    }
                }
                transScope.Complete();
                return rowsAffected;
            }
        }
    }

    public class PenaltiesModel
    {
        [Required]
        [MaxLength(40)]
        public String penalty_code { get; set; }

        [Required]
        [MaxLength(2048)]
        public String penalty_desc { get; set; }

        [Required]
        public Int32 ri_type_id { get; set; }

        [Required]
        [MaxLength(4)]
        public String penalty_type { get; set; }

        [Required]
        [MaxLength(2)]
        public String penalty_freq { get; set; }

        [Required]
        [MaxLength(2)]
        public String frequncy { get; set; }

        [Required]
        public Int32 penalty_freq_unit { get; set; }

        public Int32? delivery_deadline_day { get; set; }

        public Int32? delivery_deadline_hr { get; set; }

        public Int32? delivery_deadline_min { get; set; }

        public decimal min_limit_accepted { get; set; } = 0;

        public decimal max_limit_accepted { get; set; } = 0;

        [Required]
        public Boolean penalty_per_unit { get; set; } = false;

        public String failed_penalty_value { get; set; } = null;

        public decimal? penalty_limit { get; set; }

        [Required]
        public decimal penalty_value { get; set; }

        [Required]
        public DateTime start_validity_date { get; set; }

        public Nullable<DateTime> end_validity_date { get; set; }

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