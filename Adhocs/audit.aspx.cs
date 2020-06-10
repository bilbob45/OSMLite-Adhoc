using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Adhocs
{
    public partial class audit : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string k = string.Empty;
            foreach(var x in Request.ServerVariables.Keys)
            {
                k += $"\n{x}\n";
            }

            Response.Write(k);
        }
    }
}