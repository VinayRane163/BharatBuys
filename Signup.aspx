<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Signup.aspx.cs" Inherits="BharatBuys.Signup" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
            <link rel="stylesheet" href="https://stackpath.bootstrapcdn.com/bootstrap/4.5.2/css/bootstrap.min.css" />

    <title></title>

     <style>
     .login-container{
         display:flexbox;
         background-color:gray;
         align-content:center;
         justify-content:center;

         max-width: 600px;
         margin: auto;
         margin-top: 50px;

         min-height:500px;
     }

     .card-header{
         justify-content:center;
         align-items:center;
         text-align:center;
         max-width: 600px;
         margin: auto;
         background-color:transparent;
         border:0 dashed;
         

         }

     .btn{
         display:flex;
     }
     .btn-secondary{         
         border:1px solid black;
         text-align:center;
         font-weight:bold;
     }
     label{
         font-weight:bold;
     }
     #Label1{
         font-size:30px;
     }

     #HyperLink3{
         color:black;
         font-weight:bold;
/*         text-decoration:underline;
*/     }
   </style>
</head>
<body>
    <form id="form1" runat="server">
       
        
   <div class="hmm">
    
    <div class="container login-container">
       <div class="card-header">
          <h3>Sign Up </h3>
               </div>
                    <label>UserName</label><asp:TextBox ID="Uname" CssClass="form-control" runat="server" placeholder="Email"></asp:TextBox><br />
                    <label>mobilenumber</label><asp:TextBox ID="Mob" CssClass="form-control" runat="server" placeholder="mobile"></asp:TextBox><br />
                    <label>pasword</label><asp:TextBox ID="Pass" CssClass="form-control" runat="server" placeholder="pass" Type="Password" ></asp:TextBox><br />
                       
                    <div class="btn">
                         <asp:Button ID="SignUP" CssClass="form-control btn-secondary" runat="server" Text="Sign up" OnClick="SignUP_Click" />
                    </div>
                                    <br />
                    <center>   
                        <asp:HyperLink ID="HyperLink3" runat="server"  href="login.aspx" >Already Registered !!</asp:HyperLink>

                    </center>

               </div>
               <center> 
                   <asp:CheckBox ID="CheckBox1" runat="server" />    
                   <asp:HyperLink ID="HyperLink2" runat="server" Target="_blank" href="#lol" >Terms and conditions</asp:HyperLink>

                   &nbsp &nbsp &nbsp &nbsp                  
                   <asp:CheckBox ID="CheckBox2" runat="server" />
                   <asp:HyperLink ID="HyperLink1" runat="server" Target="_blank" href="#lol" >Privacy & Policy</asp:HyperLink>

                   

               </center>
             </div>
        
       
    </form>
</body>
</html>
