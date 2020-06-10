using Adhocs.Logic.ServiceHandler;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Adhocs.Logic.Infrastructure
{
    public class BasePage : System.Web.UI.Page
    {
        public TCoreUsers _user = new TCoreUsers();
        protected internal string currentUser = null;
        protected internal List<string> Error = new List<string>();

        public BasePage()
        {
            this.Load += new EventHandler(this.Page_Load);
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                this.currentUser = (Request.QueryString[SharedConst.QUERY_STRING_USER_NAME]) ?? null;
                if (!String.IsNullOrWhiteSpace(currentUser))
                {
                    //Get the username fromt the query string
                    currentUser = Request.QueryString[SharedConst.QUERY_STRING_USER_NAME].ToString();

                    //Check if the username is a valid base64 string

                    //if (currentUser.Length % 4 > 0)
                    //    return;

                    //decrypt the username from the querystring
                    //currentUser = AESEncryptionUtil.DecryptTextFromBase64String(currentUser, SharedConst.HELICA_DEFAULT_CYPHER_KEY);

                    //Check that username exists
                    var userExist = _user.Get(currentUser);
                    if (string.IsNullOrWhiteSpace(userExist))
                    {
                        Error.Add("Username doesn't exists");
                        LogUtitlity.LogToText("Username doesn't exists");
                    }
                }
                else
                {
                    Error.Add("Username cant be empty");
                    LogUtitlity.LogToText("Username cant be empty");
                    return;
                }
            }
            catch (Exception ex)
            {
                //Error.Add("Username not supplied");
                LogUtitlity.LogToText($"{ex.ToString()}");
                return;
            }
        }

        public static bool ValidateDate(string datetovalidate)
        {
            bool isvalid = false;
            DateTime outputDatetime = new DateTime();
            isvalid = DateTime.TryParse(datetovalidate, out outputDatetime);

            return isvalid;
        }
    }
}