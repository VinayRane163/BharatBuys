using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Net.Mail;
using System.Net;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace BharatBuys
{
    public partial class Buy : System.Web.UI.Page
    {

        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
               
                    if (Request.QueryString["ProductID"] != null)
                    {
                        string ProductID = Request.QueryString["ProductID"].ToString(); ;


                        SqlConnection con = new SqlConnection("Server=sql.bsite.net\\MSSQL2016;Database=bharatbuys_db;User Id=bharatbuys_db;Password=Ganesh@123.;");
                        con.Open();
                        SqlCommand cmd = new SqlCommand("select * from Product where ProductID=@ProductID", con);
                        cmd.Parameters.AddWithValue("@ProductID", ProductID);
                        cmd.ExecuteNonQuery();
                        SqlDataReader rdr = cmd.ExecuteReader();
                        if (rdr.Read())
                        {
                            ItemName.Text = rdr["ProductName"].ToString();
                            ItemPrice.Text = rdr["ProductPrice"].ToString();
                        }
                        /*
                                        if (q < 0)
                                        {
                                            string successScript = "alert('quantity cant negative.');";
                                            ScriptManager.RegisterStartupScript(this, this.GetType(), "CoverImageSuccessScript", successScript, true);
                                            return;
                                        }*/
                        usernumber();
                    }
                
                else
                {

                    Response.Redirect("Default.aspx");
                }
            }
            catch
            {
                string errorScript = "alert('error');";
                ScriptManager.RegisterStartupScript(this, this.GetType(), "CoverImageErrorScript", errorScript, true);
                return;
            }
        }

        public void usernumber()
        {
            string userId = Session["User_id"].ToString();

            SqlConnection con = new SqlConnection("Server=sql.bsite.net\\MSSQL2016;Database=bharatbuys_db;User Id=bharatbuys_db;Password=Ganesh@123.;");
            con.Open();
            SqlCommand cmd = new SqlCommand("select * from UserInfo where User_Name=@UserName", con);
            cmd.Parameters.AddWithValue("@UserName", userId);
            cmd.ExecuteNonQuery();
            SqlDataReader rdr = cmd.ExecuteReader();
            if (rdr.Read())
            {
               MobileNumber.Text = rdr["User_Mobile"].ToString();
            }
        }
        protected void Buy_order_Click(object sender, EventArgs e)
        {

                if(!checkquantity())
                { 
                    return; 
                }                                  
                if (CheckBox1.Checked == false)
                {
                    string errorScript = "alert('Select order type');";
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "CoverImageErrorScript", errorScript, true);
                    return;
                }
                if (String.IsNullOrEmpty(YourName.Text) || String.IsNullOrEmpty(Quantity.Text) || String.IsNullOrEmpty(Address.Text))
                {
                    string errorScript = "alert('Fill All Data');";
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "CoverImageErrorScript", errorScript, true);
                    return;
                }
                else
                {
                    SqlConnection con = new SqlConnection("Server=sql.bsite.net\\MSSQL2016;Database=bharatbuys_db;User Id=bharatbuys_db;Password=Ganesh@123.;");
                    string userId = Session["User_id"].ToString();
                    string ProductID = Request.QueryString["ProductID"].ToString(); ;
                /*  object quantity = null;

                  con.Open();

                  SqlCommand cmd = new SqlCommand("select Quantity from Product where ProductID=@ProductID", con);
                  cmd.Parameters.AddWithValue("@ProductID", ProductID);
                  cmd.ExecuteNonQuery();
                  SqlDataReader rdr = cmd.ExecuteReader();
                  if (rdr.Read())
                  {
                      quantity = rdr["Quantity"].ToString();
                  }
                  rdr.Close();
                  con.Close();
                  *//**//*
                  int q = Convert.ToInt32(quantity);
                  int uq = Convert.ToInt32(Quantity.Text);
                  int total = q - uq;*/

                int p, q, t;
                p= Convert.ToInt32(ItemPrice.Text); 
                q= Convert.ToInt32(Quantity.Text);
                t = p * q;


                con.Open();
                    SqlCommand enter = new SqlCommand("insert into OrderBB values (@ProductID,@ProductName,@ProductPrice,@Quantity,@Total_Price,@BuyerID,@BuyerName,@BuyerPhone,@BuyerAddress,@OrderType,@Date)", con);
                    enter.Parameters.AddWithValue("@ProductID", ProductID);
                    enter.Parameters.AddWithValue("@ProductName", ItemName.Text);
                    enter.Parameters.AddWithValue("@ProductPrice", ItemPrice.Text);
                    enter.Parameters.AddWithValue("@Quantity", Quantity.Text);
                    enter.Parameters.AddWithValue("@Total_Price", t.ToString());
                    enter.Parameters.AddWithValue("@BuyerID", userId);
                    enter.Parameters.AddWithValue("@BuyerName", YourName.Text);
                    enter.Parameters.AddWithValue("@BuyerPhone", MobileNumber.Text);
                    enter.Parameters.AddWithValue("@BuyerAddress", Address.Text);
                    enter.Parameters.AddWithValue("@OrderType", CheckBox1.Text);
                    enter.Parameters.AddWithValue("@Date", DateTime.Now.ToString("dd-MM-yyyy"));

                    enter.ExecuteNonQuery();
                    con.Close();

                    getquantity();
                SendProductEmail(userId, ProductID, ItemName.Text, ItemPrice.Text, Quantity.Text, t.ToString(), userId, YourName.Text, MobileNumber.Text, Address.Text, CheckBox1.Text, DateTime.Now.ToString("dd-MM-yyyy"));


                string successScript = "if (confirm('You have successfully placed order. invoice send to mail.')) { window.location.href = 'Default.aspx'; } else { setTimeout(function(){ window.location.href = 'Default.aspx'; }, 5000); };";
                ScriptManager.RegisterStartupScript(this, this.GetType(), "RegistrationSuccessScript", successScript, true);
                /**//*
                con.Open();
                SqlCommand update = new SqlCommand("UPDATE Product SET Quantity = @Quantity WHERE ProductID = @ProductID", con);
                update.Parameters.AddWithValue("@ProductID", ProductID);
                update.Parameters.AddWithValue("@Quantity", total.ToString());
                update.ExecuteNonQuery();
                con.Close();
*/
            }
            
          
        }

        public void getquantity()
        {
            SqlConnection con = new SqlConnection("Server=sql.bsite.net\\MSSQL2016;Database=bharatbuys_db;User Id=bharatbuys_db;Password=Ganesh@123.;");
            string ProductID = Request.QueryString["ProductID"].ToString(); ;
            object quantity = null;

            con.Open();

            SqlCommand cmd = new SqlCommand("select Quantity from Product where ProductID=@ProductID", con);
            cmd.Parameters.AddWithValue("@ProductID", ProductID);
            cmd.ExecuteNonQuery();
            SqlDataReader rdr = cmd.ExecuteReader();
            if (rdr.Read())
            {
                quantity = rdr["Quantity"].ToString();
            }
            
            /**/
            int q = Convert.ToInt32(quantity);
            int uq = Convert.ToInt32(Quantity.Text);
            int total = q - uq;
            updatequantity(total);
        }

        public void updatequantity(int total)
        {
            try
            {
                SqlConnection con = new SqlConnection("Server=sql.bsite.net\\MSSQL2016;Database=bharatbuys_db;User Id=bharatbuys_db;Password=Ganesh@123.;");
                string ProductID = Request.QueryString["ProductID"].ToString(); ;

                con.Open();
                SqlCommand update = new SqlCommand("UPDATE Product SET Quantity = @Quantity WHERE ProductID = @ProductID", con);
                update.Parameters.AddWithValue("@ProductID", ProductID);
                update.Parameters.AddWithValue("@Quantity", total.ToString());
                update.ExecuteNonQuery();
                con.Close();
            }
            catch (Exception ex)
            {
                string errorScript = "alert('Error');";
                ScriptManager.RegisterStartupScript(this, this.GetType(), "CoverImageErrorScript", errorScript, true);
                return;
            }


        }

        public bool checkquantity()
        {
            string ProductID = Request.QueryString["ProductID"].ToString(); 

            SqlConnection con = new SqlConnection("Server=sql.bsite.net\\MSSQL2016;Database=bharatbuys_db;User Id=bharatbuys_db;Password=Ganesh@123.;");
            con.Open();
            SqlCommand cmd = new SqlCommand("select Quantity from Product where ProductID=@ProductID", con);
            cmd.Parameters.AddWithValue("@ProductID", ProductID);
            cmd.ExecuteNonQuery();
            SqlDataReader rdr = cmd.ExecuteReader();
            if (rdr.Read())
            {
                int quantity = Convert.ToInt32(rdr["Quantity"].ToString());
                int userquantity = Convert.ToInt32(Quantity.Text);
                int total = quantity - userquantity;
                if (total < 0)
                {
                    string errorScript = "alert('YOU TOOK MORE QUANTITY THAN SELLER CAN SELL');";
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "CoverImageErrorScript", errorScript, true);
                    return false;
                }

                if (userquantity <= 0) 
                {
                    string errorScript = "alert('Atleast take 1 quantity');";
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "CoverImageErrorScript", errorScript, true);
                    return false;
                }

            }
            return true;
        }
           
       

        protected void Back_Click(object sender, EventArgs e)
        {
            Response.Redirect("DEFAULT.ASPX");
        }

        protected void Quantity_TextChanged(object sender, EventArgs e)
        {
            calculate_TP();

        }

        protected void calculate_Click(object sender, EventArgs e)
        {
            calculate_TP();
        }

        public void calculate_TP()
        {
            int price_Product = Convert.ToInt32(ItemPrice.Text);
            int quantity_Product = Convert.ToInt32(Quantity.Text);
            int total_price_Product = price_Product * quantity_Product;
            Total_Price.Text = total_price_Product.ToString();
        }



        private void SendProductEmail(
    string email,
    string ProductID,
    string ItemName,
    string ItemPrice,
    string Quantity,
    string TotalPrice,
    string BuyerID,
    string BuyerName,
    string BuyerPhone,
    string BuyerAddress,
    string OrderType,
    string Date)
        {
            try
            {
                // Gmail SMTP configuration
                string smtpHost = "smtp.gmail.com";
                int smtpPort = 587;
                string smtpUsername = "exploremumbai69@gmail.com";
                string smtpPassword = "svrc qelk zbvx nxle";

                // Email content
                string subject = "Order Receipt - BharatBuys";
                string body = $@"
                    <html>
                        <body style='font-family: Arial, sans-serif;'>
                            <p>Dear {BuyerName},</p>
                            <p>Thank you for your order with BharatBuys! Here is your order receipt:</p>
                            <table style='border: 1px solid #dddddd; border-collapse: collapse; width: 100%; margin-top: 20px;'>
                                <tr>
                                    <td style='border: 1px solid #dddddd; padding: 8px;'><strong>Product ID:</strong></td>
                                    <td style='border: 1px solid #dddddd; padding: 8px;'>{ProductID}</td>
                                </tr>
                                <tr>
                                    <td style='border: 1px solid #dddddd; padding: 8px;'><strong>Product Name:</strong></td>
                                    <td style='border: 1px solid #dddddd; padding: 8px;'>{ItemName}</td>
                                </tr>
                                <tr>
                                    <td style='border: 1px solid #dddddd; padding: 8px;'><strong>Product Price:</strong></td>
                                    <td style='border: 1px solid #dddddd; padding: 8px;'>₹{ItemPrice}</td>
                                </tr>
                                <tr>
                                    <td style='border: 1px solid #dddddd; padding: 8px;'><strong>Quantity:</strong></td>
                                    <td style='border: 1px solid #dddddd; padding: 8px;'>{Quantity}</td>
                                </tr>
                                <tr>
                                    <td style='border: 1px solid #dddddd; padding: 8px;'><strong>Total Price:</strong></td>
                                    <td style='border: 1px solid #dddddd; padding: 8px;'>₹{TotalPrice}</td>
                                </tr>
                                <tr>
                                    <td style='border: 1px solid #dddddd; padding: 8px;'><strong>Buyer ID:</strong></td>
                                    <td style='border: 1px solid #dddddd; padding: 8px;'>{BuyerID}</td>
                                </tr>
                                <tr>
                                    <td style='border: 1px solid #dddddd; padding: 8px;'><strong>Buyer Name:</strong></td>
                                    <td style='border: 1px solid #dddddd; padding: 8px;'>{BuyerName}</td>
                                </tr>
                                <tr>
                                    <td style='border: 1px solid #dddddd; padding: 8px;'><strong>Buyer Phone:</strong></td>
                                    <td style='border: 1px solid #dddddd; padding: 8px;'>{BuyerPhone}</td>
                                </tr>
                                <tr>
                                    <td style='border: 1px solid #dddddd; padding: 8px;'><strong>Buyer Address:</strong></td>
                                    <td style='border: 1px solid #dddddd; padding: 8px;'>{BuyerAddress}</td>
                                </tr>
                                <tr>
                                    <td style='border: 1px solid #dddddd; padding: 8px;'><strong>Order Type:</strong></td>
                                    <td style='border: 1px solid #dddddd; padding: 8px;'>{OrderType}</td>
                                </tr>
                                <tr>
                                    <td style='border: 1px solid #dddddd; padding: 8px;'><strong>Date:</strong></td>
                                    <td style='border: 1px solid #dddddd; padding: 8px;'>{Date}</td>
                                </tr>
                             </table>

                            <p style='margin-top: 20px;'>Thank you for shopping with BharatBuys! We hope to serve you again soon.</p>
                            <p>Sincerely,<br>BharatBuys Team</p>
                        </body>
                    </html>
                    ";

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
                        mailMessage.IsBodyHtml = true;

                        smtpClient.Send(mailMessage);
                    }
                }
            }
            catch {
                string errorScript = "alert('email sending error ');";
                ScriptManager.RegisterStartupScript(this, this.GetType(), "CoverImageErrorScript", errorScript, true);
            }
            
        }

    }
}