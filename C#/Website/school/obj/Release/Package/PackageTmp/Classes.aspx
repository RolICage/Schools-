<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Classes.aspx.cs" Inherits="school.Classes" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link href="Stylepage1.css" rel="stylesheet" />
    <link href="FinalStyleXX.css" rel="stylesheet" />

<style <%--ScrollBar--%> >
/* width */
::-webkit-scrollbar {
  width: 12px;
  visibility:visible; 
   
}

/* Track */
::-webkit-scrollbar-track {
  background-color:#00000040; 
  visibility:visible;
  border: 0px;
  border-radius: 10px;
  box-shadow: inset 0 0 3px black;
}
 
/* Handle */
::-webkit-scrollbar-thumb {
    background-color:#196597;
    border: 0.5px solid;
    border-radius: 10px;
    box-shadow: inset 0 0 5px #CACFD2;
    visibility: visible;  
    transition:0.4s;
}

/* Handle on hover */
::-webkit-scrollbar-thumb:hover {  
    visibility: visible;  
}
</style>

<style>


    :root{--gv-border-radius: 15px;}
    .rcgv
    {
        border-radius: var(--gv-border-radius);
        border-width: 0 !important;
    }
    .rcgv th:first-child
    {
        border-top-left-radius: var(--gv-border-radius);
    }
    .rcgv th:last-child
    {
        border-top-right-radius: var(--gv-border-radius);
    }
    .rcgv tr:last-child td:first-child
    {
        border-bottom-left-radius: var(--gv-border-radius);
    }
    .rcgv tr:last-child td:last-child
    {
        border-bottom-right-radius: var(--gv-border-radius);
    }


</style>


 <style type="text/css">
        .FixedHeader {
            position: absolute;
            font-weight: bold;
        }     
    </style>   


    <style>
        .DropDownStyleCC {
            color: black;
            width: 150px;
            font-size: 20px;
            padding: 5px 10px;
            border-radius: 12px 12px 12px 12px;           
            background-color: #F8B334;
            border-color: whitesmoke;
            border-width: 2px;
            font-weight: bold;
            margin-left:10px;
            margin-right:10px;
        }

        @font-face {
            font-family: 'ArabicFont';
            src: url(fonts/AR.ttf);
            font-style: normal;
            font-weight: 100;
        }

    .DropDownStyle2 {
        color: black;
        width: 120px;
        height: 50px;
        font-size: 20px;
        padding: 5px 10px;
        border-radius: 5px 12px;
        background-color: #F8B334;
        border-color: whitesmoke;
        font-weight: bold;
        font-family: ArabicFont;
        transition: 0.5s;
    }

.DropDownStyle2:hover {
    width: 140px;
    height: 75px;
}


    .ButtonS3 {
        width: 235px;
        height: 50px;
        font-family: ArabicFont;
        font-size: large;
        border-color: #BDC3C7;
        background-color: black;
        border-radius: 5px;
        box-shadow: inset 0 0 10px #BDC3C7;
        color: #D35400;
        margin-top: 20px;
        transition: 0.4s;
    }

        .ButtonS3:hover {
            box-shadow: inset 0 0 10px #D35400;
            border-color: coral;
        }

/*===================== Back button Design =====================*/
/*===================== Back button Design =====================*/
.BackButton {
    height: 50px;
    width: 80px;
    background-color: #1F618D;
    color:white;
    border: solid;
    border-width: 1px;
    border-color: white;
    border-radius: 10px;
    margin-left: 995px;
    margin-top:40px;
    position:absolute;
    font-size:xx-large;
    box-shadow: inset 0 0 30px black;
    transition: 0.5s;
}

    .BackButton:hover {
        background-color: dimgrey;
        width:90px;
        color:gold;
        margin-left:990px;
    }

.href {
    font-size: xx-large;
    margin-left:2px;
}

     .HeaderCellStyleClasses {
         width:200px;
         border: 2.2px solid #BDC3C7;
         border-radius: 5px;
         background-color: black;
         font-size: large;
         box-shadow: inset 0 0 10px #BDC3C7;
         text-align: center;
     }

    .LabelClasses {
        font-family: ArabicFont;
        background-color: transparent;
        border-color: transparent;
        width: 200px;
        height: 100%;
        font-size: large;
        vertical-align: middle;
        text-align: center;
        color: #D35400;
    }

    </style>


</head>






<body>


    <%--============================= Form =============================--%>
    <%--============================= Form =============================--%>
    <form id="form1" runat="server" onsubmit="ShowLoading()" >
        
        <asp:Button ID="BackClick" class="BackButton" Font-Bold="true" OnClick="BackClick_Click" runat="server" Text="⟸" />
        

        <%--============================= Logo =============================--%>
        <%--============================= Logo =============================--%>
        <div align="left" >

         <img src="Images/Logo.png" alt="Alternate Text" Width="110px" height="100px" align="Right" />

         </div  >


        <br />
        <br />



