using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Web.UI;
using System.Web.UI.WebControls;
using Adhocs.Logic.ServiceHandler;
using Adhocs.Logic.Infrastructure;
using System.Data.SqlClient;

namespace Adhocs.penalty
{
    public partial class npenalty : BasePage
    {
        Penalties _penalties = new Penalties();
        PenaltiesModel _penaltiesModel = null;
        PenaltyWorkCollectionModel _penaltyWcModel = null;
        TCoreRiType _riType = new TCoreRiType();
        Dictionary<int, string> _selectedWorkCollections = new Dictionary<int, string>();
        QueryStringHandler _qHandler = null;
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

                _qHandler = new QueryStringHandler();
                if (_qHandler.Exists(SharedConst.QUERY_STRING_USER_NAME))
                {
                    currentUser = _qHandler.GetValue(SharedConst.QUERY_STRING_USER_NAME);
                    if (!String.IsNullOrWhiteSpace(currentUser))
                    {
                        //Uncomment the below line when the cryptographics module is ready

                        //currentUser = HttpUtility.UrlDecode(Request.QueryString[SharedConst.QUERY_STRING_USER_NAME]);
                        //currentUser = CryptoServiceHandler.Decrypt(currentUser, CryptoServiceHandler.ENCRYPTION_PASS_PHRASE);
                    }
                    else
                    {
                        this.frmPenalty.Visible = false;
                    }
                }

