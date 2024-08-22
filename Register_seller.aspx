<%@ Page Title="" Language="C#" MasterPageFile="~/User.Master" UnobtrusiveValidationMode="none" AutoEventWireup="true" CodeBehind="Register_seller.aspx.cs" Inherits="BharatBuys.Register_seller" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">

        <title>SELL</title>
    <link href="https://cdn.jsdelivr.net/npm/bootstrap@5.3.3/dist/css/bootstrap.min.css" rel="stylesheet" />
<style>
    .card{
        width:100%;
        height:100%; 
        border:1px solid black;
        padding:10px;
    }

    .button1{
      padding:10px;
      margin:10px;  
    }

    .btn-div{
        display:flex;
        justify-content:center;

    }
    #Pancard{
        text-transform:uppercase;
    }

    .labels{
        font-size:1.5rem;
    }
    .pd{
        padding-block:5px;
    }
  
</style>

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

        <div class="card">
    <div>
                    <center>        <asp:Label class="labels p-2  fw-bold" runat="server" Text="Regiater as Seller"></asp:Label></center>

    </div>
    <div class="card  pd">
       <div class="pd">
        <asp:Label for="FullName" class="labels" runat="server" Text="Full Name : "></asp:Label>
        <asp:TextBox ID="FullName"  class="form-control" runat="server" AutoCompleteType="DisplayName" ></asp:TextBox>
       </div >
        <div class="pd">
        <asp:Label for="email" class="labels"  runat="server" Text="Email : "></asp:Label>
        <asp:TextBox ID="email" class="form-control" type="email"  runat="server" AutoCompleteType="Email" ></asp:TextBox>
       </div>
        <div class="pd">
        <asp:Label for="phonenumber" class="labels" runat="server" Text="Phone number  : "></asp:Label>
        <asp:TextBox ID="phonenumber" class="form-control"  runat="server" AutoCompleteType="BusinessPhone" type="number" ></asp:TextBox>
       </div>
        <div class="pd">
        <asp:Label  class="labels" runat="server" Text="Adhar card  : "></asp:Label>
        <asp:TextBox ID="Adharcard" type="number"  class="form-control" runat="server"  ></asp:TextBox>

       </div >
        <div class="pd">
        <asp:Label  class="labels"  runat="server" Text="Pancard  : "></asp:Label>
        <asp:TextBox ID="Pancard" class="form-control"    runat="server"></asp:TextBox>

       </div>
        <div class="pd">
        <asp:Label for="Address" class="labels" runat="server" Text="Address : "></asp:Label>
        <asp:TextBox ID="Address" class="form-control"  runat="server" AutoCompleteType="BusinessStreetAddress"></asp:TextBox>
       </div>

    </div>

    
     
    <div class="btn-div">
        <asp:Button ID="Button1" CssClass="button1" runat="server" Text="Register" OnClick="Button1_Click" />
        <asp:Button ID="Back" CssClass="button1" runat="server" Text="Back" OnClick="Back_Click"/>
    </div>
</div>


</asp:Content>
