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
    public partial class bankratingscore : BasePage
    {
        TCoreRiType _riTypes = new TCoreRiType();
        ReturnInstitutions _ri = new ReturnInstitutions();
        TRPTComputationBankRatingSetupHandler _setuphandler = new TRPTComputationBankRatingSetupHandler();
        TRPTComputationBankRatingScoringHandler _scorehandler = new TRPTComputationBankRatingScoringHandler();
        TRPTComputationBankRatingScoringObject _scoreobject;
        GridViewRow _selectedrow;

        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (base.Error.Count > 0)
                {
                    this.frmBankRatingScore.Visible = false;
                    return;
                }

                if (!Page.IsPostBack)
                {
                    _scorehandler.BindBankRatingSetupRiTypes(this.cmbRiType);
                    this.cmbRiType.Items.Insert(0, "-choose one-");
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
            if (this.cmbRiType.SelectedItem.ToString() != null)
            {
                try
                {
                    var ritypeId = Convert.ToInt32(this.cmbRiType.SelectedValue);
                    if (!String.IsNullOrWhiteSpace(ritypeId.ToString()) || this.cmbRiType.SelectedValue == "00")
                    { 
                        _ri.BindAllReturnInstitutions(this.cmbReportingInstitution, ritypeId);
                    }
                    else
                    {
                        divAlert.Visible = true;
                        lblError.Text = "Please select an institution type";
                    }
                }
                catch (Exception ex)
                { 
                    LogUtitlity.LogToText(ex.ToString());
                }
            }
        }

        protected void btnGoBack_Click(object sender, EventArgs e)
        {
            try
            {
                string filePath = $"~/mgtcomponent/bankratingsetupview.aspx?uname={currentUser}";
                Response.Redirect(filePath);
            }
            catch (Exception ex)
            {
                LogUtitlity.LogToText(ex.ToString());
            }
        }

        protected void btnGetRatingDetails_ServerClick(object sender, EventArgs e)
        { 
            //Validate users input
            ValidateBusinessData();

            //Validate the date
            string selectedDateTsring = this.txtWorkcollectionDate.Text.Trim();
            bool isDateValid = ValidateDate(selectedDateTsring);
            divAlert.Visible = true;
            if (isDateValid == true)
                divAlert.Visible = false;
            else
            {
                lblError.Text = "The selcted date is not in the right format";
                return;
            }

            //Get the bank rating setup details and isplay in gridview
            int ritypeid = Convert.ToInt32(this.cmbRiType.SelectedValue);
            int riid = Convert.ToInt32(this.cmbReportingInstitution.SelectedValue);
            int count = _setuphandler.GetBankRatingSetupDetails(ritypeid, riid).Rows.Count;
            if(count > 0)
                this.gridviewRatingSetup.DataSource = _setuphandler.GetBankRatingSetupDetails(ritypeid, riid);
            else
            {
                divAlert.Visible = true;
                lblError.Text = "No bank rating setup details available for the selected institution type";
            }
            this.gridviewRatingSetup.DataBind();
            this.divGridResult.Visible = true;
        }

        protected void gridviewRatingSetup_SelectedIndexChanged(object sender, EventArgs e)
        {
            _selectedrow = this.gridviewRatingSetup.SelectedRow;
            ClientScript.RegisterStartupScript(this.GetType(), "Pop", "$('#exampleModalCenter3').modal('show')", true);
        }

        protected void btnSaveChanges_ServerClick(object sender, EventArgs e)
        {
            int rowsAffected = 0;
            try
            {
                //Validate business data
                ValidateBusinessData();

                //contiue to save all changes
                for(int x = 0; x < this.gridviewRatingSetup.Rows.Count; x++)
                {
                    var selectedRow = this.gridviewRatingSetup.SelectedRow;
                    _scoreobject = new TRPTComputationBankRatingScoringObject();
                    _scoreobject.bank_rating_code = this.gridviewRatingSetup.Rows[x].Cells[1].Text; 
                    _scoreobject.ri_type_id = Convert.ToInt32(this.cmbRiType.SelectedValue);
                    _scoreobject.ri_id = Convert.ToInt32(this.cmbReportingInstitution.SelectedValue);
                    _scoreobject.rating_date = Convert.ToDateTime(this.txtWorkcollectionDate.Text.Trim());
                    _scoreobject.rating_score = this.gridviewRatingSetup.Rows[x].Cells[5].Text;
                    _scoreobject.last_modified = DateTime.Now;
                    _scoreobject.modified_by = currentUser;

                    //Check bank rating code exists
                    bool codeExists = _scorehandler.CheckDataExists(this.gridviewRatingSetup.Rows[x].Cells[1].Text);
                    divAlert.Visible = true;
                    divAlert.Attributes.Add("class", "alert alert-success alert-dismissible");
                    if (codeExists == true)
                    {
                        rowsAffected = _scorehandler.UpdateComputationBankRatingScore(_scoreobject);
                        lblError.Text = "Management component on bank rating score updated successfully";
                    }
                    else
                    {
                        rowsAffected = _scorehandler.SaveComputationBankRatingScore(_scoreobject);
                        lblError.Text = "Management component on bank rating score saved successfully";
                    }
                }
                
                //if (rowsAffected > 0)
                //{
                    
                //}
                //else
                //    lblError.Text = "An error occured while saving changes";
            }
            catch (Exception ex)
            {
                if(ex.ToString().Contains("PRIMARY KEY"))
                {
                    divAlert.Visible = true;
                    divAlert.Attributes.Add("class", "alert alert-warning alert-dismissible");
                    lblError.Text = "Bank rating code already exists";
                }
                LogUtitlity.LogToText(ex.ToString());
            }
        }

        protected void btnUpdateScore_ServerClick(object sender, EventArgs e)
        {
            try
            {
                var columnIndex = GetColumnIndexByName(this.gridviewRatingSetup.SelectedRow, "rating_score");
                string ratingScoreValue = this.txtRatingScore.Value.Trim();
                string componentWeight = GetGridCellValue(this.gridviewRatingSetup.SelectedRow, GetColumnIndexByName(this.gridviewRatingSetup.SelectedRow, "component_weight"));

                if (string.IsNullOrWhiteSpace(ratingScoreValue))
                    ratingScoreValue = "0.00";

                //Check that rating score is not higher than component_weight
                divAlert.Visible = true;
                if (double.Parse(ratingScoreValue) > double.Parse(componentWeight))
                {
                    lblError.Text = "Rating score value can't be greater than component weight";
                    return;
                }
                else
                {
                    divAlert.Visible = false;
                    SetGridCellValue(this.gridviewRatingSetup.SelectedRow, columnIndex, ratingScoreValue);
                    this.gridviewRatingSetup.SelectedRow.Cells[columnIndex].ForeColor = System.Drawing.Color.Maroon;
                }
            }
            catch(Exception ex)
            {
                LogUtitlity.LogToText(ex.ToString());
            }
        }

        int GetColumnIndexByName(GridViewRow row, string columnName)
        {
            int columnIndex = 0;
            foreach (DataControlFieldCell cell in row.Cells)
            {
                if (cell.ContainingField is BoundField)
                    if (((BoundField)cell.ContainingField).DataField.Equals(columnName))
                        break;
                columnIndex++;
            }
            return columnIndex;
        }

        protected string GetGridCellValue(GridViewRow gridviewrow, int cellindex)
        {
            return gridviewrow.Cells[cellindex].Text;
        }

        protected void SetGridCellValue(GridViewRow gridviewrow, int cellindex, string value)
        {
            gridviewrow.Cells[cellindex].Text = value;
        }
        private void ValidateBusinessData()
        {
            divAlert.Visible = true;
            if (this.cmbRiType.SelectedItem.Text.Equals("-choose one-"))
            {
                lblError.Text = "Please select a valid RI Type";
                return;
            }
            else if (this.cmbReportingInstitution.SelectedItem.Text.Equals("-Select Institution-"))
            {
                lblError.Text = "Please select a valid reporting institution";
                return;
            }
            else
                divAlert.Visible = false;

            string selectedDateTsring = this.txtWorkcollectionDate.Text.Trim();
            bool isDateValid = ValidateDate(selectedDateTsring);
            divAlert.Visible = true;
            if (isDateValid == true)
            { divAlert.Visible = false; }
            else
            {
                lblError.Text = "The selcted date is not in the right format";
                divAlert.Visible = true;
            }
        }

        private void ValidateBusinessDatas()
        {
            divAlert.Visible = true;
            if (this.cmbRiType.SelectedItem.Text.Equals("-choose one-"))
            {
                lblError.Text = "Please select a valid RI Type";
                return;
            }
            else
                divAlert.Visible = false;

            if (this.cmbReportingInstitution.SelectedItem.Text.Equals("-Select Institution-"))
            {
                lblError.Text = "Please select a valid reporting institution";
                return;
            }
            else
                divAlert.Visible = false;
                       
            string selectedDateTsring = this.txtWorkcollectionDate.Text.Trim();
            bool isDateValid = ValidateDate(selectedDateTsring);
            divAlert.Visible = true;
            if (isDateValid == true)
                divAlert.Visible = false;
            else
                lblError.Text = "The selcted date is not in the right format";
        }
    }
}