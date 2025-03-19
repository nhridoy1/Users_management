<%@ Page MasterPageFile="~/Site.Master" Language="C#" AutoEventWireup="true" CodeBehind="User.aspx.cs" Inherits="Users.Pages.User" %>



<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server" cssClass="container">
    <h1>Users Manage</h1>
    <asp:DropDownList ID="ddlPageSize" runat="server" AutoPostBack="True" CssClass="form-select"
    OnSelectedIndexChanged="ddlPageSize_SelectedIndexChanged">
    <asp:ListItem Text="10" Value="10" Selected="True"></asp:ListItem>
    <asp:ListItem Text="20" Value="20"></asp:ListItem>
    <asp:ListItem Text="30" Value="30"></asp:ListItem>
    <asp:ListItem Text="50" Value="50"></asp:ListItem>
    <asp:ListItem Text="100" Value="100"></asp:ListItem>
</asp:DropDownList>

    <asp:GridView ID="GridViewUsers" runat="server" AutoGenerateColumns="False" CssClass="gridview table table-bordered table-primary" 
        OnRowEditing="GridView_rowEdit"
        OnRowUpdating="GridView_rowUpdate"
        OnRowDeleting="GridViewUsers_RowDeleting"
        OnDelete="GridViewUsers_RowDeleting"
        OnRowCancelingEdit="GridViewUsers_rowCancelEdit"
        AllowPaging="True" 
    PageSize="10" 
    OnPageIndexChanging="GridViewUsers_PageIndexChanging"
        DataKeyNames="Id"
        >

        <Columns>

            <asp:TemplateField HeaderText="Photo">
                <ItemTemplate>
                    <img id="imgPreview" style="border-radius: 5px; object-fit: cover; width: 70px; height: 70px;"
                        src='<%# ResolveUrl(Eval("ImagePath").ToString()) %>' />
                </ItemTemplate>
                <EditItemTemplate>
                    <asp:FileUpload ID="fileUploadImage" runat="server" CssClass="form-control" />
                    <asp:HiddenField ID="hfImagePath" runat="server" Value='<%# Eval("ImagePath") %>' />
                    <br />
                    <img id="imgEditPreview" style="border-radius: 5px; object-fit: cover; width: 70px; height: 70px;"
                        src='<%# ResolveUrl(Eval("ImagePath").ToString()) %>' />
                </EditItemTemplate>
            </asp:TemplateField>


            <asp:TemplateField HeaderText="First Name">
                <ItemTemplate>
                    <asp:Label ID="lblFirstName" runat="server" Text='<%# Eval("FirstName") %>'></asp:Label>
                </ItemTemplate>
                <EditItemTemplate>
                    <asp:TextBox ID="txtFirstName" runat="server" Text='<%# Bind("FirstName") %>' CssClass="form-control"></asp:TextBox>
                </EditItemTemplate>
            </asp:TemplateField>

            <asp:TemplateField HeaderText="Last Name">
                <ItemTemplate>
                    <asp:Label ID="lblLastName" runat="server" Text='<%# Eval("LastName") %>'></asp:Label>
                </ItemTemplate>
                <EditItemTemplate>
                    <asp:TextBox ID="txtLastName" runat="server" Text='<%# Bind("LastName") %>' CssClass="form-control"></asp:TextBox>
                </EditItemTemplate>
            </asp:TemplateField>

            <asp:TemplateField HeaderText="Email">
                <ItemTemplate>
                    <asp:Label ID="lblEmail" runat="server" Text='<%# Eval("Email") %>'></asp:Label>
                </ItemTemplate>
                <EditItemTemplate>
                    <asp:TextBox ID="txtEmail" runat="server" Text='<%# Bind("Email") %>' CssClass="form-control"></asp:TextBox>
                </EditItemTemplate>
            </asp:TemplateField>

            <asp:TemplateField HeaderText="Phone">
                <ItemTemplate>
                    <asp:Label ID="lblPhone" runat="server" Text='<%# Eval("Phone") %>'></asp:Label>
                </ItemTemplate>
                <EditItemTemplate>
                    <asp:TextBox ID="txtPhone" runat="server" Text='<%# Bind("Phone") %>' CssClass="form-control"></asp:TextBox>
                </EditItemTemplate>
            </asp:TemplateField>

            <asp:TemplateField HeaderText="Action">
                <ItemTemplate>
                    <asp:Button ID="btnEdit" runat="server" CommandName="Edit" Text="Edit"
                        CssClass="btn btn-warning btn-sm" />
                    <asp:LinkButton ID="btnDelete" runat="server" CommandName="Delete" CommandArgument='<%# Eval("Id") %>' Text="Delete"
    OnClientClick="return confirm('Are you sure?')" CssClass="btn btn-danger btn-sm" />

                </ItemTemplate>
                <EditItemTemplate>
                    <asp:Button ID="btnUpdate" runat="server" CommandName="Update" Text="Update"
                        CssClass="btn btn-success btn-sm" />
                    <asp:Button ID="btnCancel" runat="server" CommandName="Cancel" Text="Cancel"
                        CssClass="btn btn-secondary btn-sm" />
                </EditItemTemplate>
            </asp:TemplateField>


        </Columns>
        <PagerStyle CssClass="gvPagination" />
    </asp:GridView>
    
    <asp:Button ID="PrintUserList" Text="Print" runat="server" OnClick="btnPrintUserList1" />

</asp:Content>
