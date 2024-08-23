<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Forgetpassword.aspx.cs" Inherits="BharatBuys.Forgetpassword"  %>
<%@ OutputCache Duration="30" VaryByParam="None" %>


<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
        <link rel="stylesheet" href="https://stackpath.bootstrapcdn.com/bootstrap/4.5.2/css/bootstrap.min.css" />
        
    <title>Login</title>
    <style>
        .login-container{
            display:flexbox;
            background-color:gray;
            align-content:center;
            justify-content:center;

            max-width: 600px;
            margin: auto;
            margin-top: 50px;

            min-height:300px;
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
       #register_text{
           font-size:20px;
           font-weight:bolder;
       }
       #HyperLink1:hover{
           text-decoration:none;
           color:black;
       }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div class="hmm">
            
            <div class="container login-container">
               <div class="card-header">
                 <h3>Forget Password </h3>
               </div>
            <label>UserName</label><asp:TextBox CssClass="form-control" ID="Uname" runat="server" placeholder="Email" type="e-mail" ></asp:TextBox><br />
                <div class="btn">
                     <asp:Button CssClass="form-control btn-secondary" ID="ForgetBtn" runat="server" Text="Forget Password" OnClick="MailPassword_Click"  />
                </div>
            </div>
        </div>

        <div>
            <center> 
                <asp:HyperLink ID="HyperLink1" runat="server"  href="Login.aspx" ><p id="register_text" >Login Page</p></asp:HyperLink>
            </center>
        </div>
       

    </form>
</body>
</html>