<%@ Page Title="" Language="C#" MasterPageFile="~/User.Master" AutoEventWireup="true" CodeBehind="Buy.aspx.cs" Inherits="BharatBuys.Buy" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
     <title>Buy</title>
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
     .unabledz{
            font-size:1.4rem;
            min-width:600px;

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
    <div class="m-3">
                    <center>        <asp:Label ID="hoi" class="labels p-2 border border-black  fw-bold m-3   " runat="server" Text="Buy"></asp:Label></center>

    </div>
    <div class="card  pd">
       <div class="pd">
        <asp:Label for="ItemName" class="labels" runat="server" Text="Product Name : "></asp:Label>
        <asp:TextBox ID="ItemName" CssClass="unabledz" runat="server"  Enabled="false" ></asp:TextBox>
       </div >
        <div class="pd">
        <asp:Label for="ItemPrice" class="labels"  runat="server" Text="Product Price : "></asp:Label>
        <asp:TextBox ID="ItemPrice" CssClass="unabledz" type="number" Enabled="false"  runat="server"></asp:TextBox>
       </div>        
         <div class="pd">
             <asp:Label for="Quantity" class="labels" runat="server" Text="Quantity : "></asp:Label>
             <asp:TextBox ID="Quantity" type="number" value="0" class="form-control labels"  runat="server" OnTextChanged="Quantity_TextChanged"></asp:TextBox>
         </div>
        <div class="pd">
             <asp:Label for="Total_Price" class="labels" runat="server" Text="Total Price : "></asp:Label>
             <asp:TextBox ID="Total_Price" type="number" value="0" class="form-control labels" Enabled="false"  runat="server"></asp:TextBox>
            <asp:Button ID="calculate" runat="server" Text="🔄" OnClick="calculate_Click" />
             <asp:Label ID="price_warning" runat="server" ForeColor="Red" Text="/*it will calculate on logic side, rcomend to refresh*/"></asp:Label>
         </div>
        <div class="pd">
             <asp:Label for="YourName" class="labels" runat="server" Text="Your Name : "></asp:Label>
             <asp:TextBox ID="YourName"  class="form-control labels"  AutoCompleteType="FirstName"  runat="server"></asp:TextBox>
         </div>
        <div class="pd">
             <asp:Label for="MobileNumber" class="labels" runat="server" Text="Mobile Number : "></asp:Label>
             <asp:TextBox ID="MobileNumber" type="number" CssClass="unabledz" Enabled="false" runat="server"></asp:TextBox>
         </div>
        <div class="pd">
             <asp:Label for="Address" class="labels" runat="server" Text="Address : "></asp:Label>
             <asp:TextBox ID="Address" AutoCompleteType="HomeStreetAddress" class="form-control labels"  runat="server"></asp:TextBox>
         </div>
        <div>
            <asp:CheckBox ID="CheckBox1" runat="server" CssClass="form-control labels" value="CashonDelivery" Text="Cash on delivery"/>
            
        </div>
    </div>

    
     
    <div class="btn-div p-3">
        <asp:Button ID="Buy_order" CssClass="button1 labels form-control bg-warning border border-black" runat="server" Text="Buy" OnClick="Buy_order_Click"  /><br />
        <asp:Button ID="Back" CssClass="button1 labels form-control bg-danger border border-black" runat="server" Text="Return to Home" OnClick="Back_Click" />
    </div>
</div>

</asp:Content>
