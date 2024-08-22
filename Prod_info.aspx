<%@ Page Title="" Language="C#" MasterPageFile="~/User.Master" AutoEventWireup="true" CodeBehind="Prod_info.aspx.cs" Inherits="BharatBuys.Prod_info" %>
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
            height:300px;
            min-height:300px;
            object-fit: contain;
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
             <div class="p-4">
                <div class="row">   


                    <asp:Repeater ID="Repeater1" runat="server">
                            <ItemTemplate>
                                <div class="col-12 col-md-12 col-lg-12 p-1">
                                    <div class="p-3 border bg-light">
                                                        <center><p style="font-size: 2rem;"> <%# Eval("ProductName") %></p></center>     

                                        <!-- Display Cover Image    remove a
                                                            <asp:Image ID="Coverimage" CssClass="Coverimage border border-2 rounded img-fluid m-2 p-1" runat="server" ImageUrl='<%a# "data:image/jpeg;base64," + GetBase64Image(Eval("Cover_Image")) %>' placeholder="ERROR" /><br />
                                            -->
                                                             <!-- Bootstrap Image Carousel -->
                                             <div id="carousel<%# Eval("ProductID") %>" class="carousel slide m-2 p-1 bg-dark border border-2 rounded img-fluid" data-bs-ride="carousel">
                                                 <div class="carousel-inner">
                                                     <!-- Image 1 -->
                                                     <div class="carousel-item active">
                                                         <img src='<%# "data:image/jpeg;base64," + GetBase64Image(Eval("Cover_Image")) %>' class="Coverimage" alt="">
                                                     </div> 
                                                     <div class="carousel-item active">
                                                         <img src='<%# "data:image/jpeg;base64," + GetBase64Image(Eval("Image1")) %>' class="Coverimage" alt="">
                                                     </div>
                                                     <!-- Image 2 -->
                                                     <div class="carousel-item">
                                                         <img src='<%# "data:image/jpeg;base64," + GetBase64Image(Eval("Image2")) %>' class="Coverimage" alt="Image 2">
                                                     </div>
                                                     <!-- Image 3 -->
                                                     <div class="carousel-item">
                                                         <img src='<%# "data:image/jpeg;base64," + GetBase64Image(Eval("Image3")) %>' class="Coverimage" alt="Image 3">
                                                     </div>
                                                     <!-- Image 4 -->
                                                     <div class="carousel-item">
                                                         <img src='<%# "data:image/jpeg;base64," + GetBase64Image(Eval("Image4")) %>' class="Coverimage" alt="Image 4">
                                                     </div>
                                                     <!-- Image 5 -->
                                                     <div class="carousel-item">
                                                         <img src='<%# "data:image/jpeg;base64," + GetBase64Image(Eval("Image5")) %>' class="Coverimage" alt="Image 5">
                                                     </div>
                                                 </div>
                                             <a class="carousel-control-prev border border-white" href="#carousel<%# Eval("ProductID") %>" role="button" data-bs-slide="prev">
                                                <span class="carousel-control-prev-icon" aria-hidden="false"></span>
                                                <span class="visually-hidden">Previous</span>
                                            </a>
                                            <a class="carousel-control-next border border-white" href="#carousel<%# Eval("ProductID") %>" role="button" data-bs-slide="next">
                                                <span class="carousel-control-next-icon" aria-hidden="false"></span>
                                                <span class="visually-hidden">Next</span>
                                             </a>


                                       

               
                                        </div>
                                        <div class="border border-2 rounded m-2 p-3 img-fluid">
                                         <p style="font-size: 2rem;">Price : RS <%# Eval("ProductPrice") %>/-</p>
                                         <p style="font-size: 2rem;">Quantity Available -  <%# Eval("Quantity") %></p>
                                         <p style="font-size: 2rem;">Product Description - <%# Eval("ProductDescription") %></p>
                                        </div>
                                        
                                        <div class="border border-2 m-2 p-3 rounded img-fluid">
                                         <asp:HyperLink ID="Buylink" runat="server" 
                                                NavigateUrl='<%# "Buy.aspx?ProductID=" + Eval("ProductID") %>'
                                                CssClass="btn-login btn form-control bg-warning border border-black m-2 p-3">BUY
                                </asp:HyperLink>                                           
                                        </div>


                                    </div>
                                </div>
                            </ItemTemplate>
                        </asp:Repeater>

            <div class="border border-2 m-2 p-3 rounded img-fluid p-3 border bg-light">
                  

                <asp:Button ID="AddtoCart" CssClass="btn-login form-control btn border border-black m-2 p-3" runat="server" Text="Add to Cart" OnClick="AddtoCart_Click" />
                <asp:Button ID="RemovefromCart" CssClass="btn-login form-control btn border border-black m-2 p-3" runat="server" Text="Remove from cart" OnClick="RemovefromCart_Click" />
<asp:Button ID="Button1" runat="server" CssClass="btn-login form-control btn border border-black m-2 p-3" Text="BACK TO HOME" OnClick="Back_Click" />

            </div>





                </div>
            </div>             
        </div>
       <center><asp:Label ID="Label1" CssClass="label1" runat="server" Text=""></asp:Label></center> 
    <script src="https://cdn.jsdelivr.net/npm/bootstrap@5.3.3/dist/js/bootstrap.bundle.min.js"></script>
</body>
</html>



</asp:Content>

