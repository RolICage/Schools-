using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;

namespace school
{
    public partial class WebForm3 : System.Web.UI.Page
    {
        
        protected void Page_Load(object sender, EventArgs e)
        {

            DivPop.Visible = false;
            

            if (!IsPostBack)
            {

          

            }
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
           
            DivPop.Visible = true;      
            

        }

        
    }
}