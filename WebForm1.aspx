<%@ Page Title="" Language="C#" MasterPageFile="~/User.Master" AutoEventWireup="true"   CodeBehind="WebForm1.aspx.cs" Inherits="BharatBuys.WebForm1" %>
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

                   <center><asp:Label ID="Label2" CssClass="label2" runat="server" Text=""></asp:Label></center>
             <div class="p-3">
                <div class="row">   
                    <asp:Repeater ID="Repeater1" runat="server"  >
                        <ItemTemplate>
                            <div class="col-12 col-md-12 col-lg-4 p-1" >
                                <div class="p-3 border bg-light">
                                    <asp:Image ID="Coverimage" CssClass="Coverimage border border-2 rounded img-fluid" runat="server" ImageUrl='<%# "data:image/jpeg;base64," + GetBase64Image(Eval("Cover_Image")) %>' placeholder="ERROR" /><br />
                        
                               <center><p style="font-size: 2rem;"> <%# Eval("ProductName") %></p></center>     
                                    <p style="font-size: 2rem;">Price : RS <%# Eval("ProductPrice") %>/-</p>
                                    <p style="font-size: 2rem;">Quantity Available - <%# Eval("Quantity") %></p>
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
       <center><asp:Label ID="Label1" CssClass="label1" runat="server" Text=""></asp:Label></center> 
    <script src="https://cdn.jsdelivr.net/npm/bootstrap@5.3.3/dist/js/bootstrap.bundle.min.js"></script>
</body>
</html>



</asp:Content>

