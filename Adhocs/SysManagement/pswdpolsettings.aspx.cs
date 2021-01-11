using Adhocs.Logic.Infrastructure;
using Adhocs.Logic.Object;
using Adhocs.Logic.ServiceHandler;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Adhocs.SysManagement
{
    public partial class pswdpolsettings : Page
    {
        private TSysConfigurationIrsHandler _sysConfigHandler = new TSysConfigurationIrsHandler();
        private int _configId = 0;
        private string _defaultValue;
        private string _configValue;
        private int _enable = 0;
        private string _configValueDesc;
        private string _commandName;
        private int _rowsaffected = 0;
        public List<string> _modifTracker = new List<string>();
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                //check if a success message is inside the stack
                //if (base.Error.Count > 0)
                //{
                //    this.frmPasswordPolicy.Visible = false;
                //    return;
                //}

                if (!Page.IsPostBack)
                {
                    this.gridViewPasswordPolicy.DataSource = _sysConfigHandler.GetAll();
                    this.gridViewPasswordPolicy.DataBind();

                    //this.gridViewPasswordPolicyProc.DataSource = _sysConfigHandler.GetAllProc();
                    //this.gridViewPasswordPolicyProc.DataBind();
                }
            }
            catch (Exception ex)
            {
                LogUtitlity.LogToText($"{ex.ToString()}");
            }
        }

        protected void btnEditPolicy_ServerClick(object sender, EventArgs e)
        {
            ClientScript.RegisterStartupScript(this.GetType(), "UpdatePasswordPolicy", "$('#exampleModalCenterX').modal('show')", true);
        }

        protected void gridViewPasswordPolicy_SelectedIndexChanged(object sender, EventArgs e)
        {
            var gridViewSelectedRow = this.gridViewPasswordPolicy.SelectedRow;
            _configId = Convert.ToInt32(gridViewSelectedRow.Cells[1].Text);
            _configValueDesc = gridViewSelectedRow.Cells[5].Text;
            this.lblEntryTitleX.InnerText = $"{_configValueDesc}";
        }

        protected void gridViewPasswordPolicy_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            e.Row.Cells[1].Visible = false;
        }

        protected void cmbRequiredDigit_SelectedIndexChanged(object sender, EventArgs e)
        {
            ClientScript.RegisterStartupScript(this.GetType(), "UpdatePasswordPolicy", "$('#exampleModalCenterX').modal('show')", true);
        }

        protected void btnSave_ServerClick(object sender, EventArgs e)
        {
            try
            {
                //Save the settings 
                //Loop the gridview and check if gridview.rows[n-index].text = _modiftracker
                var tracker = (List<string>)Session["tracker"] ?? null;
                if (tracker == null || tracker.Count < 1)
                    return;
                tracker.Distinct<string>();
                foreach (var code in tracker)
                {
                    for (int y = 0; y <= this.gridViewPasswordPolicy.Rows.Count -1; y++)
                    {
                        if (code == this.gridViewPasswordPolicy.Rows[y].Cells[1].Text)
                        {
                            //Save the changes
                            int isEnabled = (this.gridViewPasswordPolicy.Rows[y].Cells[4].Text.Equals("Enable")) ? 1 : 0;
                            _rowsaffected += _sysConfigHandler.Save(new TSysConfigurationIrsObject()
                            {
                                config_id = Convert.ToInt32(code),
                                default_value = this.gridViewPasswordPolicy.Rows[y].Cells[2].Text,
                                config_value = this.gridViewPasswordPolicy.Rows[y].Cells[3].Text,
                                enabled = isEnabled
                            });
                        }
                    }
                }

                if (_rowsaffected > 0)
                {
                    this.divAlert.Visible = true;
                    divAlert.Attributes.Add("class", "alert alert-success alert-dismissible");
                    this.lblError.Text = "Password policy settings saved successfully";
                }
            }
            catch(Exception ex)
            {
                LogUtitlity.LogToText($"{ex.ToString()}");
            }
        }

        protected void btnUpdatePolicySettings_ServerClick(object sender, EventArgs e)
        {
            try
            {
                void ValidateControl()
                {
                    if (!string.IsNullOrWhiteSpace(txtDefaultValue.Value))
                    {
                        SetGridViewRowCellValueAndColor(this.gridViewPasswordPolicy, 2, this.txtDefaultValue.Value, System.Drawing.Color.Maroon);
                    }

                    if (!string.IsNullOrWhiteSpace(txtPolicyValue.Value))
                    {
                        SetGridViewRowCellValueAndColor(this.gridViewPasswordPolicy, 3, this.txtDefaultValue.Value, System.Drawing.Color.Maroon);
                    }

                    if (!string.IsNullOrWhiteSpace(cmbEnable.SelectedItem.Text) && !cmbEnable.SelectedItem.Text.Equals("--choose one--"))
                    {
                        SetGridViewRowCellValueAndColor(this.gridViewPasswordPolicy, 4, this.cmbEnable.SelectedItem.Text, System.Drawing.Color.Maroon);
                    }
                }

                ValidateControl();
                
                if(Session["tracker"] != null)
                {
                    _modifTracker = (List<string>)Session["tracker"];
                    _modifTracker.Add(gridViewPasswordPolicy.SelectedRow.Cells[1].Text);
                    Session["tracker"] = _modifTracker;
                }
                else
                {
                    _modifTracker.Add(gridViewPasswordPolicy.SelectedRow.Cells[1].Text);
                    Session["tracker"] = _modifTracker;
                }
            }
            catch(Exception ex)
            {
                LogUtitlity.LogToText($"{ex.ToString()}");
            }
        }

        private void SetGridViewRowCellValueAndColor(GridView grid, int cellindex, string cellvalue, System.Drawing.Color forecolor)
        {
            var selectedGrid = grid.SelectedRow;
            selectedGrid.Cells[cellindex].Text = cellvalue;
            selectedGrid.Cells[cellindex].ForeColor = forecolor;
        }
    }
}