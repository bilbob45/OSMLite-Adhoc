using Adhocs.Logic.DatabaseHandler;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace Adhocs.Logic.ServiceHandler
{
    public class ServiceBaseHandler
    {
        public DataTable DataTable { get; set; }
        public DatabaseOps DatabaseOps { get; }
        public SqlConnection Connection { get; }
        public string RealData { get; set; }
        public int RowsAffected { get; set; }

        public ServiceBaseHandler()
        {
            this.DataTable = new DataTable();
            this.DatabaseOps = new DatabaseOps();
            this.Connection = DatabaseOps.OpenSqlConnection();
        }
    }
}