using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Adhocs.Logic.DatabaseHandler;
using Adhocs.Logic.Infrastructure;
using Adhocs.Logic.ServiceHandler;
using Adhocs.Logic.Objects;
using System.Data;
using System.Text;

namespace Adhocs.rules
{
    public partial class radjustments : BasePage
    {
        #region Global declaration
        int _scheduleid = 0;
        private string _compruletype;
        private string _ruleTypeText;
        private string _ruleId;
        private string _rulename;
        private string _versionid;
        private string _runid;

        Dictionary<string, string> _keyValuesHeader = new Dictionary<string, string>();
        List<string> columnNameBuilder = new List<string>();
        Dictionary<string, string> _keyValues = new Dictionary<string, string>();
        #endregion

        #region Global properties
        RuleVarianceAdjustment _ruleVarianceAdjustment;
        TRTNWorkCollectionScheduleHandler _tRTNWorkCollectionSchedule; //= new TRTNWorkCollectionScheduleHandler();
        TRPTComputationRuleBaseHandler _tRPTComputationRuleBaseHandler;
        VRTNWorkCollectionObject _vrtnWorkCollectionObject;
        TRPTComputationValueTableObject _trptcomputationvaluetableobjects = new TRPTComputationValueTableObject();
        TRTNWorkCollectionScheduleObject _trntnWorkCollectionScheduleObject = new TRTNWorkCollectionScheduleObject();
        #endregion

        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (base.Error.Count > 0)
                {
                    this.frmRulesAdjustment.Visible = false;
                    return;
                }

