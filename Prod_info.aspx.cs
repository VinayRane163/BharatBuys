using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace BharatBuys
{
    public partial class Prod_info : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            cartcheck();
            if (Request.QueryString["ProductID"] != null)
            {
                // Get the ProductID from the query string
                string ProductID = Request.QueryString["ProductID"].ToString(); ;


                SqlConnection con = new SqlConnection("Server=sql.bsite.net\\MSSQL2016;Database=bharatbuys_db;User Id=bharatbuys_db;Password=Ganesh@123.;");
                con.Open();
                SqlCommand cmd = new SqlCommand("select * from Product where ProductID=@ProductID", con);
                cmd.Parameters.AddWithValue("@ProductID", ProductID);
                cmd.ExecuteNonQuery();
                SqlDataReader rdr = cmd.ExecuteReader();
                Repeater1.DataSource = rdr;
                Repeater1.DataBind();
            }
            else
            {
                string errorScript = "alert('Error Occured Plese go gack to home');";
                ScriptManager.RegisterStartupScript(this, this.GetType(), "CoverImageErrorScript", errorScript, true);
            }

        }
        protected string GetBase64Image(object imageData)
        {
            if (imageData != DBNull.Value)
            {
                byte[] bytes = (byte[])imageData;
                return Convert.ToBase64String(bytes, 0, bytes.Length);
            }
            return string.Empty;
        }

        protected void AddtoCart_Click(object sender, EventArgs e)
        {
            string ProductID = Request.QueryString["ProductID"].ToString();
            string userId = Session["User_id"].ToString();

            SqlConnection con = new SqlConnection("Server=sql.bsite.net\\MSSQL2016;Database=bharatbuys_db;User Id=bharatbuys_db;Password=Ganesh@123.;");
            con.Open();
            SqlCommand cmd = new SqlCommand("insert into usercart values (@username,@ProductID)", con);
            cmd.Parameters.AddWithValue("@ProductID", ProductID);
            cmd.Parameters.AddWithValue("@username", userId);
            cmd.ExecuteNonQuery();

            cartcheck();
            string errorScript = "alert('Item added to cart');";
            ScriptManager.RegisterStartupScript(this, this.GetType(), "CoverImageErrorScript", errorScript, true);
        }

        protected void RemovefromCart_Click(object sender, EventArgs e)
        {
            string ProductID = Request.QueryString["ProductID"].ToString();
            string userId = Session["User_id"].ToString();

            SqlConnection con = new SqlConnection("Server=sql.bsite.net\\MSSQL2016;Database=bharatbuys_db;User Id=bharatbuys_db;Password=Ganesh@123.;");
            con.Open();
            SqlCommand cmd = new SqlCommand("DELETE FROM usercart WHERE product_id = @ProductID AND username = @username", con);
            cmd.Parameters.AddWithValue("@ProductID", ProductID);
            cmd.Parameters.AddWithValue("@username", userId);
            cmd.ExecuteNonQuery();

            cartcheck();

            string errorScript = "alert('Item removed from cart');";
            ScriptManager.RegisterStartupScript(this, this.GetType(), "CoverImageErrorScript", errorScript, true);
        }

        protected void Back_Click(object sender, EventArgs e)
        {
            Response.Redirect("Default.aspx");
        }

        public void cartcheck()
        {
            string ProductID = Request.QueryString["ProductID"].ToString();
            string userId = Session["User_id"].ToString();

            SqlConnection con = new SqlConnection("Server=sql.bsite.net\\MSSQL2016;Database=bharatbuys_db;User Id=bharatbuys_db;Password=Ganesh@123.;");
            con.Open();
            SqlCommand cmd = new SqlCommand("select product_id,username from usercart where product_id=@ProductID and username=@username", con);
            cmd.Parameters.AddWithValue("@ProductID", ProductID);
            cmd.Parameters.AddWithValue("@username", userId);
            cmd.ExecuteNonQuery();
            SqlDataReader rdr = cmd.ExecuteReader();
            if (rdr.Read())
            {
                AddtoCart.Visible = false;
                AddtoCart.Enabled = false;
                RemovefromCart.Visible = true;
                RemovefromCart.Enabled = true;
            }
            else
            {
                AddtoCart.Visible = true;
                AddtoCart.Enabled = true;
                RemovefromCart.Visible = false;
                RemovefromCart.Enabled = false;
            }
        }
    }
}