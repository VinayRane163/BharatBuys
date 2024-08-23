using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Net.Mail;
using System.Net;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace BharatBuys
{
    public partial class Forgetpassword : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        
        protected void MailPassword_Click(object sender, EventArgs e)
        {
            if(string.IsNullOrEmpty(Uname.Text)){
                string errorScript = "alert('Please enter email id ');";
                ScriptManager.RegisterStartupScript(this, this.GetType(), "CoverImageErrorScript", errorScript, true);


            }
            else {
                try
                {
                    string email = Uname.Text;
                    string password;

                    SqlConnection con = new SqlConnection("Server=sql.bsite.net\\MSSQL2016;Database=bharatbuys_db;User Id=bharatbuys_db;Password=Ganesh@123.;");
                    con.Open();
                    SqlCommand cmd = new SqlCommand("select * from UserInfo where User_Name=@User_Name", con);
                    cmd.Parameters.AddWithValue("@User_Name", email);
                    SqlDataReader reader = cmd.ExecuteReader();
                    if (reader.Read())
                    {
                        password = reader["User_Password"].ToString();
                        SendResetEmail(email, email, password);
                    }
                    reader.Close();
                    con.Close();
                }
                catch (Exception ex)
                {
                    string errorScript = "alert('Error Occured !!! Please Retry after 30 second');";
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "CoverImageErrorScript", errorScript, true);

                }
            }

        }

        private void SendResetEmail(string email, string username, string Password)
        {
            try
            {
                // Gmail SMTP configuration
                string smtpHost = "smtp.gmail.com";
                int smtpPort = 587;
                string smtpUsername = "exploremumbai69@gmail.com";
                string smtpPassword = "svrc qelk zbvx nxle";

                // Email content
                string subject = "Password Recover - BharatBuys";
                string body = $"Dear {username},\n\nYour password is : {Password}\n\nPlease change your password after logging in.\n\nSincerely,\nBharatBuys";

                using (SmtpClient smtpClient = new SmtpClient(smtpHost, smtpPort))
                {
                    smtpClient.EnableSsl = true;
                    smtpClient.UseDefaultCredentials = false;
                    smtpClient.Credentials = new NetworkCredential(smtpUsername, smtpPassword);

                    using (MailMessage mailMessage = new MailMessage())
                    {
                        mailMessage.From = new MailAddress(smtpUsername);
                        mailMessage.To.Add(email);
                        mailMessage.Subject = subject;
                        mailMessage.Body = body;

                        smtpClient.Send(mailMessage);
                    }

                    string errorScript = "alert('Password reset email sent successfully to your email');";
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "CoverImageErrorScript", errorScript, true);

                }
            }
            catch (Exception ex)
            {
                string errorScript = "alert('Error Occured !!! Please Retry after 30 second');";
                ScriptManager.RegisterStartupScript(this, this.GetType(), "CoverImageErrorScript", errorScript, true);

            }
        }


    }
}