<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Search.aspx.cs" Inherits="BharatBuys.Search" %>


<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <link href="https://cdn.jsdelivr.net/npm/bootstrap@5.3.3/dist/css/bootstrap.min.css" rel="stylesheet" />
    <title></title>
    
    <style>
        #nav-area{
            width: 100%; /* Ensure the container takes the full width */
            overflow-x:scroll;            
        }
        #nav-area::-webkit-scrollbar {
            display: none; /* Hide scrollbar */
        }
           .Coverimage{
       width:99%;
       height:250px;object-fit: contain;
   }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <header id="header_1">
            <div class="text-center bg-danger"  style="font-size:3rem ;">BharatBuys </div>

              <div class="container-fluid bg-warning" id="nav-area">
    <div class="row">
        <div class="col-6 d-flex align-items-center justify-content-center">
            <asp:TextBox CssClass="text-black border border-black form-control rounded p-1" ID="Search_Item" runat="server"></asp:TextBox>
            <asp:Button CssClass="text-decoration-none text-black border border-black rounded p-1 ms-2" ID="Button1" runat="server" Text="Search" OnClick="Search_Prod" />

        </div>   
        <div class="col-6 d-flex align-items-center justify-content-center">
            <div class="p-2 me-3" style="font-size:1.5rem;"><a class="text-decoration-none text-black border border-black rounded p-1" href="Default.aspx">Home</a></div>
            <div class="p-2 me-3" style="font-size:1.5rem;"><a class="text-decoration-none text-black border border-black rounded p-1" href="order.aspx">Order</a></div>              
            <div class="p-2 me-3" style="font-size:1.5rem;"><a class="text-decoration-none text-black border border-black rounded p-1" href="cart.aspx">Cart</a></div>             
            <div class="p-2 me-3" style="font-size:1.5rem;"><a class="text-decoration-none text-black border border-black rounded p-1" href="Setting.aspx">Setting</a></div>   
        </div> 
    </div>
</div>


           
        </header>

                <div>
             <div class="p-3">
    <div class="row">   
        <asp:Repeater ID="Repeater1" runat="server">
            <ItemTemplate>
                <div class="col-12 col-md-12 col-lg-3 p-1" >
                    <div class="p-3 border bg-light">
                        <asp:Image ID="Coverimage" CssClass="Coverimage border border-2 rounded img-fluid" runat="server" ImageUrl='<%# "data:image/jpeg;base64," + GetBase64Image(Eval("Cover_Image")) %>' placeholder="ERROR" /><br />
                        
                   <center><p style="font-size: 1.5rem;"> <%# Eval("ProductName") %></p></center>     
                        <p style="font-size: 1.5rem;">Price : RS <%# Eval("ProductPrice") %>/-</p>
                       <p style="font-size: 1.5rem;">Quantity Available - <%# Eval("Quantity") %></p>
                                   <center>
                                    <asp:HyperLink ID="ProductLink" runat="server" 
                                                    NavigateUrl='<%# "prod_info.aspx?ProductID=" + Eval("ProductID") %>'
                                                    CssClass="btn-login btn border border-black">VIEW DETAILS
                                    </asp:HyperLink>
                                </center>
                    </div>
                </div>
            </ItemTemplate>
        </asp:Repeater>
    </div>
</div>

             
        </div>

        
       </form>  
    <script src="https://cdn.jsdelivr.net/npm/bootstrap@5.3.3/dist/js/bootstrap.bundle.min.js"></script>
</body>
</html>
