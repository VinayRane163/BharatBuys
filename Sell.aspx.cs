using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace BharatBuys
{
    public partial class Sell : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            // Check for user session
            if (Session["User_id"] == null)
            {
                // Redirect to login page if no user session is found
                Response.Redirect("Login.aspx");
            }
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            // Handle single cover image upload
            if (coverimage.HasFile)
            {
                string fileName = Path.GetFileName(coverimage.FileName);
                byte[] fileData = coverimage.FileBytes;
                SaveCoverImage(fileName, fileData);

                // Handle multiple detail images upload
                if (imageUpload.HasFiles)
                {
                    var files = imageUpload.PostedFiles;
                    SaveDetailImages(files);
                }

                string successScript = "if (confirm('You have successfully Registered your')) { window.location.href = 'Default.aspx'; } else { setTimeout(function(){ window.location.href = 'Default.aspx'; }, 3000); };";
                ScriptManager.RegisterStartupScript(this, this.GetType(), "RegistrationSuccessScript", successScript, true);
            }
            else
            {
                // Show error if no cover image is selected
                string errorScript = "alert('Please select a cover image.');";
                ScriptManager.RegisterStartupScript(this, this.GetType(), "CoverImageErrorScript", errorScript, true);
            }
        }

        private byte[] GetFileBytes(HttpPostedFile file)
        {
            using (var binaryReader = new BinaryReader(file.InputStream))
            {
                return binaryReader.ReadBytes(file.ContentLength);
            }
        }

        private void SaveCoverImage(string fileName, byte[] fileData)
        {
            string connectionString = "Server=sql.bsite.net\\MSSQL2016;Database=bharatbuys_db;User Id=bharatbuys_db;Password=Ganesh@123.";
            int q= Convert.ToInt32(Quantity.Text);
            int p= Convert.ToInt32(ItemPrice.Text);
            if(q<=0 || p<=0)
            {
                string successScript = "alert('quantity cant negative.');";
                ScriptManager.RegisterStartupScript(this, this.GetType(), "CoverImageSuccessScript", successScript, true);
                return;
            }
            if (string.IsNullOrEmpty(ItemName.Text) || string.IsNullOrEmpty(ItemPrice.Text) || string.IsNullOrEmpty(ItemTags.Text) || string.IsNullOrEmpty(Quantity.Text) || string.IsNullOrEmpty(ItemDescription.Text))
            {
                string successScript = "alert('fill all details.');";
                ScriptManager.RegisterStartupScript(this, this.GetType(), "CoverImageSuccessScript", successScript, true);
                return;
            }
            else
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    string query = "INSERT INTO Product (UserID,ProductName, ProductPrice, ProductDescription,Keywords,Quantity, Cover_Image) " +
                                   "VALUES (@UserID,@ProductName, @ProductPrice, @ProductDescription,@Keywords,@Quantity, @Cover_Image)";
                    string userId = Session["User_id"].ToString();

                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@UserID", userId);
                        cmd.Parameters.AddWithValue("@ProductName", ItemName.Text);
                        cmd.Parameters.AddWithValue("@ProductPrice", ItemPrice.Text);
                        cmd.Parameters.AddWithValue("@Keywords", ItemTags.Text);
                        cmd.Parameters.AddWithValue("@Quantity", Quantity.Text);
                        cmd.Parameters.AddWithValue("@ProductDescription", ItemDescription.Text);
                        cmd.Parameters.Add("@Cover_Image", SqlDbType.VarBinary).Value = fileData;

                        conn.Open();
                        cmd.ExecuteNonQuery();
                        conn.Close();

                        // Optionally, show success message after saving cover image
                        /*string successScript = "alert('Cover image successfully registered.');";
                        ScriptManager.RegisterStartupScript(this, this.GetType(), "CoverImageSuccessScript", successScript, true);*/
                    }
                }
            }
        }

        private void SaveDetailImages(IEnumerable<HttpPostedFile> files)
        {
            // Limit the number of files to 5
            try
            {
                var filesToSave = files.Take(5).ToList();

                // If there are no files to save, exit early
                if (!filesToSave.Any())
                {
                    return;
                }

                string connectionString = "Server=sql.bsite.net\\MSSQL2016;Database=bharatbuys_db;User Id=bharatbuys_db;Password=Ganesh@123.";

                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();

                    int imageIndex = 1;
                    foreach (HttpPostedFile uploadedFile in filesToSave)
                    {
                        // Only process up to 5 images
                        if (imageIndex > 5)
                            break;

                        string fileName = Path.GetFileName(uploadedFile.FileName);
                        byte[] fileData = GetFileBytes(uploadedFile);

                        string query = "UPDATE Product SET " +
                                       "Image" + imageIndex + " = @Image " +
                                       "WHERE ProductID = (SELECT MAX(ProductID) FROM Product)"; // Assuming the latest ProductID

                        using (SqlCommand cmd = new SqlCommand(query, conn))
                        {
                            cmd.Parameters.Add("@Image", SqlDbType.VarBinary).Value = fileData;
                            cmd.ExecuteNonQuery();
                        }

                        imageIndex++;
                    }

                    conn.Close();
                }

            }
            catch (Exception e)
            {

                // Show error if no cover image is selected
                string errorScript = "alert('Error.');";
                ScriptManager.RegisterStartupScript(this, this.GetType(), "CoverImageErrorScript", errorScript, true);
                return;
            }

        }

        protected void Back_Click(object sender, EventArgs e)
        {
            Response.Redirect("Default.aspx");
        }
    }
}
