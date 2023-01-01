<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Tests.aspx.cs" Inherits="school.Tests" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">

<head runat="server">
        <link href="Stylepage1.css" rel="stylesheet" />
    <link href="FinalStyleXX.css" rel="stylesheet" />
<script src="https://ajax.googleapis.com/ajax/libs/jquery/3.4.1/jquery.min.js"></script>



<style type="text/css" <%--Button Style--%> >

    /* width */
::-webkit-scrollbar {
  width: 12px;
  visibility:visible;   
}

    /* Track */
::-webkit-scrollbar-track {
  background-color:#00000033; 
  visibility:visible;
  border: 1px solid;
  -webkit-border-radius: 10px; 
  -moz-border-radius: 10px; 
  border-radius: 10px;
}
 
/* Handle */
::-webkit-scrollbar-thumb {
    background: url('Gifs/ScrollBackGIF.gif'); 
    border: 2px solid;
    -webkit-border-radius: 10px; 
    -moz-border-radius: 10px; 
    border-radius: 10px;
    visibility: visible;        
}

/* Handle on hover */
::-webkit-scrollbar-thumb:hover { 
  visibility:visible;
}


    @font-face {
        font-family: 'ArabicFont';
        src: url(fonts/AR.ttf);
        font-style: normal;
        font-weight: 100;
    }


</style>


</head>
<body>


    <form id="load" runat="server">

        <asp:Button ID="Button1" runat="server" Text="Button" />

    <script type="text/javascript">
        $(document).ready(function () {
            $('#Button1').hide();
                $('#Button1').fadeIn("slow").delay(5000).fadeOut("slow");        
        });
    </script>

     </form>


</body>
</html>
