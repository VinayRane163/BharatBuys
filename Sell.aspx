<%@ Page Title="" Language="C#" MasterPageFile="~/Setting.Master" AutoEventWireup="true" CodeBehind="Sell.aspx.cs" Inherits="BharatBuys.Sell" %>
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

 
     .labels{
         font-size:1.5rem;
     }
     .pd{
         padding-block:5px;
     }
   
 </style>
 <script type="text/javascript">
     function showImage(input) {
         var fileInput = document.getElementById('<%= coverimage.ClientID %>');
         var imgPreview = document.getElementById('<%= Image1.ClientID %>');
         var fileLabel = document.getElementById('fileLabel');

         if (fileInput.files && fileInput.files[0]) {
             var reader = new FileReader();
             reader.onload = function (e) {
                 imgPreview.src = e.target.result;
             };
             reader.readAsDataURL(fileInput.files[0]);

             // Display chosen file name
             fileLabel.innerText = fileInput.files[0].name;
         }
     }

     function showImages(input) {
         var fileInput = document.getElementById('<%= imageUpload.ClientID %>');
         var imagePreviewContainer = document.getElementById('imagePreviewContainer');
         var fileLabel = document.getElementById('detailimages');

         // Clear previous images
         imagePreviewContainer.innerHTML = '';

         if (fileInput.files && fileInput.files.length > 0) {
             // Display chosen file names
             var fileNames = Array.from(fileInput.files).map(file => file.name).join(', ');
             fileLabel.innerText = fileNames;

             // Loop through each file and create an img element
             Array.from(fileInput.files).forEach(file => {
                 var reader = new FileReader();
                 reader.onload = function (e) {
                     var imgElement = document.createElement('img');
                     imgElement.src = e.target.result;
                     imgElement.className = 'img-thumbnail';
                     imgElement.style.maxWidth = '150px';
                     imgElement.style.maxHeight = '150px';
                     imgElement.style.marginRight = '10px';
                     imagePreviewContainer.appendChild(imgElement);
                 };
                 reader.readAsDataURL(file);
             });
         }
     }
 </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="card">
    <div>
                    <center>        <asp:Label class="labels p-2  fw-bold" runat="server" Text="Add Product"></asp:Label></center>

    </div>
    <div class="card  pd">
       <div class="pd">
        <asp:Label for="ItemName" class="labels" runat="server" Text="Product Name : "></asp:Label>
        <asp:TextBox ID="ItemName"  class="form-control" runat="server" ></asp:TextBox>
       </div >
        <div class="pd">
        <asp:Label for="ItemPrice" class="labels"  runat="server" Text="Product Price : "></asp:Label>
        <asp:TextBox ID="ItemPrice" class="form-control" type="number"  runat="server"></asp:TextBox>
       </div>
        <div class="pd">
        <asp:Label for="ItemDescription" class="labels" runat="server" Text="Product Description : "></asp:Label>
        <asp:TextBox ID="ItemDescription" class="form-control"  runat="server"></asp:TextBox>
       </div>
         <div class="pd">
             <asp:Label for="ItemTags" class="labels" runat="server" Text="Item Tags : 'use space or comma ' "></asp:Label>
             <asp:TextBox ID="ItemTags" class="form-control"  runat="server"></asp:TextBox>
            </div>
         <div class="pd">
             <asp:Label for="Quantity" class="labels" runat="server" Text="Quantity : "></asp:Label>
             <asp:TextBox ID="Quantity" type="number" class="form-control"  runat="server"></asp:TextBox>
            </div>
    </div>

    <br />

    <div class="card">
        <asp:Label ID="Label1" class="labels fw-bold" runat="server" Text="Cover Image" ></asp:Label>
        <div class="custom-file">
          <asp:FileUpload ID="coverimage" runat="server" CssClass="custom-file-input form-control" onchange="showImage(this);" />
       </div>
         <img id="Image1" runat="server" class="mt-2 img-thumbnail" style="max-width: 150px; max-height: 150px;" src="image" />
    </div>

   <br />           

     <div class="card">
        <div class="custom-file">
            <asp:FileUpload ID="imageUpload" runat="server" CssClass="custom-file-input form-control" onchange="showImages(this);" multiple="multiple" />
            <label class="custom-file-label" for="imageUpload" id="detailimages">Choose files  *Max 5 files can be entered*</label>
        </div>
        <div id="imagePreviewContainer" class="mt-2"></div>
    </div>
     
    <br />
     
    <div class="btn-div">
        <asp:Button ID="Button1" CssClass="button1" runat="server" Text="ADD ITEM" OnClick="Button1_Click" />
        <asp:Button ID="Back" CssClass="button1" runat="server" Text="Return to Home" OnClick="Back_Click"/>
    </div>
</div>

</asp:Content>
