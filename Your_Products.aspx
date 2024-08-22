<%@ Page Title="" Language="C#" MasterPageFile="~/Setting.Master" AutoEventWireup="true" CodeBehind="Your_Products.aspx.cs" Inherits="BharatBuys.Your_Products" %>
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
            font-size: 7rem;
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
                            <div class="col-12 col-md-6 col-lg-6 p-3" >
                                <div class="p-3 border bg-light">
                        
                               <p style="font-size: 1rem;">Name : <%# Eval("ProductName") %></p>  
                                    <p style="font-size: 1rem;">Price : RS <%# Eval("ProductPrice") %>/-</p>
                                    <p style="font-size: 1rem;">Quantity Available - <%# Eval("Quantity") %></p>
                                    <asp:HyperLink ID="Edit_Prod" runat="server" 
                                                    NavigateUrl='<%# "Edit_Prod.aspx?ProductID=" + Eval("ProductID") %>'
                                                    CssClass="btn-login btn border border-black">Edit_Prod
                                    </asp:HyperLink>
                                       <asp:HyperLink ID="Delete_Product" runat="server" 
                                                    NavigateUrl='<%# "Delete_Product.aspx?ProductID=" + Eval("ProductID") %>'
                                                    CssClass="btn-login btn border border-black">Delete_Product
                                    </asp:HyperLink>
                                </div>
                              
                            </div>
                        </ItemTemplate>
                    </asp:Repeater>
                </div>
            </div>             
        </div>
       <center><asp:Label ID="Label1" CssClass="label1" runat="server" Text=""></asp:Label></center> 
    <script src="https://cdn.jsdelivr.net/npm/bootstrap@5.3.3/dist/js/bootstrap.bundle.min.js"></script>
</body>
</html>



</asp:Content>