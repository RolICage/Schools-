<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Parents.aspx.cs" Inherits="school.WebForm2" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>

    <%--<script type="text/html">

        $(document).ready(function () {
            var maxlen = 9;

            $("#TextPhoneNumber").keypress(function (k) {

                if (this.val.length >= maxlen) {
                    k.preventDefault();
                    alert('out of length' + maxlen);
                }

            });

        });
    </script>--%>

    <link href="Stylepage1.css" rel="stylesheet" />
    <link href="FinalStyleXX.css" rel="stylesheet" />
    <style>

</style>


 <style type="text/css">
        .FixedHeader {
            position: absolute;
            font-weight: bold;
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

.DropDownStyle2 {
    color: black;
    width: 120px;
    font-size: 20px;
    padding: 5px 10px;
    border-radius: 5px 12px;
    background-color: #F8B334;
    border-color: whitesmoke;
    font-weight: bold;
}

.DropDownStyle2:hover {
    width: 140px;
}

.GridViewTextBoxp {
    font-family: ArabicFont;
    background-color: #808080;
    border-color: #FF9900;
    -webkit-border-radius: 10px;
    -moz-border-radius: 10px;
    border-radius: 10px;
    width: 150px;
    height: 35px;
    font-size: large;
    text-align: center;
}

.search-boxp {
    margin-top: 61px;
    margin-left: 160px;
    z-index: 1;
    position: absolute;
    transform: translate(-50%,-50%);
    background: #2b2b2b;
    height: 35px;
    border-radius: 30px;
    padding: 10px;
    background: #212000;
}

        .ButtonS3 {
            font-family: ArabicFont;
            width: 243px;
            height: 35px;
            font-size: large;
            border-width: 3px;
            border-color: #FF9900;
            background-color: black;
            border-radius: 5px 12px;
        }


        .GridViewLabep {
            font-family: ArabicFont;
            background-color: #FF9900;
            -webkit-border-radius: 10px;
            -moz-border-radius: 10px;
            border: 2px solid transparent;
            border-radius: 10px;
            width: 200px;
            height: 28px;
            color: black;
            font-size: large;
            text-align: left;
            vertical-align: middle;
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
    margin-top:60px;
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

     .HeaderCellStyleParents {
         width:200px;
         border: 2.2px solid #BDC3C7;
         border-radius: 5px;
         background-color: black;
         font-size: large;
         box-shadow: inset 0 0 10px #BDC3C7;
         text-align: center;
     }

     .LabelParents {
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
<body   >

    <form id="form1" runat="server" onsubmit="ShowLoading()" >

<asp:Button ID="BackClick" class="BackButton" Font-Bold="true" OnClick="BackClick_Click" runat="server" Text="⟸" />

            <br />

        <%--============================= Search Option =============================--%>
        <%--============================= Search Option =============================--%>

       <div id="Div" runat="server" style="background-image: url( Images/GridEditRow.Gif );" class="search-box" >

            <asp:TextBox CssClass="search-txt" ID="TextFind" TextMode="Number" min="1" max="999999999" placeholder="ENTER PARENT ID" Font-Bold="true"  runat="server"></asp:TextBox>  
  
            <asp:Button text="S" class="search-btn" ID="ButtonFind" runat="server" Font-Bold="true"  OnClick="ButtonFind_Click1" />   
            
            <asp:ImageButton ID="ImageButton1" class="search-btn" ImageUrl="Gifs/Refresh.Gif" runat="server" Font-Bold="true" OnClick="ImageButton1_Click" />

       </div>
          
          
     <div    >
         <img src="Images/Logo.png" alt="Alternate Text" Width="110px" height="100px" align="Right" />
     </div  >




<%--*************************************** Grid Header ***************************************
******************************************* Grid Header ***************************************
******************************************* Grid Header ***************************************--%>
            <asp:Table ID="Grid1HeaderTabel" CssClass="GridHeader" runat="server" >


                <asp:TableRow >

<%--===================================================================CELL===============================================================>--%>
                    <asp:TableCell CssClass="HeaderCellStyleParents" style="box-shadow: inset 0 0 0px #00000000;" Width="225px" >

                        <img src="Gifs/3Lines.gif" class="EditGif" />

                    </asp:TableCell>

                    <%--===================================================================CELL===============================================================>--%>
                    <asp:TableCell CssClass="HeaderCellStyleParents"  >

                        <asp:Label ID="HeaderPName" CssClass="LabelParents"  runat="server" Text="Parent Name"></asp:Label>

                    </asp:TableCell>
                    <%--===================================================================CELL===============================================================>--%>
                    <asp:TableCell CssClass="HeaderCellStyleParents"  >

                        <asp:Label ID="HeaderPID" CssClass="LabelParents"  runat="server" Text="Parent ID"></asp:Label>

                    </asp:TableCell>
                    <%--===================================================================CELL===============================================================>--%>
                    <asp:TableCell CssClass="HeaderCellStyleParents"  >

                        <asp:Label ID="HeaderPPhone" CssClass="LabelParents"  runat="server" Text="Phone"></asp:Label>

                    </asp:TableCell>

                </asp:TableRow>
              

            </asp:Table>


<%--*************************************** GridView ***************************************
******************************************* GridView ***************************************
******************************************* GridView ***************************************--%>

            <div runat="server" class="ScrollDiv" >

             <asp:GridView ID="GridParents" runat="server" ShowFooter="false" ShowHeader="false"  CssClass="rcgv"
              AutoGenerateColumns="False" DataKeyNames="PID" OnRowEditing="GridParents_RowEditing" OnRowCancelingEdit="GridParents_RowCancelingEdit" OnRowDeleting="GridParents_RowDeleting"
              OnRowUpdating="GridParents_RowUpdating" BorderColor="Transparent" CellPadding="5" CellSpacing="5"  Font-Bold="True" OnRowCommand="GridParents_RowCommand" 
              Font-Names="Franklin Gothic Medium" Font-Overline="False" Font-Size="Medium" Font-Strikeout="False" Font-Underline="True" ForeColor="Black"
              style="overflow:auto; max-height:500px" HorizontalAlign="Center" Width="1180px" BorderStyle="None" >

                <Columns>  

        <asp:TemplateField ItemStyle-Width="250px" >
        <ItemTemplate>
   
            <asp:Button  CommandArgument='<%# Eval("PID")%>' Class="ADDDELETE" style="font-family:ArabicFont;" Height="30px" Width="120px" ForeColor="#FFD800" CommandName="Edit" 
                Font-Bold="true" Font-Size="Medium" Text="EDIT" BorderWidth="2" ID="Edit" runat="server" />      

            <asp:Button CommandArgument='<%# Eval("PID")%>' Class="ADDDELETE" style="font-family:ArabicFont;" Height="30px" Width="120px" CommandName="Delete" ToolTip="Delete"
                Font-Bold="true" Font-Size="Medium" Text="Delete" ForeColor="Crimson" ID="Delete" runat="server" />
    
        </ItemTemplate>

   <EditItemTemplate >
           
            <asp:Button  CommandName="Update" Class="ButtonS" ToolTip="Update" Font-Bold="true" Font-Size="Medium" ForeColor="#FFD800" Text="Update" BorderWidth="2"  Width="120px" Height="30px"  ID="Update" runat="server" />
            <asp:Button CommandName="Cancel"  Class="ButtonS" ToolTip="Cancel" Font-Bold="true" Font-Size="Medium" ForeColor="Crimson" Text="Cancel" BorderWidth="2"  Width="120px" Height="30px"  ID="Cancel" runat="server" />
            <br /> <br />
            <asp:Button CommandArgument='<%# Eval("PID")%>' CommandName="ChangeID" Class="ButtonS" ID="ChangeID" Font-Bold="true" ForeColor="#FFD800"  Text="ChangeID"  Width="243px" Height="35px" runat="server" />
        
   </EditItemTemplate>


    </asp:TemplateField>



                    <asp:TemplateField HeaderText="Name" ItemStyle-Width="220px" >
                        <ItemTemplate>
                            <asp:Label ID="PName" runat="server" style="color:darkblue" Font-Underline="true"  CssClass="GridViewLabep" Width="150px"  Text='<%# Eval("PName")%>'></asp:Label>
                        </ItemTemplate>
                        <EditItemTemplate>
                            <asp:TextBox  Text='<%# Eval("PName")%>' ID="TextPName" style="color:darkblue" Font-Underline="true" MaxLength="15" Width="150px" Font-Size="Medium" Font-Bold="true" Height="30px" CssClass="GridViewTextBoxp" runat="server"></asp:TextBox>
                        </EditItemTemplate>

                    </asp:TemplateField>
                 

                    <asp:TemplateField HeaderText="Parents ID" ItemStyle-Width="220px" >
                        <ItemTemplate>
                            <asp:Label ID="PID" runat="server" CssClass="GridViewLabep" Width="150px"  Text='<%# Eval("PID")%>'></asp:Label>
                        </ItemTemplate>
                        <EditItemTemplate>
                            <asp:Label ID="PID" runat="server" CssClass="mydropdownlist" Text='<%# Eval("PID")%>'></asp:Label>  
                        </EditItemTemplate>

                    </asp:TemplateField>


                    <asp:TemplateField HeaderText="Phone Number" ItemStyle-Width="220px" >
                        <ItemTemplate>
                            <asp:Label ID="PhoneNumber" runat="server" CssClass="GridViewLabep" Width="150px"  Text='<%# Eval("PhoneNumber")%>'></asp:Label>
                        </ItemTemplate>
                        <EditItemTemplate>
                            <asp:TextBox Text='<%# Eval("PhoneNumber")%>' Height="30px" Width="150px" Font-Size="Medium" Font-Bold="true" CssClass="GridViewTextBoxp" ID="TextPhoneNumber" MaxLength="10" runat="server" TextMode="Number"></asp:TextBox>
                        </EditItemTemplate>
                    </asp:TemplateField>

               </Columns>  

                <EditRowStyle BackColor="Silver" BorderColor="Black" Font-Size="Medium" HorizontalAlign="Center" />

                <FooterStyle BackColor="Black" BorderWidth="0px" ForeColor="Black" Font-Bold="True" Font-Size="Medium" Height="60px" />
                <HeaderStyle BackColor="Black" BorderStyle="Double" ForeColor="#FF9900" Font-Bold="True" Font-Size="Large" Height="60px" Font-Strikeout="False" />
                <PagerStyle BackColor="Black" />

                <RowStyle BackColor="#FF9900" BorderWidth="2px" BorderColor="Black" ForeColor="Black" Wrap="True" BorderStyle="None" Font-Bold="True" Font-Size="Medium" />

                <SelectedRowStyle BackColor="#FF3300" />

            </asp:GridView>


            </div> 

<%--*************************************** Grid Footer ***************************************
******************************************* Grid Footer ***************************************--%>
            <asp:Table ID="Grid1FooterTabel" CssClass="GridFooter" runat="server">


                <asp:TableRow >

                    <%--===================================================================CELL===============================================================>--%>
                    <asp:TableCell CssClass="FooterCellStyle"  Width="260px" >

                     

                    </asp:TableCell>

                    <%--===================================================================CELL===============================================================>--%>
                    <asp:TableCell CssClass="FooterCellStyle" >

                       

                    </asp:TableCell>

                </asp:TableRow>
              

            </asp:Table>

            <br />


<%--*************************************** Grid2 ***************************************
******************************************* Grid2 ***************************************
******************************************* Grid2 ***************************************--%>

             
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

              <asp:GridView ID="Grid2" runat="server" BackColor="Black" ShowFooter="true" 
              AutoGenerateColumns="False"   DataKeyNames="PID"  OnRowUpdating="Grid2_RowUpdating" BorderColor="Transparent"
              CellPadding="2" CellSpacing="2" Font-Bold="True" Font-Names="Franklin Gothic Medium" CssClass="rcgv"
              Height="70px" HorizontalAlign="Center" Width="420px"              
              Font-Overline="False" Font-Size="Medium" Font-Strikeout="False" Font-Underline="True" ForeColor="Black"   OnRowCancelingEdit="Grid2_RowCancelingEdit" >

                <Columns>  

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


                    <asp:TemplateField >
                        <ItemTemplate >

                            <asp:TextBox ID="TextPID" TextMode="Number" CssClass="GridViewTextBox" runat="server" Height="30px" Width="170px" Font-Size="Medium" Font-Bold="true" BorderColor="#FF9900"   Text='<%# Eval("PID")%>' ></asp:TextBox>
                            
                            
                        </ItemTemplate>                                         
                    </asp:TemplateField>


               </Columns>  

                <EditRowStyle BackColor="#CCCCCC" BorderColor="Black" />

                <FooterStyle BackColor="Black" BorderColor="Transparent" ForeColor="Black" Font-Size="Medium" Height="30px" />
                <HeaderStyle BackColor="Black" BorderStyle="Double" BorderWidth="2px" ForeColor="#FF9900" Font-Size="Medium" Height="60px" />
                <PagerStyle BackColor="Black" />

                <RowStyle BackColor="#CCCCCC" BorderStyle="None"  ForeColor="Black" BorderColor="Black" BorderWidth="2px" Height="40px" />

                <SelectedRowStyle BackColor="#CCCCCC" />

              </asp:GridView>


              </div>      



             <br />


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

            


             <br />

    <section>
           <div class="wave">
             

           </div>
       </section>

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

