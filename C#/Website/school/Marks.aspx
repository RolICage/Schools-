<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Marks.aspx.cs" Inherits="school.Marks" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
  <%--******************************************* Stylesheets ***************************************--%>
    <link href="Stylepage1.css" rel="stylesheet" />

    <link href="Items%20Design.css" rel="stylesheet" />
  <%--******************************************* Stylesheets END ***************************************--%>

<style <%--ScrollBar--%> >

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
    -webkit-border-radius: 10px; 
    -moz-border-radius: 10px; 
    border-radius: 10px;
    visibility: visible; 
        
}

/* Handle on hover */
::-webkit-scrollbar-thumb:hover { 
  visibility:visible;

}

</style>


<style>
    .EditGifMarks {
        height: 45px;
        width: 60px;
        -webkit-border-radius: 10px;
        -moz-border-radius: 10px;
        border-radius: 10px;
    }

    .HeaderCellStyleMarks {
        width: 150px;
        border: 20px;
        border-radius: 10px;
        background-color: black;
        font-size: large;
        text-align: center;
    }


    .FooterCellStyleMarks {
        width: 150px;
        border: 20px;
        border-radius: 10px;
        background-color: transparent;
        font-size: large;
        text-align: center;
    }

          
    .DropDownStyleMarks {
        color: black;
        width: 150px;
        font-size: 20px;
        padding: 5px 10px;
        border-radius: 12px 12px 12px 12px;;
        background-color: #F8B334;
        border-color: whitesmoke;
        border-width:2px;
        font-weight: bold;
        transition: 0.3s;
    }

    .LabelMarks {
        background-color: transparent;
        border-color: transparent;
        width: 110px;
        height: 100%;
        font-size: large;
        vertical-align: middle;
        text-align: center;
        color: #F8B334;
    }

    .DropDownStyleMarks {
        color: black;
        width: 150px;
        height: auto;
        font-size: 20px;
        padding: 5px 10px;
        border-radius: 12px 12px 12px 12px;
        background-color: #F8B334;
        border-color: whitesmoke;
        font-weight: bold;
        transition: 0.4s;
    }

    .DropDownStyleMarks2 {
        color: black;
        width: 150px;
        height: auto;
        font-size: 20px;
        padding: 5px 10px;
        border-radius: 12px 12px 12px 12px;
        background-color: #F8B334;
        border-color: whitesmoke;
        font-weight: bold;
        transition: 0.4s;
    }

    .ScrollDivMarks {
        width: 1505px;
        height: auto;
        max-height: 400px;
        overflow: auto;
        position: relative;
    }

    .ADDDELETEMarks {
        width: 150px;
        height: 35px;
        font-size: large;
        border-width: 3px;
        border-color: #FF9900;
        background-color: black;
        border-radius: 12px 12px 12px 12px;
        transition: 0.4s;
    }

    .ADDDELETEMarks:hover{
        background-color: dimgrey;
        border-color: yellow;
    }

    .DropDownStyleMarks:hover{
        background-color: dimgrey;
        border-color: yellow;
    }

/*===================== Back button Design =====================*/
/*===================== Back button Design =====================*/
.BackButton {
    height: 40px;
    width: 100px;
    background-color: black;
    border: solid;
    border-width: 2px;
    border-color: gold;
    -webkit-border-radius: 10px;
    -moz-border-radius: 10px;
    border-radius: 10px;
    margin-left: 700px;
    transition: 0.5s;
}

    .BackButton:hover {
        background-color: dimgrey;
    }

.href {
    margin: 13px;
    font-size: xx-large;
    font-style: oblique;
    color: chocolate;
    transition: 0.5s;
}

    .href:hover {
        color: yellow;
    }

</style>

</head>


<body>
    


    <%--============================= Form =============================--%>
    <%--============================= Form =============================--%>
    <form id="form1" runat="server"  >


        <div class="BackButton">
            <a Font-Bold="true" class="href" href="Choose.aspx" >BACK</a>
        </div>
        

        <div   >



        <%--============================= Search Option =============================--%>
        <%--============================= Search Option =============================--%>

       <div id="Div" runat="server" style="background-image: url( Images/GridEditRow.Gif );" class="search-box" >

            <asp:TextBox CssClass="search-txt" ID="TextFind" TextMode="Number" placeholder="Enter Student ID" Font-Bold="true"  runat="server"></asp:TextBox>  
  
            <asp:Button text="S" class="search-btn" ID="ButtonFind" runat="server" Font-Bold="true"  OnClick="ButtonFind_Click"  />   
            
            <asp:ImageButton ID="Refresh" class="search-btn" ImageUrl="Gifs/Refresh.Gif" runat="server" Font-Bold="true" OnClick="Refresh_Click"/>

       </div>

            
        <%--============================= Logo =============================--%>
        <%--============================= Logo =============================--%>

        <div class="alingLogo" align="right" >

         <img src="Images/Logo.png" alt="Alternate Text" Width="110px" height="100px" align="right" />

         </div>




