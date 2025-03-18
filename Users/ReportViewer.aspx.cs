using System;
using System.Collections.Generic;
using System.Data;
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
            // Fetch Data
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

            // Clear existing report data
            ReportViewer1.LocalReport.DataSources.Clear();

            // Add dataset to ReportViewer
            ReportDataSource rds = new ReportDataSource("DataSet1", users);
            ReportViewer1.LocalReport.DataSources.Add(rds);

            // Set Report Path
            ReportViewer1.LocalReport.ReportPath = @"C:\Users\Administrator\source\repos\Users\ReportService\Reports\UserReport.rdlc";

            TimeZoneInfo bdTimeZone = TimeZoneInfo.FindSystemTimeZoneById("Bangladesh Standard Time");

            // Convert UTC time to Bangladesh time
            DateTime bdTime = TimeZoneInfo.ConvertTimeFromUtc(DateTime.UtcNow, bdTimeZone);

            // Convert to a valid format as a string
            string formattedBdTime = bdTime.ToString("yyyy-MM-dd"); // or "dd-MM-yyyy" based on your RDLC format



            // Define Report Parameters
            ReportParameter[] parameters = new ReportParameter[]
            {
                new ReportParameter("CompanyTitle", "My Company Name"),
                new ReportParameter("CurrentDate", formattedBdTime, true)
        };

            // Set Parameters in ReportViewer
            ReportViewer1.LocalReport.SetParameters(parameters);

            // Refresh Report
            ReportViewer1.LocalReport.Refresh();
        }
    }
}
