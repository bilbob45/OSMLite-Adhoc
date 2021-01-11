using Adhocs.Logic.Infrastructure;
using Adhocs.Logic.ServiceHandler;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.Services;
using Adhocs.Infrastructure;

namespace Adhocs.penalty
{
    public partial class vpenalty : BasePage
    {
        Penalties _penalties = new Penalties();
        PenaltiesModel _penaltiesModel = new PenaltiesModel();
        IRSAdhocContext _dbContext = null;
        ResponseHandler _response;
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

        [WebMethod]
        public static object GetPenaltyDetails(string pcode)
        {
            var response = new ResponseHandler();
            object query;

            var dbContext = new IRSAdhocContext();

            //query = dbContext.t_pnt_penalty_definition.Where(code => code.penalty_code == pcode)
            //    .Join(dbContext.t_core_ri_type)
            //    .Select(x => new {
            //    pcode = x.penalty_code,
            //    pdescription = x.penalty_desc,
            //    rtype = x.ri_type_id
            //}).FirstOrDefault();

            query = (from pdefn in dbContext.t_pnt_penalty_definition
                     join ritype in dbContext.t_core_ri_type
                        on pdefn.ri_type_id equals ritype.ri_type_id 
                        join lkupptype in dbContext.t_lkup_penalty_type 
                        on pdefn.penalty_type equals lkupptype.penalty_type
                        join lkupfreq in dbContext.t_lkup_frequency
                        on pdefn.frequency equals lkupfreq.freq_unit
                     select new
                     {
                         pcode = pdefn.penalty_code,
                         pdescription = pdefn.penalty_desc,
                         ritypedesc = ritype.description,
                         type = lkupptype.description,
                         freq = lkupfreq.freq_desc,
                         frequnit = pdefn.penalty_freq_unit,
                         dday = pdefn.delivery_deadline_day,
                         dhour = pdefn.delivery_deadline_hr,
                         dmin = pdefn.delivery_deadline_min,
                         plimit = pdefn.min_limit_accepted,
                         pvalue = pdefn.penalty_value,
                         pstartval = pdefn.start_validity_date,
                         pendtval = pdefn.end_validity_date,
                     }).FirstOrDefault();
            

            //if(query != null)
            //{
            //    response.Status = 1;
            //    response.Message = query;
            //    return response;
            //}
            //else
            //{
            //    response.Status = 0;
            //    response.Message = "The selected penalty details can not be found.";
            //    return response;
            //}

            return query;
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
            }
        }

        protected void gridViewPenalties_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            try
            {
                if (e.Row.RowType == DataControlRowType.Header)
                {
                    e.Row.TableSection = TableRowSection.TableHeader;
                }

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

        protected void btnView_ServerClick(object sender, EventArgs e)
        {
            try
            {
                HtmlButton btn = (HtmlButton)sender;

                //Get the row that contains this button
                GridViewRow gvr = (GridViewRow)btn.NamingContainer;

                int _rowIndex = ((GridViewRow)((Control)sender).NamingContainer).RowIndex;
                Session["rowindex"] = _rowIndex;
                GridViewRow selectedPenalty = gvr;

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
                }

                //get the leave id
                //int leaveId = Convert.ToInt32(this.gridViewPenalties.Rows[_rowIndex].Cells[1].Text);

                //get the staff identification number
                //string employeeId = this.gridViewPenalties.Rows[_rowIndex].Cells[2].Text;
            }
            catch (Exception ex)
            {
                Trace.Write(ex.ToString());
            }
        }
    }
}