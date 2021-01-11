using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Diagnostics;
using System.Threading.Tasks;
using Adhocs.Logic.ServiceHandler;
using System.Text;
using System.IO;
using Adhocs.Logic.Infrastructure;
using Adhocs.Logic.Object;
using System.Configuration;
using System.Web.Services;

namespace Adhocs.HelicaInsight
{
    public partial class HelicaInsightSSOGen : BasePage
    {
        private DateTime _expTime = DateTime.Now;
        public TCoreUsers _tCoreUser = new TCoreUsers();

        private string _stringToencrypt = null;
        private string _helicaInstallationPath = null;
        private string _roles = "";
        public string _company = "";
        private string _urlSafeencToken = null;        
        public string _useRole = null;
        public string _useCompany = null;

        protected void Page_Load(object sender, EventArgs e)
        {
            //try
            //{
            //    if(!Page.IsPostBack)
            //    {
            //        if(base.Error.Count > 0)
            //        {
            //            divAlert.Visible = true;
            //            lblErrorMsg.Text = base.Error[0];
            //            return;
            //        }

            //        _helicaInstallationPath = SharedConst.HELICA_INSTALLATION_PATH ?? null;
            //        if (_helicaInstallationPath == null || _helicaInstallationPath.Length < 1)
            //        {
            //            divAlert.Visible = true;
            //            lblErrorMsg.Text = "Cant load the query builder! please contact system administrator";
            //        }
            //    }
                
            //    //Get the user name of the currently logged in user and decrypt it and the UseDefault property value                
            //    currentUser = Request.QueryString[SharedConst.QUERY_STRING_USER_NAME] ?? null;

            //    if (!String.IsNullOrWhiteSpace(currentUser))
            //    {
            //        currentUser = Request.QueryString[SharedConst.QUERY_STRING_USER_NAME];
            //        //_useDefault = Request.QueryString["usedefault"] ?? null;
            //        //_useRole = Request.QueryString["role"] ?? null;
            //        _useCompany = (string.IsNullOrWhiteSpace(ConfigurationManager.AppSettings["company"])) ? "CBN_NDIC" : ConfigurationManager.AppSettings["company"];

            //        //Get the users role and company i.e user institution
            //        var user = new TCoreUsersObject()
            //        {
            //            user_name = currentUser
            //        };

            //        List<VRTNUserDeptRoleForQbObject> units = _tCoreUser.Roles(user);
            //        if (units == null || units.Count < 1)
            //        {
            //            //if current user doesn't belong to a role
            //            //Assign a deault role ROLE_USER to the role parameter on helica insight
            //            _stringToencrypt = $"username={currentUser}|role={SharedConst.HELICA_DEFAULT_ROLENAME}";
            //        }
            //        else
            //        {
            //            foreach (var unit in units)
            //            {
            //                if(_roles == "")
            //                    _roles = $"{unit.role_name}";
            //                else
            //                    _roles = $"{_roles},{unit.role_name}";
            //            }

            //            _stringToencrypt = $"username={currentUser}|role={_roles.TrimEnd(',')}";

            //            if (_useCompany != null)
            //            {
            //                //Get the user company name if it exists - example CBN or NDIC
            //                //and modify the helica SSO string accordingly
            //                if (!string.IsNullOrWhiteSpace(_tCoreUser.UserInst(currentUser)))
            //                {
            //                    _stringToencrypt = $"username={currentUser}|role={_roles.TrimEnd(',')}|company={_useCompany}";
            //                }
            //            }
            //        }
            //    }
            //    else
            //    {
            //        divAlert.Visible = true;
            //        this.lblErrorMsg.Text = "Username cant be empty";
            //        this.qbNew.Disabled = true;
            //        return;
            //    }

            //    //Check if the encryption key is available for use
            //    //else throw and log an error - encryption key not available
            //    if (SharedConst.HELICA_DEFAULT_CYPHER_KEY != null && SharedConst.HELICA_DEFAULT_CYPHER_KEY.Length > 0)
            //    {
            //        //Encrypt the currently logged-in username using aes encryption
            //        var encToken = AESEncryptionUtil.EncryptTextToBase64String(_stringToencrypt, SharedConst.HELICA_DEFAULT_CYPHER_KEY);

            //        //Transform the encrypted string to a URL safe string
            //        _urlSafeencToken = encToken.TrimEnd('=').Replace('+', '-').Replace('/', '_');
            //        var helicaUrlStringBuilder = $"{_helicaInstallationPath}?authToken={_urlSafeencToken}";
                    
            //        lblerror.Text = helicaUrlStringBuilder;
            //        this.qbNew.HRef = helicaUrlStringBuilder;

            //        Response.Redirect(helicaUrlStringBuilder, false);
            //        //ScriptManager.RegisterStartupScript(Page, typeof(Page), "OpenWindow", $"loadTab({_helicaInstallationPath})", true);
            //    }
            //    else
            //        LogUtitlity.LogToText("The encryption key cant be located");
            //}
            //catch(Exception ex)
            //{
            //    LogUtitlity.LogToText(ex.ToString());
            //}
        }        

