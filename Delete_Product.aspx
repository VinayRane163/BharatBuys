﻿<%@ Page Title="" Language="C#" MasterPageFile="~/Setting.Master" AutoEventWireup="true" CodeBehind="Delete_Product.aspx.cs" Inherits="BharatBuys.Delete_Product" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="https://cdn.jsdelivr.net/npm/bootstrap@5.3.3/dist/css/bootstrap.min.css" rel="stylesheet" />
    <title></title>
    <style>
        #nav-area{
            width: 100%; /* Ensure the container takes the full width */
            overflow:scroll;            
        }
        #nav-area::-webkit-scrollbar {
            display: none; /* Hide scrollbar */
        }
        .Coverimage{
            width:99%;
            height:250px;object-fit: contain;
        }
        .label1{
            font-size: 1rem;
            color:firebrick;
        }
    </style>
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    
<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">

<body>
      
        <div id="Data_Display">
             <div class="p-3">
                <div class="row">   
                    <asp:Repeater ID="Repeater1" runat="server"  >
                        <ItemTemplate>
                            <div class="col-12 col-md-12 col-lg-12 p-2" >
                                <div class="p-3 border bg-light">
                            
                                    <p style="font-size: 1rem;">Name : <%# Eval("ProductName") %></p>  
                                    <p style="font-size: 1rem;">Price : <%# Eval("ProductPrice") %></p>  
                                    <p style="font-size: 1rem;">Description : RS <%# Eval("ProductDescription") %>/-</p>
                                    <p style="font-size: 1rem;">Keywords : <%# Eval("Keywords") %></p>
                                    <p style="font-size: 1rem;">Quantity Available : <%# Eval("Quantity") %></p>
                                  
                                </div>
                              
                            </div>
                        </ItemTemplate>
                    </asp:Repeater>
                            <asp:Button CssClass="form-control m-3 fs-5 bg-danger border border-black" ID="Your_Products" runat="server" Text="Delete Product" OnClick="DeleteProducts_Click" />

                </div>
            </div>             
        </div>
       <center><asp:Label ID="Label1" CssClass="label1" runat="server" Text="/* product will be deleted permanently */"></asp:Label></center> 
    <script src="https://cdn.jsdelivr.net/npm/bootstrap@5.3.3/dist/js/bootstrap.bundle.min.js"></script>
</body>
</html>



</asp:Content>