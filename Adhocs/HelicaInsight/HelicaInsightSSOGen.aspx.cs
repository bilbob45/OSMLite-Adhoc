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

namespace Adhocs.HelicaInsight
{
    public partial class HelicaInsightSSOGen : BasePage
    {
        private string _stringToencrypt = null;
        private string _helicaInstallationPath = null;
        private string _defaultRole = "";
        private string _urlSafeencToken = null;
        private DateTime _expTime = DateTime.Now;
        public TCoreUsers _tCoreUser = new TCoreUsers();
        public string _useDefault = string.Empty;
        public string _defaultTime = "01:59:00 WAT";

        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if(!Page.IsPostBack)
                {
                    if(base.Error.Count > 0)
                    {
                        divAlert.Visible = true;
                        lblErrorMsg.Text = base.Error[0];
                        return;
                    }

                    _helicaInstallationPath = SharedConst.HELICA_INSTALLATION_PATH ?? null;
                    if (_helicaInstallationPath == null || _helicaInstallationPath.Length < 1)
                    {
                        divAlert.Visible = true;
                        lblErrorMsg.Text = "Cant load the query builder! please contact system administrator";
                    }
                }
                
                //Get the user name of the currently logged in user and decrypt it and the UseDefault property value                
                currentUser = Request.QueryString[SharedConst.QUERY_STRING_USER_NAME] ?? null;

                if (!String.IsNullOrWhiteSpace(currentUser))
                {
                    currentUser = Request.QueryString[SharedConst.QUERY_STRING_USER_NAME];
                    _useDefault = Request.QueryString["usedefault"] ?? null;

                    //Get the users role and company i.e user institution
                    var user = new TCoreUsersObject()
                    {
                        user_name = currentUser
                    };

                    List<VRTNUserDeptRoleForQbObject> units = _tCoreUser.Roles(user);
                    if (units == null || units.Count < 1)
                    {
                        //_stringToencrypt = $"username={currentUser}|role={_defaultRole}|company={_companyName}";
                        _stringToencrypt = $"username={currentUser}|role={SharedConst.HELICA_DEFAULT_ROLENAME}";
                    }
                    else
                    {
                        foreach (var unit in units)
                        {
                            if(_defaultRole == "")
                                _defaultRole = $"{unit.role_name}";
                            else
                                _defaultRole = $"{_defaultRole},{unit.role_name}";
                        }

                        _stringToencrypt = $"username={currentUser}|role={_defaultRole.TrimEnd(',')}";
                    }

                    //if (_useDefault == null || _useDefault.Length < 1)
                    //{
                    //    //_stringToencrypt = $"username={currentUser}|role={_defaultRole}|company={_companyName}";
                    //    //_stringToencrypt = $"username={currentUser}|role={SharedConst.HELICA_DEFAULT_ROLENAME}";
                    //}

                    //if (_useDefault.Equals("true") == true)
                    //{
                        
                    //}
                    //else
                    //    return;
                }
                else
                {
                    divAlert.Visible = true;
                    this.lblErrorMsg.Text = "Username can't be decoded or helica insight cant be found! please contact the administrator";
                    this.qbNew.Disabled = true;
                    return;
                }

                //The aes cryptographic key
                if (SharedConst.HELICA_DEFAULT_CYPHER_KEY != null && SharedConst.HELICA_DEFAULT_CYPHER_KEY.Length > 0)
                {
                    //Encrypt the currently logged-in username using aes encryption
                    var encToken = AESEncryptionUtil.EncryptTextToBase64String(_stringToencrypt, SharedConst.HELICA_DEFAULT_CYPHER_KEY);

                    //Transform the encrypted string to a URL safe string
                    _urlSafeencToken = encToken.TrimEnd('=').Replace('+', '-').Replace('/', '_');
                    var helicaUrlStringBuilder = $"{_helicaInstallationPath}?authToken={_urlSafeencToken}";
                    
                    lblerror.Text = helicaUrlStringBuilder;
                    this.qbNew.HRef = helicaUrlStringBuilder;

                    Response.Redirect(helicaUrlStringBuilder, false);
                    //ScriptManager.RegisterStartupScript(Page, typeof(Page), "OpenWindow", $"loadTab({_helicaInstallationPath})", true);
                }
            }
            catch(Exception ex)
            {
                LogUtitlity.LogToText(SharedConst.Ad_HOC_LOG_PATH, ex.ToString());
            }
        }        
    }
}