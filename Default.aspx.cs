using System;
using System.Data.SqlClient;
using System.Web.UI;

namespace BharatBuys
{
    public partial class Default : System.Web.UI.Page
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
                        Label1.Text = "Search To Get Suggestions";

                    }
                    else
                    {
                        Label2.Text = "Recommendations on your previous search";
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
            SqlCommand cmd = new SqlCommand("SELECT COUNT(*) FROM user_search_history WHERE user_id = @User_id", con);
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