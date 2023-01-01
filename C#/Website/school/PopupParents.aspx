<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>
<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="PopupParents.aspx.cs" Inherits="school.WebForm3" %>


<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">

<head runat="server">

<script src="https://ajax.googleapis.com/ajax/libs/jquery/3.4.1/jquery.min.js"></script>
<script> 
    $(document).ready(function () {
        $("button1").click(function () {
    $("DivPop").animate({
      opacity: '1',
      
    });
  });
});
</script> 


    <title></title>
    <link href="Stylepage1.css" rel="stylesheet" />
    <link href="stylepage2.css" rel="stylesheet" />

    <style type="text/css">
        #DivPop {

            
             position: absolute;
             top: 0;
             left: 0;
             z-index: 1;
             background-color: rgba(0,0,0,0.5);
            height: 937px;
            width: 1903px;                   
            background-color: #00000080;  
     
        }

        .Admin {
            height: 100%;
            width: 100%;
           overflow: hidden;                               
        }

        .auto-style1 {

            margin: auto;
            vertical-align: middle;
            width: 694px;
            background-color: #FF9900;
            height: 386px;
             -moz-border-radius: 10px;
            -webkit-border-radius: 10px;
            border-radius: 10px;
            border-width: 6px;
            z-index: 1;
        }
       
        .auto-style3 {
            width: 342px;
        }
       
        .auto-style4 {
            height: 664px;
            margin-bottom: 1px;
        }
       
        </style>
</head>
<body >  

    
        
         <form id="form1" runat="server" class="Admin"  >

           
           
             <div align="center" class="btn"   >
                 <asp:Button   CssClass="button" BackColor="Black" Font-Bold="true" Font-Size="15px" BorderColor="#f6be00" BorderWidth="3px" ForeColor="#f6be00" Width="200px" Height="80px" ID="Button1" runat="server" Text="POPUP" OnClick="Button1_Click" />
             </div>
            

         <div   id="DivPop" runat="server" class="auto-style4" >
     
            <br /> 
                 
             <br />
            <br /> <br />
            <br /> <br />
            <br /> <br />
            <br /> <br />
            <br /> <br />
            <br /> <br />

              
            <table id="PopTable"  class="auto-style1" align="center" border="1"  >
            <tr>
                <td colspan="2">&nbsp;</td>
            </tr>
            <tr>
                <td>
                
                </td>
                <td class="auto-style3">&nbsp;</td>
            </tr>
            <tr>
                <td>&nbsp;</td>
                <td class="auto-style3">&nbsp;</td>
            </tr>
            <tr>
                <td>&nbsp;</td>
                <td class="auto-style3">&nbsp;</td>
            </tr>
            <tr>
                <td>&nbsp;</td>
                <td class="auto-style3">&nbsp;</td>
            </tr>
            <tr>
                <td colspan="2">&nbsp;</td>
            </tr>
            </table>
        
              
        </div>

           <%---------------------------------------------------------------------------------------- Timer--%>


             <asp:ScriptManager ID="ScriptManager1" runat="server">
            </asp:ScriptManager>

       

 </form>




                    


          

        

</body>  
</html>