                if (!Page.IsPostBack)
                {
                    this.hdRs.Value = SharedConst.PENALTY_TYPE_NOT_RS;

                    _penalties.BindWorkCollection(this.cmbWorkCollection);
                    this.cmbWorkCollection.Items.Insert(0, new ListItem(SharedConst.DEFAULT_DROP_DOWN_SELECTION, "0", true));

                    _penalties.BindPenalties(this.cmbPenaltyType);
                    this.cmbPenaltyType.Items.Insert(0, new ListItem(SharedConst.DEFAULT_DROP_DOWN_SELECTION, "0", true));

                    _riType.GetAllRiTypes(this.cmbRiType);
                    this.cmbRiType.Items.Insert(0, new ListItem(SharedConst.DEFAULT_DROP_DOWN_SELECTION, "0", true));

                    _penalties.BindPenaltyFrequncies(this.cmbPenaltyFrequency);
                    this.cmbPenaltyFrequency.Items.Insert(0, new ListItem(SharedConst.DEFAULT_DROP_DOWN_SELECTION, "0", true));

                    _penalties.BindFrequncies(this.cmbFrequency);
                    this.cmbPenaltyFrequency.Items.Insert(0, new ListItem(SharedConst.DEFAULT_DROP_DOWN_SELECTION, "0", true));
                }
            }
            catch(Exception ex)
            {
                LogUtitlity.LogToText(ex.ToString());
            }
        }

        protected void cmbPenaltyType_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (this.cmbPenaltyType.SelectedValue == "RS"/* && !string.IsNullOrWhiteSpace(this.txtPenaltyCode.Value)*/)
            {
                this.hdRs.Value = SharedConst.PENALTY_TYPE_RS;
                if (this.hdRs.Value == SharedConst.PENALTY_TYPE_RS && this.txtPenaltyCode.Value != "")
                {
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "Pop", "openModalWC();", true);
                }
                else if (this.hdRs.Value == SharedConst.PENALTY_TYPE_RS && this.txtPenaltyCode.Value == "")
                {
                    this.divAlert.Visible = true;
                    lblFrmError.Text = "Penalty code is required";
                    this.cmbPenaltyType.SelectedIndex = 0;
                }
                else
                    return;
            }
            else
            {
                this.hdRs.Value = SharedConst.PENALTY_TYPE_NOT_RS;
            }
        }

        protected void cmbRiType_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        protected void ValidateForm()
        {
            this.divnpenalty.Visible = true;
            if (String.IsNullOrWhiteSpace(txtPenaltyCode.Value))
            {
                this.lblFrmError.Text = "Penalty code is required.";
                return;
            }
            else if (string.IsNullOrWhiteSpace(txtPenaltyDescription.Value))
            {
                this.lblFrmError.Text = "Penalty description is required.";
                return;
            }
            else if (this.cmbRiType.SelectedItem.ToString().Equals("--choose one--"))
            {
                this.lblFrmError.Text = "Return institution type is required.";
                return;
            }
            else if (this.cmbPenaltyType.SelectedItem.ToString().Equals("--choose one--"))
            {
                this.lblFrmError.Text = "Penalty type is required.";
                return;
            }
            else if (string.IsNullOrWhiteSpace(cmbPenaltyFrequency.SelectedValue))
            {
                this.lblFrmError.Text = "Penalty frequency is required.";
                return;
            }
            else if (string.IsNullOrWhiteSpace(txtPenaltyFreqUnit.Value))
            {
                this.lblFrmError.Text = "Penalty frequency unit is required.";
                return;
            }
            else if (string.IsNullOrWhiteSpace(txtPenaltyValue.Value))
            {
                this.lblFrmError.Text = "Penalty value is required.";
                return;
            }
            else if (DateTime.TryParse(txtStartValDate.Text, out DateTime date))
            {
                this.lblFrmError.Text = "Penalty frequency is required.";
                return;
            }
            else
            {
                //Submit the for to the database
                this.divnpenalty.Visible = false;
            }
        }

        protected void btnSavePenalty_Click(object sender, EventArgs e)
        {
            var rowsAffected = 0;
            try
            {
                //ValidateForm();
                _penaltiesModel = new PenaltiesModel();
                _penaltiesModel.penalty_code = txtPenaltyCode.Value.Trim();
                _penaltiesModel.penalty_desc = txtPenaltyDescription.Value.Trim();
                _penaltiesModel.ri_type_id = Convert.ToInt32(cmbRiType.SelectedValue.Trim());
                _penaltiesModel.penalty_type = cmbPenaltyType.SelectedValue.Trim();
                _penaltiesModel.penalty_freq = cmbPenaltyFrequency.SelectedValue.Trim();
                _penaltiesModel.penalty_freq_unit = Convert.ToInt32(txtPenaltyFreqUnit.Value);
                _penaltiesModel.delivery_deadline_day = 
                    (string.IsNullOrWhiteSpace(txtPenaltyDeadlineDay.Value)) ? (int?)null : Convert.ToInt32(txtPenaltyDeadlineDay.Value);
                _penaltiesModel.delivery_deadline_hr =
                    (string.IsNullOrWhiteSpace(txtPenaltyDeadlineHour.Value)) ? (int?)null : Convert.ToInt32(txtPenaltyDeadlineHour.Value);
                _penaltiesModel.delivery_deadline_min = 
                    (String.IsNullOrWhiteSpace(txtPenaltyDeadlineMinute.Value)) ? (int?)null : Convert.ToInt32(txtPenaltyDeadlineMinute.Value);
                _penaltiesModel.min_limit_accepted = txtMinimumLimitsAccepted.Value;
                _penaltiesModel.max_limit_accepted = txtMaximumLimitsAccepted.Value;
                _penaltiesModel.penalty_per_unit = (cmbPenaltyPerUnit.SelectedValue.Equals("0")) ? false : true;
                _penaltiesModel.failed_penalty_value = txtFailedPenaltyValue.Value;
                _penaltiesModel.penalty_value = Convert.ToDecimal(txtPenaltyValue.Value);
                _penaltiesModel.start_validity_date = Convert.ToDateTime(Convert.ToDateTime(txtStartValDate.Text).ToShortDateString());
                _penaltiesModel.frequncy = cmbFrequency.SelectedValue;

                if (txtEndValDate.Text == "" || txtEndValDate.Text == DateTime.MinValue.ToString())
                    _penaltiesModel.end_validity_date = _penaltiesModel.end_validity_date;
                else
                    _penaltiesModel.end_validity_date = (DateTime?)null;

                _penaltiesModel.created_date = DateTime.Now;
                _penaltiesModel.created_by = base.currentUser;

                if (this.hdRs.Value == SharedConst.PENALTY_TYPE_RS)
                {
                    foreach (ListItem li in cmbWorkCollection.Items)
                    {
                        if (li.Selected)
                        {
                            _selectedWorkCollections.Add(Convert.ToInt32(li.Value), li.Text);
                        }
                    }
                    _penaltyWcModel = new PenaltyWorkCollectionModel();
                    _penaltyWcModel.penalty_code = this.txtPenaltyCode.Value.Trim();
                    _penaltyWcModel.work_collection_id = _selectedWorkCollections;
                    _penaltyWcModel.created_date = DateTime.Now;
                    _penaltyWcModel.created_by = base.currentUser;

                    rowsAffected = _penalties.SavePenalty(_penaltiesModel, _penaltyWcModel);
                }
                else
                {
                    rowsAffected = _penalties.SavePenalty(_penaltiesModel);
                }

                if (rowsAffected > 0)
                {
                    divAlert.Visible = true;
                    divAlert.Attributes.Add("class", "alert alert-success alert-dismissible");
                    lblFrmError.Text = $"Penalty records '{this.txtPenaltyCode.Value}' saved successfuly, <a href='{Request.Url.ToString()}'>add</a> new penalty";
                    this.btnSave.Enabled = false;
                }
                else
                {
                    divAlert.Visible = true;
                    lblFrmError.Text = "Error while saving penalty details";
                }
            }
            catch (SqlException sqlEx)
            {
                Trace.Write(sqlEx.ToString());
                divAlert.Visible = true;
                lblFrmError.Text = sqlEx.ToString();

                if (sqlEx.Number == 2627)
                {
                    divAlert.Visible = true;
                    lblFrmError.Text = "Penalty code already exists";
                }
                else
                    divAlert.Visible = false;
            }
            catch (Exception ex)
            {
                LogUtitlity.LogToText(ex.ToString());
                divAlert.Visible = true;
                lblFrmError.Text = "Couldn't add penalty details" + ex.ToString();
            }
        }

        protected void btnAddWC_ServerClick(object sender, EventArgs e)
        {
            //_selectedWorkCollections = new Dictionary<int, string>();
            var selectedWcText = this.cmbWorkCollection.SelectedItem.Value;
            if (selectedWcText.Equals("0"))
            {
                divAlert.Visible = true;
                divAlert.Attributes.Add("class", "alert alert-warning alert-dismissible");
                lblFrmError.Text = "Please choose a valid work collection";
                this.cmbPenaltyType.SelectedIndex = 0;
            }
        }

        protected void cmbWorkCollection_SelectedIndexChanged(object sender, EventArgs e)
        {
            //ScriptManager.RegisterStartupScript(this, this.GetType(), "Pop", "openModalWC();", true);
            //Response.Write(this.cmbWorkCollection.SelectedValue);
            //lblPenaltyId.InnerText = this.cmbWorkCollection.SelectedValue;
        }

        public Dictionary<int, string> GetControlTextValue(ListBox controlid)
        {
            if (controlid == null)
            {
                throw new ArgumentNullException("control id can not be null");
            }

            foreach (ListItem li in controlid.Items)
            {
                if (li.Selected)
                {
                    _selectedWorkCollections.Add(Convert.ToInt32(li.Value), li.Text);
                }
            }

            return _selectedWorkCollections;
        }
    }
}