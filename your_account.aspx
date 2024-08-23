<%@ Page Title="" Language="C#" MasterPageFile="~/User.Master" AutoEventWireup="true" UnobtrusiveValidationMode="none" CodeBehind="your_account.aspx.cs" Inherits="BharatBuys.your_account" %>
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
         padding:5px;
         margin:4px;
     }
   
 </style>
</asp:Content>


<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="card">
    
    <div class="card  pd">
       <div class="pd">
        <asp:Label ID="Username" class="form-control labels" runat="server" Text="Product Name : "></asp:Label>
       </div >       
    </div>

        <div class="card  pd">
                                   <asp:Label ID="label1" class="form-control labels border border-primary" runat="server" Text="CHANGE PASSWORD : "></asp:Label>

           <div class="pd">
           <asp:TextBox ID="changePass" CssClass="form-control pd labels" placeholder="Enter new Password" runat="server" TextMode="Password"></asp:TextBox>

           <asp:TextBox ID="repass" CssClass="form-control pd labels" placeholder="RE-Enter new Password" runat="server" TextMode="Password"></asp:TextBox>
               
               <asp:CompareValidator ID="CompareValidator1" CssClass="form-control pd" runat="server" ErrorMessage="Password dont Match" ControlToCompare="changePass" ControlToValidate="repass"></asp:CompareValidator>

          <asp:Button ID="changebtn" CssClass="button1 pd labels form-control bg-danger border border-black" runat="server" Text="Change Password" OnClick="password_Click" />


           </div >       
        </div>

    
     
    <div class="btn-div p-3">
        <asp:Button ID="Back" CssClass="button1 labels form-control bg-danger border border-black" runat="server" Text="Return to Home" OnClick="Back_Click" />
    </div>
</div>

</asp:Content>
