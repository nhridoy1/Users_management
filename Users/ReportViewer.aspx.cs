using System;
using System.Collections.Generic;
using System.Data;
using System.Web;
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

            // Clear existing report data
            ReportViewer1.LocalReport.DataSources.Clear();

            // Add dataset to ReportViewer
            ReportDataSource rds = new ReportDataSource("DataSet1", users);
            ReportViewer1.LocalReport.DataSources.Add(rds);

            // Set Report Path
            ReportViewer1.LocalReport.ReportPath = @"C:\Users\Administrator\source\repos\Users\ReportService\Reports\UserReport.rdlc";

            //string currentDate = DateTime.Today.ToString("dd-MMM-yyyy hh:mm:ss tt");
            var currentDate = DateTime.UtcNow.AddHours(6).ToString("dd-MMM-yyyy hh:mm:ss tt"); 

            ReportParameter[] parameters = new ReportParameter[]
            {
                new ReportParameter("CompanyTitle", "Pinnovation Company Ltd."),
                new ReportParameter("CurrentDate", currentDate)
            };


            ReportViewer1.LocalReport.SetParameters(parameters);
            ReportViewer1.LocalReport.Refresh();

            string mimeType, encoding, fileNameExtension;
            Warning[] warnings;
            string[] streamIds;

            byte[] pdfBytes = ReportViewer1.LocalReport.Render("PDF", null, out mimeType, out encoding, out fileNameExtension,
            out streamIds, out warnings);

            HttpContext.Current.Response.Clear();
            HttpContext.Current.Response.ContentType = "application/pdf";
            HttpContext.Current.Response.AddHeader("Content-Disposition", $"inline; filename=ProductReport-{currentDate}.pdf");
            HttpContext.Current.Response.BinaryWrite(pdfBytes);
            HttpContext.Current.Response.End();
        }
    }
}