        [WebMethod]
        public static object HelicaRun(string username)
        {
            var response = new ResponseHandler();
            TCoreUsers _tCoreUser = new TCoreUsers();
            string _stringToencrypt = string.Empty;

            try
            {
                string _helicaInstallationPath = ConfigurationManager.AppSettings["HelicaInstallPath"];
                if (_helicaInstallationPath == null || _helicaInstallationPath.Length < 1)
                {
                    response.Status = 0;
                    response.Message = "Cant load the query builder/BI tool! please contact system administrator";
                    return response;
                }

                //Get the user name of the currently logged in user and decrypt it and the UseDefault property value
                //string currentUser = username;

                if (!String.IsNullOrWhiteSpace(username))
                {
                    string _useCompany = (string.IsNullOrWhiteSpace(ConfigurationManager.AppSettings["company"])) ? "CBN_NDIC" : ConfigurationManager.AppSettings["company"];

                    //Get the users role and company i.e user institution
                    var user = new TCoreUsersObject()
                    {
                        user_name = username
                    };

                    List<VRTNUserDeptRoleForQbObject> units = _tCoreUser.Roles(user);
                    if (units == null || units.Count < 1)
                    {
                        //if current user doesn't belong to a role
                        //Assign a deault role ROLE_USER to the role parameter on helica insight
                        _stringToencrypt = $"username={username}|role={SharedConst.HELICA_DEFAULT_ROLENAME}";
                    }
                    else
                    {
                        string _roles = "";
                        foreach (var unit in units)
                        {
                            if (_roles == "")
                                _roles = $"{unit.role_name}";
                            else
                                _roles = $"{_roles},{unit.role_name}";
                        }

                        _stringToencrypt = $"username={username}|role={_roles.TrimEnd(',')}";

                        if (_useCompany != null)
                        {
                            //Get the user company name if it exists - example CBN or NDIC
                            //and modify the helica SSO string accordingly
                            if (!string.IsNullOrWhiteSpace(_tCoreUser.UserInst(username)))
                            {
                                _stringToencrypt = $"username={username}|role={_roles.TrimEnd(',')}|company={_useCompany}";
                            }
                        }
                    }
                }
                else
                {
                    response.Status = 0;
                    response.Message = "Username cant be empty";
                    return response;
                }

                //Check if the encryption key is available for use
                //else throw and log an error - encryption key not available
                if (SharedConst.HELICA_DEFAULT_CYPHER_KEY != null && SharedConst.HELICA_DEFAULT_CYPHER_KEY.Length > 0)
                {
                    //Encrypt the currently logged-in username using aes encryption
                    var encToken = AESEncryptionUtil.EncryptTextToBase64String(_stringToencrypt, SharedConst.HELICA_DEFAULT_CYPHER_KEY);

                    //Transform the encrypted string to a URL safe string
                    
                    string  _urlSafeencToken = encToken.TrimEnd('=').Replace('+', '-').Replace('/', '_');
                    var helicaUrlStringBuilder = $"{_helicaInstallationPath}?authToken={_urlSafeencToken}";

                    response.Status = 1;
                    response.Message = helicaUrlStringBuilder;
                    return response;
                }
                else
                    LogUtitlity.LogToText("The encryption key cant be located");
            }
            catch (Exception ex)
            {
                LogUtitlity.LogToText(ex.ToString());
            }

            return response;
        }
    }
}