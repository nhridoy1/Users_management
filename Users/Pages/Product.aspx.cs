using System;
using System.Data;


namespace Users.Pages
{
    public partial class Product : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["Email"] == null || Session["Role"] == null)
            {
                Response.Redirect("Login.aspx");
            }

            if (!IsPostBack)
            {
                DataTable dtProduct = DatabaseHelper.GetDataTable("GetAllProduct", null);
                rptProducts.DataSource = dtProduct;
                rptProducts.DataBind();
            }

        }
    }
}