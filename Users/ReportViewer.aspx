<%@ Page Language="C#" AutoEventWireup="true"  CodeBehind="ReportViewer.aspx.cs" Inherits="Users.ReportViewer" %>

<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>User Report</title>
</head>
<body>
    <form id="form1" runat="server">
        <%@ Register Assembly="Microsoft.ReportViewer.WebForms" Namespace="Microsoft.Reporting.WebForms" TagPrefix="rsweb" %>

        <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
        <rsweb:ReportViewer ID="ReportViewer1" runat="server" Width="100%" Height="600px" ProcessingMode="Local"></rsweb:ReportViewer>
    </form>
</body>
</html>