<%--*************************************** Grid Header ***************************************
******************************************* Grid Header ***************************************
******************************************* Grid Header ***************************************--%>
            <asp:Table ID="Grid1HeaderTabel" Width="1500px"  CssClass="GridHeader" runat="server" >

<%--===================================================================Row===============================================================>--%>
                <asp:TableRow >

<%--===================================================================CELL===============================================================>--%>
                    <asp:TableCell CssClass="HeaderCellStyleMarks" BorderColor="Yellow" BorderWidth="2px" Width="150px" >

                        <img src="Gifs/3Lines2.gif" class="EditGifMarks"  />

                    </asp:TableCell>

<%--===================================================================CELL===============================================================>--%>
                    <asp:TableCell CssClass="HeaderCellStyleMarks" BorderColor="Yellow" BorderWidth="2px" Width="150px" >

                        <asp:Label ID="HeaderStudentName" CssClass="LabelMarks"  runat="server" Text="STUDENT ID"></asp:Label>

                    </asp:TableCell>
<%--===================================================================CELL===============================================================>--%>
                    <asp:TableCell CssClass="HeaderCellStyleMarks" BorderColor="Yellow" BorderWidth="2px" Width="150px" >

                        <asp:Label ID="HeaderSubName" CssClass="LabelMarks"  runat="server" Text="SUBJECT"></asp:Label>

                    </asp:TableCell>
<%--===================================================================CELL===============================================================>--%>
                    <asp:TableCell CssClass="HeaderCellStyleMarks" BorderColor="Yellow" BorderWidth="2px" Width="150px" >

                        <asp:Label ID="HeaderClassName" CssClass="LabelMarks"  runat="server" Text="CLASS"></asp:Label>

                    </asp:TableCell>
<%--===================================================================CELL===============================================================>--%>
                   <asp:TableCell CssClass="HeaderCellStyleMarks" BorderColor="Yellow" BorderWidth="2px" Width="150px" >

                        <asp:Label ID="HeaderMark" CssClass="LabelMarks"  runat="server" Text="MARK"></asp:Label>

                    </asp:TableCell>
<%--===================================================================CELL===============================================================>--%>
                   <asp:TableCell CssClass="HeaderCellStyleMarks" BorderColor="Yellow" BorderWidth="2px" Width="150px" >

                        <asp:Label ID="HeaderChapter" CssClass="LabelMarks"  runat="server" Text="CHAPTER"></asp:Label>

                    </asp:TableCell>
<%--===================================================================CELL===============================================================>--%>
                   <asp:TableCell CssClass="HeaderCellStyleMarks" BorderColor="Yellow" BorderWidth="2px" Width="150px" >

                        <asp:Label ID="HeaderKind" CssClass="LabelMarks"  runat="server" Text="KIND"></asp:Label>

                    </asp:TableCell>
<%--===================================================================CELL===============================================================>--%>
                   <asp:TableCell CssClass="HeaderCellStyleMarks" BorderColor="Yellow" BorderWidth="2px" Width="150px" >

                        <asp:Label ID="Headerpercentage" CssClass="LabelMarks"  runat="server" Text="PERCENTAGE"></asp:Label>

                    </asp:TableCell>


                </asp:TableRow>
              

            </asp:Table>


<%--*************************************** GridViewTecher ***************************************
******************************************* GridViewTecher ***************************************
******************************************* GridViewTecher ***************************************--%>

              <div id="GRIDVDIV" runat="server" class="ScrollDivMarks" >

            
              <asp:GridView ID="Grid1" ShowFooter="false" ShowHeader="false" runat="server" OnRowCommand="Grid1_RowCommand" style=" overflow:auto; max-height:500px"
              AutoGenerateColumns="False" OnRowEditing="Grid1_RowEditing" OnRowCancelingEdit="Grid1_RowCancelingEdit"
              OnRowUpdating="Grid1_RowUpdating" BorderColor="black"  CellPadding="5" CellSpacing="5" OnRowDeleting="Grid1_RowDeleting" Font-Bold="True" 
              Font-Names="Franklin Gothic Medium" Font-Overline="False" Font-Size="Medium" Font-Strikeout="False" Font-Underline="false" ForeColor="Black"
              OnSelectedIndexChanged="Grid1_SelectedIndexChanged" HorizontalAlign="Center" BorderStyle="None" OnRowDataBound="Grid1_RowDataBound" Width="1490px" >

