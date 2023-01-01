<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="SubTecher.aspx.cs" Inherits="school.SubTecher" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>

<%--******************************************* Stylesheets ***************************************--%>
    <link href="Stylepage1.css" rel="stylesheet" />
    <link href="FinalStyleXX.css" rel="stylesheet" />
<%--******************************************* Stylesheets END ***************************************--%>


<style <%--ScrollBar--%> >

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


 <style type="text/css">
        .FixedHeader {
            position: absolute;
            font-weight: bold;
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


@font-face {
    font-family: 'ArabicFont';
    src: url(fonts/AR.ttf);
    font-style: normal;
    font-weight: 100;
}

    .DropDownStyle2 {
        color: black;
        width: 120px;
        height: 40px;
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


    .DropDownStyle3 {
        color: black;
        width: 200px;
        height: 40px;
        font-size: 20px;
        padding: 5px 10px;
        border-radius: 5px 12px;
        background-color: #F8B334;
        border-color: whitesmoke;
        font-weight: bold;
        font-family: ArabicFont;
        transition: 0.5s;
    }

.DropDownStyle3:hover {
    width: 250px;
    height: 75px;
}


     .HeaderCellStyleSubjectsT {
         width:200px;
         border: 2.2px solid #BDC3C7;
         border-radius: 5px;
         background-color: black;
         font-size: large;
         box-shadow: inset 0 0 10px #BDC3C7;
         text-align: center;
     }

    .LabelSubjectsT {
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
        

        <div>

        <%--============================= Search Option =============================--%>
        <%--============================= Search Option =============================--%>

       <div id="Div" runat="server" style="background-image: url( Images/GridEditRow.Gif );" class="search-box" >


            <asp:TextBox CssClass="search-txt" ID="TextFind" min="1" max="999999999" placeholder="ENTER TECHER ID" Font-Bold="true"  runat="server"></asp:TextBox>  
  
            <asp:Button text="S" class="search-btn" ID="ButtonFind" runat="server" Font-Bold="true"  OnClick="ButtonFind_Click"  />

           <asp:ImageButton ID="ImageButton1" class="search-btn" ImageUrl="Gifs/Refresh.Gif" runat="server" Font-Bold="true" OnClick="ImageButton1_Click" />
            
         
       </div>

            
        <%--============================= Logo =============================--%>
        <%--============================= Logo =============================--%>
        <div class="alingLogo" align="right" >

         <img src="Images/Logo.png" alt="Alternate Text" Width="110px" height="100px" align="right" />

         </div>




<%--*************************************** Grid Header ***************************************
******************************************* Grid Header ***************************************
******************************************* Grid Header ***************************************--%>
            <asp:Table ID="Grid1HeaderTabel"  CssClass="GridHeader" runat="server" >

<%--===================================================================Row===============================================================>--%>
                <asp:TableRow >

<%--===================================================================CELL===============================================================>--%>
                    <asp:TableCell CssClass="HeaderCellStyleSubjectsT" style="box-shadow: inset 0 0 0px #00000000;" Width="225px" >

                        <img src="Gifs/3Lines.gif" class="EditGif" />

                    </asp:TableCell>

<%--===================================================================CELL===============================================================>--%>
                    <asp:TableCell CssClass="HeaderCellStyleSubjectsT"  >

                        <asp:Label ID="HeaderTName" CssClass="LabelSubjectsT"  runat="server" Text="TECHER"></asp:Label>

                    </asp:TableCell>
<%--===================================================================CELL===============================================================>--%>
                    <asp:TableCell CssClass="HeaderCellStyleSubjectsT" >

                        <asp:Label ID="HeaderCName" CssClass="LabelSubjectsT"  runat="server" Text="CLASS"></asp:Label>

                    </asp:TableCell>
<%--===================================================================CELL===============================================================>--%>
                    <asp:TableCell CssClass="HeaderCellStyleSubjectsT" >

                        <asp:Label ID="HeaderSName" CssClass="LabelSubjectsT"  runat="server" Text="SUBJECT"></asp:Label>

                    </asp:TableCell>

                </asp:TableRow>              

            </asp:Table>


<%--*************************************** GridViewTecher ***************************************
******************************************* GridViewTecher ***************************************
******************************************* GridViewTecher ***************************************--%>

              <div id="GRIDVDIV" runat="server" class="ScrollDiv" >

            
              <asp:GridView ID="Grid1" ShowFooter="false" ShowHeader="false" CssClass="rcgv" runat="server" OnRowCommand="Grid1_RowCommand" style=" overflow:auto; max-height:500px"
              AutoGenerateColumns="False" 
              BorderColor="black"  CellPadding="5" CellSpacing="5" OnRowDeleting="Grid1_RowDeleting" Font-Bold="True" 
              Font-Names="Franklin Gothic Medium" Font-Overline="False" Font-Size="Medium" Font-Strikeout="False" Font-Underline="false" ForeColor="Black"
              OnSelectedIndexChanged="Grid1_SelectedIndexChanged" HorizontalAlign="Center" BorderStyle="None"  Width="1180px" >

<%--==================================================================== Columns ====================================================================--%>
<%--==================================================================== Columns ====================================================================--%>
              <Columns >  

<%--==================================================================== TemplateField EDIT ====================================================================--%>
<%--==================================================================== TemplateField EDIT ====================================================================--%>
              <asp:TemplateField ItemStyle-Width="250px" ControlStyle-CssClass="ButtonS2"  >
  
              <%--============================= Item Template =============================--%>
              <%--============================= Item Template =============================--%>
              <ItemTemplate >
      
              <asp:Button  Class="ADDDELETE" CommandName="Delete" CommandArgument='<%# Eval("Cnt")%>' ToolTip="Delete"
                Font-Bold="true" Font-Size="Medium" Text="Delete" ForeColor="Crimson" ID="Delete" runat="server" />
             
              </ItemTemplate>


              <%--============================= Edit Template =============================--%>
              <%--============================= Edit Template =============================--%>


            
              <ControlStyle CssClass="ButtonS2"></ControlStyle>

              <ItemStyle Width="250px"></ItemStyle>

            
              </asp:TemplateField>


<%--==================================================================== TemplateField Techer  ====================================================================--%>
<%--==================================================================== TemplateField Techer  ====================================================================--%>

                    <asp:TemplateField ItemStyle-Width="220px" ItemStyle-CssClass="GRIDC"  >

                        <%--============================= Item Template =============================--%>
                        <%--============================= Item Template =============================--%>
                        <ItemTemplate >

                            <div class="GridRowMaxWidth" >

                            <asp:Label ID="LabelTID" Font-Underline="true" ForeColor="DarkBlue" CssClass="DropDownStyle" BorderWidth="1px" BorderColor="Black" Width="195px" Height="20px" runat="server" Text='<%# Eval("TName")%>'></asp:Label>                                                                                     

                            </div>
                            
                        <%--============================= Edit Template =============================--%>
                        <%--============================= Edit Template =============================--%>
                        </ItemTemplate>

                     
                      <ItemStyle CssClass="GRIDC" Width="220px"></ItemStyle>
                     
                    </asp:TemplateField>

                    

<%--==================================================================== TemplateField ClassCode ====================================================================--%>
<%--==================================================================== TemplateField ClassCode ====================================================================--%>

                    <asp:TemplateField ItemStyle-Width="220px"  >

                        <%--============================= CLASS =============================--%>
                        <%--============================= CLASS =============================--%>
                        <ItemTemplate>

                            <asp:Label ID="LabelClassCode" CssClass="DropDownStyle" BorderWidth="1px" brodercolor="black" Width="140px" Height="20px" runat="server" BorderColor="Black" BackColor="#F8B334" Text='<%# Eval("CName")%>'></asp:Label>

                        </ItemTemplate>

                        <%--============================= Edit Template =============================--%>
                        <%--============================= Edit Template =============================--%>

                      
                           <ItemStyle Width="220px"></ItemStyle>
                      
                    </asp:TemplateField>



<%--==================================================================== TemplateField SUBJECTS ====================================================================--%>
<%--==================================================================== TemplateField SUBJECTS ====================================================================--%>

                    <asp:TemplateField ItemStyle-Width="220px"  >

                        <%--============================= Subject =============================--%>
                        <%--============================= Subject =============================--%>
                        <ItemTemplate>

                            <asp:Label ID="LabelSUBJECTS" CssClass="DropDownStyle" BorderWidth="1px" brodercolor="black" Width="140px" Height="20px" runat="server" BorderColor="Black" BackColor="#F8B334" Text='<%# Eval("SName")%>'></asp:Label>

                        </ItemTemplate>

                        <%--============================= Edit Template =============================--%>
                        <%--============================= Edit Template =============================--%>

                      
                       <ItemStyle Width="220px"></ItemStyle>
                      
                    </asp:TemplateField>



                </Columns>  

<%--==================================================================== Grid Styles ====================================================================--%>
<%--==================================================================== Grid Styles ====================================================================--%>
                <EditRowStyle BackColor="Silver" CssClass="GridEditRow" Height="100px" BorderColor="Black" Font-Size="Medium" HorizontalAlign="Center" />

                <FooterStyle BackColor="Black"  ForeColor="Black" Font-Bold="True" Font-Size="Medium" />
                <HeaderStyle BackColor="Black"  ForeColor="#FF9900" Font-Bold="True" Font-Size="Large" Height="60px" Font-Strikeout="False" HorizontalAlign="Center" />
                <PagerStyle BackColor="Black" />

                <RowStyle BackColor="#FF9900"  Height="60px" CssClass="GridRow" BorderColor="Black" HorizontalAlign="Center"  ForeColor="Black" Wrap="True"  Font-Bold="True" Font-Size="Medium" BorderStyle="None" />

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
                        <br />
                        <asp:Button ID="addsubteacherbutton" Class="ButtonS3"  Font-Bold="true" ForeColor="#FFD800" Font-Size="Large" Text="ADD" BorderWidth="3" runat="server" OnClick="ADD_Click" /> <br /> <br />

                    </asp:TableCell>

                    <%--===================================================================CELL===============================================================>--%>
                    <asp:TableCell CssClass="FooterCellStyle" >

                        <asp:DropDownList  ID="FooterTName" Font-Size="Medium" Font-Bold="true" onmousedown="this.size=3;" onfocusout="this.size=1;" CssClass="DropDownStyle3" runat="server" ></asp:DropDownList>

                    </asp:TableCell>

                    <%--===================================================================CELL===============================================================>--%>
                    <asp:TableCell CssClass="FooterCellStyle" >

                        <asp:DropDownList  ID="FooterCName" Font-Size="Medium" Font-Bold="true" onmousedown="this.size=3;" onfocusout="this.size=1;" CssClass="DropDownStyle2" runat="server" ></asp:DropDownList>

                    </asp:TableCell>
                    <%--===================================================================CELL===============================================================>--%>
                    <asp:TableCell CssClass="FooterCellStyle" >

                        <asp:DropDownList  ID="FooterSName" Font-Size="Medium" Font-Bold="true" onmousedown="this.size=3;" onfocusout="this.size=1;" CssClass="DropDownStyle2" runat="server" ></asp:DropDownList>

                    </asp:TableCell>

                </asp:TableRow>
              

            </asp:Table>

        </div>

   
                             
            <br />       



       <section>
        

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

       <div runat="server" visible="false"  class="PopUpMessage" id="PopUpAccept">


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

                   
                    <asp:Button Class="ButtonS2" Font-Bold="True" Text="Accept" ID="Accept" runat="server" ForeColor="#FFD800" OnClick="Accept_Click" />
                    <asp:Button Class="ButtonS2" Font-Bold="True" Text="Cancel" ID="Cancel" runat="server" ForeColor="#FFD800" OnClick="Cancel_Click" />
                    
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
