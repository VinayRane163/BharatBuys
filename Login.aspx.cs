using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace BharatBuys
{
    public partial class Login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void LoginBtn_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(Uname.Text) || string.IsNullOrWhiteSpace(Pass.Text))
            {
                Label1.Text = "enter username and password";
                return;
            }
            else
            {
                SqlConnection conn = new SqlConnection("Server=sql.bsite.net\\MSSQL2016;Database=bharatbuys_db;User Id=bharatbuys_db;Password=Ganesh@123.;");
                SqlCommand cmd = new SqlCommand("select * from UserInfo where User_Name=@User_id and User_Password=@User_password", conn);
                cmd.Parameters.AddWithValue("@User_id", Uname.Text);
                cmd.Parameters.AddWithValue("@User_password", Pass.Text);

                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataSet ds = new DataSet();
                da.Fill(ds, "UserInfo");

                if (ds.Tables["UserInfo"].Rows.Count == 0)
                {
                    string errorScript = "alert('Invalid User or Password.');";
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "CoverImageErrorScript", errorScript, true);

                }
                else
                {
                    Session["session_id"] = Session.SessionID;
                    Session["User_id"] = Uname.Text;
                    Response.Redirect("Default.aspx");


                }
            }
        }
    }
}