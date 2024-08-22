using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace BharatBuys
{
    public partial class Signup : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        SqlConnection conn = new SqlConnection("Server=sql.bsite.net\\MSSQL2016;Database=bharatbuys_db;User Id=bharatbuys_db;Password=Ganesh@123.");

        protected void SignUP_Click(object sender, EventArgs e)
        {
            string numb = Mob.Text;
            if ((CheckBox1.Checked != true) || (CheckBox2.Checked != true))
            {
                string script = "alert('select all check box');";
                ScriptManager.RegisterStartupScript(this, this.GetType(), "EmailExistsScript", script, true);

                return;
            }
            if (numb.Length != 10)
            {
                string script = "alert('Indian Number Consist 10 digits.');";
                ScriptManager.RegisterStartupScript(this, this.GetType(), "EmailExistsScript", script, true);
                return;
            }

            if (string.IsNullOrWhiteSpace(Uname.Text) || string.IsNullOrWhiteSpace(Mob.Text) || string.IsNullOrWhiteSpace(Pass.Text))
            {
                return;
            }
            if (IsEmailAlreadyExists(Uname.Text))
            {
                // Email already exists, show an error message
                string script = "alert('Email address is already in use. Please choose a different one.');";
                ScriptManager.RegisterStartupScript(this, this.GetType(), "EmailExistsScript", script, true);
                return;
            }
            if (IsNumberAlreadyExists(Mob.Text))
            {
                string script = "alert('number is already in use. Please choose a different one.');";
                ScriptManager.RegisterStartupScript(this, this.GetType(), "EmailExistsScript", script, true);
                return;
            }
            else
            {


                SqlCommand cmd = new SqlCommand("insert into userinfo (User_Name,User_Password,User_Mobile) values (@uname,@upass,@umob)", conn);
                cmd.Parameters.AddWithValue("@uname", Uname.Text);
                cmd.Parameters.AddWithValue("@upass", Pass.Text);
                cmd.Parameters.AddWithValue("@umob", Mob.Text);
                conn.Open();
                cmd.ExecuteNonQuery();
                conn.Close();

                string script = "alert('registeration succesful');";
                ScriptManager.RegisterStartupScript(this, this.GetType(), "EmailExistsScript", script, true);

                cleartxt();
                Response.Redirect("login.aspx");

            }
        }

        void cleartxt()
        {
            Mob.Text = "";
            Uname.Text = "";
            Pass.Text = "";

        }
        private bool IsEmailAlreadyExists(string email)
        {
            // Check if the email already exists in the database
            SqlCommand cmd = new SqlCommand("SELECT COUNT(*) FROM UserInfo WHERE User_Name = @User_id", conn);
            cmd.Parameters.AddWithValue("@User_id", email);

            conn.Open();
            int count = (int)cmd.ExecuteScalar();
            conn.Close();

            return count > 0;
        }
        private bool IsNumberAlreadyExists(string number)
        {
            // Check if the email already exists in the database
            SqlCommand cmd = new SqlCommand("SELECT COUNT(*) FROM UserInfo WHERE User_Mobile = @number", conn);
            cmd.Parameters.AddWithValue("@number", number);

            conn.Open();
            int count = (int)cmd.ExecuteScalar();
            conn.Close();

            return count > 0;
        }
    }
}