using Adhocs.Logic.Infrastructure;
using Adhocs.Logic.Object;
using Adhocs.Logic.ServiceHandler;
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Adhocs.mgtcomponent
{
    public partial class bankratingsetupview : BasePage
    {
        TRPComputationBankRatingSetupObject _bankRatingModel;
        TRPTComputationBankRatingSetupHandler _bankRatinghandler;

        public bankratingsetupview()
        {
            _bankRatinghandler = new TRPTComputationBankRatingSetupHandler();
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                //currentUser = Request.QueryString[SharedConst.QUERY_STRING_USER_NAME];

                ////Get the user name of the currently logged in user and decrypt it
                //if (!String.IsNullOrWhiteSpace(Request.QueryString[SharedConst.QUERY_STRING_USER_NAME]))
                //{
                //    //Uncomment the below line of code when the crypographics module is okay
                //    //var encryptedQueryString = Request.QueryString[SharedConst.QUERY_STRING_USER_NAME];
                //    //currentUser = HttpUtility.UrlDecode(encryptedQueryString.Trim());                  
                //    //currentUser = CryptoServiceHandler.Decrypt(currentUser, CryptoServiceHandler.ENCRYPTION_PASS_PHRASE);
                //}
                //else
                //{
                //    this.frmBankRatingSetupView.Visible = false;
                //}

                if (base.Error.Count > 0)
                {
                    this.frmBankRatingSetupView.Visible = false;
                    return;
                }

                if (!Page.IsPostBack)
                {
                    //Bind the computation bank setup
                    this.gridViewBankRatingSetup.DataSource = _bankRatinghandler.GetBankRatingSetupDetails();
                    this.gridViewBankRatingSetup.DataBind();
                }
            }
            catch (Exception ex)
            {
                LogUtitlity.LogToText(ex.ToString());
            }
        }

        protected void gridViewBankRatingSetup_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                var selectedRow = this.gridViewBankRatingSetup.SelectedRow;
                string bankRateCode = selectedRow.Cells[1].Text.Trim();
                if (!string.IsNullOrWhiteSpace(bankRateCode))
                {
                    string filePath = $"~/mgtcomponent/bankratingsetup.aspx?uname={currentUser}&brc={bankRateCode}";
                    Response.Redirect(filePath);
                }
                else
                    return;
            }
            catch(Exception ex)
            {
                LogUtitlity.LogToText(ex.ToString());
            }
        }

        protected void lblBankSetup_ServerClick(object sender, EventArgs e)
        {
            try
            {
                Response.Redirect($"~/mgtcomponent/bankratingsetup.aspx?uname={currentUser}", false);
            }
            catch(Exception ex)
            {
                LogUtitlity.LogToText(ex.ToString());
            }
        }

        protected void lblBankScoring_ServerClick(object sender, EventArgs e)
        {
            try
            {
                Response.Redirect($"~/mgtcomponent/bankratingscore.aspx?uname={currentUser}", false);
            }
            catch (Exception ex)
            {
                LogUtitlity.LogToText(ex.ToString());
            }
        }
    }
}