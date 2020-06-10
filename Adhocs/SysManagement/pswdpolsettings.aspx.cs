using Adhocs.Logic.ServiceHandler;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Adhocs.SysManagement
{
    public partial class pswdpolsettings : System.Web.UI.Page
    {
        private TSysConfigurationIrsHandler _sysConfigHandler = new TSysConfigurationIrsHandler();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                this.gridViewPasswordPolicy.DataSource = _sysConfigHandler.GetAll();
                this.gridViewPasswordPolicy.DataBind();
            }
        }

        protected void btnSave_ServerClick(object sender, EventArgs e)
        {

        }

        protected void gridViewPasswordPolicy_SelectedIndexChanged(object sender, EventArgs e)
        {
            ScriptManager.RegisterStartupScript(this, this.GetType(), "Pop", "openModalPwPolicy();", true);
        }

        protected void gridViewPasswordPolicy_RowDataBound(object sender, GridViewRowEventArgs e)
        {

        }
    }
}