<%--==================================================================== Columns ====================================================================--%>
<%--==================================================================== Columns ====================================================================--%>
              <Columns >  

<%--==================================================================== TemplateField EDIT ====================================================================--%>
<%--==================================================================== TemplateField EDIT ====================================================================--%>
              <asp:TemplateField ItemStyle-Width="165px" >
  
              <%--============================= Item Template =============================--%>
              <%--============================= Item Template =============================--%>
              <ItemTemplate >
    
              <asp:Button   Class="ADDDELETEMarks"  CommandName="Edit" CommandArgument='<%# Container.DataItemIndex %>' ToolTip="Edit"
                Font-Bold="true" Font-Size="Medium" Text="EDIT"  ForeColor="#FFD800" ID="Edit" runat="server"  />             
                       
              <asp:Button  Class="ADDDELETEMarks" CommandArgument='<%# Eval("Cnt")%>'  CommandName="Delete" ToolTip="Delete"
                Font-Bold="true" Font-Size="Medium" Text="Delete" ForeColor="#FFD800" ID="Delete" runat="server" />
             
              </ItemTemplate>


              <%--============================= Edit Template =============================--%>
              <%--============================= Edit Template =============================--%>
              <EditItemTemplate >
           
              <asp:Button  CommandName="Update" CommandArgument='<%# Eval("Cnt")%>' Class="ButtonS2" ToolTip="Update" Font-Bold="true" Font-Size="Medium" Text="Update" ForeColor="#FFD800"  ID="Update" runat="server" />
              <asp:Button CommandName="Cancel" Class="ButtonS2" ToolTip="Cancel" Font-Bold="true" Font-Size="Medium" Text="Cancel" ForeColor="#FFD800"  ID="Cancel" runat="server" />

              </EditItemTemplate>
            
              </asp:TemplateField>


<%--==================================================================== TemplateField Student  ====================================================================--%>
<%--==================================================================== TemplateField Student  ====================================================================--%>

                      <asp:TemplateField ItemStyle-Width="150px" >
                        <%--============================= Item Template =============================--%>
                        <%--============================= Item Template =============================--%>
                        <ItemTemplate >

                            <div class="GridRowMaxWidth" >

                            <asp:Label ID="LabelStudentName" CssClass="DropDownStyleMarks2" BorderWidth="1px" BorderColor="Black"  Height="20px" runat="server" Text='<%# Eval("Student")%>'></asp:Label>                                                                                     

                            </div>
                                              
                        </ItemTemplate>

                        <%--============================= Edit Template =============================--%>
                        <%--============================= Edit Template =============================--%>
                        <EditItemTemplate>

                            <asp:TextBox ID="TextBoxStudentName" Font-Size="Medium" Font-Bold="true" CssClass="DropDownStyleMarks"  Height="20px" runat="server" Text='<%# Eval("Student")%>'></asp:TextBox> 

                        </EditItemTemplate>
                     
                     
                    </asp:TemplateField>

                    

<%--==================================================================== TemplateField Subjects ====================================================================--%>
<%--==================================================================== TemplateField Subjects ====================================================================--%>

                    <asp:TemplateField ItemStyle-Width="150px"  >

                        <%--============================= CLASS =============================--%>
                        <%--============================= CLASS =============================--%>
                        <ItemTemplate>

                            <asp:Label ID="LabelSubjectName" CssClass="DropDownStyleMarks" BorderWidth="1px" brodercolor="black" Width="140px" Height="20px" runat="server" BorderColor="Black" BackColor="#F8B334" Text='<%# Eval("Subject")%>'></asp:Label>

                        </ItemTemplate>

                        <%--============================= Edit Template =============================--%>
                        <%--============================= Edit Template =============================--%>
                        <EditItemTemplate>

                            <asp:Label ID="EditLabelSubjectName" CssClass="DropDownStyleMarks" BorderWidth="1px" brodercolor="black" Width="140px" Height="20px" runat="server" BorderColor="Black" BackColor="#F8B334" Text='<%# Eval("Subject")%>'></asp:Label>
                            
                        </EditItemTemplate>
                      
                    </asp:TemplateField>


