using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Security;
using System.Security.Principal;
using System.Web.UI;

namespace Adhocs.App_Code.ServiceHandler
{
    public class UserIdentityHandler : Page
    {
        public String GetUserName()
        {
            return Page.User.Identity.Name;
        }
    }
}