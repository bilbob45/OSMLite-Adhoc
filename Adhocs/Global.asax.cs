using System;
using System.Web;
using System.Diagnostics;
using Adhocs.Logic.Infrastructure;

namespace WebForms_Samples
{
    public class Global : HttpApplication
    {
        void Application_Start(object sender, EventArgs e)
        {
            
        }

        void Application_Error(object sender, EventArgs e)
        {
            var s = Server.GetLastError();
            LogUtitlity.LogToText(s.ToString());
        }
    }
}
