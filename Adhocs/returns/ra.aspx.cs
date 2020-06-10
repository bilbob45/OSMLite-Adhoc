using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Globalization;
using Adhocs.App_Code.ServiceHandler;
using Adhocs.App_Code.Objects;
using Adhocs.App_Code.DatabaseHandler;

namespace Adhocs.returns
{
    public partial class return_ra : System.Web.UI.Page
    {
        private String ReturnTableName { get; set; }
        private String ScheduleId { get; set; }
        public String RunId { get; set; }
        public String AnalystComment { get; set; }
        public Decimal CurrencyModif { get; set; }





        ReturnInstitutionType riType = new ReturnInstitutionType();
        ReturnInstitutions ri = new ReturnInstitutions();
        ReturnAdjustment returnHandler = new ReturnAdjustment();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                try
                {
                    this.txtDate.Value = "2019-03-31 00:00:00.000"; //DateTime.Now.ToString();
                    riType.GetAllRIType(this.cmbInstitutionType);
                }
                catch (Exception ex)
                {
                    divAlert.Visible = true;
                    lblErrorMsg.Text = ex.Message;
                }
            }
        }

        protected void cmbInstitutionType_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (this.cmbInstitutionType.SelectedItem.ToString() != null)
            {
                //Get the reporting institution tables
                var ricodeByType = riType.ConverRITypeIDToCode(this.cmbInstitutionType.SelectedValue);


                //riType.GetTableSurfixByRIType(this.cmbTableNames, riType.ConverRITypeIDToCode(this.cmbInstitutionType.SelectedValue));

                //Display the reporting intitution id
                var ritypeId = Convert.ToInt32(this.cmbInstitutionType.SelectedValue);

                if (!String.IsNullOrWhiteSpace(ritypeId.ToString()))
                {
                    //Bind all return institution to the dropdown control
                    ri.GetReturnInstitutions(this.cmbReportingInstitution, ritypeId);
                }
                else
                {
                    divAlert.Visible = true;
                    lblErrorMsg.Text = "Please select an institution type";
                }
            }
        }

        protected void lblSubmit_ServerClick(object sender, EventArgs e)
        {
            #region Conditional Check
            if (this.cmbInstitutionType.SelectedIndex < 1)
            {
                divAlert.Visible = true;
                lblErrorMsg.Text = "Institution type is required";
                return;
            }
            else if (this.cmbReportingInstitution.SelectedIndex < 1)
            {
                divAlert.Visible = true;
                lblErrorMsg.Text = "Reporting institution type is required";
                return;
            }
            #endregion

            try
            {
                //Build schedule for analyst return paramter
                ReturnAdjustmentObject returnObject = new ReturnAdjustmentObject()
                {
                    ri_id = Convert.ToInt32(this.cmbReportingInstitution.SelectedValue),
                    work_collection_date = Convert.ToDateTime(this.txtDate.Value)
                };

                //Get the schedule for analyst return parameter
                DataTable dataTableForScheduleAnalystToAdjust = returnHandler.GetScheduleForAnalystAdjustment(returnObject);

                //Check of there exists returns to be adjusted
                if (dataTableForScheduleAnalystToAdjust.Rows.Count > 0)
                {
                    this.ScheduleId = dataTableForScheduleAnalystToAdjust.Rows[0]["schedule_id"].ToString();
                    this.RunId = dataTableForScheduleAnalystToAdjust.Rows[0]["run_id"].ToString();
                    this.AnalystComment = dataTableForScheduleAnalystToAdjust.Rows[0]["analyst_comment"].ToString();

                    if (!String.IsNullOrWhiteSpace(this.ScheduleId))
                    {
                        //Get the institution code by institution type name
                        var returnInstitutionCode = new RITypeHandler().ConverRITypeIDToCode(this.cmbInstitutionType.SelectedValue).ToLower();
                        var adjustmentTablePref1 = returnHandler.AjustmentTableBuilder(returnInstitutionCode, "MBR300").ToLower();
                        var adjustmentTablePref2 = returnHandler.AjustmentTableBuilder(returnInstitutionCode, "MBR1000").ToLower();
                        var submissionTableName1 = String.Concat(returnInstitutionCode, ".", adjustmentTablePref1);
                        var submissionTableName2 = String.Concat(returnInstitutionCode, ".", adjustmentTablePref2);

                        this.griviewReturnAdjusted.DataSource = returnHandler.GetColumnToAdjustInMBR300Return(submissionTableName1, this.cmbReportingInstitution.SelectedValue, this.ScheduleId);
                        this.griviewReturnAdjusted.DataBind();

                        this.GridView1.DataSource = returnHandler.GetColumnToAdjustInMBR1000Return(submissionTableName2, this.cmbReportingInstitution.SelectedValue, this.ScheduleId);
                        this.GridView1.DataBind();

                        try
                        {
                            foreach (GridViewRow grdRow in this.griviewReturnAdjusted.Rows)
                            {
                                grdRow.Cells[4].Text = ConvertDecimalToMoney(Convert.ToDecimal(grdRow.Cells[4].Text));
                            }
                        }
                        catch (FormatException fex)
                        {
                            return;
                        }
                    }
                    else
                    {
                        divAlert.Visible = true;
                        lblErrorMsg.Text = "There is no schedule available for to the selected return institution";
                        return;
                    }
                }
                else
                {
                    divAlert.Visible = true;
                    lblErrorMsg.Text = "There is no record(s) to display from the selected date";
                    return;
                }
            }
            catch (Exception ex)
            {
                lblErrorMsg.Text = ex.Message;
                divAlert.Visible = true;
            }
        }

        private String ConvertDecimalToMoney(decimal decimalnumber)
        {
            return decimalnumber.ToString("C3", CultureInfo.CurrentCulture);
        }

        protected void lblAdjustReturn_ServerClick(object sender, EventArgs e)
        {

        }

        protected void griviewReturnAdjusted_RowEditing(object sender, GridViewEditEventArgs e)
        {
            try
            {
                e.NewEditIndex = 4;
                this.griviewReturnAdjusted.DataSource = returnHandler.GetColumnToAdjustInMBR300Return(this.ReturnTableName, this.cmbReportingInstitution.SelectedValue, this.ScheduleId);
                this.griviewReturnAdjusted.DataBind();
            }
            catch (Exception ex)
            {
                divAlert.Visible = true;
                lblErrorMsg.Text = ex.ToString();
            }
        }

        protected void griviewReturnAdjusted_SelectedIndexChanged(object sender, EventArgs e)
        {
            //ClientScript.RegisterStartupScript(this.GetType(), "pop", "JQuery('#').modal('show')", true);
            var gridViewSelectedRow = this.griviewReturnAdjusted.SelectedRow;

            lblItemCode.InnerText = String.Format("{0} : {1}", "Item Code", gridViewSelectedRow.Cells[2].Text);
            lblDescriptionToModify.InnerText = String.Format("{0} : {1}", "Item Description", gridViewSelectedRow.Cells[3].Text);
            lblLocalCurrencyToModify.InnerText = String.Format("{0} : {1}", "Local Currency (Old)", gridViewSelectedRow.Cells[4].Text);
        }

        protected void griviewReturnAdjusted_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            try
            {
                this.griviewReturnAdjusted.PageIndex = e.NewPageIndex;
                this.griviewReturnAdjusted.DataSource = returnHandler.GetColumnToAdjustInMBR300Return(this.ReturnTableName, this.cmbReportingInstitution.SelectedValue, this.ScheduleId);
                this.griviewReturnAdjusted.DataBind();
            }
            catch (Exception ex)
            {
                return;
            }
        }

        protected void btnProceedToReturnAdjustment_ServerClick(object sender, EventArgs e)
        {
            ClientScript.RegisterStartupScript(this.GetType(), "pop", "$('#exampleModalCenter').modal('show')", false);

            if (String.IsNullOrWhiteSpace(this.txtNewCurrencyValue.Value))
            {
                divAlertInPopup.Visible = true;
                lblErrorMsgInPopup.Text = "Local currency value is required";
                return;
            }

            if (Session["analystcomment"] == null)
            {

            }
        }

        protected void griviewReturnAdjusted_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {

        }

        protected void griviewReturnAdjusted_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            var gridViewSelectedRow = this.griviewReturnAdjusted.SelectedRow;
            //Page.ClientScript.RegisterStartupScript(this.GetType(), "EditReturnAdjustment", "EditReturnAdjustment()", true);
        }
    }
}