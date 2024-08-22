using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace BharatBuys
{
    public partial class Search : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["User_id"] == null)
            {
                Response.Redirect("Login.aspx");
            }
            else
            {
                string userId = Session["User_id"].ToString();

                SqlConnection con = new SqlConnection("Server=sql.bsite.net\\MSSQL2016;Database=bharatbuys_db;User Id=bharatbuys_db;Password=Ganesh@123.;");
                    con.Open();
                    SqlCommand cmd = new SqlCommand(@"
                            SELECT TOP 12 *
                            FROM Product p
                            WHERE not Quantity=0 and  EXISTS (
                                SELECT 1
                                FROM user_search_history ush
                                WHERE ush.user_id = @UserEmail
                                  AND (p.ProductName LIKE '%' + ush.search + '%'
                                       OR p.Keywords LIKE '%' + ush.search + '%')
                            );", con);
                    cmd.Parameters.AddWithValue("@UserEmail", userId);
                    cmd.ExecuteNonQuery();
                    SqlDataReader rdr = cmd.ExecuteReader();
                    Repeater1.DataSource = rdr;
                    Repeater1.DataBind();
                    /*                
                        SqlDataAdapter adapter = new SqlDataAdapter();
                        DataSet dataSet = new DataSet();
                        adapter.Fill(dataSet);
                   */
                
            }
        }

        protected void Search_Prod(object sender, EventArgs e)
        {
            try
            {

                SqlConnection con = new SqlConnection("Server=sql.bsite.net\\MSSQL2016;Database=bharatbuys_db;User Id=bharatbuys_db;Password=Ganesh@123.;");
                con.Open();
                SqlCommand cmd = new SqlCommand("select * from product where ProductName LIKE '%' + @search + '%' or ProductName LIKE '%' + @search + '%'", con);
                cmd.Parameters.AddWithValue("@search", Search_Item.Text);
                cmd.ExecuteNonQuery();
                SqlDataReader rdr = cmd.ExecuteReader();
                Repeater1.DataSource = rdr;
                Repeater1.DataBind();
                /**/


                searchtable();
            }
            catch
            {
                // Show error if no cover image is selected
                string errorScript = "alert('error occured');";
                ScriptManager.RegisterStartupScript(this, this.GetType(), "CoverImageErrorScript", errorScript, true);
            }
        }

        public void searchtable()
        {
            SqlConnection con = new SqlConnection("Server=sql.bsite.net\\MSSQL2016;Database=bharatbuys_db;User Id=bharatbuys_db;Password=Ganesh@123.;");
            con.Open(); 
            string userId = Session["User_id"].ToString();
            SqlCommand enter = new SqlCommand("insert into user_search_history values (@username,@search)", con);
            enter.Parameters.AddWithValue("@username", userId);
            enter.Parameters.AddWithValue("@search", Search_Item.Text);
            enter.ExecuteNonQuery();
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
    }
}