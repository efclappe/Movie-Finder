using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Threading;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace MovieFinderApp.View
{
    public partial class WebForm1 : System.Web.UI.Page
    {

        

        protected void Page_Load(object sender, EventArgs e)
        {
            
        }

        protected void Session_Start(object sender, EventArgs e)
        {
            System.Diagnostics.Debug.WriteLine("Session has begun!");
        }

        protected void Session_eND(object sender, EventArgs e)
        {
            System.Diagnostics.Debug.WriteLine("Session has ended!");
        }

    }
}