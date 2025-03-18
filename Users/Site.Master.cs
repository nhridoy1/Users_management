using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Users
{
    public partial class SiteMaster : MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                checkUserRole();
            }
        }

        private void checkUserRole()
        {
            if (Session["Role"] != null && Session["Role"].ToString() == "Admin")
            {
                listUser.Visible = true;
            }
            else
            {
                listUser.Visible = false;
            }
        }
    }
}