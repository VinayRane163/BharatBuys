using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace BharatBuys
{
    public partial class Delete_Product : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
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



        protected void DeleteProducts_Click(object sender, EventArgs e)
        {
            string ProductID = Request.QueryString["ProductID"].ToString(); ;


            SqlConnection con = new SqlConnection("Server=sql.bsite.net\\MSSQL2016;Database=bharatbuys_db;User Id=bharatbuys_db;Password=Ganesh@123.;");
            con.Open();
            SqlCommand cmd = new SqlCommand("Delete * from Product where ProductID=@ProductID", con);
            cmd.Parameters.AddWithValue("@ProductID", ProductID);
            cmd.ExecuteNonQuery();

            string successScript = "if (confirm('Product deleted redirecting to Your Products page')) { window.location.href = 'Your_Products.aspx'; } else { setTimeout(function(){ window.location.href = 'Your_Products.aspx'; }, 3000); };";
            ScriptManager.RegisterStartupScript(this, this.GetType(), "RegistrationSuccessScript", successScript, true);
        }
    }
}