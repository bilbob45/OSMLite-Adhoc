using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Adhocs.Logic.Infrastructure;
using Adhocs.Logic.ServiceHandler;

namespace Adhocs.shared_ui
{
    public partial class enc_dec : System.Web.UI.Page
    {
        CryptoServiceHandler _crypt = null;
        protected void Page_Load(object sender, EventArgs e)
        {
            var uname = Request.QueryString["uanme"] ?? null;
            if(uname != null)
            {
                uname = Request.QueryString["uanme"].ToString();
                var encString = AESEncryptionUtil.DecryptTextFromBase64String(uname, SharedConst.HELICA_DEFAULT_CYPHER_KEY);
                Response.Write(encString);
            }
        }

        protected void btnDecrypt_ServerClick(object sender, EventArgs e)
        {
            ValidateForm();
            try
            {
                if(this.txtEncyptDecrypt.Value.Length % 4 > 0)
                {
                    this.txtEncyptDecrypt.Value += new string('=', 4 - this.txtEncyptDecrypt.Value.Length);
                }
                var stringToDecrypt = AESEncryptionUtil.DecryptTextFromBase64String(this.txtEncyptDecrypt.Value.Trim(), SharedConst.HELICA_DEFAULT_CYPHER_KEY);
                this.rchTxtOutput.Value = stringToDecrypt;
            }
            catch (Exception ex)
            {
                divAlert.Visible = true;
                lblError.Text = ex.Message;
            }
        }

        protected void btnEncrypt_ServerClick(object sender, EventArgs e)
        {
            ValidateForm();
            try
            {
                var stringToDecrypt = AESEncryptionUtil.EncryptTextToBase64String(this.txtEncyptDecrypt.Value.Trim(), SharedConst.HELICA_DEFAULT_CYPHER_KEY);
                //stringToDecrypt = stringToDecrypt.TrimEnd('=').Replace('+', '-').Replace('/', '_');
                this.rchTxtOutput.Value = stringToDecrypt;
            }
            catch (Exception ex)
            {
                divAlert.Visible = true;
                lblError.Text = ex.Message;
            }
        }

        private void ValidateForm()
        {
            if(string.IsNullOrWhiteSpace(txtEncyptDecrypt.Value))
            {
                divAlert.Visible = true;
                lblError.Text = "String to encrypt or decrypt can not be empty";
            }
        }

        protected void btnEncode_ServerClick(object sender, EventArgs e)
        {
            this.rchTxtEncodeDecodeOutput.Value = HttpUtility.UrlEncode(this.txtEncodeDecod.Value);
        }

        protected void btnDecode_ServerClick(object sender, EventArgs e)
        {
            this.rchTxtEncodeDecodeOutput.Value = HttpUtility.UrlDecode(this.txtEncodeDecod.Value);
        }
    }
}