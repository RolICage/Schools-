<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login Page.aspx.cs" Inherits="school.WebForm1" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Login</title>   
    <link href="Stylepage1.css" rel="stylesheet" />
    <link href="FinalStyleXX.css" rel="stylesheet" />
    <link href="https://stackpath.bootstrapcdn.com/font-awesome/4.7.0/css/font-awesome.min.css" rel="stylesheet">

    <style>

        @font-face {
            font-family: 'ArabicFont';
            src: url(fonts/AR.ttf);
            font-style: normal;
            font-weight: 100;
        }

        .B1 {
            font-family: ArabicFont;
            font-size: medium;
            -webkit-border-radius: 10px;
            -moz-border-radius: 10px;
            border-radius: 10px;
            height:40px;
            width:160px;
        }

        .ChangeLangNow {
            font-family: ArabicFont;
            position: absolute;
            z-index: 10;
            height: 40px;
            width: 40px;
            -webkit-border-radius: 10px;
            -moz-border-radius: 10px;
            border-radius: 10px;
            background-color: #FE940033;
            margin-top: 5px;
            margin-left: 5px;
            font-size: larger;
        }

    </style>

    <style type="text/css" <%--Tabel 2 Style--%> >

        @font-face {
            font-family: 'AR';
            src: url(fonts/AR.ttf);
            font-style: normal;
            font-weight: 100;
        }

    .Divin {
        width: 250px;
        height: 165px;
        background-color: #FE9400;
        -webkit-border-radius: 10px;
        -moz-border-radius: 10px;
        border-radius: 10px;
        margin: auto;
        vertical-align: middle;
        -webkit-box-shadow: inset 0 0 20px #888888;
        -moz-box-shadow: inset 0 0 20px #888888;
        box-shadow: inset 0 0 20px #888888;
        z-index: 50;
    }

    .Divout {
        width: 250px;
        height: 165px;
        background-color: #FE9400;
        -webkit-border-radius: 10px;
        -moz-border-radius: 10px;
        border-radius: 10px;
        margin: auto;
        vertical-align: middle;
        box-shadow: 4px 4px 8px #888888;
        z-index: 50;
    }


    .ButtonSD {
        width: 160px;
        height: 37px;
        font-size: large;
        border-width: 3px;
        border-color: #FF9900;
        background-color: black;
        border-radius: 12px 12px;
        transition: 0.4s;
        color: wheat;
    }

        .ButtonSD:hover {
            background-color: dimgrey;
            width: 170px;
            height: 40px;
        }

        .Exit{
            width:30px;
            height:30px;
            background-color: transparent;
            margin-left:205px;
            margin-top:5px;
            border: 0px;
            font-size:20px;
            color:dimgrey;
        }

</style>

</head>



<body>

    <form runat="server">

            <%--///////////////////////////////--%>

            <asp:Button  id="ChangeLangNow" class="ChangeLangNow" OnClick="ChangeLangNow_Click" Font-Bold="true" runat="server" />
          

            <%--///////////////////////////////--%>

<%--------------------------------------Image Logo----------------------------------------%>

     <div class="Mylogo">
         <img src="Images/Logo.png" alt="Alternate Text" class="user" />
     </div>

<%--------------------------------------table Login----------------------------------------%>
    <div class="login">
        <br />
      
        <h2 id="title1" style="font-family:ArabicFont;" runat="server" >Sign In</h2>
        
            <div class="input-group">
                <asp:TextBox ID="TextSchoolCode" Class="text" runat="server" TextMode="Number"></asp:TextBox>
                <span id="CodeSpan" runat="server"></span>
            </div>
            <div class="input-group"> 
                <asp:TextBox ID="TextPass" Class="text" runat="server"></asp:TextBox>
                <span id="PassSpan" runat="server" ></span>
            </div>
              <div class="input-group">
                  <asp:Button ID="Login" style="font-family:ArabicFont; font-size:large;" Class="button" runat="server" OnClick="LoginClick" />
            </div>
       
           <asp:Button ID="GorgetPass" CssClass="B1" BackColor="Transparent" BorderWidth="1px" ForeColor="White" BorderColor="Yellow" OnClick="GorgetPass_Click" runat="server" />
    </div>
  <br />
<%--------------------------------------social media----------------------------------------%>
        <ul>
            <li>
                <a href="#">
                    <i class="fa fa-facebook" aria-hidden="true"></i><span>Facebook</span>
                </a>
            </li>
            <li>
                <a href="#">
                    <i class="fa fa-instagram" aria-hidden="true"></i><span>Instagram</span>
                </a>
            </li>
        </ul>


     <%--------------------------------------PopUp--------------------------------%>
     <%--------------------------------------PopUp--------------------------------%>
               <div runat="server" visible="false"  class="PopUpMessage" id="DivMessage">

            <br /> <br />
            <br /> <br />
            <br /> <br />
            <br /> <br />
            <br /> <br />
            <br /> <br />
            <br /> <br />


           <table id="PopTable2" cellspacing="0px" cellpadding="13px"  class="Tabel2" align="center" border="1" >
               <%-----------------------------ROW-----------------------------%>

            <tr >
                <td class="CellStyle2" align="center" colspan="2" height="20px" >   
                 
                   <img src="Gifs/LitUpPNG.gif" height="80px" width="120px" />

                </td>

            </tr>
               <%-----------------------------ROW-----------------------------%>

            <tr>
                <td class="CellStyle2" align="center" colspan="2" height="100px">&nbsp;

                   
                    <asp:Label ID="LabelMessage" CssClass="Label" runat="server" Text="NO TEXT !"></asp:Label>
                    
                    
                </td>
            </tr>
               <%-----------------------------ROW-----------------------------%>
            
            <tr>
                <td class="CellStyle2" align="center" colspan="2" height="20px" >&nbsp;

                   
                    <asp:Button Class="ButtonS2" Font-Bold="True" Text="Close" ID="ButtonMessage" runat="server" ForeColor="#FFD800" OnClick="ButtonMessage_Click" />
                    
                </td>
            </tr>


            </table>


         </div>

    <%--------------------------------------Change Lang Div--------------------------------%>
    <%--------------------------------------Change Lang Div--------------------------------%>
            <div id="DivLang" runat="server" visible="false" class="PopUpMessage">
            

            <br /> <br /> <br /> <br /> <br /> <br />
            <br /> <br /> <br /> <br /> <br /> <br />
            <br /> <br /> <br /> <br /> <br /> <br />
            

         <div class="Divout" align="center" runat="server" >

            <div class="Divin"  runat="server" >

                <asp:Button id="ButtonExit" Font-Bold="true" Class="Exit" Text="⊗" OnClick="ButtonExit_Click" runat="server"/>
                 <br /> 

                <asp:Button ID="BtEN" Font-Bold="true" style="font-family:ArabicFont;" Class="ButtonSD" Enabled="false" OnClick="BtEN_Click1" runat="server" Text="ENGLISH Soon" />
                <br /> <br />

                <asp:Button ID="BtAR"  Font-Bold="true" style="font-family:ArabicFont;" Class="ButtonSD" OnClick="BtAR_Click" Text="ARABIC" runat="server"  />
            </div>

        </div>
    <%--------------------------------------Change Lang Div--------------------------------%>
    <%--------------------------------------Change Lang Div--------------------------------%>

        </div>

    </form>

    <%--------------------------------------photos wave animition--------------------------------%>
    <%--------------------------------------photos wave animition--------------------------------%>
       <section>
           <div class="wave">
              
           </div>
       </section>

</body>
</html>
