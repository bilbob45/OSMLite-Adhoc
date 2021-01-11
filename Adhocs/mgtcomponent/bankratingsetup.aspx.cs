using Adhocs.Logic.Infrastructure;
using Adhocs.Logic.Object;
using Adhocs.Logic.ServiceHandler;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Adhocs.mgtcomponent
{
    public partial class bankratingsetup : BasePage
    {
        public String Param { get; set; } = "Management";
        TCoreRiType riType = new TCoreRiType();
        TRPComputationBankRatingSetupObject _bankRatingModel;
        TRPTComputationBankRatingSetupHandler _bankRatinghandler;

        public bankratingsetup()
        {
            _bankRatinghandler = new TRPTComputationBankRatingSetupHandler();
            //_util = new LogUtitlity()
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (base.Error.Count > 0)
                {
                    this.frmBankRating.Visible = false;
                    return;
                }

                //Check if the request is an update request
                string bankRatingCode = Request.QueryString[SharedConst.QUERY_STRING_BRC];
                if (!string.IsNullOrWhiteSpace(bankRatingCode))
                {
                    this.txtBankRatingCode.Value = bankRatingCode.Trim();
                    this.txtBankRatingCode.Disabled = true;
                    _bankRatingModel = _bankRatinghandler.GetBankRatingSetupDetails(bankRatingCode);
                    this.cmbRiType.SelectedValue = _bankRatingModel.ri_type_id.ToString();
                    this.txtParam.Value = _bankRatingModel.param;
                    this.txtDescription.Value = _bankRatingModel.description;
                    this.txtComponentWeight.Value = _bankRatingModel.component_weight;
                    this.txtStartValidityDate.Text = _bankRatingModel.start_validity_date.ToString();
                }

                if (!Page.IsPostBack)
                {
                    riType.BindAllRiTypes(this.cmbRiType);
                    this.cmbRiType.Items.Insert(0, new ListItem(SharedConst.DEFAULT_DROP_DOWN_SELECTION, "0", true));
                }
            }
            catch(Exception ex)
            {
                LogUtitlity.LogToText(ex.ToString());
                LogUtitlity.LogToText(ex.ToString());
            }
        }

        protected void cmbRiType_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        protected void cmbReportingInstitution_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        protected void txtStartValidityDate_TextChanged(object sender, EventArgs e)
        {
            string selectedDateTsring = this.txtStartValidityDate.Text.Trim();
            bool isDateValid = ValidateDate(selectedDateTsring);
            divAlert.Visible = true;
            if (isDateValid == true)
                divAlert.Visible = false;
            else
                lblError.Text = "The selcted date is not in the right format";
        }

        protected void txtEndValidityDate_TextChanged(object sender, EventArgs e)
        {

        }

        protected void btnGoBack_Click(object sender, EventArgs e)
        {
            try
            {
                string filePath = $"~/mgtcomponent/bankratingsetupview.aspx?uname={currentUser}";
                Response.Redirect(filePath);
            }
            catch(Exception ex)
            {
                LogUtitlity.LogToText(ex.ToString());
            }
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            _bankRatingModel = new TRPComputationBankRatingSetupObject();
            try
            {
                ValidateBusinessData();

                _bankRatingModel.bank_rating_code = this.txtBankRatingCode.Value.Trim();
                _bankRatingModel.ri_type_id = Convert.ToInt32(this.cmbRiType.SelectedValue.ToString());
                _bankRatingModel.param = this.txtParam.Value.Trim();
                _bankRatingModel.description = this.txtDescription.Value.Trim();
                _bankRatingModel.component_weight = this.txtComponentWeight.Value.Trim();
                _bankRatingModel.start_validity_date = Convert.ToDateTime(txtStartValidityDate.Text);
                _bankRatingModel.end_validity_date = DateTime.MinValue;
                _bankRatingModel.created_date = DateTime.Now;
                _bankRatingModel.created_by = currentUser;

                _bankRatinghandler = new TRPTComputationBankRatingSetupHandler();
                var rowsAffected = _bankRatinghandler.SaveComputationBankRatingSetup(_bankRatingModel);

                divAlert.Visible = true;
                divAlert.Attributes.Add("class", "alert alert-success alert-dismissible");

                if (rowsAffected > 0)
                {
                    lblError.Text = "Management component on bank rating saved successfully";
                }
                else
                    lblError.Text = "An error occured while saving changes";
            }
            catch (Exception ex)
            {
                if(ex.ToString().Contains("PRIMARY KEY"))
                {
                    //divAlert.Visible = true;
                    //divAlert.Attributes.Add("class", "alert alert-success alert-dismissible");
                    //_bankRatingModel.last_modified = DateTime.Now;
                    //_bankRatingModel.modified_by = currentUser;
                    //_bankRatinghandler.UpdateComputationBankRatingSetup(_bankRatingModel);
                }
                LogUtitlity.LogToText(ex.ToString());
            }
        }

        private void ValidateBusinessData()
        {
            //Component weight validation
            var componentWeight = this.txtComponentWeight.Value.Trim();
            decimal validComponent;
            var x = decimal.TryParse(componentWeight, out validComponent);
            divAlert.Visible = true;
            if (x == false || validComponent > 100)
                lblError.Text = "Component weight value must be less than or equal to 100";
            else
                divAlert.Visible = false;

            //Default parameter settings
            string param = this.txtParam.Value.Trim();
            if (string.IsNullOrWhiteSpace(param))
                Param = "Management";
        }

        private void PrefillControl()
        {
           
        }

        protected void txtBankRatingCode_ServerChange(object sender, EventArgs e)
        {
            //Rating code check
            //_bankRatinghandler = new TRPTComputationBankRatingSetupHandler();
            //var isFound = _bankRatinghandler.CheckDataExists(this.txtBankRatingCode.Value.Trim());
            //divAlert.Visible = true;
            //if (isFound == true)
            //{
            //    lblError.Text = "Bank rating code already exists";
            //}
            //else
            //    divAlert.Visible = false;
        }
    }
}