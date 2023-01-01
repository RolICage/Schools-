<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="WebForm1.aspx.cs" Inherits="WebApplication1.WebForm1" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>

        <style>
        .TabelAddSchool {
            border: 10px solid;
            border-color: #FF9900;
            margin: auto;
            vertical-align: middle;
            width: 500px;
            height: 100px;
            margin-top:15%;
            background-color: #000000D9;
            -webkit-border-radius: 10px;
            -moz-border-radius: 10px;
            border-radius: 10px;
        }

        .PopUpAddSchool {
            position: absolute;
            top: 0;
            left: 0;
            z-index: 5;
            background-color: rgba(0,0,0,0.5);
            width: 100%;
            height: 100%;
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
            border-color: transparent;
            width: 150px;
            font-size: large;
            text-align: left;
            color: #F8B334;
        }

        .TextBoxAddSchoold {
            background-color: transparent;
            border-color: orangered;
            width: 150px;
            font-size: large;
            vertical-align: middle;
            text-align: center;
            color: #F8B334;
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
                height: 100%;
                width: 100%;
                background-color: #000000A6;
            }

            .ButtonS2 {
                font-family: ArabicFont;
                width: 120px;
                height: 35px;
                font-size: large;
                border-width: 3px;
                border-color: #FF9900;
                background-color: black;
                border-radius: 5px 12px;
                transition: 0.4s;
            }

            .Tabel2 {
                border: 2px solid;
                border-color: #FF9900;
                margin: auto;
                vertical-align: middle;
                width: 500px;
                height: 200px;
                background-color: #000000D9;
                -webkit-border-radius: 10px;
                -moz-border-radius: 10px;
                border-radius: 10px;
            }

    </style>

</head>
<body>




    <form id="form1" runat="server">

 <div runat="server" class="PopUpAddSchool" id="PopTableAddSchoolDiv">


           <table id="PopTableAddSchool" cellspacing="0px" cellpadding="2px"  class="TabelAddSchool" align="center" border="1">

             <%-----------------------------ROW-----------------------------%>

            <tr>
                <td class="CellStyle2" align="center" colspan="2" height="30px">&nbsp;

                   
                    <asp:Label ID="LabelSchoolName" CssClass="Label" runat="server" Text="Enter School Name :"></asp:Label>
                    <asp:TextBox ID="TextSchoolName" style="margin-left:13px" CssClass="TextBoxAddSchoold" runat="server"></asp:TextBox>
                    
                </td>
            </tr>
             <%-----------------------------ROW-----------------------------%>

            <tr>
                <td class="CellStyle2" align="center" colspan="2" height="30px">&nbsp;

                   
                    <asp:Label ID="LabelSchoolID" CssClass="Label" type="number" runat="server" Text="Enter School ID :"></asp:Label>
                    <%--<asp:TextBox ID="TextSchoolID" style="margin-left:43px" CssClass="TextBoxAddSchoold" runat="server"></asp:TextBox>--%>
                    <input type="number" ID="TextSchoolID" style="margin-left:43px" class="TextBoxAddSchoold" runat="server" />
                    
                </td>
            </tr>
             <%-----------------------------ROW-----------------------------%>

            <tr>
                <td class="CellStyle2" align="center" colspan="2" height="30px">&nbsp;
                   
                    <asp:Label ID="LabelSchoolPass" CssClass="Label" runat="server" Text="Enter School Pass :"></asp:Label>
                    <asp:TextBox ID="TextSchoolPass" style="margin-left:26px" CssClass="TextBoxAddSchoold" runat="server"></asp:TextBox>
                    
                </td>
            </tr>


            <%-----------------------------ROW-----------------------------%>

            <tr>
                <td class="CellStyle2" align="center" colspan="2" height="30px">&nbsp;
                  
                    <asp:Label ID="LabeConnection" CssClass="Label" runat="server" Text="Enter DB Connection :"></asp:Label>
                    <asp:TextBox ID="TextConnection"  CssClass="TextBoxAddSchoold" runat="server"></asp:TextBox>

                </td>
            </tr>

            <%-----------------------------ROW-----------------------------%>
            <tr>
                <td class="CellStyle2" align="center" colspan="2" height="30px">&nbsp;
                   
                    <asp:Label ID="LabelSelectSchool" CssClass="Label" runat="server" Text="Select School :"></asp:Label>
                    <asp:DropDownList ID="DropDownSelectSchool" style="margin-left:60px" CssClass="TextBoxAddSchoold"  runat="server"></asp:DropDownList>
                    <br />
                    <br />
                    
                </td>
            </tr>
            

            <%-----------------------------ROW-----------------------------%>
            <tr>
                <td class="CellStyle2" align="center" colspan="2" height="30px" >&nbsp;

                   
                    <asp:Button Class="ButtonS" Font-Bold="True" Text="Add School" ID="AddSchoolNow" runat="server" ForeColor="#FFD800" OnClick="AddSchoolNow_Click" />
                    <br />
                    <br />

                </td>
            </tr>


            </table>


         </div>


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

    </form>



</body>
</html>
