using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Users.Pages
{
    public partial class Register : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnAdd_Click(object sender, EventArgs e)
        {
            string firstName = txtFirstName.Text.Trim();
            string lastName = txtLastName.Text.Trim();
            string email = txtEmail.Text.Trim();
            string phone = txtPhone.Text.Trim();

            if (string.IsNullOrEmpty(firstName) || string.IsNullOrEmpty(lastName) ||
                string.IsNullOrEmpty(email) || string.IsNullOrEmpty(phone))
            {
                Response.Write("<script>alert('Please fill in all fields.');</script>");
                return;
            }

            // Handling Image Upload
            string ImagePath = "~/Images/default.png";
            if (userImage.HasFile)
            {
                string fileExtension = Path.GetExtension(userImage.FileName).ToLower();
                if (fileExtension == ".jpg" || fileExtension == ".png" || fileExtension == ".jpeg")
                {
                    string fileName = Guid.NewGuid() + fileExtension; // Unique file name
                    ImagePath = "~/Images/" + fileName;
                    userImage.SaveAs(Server.MapPath(ImagePath));
                }
                else
                {
                    Response.Write("<script>alert('Please upload a valid image file (JPG, JPEG, PNG).')</script>");
                    return;
                }
            }

            SqlParameter[] parameters =
            {
        new SqlParameter("@FirstName", firstName),
        new SqlParameter("@LastName", lastName),
        new SqlParameter("@Email", email),
        new SqlParameter("@Phone", phone),
        new SqlParameter("@ImagePath", ImagePath)
    };

            DatabaseHelper.ExecuteProcedure("addNewUser", parameters);
            Response.Redirect("User.aspx");
        }
    }
}