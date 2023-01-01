<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Techers.aspx.cs" Inherits="school.Techers" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">


<%--///////////////////////////////////////////////////////// Stylesheet
    ///////////////////////////////////////////////////////// Stylesheet--%>

    <link href="Stylepage1.css" rel="stylesheet" />
    <link href="FinalStyleXX.css" rel="stylesheet" />

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

.ButtonS3:hover{
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


    .DropDownPhone {
        height: 45px;
        width: 60px;
        border-top-left-radius: 15px 10px;
        border-bottom-left-radius: 15px 10px;
        background-color:orange;
        color:black;
        font-size:large;
        font-family: ArabicFont;
    }

    .TextPhone {
        width: 120px;
        height: 35px;
        background-color: transparent;
        border-color: transparent;
        color:orange;
        font-size:medium;
        font-family: ArabicFont;
    }

    .divPhone {
        width: 200px;
        height: 45px;
        max-height: 45px;
        border-top-left-radius: 15px 10px;
        border-bottom-left-radius: 15px 10px;
        border-top-right-radius: 15px 10px;
        border-bottom-right-radius: 15px 10px;
        border: 1px solid Black;
    }


     .HeaderCellStyleTeachers {
         width:200px;
         border: 2.2px solid #BDC3C7;
         border-radius: 5px;
         background-color: black;
         font-size: large;
         box-shadow: inset 0 0 10px #BDC3C7;
         text-align: center;
     }

     .LabelStudents {
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


    ::-webkit-input-placeholder { /* Safari, Chrome and Opera */
        color: #273746;
    }

    :-moz-placeholder { /* Firefox */
        color: #273746;
    }

    :-ms-input-placeholder { /* IE 10+ */
        color: #273746;
    }

    ::-ms-input-placeholder { /* Edge */
        color: #273746;
    }

    :placeholder-shown { /* Default */
        color: #273746;
    }
</style>


</head>


    <title></title>

<body>


    <%--============================= Form =============================--%>
    <%--============================= Form =============================--%>
    <form id="form1" runat="server" onsubmit="ShowLoading()" >
      
        
<asp:Button ID="BackClick" class="BackButton" Font-Bold="true" OnClick="BackClick_Click" runat="server" Text="⟸" />

        <%--============================= Search Option =============================--%>
        <%--============================= Search Option =============================--%>


      <div id="Div" runat="server" style="background-image: url( Images/GridEditRow.Gif )" class="search-box" >

            <asp:TextBox CssClass="search-txt" ID="TextFind" TextMode="Number" min="1" max="999999999" placeholder="ENTER TECHER ID" Font-Bold="true"  runat="server"></asp:TextBox>  
  
            <asp:Button text="S" class="search-btn" ID="ButtonFind" runat="server" Font-Bold="true"  OnClick="ButtonFind_Click"  />   
            
            <asp:ImageButton ID="ImageButton1" class="search-btn" ImageUrl="Gifs/Refresh.Gif" runat="server" Font-Bold="true" OnClick="ImageButton1_Click" />

       </div>


        <%--============================= Logo =============================--%>
        <%--============================= Logo =============================--%>
        <div align="left" >

         <img src="Images/Logo.png" alt="Alternate Text" Width="110px" height="100px" align="Right" />

         </div  >


        <br />
        <br />

        <%--============================= Search Option =============================--%>
        <%--============================= Search Option =============================--%>



<%--*************************************** Grid Header ***************************************
******************************************* Grid Header ***************************************
******************************************* Grid Header ***************************************--%>
            <asp:Table ID="Grid1HeaderTabel" CssClass="GridHeader" runat="server" >

<%--===================================================================Row===============================================================>--%>
                <asp:TableRow >

<%--===================================================================CELL===============================================================>--%>
                    <asp:TableCell CssClass="HeaderCellStyleTeachers" style="box-shadow: inset 0 0 0px #00000000;" Width="225px" >

                        <img src="Gifs/3Lines.gif" class="EditGif" />

                    </asp:TableCell>

<%--===================================================================CELL===============================================================>--%>
                    <asp:TableCell CssClass="HeaderCellStyleTeachers"  >

                        <asp:Label ID="HeaderTecherName" CssClass="LabelStudents"  runat="server" Text="TEACHER NAME"></asp:Label>

                    </asp:TableCell>

<%--===================================================================CELL===============================================================>--%>
                    <asp:TableCell CssClass="HeaderCellStyleTeachers" >

                        <asp:Label ID="HeaderTID" CssClass="LabelStudents"  runat="server" Text="TECHER ID"></asp:Label>

                    </asp:TableCell>

<%--===================================================================CELL===============================================================>--%>
                    <asp:TableCell CssClass="HeaderCellStyleTeachers" >

                        <asp:Label ID="HeaderPhone" CssClass="LabelStudents" runat="server" Text="Phone"></asp:Label>

                    </asp:TableCell>


                </asp:TableRow>
              

            </asp:Table>


<%--*************************************** GridViewTecher ***************************************
******************************************* GridViewTecher ***************************************
******************************************* GridViewTecher ***************************************--%>
              <div id="GRIDVDIV" runat="server" class="ScrollDiv" onscroll="SetDivPosition()">

            
              <asp:GridView ID="Grid1" ShowFooter="false" ShowHeader="false" CssClass="rcgv" runat="server" OnRowCommand="Grid1_RowCommand" style=" overflow:auto; max-height:500px"
              AutoGenerateColumns="False" DataKeyNames="TID" OnRowEditing="Grid1_RowEditing" OnRowCancelingEdit="Grid1_RowCancelingEdit"
              OnRowUpdating="Grid1_RowUpdating" BorderColor="Transparent" CellPadding="5" CellSpacing="5" OnRowDeleting="Grid1_RowDeleting" Font-Bold="True" 
              Font-Names="Franklin Gothic Medium" Font-Overline="False" Font-Size="Medium" Font-Strikeout="False" Font-Underline="True" ForeColor="Black"
              OnSelectedIndexChanged="Grid1_SelectedIndexChanged" HorizontalAlign="Center" BorderStyle="None" OnRowDataBound="Grid1_RowDataBound" Width="1180px" >

<%--==================================================================== Columns ====================================================================--%>
<%--==================================================================== Columns ====================================================================--%>
              <Columns >  

<%--==================================================================== TemplateField EDIT ====================================================================--%>
<%--==================================================================== TemplateField EDIT ====================================================================--%>
              <asp:TemplateField ItemStyle-Width="250px"  >
  
              <%--============================= Item Template =============================--%>
              <%--============================= Item Template =============================--%>
              <ItemTemplate >
    
              <asp:Button  CommandArgument='<%# Container.DataItemIndex %>' Class="ButtonS" Height="30px" Width="120px" CommandName="Edit"  ToolTip="Edit"
                Font-Bold="true" Font-Size="Medium" Text="EDIT"  ForeColor="#FFD800" ID="Edit" runat="server"  />             
                       
              <asp:Button CommandArgument='<%# Eval("TID")%>' Class="ButtonS" Height="30px" Width="120px" CommandName="Delete" ToolTip="Delete"
                Font-Bold="true" Font-Size="Medium" Text="Delete" ForeColor="#FFD800" ID="Delete" runat="server" Style="color:crimson" />

                  <br />

              <asp:Button CommandArgument='<%# Eval("TID")%>' Class="ButtonS" Height="30px" Width="170px" CommandName="FindPass" Font-Bold="true" 
                  Font-Size="Medium" Text="Show Password" ForeColor="#FFD800" ID="showpassbutton" runat="server" Style="background-image:url('Gifs/Delete.gif');" />
             
              </ItemTemplate>


              <%--============================= Edit Template =============================--%>
              <%--============================= Edit Template =============================--%>
              <EditItemTemplate >
           
              <asp:Button  CommandName="Update" Class="ButtonS" ToolTip="Update" Font-Bold="true" Font-Size="Medium" Text="Update" ForeColor="#FFD800" Width="120px" Height="30px"  ID="Update" runat="server" />
              <asp:Button CommandName="Cancel" Style="color:crimson" Class="ButtonS" ToolTip="Cancel" Font-Bold="true" Font-Size="Medium" Text="Cancel" ForeColor="#FFD800" Width="120px" Height="30px" ID="Cancel" runat="server" />
              <br />
              <br />
              <asp:Button CommandArgument='<%# Eval("TID")%>' CommandName="ChangeID" Class="ButtonS" ID="ChangeID" Font-Bold="true" ForeColor="#FFD800"  Text="ChangeID"  Width="243px" Height="35px" runat="server" />

              </EditItemTemplate>

            
              </asp:TemplateField>


<%--==================================================================== TemplateField Techer Name ====================================================================--%>
<%--==================================================================== TemplateField Techer Name ====================================================================--%>

                    <asp:TemplateField HeaderText="TECHER NAME" ItemStyle-Width="220px" >

                        <%--============================= Item Template =============================--%>
                        <%--============================= Item Template =============================--%>
                        <ItemTemplate >

                            <div class="GridRowMaxWidth" >

                            <asp:Label ID="LabelTName" style="color:darkblue" Font-Underline="true" CssClass="GridViewLabe2" Width="130px" runat="server"  Text='<%# Eval("TName")%>'></asp:Label>                                                                                     

                            </div>
                            
                        <%--============================= Edit Template =============================--%>
                        <%--============================= Edit Template =============================--%>
                        </ItemTemplate>

                        <EditItemTemplate>
                            <asp:TextBox  Text='<%# Eval("TName")%>' ID="TextBoxTName" MaxLength="15" Font-Size="Medium" Font-Bold="true" Height="30px" CssClass="GridViewTextBox" runat="server"></asp:TextBox>
                        </EditItemTemplate>
                     
                    </asp:TemplateField>

                    

<%--==================================================================== TemplateField TecherID ====================================================================--%>
<%--==================================================================== TemplateField TecherID ====================================================================--%>

                    <asp:TemplateField HeaderText="CLASS CODE" ItemStyle-Width="220px">

                        <%--============================= TecherID =============================--%>
                        <%--============================= TecherID =============================--%>
                        <ItemTemplate>

                            <asp:Label ID="LabelTecherID" CssClass="mydropdownlist" BorderWidth="1px" brodercolor="black" Width="140px" Height="20px" runat="server" BorderColor="Black" BackColor="#F8B334" Text='<%# Eval("TID")%>'></asp:Label>

                        </ItemTemplate>

                        <%--============================= Edit Template =============================--%>
                        <%--============================= Edit Template =============================--%>
                        <EditItemTemplate>

                            <img src="Gifs/lockgifid.gif" height="52px" width="47px" align="center" />

                            <br />
                                                                                                                                                         
                            <asp:Label ID="TecherID" runat="server" CssClass="mydropdownlist" Height="17px" Width="115px" TextMode="Number"  Text='<%# Eval("TID")%>'></asp:Label>   
                            
                        </EditItemTemplate>
                      
                    </asp:TemplateField>


<%--==================================================================== TemplateField Phone ====================================================================--%>
<%--==================================================================== TemplateField Phone ====================================================================--%>

                    <asp:TemplateField HeaderText="CLASS CODE" ItemStyle-Width="220px">

                        <%--============================= TecherID =============================--%>
                        <%--============================= TecherID =============================--%>
                        <ItemTemplate>

                            <asp:Label ID="LabelTecherPhone" CssClass="mydropdownlist" BorderWidth="1px" brodercolor="black" Width="140px" Height="20px" runat="server" BorderColor="Black" BackColor="#F8B334" Text='<%# Eval("Phone")%>'></asp:Label>

                        </ItemTemplate>

                        <%--============================= Edit Template =============================--%>
                        <%--============================= Edit Template =============================--%>
                        <EditItemTemplate>
                                                                                                                                                         
      <%--============ DivPhoneNum ============= >--%>          
      <div class="divPhone" style="background-image: url( Gifs/graygif.Gif ); margin-left:50px; height:35px; width:180px" >

            <asp:DropDownList CssClass="DropDownPhone" Height="35px" Font-Bold="true" ID="EditPhoneDrop" runat="server">

                    <asp:ListItem Text="050" Value="050"></asp:ListItem>
                    <asp:ListItem Text="052" Value="052"></asp:ListItem>
                    <asp:ListItem Text="054" Value="054"></asp:ListItem>

            </asp:DropDownList>

            <asp:TextBox CssClass="TextPhone" placeholder="STUDENT PHONE" ForeColor="Black" style="width:108px; height:25px; font-size:medium" Font-Bold="true" ID="EditPhone" TextMode="Number" min="7" max="9999999" runat="server"></asp:TextBox>

      </div>
                            
                        </EditItemTemplate>
                      
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

                        <asp:Button ID="addteacherbutton" Class="ButtonS3"  Font-Bold="true" ForeColor="#FFD800" Font-Size="Large" Text="ADD" BorderWidth="3" runat="server" OnClick="ADD_Click" /> <br /> <br />

                    </asp:TableCell>

                    <%--===================================================================CELL===============================================================>--%>
                    <asp:TableCell CssClass="FooterCellStyle" >

                        <asp:TextBox ID="FooterTName" Font-Size="Medium" MaxLength="15" Font-Bold="true" CssClass="GridViewTextBox" Height="30px" runat="server"></asp:TextBox>

                    </asp:TableCell>

                    <%--===================================================================CELL===============================================================>--%>
                    <asp:TableCell CssClass="FooterCellStyle" >

                        <asp:TextBox ID="FooterTecherID" TextMode="Number" Font-Size="Medium" Font-Bold="true" CssClass="GridViewTextBox" Height="30px" runat="server"></asp:TextBox>

                    </asp:TableCell>

                    <%--===================================================================CELL===============================================================>--%>
                    <asp:TableCell CssClass="FooterCellStyle" >

                                            
      <%--============ DivPhoneNum ============= >--%>          
      <div class="divPhone" style="background-image: url( Gifs/graygif.Gif ); margin-left:50px; height:35px; width:180px" >

            <asp:DropDownList CssClass="DropDownPhone" Height="35px" Font-Bold="true" ID="FooterPhoneDrop2" runat="server">

                    <asp:ListItem Text="050" Value="050"></asp:ListItem>
                    <asp:ListItem Text="052" Value="052"></asp:ListItem>
                    <asp:ListItem Text="054" Value="054"></asp:ListItem>

            </asp:DropDownList>

            <asp:TextBox CssClass="TextPhone" placeholder="STUDENT PHONE" ForeColor="Black" style="width:112px; height:25px; font-size:medium" Font-Bold="true" ID="FooterPhone2" TextMode="Number" min="7" max="9999999" runat="server"></asp:TextBox>

      </div>

                    </asp:TableCell>

                </asp:TableRow>
              

            </asp:Table>

            
                             
            <br />             


<%--*************************************** GridViewChangeID ***************************************
******************************************* GridViewChangeID ***************************************
******************************************* GridViewChangeID ***************************************--%>            
            <div id="ChangeIDPopUp" runat="server" class="ChangeIDPopUp" >


            <br /> <br />
            <br /> <br />
            <br /> <br />
            <br /> <br />
            <br /> <br />
            <br /> <br />
            <br /> <br />
            <br /> <br />
            <br /> <br />
            <br /> <br />

              <asp:GridView ID="Grid2" runat="server" BackColor="Black" ShowFooter="true"  OnRowCommand="Grid1_RowCommand"
              AutoGenerateColumns="False"   DataKeyNames="TID"  OnRowUpdating="Grid2_RowUpdating" BorderColor="Transparent"
              CellPadding="2" CellSpacing="2" Font-Bold="True" Font-Names="Franklin Gothic Medium" CssClass="rcgv"
              Height="70px" HorizontalAlign="Center" Width="420px"              
              Font-Overline="False" Font-Size="Medium" Font-Strikeout="False" Font-Underline="True" ForeColor="Black"   OnRowCancelingEdit="Grid2_RowCancelingEdit" >

<%--==================================================================== Columns ====================================================================--%>
<%--==================================================================== Columns ====================================================================--%>
                <Columns>  

<%--==================================================================== TemplateField Class Name ====================================================================--%>
<%--==================================================================== TemplateField Class Name ====================================================================--%>
            


<%--============================= Item Template =============================--%>
<%--============================= Item Template =============================--%>
            <asp:TemplateField>

             <HeaderTemplate>

                 <img src="Gifs/3Lines.gif"  alt="gif image" align="center" class="EditGif" />

             </HeaderTemplate>  

             <ItemTemplate>

             <br />
             <asp:Button CommandName="Update" CssClass="ButtonS" ToolTip="Update" Font-Bold="true" Font-Size="Medium" Text="Update" Height="30px" Width="200px" BackColor="Black" ForeColor="#f6be00" BorderColor="#f6be00"   ID="Update" runat="server" /> 
             <br />
             <br />
             <asp:Button CommandName="Cancel" CssClass="ButtonS" ToolTip="Cancel" Font-Bold="true" Font-Size="Medium" Text="Cancel" Height="30px" Width="200px" BackColor="Black" ForeColor="#f6be00" BorderColor="#f6be00"   ID="Cancel" runat="server" />
             <br />
             </ItemTemplate>

            </asp:TemplateField>
          
             
<%--==================================================================== TemplateField Class Code ====================================================================--%>
<%--==================================================================== TemplateField Class Code ====================================================================--%> 
             


<%--============================= Item Template =============================--%>
<%--============================= Item Template =============================--%>
                    <asp:TemplateField HeaderText="TecherID">

                        <ItemTemplate >

                            <asp:TextBox ID="TextTecherID" TextMode="Number" CssClass="GridViewTextBox" runat="server" Height="30px" Width="170px" Font-Size="Medium" Font-Bold="true" BorderColor="#FF9900"   Text='<%# Eval("TID")%>' ></asp:TextBox>
                                                       
                        </ItemTemplate>      
                        
                    </asp:TemplateField>


               </Columns>  

<%--==================================================================== Grid Styles ====================================================================--%>
<%--==================================================================== Grid Styles ====================================================================--%>
                <EditRowStyle BackColor="#CCCCCC" BorderColor="Black" />

                <FooterStyle BackColor="Black" BorderColor="Transparent" ForeColor="Black" Font-Size="Medium" Height="30px" />
                <HeaderStyle BackColor="Black" BorderStyle="Double" BorderWidth="2px" ForeColor="#FF9900" Font-Size="Medium" Height="60px" />
                <PagerStyle BackColor="Black" />

                <RowStyle BackColor="#CCCCCC" BorderStyle="None"  ForeColor="Black" BorderColor="Black" BorderWidth="2px" Height="40px" />

                <SelectedRowStyle BackColor="#CCCCCC" />

              </asp:GridView>


              </div>      



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


 



<%--*************************************** Tests END ***************************************
******************************************* Tests END ***************************************
******************************************* Tests END ***************************************--%>
  

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

    </form>
</body>
</html>
