using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;
using Adhocs.Logic.ServiceHandler;

namespace Adhocs.Logic.ServiceHandler
{
    public class QueryStore
    {
        String _conString;
        public QueryStore()
        {
            _conString = ConnectionString.GetConnectionString();
        }

        [Required]
        public Int32 script_id { get; set; }

        [Required]
        [MaxLength(128)]
        public String query_name { get; set; }

        [Required]
        [MaxLength(1024)]
        public String query_desc { get; set; }

        [Required]
        public String query_script { get; set; }

        [Required]
        public Boolean is_public { get; set; }

        [Required]
        public DateTime created_date { get; set; }

        [Required]
        [MaxLength(255)]
        public String created_by { get; set; }

        public DateTime last_modified { get; set; }

        [MaxLength(255)]
        public String modified_by { get; set; }

        public int SaveQueryToStore(QueryStore queryparam)
        {

            //Create the SQL Query for inserting an article
            string sqlQuery = String.Format("INSERT INTO t_db_query_script (query_name, query_desc, query_script) Values('{0}', '{1}', '{2}');Select @@Identity", queryparam.query_name, queryparam.query_desc, queryparam.query_script.Replace("'", "''"));

            //Create and open a connection to SQL Server 
            SqlConnection connection = new SqlConnection(_conString);
            connection.Open();

            //Create a Command object
            SqlCommand command = new SqlCommand(sqlQuery, connection);
            //command.Parameters.AddWithValue("", "");

            //Execute the command to SQL Server and return the newly created ID
            int newArticleID = Convert.ToInt32((decimal)command.ExecuteScalar());

            //Close and dispose
            command.Dispose();
            connection.Close();
            connection.Dispose();

            // Set return value
            return newArticleID;
        }

        public List<QueryStore> GetQueryFromStore()
        {
            List<QueryStore> result = new List<QueryStore>();

            //Create the SQL Query for returning all the articles
            string sqlQuery = String.Format("SELECT query_name, query_desc, query_script, created_date from t_db_query_script");

            //Create and open a connection to SQL Server 
            SqlConnection connection = new SqlConnection(_conString);
            connection.Open();

            SqlCommand command = new SqlCommand(sqlQuery, connection);

            //Create DataReader for storing the returning table into server memory
            SqlDataReader dataReader = command.ExecuteReader();

            QueryStore query = null;

            //load into the result object the returned row from the database
            if (dataReader.HasRows)
            {
                while (dataReader.Read())
                {
                    query.query_name = dataReader.GetString(0);
                    query.query_desc = dataReader.GetString(1);
                    query.query_script = dataReader.GetString(2);
                    query.created_date = Convert.ToDateTime(dataReader.GetString(3));
                    result.Add(query);
                }
            }

            return result;

        }

        public void GetQueryFromStore(System.Web.UI.WebControls.GridView grd)
        {

            List<QueryStore> result = new List<QueryStore>();

            //Create the SQL Query for returning all the articles
            string sqlQuery = String.Format("SELECT query_name AS 'Query Name', query_desc AS 'Query Description', query_script AS 'Query Script', created_date AS 'Created Date' from t_db_query_script");

            //Create and open a connection to SQL Server 
            SqlConnection connection = new SqlConnection(_conString);
            connection.Open();

            SqlCommand command = new SqlCommand(sqlQuery, connection);

            //Create Data Table for storing the returning table into server memory
            DataTable dataTable = new DataTable();
            SqlDataAdapter adapter = new SqlDataAdapter(command);

            adapter.Fill(dataTable);
            grd.DataSource = dataTable;
            grd.DataBind();
        }
    }
}