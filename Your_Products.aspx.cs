using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace BharatBuys
{
    public partial class Your_Products : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {

                if (Session["User_id"] == null)
                {
                    Label1.Text = "Login to Start";
                }
                else
                {
                          string userId = Session["User_id"].ToString();                  
                  
                        SqlConnection con = new SqlConnection("Server=sql.bsite.net\\MSSQL2016;Database=bharatbuys_db;User Id=bharatbuys_db;Password=Ganesh@123.;");
                        con.Open();
                        SqlCommand cmd = new SqlCommand(@"SELECT  * FROM Product where UserID=@UserEmail", con);
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
            catch
            {
                // Show error if no cover image is selected
                string errorScript = "alert('error occured');";
                ScriptManager.RegisterStartupScript(this, this.GetType(), "CoverImageErrorScript", errorScript, true);
            }
        }
    }
}