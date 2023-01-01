using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WebApplication6.App_Code;


namespace WebApplication6
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        DataTable MyGrid;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                
                MyGrid = Class1.getall();
                Grid1.DataSource = MyGrid;
                Grid1.DataBind();
            }
            
        }

        protected void Grid1_RowEditing(object sender, GridViewEditEventArgs e)
        {
            String Name = "", Age = "", Class = "", Tybe = "", unite = "";
           


        }
        protected void Grid1_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {

        }

        protected void Grid1_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if(e.CommandName=="Doom")
            {
                e.CommandName.ToString();
            }
        }
    }
}