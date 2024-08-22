using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace BharatBuys
{
    public partial class Order : System.Web.UI.Page
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


                    if (!usersearch(userId))
                    {
                        Label1.Text = "Make Purchase";

                    }
                    else
                    {
                        SqlConnection con = new SqlConnection("Server=sql.bsite.net\\MSSQL2016;Database=bharatbuys_db;User Id=bharatbuys_db;Password=Ganesh@123.;");
                        con.Open();                       
                        SqlCommand cmd = new SqlCommand("select * from OrderBB where BuyerID=@BuyerID",con);
                        cmd.Parameters.AddWithValue("@BuyerID", userId);
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

             }
             catch
             {
                 // Show error if no cover image is selected
                 string errorScript = "alert('error occured');";
                 ScriptManager.RegisterStartupScript(this, this.GetType(), "CoverImageErrorScript", errorScript, true);
             }
        }

        public bool usersearch(string email)
        {
            SqlConnection con = new SqlConnection("Server=sql.bsite.net\\MSSQL2016;Database=bharatbuys_db;User Id=bharatbuys_db;Password=Ganesh@123.;");

            // Check if the email already exists in the database
            SqlCommand cmd = new SqlCommand("SELECT COUNT(*) FROM OrderBB WHERE BuyerID = @User_id", con);
            cmd.Parameters.AddWithValue("@User_id", email);

            con.Open();
            int count = (int)cmd.ExecuteScalar();
            con.Close();

            return count > 0;

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