<%--==================================================================== TemplateField Class ====================================================================--%>
<%--==================================================================== TemplateField Class ====================================================================--%>


                    <asp:TemplateField ItemStyle-Width="150px"  >

                        <%--============================= CLASS =============================--%>
                        <%--============================= CLASS =============================--%>
                        <ItemTemplate>

                            <asp:Label ID="LabelClassName" CssClass="DropDownStyleMarks" BorderWidth="1px" brodercolor="black" Height="20px" runat="server" BorderColor="Black" BackColor="#F8B334" Text='<%# Eval("Class")%>'></asp:Label>

                        </ItemTemplate>

                        <%--============================= Edit Template =============================--%>
                        <%--============================= Edit Template =============================--%>
                        <EditItemTemplate>
                   
                            <asp:Label ID="EditLabelClassName" CssClass="DropDownStyleMarks" BorderWidth="1px" brodercolor="black" Height="20px" runat="server" BorderColor="Black" BackColor="#F8B334" Text='<%# Eval("Class")%>'></asp:Label>
                            
                        </EditItemTemplate>
                      
                      
                    </asp:TemplateField>


<%--==================================================================== TemplateField Mark ====================================================================--%>
<%--==================================================================== TemplateField Mark ====================================================================--%>

                    <asp:TemplateField ItemStyle-Width="150px"  >

                        <%--============================= CLASS =============================--%>
                        <%--============================= CLASS =============================--%>
                        <ItemTemplate>

                            <asp:Label ID="LabelMark" CssClass="DropDownStyleMarks" BorderWidth="1px" brodercolor="black" Height="20px" runat="server" BorderColor="Black" BackColor="#F8B334" Text='<%# Eval("Mark")%>'></asp:Label>

                        </ItemTemplate>

                        <%--============================= Edit Template =============================--%>
                        <%--============================= Edit Template =============================--%>
                        <EditItemTemplate>
                                                                                                                                                        
                            <asp:TextBox ID="TextBoxMark" Font-Size="Medium" Font-Bold="true" CssClass="DropDownStyleMarks"  Height="20px" runat="server" Text='<%# Eval("Mark")%>' ></asp:TextBox>
                            
                        </EditItemTemplate>
                      
                      
                    </asp:TemplateField>


<%--==================================================================== TemplateField Chapter ====================================================================--%>
<%--==================================================================== TemplateField Chapter ====================================================================--%>


                    <asp:TemplateField ItemStyle-Width="150px"  >

                        <%--============================= Chapter =============================--%>
                        <%--============================= Chapter =============================--%>
                        <ItemTemplate>

                            <asp:Label ID="LabelChapter" CssClass="DropDownStyleMarks" BorderWidth="1px" brodercolor="black" Height="20px" runat="server" BorderColor="Black" BackColor="#F8B334" Text='<%# Eval("Chapter")%>'></asp:Label>

                        </ItemTemplate>

                        <%--============================= Edit Template =============================--%>
                        <%--============================= Edit Template =============================--%>
                        <EditItemTemplate>
                                                                                                                                                         
                            <asp:DropDownList  ID="DropDownChapter" Font-Size="Medium" Font-Bold="true" CssClass="DropDownStyleMarks"  Height="33px" runat="server" ></asp:DropDownList>
                            
                        </EditItemTemplate>
                      
                      
                    </asp:TemplateField>

<%--==================================================================== TemplateField Kind ====================================================================--%>
<%--==================================================================== TemplateField Kind ====================================================================--%>

                    <asp:TemplateField ItemStyle-Width="150px"  >

                        <%--============================= Kind =============================--%>
                        <%--============================= Kind =============================--%>
                        <ItemTemplate>

                            <asp:Label ID="KindChapter" CssClass="DropDownStyleMarks" BorderWidth="1px" brodercolor="black" Height="20px" runat="server" BorderColor="Black" BackColor="#F8B334" Text='<%# Eval("Kind")%>'></asp:Label>

                        </ItemTemplate>

                        <%--============================= Edit Template =============================--%>
                        <%--============================= Edit Template =============================--%>
                        <EditItemTemplate>
                                                                                                                                                         
                            <asp:DropDownList  ID="DropDownKind" Font-Size="Medium" Font-Bold="true" CssClass="DropDownStyleMarks"  Height="33px" runat="server" ></asp:DropDownList>
                            
                        </EditItemTemplate>
                      
                      
                   </asp:TemplateField>


