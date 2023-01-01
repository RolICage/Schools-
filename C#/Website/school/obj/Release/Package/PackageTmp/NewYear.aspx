<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="NewYear.aspx.cs" Inherits="school.NewYear" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">

    <link href="Stylepage1.css" rel="stylesheet" />
    <link href="FinalStyleXX.css" rel="stylesheet" />

    <title></title>

    <style>
        .TabelC {
            border: 2px solid;
            border-color: #FF9900;
            margin: auto;
            vertical-align: middle;
            width: 500px;
            height: 100px;
            background-color: #000000D9;
            -webkit-border-radius: 10px;
            -moz-border-radius: 10px;
            border-radius: 10px;
        }

        .PopUpMessage {
            position: absolute;
            top: 0;
            left: 0;
            z-index: 5;
            background-color: rgba(0,0,0,0.5);
            width: 100%;
            background-color: #000000A6;
        }


        .CellStyle2 {
            width: 340px;
            border: 20px;
            -webkit-border-radius: 10px;
            -moz-border-radius: 10px;
            border-radius: 10px;
            background-color: transparent;
            vertical-align: bottom;
        }

        .ButtonS {
            width: 200px;
            height: 35px;
            font-size: large;
            border-width: 3px;
            border-color: #FF9900;
            background-color: black;
            -webkit-border-radius: 10px;
            -moz-border-radius: 10px;
            border-radius: 10px;
        }


        .Label {
            background-color: transparent;
            margin-bottom: 20px;
            border-color: transparent;
            width: 200px;
            font-size: large;
            vertical-align: middle;
            text-align: center;
            color: #F8B334;
        }




    </style>

</head>
<body>


    <form id="form1" runat="server" onsubmit="ShowLoading()">

     <%--------------------------------------PopUp--------------------------------%>
     <%--------------------------------------PopUp--------------------------------%>

  <div runat="server" visible="true"  class="PopUpMessage" id="PopUpAccept">


            <br /> <br />
            <br /> <br />
            <br /> <br />
            <br /> <br />
            <br /> <br />
            <br /> <br />
            <br /> <br />
            <br /> <br />


           <table id="PopTableAccept" cellspacing="2px" cellpadding="2px" class="TabelC" align="center" border="1">
               <%-----------------------------ROW-----------------------------%>

            <tr >
                <td class="CellStyle2" align="center" colspan="2"  >   
                 
                   <img src="Gifs/Warning.gif" height="70px" width="70px" />

                </td>

            </tr>
               <%-----------------------------ROW-----------------------------%>

            <tr>
                <td class="CellStyle2" align="center" colspan="2"  >&nbsp;

                    <br />
                    <asp:Label ID="LabelAccept" CssClass="Label" runat="server" Text="Are You Sure Do U Want To Higher The Classes ?"></asp:Label>

                    <br /> <br />
                    
                </td>
            </tr>

            <%-----------------------------ROW-----------------------------%>

            <tr>
                <td class="CellStyle2" align="center" colspan="2"  >&nbsp;

                    <br />
                    <asp:TextBox ID="TextSCode" Font-Size="Medium" MaxLength="15" Font-Bold="true" CssClass="GridViewTextBox" Height="30px" runat="server"></asp:TextBox>

                    <br /> <br />
                    
                </td>
            </tr>
               <%-----------------------------ROW-----------------------------%>
            
            <tr>
                <td class="CellStyle2" align="center" colspan="2" height="20px" >

                   
                    <asp:Button Class="ButtonS" Font-Bold="True" Text="Yes" ID="Accept" runat="server" ForeColor="#FFD800" OnClick="Accept_Click"/>

                    <asp:Button Class="ButtonS" Font-Bold="True" Text="Cancel" ID="Cancel" runat="server" ForeColor="#FFD800" OnClick="Cancel_Click"/>

                    
                </td>
            </tr>


            </table>


         </div>




     <%--------------------------------------PopUp Message--------------------------------%>
     <%--------------------------------------PopUp Message--------------------------------%>
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

                   
                    <asp:Button Class="ButtonS" Font-Bold="True" Text="Close" ID="ButtonMessage" runat="server" ForeColor="#FFD800" OnClick="ButtonMessage_Click" />
                    
                </td>
            </tr>


            </table>


         </div>




    </form>

        <script type="text/javascript">
        function ShowLoading(e) {
            var divBG = document.createElement('divBG');
            var div = document.createElement('div');
            var img = document.createElement('img');
            img.src = 'Gifs/Loading2.Gif';
            img.style.cssText ='width:100px;  height:100px'
            div.innerHTML = "<br\>Loading...<br\>";
            div.style.cssText = 'position: fixed; color:#E5E7E9; Font-Bold:true; font-size:larger; top: 33%; left: 43.5%; z-index: 5000; border-radius: 10px; width: 222px; text-align: center; background: #000000A6; border: 4px solid #D35400; box-shadow: inset 0 0 30px #D4AC0D;';
            div.appendChild(img);

            divBG.style.cssText = 'width:100%; height: 100%; background: #000000A6; z-index: 5; position: absolute;'
            divBG.appendChild(div);

            document.body.appendChild(divBG);

            // These 2 lines cancel form submission, so only use if needed.
            window.event.cancelBubble = true;
            e.stopPropagation();
        }
        </script>

</body>
</html>