<%--*************************************** Grid Header ***************************************
******************************************* Grid Header ***************************************
******************************************* Grid Header ***************************************--%>
            <asp:Table ID="Grid1HeaderTabel" CssClass="GridHeader" runat="server" >


                <asp:TableRow >

<%--===================================================================CELL===============================================================>--%>
                    <asp:TableCell CssClass="HeaderCellStyleClasses" style="box-shadow: inset 0 0 0px #00000000;" Width="225px" >

                        <img src="Gifs/3Lines.gif" class="EditGif" />

                    </asp:TableCell>

<%--===================================================================CELL===============================================================>--%>
                    <asp:TableCell CssClass="HeaderCellStyleClasses"  >

                        <asp:Label ID="HeaderClassName" CssClass="LabelClasses"  runat="server" Text="CLASS NAME"></asp:Label>

                    </asp:TableCell>

                </asp:TableRow>
              

            </asp:Table>


<%--*************************************** GridViewClass ***************************************
******************************************* GridViewClass ***************************************
******************************************* GridViewClass ***************************************--%>
              <div id="GRIDVDIV" runat="server" class="ScrollDiv" >

            
              <asp:GridView ID="Grid1" ShowFooter="false" ShowHeader="false" CssClass="rcgv" runat="server" OnRowCommand="Grid1_RowCommand" style=" overflow:auto; max-height:500px"
              AutoGenerateColumns="False" DataKeyNames="ClassCode" 
              BorderColor="Transparent" CellPadding="5" CellSpacing="5" OnRowDeleting="Grid1_RowDeleting" Font-Bold="True" 
              Font-Names="Franklin Gothic Medium" Font-Overline="False" Font-Size="Medium" Font-Strikeout="False" Font-Underline="True" ForeColor="Black"
              OnSelectedIndexChanged="Grid1_SelectedIndexChanged" HorizontalAlign="Center" BorderStyle="None" Width="1180px" >

<%--==================================================================== Columns ====================================================================--%>
<%--==================================================================== Columns ====================================================================--%>
              <Columns >  

<%--==================================================================== TemplateField Class Name ====================================================================--%>
<%--==================================================================== TemplateField Class Name ====================================================================--%>
              <asp:TemplateField ItemStyle-Width="250px"  >
  
              <%--============================= Item Template =============================--%>
              <%--============================= Item Template =============================--%>
              <ItemTemplate >  
                       
              <asp:Button CommandArgument='<%# Eval("ClassCode")%>' Class="ButtonS" Height="30px" Width="120px" CommandName="Delete" ToolTip="Delete"
                Font-Bold="true" Font-Size="Medium" Text="Delete" ForeColor="#FFD800" ID="Delete" runat="server" Style="background-image:url('Gifs/Delete.gif');" />
             
              </ItemTemplate>

            
              </asp:TemplateField>


<%--==================================================================== TemplateField Class Name ====================================================================--%>
<%--==================================================================== TemplateField Class Name ====================================================================--%>

                    <asp:TemplateField HeaderText="CLASS NAME" ItemStyle-Width="220px" >

                        <%--============================= Item Template =============================--%>
                        <%--============================= Item Template =============================--%>
                        <ItemTemplate >

                            <div class="GridRowMaxWidth" >

                            <asp:Label ID="LabelCName" CssClass="GridViewLabe2" Width="130px" runat="server"  Text='<%# Eval("CName")%>'></asp:Label>                                                                                     

                            </div>
                            
                        </ItemTemplate>

                     
                    </asp:TemplateField>

                </Columns>  

<%--==================================================================== Grid Styles ====================================================================--%>
<%--==================================================================== Grid Styles ====================================================================--%>
                <EditRowStyle BackColor="Silver" CssClass="GridEditRow" Height="100px" BorderColor="Black" Font-Size="Medium" HorizontalAlign="Center" />

                <FooterStyle BackColor="Black" BorderWidth="0px" ForeColor="Black" Font-Bold="True" Font-Size="Medium" />
                <HeaderStyle BackColor="Black" BorderStyle="Double" ForeColor="#FF9900" Font-Bold="True" Font-Size="Large" Height="60px" Font-Strikeout="False" HorizontalAlign="Center" />
                <PagerStyle BackColor="Black" />

                <RowStyle BackColor="#FF9900" BorderWidth="1px" Height="60px" CssClass="GridRow" BorderColor="Black" HorizontalAlign="Center"  ForeColor="Black" Wrap="True"  Font-Bold="True" Font-Size="Medium" />

                <SelectedRowStyle BackColor="#FF3300" />

                </asp:GridView>


                </div>

        
