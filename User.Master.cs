using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace BharatBuys
{
    public partial class User : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            lbtn();
        }

        protected void login_btn_Click(object sender, EventArgs e)
        {
            Response.Redirect("Login.aspx");
        }

        public void lbtn()
        {
            if (Session["User_id"] == null)
            {
                login_btn.Visible = true;
                login_btn.Enabled = true;
            }
            else
            {
                login_btn.Visible = false;
                login_btn.Enabled = false;
            }

        }
    }
}