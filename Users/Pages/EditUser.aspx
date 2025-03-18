<%@ Page EnableEventValidation="true" Language="C#" AutoEventWireup="true" MasterPageFile="~/Site.Master"  CodeBehind="EditUser.aspx.cs" Inherits="Users.Pages.EditUser" %>


<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <div >
        <asp:HiddenField ID="Id" runat="server" />
        <asp:FileUpload CssClass="form-control m-3" ID="userImage" runat="server" placeholder="Chose Photo" />
        <asp:TextBox ID="txtFirstName" runat="server" placeholder="FirstName"></asp:TextBox>
        <asp:TextBox ID="txtLastName" runat="server" placeholder="LastName"></asp:TextBox>
        <asp:TextBox ID="txtEmail" runat="server" placeholder="Email"></asp:TextBox>
        <asp:TextBox ID="txtPhone" runat="server" placeholder="Phone"></asp:TextBox>
        <asp:Button ID="btnUpdate" runat="server" Text="Update User" OnClick="btnUpdate_Click" />
    </div>
</asp:Content>

