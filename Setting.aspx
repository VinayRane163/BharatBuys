    <%@ Page Title="" Language="C#" MasterPageFile="~/User.Master" AutoEventWireup="true" CodeBehind="Setting.aspx.cs" Inherits="BharatBuys.Setting" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
        <link href="https://cdn.jsdelivr.net/npm/bootstrap@5.3.3/dist/css/bootstrap.min.css" rel="stylesheet" />
    <title>SETTING</title>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div class="p-3">
            
        <asp:Button CssClass="form-control m-3 fs-5 bg-danger border border-black" ID="Button1" runat="server" Text="Register as Seller" OnClick="RAS_Click" />
        <asp:Button CssClass="form-control m-3 fs-5 bg-danger border border-black" ID="AddProd" runat="server" Text="Add Product" OnClick="Add_Click" />
        <asp:Button CssClass="form-control m-3 fs-5 bg-danger border border-black" ID="Your_Products" runat="server" Text="Your Products" OnClick="Your_Products_Click" />
        <asp:Button CssClass="form-control m-3 fs-5 bg-danger border border-black" ID="Your_Product_Order" runat="server" Text="Your Product Orders" OnClick="Your_Product_Order_Click" />
        <asp:Button CssClass="form-control m-3 fs-5 bg-danger border border-black" ID="Order_History" runat="server" Text="Your Order History" OnClick="Order_History_Click" />
        <asp:Button CssClass="form-control m-3 fs-5 bg-danger border border-black" ID="Logout" runat="server" Text="Logout" OnClick="Logout_Click" />                            
         
    </div>

</asp:Content>
