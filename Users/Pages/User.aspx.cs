using System;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Web.UI.WebControls;

namespace Users.Pages
{
    public partial class User : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Session["Role"] == null || Session["Email"] == null)
                {
                    Response.Redirect("Login.aspx");
                    return;
                }

                if (Session["Role"].ToString() != "Admin")
                {
                    Response.Redirect("Product.aspx");
                    return;
                }

                LoadUsers();
            }
        }

        protected void ddlPageSize_SelectedIndexChanged(object sender, EventArgs e)
        {
           
            int newPageSize = Convert.ToInt32(ddlPageSize.SelectedValue);

            GridViewUsers.PageSize = newPageSize;

            LoadUsers();
        }


        private void LoadUsers()
        {
            DataTable dt = DatabaseHelper.GetDataTable("GetUsers", null);
            GridViewUsers.DataSource = dt;
            GridViewUsers.DataBind();
        }

        protected void GridViewUsers_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            GridViewUsers.PageIndex = e.NewPageIndex;

            LoadUsers();
        }



        protected void GridView_rowEdit(object sender, GridViewEditEventArgs e)
        {
            GridViewUsers.EditIndex = e.NewEditIndex;
            LoadUsers();
        }

        protected void GridView_rowUpdate(object sender, GridViewUpdateEventArgs e)
        {

            int userId = Convert.ToInt32(GridViewUsers.DataKeys[e.RowIndex].Value);


            TextBox txtFirstName = (TextBox)GridViewUsers.Rows[e.RowIndex].FindControl("txtFirstName");
            TextBox txtLastName = (TextBox)GridViewUsers.Rows[e.RowIndex].FindControl("txtLastName");
            TextBox txtEmail = (TextBox)GridViewUsers.Rows[e.RowIndex].FindControl("txtEmail");
            TextBox txtPhone = (TextBox)GridViewUsers.Rows[e.RowIndex].FindControl("txtPhone");


            FileUpload fileUpload = (FileUpload)GridViewUsers.Rows[e.RowIndex].FindControl("fileUploadImage");
            HiddenField hfImagePath = (HiddenField)GridViewUsers.Rows[e.RowIndex].FindControl("hfImagePath");

            string imagePath = hfImagePath.Value;


            if (fileUpload.HasFile)
            {
                string folderPath = Server.MapPath("~/Images/");
                string fileName = Path.GetFileName(fileUpload.FileName);
                imagePath = "~/Images/" + fileName;
                fileUpload.SaveAs(folderPath + fileName);
            }


            SqlParameter[] parameters = {
        new SqlParameter("@UserId", userId),
        new SqlParameter("@FirstName", txtFirstName.Text.Trim()),
        new SqlParameter("@LastName", txtLastName.Text.Trim()),
        new SqlParameter("@Email", txtEmail.Text.Trim()),
        new SqlParameter("@Phone", txtPhone.Text.Trim()),
        new SqlParameter("@ImagePath", imagePath)
    };

            DatabaseHelper.ExecuteProcedure("UpdateUser", parameters);

            GridViewUsers.EditIndex = -1;
            LoadUsers();
        }

        protected void GridViewUsers_rowCancelEdit(object sender, GridViewCancelEditEventArgs e)
        {
            GridViewUsers.EditIndex = -1;
            LoadUsers();
        }

        protected void GridViewUsers_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            int userId = Convert.ToInt32(GridViewUsers.DataKeys[e.RowIndex].Value);


            Console.WriteLine("Deleting User ID: " + userId);

            SqlParameter[] parameters = { new SqlParameter("@UserId", userId) };
            DatabaseHelper.ExecuteProcedure("DeleteUser", parameters);

            LoadUsers();
        }

        protected void btnPrintUserList1(object sender, EventArgs e)
        {
            Response.Redirect("~/ReportViewer.aspx");
        }
    }
}