<%--==================================================================== TemplateField percentage ====================================================================--%>
<%--==================================================================== TemplateField percentage ====================================================================--%>

                    <asp:TemplateField ItemStyle-Width="150px"  >

                        <%--============================= percentage =============================--%>
                        <%--============================= percentage =============================--%>
                        <ItemTemplate>

                            <asp:Label ID="percentageChapter" CssClass="DropDownStyleMarks" BorderWidth="1px" brodercolor="black" Height="20px" runat="server" BorderColor="Black" BackColor="#F8B334" Text='<%# Eval("percentage")%>'></asp:Label>


                        </ItemTemplate>

                        <%--============================= Edit Template =============================--%>
                        <%--============================= Edit Template =============================--%>
                        <EditItemTemplate>
                                                                                                                                                         
                            <asp:TextBox ID="DropDownpercentage" Font-Size="Medium" Font-Bold="true" CssClass="DropDownStyleMarks"  Height="33px" runat="server" Text='<%# Eval("percentage")%>'></asp:TextBox>
                            
                        </EditItemTemplate>
                      
                      
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
            <asp:Table ID="Grid1FooterTabel" Width="1500px" CssClass="GridFooter" runat="server">


                <asp:TableRow >

                    <%--===================================================================CELL===============================================================>--%>
                    <asp:TableCell CssClass="FooterCellStyleMarks"  Width="150px" >
                        <br />
                        <asp:Button Class="ButtonSADD"  Font-Bold="true" ForeColor="#FFD800" Font-Size="Large" Text="ADD" BorderWidth="3" Width="110px" Height="35px" runat="server" OnClick="ADD_Click" /> <br /> <br />

                    </asp:TableCell>

                    <%--===================================================================CELL===============================================================>--%>
                    <asp:TableCell CssClass="FooterCellStyleMarks"  Width="150px" >

                        <asp:TextBox ID="FooterStudentName" Font-Size="Medium" TextMode="Number" Font-Bold="true" CssClass="DropDownStyleMarks"   Height="20px" runat="server"></asp:TextBox>

                    </asp:TableCell>

                    <%--===================================================================CELL===============================================================>--%>
                    <asp:TableCell CssClass="FooterCellStyleMarks"  Width="150px" >

                        <asp:DropDownList  ID="FooterSName" Font-Size="Medium" Font-Bold="true" CssClass="DropDownStyleMarks"  Height="33px" runat="server" ></asp:DropDownList>

                    </asp:TableCell>

                    <%--===================================================================CELL===============================================================>--%>
                    <asp:TableCell CssClass="FooterCellStyleMarks"  Width="150px" >

                        <asp:DropDownList  ID="FooterCName" Font-Size="Medium" Font-Bold="true" CssClass="DropDownStyleMarks"  Height="33px" runat="server" ></asp:DropDownList>

                    </asp:TableCell>
                    <%--===================================================================CELL===============================================================>--%>
                    <asp:TableCell CssClass="FooterCellStyleMarks"  Width="150px" >

                        <asp:TextBox ID="FooterMark" TextMode="Number" Font-Size="Medium" Font-Bold="true" CssClass="DropDownStyleMarks"  Height="20px" runat="server"></asp:TextBox>

                    </asp:TableCell>
                    <%--===================================================================CELL===============================================================>--%>
                    <asp:TableCell CssClass="FooterCellStyleMarks"  Width="150px" >

                        <asp:DropDownList  ID="FooterChapter" Font-Size="Medium" Font-Bold="true" CssClass="DropDownStyleMarks"  Height="33px" runat="server" ></asp:DropDownList>

                    </asp:TableCell>
                    <%--===================================================================CELL===============================================================>--%>
                    <asp:TableCell CssClass="FooterCellStyleMarks"  Width="150px" >

                        <asp:DropDownList  ID="FooterKind" Font-Size="Medium" Font-Bold="true" CssClass="DropDownStyleMarks"  Height="33px" runat="server" ></asp:DropDownList>

                    </asp:TableCell>
                    <%--===================================================================CELL===============================================================>--%>
                    <asp:TableCell CssClass="FooterCellStyleMarks"  Width="150px" >

                        <asp:TextBox ID="Footerpercentage" TextMode="Number" Font-Size="Medium" Font-Bold="true" CssClass="DropDownStyleMarks"   Height="20px" runat="server"></asp:TextBox>

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



<%--*************************************** Tests ***************************************
******************************************* Tests ***************************************
******************************************* Tests ***************************************--%>


 



<%--*************************************** Tests END ***************************************
******************************************* Tests END ***************************************
******************************************* Tests END ***************************************--%>


       </section>
    </form>
</body>



</html>
