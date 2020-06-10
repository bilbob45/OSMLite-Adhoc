using Adhocs.Logic.Infrastructure;
using Adhocs.Logic.Object;
using Adhocs.Logic.ServiceHandler;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Transactions;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Adhocs.mgtcomponent
{
    public partial class liquiditystresstest : BasePage
    {
        TRPTLiqStressTestDataDefnObject _testDefnObject;
        TRPTLiqStressTestDataDefnHandler _testDefnHandler;
        TRPTLiqStressTestScoringHandler _testHandler;
        TRPTLiqStressTestScoringObject _testScoreObj;

        #region Local variables
        int _ritypeid = 0;
        int _riid = 0;
        string _stresTestDate = string.Empty;
        int rowsAffected = 0;
        #endregion

        public liquiditystresstest()
        {
            _testDefnObject = new TRPTLiqStressTestDataDefnObject();
            _testDefnHandler = new TRPTLiqStressTestDataDefnHandler();
            _testHandler = new TRPTLiqStressTestScoringHandler();
            _testScoreObj = new TRPTLiqStressTestScoringObject();
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                //Get the user name of the currently logged in user and decrypt it
                //if (!String.IsNullOrWhiteSpace(Request.QueryString[SharedConst.QUERY_STRING_USER_NAME]))
                //{
                //    currentUser = Request.QueryString[SharedConst.QUERY_STRING_USER_NAME];

                //    //Get the user name of the currently logged in user and decrypt it
                //    //Uncomment the below line of code when the crypographics module is okay
                //    //var encryptedQueryString = Request.QueryString[SharedConst.QUERY_STRING_USER_NAME];
                //    //currentUser = HttpUtility.UrlDecode(encryptedQueryString.Trim());                  
                //    //currentUser = CryptoServiceHandler.Decrypt(currentUser, CryptoServiceHandler.ENCRYPTION_PASS_PHRASE);
                //}
                //else
                //{
                //    this.frmliquiditystresstest.Visible = false;
                //}

                if (base.Error.Count > 0)
                {
                    this.frmliquiditystresstest.Visible = false;
                    return;
                }

                if (!Page.IsPostBack)
                {
                    _testDefnHandler.BindStressTestRiType(this.cmbRiType);
                    this.cmbRiType.Items.Insert(0, "-choose one-");
                }
            }
            catch (Exception ex)
            {
                LogUtitlity.LogToText(ex.ToString());
            }
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            ClientScript.RegisterStartupScript(this.GetType(), "Pop", "$('#exampleModalCenter3').modal('show')", true);
        }

        protected void cmbRiType_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                var ritypeId = Convert.ToInt32(this.cmbRiType.SelectedValue);
                _ritypeid = ritypeId;
                if (!String.IsNullOrWhiteSpace(ritypeId.ToString()))
                {
                    _testDefnHandler.BindStressTestRI(this.cmbReportingInstitution, ritypeId);
                    this.cmbReportingInstitution.Items.Insert(0, "-choose one-");
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

        protected void cmbReportingInstitution_SelectedIndexChanged(object sender, EventArgs e)
        {
            _riid = Convert.ToInt32(this.cmbReportingInstitution.SelectedValue);
        }

        protected void txtEndValidityDate_TextChanged(object sender, EventArgs e)
        {
            var isDateValid = ValidateDate(this.txtEndValidityDate.Text);
            this.divAlert.Visible = true;
            if (isDateValid == false)
            {
                lblError.Text = "The selected date is not in the right format";
            }
            else
            {
                divAlert.Visible = false;
            }
        }

        protected void btnUpdateScore_ServerClick(object sender, EventArgs e)
        {
            try
            {
                using (TransactionScope scope = new TransactionScope(TransactionScopeOption.Required))
                {
                    if (_testDefnHandler.GetLiquidityStressTestByInputReq(1).Count > 0)
                    {
                        foreach (var key in _testDefnHandler.GetLiquidityStressTestByInputReq(1))
                        {
                            _testScoreObj.item_code = key.Key;
                            _testScoreObj.item_description = key.Value;
                            _testScoreObj.ri_id = Convert.ToInt32(this.cmbReportingInstitution.SelectedValue);
                            _testScoreObj.valuation_date = Convert.ToDateTime(this.txtEndValidityDate.Text);
                            _testScoreObj.amount = this.txtAmount.Value.Trim();

                            rowsAffected += _testHandler.SaveComputationBankRatingSetup(_testScoreObj);
                        }
                        divAlert.Visible = true;
                        if (rowsAffected > 0)
                        {
                            divAlert.Attributes.Add("class", "alert alert-success alert-dismissible");
                            lblError.Text = "Liquidity stress test saved successfully";
                        }
                        else
                            lblError.Text = "An error occured while saving changes";
                    }
                    scope.Complete();
                }
            }
            catch(Exception ex)
            {
                divAlert.Visible = true;
                if (ex.ToString().Contains("PRIMARY KEY"))
                {
                    lblError.Text = "Selected reporting institution liquidity ratio already exists";
                }
                LogUtitlity.LogToText(ex.ToString()); 
            }
        }
    }
}