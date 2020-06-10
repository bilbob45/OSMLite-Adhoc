using Adhocs.Logic.DatabaseHandler;
using Adhocs.Logic.Objects;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace Adhocs.Logic.ServiceHandler
{
    public class VRTNWorkCollectionHandler
    {
        DatabaseOps _databaseOperations;
        DataTable _resultTable;
        VRTNWorkCollectionObject _vrtnworkcollectionobject;
        public VRTNWorkCollectionHandler()
        {
            _databaseOperations = new DatabaseOps();
            _resultTable = new DataTable();
        }

        public VRTNWorkCollectionHandler(VRTNWorkCollectionObject vrtnworkcollectionobject)
        {
            _vrtnworkcollectionobject = vrtnworkcollectionobject;
            _databaseOperations = new DatabaseOps();
            _resultTable = new DataTable();
        }

        public DataTable GetAll(VRTNWorkCollectionObject vrtnworkcollectionobject)
        {
            return new DataTable();
        }
    }
}