<%--*************************************** Grid Footer ***************************************
******************************************* Grid Footer ***************************************
******************************************* Grid Footer ***************************************--%>
            <asp:Table ID="Grid1FooterTabel" CssClass="GridFooter" runat="server">


                <asp:TableRow >

                    <%--===================================================================CELL===============================================================>--%>
                    <asp:TableCell CssClass="FooterCellStyle"  Width="260px" >

                        <asp:Button ID="addclassbutton" Class="ButtonS3"  Font-Bold="true" ForeColor="#FFD800" Font-Size="Large" Text="ADD" BorderWidth="3" runat="server" OnClick="ADD_Click" /> <br /> <br />

                    </asp:TableCell>

                    <%--===================================================================CELL===============================================================>--%>
                    <asp:TableCell CssClass="FooterCellStyle" >

                        <asp:DropDownList ID="DropDownClasses" onmousedown="this.size=3;" onfocusout="this.size=1;" CssClass="DropDownStyle2"  runat="server"></asp:DropDownList>


                    </asp:TableCell>

                                        <%--===================================================================CELL===============================================================>--%>
                    <asp:TableCell CssClass="FooterCellStyle" Width="100px" >

                        <asp:DropDownList ID="DropDownClassID" onmousedown="this.size=3;" onfocusout="this.size=1;" CssClass="DropDownStyle2" runat="server"></asp:DropDownList>

                    </asp:TableCell>

                </asp:TableRow>
              

            </asp:Table>

            
                             
            <br />             


            <br />
  
            <section>



           

<%--*************************************** Grid2 END ***************************************
******************************************* Grid2 END ***************************************
******************************************* Grid2 END ***************************************--%>

           <div class="wave">

           </div>

        
<%--*************************************** PopUp Message ***************************************
******************************************* PopUp Message ***************************************
******************************************* PopUp Message ***************************************--%>



        <div runat="server"  class="PopUpMessage" id="DivMessage">


            <br /> <br />
            <br /> <br />
            <br /> <br />
            <br /> <br />
            <br /> <br />
            <br /> <br />
            <br /> <br />


           <table id="PopTable2" cellspacing="0px" cellpadding="13px"  class="Tabel2" align="center" border="1">
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




<%--*************************************** PopUp Accept ***************************************
******************************************* PopUp Accept ***************************************
******************************************* PopUp Accept ***************************************--%>

       <div runat="server"  class="PopUpMessage" id="PopUpAccept">


            <br /> <br />
            <br /> <br />
            <br /> <br />
            <br /> <br />
            <br /> <br />
            <br /> <br />
            <br /> <br />


           <table id="PopTableAccept" cellspacing="0px" cellpadding="13px"  class="Tabel2" align="center" border="1">
               <%-----------------------------ROW-----------------------------%>

            <tr >
                <td class="CellStyle2" align="center" colspan="2" height="20px" >   
                 
                   <img src="Gifs/Warning.gif" height="70px" width="70px" />

                </td>

            </tr>
               <%-----------------------------ROW-----------------------------%>

            <tr>
                <td class="CellStyle2" align="center" colspan="2" height="100px">&nbsp;

                   
                    <asp:Label ID="LabelAccept" CssClass="Label" runat="server" Text="NO Accept TEXT !"></asp:Label>
                    
                    
                </td>
            </tr>
               <%-----------------------------ROW-----------------------------%>
            
            <tr>
                <td class="CellStyle2" align="center" colspan="2" height="20px" >&nbsp;

                   
                    <asp:Button Class="ButtonS" Font-Bold="True" Text="Accept" ID="Accept" runat="server" ForeColor="#FFD800" OnClick="Accept_Click" />
                    <asp:Button Class="ButtonS" Font-Bold="True" Text="Cancel" ID="Cancel" runat="server" ForeColor="#FFD800" OnClick="Cancel_Click" />
                    
                </td>
            </tr>


            </table>


         </div>

    </section>

<%--*************************************** Tests ***************************************
******************************************* Tests ***************************************
******************************************* Tests ***************************************--%>

        <%--================== Control ScrollBar in Div ============>--%>
        <%--================== Control ScrollBar in Div ============>--%>
        <script type="text/javascript">
            window.onload = function () {
                var strCook = document.cookie;
                if (strCook.indexOf("!~") != 0) {
                    var intS = strCook.indexOf("!~");
                    var intE = strCook.indexOf("~!");
                    var strPos = strCook.substring(intS + 2, intE);
                    document.getElementById("GRIDVDIV").scrollTop = strPos;
                }
            }
            function SetDivPosition() {
                var intY = document.getElementById("GRIDVDIV").scrollTop;
                document.cookie = "yPos=!~" + intY + "~!";
            }
        </script>
 
            <script type="text/javascript">
                function ShowLoading(e) {
                    var divBG = document.createElement('divBG');
                    var div = document.createElement('div');
                    var img = document.createElement('img');
                    img.src = 'Gifs/Loading2.Gif';
                    img.style.cssText = 'width:100px;  height:100px'
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

<%--*************************************** Tests END ***************************************
******************************************* Tests END ***************************************
******************************************* Tests END ***************************************--%>
    </form>
    </body>





</html>
