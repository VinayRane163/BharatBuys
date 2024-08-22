using System;
using System.Data.SqlClient;
using System.Web.UI;

namespace BharatBuys
{
    public partial class Register_seller : System.Web.UI.Page
    {
        SqlConnection conn = new SqlConnection("Server = sql.bsite.net\\MSSQL2016; Database = bharatbuys_db; User Id = bharatbuys_db; Password = Ganesh@123.;");

        protected void Page_Load(object sender, EventArgs e)
        {
            string userId = Session["User_id"].ToString();
            conn.Open();
            SqlCommand cmd = new SqlCommand("select User_Name,User_Mobile from UserInfo where User_Name=@User_Name", conn);
            cmd.Parameters.AddWithValue("User_Name", userId);
            SqlDataReader reader = cmd.ExecuteReader();
            if (reader.Read())
            {
                email.Text = reader["User_Name"].ToString();
                phonenumber.Text = reader["User_Mobile"].ToString();

                email.Enabled = false;
                phonenumber.Enabled = false;
            }
            conn.Close();

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            string pan = Pancard.Text.ToUpper();
            if (pan.Length != 10)
            {
                string errorScript = "alert('Pancard in wrong format.');";
                ScriptManager.RegisterStartupScript(this, this.GetType(), "Error", errorScript, true);
            }
            string adhar = Adharcard.Text;
            if (adhar.Length != 12)
            {

                string errorScript = "alert('Pancard in wrong format.');";
                ScriptManager.RegisterStartupScript(this, this.GetType(), "Error", errorScript, true);
                return;
            }
            if (IsEmailAlreadyExists(email.Text))
            {
                string script = "alert('already registereed user.');";
                ScriptManager.RegisterStartupScript(this, this.GetType(), "EmailExistsScript", script, true);
                return;
            }
            if (String.IsNullOrEmpty(FullName.Text)||String.IsNullOrEmpty(Adharcard.Text) || String.IsNullOrEmpty(Pancard.Text) || String.IsNullOrEmpty(Address.Text))
            {
                string errorScript = "alert('All information is necessary.');";
                ScriptManager.RegisterStartupScript(this, this.GetType(), "Error", errorScript, true);
                return ;
            }
            else
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand("insert into Seller values (@fname,@email,@phone,@pan,@adhar,@address)",conn);
                cmd.Parameters.AddWithValue("@fname",FullName.Text);
                cmd.Parameters.AddWithValue("@email",email.Text);
                cmd.Parameters.AddWithValue("@phone",phonenumber.Text);
                cmd.Parameters.AddWithValue("@pan",pan);
                cmd.Parameters.AddWithValue("@adhar",adhar);
                cmd.Parameters.AddWithValue("@address",Address.Text);
                cmd.ExecuteNonQuery();
                conn.Close();

                string successScript = "if (confirm('You have successfully Registered as Seller')) { window.location.href = 'Setting.aspx'; } else { setTimeout(function(){ window.location.href = 'Setting.aspx'; }, 3000); };";
                ScriptManager.RegisterStartupScript(this, this.GetType(), "RegistrationSuccessScript", successScript, true);
            }
        }

        private bool IsEmailAlreadyExists(string email)
        {
            // Check if the email already exists in the database
            SqlCommand cmd = new SqlCommand("SELECT COUNT(*) FROM Seller WHERE Email_Id = @User_id", conn);
            cmd.Parameters.AddWithValue("@User_id", email);

            conn.Open();
            int count = (int)cmd.ExecuteScalar();
            conn.Close();

            return count > 0;
        }

        protected void Back_Click(object sender, EventArgs e)
        {
            Response.Redirect("Default.aspx1");
        }
    }
}