using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Adhocs.Logic.ServiceHandler;
using Adhocs.Logic.Object;
using Adhocs.Logic.Infrastructure;

using System.Web.ModelBinding;

namespace Adhocs.SysManagement
{
    public partial class sysmanagement : BasePage
    {
        TCoreUsers _users = new TCoreUsers();
        TCoreUsersObject _usersObj = new TCoreUsersObject();
        static string _commandName = null;
        static string _userId = null;
        int _rowIndex = 0;
        static string _userName = null;
        static string _twofactor = null;
        static string _email = null;
        static string _isActive = null;
        static string _mailConfirmed = null;

        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                //check if a success message is inside the stack
                if (base.Error.Count > 0)
                {
                    this.frmsysmanagement.Visible = false;
                    return;
                }                

                if(!Page.IsPostBack)
                {
                    var allUser = _users.GetAllUser(new TCoreUsersObject
                    {
                        user_name = "Admin"
                    });
                    this.gridViewListUser.DataSource = allUser;
                    this.gridViewListUser.DataBind();
                }
            }
            catch(Exception ex)
            {
                LogUtitlity.LogToText(ex.ToString());
            }
        }

        protected void gridViewListUser_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        protected void btnDissableToken_Command(object sender, CommandEventArgs e)
        {
            _commandName = e.CommandName;
            if (String.IsNullOrWhiteSpace(_commandName))
                return;

            _userId = e.CommandArgument.ToString();
            _rowIndex = ((sender as Button).NamingContainer as GridViewRow).RowIndex;

            _userName = this.gridViewListUser.Rows[_rowIndex].Cells[2].Text;
            _email = this.gridViewListUser.Rows[_rowIndex].Cells[6].Text;
            _twofactor = this.gridViewListUser.Rows[_rowIndex].Cells[9].Text;
            _isActive = this.gridViewListUser.Rows[_rowIndex].Cells[7].Text;
            _mailConfirmed = this.gridViewListUser.Rows[_rowIndex].Cells[8].Text;

            if (_commandName.Equals("DisableToken"))
            {
                string action = (_twofactor == "Disabled") ? "enable" : "disable";
                lblErrorMsgConfirm.Text = $"The selected user <b>{_userName}</b> is currently <b>{_twofactor}</b> please confirm that you want to change the token status to  <b>{action}</b>";
            }
            else if(_commandName.Equals("DeactivateUser"))
            {
                string action = (_isActive == "Active") ? "Not Active" : "Active";
                lblErrorMsgConfirm.Text = $"The selected user <b>{_userName}</b> is currently <b>{_isActive}</b> please confirm that you want to change the is active status to <b>{action}<b/>";
            }
            else if (_commandName.Equals("ConfirmMail"))
            {
                string action = (_mailConfirmed == "Confirmed") ? "Not Confirmed" : "Confirmed";
                lblErrorMsgConfirm.Text = $"The email confirmation status of the selected user <b>{_userName}</b> is currently <b>{_mailConfirmed}</b>. Please confirm that you want to change the email status to <b>{action}</b>";
            }
            else
            {
                return;
            }

            ClientScript.RegisterStartupScript(this.GetType(), "Dissable Token", "ConfirmDeactivation()", true);
        }

        protected void btnProceed_ServerClick(object sender, EventArgs e)
        {
            int PerformAction()
            {
                int value = 0;
                if (_commandName.Equals("DisableToken"))
                {
                    value = _users.SetTwoFactor(new TCoreUsersObject
                    {
                        app_user_id = _userId
                    }, (_twofactor.Equals("Enable") ? false : true));
                }
                else if(_commandName.Equals("DeactivateUser"))
                {
                    value = _users.ActivateUser(new TCoreUsersObject
                    {
                        app_user_id = _userId
                    }, (_isActive.Equals("Active") ? false : true));
                }
                else  if(_commandName.Equals("ConfirmMail"))
                {
                    value = _users.ConfirmEmail(new TCoreUsersObject
                    {
                        app_user_id = _userId
                    }, (_mailConfirmed.Equals("Confirmed") ? false : true));
                }
                else
                {

                }

                return value;
            };

            int isSuccess = PerformAction();
            if (isSuccess > 0)
            {
                this.divAlert.Visible = true;
                lblError.Text = "Changes saved successfuly";
            }
        }

        protected void gridViewListUser_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            try
            {
                e.Row.Cells[1].Visible = false;
            }
            catch(Exception ex)
            {
                LogUtitlity.LogToText(SharedConst.Ad_HOC_LOG_PATH, ex.ToString());
            }
        }

        protected void sysMgtTimer_Tick(object sender, EventArgs e)
        {
            var allUser = _users.GetAllUser(new TCoreUsersObject
            {
                user_name = "Admin"
            });
            this.gridViewListUser.DataSource = allUser;
            this.gridViewListUser.DataBind();
        }
    }
}