using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using RestSharp;
using RestSharp.Authenticators;

namespace Adhocs
{
    public partial class audit : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //string k = string.Empty;
            //foreach(var x in Request.ServerVariables.Keys)
            //{
            //    k += $"\n{x}\n";
            //}

            //Response.Write(k);
        }

        public string TwitterTest()
        {
            var client = new RestSharp.RestClient("https://upload.twitter.com/1.1/media/upload.json?media_category=TWEET_IMAGE");

            client.Timeout = -1;
            var request = new RestRequest(Method.POST);
            request.AddHeader("Content-Type", "application/x-www-form-urlencoded");
            request.AddHeader("dataType", "json");
            request.AddHeader("Authorization", $"OAuth oauth_consumer_key=\"uqF0Xl45tPY8oznL9X7VpXmwY\",oauth_token=\"1229771093214420993-Nuf0GXfLlZEiqn71LYgRAFgiKJKS97\",oauth_signature_method=\"HMAC-SHA1\",oauth_timestamp=\"{Convert.ToInt32((DateTime.Now - new DateTime(1970, 1, 1)).TotalSeconds).ToString()}\",oauth_nonce=\"{new Random().Next(0, int.MaxValue).ToString("X8")}\",oauth_version=\"1.0\",oauth_signature=\"dJ%2B35xnjg7vqkUg%2BzP2B6TV3%2Fdw%3D\"");
            request.AddHeader("Cookie", "personalization_id=\"v1_M7C2KXw+CCrOdLnCQ1Mn/Q==\"; guest_id=v1%3A159237331661317049; lang=en");
            request.AddFile("media", "C:\\Users\\Olamide\\Documents\\logo.png");
            IRestResponse response = client.Execute(request);
            if(!string.IsNullOrWhiteSpace(response.ErrorMessage))
            {
                lblError.Text = response.ErrorMessage;
            }
            return response.Content;
        }

        protected void btnClickMe_ServerClick(object sender, EventArgs e)
        {
            var response = TwitterTest();
            this.lblError.Text = response;
        }
    }
}