                if (!Page.IsPostBack)
                {
                    _ruleVarianceAdjustment = new RuleVarianceAdjustment();
                    _ruleVarianceAdjustment.GetRIType(this.cmbRiType);
                    this.cmbRiType.Items.Insert(0, new ListItem("--choose one--", "0", true));

                    SaveToSession(SharedConst.SESSION_IS_MODIFIED, "false");
                }
            }
            catch(Exception ex)
            {
                LogUtitlity.LogToText(ex.ToString());
            }
        }

        #region Session Management
        private void SaveToSession(string key, string value)
        {
            //RNGCryptoServiceProvider rngCrypt = new RNGCryptoServiceProvider();
            Session[key] = value;
        }

        public String GetFromSession(string key)
        {
            try
            {
                return Session[key].ToString();
            }
            catch (Exception ex)
            {
                LogUtitlity.LogToText(ex.ToString());
                return null;
            }
        }
        #endregion

        protected void cmbRiType_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (this.cmbRiType.SelectedItem.ToString() != null && this.cmbRiType.SelectedValue != "0")
            {
                try
                {
                    var instTypeId = this.cmbRiType.SelectedValue;
                    _ruleVarianceAdjustment = new RuleVarianceAdjustment();
                    _ruleVarianceAdjustment.GetRI(this.cmbReportingInstitution, Convert.ToInt32(instTypeId));
                    this.cmbReportingInstitution.Items.Insert(0, new ListItem("--choose one--", "0", true));
                }
                catch (Exception ex)
                {
                    LogUtitlity.LogToText(ex.ToString());
                }
            }
            else
                this.cmbReportingInstitution.Items.Clear();
        }

        protected void cmbReportingInstitution_SelectedIndexChanged(object sender, EventArgs e)
        {
            _ruleVarianceAdjustment = new RuleVarianceAdjustment();
            this.cmbFrequency.Items.Clear();
            if (this.cmbReportingInstitution.SelectedItem != null && !this.cmbReportingInstitution.SelectedValue.Equals("0"))
            {
                string ritypecode = this.cmbRiType.SelectedItem.ToString().Split('-')[0];
                _ruleVarianceAdjustment.GetFrequency(this.cmbFrequency, ritypecode);
                this.cmbFrequency.Items.Insert(0, new ListItem("--choose one--", "0", true));
            }
        }

        protected void cmbColmnList_SelectedIndexChanged(object sender, EventArgs e)
        {
            //ScriptManager.RegisterStartupScript(this, this.GetType(), "Pop", "openModalValue();", true);
            ClientScript.RegisterStartupScript(this.GetType(), "Pop", "$('#exampleModalCenterValue').modal('show')", true);
        }

        protected void gridViewListReport_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            //HideColum(this.gridViewListReport, "rule_code_id");
            
            if (e.Row.Cells.Count > 1)
            {
                //e.Row.Cells[1].Visible = false;
                //e.Row.Cells[2].Visible = false;
                //e.Row.Cells[5].Visible = false;
                //e.Row.Cells[11].Visible = false;
                //e.Row.Cells[12].Visible = false;
                //e.Row.Cells[13].Visible = false;
            }
            else { return; }
        }

        /// <summary>
        /// View the computation rules available in the database
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void lblViewCompRule_ServerClick(object sender, EventArgs e)
        {
            var ritypeid = this.cmbRiType.SelectedValue;
            var wcDate = this.txtWorkcollectionDate.Text.Trim();

            //RI type validation
            divAlert.Visible = true;
            DateTime datetocheck;
            if (this.cmbRiType.SelectedIndex < 1)
            {
                lblError.Text = "Please choose an RI Type";
                return;
            }
            if (this.cmbReportingInstitution.SelectedIndex < 1)
            {
                lblError.Text = "Please a valid reporting institution";
                return;
            }
            if (this.cmbFrequency.SelectedIndex < 1)
            {
                lblError.Text = "Please a frequency value";
                return;
            }
            if (DateTime.TryParse(this.txtWorkcollectionDate.Text, out datetocheck) == false)
            {
                lblError.Text = "Selected date format is not valid";
                return;
            }
            else
            {
                divAlert.Visible = false;
            }

            try
            {
                divGrids.Attributes.CssStyle.Add("display", "grid");
                _tRPTComputationRuleBaseHandler = new TRPTComputationRuleBaseHandler();
                this.gridViewRules.DataSource = _tRPTComputationRuleBaseHandler.GetComputationRuleBase(new TCoreRiTypeObject
                {
                    ri_type_id = Convert.ToInt32(this.cmbRiType.SelectedValue)
                });
                this.gridViewRules.DataBind();

                //Get the schedule ID
                _tRTNWorkCollectionSchedule = new TRTNWorkCollectionScheduleHandler();
                Dictionary<string, string> returnedValues = _tRTNWorkCollectionSchedule.GetWorkCollectionSchedule(
                        new VRTNWorkCollectionObject { ri_type_id = Convert.ToInt32(this.cmbRiType.SelectedValue), frequency = this.cmbFrequency.SelectedValue },
                        new TRTNWorkCollectionScheduleObject
                        { is_valid = true, ri_id = Convert.ToInt32(this.cmbReportingInstitution.SelectedValue), work_collection_date = Convert.ToDateTime(this.txtWorkcollectionDate.Text) });

                if (returnedValues != null)
                    this.hndSchedule.Value = returnedValues["schedule_id"];
                else
                    return;
            }
            catch (FormatException fex)
            {
                Trace.Write(fex.ToString());
                divAlert.Visible = true;
                divAlert.Attributes.Add("class", "alert alert-danger alert-dismissible");
                lblError.Text = "Specified work collection date not in the right format";
                this.gridViewRules.DataSource = null;
                this.gridViewRules.DataBind();
            }
            catch (Exception ex)
            {
                LogUtitlity.LogToText(ex.ToString());
                divAlert.Visible = true;
                divAlert.Attributes.Add("class", "alert alert-danger alert-dismissible");
                lblError.Text = SharedConst.ERROR_SHARED_ERROR_MESSAGE;
            }
        }

        private void ValidateBusinessData()
        {
            //RI type validation
            divAlert.Visible = true;
            DateTime datetocheck;
            if (this.cmbRiType.SelectedIndex.ToString().Equals("--choose one--"))
            {
                lblError.Text = "Please choose an RI Type";
                return;
            }
            else if (this.cmbReportingInstitution.SelectedIndex.ToString().Equals("--choose one--"))
            {
                lblError.Text = "Please a valid reporting institution";
                return;
            }
            else if (this.cmbFrequency.SelectedIndex.ToString().Equals("--choose one--"))
            {
                lblError.Text = "Please a frequency value";
                return;
            }
            else if (DateTime.TryParse(this.txtWorkcollectionDate.Text, out datetocheck) == false)
            {
                lblError.Text = "Selected date format is not valid";
                return;
            }
            else
            {
                divAlert.Visible = false;
                return;
            }
        }

        protected void gridViewRules_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                var selectedItem = this.gridViewRules.SelectedRow;
                if (selectedItem.Cells.Count > 0)
                {
                    _ruleTypeText = selectedItem.Cells[SharedConst.COMP_RULE_TYPE_COLUMN_INDEX].Text;
                    //Store the rule name and rule ID using the selected row column index
                    _ruleId = selectedItem.Cells[1].Text;
                    _rulename = selectedItem.Cells[2].Text;
                    void BindComputationRuleSpool()
                    {
                        _ruleVarianceAdjustment = new RuleVarianceAdjustment();
                        this.gridViewCompValue.DataSource = _ruleVarianceAdjustment.CompRuleSpool(Convert.ToInt32(this.hndSchedule.Value), Convert.ToInt32(_ruleId));
                        this.gridViewCompValue.DataBind();
                    };

                    BindComputationRuleSpool();

                    #region comment
                    ////Get the version ID
                    //string GetVersionId()
                    //{
                    //    var versionId = new TRPTComputationValueTableHandler().GetVersionId(Convert.ToInt32(cmbRiType.SelectedValue), Convert.ToInt32(cmbReportingInstitution.SelectedValue), cmbFrequency.SelectedValue, Convert.ToDateTime(txtWorkcollectionDate.Text), _rulename, Convert.ToInt32(this.hndText.Value));
                    //    if (!string.IsNullOrWhiteSpace(versionId))
                    //        return versionId;
                    //    else
                    //        return string.Empty;
                    //};
                    //_versionid = GetVersionId();

                    ////Get the version ID
                    //string GetRunId()
                    //{
                    //    return new TRPTComputationValueTableHandler().GetRunId(Convert.ToInt32(cmbRiType.SelectedValue), Convert.ToInt32(cmbReportingInstitution.SelectedValue), cmbFrequency.SelectedValue, Convert.ToDateTime(txtWorkcollectionDate.Text), _rulename, Convert.ToInt32(this.hndText.Value));
                    //};
                    //_runid = GetRunId();
                    #endregion

                    this.hndType.Value = this.gridViewRules.SelectedRow.Cells[SharedConst.COMP_RULE_TYPE_COLUMN_INDEX].Text;
                }
                else
                    return;
            }
            catch (Exception ex)
            {
                LogUtitlity.LogToText(ex.ToString());
                divAlert.Visible = true;
                divAlert.Attributes.Add("class", "alert alert-danger alert-dismissible");
                lblError.Text = SharedConst.ERROR_SHARED_ERROR_MESSAGE;
            }
        }

        protected void btnUpdateValueProceed_ServerClick(object sender, EventArgs e)
        {
            try
            {
                var selectedRow = this.gridViewRules.SelectedRow;
                if (selectedRow.Cells[SharedConst.COMP_RULE_TYPE_COLUMN_INDEX].Text == SharedConst.COMP_RULE_TYPE_TEXT_SIMPLE)
                {
                    SetGridCellValue(this.gridViewCompValue.SelectedRow, 2, this.txtNewValueSimple.Value);
                    SetGridCellValue(this.gridViewCompValue.SelectedRow, 3, this.txtAreaAnalystComment.Value);
                    this.gridViewCompValue.SelectedRow.Cells[2].ForeColor = System.Drawing.Color.Maroon;
                    this.gridViewCompValue.SelectedRow.Cells[3].ForeColor = System.Drawing.Color.Maroon;
                }
                else if (selectedRow.Cells[SharedConst.COMP_RULE_TYPE_COLUMN_INDEX].Text == SharedConst.COMP_RULE_TYPE_TEXT_COMPOUND)
                {
                    
                }
                else
                    return;

                //set a flag to show a value has been changed
                SaveToSession(SharedConst.SESSION_IS_MODIFIED, "true");
            }
            catch (Exception ex)
            {
                LogUtitlity.LogToText(ex.ToString());
                divAlert.Visible = true;
                divAlert.Attributes.Add("class", "alert alert-danger alert-dismissible");
                lblError.Text = SharedConst.ERROR_SHARED_ERROR_MESSAGE;
            }
        }

        private Dictionary<string, string> SimpleCompValueTemp(GridView source)
        {
            Dictionary<string, string> keyValues = new Dictionary<string, string>();
            for(int i = 0; i <= source.Rows.Count; i++)
            {
                keyValues.Add(source.Rows[i].Cells[1].Text, source.Rows[i].Cells[2].Text);
            }

            return keyValues;
        }

        protected void gridViewCompValue_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                var selectedRow = this.gridViewCompValue.SelectedRow;
                if (selectedRow.Cells.Count > 0)
                {
                    //Display a modal box showing which value to change
                    ClientScript.RegisterStartupScript(this.GetType(), "Pop", "$('#exampleModalCenterValue').modal('show')", true);

                    void SetSimpleRuleAdjustmentTextInPopup()
                    {
                        lblRuleTypeSimple.InnerText = $"Rule Type: {this.gridViewRules.SelectedRow.Cells[SharedConst.COMP_RULE_TYPE_COLUMN_INDEX].Text}";
                        lblOldRowIdSimple.InnerText = $"Row Id: {GetGridCellValue(selectedRow, 1)}";
                        lblOldValueSimple.InnerText = $"Value: {GetGridCellValue(selectedRow, 2)}";
                        lblOldCommentSimple.InnerText = $"Comment: {GetGridCellValue(selectedRow, 3)}";
                    }

                    void SetCompoundRuleAdjustmentTextInPopup()
                    {
                        var gridViewHeaderText = this.gridViewCompValue.HeaderRow.Cells[3].Text;
                        lblRuleTypeCompound.InnerText = $"Rule Type: {this.gridViewRules.SelectedRow.Cells[SharedConst.COMP_RULE_TYPE_COLUMN_INDEX].Text}";
                        lblOldRowIdComplex.InnerText = $"Row Id: {GetGridCellValue(selectedRow, 1)}";
                        lblRowCodeComplex.InnerText = $"Row Code: {GetGridCellValue(selectedRow, 2)}";
                        lblSummaryComplex.InnerText = $"{HttpUtility.HtmlDecode(gridViewHeaderText)}: {GetGridCellValue(selectedRow, 3)}";
                        lblSummaryComplex.Attributes.CssStyle.Add("color", "Maroon");
                    }

                    if (this.gridViewRules.SelectedRow.Cells[SharedConst.COMP_RULE_TYPE_COLUMN_INDEX].Text == SharedConst.COMP_RULE_TYPE_TEXT_SIMPLE)
                    {
                        //Set the popup text
                        SetSimpleRuleAdjustmentTextInPopup();
                        divCompoundRuleAdjustment.Visible = false;
                        divSimpleRuleAdjustment.Visible = true;

                        //Dissable the update button
                        this.btnUpdate.Disabled = true;
                    }
                    else if (this.gridViewRules.SelectedRow.Cells[SharedConst.COMP_RULE_TYPE_COLUMN_INDEX].Text == SharedConst.COMP_RULE_TYPE_TEXT_COMPOUND)
                    {
                        //Set the popup text
                        SetCompoundRuleAdjustmentTextInPopup();
                        divSimpleRuleAdjustment.Visible = false;
                        divCompoundRuleAdjustment.Visible = true;

                        //Bind gridview columns to dropdown control
                        this.cmbColumnListComplex.Items.Clear();
                        _ruleVarianceAdjustment = new RuleVarianceAdjustment();
                        _ruleVarianceAdjustment.BindSpoolColumns(this.cmbColumnListComplex);

                        //Count number of column in the binded drop down control above
                        var columnHeaderCount = this.cmbColumnListComplex.Items.Count;                        
                    }
                    else
                        return;
                }
                else
                    return;
            }
            catch (Exception ex)
            {
                LogUtitlity.LogToText(ex.ToString());
                divAlert.Visible = true;
                divAlert.Attributes.Add("class", "alert alert-danger alert-dismissible");
                lblError.Text = SharedConst.ERROR_SHARED_ERROR_MESSAGE;
            }
        }

        protected void cmbColumnListComplex_SelectedIndexChanged(object sender, EventArgs e)
        {
            string columnNameValue = this.cmbColumnListComplex.SelectedValue;
            string colummnName = this.cmbColumnListComplex.SelectedItem.ToString();

            var selectedRow = this.gridViewCompValue.SelectedRow;
            string rowid = selectedRow.Cells[1].Text.Trim();

            lblSummaryComplex.InnerText = $"{HttpUtility.HtmlDecode(colummnName)}: {GetGridCellValue(selectedRow, GetColumnIndexByName(gridViewCompValue.SelectedRow, colummnName))}";

            if (columnNameValue.Equals("1") || columnNameValue.Equals("2"))
            {
                this.txtNewValueComplex.Attributes.CssStyle.Add("display", "none");
                this.lblNewValueComplex.Attributes.CssStyle.Add("display", "none");

                this.txtAreaAnalystComment.Attributes.CssStyle.Add("display", "none");
                this.lblAreaAnalystComment.Attributes.CssStyle.Add("display", "none");
            }
            else if(colummnName.Equals("comment"))
            {
                this.txtNewValueComplex.Attributes.CssStyle.Add("display", "none");
                this.lblNewValueComplex.Attributes.CssStyle.Add("display", "none");

                this.txtAreaAnalystComment.Attributes.CssStyle.Add("display", "flex");
                this.lblAreaAnalystComment.Attributes.CssStyle.Add("display", "flex");
            }
            else
            {
                this.txtNewValueComplex.Attributes.CssStyle.Add("display", "flex");
                this.txtAreaAnalystComment.Attributes.CssStyle.Add("display", "flex");

                this.txtAreaAnalystComment.Attributes.CssStyle.Add("display", "none");
                this.lblAreaAnalystComment.Attributes.CssStyle.Add("display", "none");
            }

            ClientScript.RegisterStartupScript(this.GetType(), "Pop", "$('#exampleModalCenterValue').modal('show')", true);
        }

        protected void btnUpdate_ServerClick(object sender, EventArgs e)
        {
            try
            {
                string columnListValue = this.cmbColumnListComplex.SelectedValue;
                string columnName = this.cmbColumnListComplex.SelectedItem.ToString();
                int index = GetColumnIndexByName(this.gridViewCompValue.SelectedRow, columnName);

                if (columnName.Equals("comment"))
                {
                    SetGridCellValue(this.gridViewCompValue.SelectedRow, index, this.txtAreaAnalystComment.Value.Trim());
                    this.gridViewCompValue.SelectedRow.Cells[index].ForeColor = System.Drawing.Color.Maroon;
                }
                else
                {
                    SetGridCellValue(this.gridViewCompValue.SelectedRow, index, this.txtNewValueComplex.Value.Trim());
                    this.gridViewCompValue.SelectedRow.Cells[index].ForeColor = System.Drawing.Color.Maroon;
                }

                //Rebuild the column list control to include all column names minus previously selected column name
                if (string.IsNullOrWhiteSpace(this.hfColumnList.Value))
                    this.hfColumnList.Value = $"{columnListValue}";
                else
                    this.hfColumnList.Value += $",{columnListValue}";

                this.cmbColumnListComplex.Items.Clear();
                _ruleVarianceAdjustment = new RuleVarianceAdjustment();
                _ruleVarianceAdjustment.BindSpoolColumns(this.cmbColumnListComplex, this.hfColumnList.Value);

                ClientScript.RegisterStartupScript(this.GetType(), "Pop", "$('#exampleModalCenterValue').modal('show')", true);
            }
            catch(Exception ex)
            {
                LogUtitlity.LogToText(ex.ToString());
            }
        }

        protected string GetGridCellValue(GridViewRow gridviewrow, int cellindex)
        {
            return gridviewrow.Cells[cellindex].Text;
        }

        protected void SetGridCellValue(GridViewRow gridviewrow, int cellindex, string value)
        {
            gridviewrow.Cells[cellindex].Text = value;
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

        protected void btnSaveAdjustment_ServerClick(object sender, EventArgs e)
        {
            try
            {
                //Get the currently selected row
                var srow = this.gridViewCompValue.SelectedRow;

                //Get the rule name from gridview selected row
                var ruleName = this.gridViewRules.SelectedRow.Cells[2].Text;
                
                //Get the rule type from gridview selected row
                var ruleType = this.gridViewRules.SelectedRow.Cells[SharedConst.COMP_RULE_TYPE_COLUMN_INDEX].Text;
               
                //Get version and run id for submission
                Dictionary<string, string> values = new TRPTComputationValueTableHandler().GetVersionIdNRunId(ruleName, Convert.ToInt32(cmbRiType.SelectedValue), Convert.ToInt32(cmbReportingInstitution.SelectedValue), cmbFrequency.SelectedValue, Convert.ToInt32(this.hndSchedule.Value), Convert.ToDateTime(txtWorkcollectionDate.Text));
                
                //Check if version and run id is null or 0
                if (values == null && values.Keys.Count < 1)
                {
                    return;
                }

                int rowsAffected = 0;
                if (GetFromSession(SharedConst.SESSION_IS_MODIFIED).Equals("true"))
                {
                    _trptcomputationvaluetableobjects.computation_rule = this.gridViewRules.SelectedRow.Cells[2].Text;
                    _trptcomputationvaluetableobjects.version_id = Convert.ToInt32(values["version_id"]);
                    _trptcomputationvaluetableobjects.ri_type_id = Convert.ToInt32(this.cmbRiType.SelectedValue);
                    _trptcomputationvaluetableobjects.ri_id = Convert.ToInt32(this.cmbReportingInstitution.SelectedValue);
                    _trptcomputationvaluetableobjects.work_collection_date = Convert.ToDateTime(this.txtWorkcollectionDate.Text);
                    _trptcomputationvaluetableobjects.freq_unit = this.cmbFrequency.SelectedValue;
                    _trptcomputationvaluetableobjects.schedule_id = this.hndSchedule.Value;
                    _trptcomputationvaluetableobjects.run_id = Convert.ToInt32(values["run_id"]);
                    _trptcomputationvaluetableobjects.comment = this.txtAreaAnalystComment.Value.Trim();
                    _trptcomputationvaluetableobjects.last_modified = DateTime.Now;
                    _trptcomputationvaluetableobjects.modified_by = base.currentUser;

                    if (ruleType == SharedConst.COMP_RULE_TYPE_TEXT_SIMPLE)
                    {
                        for (int i = 1; i <= this.gridViewCompValue.Rows.Count; i++)
                        {
                            _trptcomputationvaluetableobjects.row_code = this.gridViewCompValue.Rows[i-1].Cells[1].Text;
                            _trptcomputationvaluetableobjects.column_1 = this.gridViewCompValue.Rows[i-1].Cells[2].Text;

                            rowsAffected = new TRPTComputationValueTableHandler().SaveSimpleRule(_trptcomputationvaluetableobjects);
                        }
                    }
                    else if (ruleType == SharedConst.COMP_RULE_TYPE_TEXT_COMPOUND)
                    {
                        int columnCount = this.gridViewCompValue.SelectedRow.Cells.Count;
                        _trptcomputationvaluetableobjects.row_code = GetGridCellValue(srow, 2);
                        switch (columnCount)
                        {
                            case 4:
                                _trptcomputationvaluetableobjects.column_1 = GetGridCellValue(srow, 4);
                                break;
                            case 5:
                                _trptcomputationvaluetableobjects.column_1 = GetGridCellValue(srow, 4);
                                _trptcomputationvaluetableobjects.column_2 = GetGridCellValue(srow, 5);
                                break;
                            case 6:
                                _trptcomputationvaluetableobjects.column_1 = GetGridCellValue(srow, 4);
                                //_trptcomputationvaluetableobjects.column_2 = GetGridCellValue(srow, 4);
                                //_trptcomputationvaluetableobjects.column_3 = GetGridCellValue(srow, 6);
                                break;
                            case 7:
                                _trptcomputationvaluetableobjects.column_1 = GetGridCellValue(srow, 4);
                                _trptcomputationvaluetableobjects.column_2 = GetGridCellValue(srow, 5);
                                //_trptcomputationvaluetableobjects.column_3 = GetGridCellValue(srow, 6);
                                //_trptcomputationvaluetableobjects.column_4 = GetGridCellValue(srow, 7);
                                break;
                            case 8:
                                _trptcomputationvaluetableobjects.column_1 = GetGridCellValue(srow, 4);
                                _trptcomputationvaluetableobjects.column_2 = GetGridCellValue(srow, 5);
                                _trptcomputationvaluetableobjects.column_3 = GetGridCellValue(srow, 6);
                                //_trptcomputationvaluetableobjects.column_4 = GetGridCellValue(srow, 7);
                                //_trptcomputationvaluetableobjects.column_5 = GetGridCellValue(srow, 7);
                                break;
                            case 9:
                                _trptcomputationvaluetableobjects.column_1 = GetGridCellValue(srow, 4);
                                _trptcomputationvaluetableobjects.column_2 = GetGridCellValue(srow, 5);
                                _trptcomputationvaluetableobjects.column_3 = GetGridCellValue(srow, 6);
                                _trptcomputationvaluetableobjects.column_4 = GetGridCellValue(srow, 7);
                                //_trptcomputationvaluetableobjects.column_5 = GetGridCellValue(srow, 8);
                                //_trptcomputationvaluetableobjects.column_6 = GetGridCellValue(srow, 9);
                                break;
                            case 10:
                                _trptcomputationvaluetableobjects.column_1 = GetGridCellValue(srow, 4);
                                _trptcomputationvaluetableobjects.column_2 = GetGridCellValue(srow, 5);
                                _trptcomputationvaluetableobjects.column_3 = GetGridCellValue(srow, 6);
                                _trptcomputationvaluetableobjects.column_4 = GetGridCellValue(srow, 7);
                                _trptcomputationvaluetableobjects.column_5 = GetGridCellValue(srow, 8);
                                //_trptcomputationvaluetableobjects.column_6 = GetGridCellValue(srow, 9);
                                //_trptcomputationvaluetableobjects.column_7 = GetGridCellValue(srow, 10);
                                break;
                            case 11:
                                _trptcomputationvaluetableobjects.column_1 = GetGridCellValue(srow, 4);
                                _trptcomputationvaluetableobjects.column_2 = GetGridCellValue(srow, 5);
                                _trptcomputationvaluetableobjects.column_3 = GetGridCellValue(srow, 6);
                                _trptcomputationvaluetableobjects.column_4 = GetGridCellValue(srow, 7);
                                _trptcomputationvaluetableobjects.column_5 = GetGridCellValue(srow, 8);
                                _trptcomputationvaluetableobjects.column_6 = GetGridCellValue(srow, 9);
                                //_trptcomputationvaluetableobjects.column_7 = GetGridCellValue(srow, 10);
                                //_trptcomputationvaluetableobjects.column_8 = GetGridCellValue(srow, 11);
                                break;
                            case 12:
                                _trptcomputationvaluetableobjects.column_1 = GetGridCellValue(srow, 4);
                                _trptcomputationvaluetableobjects.column_2 = GetGridCellValue(srow, 5);
                                _trptcomputationvaluetableobjects.column_3 = GetGridCellValue(srow, 6);
                                _trptcomputationvaluetableobjects.column_4 = GetGridCellValue(srow, 7);
                                _trptcomputationvaluetableobjects.column_5 = GetGridCellValue(srow, 8);
                                _trptcomputationvaluetableobjects.column_6 = GetGridCellValue(srow, 9);
                                _trptcomputationvaluetableobjects.column_7 = GetGridCellValue(srow, 10);
                                //_trptcomputationvaluetableobjects.column_8 = GetGridCellValue(srow, 11);
                                //_trptcomputationvaluetableobjects.column_9 = GetGridCellValue(srow, 12);
                                break;
                            case 13:
                                _trptcomputationvaluetableobjects.column_1 = GetGridCellValue(srow, 4);
                                _trptcomputationvaluetableobjects.column_2 = GetGridCellValue(srow, 5);
                                _trptcomputationvaluetableobjects.column_3 = GetGridCellValue(srow, 6);
                                _trptcomputationvaluetableobjects.column_4 = GetGridCellValue(srow, 7);
                                _trptcomputationvaluetableobjects.column_5 = GetGridCellValue(srow, 8);
                                _trptcomputationvaluetableobjects.column_6 = GetGridCellValue(srow, 9);
                                _trptcomputationvaluetableobjects.column_7 = GetGridCellValue(srow, 10);
                                _trptcomputationvaluetableobjects.column_8 = GetGridCellValue(srow, 11);
                                //_trptcomputationvaluetableobjects.column_9 = GetGridCellValue(srow, 12);
                                //_trptcomputationvaluetableobjects.column_10 = GetGridCellValue(srow, 13);
                                break;
                            case 14:
                                _trptcomputationvaluetableobjects.column_1 = GetGridCellValue(srow, 4);
                                _trptcomputationvaluetableobjects.column_2 = GetGridCellValue(srow, 5);
                                _trptcomputationvaluetableobjects.column_3 = GetGridCellValue(srow, 6);
                                _trptcomputationvaluetableobjects.column_4 = GetGridCellValue(srow, 7);
                                _trptcomputationvaluetableobjects.column_5 = GetGridCellValue(srow, 8);
                                _trptcomputationvaluetableobjects.column_6 = GetGridCellValue(srow, 9);
                                _trptcomputationvaluetableobjects.column_7 = GetGridCellValue(srow, 10);
                                _trptcomputationvaluetableobjects.column_8 = GetGridCellValue(srow, 11);
                                _trptcomputationvaluetableobjects.column_9 = GetGridCellValue(srow, 12);
                                //_trptcomputationvaluetableobjects.column_10 = GetGridCellValue(srow, 13);
                                //_trptcomputationvaluetableobjects.column_11 = GetGridCellValue(srow, 14);
                                break;
                            case 15:
                                _trptcomputationvaluetableobjects.column_1 = GetGridCellValue(srow, 4);
                                _trptcomputationvaluetableobjects.column_2 = GetGridCellValue(srow, 5);
                                _trptcomputationvaluetableobjects.column_3 = GetGridCellValue(srow, 6);
                                _trptcomputationvaluetableobjects.column_4 = GetGridCellValue(srow, 7);
                                _trptcomputationvaluetableobjects.column_5 = GetGridCellValue(srow, 8);
                                _trptcomputationvaluetableobjects.column_6 = GetGridCellValue(srow, 9);
                                _trptcomputationvaluetableobjects.column_7 = GetGridCellValue(srow, 10);
                                _trptcomputationvaluetableobjects.column_8 = GetGridCellValue(srow, 11);
                                _trptcomputationvaluetableobjects.column_9 = GetGridCellValue(srow, 12);
                                _trptcomputationvaluetableobjects.column_10 = GetGridCellValue(srow, 13);
                                //_trptcomputationvaluetableobjects.column_11 = GetGridCellValue(srow, 14);
                                //_trptcomputationvaluetableobjects.column_12 = GetGridCellValue(srow, 15);
                                break;
                            case 16:
                                _trptcomputationvaluetableobjects.column_1 = GetGridCellValue(srow, 4);
                                _trptcomputationvaluetableobjects.column_2 = GetGridCellValue(srow, 5);
                                _trptcomputationvaluetableobjects.column_3 = GetGridCellValue(srow, 6);
                                _trptcomputationvaluetableobjects.column_4 = GetGridCellValue(srow, 7);
                                _trptcomputationvaluetableobjects.column_5 = GetGridCellValue(srow, 8);
                                _trptcomputationvaluetableobjects.column_6 = GetGridCellValue(srow, 9);
                                _trptcomputationvaluetableobjects.column_7 = GetGridCellValue(srow, 10);
                                _trptcomputationvaluetableobjects.column_8 = GetGridCellValue(srow, 11);
                                _trptcomputationvaluetableobjects.column_9 = GetGridCellValue(srow, 12);
                                _trptcomputationvaluetableobjects.column_10 = GetGridCellValue(srow, 13);
                                _trptcomputationvaluetableobjects.column_11 = GetGridCellValue(srow, 14);
                                //_trptcomputationvaluetableobjects.column_12 = GetGridCellValue(srow, 15);
                                //_trptcomputationvaluetableobjects.column_13 = GetGridCellValue(srow, 16);
                                break;
                            case 17:
                                _trptcomputationvaluetableobjects.column_1 = GetGridCellValue(srow, 4);
                                _trptcomputationvaluetableobjects.column_2 = GetGridCellValue(srow, 5);
                                _trptcomputationvaluetableobjects.column_3 = GetGridCellValue(srow, 6);
                                _trptcomputationvaluetableobjects.column_4 = GetGridCellValue(srow, 7);
                                _trptcomputationvaluetableobjects.column_5 = GetGridCellValue(srow, 8);
                                _trptcomputationvaluetableobjects.column_6 = GetGridCellValue(srow, 9);
                                _trptcomputationvaluetableobjects.column_7 = GetGridCellValue(srow, 10);
                                _trptcomputationvaluetableobjects.column_8 = GetGridCellValue(srow, 11);
                                _trptcomputationvaluetableobjects.column_9 = GetGridCellValue(srow, 12);
                                _trptcomputationvaluetableobjects.column_10 = GetGridCellValue(srow, 13);
                                _trptcomputationvaluetableobjects.column_11 = GetGridCellValue(srow, 14);
                                _trptcomputationvaluetableobjects.column_12 = GetGridCellValue(srow, 15);
                                //_trptcomputationvaluetableobjects.column_13 = GetGridCellValue(srow, 16);
                                //_trptcomputationvaluetableobjects.column_14 = GetGridCellValue(srow, 17);
                                break;
                            case 18:
                                _trptcomputationvaluetableobjects.column_1 = GetGridCellValue(srow, 4);
                                _trptcomputationvaluetableobjects.column_2 = GetGridCellValue(srow, 5);
                                _trptcomputationvaluetableobjects.column_3 = GetGridCellValue(srow, 6);
                                _trptcomputationvaluetableobjects.column_4 = GetGridCellValue(srow, 7);
                                _trptcomputationvaluetableobjects.column_5 = GetGridCellValue(srow, 8);
                                _trptcomputationvaluetableobjects.column_6 = GetGridCellValue(srow, 9);
                                _trptcomputationvaluetableobjects.column_7 = GetGridCellValue(srow, 10);
                                _trptcomputationvaluetableobjects.column_8 = GetGridCellValue(srow, 11);
                                _trptcomputationvaluetableobjects.column_9 = GetGridCellValue(srow, 12);
                                _trptcomputationvaluetableobjects.column_10 = GetGridCellValue(srow, 13);
                                _trptcomputationvaluetableobjects.column_11 = GetGridCellValue(srow, 14);
                                _trptcomputationvaluetableobjects.column_12 = GetGridCellValue(srow, 15);
                                _trptcomputationvaluetableobjects.column_13 = GetGridCellValue(srow, 16);
                                //_trptcomputationvaluetableobjects.column_14 = GetGridCellValue(srow, 17);
                                //_trptcomputationvaluetableobjects.column_15 = GetGridCellValue(srow, 18);
                                break;
                            case 19:
                                _trptcomputationvaluetableobjects.column_1 = GetGridCellValue(srow, 4);
                                _trptcomputationvaluetableobjects.column_2 = GetGridCellValue(srow, 5);
                                _trptcomputationvaluetableobjects.column_3 = GetGridCellValue(srow, 6);
                                _trptcomputationvaluetableobjects.column_4 = GetGridCellValue(srow, 7);
                                _trptcomputationvaluetableobjects.column_5 = GetGridCellValue(srow, 8);
                                _trptcomputationvaluetableobjects.column_6 = GetGridCellValue(srow, 9);
                                _trptcomputationvaluetableobjects.column_7 = GetGridCellValue(srow, 10);
                                _trptcomputationvaluetableobjects.column_8 = GetGridCellValue(srow, 11);
                                _trptcomputationvaluetableobjects.column_9 = GetGridCellValue(srow, 12);
                                _trptcomputationvaluetableobjects.column_10 = GetGridCellValue(srow, 13);
                                _trptcomputationvaluetableobjects.column_11 = GetGridCellValue(srow, 14);
                                _trptcomputationvaluetableobjects.column_12 = GetGridCellValue(srow, 15);
                                _trptcomputationvaluetableobjects.column_13 = GetGridCellValue(srow, 16);
                                _trptcomputationvaluetableobjects.column_14 = GetGridCellValue(srow, 17);
                                //_trptcomputationvaluetableobjects.column_15 = GetGridCellValue(srow, 18);
                                //_trptcomputationvaluetableobjects.column_16 = GetGridCellValue(srow, 19);
                                break;
                            case 20:
                                _trptcomputationvaluetableobjects.column_1 = GetGridCellValue(srow, 4);
                                _trptcomputationvaluetableobjects.column_2 = GetGridCellValue(srow, 5);
                                _trptcomputationvaluetableobjects.column_3 = GetGridCellValue(srow, 6);
                                _trptcomputationvaluetableobjects.column_4 = GetGridCellValue(srow, 7);
                                _trptcomputationvaluetableobjects.column_5 = GetGridCellValue(srow, 8);
                                _trptcomputationvaluetableobjects.column_6 = GetGridCellValue(srow, 9);
                                _trptcomputationvaluetableobjects.column_7 = GetGridCellValue(srow, 10);
                                _trptcomputationvaluetableobjects.column_8 = GetGridCellValue(srow, 11);
                                _trptcomputationvaluetableobjects.column_9 = GetGridCellValue(srow, 12);
                                _trptcomputationvaluetableobjects.column_10 = GetGridCellValue(srow, 13);
                                _trptcomputationvaluetableobjects.column_11 = GetGridCellValue(srow, 14);
                                _trptcomputationvaluetableobjects.column_12 = GetGridCellValue(srow, 15);
                                _trptcomputationvaluetableobjects.column_13 = GetGridCellValue(srow, 16);
                                _trptcomputationvaluetableobjects.column_14 = GetGridCellValue(srow, 17);
                                _trptcomputationvaluetableobjects.column_15 = GetGridCellValue(srow, 18);
                                //_trptcomputationvaluetableobjects.column_16 = GetGridCellValue(srow, 19);
                                //_trptcomputationvaluetableobjects.column_17 = GetGridCellValue(srow, 20);
                                break;
                            default:
                                break;
                        }

                        rowsAffected = new TRPTComputationValueTableHandler().SaveCompoundRule(_trptcomputationvaluetableobjects);
                    }
                    else
                        return;

                    if (rowsAffected > 0)
                    {
                        divAlert.Visible = true;
                        divAlert.Attributes.Add("class", "alert alert-success alert-dismissible");
                        lblError.Text = $"Computation value adjustment saved successfully. ";
                        //divGrids.Attributes.CssStyle.Add("display", "none");
                        //srow.BackColor = System.Drawing.Color.LightSkyBlue;
                    }
                    else
                    {
                        divAlert.Visible = true;
                        divAlert.Attributes.Add("class", "alert alert-danger alert-dismissible");
                        lblError.Text = SharedConst.ERROR_SHARED_ERROR_MESSAGE;
                    }
                }
            }
            catch(Exception ex)
            {
                LogUtitlity.LogToText(ex.ToString());
                divAlert.Visible = true;
                divAlert.Attributes.Add("class", "alert alert-danger alert-dismissible");
                lblError.Text = SharedConst.ERROR_SHARED_ERROR_MESSAGE;
            }
        }

        protected void btnCancelAdjustment_ServerClick(object sender, EventArgs e)
        {
            //Response.Write(GetFromSession(SharedConst.SESSION_IS_MODIFIED).ToString());
            if (GetFromSession(SharedConst.SESSION_IS_MODIFIED).Equals("true"))
            {
                divAlert.Visible = true;
                divAlert.Attributes.Add("class", "alert alert-info alert-dismissible");
                lblError.Text = "Some changes were made and has not been saved, save changes or <a href='#' id='lnkCancel'> cancel </a> to proceed";
            }
            else
                SaveToSession(SharedConst.SESSION_IS_MODIFIED, "false");
        }
    }
}