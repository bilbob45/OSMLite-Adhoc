using Adhocs.Logic.Infrastructure;
using Adhocs.Logic.ServiceHandler;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Adhocs.penalty
{
    public partial class vpenalty : BasePage
    {
        Penalties _penalties = new Penalties();
        PenaltiesModel _penaltiesModel = new PenaltiesModel();
        readonly private string NEW_PENALTY_PAGE_URL = "~/penalty/npenalty.aspx?uname=";
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                //Get the user name of the currently logged in user and decrypt it
                if (!String.IsNullOrWhiteSpace(Request.QueryString[SharedConst.QUERY_STRING_USER_NAME]))
                {
                    currentUser = Request.QueryString[SharedConst.QUERY_STRING_USER_NAME];

                    //uncomment this below line when the encryption
                    //var encryptedQueryString = Request.QueryString[SharedConst.QUERY_STRING_USER_NAME];
                    //encryptedQueryString = HttpUtility.UrlDecode(encryptedQueryString.Trim());
                    //currentUser = CryptoServiceHandler.Decrypt(currentUser, CryptoServiceHandler.ENCRYPTION_PASS_PHRASE);
                }
                else
                {
                    this.frmPenalty.Visible = false;
                }

                if (!Page.IsPostBack)
                {
                    this.gridViewPenalties.DataSource = new Penalties().ListPenalties();
                    this.gridViewPenalties.DataBind();
                }
            }
            catch (Exception ex)
            {
                LogUtitlity.LogToText(ex.ToString());

            }
        }

        protected void gridViewPenalties_SelectedIndexChanged(object sender, EventArgs e)
        {
            var selectedRow = this.gridViewPenalties.SelectedRow;
            var penalty_code = selectedRow.Cells[1].Text;
        }

        protected void lblAddNewPenalty_ServerClick(object sender, EventArgs e)
        {
            try
            {
                Response.Redirect(NEW_PENALTY_PAGE_URL + currentUser);
            }
            catch (Exception ex)
            {
                LogUtitlity.LogToText(ex.ToString());
            }
        }

        protected void lblEditPenalty_ServerClick(object sender, EventArgs e)
        {
            var selectedPenalty = this.gridViewPenalties.SelectedRow;
            if (selectedPenalty == null)
                return;
            else
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "Pop", "openModalViewPenalty();", true);

                this.lblPenaltyCode.InnerText = selectedPenalty.Cells[1].Text.Trim();
                this.lblPenaltyDescription.InnerText = selectedPenalty.Cells[2].Text.Trim();
                this.lblRiType.InnerText = selectedPenalty.Cells[3].Text.Trim();
                this.lblPenaltyType.InnerText = selectedPenalty.Cells[4].Text.Trim();
                this.lblPenaltyFrequency.InnerText = selectedPenalty.Cells[5].Text.Trim();
                this.lblPenaltyFrequencyUnit.InnerText = selectedPenalty.Cells[6].Text.Trim();
                this.lblDeliveryDay.InnerText = selectedPenalty.Cells[7].Text.Trim();
                this.lblDeliveryHour.InnerText = selectedPenalty.Cells[8].Text.Trim();
                this.lblDeliveryMinute.InnerText = selectedPenalty.Cells[9].Text.Trim();
                this.lblPenaltyLimit.InnerText = selectedPenalty.Cells[10].Text.Trim();
                this.lblPenaltyvalue.InnerText = selectedPenalty.Cells[11].Text.Trim();
                this.lblValidityStart.InnerText = selectedPenalty.Cells[12].Text.Trim();
                this.lblValidityEnd.InnerText = selectedPenalty.Cells[13].Text.Trim();

                this.lblCreatedBy.InnerText = selectedPenalty.Cells[14].Text.Trim();
                this.lblCreatedDate.InnerText = selectedPenalty.Cells[15].Text.Trim();
            }
        }

        protected void gridViewPenalties_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            try
            {
                if (e.Row.Cells.Count > 0)
                {
                    e.Row.Cells[7].Visible = false;
                    e.Row.Cells[8].Visible = false;
                    e.Row.Cells[9].Visible = false;
                    e.Row.Cells[10].Visible = false;
                    e.Row.Cells[12].Visible = false;
                    e.Row.Cells[13].Visible = false;
                    e.Row.Cells[14].Visible = false;
                    e.Row.Cells[15].Visible = false;
                    e.Row.Cells[16].Visible = false;
                    e.Row.Cells[17].Visible = false;
                }
            }
            catch (Exception ex)
            {
                LogUtitlity.LogToText(ex.ToString());
            }
        }
    }
}