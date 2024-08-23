using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace BharatBuys
{
    public partial class your_account : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Username.Text  ="Welcome " + Session["User_id"].ToString();
        }

        protected void Back_Click(object sender, EventArgs e)
        {
            Response.Redirect("default.aspx");
        }

        protected void password_Click(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(changePass.Text) || String.IsNullOrEmpty(repass.Text))
            {
                string errorScript = "alert('cant update ');";
                ScriptManager.RegisterStartupScript(this, this.GetType(), "CoverImageErrorScript", errorScript, true);
                return;
            }
            else {

                SqlConnection con = new SqlConnection("Server=sql.bsite.net\\MSSQL2016;Database=bharatbuys_db;User Id=bharatbuys_db;Password=Ganesh@123.;");
                con.Open();
                SqlCommand cmd = new SqlCommand("update UserInfo set User_Password=@User_Password where User_Name=@User_Name", con);
                cmd.Parameters.AddWithValue("User_Name", Session["User_id"].ToString());
                cmd.Parameters.AddWithValue("User_Password", repass.Text);
                cmd.ExecuteNonQuery();
                con.Close();

                string errorScript = "alert('Password changed sucessfully');";
                ScriptManager.RegisterStartupScript(this, this.GetType(), "CoverImageErrorScript", errorScript, true);

                clrtext();
            }
        }

        void clrtext()
        {
            changePass.Text = null;
            repass.Text = null;
        }
    }
}