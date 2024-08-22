<%@ Page Title="" Language="C#" MasterPageFile="~/Setting.Master" AutoEventWireup="true" CodeBehind="Edit_Prod.aspx.cs" Inherits="BharatBuys.Edit_Prod" %>
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
                    

                     <div class="col-12 col-md-12 col-lg-12 p-2" >
                        <div class="p-3 border bg-light">
                            <asp:Label ID="Label2" runat="server" Text="ProductName"></asp:Label>
                            <asp:TextBox ID="ProductName" CssClass="form-control" runat="server"></asp:TextBox>

                            <asp:Label ID="Label3" runat="server" Text="ProductPrice"></asp:Label>
                            <asp:TextBox ID="ProductPrice" type="number" CssClass="form-control" runat="server"></asp:TextBox>

                            <asp:Label ID="Label4" runat="server" Text="ProductDescription"></asp:Label>
                            <asp:TextBox ID="ProductDescription" CssClass="form-control"  runat="server" TextMode="MultiLine" Rows="2"></asp:TextBox>

                            <asp:Label ID="Label5" runat="server" Text="Keywords"></asp:Label>
                            <asp:TextBox ID="Keywords" CssClass="form-control" runat="server"></asp:TextBox>

                            <asp:Label ID="Label6" runat="server" Text="Quantity"></asp:Label>
                            <asp:TextBox ID="Quantity"  CssClass="form-control" type="number" runat="server"></asp:TextBox>

                         </div>
                      </div>


                            <asp:Button CssClass="form-control m-3 fs-5 bg-danger border border-black" ID="Your_Products" runat="server" Text="Update Confirm" OnClick="UpdateProducts_Click" />

                </div>
            </div>             
        </div>
       <center><asp:Label ID="Label1" CssClass="label1" runat="server" Text="/* Product data will be Updated */"></asp:Label></center> 
    <script src="https://cdn.jsdelivr.net/npm/bootstrap@5.3.3/dist/js/bootstrap.bundle.min.js"></script>
</body>
</html>



</asp:Content>
