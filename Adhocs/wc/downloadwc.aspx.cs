using Adhocs.Logic.Infrastructure;
using Adhocs.Logic.ServiceHandler;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Adhocs.wc
{
    public partial class downloadwc : BasePage
    {
        TCoreRiType _tCoreRitype = new TCoreRiType();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (base.Error.Count > 0)
            {
                this.frmDownloadWc.Visible = false;
                return;
            }

            if (!Page.IsPostBack)
            {
                _tCoreRitype.BindAllRiTypes(this.cmbInstitutionType, base.currentUser);
                this.cmbInstitutionType.Items.Insert(0, new ListItem(SharedConst.DEFAULT_DROP_DOWN_SELECTION, "0", true));
            }
        }

        protected void cmbInstitutionType_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (this.cmbInstitutionType.SelectedItem.ToString() != null)
            {
                try
                {
                    var instTypeId = this.cmbInstitutionType.SelectedValue;

                    var ritypeId = Convert.ToInt32(this.cmbInstitutionType.SelectedValue);
                    if (!String.IsNullOrWhiteSpace(ritypeId.ToString()))
                    {
                        ReturnInstitutions ri = new ReturnInstitutions();
                        ri.GetReturnInstitutionsByTypeId(this.cmbReportingInstitution, ritypeId);
                    }
                    else
                    {
                        divAlert.Visible = true;
                        lblErrorMsg.Text = "Please select an institution type";
                    }
                }
                catch (Exception ex)
                {
                    LogUtitlity.LogToText(ex.ToString());
                }
            }
        }

        protected void gridviewLeft300_RowDataBound(object sender, GridViewRowEventArgs e)
        {

        }

        protected void gridviewLeft300_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        protected void A1_ServerClick(object sender, EventArgs e)
        {

        }

        protected void btnViewDetails_ServerClick(object sender, EventArgs e)
        {

        }
    }
}