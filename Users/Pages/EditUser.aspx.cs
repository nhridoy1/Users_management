using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Users.Pages
{
    public partial class EditUser : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Request.QueryString["UserId"] != null)
                {
                    Id.Value = Request.QueryString["UserId"];
                    LoadUserDetails(Convert.ToInt32(Id.Value));
                }
            }
        }

        private void LoadUserDetails(int userId)
        {
            SqlParameter[] parameters = { new SqlParameter("@UserId", userId) };
            DataTable dt = DatabaseHelper.ExecuteProcedureWithData("GetUserById", parameters);

            if (dt.Rows.Count > 0)
            {
                DataRow row = dt.Rows[0];
                txtFirstName.Text = row["FirstName"].ToString();
                txtLastName.Text = row["LastName"].ToString();
                txtEmail.Text = row["Email"].ToString();
                txtPhone.Text = row["Phone"].ToString();
            }
        }


        protected void btnUpdate_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(Id.Value) || !int.TryParse(Id.Value, out int userId))
            {
                Response.Write("<script>alert('Invalid User ID.');</script>");
                return;
            }

            string ImagePath = null;
            if (userImage.HasFile)
            {
                string fileExtension = Path.GetExtension(userImage.FileName).ToLower();
                if (fileExtension == ".jpg" || fileExtension == ".png" || fileExtension == ".jpeg")
                {
                    string fileName = Path.GetFileName(userImage.FileName);
                    ImagePath = "~/Images/" + fileName;
                    userImage.SaveAs(Server.MapPath(ImagePath));
                }
                else
                {
                    Response.Write("<script>alert('Please upload a valid image file (JPG, JPEG, PNG).')</script>");
                }
            }

            SqlParameter[] parameters =
            {
                new SqlParameter("@UserId", userId),
                new SqlParameter("@FirstName", string.IsNullOrEmpty(txtFirstName.Text.Trim()) ? (object)DBNull.Value : txtFirstName.Text.Trim()),
                new SqlParameter("@LastName", string.IsNullOrEmpty(txtLastName.Text.Trim()) ? (object)DBNull.Value : txtLastName.Text.Trim()),
                new SqlParameter("@Email", string.IsNullOrEmpty(txtEmail.Text.Trim()) ? (object)DBNull.Value : txtEmail.Text.Trim()),
                new SqlParameter("@Phone", string.IsNullOrEmpty(txtPhone.Text.Trim()) ? (object)DBNull.Value : txtPhone.Text.Trim()),
                new SqlParameter("@ImagePath", ImagePath ?? (object)DBNull.Value)
            };

            DatabaseHelper.ExecuteProcedure("UpdateUser", parameters);
            Response.Redirect("User.aspx");
        }
    }
}