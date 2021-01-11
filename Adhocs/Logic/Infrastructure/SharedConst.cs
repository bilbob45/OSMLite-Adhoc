using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;

namespace Adhocs.Logic.Infrastructure
{
    public static class SharedConst
    {
        //Return adjustment table name surfix 
        public static  String MBR300_TABLE_SURFIX = "mbr300";
        public static  String MBR1000_TABLE_SURFIX = "mbr1000";
        public static  String MDHR300_TABLE_SURFIX = "mdhr300";
        public static  String MDHR1000_TABLE_SURFIX = "mdhr1000";
        public static  String MNBR300_TABLE_SURFIX = "mnbr300";
        public static  String MNBR1000_TABLE_SURFIX = "mnbr1000";

        //Return submission full table name
        public static String MBR300_SUBMISSION_TABLE = "cb.t_rtn_submission_mbr300";
        public static String MBR1000_SUBMISSION_TABLE = "cb.t_rtn_submission_mbr1000";
        public static String MDHR300_SUBMISSION_TABLE = "dh.t_rtn_submission_mdhr300";
        public static String MDHR1000_SUBMISSION_TABLE = "dh.t_rtn_submission_mdhr1000";
        public static String MNBR300_SUBMISSION_TABLE = "nib.t_rtn_submission_mnbr300";
        public static String MNBR1000_SUBMISSION_TABLE = "nib.t_rtn_submission_mnbr1000";

        //Shared submission table name
        public static  String SHARED_SUBMISSION_TABLE_NAME = "t_rtn_submission_";

        //Submission tables that have a slightly different column arrangement
        public static  String T_SUBMISSION_MDHR300 = "dh.t_rtn_submission_mdhr300";
        public static  String T_SUBMISSION_MDHR1000 = "dh.t_rtn_submission_mdhr1000";

        // values that are used as session variables
        public static  String S_SCHEDULE_ID = "schedule_id";
        public static  String S_RUN_ID = "run_id";
        public static  String S_ANALYST_COMMENTS = "analyst_comment";

        //Penalty constants
        public const String PENALTY_TYPE_RS = "1";
        public const String PENALTY_TYPE_NOT_RS = "2";

        //Drpdown constants
        public static String DEFAULT_DROP_DOWN_SELECTION = "--choose one--";

        //Query-string constants
        public static String QUERY_STRING_USER_NAME = "uname";
        public static String QUERY_STRING_BRC = "brc";

        //Dev type constant
        public static String DEV_TYPE = "devtype";

        //Computation rule active column index
        //public static int COMP_RULE_STATUS_COLUMN_INDEX = 4;
        public static int COMP_RULE_TYPE_COLUMN_INDEX = 4;
        public static String COMP_RULE_ACTIVE_COLUMN_TEXT = "Active";
        public static String COMP_RULE_INACTIVE_COLUMN_TEXT = "Inactive";
        public static String COMP_RULE_TYPE_TEXT_SIMPLE = "Simple";
        public static String COMP_RULE_TYPE_TEXT_COMPOUND = "Compound";

        //Session utility constants
        public static string SESSION_IS_MODIFIED = "Modif";

        //Restricted column list in rule adjustment
        public static String[] RESTRICTED_COLUMN_LIST_RULE = new string[] {"row_id", "Row Code", "Items"};

        //Error display constant
        public static string ERROR_SHARED_ERROR_MESSAGE = "Error - please contact the system administrator";

        //Reporting utility constants
        readonly public static string REPORT_VIEWER_PAGE_URL = "~/reports/rptviewer.aspx?uname=";
        readonly public static int REPORT_CODE_INDEX = 3;

        readonly public static String CONST_MONEY_INT_VALUE = "0.0";

        //Exception log path
        readonly public static String Ad_HOC_LOG_PATH = ConfigurationManager.AppSettings["AdhocLogPath"];

        //Helica Default Settings
        readonly public static String HELICA_DEFAULT_AUTHTOKEN = "edZjvfLYDLnDNHYtQVS1Tq5w1bqaAehYVqaOn43yPI0";
        readonly public static String HELICA_INSTALLATION_PATH = ConfigurationManager.AppSettings["HelicaInstallPath"];
        public const String HELICA_DEFAULT_ROLENAME = "ROLE_USER";
        readonly public static string HELICA_DEFAULT_CYPHER_KEY = "HSpnzzfCLqrBn8Lk";

        ///Return Builder ValidationExpression=""
        readonly public static string RETURN_BUILDER_DOWNLOAD_PATH = ConfigurationManager.AppSettings["RbDownloadDirPath"];
        readonly public static string RETURN_BUILDER_FILE_NAME_REGEX = "^(([a-zA-Z]:)|(\\{2}\\w+)\\$?)(\\(\\w[\\w].*))+(.zip|.ZIP|.7zip|.7ZIP)$";
    }
}