using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace BharatBuys
{
    public partial class Setting : System.Web.UI.Page
    {
        SqlConnection conn = new SqlConnection("Server = sql.bsite.net\\MSSQL2016; Database = bharatbuys_db; User Id = bharatbuys_db; Password = Ganesh@123.;");

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["User_id"] == null)
            {
                Response.Redirect("Login.aspx");
            }
            else
            {
                string userId = Session["User_id"].ToString();
                seller(userId);
            }

        }

        public void seller(string userId)
        {
            try
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand("select Email_Id from Seller where Email_Id=@id",conn);
                cmd.Parameters.AddWithValue("@id",userId);
                SqlDataReader sqlDataReader = cmd.ExecuteReader();
                if (sqlDataReader.Read())
                {
                    AddProd.Visible = true; AddProd.Enabled = true;
                    Your_Products.Visible = true; Your_Products.Enabled = true;
                    Your_Product_Order.Visible = true; Your_Product_Order.Enabled = true;
                    Button1.Visible = false; Button1.Enabled = false;
                }
                else
                {
                    AddProd.Visible = false; AddProd.Enabled = false;
                    Your_Products.Visible = false; Your_Products.Enabled = false;
                    Your_Product_Order.Visible = false; Your_Product_Order.Enabled = false;
                    Button1.Visible = true; Button1.Enabled = true;
                }
                conn.Close();

                

            }
            catch(Exception e)
            {
                string errorScript = "alert('Error.');";
                ScriptManager.RegisterStartupScript(this, this.GetType(), "Error", errorScript, true);
            }
        }


        protected void RAS_Click(object sender, EventArgs e)
        {
            Response.Redirect("Register_seller.aspx");
        }

        protected void Add_Click(object sender, EventArgs e)
        {
            Response.Redirect("sell.aspx");
        }

        protected void Logout_Click(object sender, EventArgs e)
        {
            Session["session_id"] = null;
            Session["User_id"] = null;
            Response.Redirect("Default.aspx");
        }

        protected void Order_History_Click(object sender, EventArgs e)
        {
            Response.Redirect("order.aspx");
        }

        protected void Your_Products_Click(object sender, EventArgs e)
        {
            Response.Redirect("Your_Products.aspx");

        }

        protected void Your_Product_Order_Click(object sender, EventArgs e)
        {
            Response.Redirect("Your_Product_Orders.aspx");

        }

        protected void YOURACCOUNT_Click(object sender, EventArgs e)
        {
            Response.Redirect("your_account.aspx");
        }
    }
}