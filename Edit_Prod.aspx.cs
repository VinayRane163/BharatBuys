using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace BharatBuys
{
    public partial class Edit_Prod : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (!IsPostBack)
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
                        if (rdr.Read())
                        {
                            Quantity.Text = rdr["Quantity"].ToString();
                            Keywords.Text = rdr["Keywords"].ToString();
                            ProductDescription.Text = rdr["ProductDescription"].ToString();
                            ProductPrice.Text = rdr["ProductPrice"].ToString();
                            ProductName.Text = rdr["ProductName"].ToString();
                        }
                    }
                    else
                    {
                        string errorScript = "alert('Error Occured Plese go gack to home');";
                        ScriptManager.RegisterStartupScript(this, this.GetType(), "CoverImageErrorScript", errorScript, true);
                    }
                }
            }
            catch {
                string errorScript = "alert('error');";
                ScriptManager.RegisterStartupScript(this, this.GetType(), "CoverImageErrorScript", errorScript, true);
                return;
            }   
        }

        protected void UpdateProducts_Click(object sender, EventArgs e)
        {
            int q = Convert.ToInt32(Quantity.Text);
            int p = Convert.ToInt32(ProductPrice.Text);
            if (q <= 0 || p <= 0)
            {
                string successScript = "alert('quantity cant negative.');";
                ScriptManager.RegisterStartupScript(this, this.GetType(), "CoverImageSuccessScript", successScript, true);
                return;
            }
            if (string.IsNullOrEmpty(ProductPrice.Text) || string.IsNullOrEmpty(ProductName.Text) || string.IsNullOrEmpty(ProductDescription.Text) || string.IsNullOrEmpty(Quantity.Text) || string.IsNullOrEmpty(Keywords.Text))
            {
                string successScript = "alert('fill all details.');";
                ScriptManager.RegisterStartupScript(this, this.GetType(), "CoverImageSuccessScript", successScript, true);
                return;
            }
            else
            {
                string ProductID = Request.QueryString["ProductID"].ToString(); ;


                SqlConnection con = new SqlConnection("Server=sql.bsite.net\\MSSQL2016;Database=bharatbuys_db;User Id=bharatbuys_db;Password=Ganesh@123.;");
                con.Open();
                SqlCommand cmd = new SqlCommand("Update Product set ProductName=@ProductName,ProductPrice=@ProductPrice,ProductDescription=@ProductDescription,Keywords=@Keywords,Quantity=@Quantity  where ProductID=@ProductID", con);
                cmd.Parameters.AddWithValue("@ProductID", ProductID);
                cmd.Parameters.AddWithValue("@ProductName", ProductName.Text);
                cmd.Parameters.AddWithValue("@ProductPrice", ProductPrice.Text);
                cmd.Parameters.AddWithValue("@ProductDescription", ProductDescription.Text);
                cmd.Parameters.AddWithValue("@Keywords", Keywords.Text);
                cmd.Parameters.AddWithValue("@Quantity", Quantity.Text);

                cmd.ExecuteNonQuery();


                string successScript = "if (confirm('Product info Updated redirecting to Your Products page')) { window.location.href = 'Your_Products.aspx'; } else { setTimeout(function(){ window.location.href = 'Your_Products.aspx'; }, 3000); };";
                ScriptManager.RegisterStartupScript(this, this.GetType(), "RegistrationSuccessScript", successScript, true);
            }
        }
    }
}
/* Keywords
                     ProductDescription
                     ProductPrice
                     ProductName;*/