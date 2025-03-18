<%@ MasterPageFile="~/Site.Master" Language="C#" AutoEventWireup="true" CodeBehind="Product.aspx.cs" Inherits="Users.Pages.Product" %>



<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <style>
 .product-container {
    display: flex;
    flex-wrap: wrap;  /* Ensures cards wrap to the next line if needed */
    gap: 20px;        /* Adds space between cards */
    justify-content: center; /* Centers cards */
}

.card {
    width: 18rem;
    border: 1px solid #ddd;
    border-radius: 10px;
    padding: 15px;
    background-color: #fff;
    box-shadow: 2px 2px 10px rgba(0, 0, 0, 0.1);
    text-align: center;
    transition: transform 0.3s ease-in-out;
}

.card:hover {
    transform: scale(1.05);
}

.card img {
    border-radius: 5px;
    object-fit: cover;
    width: 70px;
    height: 70px;
}

.card-body {
    padding: 10px;
}

.card-title {
    font-size: 18px;
    font-weight: bold;
}

.card-text {
    color: #333;
    font-size: 14px;
    margin-bottom: 10px;
}

.btn-primary {
    display: inline-block;
    padding: 8px 15px;
    color: white;
    background-color: #007bff;
    text-decoration: none;
    border-radius: 5px;
}

.btn-primary:hover {
    background-color: #0056b3;
}
</style>


<h2 class="text-center my-4">Product Page</h2>

<div class="container">
    <div class="row">
        <asp:Repeater ID="rptProducts" runat="server">
            <ItemTemplate>
                <div class="col-md-4 mb-4">
                    <div class="card" style="width: 18rem;">
                        <img class="card-img-top" style="border-radius: 5px; object-fit: cover; width: 100px; height: 100px;" 
                             src='<%# ResolveUrl(Eval("Image").ToString()) %>' 
                             alt="<%# Eval("Name") %>">
                        <div class="card-body">
                            <h5 class="card-title"><%# Eval("Name") %></h5>
                            <p class="card-text">Price: $<%# Eval("Price") %></p>
                            <a href="ProductDetails.aspx?ProductId=<%# Eval("ID") %>" class="btn btn-primary">View Details</a>
                        </div>
                    </div>
                </div>
            </ItemTemplate>
        </asp:Repeater>
    </div>
</div>

</asp:Content>