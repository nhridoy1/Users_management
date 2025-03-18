using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Microsoft.Reporting.WebForms;
using ReportService.Model;

namespace Users
{
    public partial class ReportViewer : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                LoadReport();
            }
        }

        private void LoadReport()
        {

            DataTable dt = DatabaseHelper.ExecuteProcedureWithData("GetUsers", null);
            List<UserModel> users = new List<UserModel>();

            foreach (DataRow row in dt.Rows)
            {
                users.Add(new UserModel
                {
                    Id = Convert.ToInt32(row["Id"]),
                    FirstName = row["FirstName"].ToString(),
                    LastName = row["LastName"].ToString(),
                    Email = row["Email"].ToString(),
                    Phone = row["Phone"].ToString()
                });
            }

            ReportViewer1.LocalReport.DataSources.Clear();
            ReportDataSource rds = new ReportDataSource("DataSet1", users);
            ReportViewer1.LocalReport.DataSources.Add(rds);
            ReportViewer1.LocalReport.ReportPath = @"C:\Users\Administrator\source\repos\Users\ReportService\Reports\UserReport.rdlc";
            ReportViewer1.LocalReport.Refresh();
        }
    }
}