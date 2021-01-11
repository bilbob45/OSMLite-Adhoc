using System;
using System;
using System.Drawing;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Globalization;
using Adhocs.Logic.ServiceHandler;
using Adhocs.Logic.DatabaseHandler;
using Adhocs.App_Code.DatabaseHandler;
using System.Transactions;
using System.Collections;
using System.Threading.Tasks;
using Adhocs.Logic.Infrastructure;
using System.Diagnostics;

namespace Adhocs.returns
{
    public partial class radjustment : BasePage
    {
        private String ReturnTableName1 { get; set; }
        public string ReturnTableName2 { get; private set; }
        TCoreRiType _riType = new TCoreRiType();
        ReturnAdjustment raHandler = new ReturnAdjustment();
        bool canEdit;
        Dictionary<int, double> oldDictionaryItem = new Dictionary<int, double>();

        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (base.Error.Count > 0)
                {
                    this.frmRAdjustment.Visible = false;
                    return;
                }

                if (!Page.IsPostBack)
                {
                    _riType.BindReturnAdjustmentRiType(this.cmbInstitutionType);
                    this.cmbInstitutionType.Items.Insert(0, "-choose one-");
                }
            }
            catch (Exception ex)
            {
                //divAlert.Visible = true;
                //lblErrorMsg.Text = "An internal error has occured";
                LogUtitlity.LogToText(ex.ToString());
            }
        }
        

        #region Columns selected index changed
        protected void cmbInstitutionType_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (this.cmbInstitutionType.SelectedItem.ToString() != null)
            {
                try
                {
                    var instTypeId = this.cmbInstitutionType.SelectedValue;
                    var ricodeByType = _riType.GetRICodeByID(instTypeId);
                    #region
                    //
                    //Convert RI type ID to ri code, build up and save the table name to be use in the return adjustment operation
                    //
                    if(instTypeId.Equals("3")) //mbr300 and mbr1000
                    {
                        this.ReturnTableName1 = raHandler.GetAjustmentTable(instTypeId.ToLower(), SharedConst.MBR300_TABLE_SURFIX);
                        this.ReturnTableName2 = raHandler.GetAjustmentTable(instTypeId.ToLower(), SharedConst.MBR1000_TABLE_SURFIX);
                        this.lblTableName300.InnerText = "MBR 300 Records";
                        this.lblTableName1000.InnerText = "MBR 1000 Records";
                    }
                    else if(instTypeId.Equals("6")) //mdhr300 and mdhr1000
                    {
                        this.ReturnTableName1 = raHandler.GetAjustmentTable(instTypeId.ToLower(), SharedConst.MDHR300_TABLE_SURFIX);
                        this.ReturnTableName2 = raHandler.GetAjustmentTable(instTypeId.ToLower(), SharedConst.MDHR1000_TABLE_SURFIX);
                        this.lblTableName300.InnerText = "MDHR 300 Records";
                        this.lblTableName1000.InnerText = "MDHR 1000 Records";
                    }
                    else if (instTypeId.Equals("12")) //mnbr300 and mnbr1000
                    {
                        this.ReturnTableName1 = raHandler.GetAjustmentTable(instTypeId.ToLower(), SharedConst.MNBR300_TABLE_SURFIX);
                        this.ReturnTableName2 = raHandler.GetAjustmentTable(instTypeId.ToLower(), SharedConst.MNBR1000_TABLE_SURFIX);
                        this.lblTableName300.InnerText = "MNBR 300 Records";
                        this.lblTableName1000.InnerText = "MNBR 1000 Records";
                    }
                    else
                    {
                        return;
                    }
                    #endregion

                    //
                    //Save the table name return for adjustment into session
                    //
                    SaveToSession("table1", this.ReturnTableName1);
                    SaveToSession("table2", this.ReturnTableName2);

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
                catch(Exception ex)
                {
                    LogUtitlity.LogToText(ex.ToString());
                }
            }
        }

        protected void btnAdjustReturn_ServerClick(object sender, EventArgs e)
        {
            #region Conditional Check
            if (this.cmbInstitutionType.SelectedIndex < 1)
            {
                divAlert.Visible = true;
                lblErrorMsg.Text = "Institution type is required";
                return;
            }
            if (this.cmbReportingInstitution.SelectedIndex < 1)
            {
                divAlert.Visible = true;
                lblErrorMsg.Text = "Reporting institution is required";
                return;
            }
            if(String.IsNullOrEmpty(this.txtWorkcollectionDate.Text))
            {
                divAlert.Visible = true;
                lblErrorMsg.Text = "Work collection date is required";
                return;
            }
            else
            {
                divAlert.Visible = false;
                lblErrorMsg.Text = string.Empty;
            }
            #endregion
            try
            {
                //Build schedule for analyst return paramter
                ReturnAdjustmentModel returnObject = new ReturnAdjustmentModel()
                {
                    ri_id = Convert.ToInt32(this.cmbReportingInstitution.SelectedValue),
                    work_collection_date = Convert.ToDateTime(this.txtWorkcollectionDate.Text.Trim())
                };

                //Get the schedule for analyst return parameter
                DataTable dtable = raHandler.GetScheduleForAnalystAdjustment(returnObject);

                //Check if there exists returns to be adjusted
                if (dtable.Rows.Count > 0)
                {
                    SaveToSession(SharedConst.S_SCHEDULE_ID, dtable.Rows[0]["schedule_id"].ToString());
                    SaveToSession(SharedConst.S_RUN_ID, dtable.Rows[0]["run_id"].ToString());
                    SaveToSession(SharedConst.S_ANALYST_COMMENTS, dtable.Rows[0]["analyst_comment"].ToString());

                    if (!String.IsNullOrWhiteSpace(GetFromSession(SharedConst.S_SCHEDULE_ID).ToString()))
                    {
                        //Get the institution code
                        var ritypeId = this.cmbInstitutionType.SelectedValue;
                        var riid = this.cmbReportingInstitution.SelectedValue;

                        //Bind mbr300 grid to datasource
                        Debug.WriteLine("Table name mapped to gridviewLeft300 = " + GetFromSession("table1"));

                        this.gridviewLeft300.DataSource = raHandler.MBR300ReturnAdjustment(GetFromSession("table1"), riid, GetFromSession(SharedConst.S_SCHEDULE_ID).ToString(), GetFromSession(SharedConst.S_RUN_ID).ToString());
                        this.gridviewLeft300.DataBind();

                        //
                        //Add comma character to specific grid values
                        //
                        var tablefromSession = GetFromSession("table1");

                        Debug.WriteLine("Table name" + tablefromSession);

                        FormatGridCellValues(tablefromSession);

                        //Bind mbr1000 grid to datasource
                        this.gridviewRight1000.DataSource = raHandler.MBR1000ReturnAdjustment(GetFromSession("table2"), riid, GetFromSession(SharedConst.S_SCHEDULE_ID).ToString(), GetFromSession(SharedConst.S_RUN_ID).ToString());
                        this.gridviewRight1000.DataBind();

                        //
                        //Add comma character to specific grid values
                        //
                        FormatGridCellValues(GetFromSession("table2"));

                        //Hide the control holding the two grid controls
                        //this.divAdjustmentButton.Visible = true;
                        this.divGridResult.Visible = true;
                        this.divAlert.Visible = false;
                        this.lblErrorMsg.Text = String.Empty;
                    }
                    else
                    {
                        divAlert.Attributes.Add("class", "alert alert-warning alert-dismissible");
                        divAlert.Visible = true;
                        lblErrorMsg.Text = "There is no schedule available for to the selected return institution";
                        //Hide the control holder the two grid controls
                        this.divGridResult.Visible = false;
                        return;
                    }
                }
                else
                {
                    divAlert.Attributes.Add("class", "alert alert-warning alert-dismissible");
                    divAlert.Visible = true;
                    lblErrorMsg.Text = "There's no return available for adjustment for the specified date";
                    //Hide the control holder the two grid controls
                    this.divGridResult.Visible = false;
                    return;
                }
            }
            catch (Exception ex)
            {
                divAlert.Visible = true;
                lblErrorMsg.Text = ex.ToString();
                //lblErrorMsg.Text = "Internal system error";
                LogUtitlity.LogToText(ex.ToString());
            }
        }
        #endregion

        private void CalculateTotal(string returncode, int itemcode)
        {
            var storedFormularsNItemCode = new SubmissionReferenceCalc().GetFormulars(returncode, itemcode, 0);
            if (storedFormularsNItemCode.Count < 1) return;

            string returnedFormular, returnedFormularSecond = string.Empty;
            int parentItemCode = 0;
            string returnTableName = GetFromSession("table1");

            if (returncode.Contains("300")) // For 300 related returns
            {
                foreach (var key in storedFormularsNItemCode)
                {
                    returnedFormular = key.Value;
                    returnedFormularSecond = key.Value;
                    parentItemCode = key.Key;

                    for (int x = 0; x <= gridviewLeft300.Rows.Count; x++)
                    {
                        if (returnTableName.Equals(SharedConst.T_SUBMISSION_MDHR300) == false) //For mbr300 and mnbr300
                            returnedFormular = 
                                returnedFormular.Replace(gridviewLeft300.Rows[x].Cells[7].Text, gridviewLeft300.Rows[x].Cells[9].Text.Replace("₦", "").Replace(",", ""));
                        else //For mdhr300
                        {
                            returnedFormular = 
                                returnedFormular.Replace(gridviewLeft300.Rows[x].Cells[7].Text, gridviewLeft300.Rows[x].Cells[9].Text).Replace("₦", "").Replace(",", "");
                            returnedFormularSecond = 
                                returnedFormularSecond.Replace(gridviewLeft300.Rows[x].Cells[7].Text, gridviewLeft300.Rows[x].Cells[10].Text.Replace("₦", "").Replace(",", ""));
                        }

                        if (gridviewLeft300.Rows[x].Cells[7].Text == parentItemCode.ToString())
                        {
                            if (returnTableName.Equals(SharedConst.T_SUBMISSION_MDHR300))
                            {
                                gridviewLeft300.Rows[x].Cells[9].Text = Convert.ToDecimal(new DataTable().Compute(returnedFormular, "")).ToString(StringUtility.FormatMoney()).Insert(0, "₦"); //Insert the naira symbol at the first index
                                gridviewLeft300.Rows[x].Cells[9].ForeColor = System.Drawing.Color.Green;

                                gridviewLeft300.Rows[x].Cells[10].Text = Convert.ToDecimal(new DataTable().Compute(returnedFormularSecond, "")).ToString(StringUtility.FormatMoney()).Insert(0, "₦");
                                gridviewLeft300.Rows[x].Cells[10].ForeColor = System.Drawing.Color.Green;
                            }
                            
                            gridviewLeft300.Rows[x].Cells[9].Text = Convert.ToDecimal(new DataTable().Compute(returnedFormular, "")).ToString(StringUtility.FormatMoney()).Insert(0, "₦");
                            gridviewLeft300.Rows[x].Cells[9].ForeColor = System.Drawing.Color.Green;

                            //second level loop to get the formular dependencies and inter
                            var allFormulaDependencies = new SubmissionReferenceCalc().GetFormularDependencies(returncode, parentItemCode.ToString());
                            String summedFormula;
                            allFormulaDependencies.Remove(parentItemCode);
                            foreach (var formula in allFormulaDependencies)
                            {
                                int dependencyItemCode = formula.Key;
                                String dependencyFormular = formula.Value;

                                for (int y = 0; y <= gridviewLeft300.Rows.Count; y++)
                                {
                                    dependencyFormular = 
                                        dependencyFormular.Replace(gridviewLeft300.Rows[y].Cells[7].Text, gridviewLeft300.Rows[y].Cells[9].Text.Replace("₦", "").Replace(",", ""));

                                    if (gridviewLeft300.Rows[y].Cells[7].Text == dependencyItemCode.ToString())
                                    {
                                        if (returnTableName.Equals(SharedConst.T_SUBMISSION_MDHR300))
                                        {
                                            summedFormula = new DataTable().Compute(dependencyFormular, "").ToString();
                                            gridviewLeft300.Rows[y].Cells[9].Text = Convert.ToDecimal(new DataTable().Compute(returnedFormular, "")).ToString(StringUtility.FormatMoney()).Insert(0, "₦");
                                            gridviewLeft300.Rows[y].Cells[9].ForeColor = System.Drawing.Color.Green;

                                            gridviewLeft300.Rows[y].Cells[10].Text = Convert.ToDecimal(new DataTable().Compute(returnedFormularSecond,"")).ToString(StringUtility.FormatMoney()).Insert(0, "₦");
                                            gridviewLeft300.Rows[y].Cells[10].ForeColor = System.Drawing.Color.Green;
                                        }

                                        summedFormula = new DataTable().Compute(dependencyFormular, "").ToString();
                                        gridviewLeft300.Rows[y].Cells[9].Text = Convert.ToDecimal(summedFormula).ToString(StringUtility.FormatMoney()).Insert(0, "₦");
                                        gridviewLeft300.Rows[y].Cells[9].ForeColor = System.Drawing.Color.Green;

                                        gridviewLeft300.Rows[y].Cells[9].Text = Convert.ToDecimal(summedFormula).ToString(StringUtility.FormatMoney()).Insert(0, "₦");
                                        break;
                                    }
                                }
                            }
                            break;
                        }
                    }
                }
            }
            else //for 1000 related returns
            {
                foreach (var key in storedFormularsNItemCode)
                {
                    returnedFormular = key.Value;
                    returnedFormularSecond = key.Value;
                    parentItemCode = key.Key;

                    for (int x = 0; x <= gridviewRight1000.Rows.Count; x++)
                    {
                        returnedFormular = 
                            returnedFormular.Replace(gridviewRight1000.Rows[x].Cells[7].Text, gridviewRight1000.Rows[x].Cells[9].Text.Replace("₦", "").Replace(",", ""));
                        returnedFormularSecond = 
                            returnedFormularSecond.Replace(gridviewRight1000.Rows[x].Cells[7].Text, gridviewRight1000.Rows[x].Cells[10].Text.Replace("₦", "").Replace(",", ""));
                        if (gridviewRight1000.Rows[x].Cells[7].Text == key.Key.ToString())
                        {
                            gridviewRight1000.Rows[x].Cells[9].Text = Convert.ToDecimal(new DataTable().Compute(returnedFormular, "")).ToString(StringUtility.FormatMoney()).Insert(0, "₦");
                            gridviewRight1000.Rows[x].Cells[9].ForeColor = System.Drawing.Color.Green;

                            gridviewRight1000.Rows[x].Cells[10].Text = Convert.ToDecimal(new DataTable().Compute(returnedFormularSecond, "")).ToString(StringUtility.FormatMoney()).Insert(0, "₦");
                            gridviewRight1000.Rows[x].Cells[10].ForeColor = System.Drawing.Color.Green;

                            var allFormulaDependencies = new SubmissionReferenceCalc().GetFormularDependencies(returncode, parentItemCode.ToString());

                            //second level loop to get the formular dependencies and inter
                            String summedFormula, summedFormulaSecond = string.Empty;
                            allFormulaDependencies.Remove(parentItemCode);
                            foreach (var formula in allFormulaDependencies)
                            {
                                int dependencyItemCode = formula.Key;
                                String dependencyFormular = formula.Value;
                                String dependencyFormular2 = formula.Value;

                                for (int y = 0; y <= gridviewRight1000.Rows.Count; y++)
                                {
                                    dependencyFormular = 
                                        dependencyFormular.Replace(gridviewRight1000.Rows[y].Cells[7].Text, gridviewRight1000.Rows[y].Cells[9].Text.Replace("₦", "").Replace(",", ""));
                                    dependencyFormular2 = 
                                        dependencyFormular2.Replace(gridviewRight1000.Rows[y].Cells[7].Text, gridviewRight1000.Rows[y].Cells[10].Text.Replace("₦", "").Replace(",", ""));

                                    if (gridviewRight1000.Rows[y].Cells[7].Text == dependencyItemCode.ToString())
                                    {
                                        summedFormula = new DataTable().Compute(dependencyFormular, "").ToString();
                                        summedFormulaSecond = new DataTable().Compute(dependencyFormular2, "").ToString();

                                        gridviewRight1000.Rows[y].Cells[9].Text = Convert.ToDecimal(summedFormula).ToString(StringUtility.FormatMoney()).Insert(0, "₦");
                                        gridviewRight1000.Rows[y].Cells[9].ForeColor = System.Drawing.Color.Green;

                                        gridviewRight1000.Rows[y].Cells[10].Text = Convert.ToDecimal(summedFormulaSecond).ToString(StringUtility.FormatMoney()).Insert(0, "₦");
                                        gridviewRight1000.Rows[y].Cells[10].ForeColor = System.Drawing.Color.Green;
                                        break;
                                    }
                                }
                            }
                            break;
                        }
                    }
                }
            }
        }

        protected void btnProceedToReturnAdjustment_ServerClick(object sender, EventArgs e)
        {
            try
            {
                var clickedButton = sender as System.Web.UI.HtmlControls.HtmlButton;
                //The button bellow works for all returns with 300 suffix
                if (clickedButton.ID.Equals("btnProceedToReturnAdjustment"))
                {          
                    //Set the new value in the gridview
                    if (GetFromSession("table1").Equals(SharedConst.T_SUBMISSION_MDHR300))
                    {
                        SetGridViewRowCellValueAndColor(this.gridviewLeft300, 9, Convert.ToDecimal(this.txtNewCurrencyValue.Value).ToString(StringUtility.FormatMoney()).Insert(0, "₦"), System.Drawing.Color.Maroon);
                        SetGridViewRowCellValueAndColor(this.gridviewLeft300, 10, Convert.ToDecimal(this.txtNewCurrencyValue2.Value).ToString(StringUtility.FormatMoney()).Insert(0, "₦"), System.Drawing.Color.Maroon);
                    }
                    else
                        SetGridViewRowCellValueAndColor(this.gridviewLeft300, 9, Convert.ToDecimal(this.txtNewCurrencyValue.Value).ToString(StringUtility.FormatMoney()).Insert(0, "₦"), System.Drawing.Color.Maroon);

                    //Get the old value before saving changing it.
                    var gridViewSelectedRow = this.gridviewLeft300.SelectedRow;
                    int itemCode = Convert.ToInt32(HttpUtility.HtmlEncode(gridViewSelectedRow.Cells[7].Text));

                    String returnCode = GetFromSession("table1").Split('_')[3];
                    CalculateTotal(returnCode, itemCode);
                }
                else //The button bellow works for all returns with 1000 suffix
                {
                    SetGridViewRowCellValueAndColor(this.gridviewRight1000, 9, Convert.ToDecimal(this.txtNewLastMonthCurrencyValue.Value).ToString(StringUtility.FormatMoney()).Insert(0, "₦"), System.Drawing.Color.Maroon);
                    SetGridViewRowCellValueAndColor(this.gridviewRight1000, 10, Convert.ToDecimal(this.txtNewYearToDateCurrencyValue.Value).ToString(StringUtility.FormatMoney()).Insert(0, "₦"), System.Drawing.Color.Maroon);

                    //Get the old value before saving changing it.
                    var gridViewSelectedRow = this.gridviewRight1000.SelectedRow;
                    int itemCode = Convert.ToInt32(HttpUtility.HtmlEncode(gridViewSelectedRow.Cells[7].Text));

                    String returnCode = GetFromSession("table2").Split('_')[3];
                    CalculateTotal(returnCode, itemCode);
                }
            }
            catch (Exception ex)
            {
                divAlert.Visible = true;
                lblErrorMsg.Text = "An error occured while executing the page";
                LogUtitlity.LogToText(ex.ToString());
            }
        }

        #region Gridview SelectedIndex Changed

        /// <summary>
        /// Save some specific column value from the grid
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void gridviewLeft300_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                var gridViewSelectedRow = this.gridviewLeft300.SelectedRow;
                gridViewSelectedRow.Focus();

                if (gridViewSelectedRow.Cells.Count > 0)
                {
                    //Set a flag to indicate that the selected row contains value(s)
                    this.hdnValues.Value = "300:1";
                    SaveToSession("aiflag", "300");

                    //Get the item code from the selecetd row in gridview
                    var selectedItemCode = Convert.ToInt32(HttpUtility.HtmlEncode(gridViewSelectedRow.Cells[7].Text));
                    //Check weather the selecered item code is editable or not
                    this.canEdit = raHandler.IsRestrictedItem(selectedItemCode);
                    if (this.canEdit == false)
                    {
                        //Show an error message to indicate the item code cant be edited
                        divAlert.Attributes.Add("class", "alert alert-warning alert-dismissible");
                        divAlert.Visible = true;
                        lblErrorMsg.Text = "Warning - can't modify the selected item";
                        return;
                    }
                    else
                    {
                        //Hide the error div
                        divAlert.Visible = false;

                        // Using c# string Interpolation
                        lblItemCode.InnerText = $"Item Code: {selectedItemCode}";
                        lblDescriptionToModify.InnerText = $"Item Description: {HttpUtility.HtmlEncode(gridViewSelectedRow.Cells[8].Text)}"; 

                        if (GetFromSession("table1").Equals(SharedConst.T_SUBMISSION_MDHR300))
                        {
                            this.div300Mdhr3.Style.Add("display", "grid");
                            this.div300Mdhr1.Attributes.Add("Class", "form-group col-md-6");
                            this.div300Mdhr2.Style.Add("display", "grid");
                            lblLocalCurrencyToModify.InnerText = $"Amount (Old) 1 : { HttpUtility.HtmlEncode(gridViewSelectedRow.Cells[9].Text) }";
                            lblLocalCurrencyToModify2nd.InnerText = $"Amount (Old) 2 : { HttpUtility.HtmlEncode(gridViewSelectedRow.Cells[9].Text) }";
                            lblAdjReason.InnerText = $"Reason for Adjustment: { (!String.IsNullOrWhiteSpace(HttpUtility.HtmlDecode(gridViewSelectedRow.Cells[13].Text)) ? gridViewSelectedRow.Cells[13].Text : "-")}";
                            return;
                        }
                        
                        this.div300Mdhr1.Attributes.Add("Class", "form-group col-md-12");
                        lblLocalCurrencyToModify.InnerText = $"Amount - Old : { HttpUtility.HtmlEncode(gridViewSelectedRow.Cells[9].Text)}";
                        lblAdjReason.InnerText = $"Reason for Adjustment : { (!String.IsNullOrWhiteSpace(HttpUtility.HtmlDecode(gridViewSelectedRow.Cells[12].Text)) ? gridViewSelectedRow.Cells[12].Text : "-")}";
                    }
                }
                else
                {
                    //Set a flag to indicate that the selected row is empty
                    this.hdnValues.Value = "0:0";
                }
            }
            catch(Exception ex)
            {
                LogUtitlity.LogToText(ex.ToString());
            }
        }

        private void LblAdjustReturn_ServerClick(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Save some specific column value from the grid
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void gridviewRight1000_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                //Get the currently selected rows in the gridview
                var gridViewSelectedRow = this.gridviewRight1000.SelectedRow;
                gridViewSelectedRow.Focus();
                if (gridViewSelectedRow.Cells.Count > 0)
                {
                    //Set a flag to indicate that the selected row is contains value(s)
                    this.hdnValues.Value = "1000:1";
                    SaveToSession("aiflag", "1000");

                    //check that selected index is editable
                    var selectedItemCode = Convert.ToInt32(HttpUtility.HtmlEncode(gridViewSelectedRow.Cells[7].Text));
                    this.canEdit = raHandler.IsRestrictedItem(selectedItemCode);
                    if (this.canEdit == false)
                    {
                        divAlert.Attributes.Add("class", "alert alert-warning alert-dismissible");
                        divAlert.Visible = true;
                        lblErrorMsg.Text = "Warning - can't modify the selected item";
                    }
                    else
                    {
                        //Hide the error div
                        divAlert.Visible = false;

                        //set the selected rows in the gridview
                        lblItemCode2.InnerText =$"Item Code: {selectedItemCode}";
                        lblDescriptionToModify2.InnerText = $"Item Description : {HttpUtility.HtmlEncode(gridViewSelectedRow.Cells[8].Text)}";
                        lblLocalCurrencyToModify2.InnerText = $"Amount (Month) : {HttpUtility.HtmlEncode(gridViewSelectedRow.Cells[9].Text)}";
                        lblLocalCurrencyToModify3.InnerText = $"Amount (Year) : {HttpUtility.HtmlEncode(gridViewSelectedRow.Cells[10].Text)}";
                        lblAdjReason2.InnerText = $"Reason for Adjustment : { (!String.IsNullOrWhiteSpace(HttpUtility.HtmlDecode(gridViewSelectedRow.Cells[13].Text)) ? gridViewSelectedRow.Cells[13].Text : "-")}";
                    }
                }
                else
                {
                    //Set a flag to indicate that the selected row is empty
                    this.hdnValues.Value = "0:0";
                }
            }
            catch (Exception ex)
            {
                LogUtitlity.LogToText(ex.ToString());
            }
        }

        protected void gridviewLeftRight_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            try
            {
                //cast the selected sender control to grid
                var selectedGrid = sender as GridView;
                if (selectedGrid.ID.Equals("griviewReturnAdjusted"))
                {
                    this.gridviewLeft300.PageIndex = e.NewPageIndex;
                    this.gridviewLeft300.DataSource
                        = raHandler.MBR300ReturnAdjustment(GetFromSession("table1"), this.cmbReportingInstitution.SelectedValue, GetFromSession(SharedConst.S_SCHEDULE_ID).ToString(), GetFromSession(SharedConst.S_RUN_ID).ToString());
                    this.gridviewLeft300.DataBind();
                }
                else
                {
                    this.gridviewRight1000.PageIndex = e.NewPageIndex;
                    this.gridviewRight1000.DataSource = raHandler.MBR1000ReturnAdjustment(GetFromSession("table2"), this.cmbReportingInstitution.SelectedValue, GetFromSession(SharedConst.S_SCHEDULE_ID).ToString(), GetFromSession(SharedConst.S_RUN_ID).ToString());
                    this.gridviewRight1000.DataBind();
                }
            }
            catch (Exception ex)
            {
                LogUtitlity.LogToText(ex.ToString());
            }
        }
        #endregion

        #region Handles gridview row data bound to hide specific columns
        protected void griviewReturnAdjusted_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.Cells.Count > 1)
            {
                e.Row.Cells[1].Visible = false;
                e.Row.Cells[2].Visible = false;
                if (GetFromSession("table1").Equals(SharedConst.T_SUBMISSION_MDHR300))
                {
                    e.Row.Cells[3].Visible = false;
                    e.Row.Cells[4].Visible = false;
                    e.Row.Cells[5].Visible = false;
                    e.Row.Cells[6].Visible = false;

                    //Uncomment the below line of code to hide the column    

                    //e.Row.Cells[7].Visible = false;
                    //e.Row.Cells[8].Visible = false;
                    //e.Row.Cells[9].Visible = false;
                    //e.Row.Cells[10].Visible = false;
                    e.Row.Cells[11].Visible = false;
                    e.Row.Cells[12].Visible = false;
                    e.Row.Cells[13].Visible = false;
                    e.Row.Cells[14].Visible = false;
                }
                else
                {
                    e.Row.Cells[3].Visible = false;
                    e.Row.Cells[4].Visible = false;
                    e.Row.Cells[5].Visible = false;
                    e.Row.Cells[6].Visible = false;
                    e.Row.Cells[10].Visible = false;
                    e.Row.Cells[11].Visible = false;
                    e.Row.Cells[13].Visible = false;

                    //Uncomment the below line of code to hide the column

                    //e.Row.Cells[7].Visible = false;
                    //e.Row.Cells[8].Visible = false;
                    //e.Row.Cells[9].Visible = false;
                    e.Row.Cells[12].Visible = false;
                }
            }
            else {
                return;
            }
        }

        protected void gridviewRight1000_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.Cells.Count > 1)
            {
                e.Row.Cells[1].Visible = false;
                e.Row.Cells[2].Visible = false;

                e.Row.Cells[3].Visible = false;
                e.Row.Cells[4].Visible = false;
                e.Row.Cells[5].Visible = false;
                e.Row.Cells[6].Visible = false;

                //e.Row.Cells[7].Visible = false;
                //e.Row.Cells[8].Visible = false;
                //e.Row.Cells[9].Visible = false;
                //e.Row.Cells[10].Visible = false;
                e.Row.Cells[11].Visible = false;
                e.Row.Cells[12].Visible = false;
                e.Row.Cells[13].Visible = false;
                e.Row.Cells[14].Visible = false;
            }
            else{
                return;
            }
        }
        #endregion

        #region helper functions for heavy lifting
        private String ConvertDecimalToMoney(decimal decimalnumber)
        {
            return decimalnumber.ToString("0,0.00").Insert(0, "₦");
            //return decimalnumber.ToString("C3", CultureInfo.CurrentCulture);//.Replace("₦", " ").Replace("£", " ").Replace("$", " ");
        }

        private void SetGridViewRowCellValueAndColor(GridView grid, int cellindex, string cellvalue, System.Drawing.Color forecolor)
        {
            var selectedGrid = grid.SelectedRow;
            selectedGrid.Cells[cellindex].Text = cellvalue;
            selectedGrid.Cells[cellindex].ForeColor = forecolor;
        }

        private void SaveToSession(string key, string value)
        {
            //RNGCryptoServiceProvider rngCrypt = new RNGCryptoServiceProvider();
            Session[key] = value;
        }

        public String GetFromSession(string key)
        {
            string sessionValue = string.Empty;
            try
            {
                sessionValue = Session[key].ToString();
            }
            catch (Exception ex)
            {
                LogUtitlity.LogToText(ex.ToString());
                return null;
            }

            return sessionValue;
        }

        private void SaveToSession(string[] key, string[] value)
        {
            for(int x = 0; x <= key.Length; x++)
            {
                Session[key[x]] = value[x];
            }
        }

        /// <summary>
        /// Format grid cell value to money - displaying the country currency symbol
        /// </summary>
        private void FormatGridCellValues(string tablename)
        {
            if(tablename.Contains("300"))
            {
                //Set the currency symbol of some specific gridiew cell value
                if (tablename.Equals(SharedConst.T_SUBMISSION_MDHR300))
                {
                    Debug.WriteLine("Table nam to check" + SharedConst.T_SUBMISSION_MDHR300);

                    foreach (GridViewRow grdRow in this.gridviewLeft300.Rows)
                    {
                        Debug.WriteLine("Table Cell Value 1" + grdRow.Cells[9].Text);
                        
                        grdRow.Cells[9].Text = ConvertDecimalToMoney(Convert.ToDecimal(grdRow.Cells[9].Text));

                        Debug.WriteLine("Table Cell Value 2 " + grdRow.Cells[10].Text);
                        grdRow.Cells[10].Text = ConvertDecimalToMoney(Convert.ToDecimal(grdRow.Cells[10].Text));
                    }
                    return;
                }

                foreach (GridViewRow grdRow in this.gridviewLeft300.Rows)
                {
                    Debug.WriteLine("Table Cell Value before = " + grdRow.Cells[9].Text);

                    grdRow.Cells[9].Text = ConvertDecimalToMoney(Convert.ToDecimal(grdRow.Cells[9].Text));

                    Debug.WriteLine("Table Cell Value after = " + grdRow.Cells[9].Text);
                }
            }
            else
            {
                //Set the currency symbol of some specific gridiew cell value
                foreach (GridViewRow grdRow in this.gridviewRight1000.Rows)
                {
                    grdRow.Cells[9].Text = ConvertDecimalToMoney(Convert.ToDecimal(grdRow.Cells[9].Text));
                    grdRow.Cells[10].Text = ConvertDecimalToMoney(Convert.ToDecimal(grdRow.Cells[10].Text));
                }
            }
        }
        #endregion

        #region Adjustment Return Label
        protected void lblAdjustReturn_ServerClick(object sender, EventArgs e)
        {
            try
            {
                if (GetFromSession("aiflag").ToString().Equals("300"))
                    if (this.canEdit == false)
                        ScriptManager.RegisterStartupScript(this, this.GetType(), "Pop", "openModal();", true);

                if (GetFromSession("aiflag").ToString().Equals("1000"))
                    if (this.canEdit == false)
                        ScriptManager.RegisterStartupScript(this, this.GetType(), "Pop", "openModal2();", true);

                    else
                    {
                        divAlert.Attributes.Add("class", "alert alert-warning alert-dismissible");
                        this.divAlert.Visible = true;
                        this.lblErrorMsg.Text = "Please select a return to be adjusted from below";
                        return;
                    }
            }
            catch (Exception ex)
            {
                LogUtitlity.LogToText(ex.ToString());
            }
        }
        #endregion

        /// <summary>
        /// Save all changes made to the return adjustment grids
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnSaveAllChanges_ServerClick(object sender, EventArgs e)
        {
            var rb1 = GetFromSession("table1");
            var rb2 = GetFromSession("table2");

            if (String.IsNullOrWhiteSpace(txtAreaAnalystComment.Value))
                return;

            try
            {
                int rowsAffected = 0;

                //Get te run id from session
                var runid = raHandler.GetIncrementRunId(GetFromSession(SharedConst.S_SCHEDULE_ID));

                if (String.IsNullOrWhiteSpace(runid.ToString()) || runid < 1)
                {
                    rowsAffected = raHandler.SaveReturnAdjustment(this.gridviewLeft300, this.gridviewRight1000, rb1, rb2, GetFromSession(SharedConst.S_SCHEDULE_ID), "1", txtAreaAnalystComment.Value);
                }
                else
                {
                    rowsAffected = raHandler.SaveReturnAdjustment(this.gridviewLeft300, this.gridviewRight1000, rb1, rb2, GetFromSession(SharedConst.S_SCHEDULE_ID), runid.ToString(), txtAreaAnalystComment.Value);
                }

                if (rowsAffected > 0)
                {
                    divAlert.Attributes.Add("class", "alert alert-success alert-dismissible");
                    divAlert.Visible = true;
                    lblErrorMsg.Text = $"Return adjustment for '{this.cmbReportingInstitution.SelectedItem.Text}' " +
                        $"saved successfully. <a href='{ Request.Url.ToString() }'> Reload </a>";

                    //Hide the control holder the two grid controls
                    this.divGridResult.Visible = false;
                }
                else
                {
                    divAlert.Visible = true;
                    lblErrorMsg.Text = "An error occured while saying the adjusted return";

                    //Hide the control holder the two grid controls
                    this.divGridResult.Visible = false;
                }


            }
            catch (SqlException sqlex)
            {
                divAlert.Visible = true;
                var errorMsg = "";
                switch (sqlex.Number)
                {
                    case 2627:
                        errorMsg = "Schedule Id already exists for the selected date";
                        break;
                    default:
                        errorMsg = "Schedule Id already exists for the selected date";
                        break;
                }
                lblErrorMsg.Text = "An error occured while saving the overall changes";
                Trace.Write(sqlex.ToString());
            }
            catch (Exception ex)
            {
                LogUtitlity.LogToText(ex.ToString());
            }
        }

        protected void btnAddAnalystComment_ServerClick(object sender, EventArgs e)
        {
            try
            {
                //Check if any modification has been made on the returns

                Session["comment"] = this.txtAreaAnalystComment.Value.Trim();
                ScriptManager.RegisterStartupScript(this, this.GetType(), "Pop", "openModal3();", true);
            }
            catch(Exception ex)
            {
                LogUtitlity.LogToText(ex.ToString());
            }
        }
    }
}