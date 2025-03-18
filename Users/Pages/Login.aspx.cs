using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Users.Pages
{
    public partial class Login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void login_btnClick(object sender, EventArgs e)
        {
            string email = txtEmail.Text;
            string phone = txtPhone.Text;

            SqlParameter[] parameter = {
                new SqlParameter("@Email", email),
                new SqlParameter("@Phone", phone)
            };

            DataTable result = DatabaseHelper.ExecuteProcedureWithData("GetUserForLogin", parameter);

            if (result.Rows.Count > 0)
            {
                string role = result.Rows[0]["RoleName"].ToString();

                // Store session variables
                Session["Email"] = email;
                Session["Role"] = role;

                // Redirect based on role
                if (role == "Admin")
                {
                    Response.Redirect("User.aspx");
                }
                else
                {
                    Response.Redirect("Product.aspx");
                }
            }
            else
            {
                // Show error message if no user found
                Response.Write("<script>alert('Invalid email or phone number');</script>");
            }
        }
    }
}