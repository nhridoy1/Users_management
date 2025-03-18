<%@ Page MasterPageFile="~/Site.Master" Language="C#" AutoEventWireup="true" CodeBehind="Register.aspx.cs" Inherits="Users.Pages.Register" %>



<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div>
        <h2>User Management</h2>
        <div class="row">
            <div class="col-sm-3">
                <asp:TextBox CssClass="form-control g-col-6" ID="txtFirstName" runat="server" Placeholder="FirstName"></asp:TextBox>
            </div>
            <div class="col-sm-3">
                <asp:TextBox CssClass="form-control g-col-6" ID="txtLastName" runat="server" Placeholder="LastName"></asp:TextBox>
            </div>
            <div class="col-sm-3">
                 <asp:TextBox CssClass="form-control g-col-6" ID="txtEmail" runat="server" Placeholder="Email"></asp:TextBox>
            </div>
            <div class="col-sm-3">
                <asp:TextBox CssClass="form-control g-col-6" ID="txtPhone" runat="server" Placeholder="Phone"></asp:TextBox>
            </div>
            <div class="container">
                <div class="input-group">
                <asp:FileUpload  ID="userImage" runat="server"/>
            </div>
            <div class="col">
                <asp:Button CssClass="btn btn-primary" style="margin: 15px"  ID="Button1" runat="server" Text="Add User" OnClick="btnAdd_Click" />
            </div>
            </div>
        </div>
    </div>
</asp:Content>
