using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;

namespace Adhocs.Logic.Infrastructure
{
    public static class AlertUtility
    {
        public static void Show(HtmlGenericControl divid, Label errortextid, string cssclassvalue, string errormessage)
        {
            if (divid.Visible = false)
                divid.Visible = true;

            if (errortextid.Visible = false)
                errortextid.Visible = true;

            divid.Attributes.Add("class", cssclassvalue);
            errortextid.Text = errormessage;
        }

        public static void Hide(HtmlGenericControl divid)
        {
            if (divid.Visible = false)
                divid.Visible = true;
            else
                divid.Visible = false;
        }
    }
}