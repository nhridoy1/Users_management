<%@ Page MasterPageFile="~/Site.Master" Language="C#" AutoEventWireup="true"CodeBehind="Login.aspx.cs" Inherits="Users.Pages.Login" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div class="container">
        <h3>Login </h3>
    </div>
    <div class="col-sm-3">
        <asp:TextBox CssClass="form-control g-col-6" ID="txtEmail" runat="server" Placeholder="Email"></asp:TextBox>
    </div>
     <div class="col-sm-3">
                <asp:TextBox CssClass="form-control g-col-6" ID="txtPhone" runat="server" Placeholder="Phone"></asp:TextBox>
            </div>

    <div class="col">
        <asp:Button ID="button1" CssClass="btn btn-primary" style="margin: 15px;" runat="server" Text="Login" OnClick="login_btnClick"/>
    </div>     
</asp:Content>

