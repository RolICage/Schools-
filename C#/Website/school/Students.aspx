<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Students.aspx.cs" Inherits="school.SchoolMain" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>

<%--    <script src="https://ajax.googleapis.com/ajax/libs/jquery/3.4.1/jquery.min.js"></script>
<script> 
$(document).ready(function(){
  $("AddParents").click(function(){
    $("PopTable").animate({left: '250px'});
  });
});
</script> --%>

<%--******************************************* Stylesheets ***************************************--%>
 

    <link href="Stylepage1.css" rel="stylesheet" />
    <link href="FinalStyleXX.css" rel="stylesheet" />

<%--******************************************* Stylesheets END ***************************************--%>

<%--*************************************** STYLES ***************************************
******************************************* STYLES ***************************************
******************************************* STYLES ***************************************--%>

<%--=========================================== ScrollBar Style ===========================================--%>

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

@font-face {
    font-family: 'ArabicFont';
    src: url(fonts/AR.ttf);
    font-style: normal;
    font-weight: 100;
}

    .DropDownStyle2 {
        width: 115px;
        height: 55px;
        font-family: ArabicFont;
        font-size: large;
        border-width: 3px;
        border-color: #BDC3C7;
        background-color: black;
        margin-left:276px;
        border-radius: 5px;
        box-shadow: inset 0 0 10px #BDC3C7;        
        color:#D35400;
        transition: 0.4s;
    }

        .DropDownStyle2:hover {
            box-shadow: inset 0 0 10px #D35400;
            border-color: coral;
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


/*===================== File Upload Design =====================*/
/*===================== File Upload Design =====================*/

    .ShowCSButton {
        font-family: ArabicFont;
        font-size: large;
        color: #E5E7E9;
        border: 3px solid #E5E7E9;
        border-radius: 5px;
        background-color: #1F618D;
        box-shadow: inset 0 0 10px black;
        margin-top: 45px;
        margin-left: 500px;
        position: absolute;
        height: 40px;
        width: 190px;
        transition: 0.4s;
    }

     .ShowCSButton:hover{
         font-size:larger;
         color:#F5B041;
     }

    .fileup{
        width:80px;
        margin-left:10px;
    }

    .labelUpload {
        font-family: ArabicFont;
        height: 20px;
        width: 90px;
        background-color: transparent;
        color: white;
        font-size:medium;   
    }

    .DivSTDuploadDiv{
        background-color:#1E5F8A;
        border: 2px solid #E5E7E9;
        border-radius:5px;
        width:180px;
        height:30px;
    }

    .DivSTDUploadButton{
        font-family: ArabicFont;
        background-color:#1E5F8A;
        position:absolute;
        margin-left:95px;
        margin-top:6px;
        width:83px;
        color:white;
        border:1px solid black;
        border-radius:3px;
        font-size:small;
        transition:0.4s;
    }
    .DivSTDUploadButton:hover{
        color:orange;
        box-shadow: inset 0 0 5px orange;
    }
    
</style>


<%--=========================================== GridView Style ===========================================--%>
<style>

    :root{--gv-border-radius: 15px;}
    .rcgv
    {
        border-radius: var(--gv-border-radius);
        border-width: 0 !important;
        background-color: #808080;
       
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
        .rcgv tr:last-child td:last-child {
            border-bottom-right-radius: var(--gv-border-radius);
        }

</style>



    <%--=========================================== DropDownPhone ===========================================--%>
<style>
    
    @font-face {
        font-family: 'ArabicFont';
        src: url(fonts/AR.ttf);
        font-style: normal;
        font-weight: 100;
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

</style>

    <%--=========================================== STDProfileDIV ===========================================--%>
<style>

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

    .DivSTDProfile {
        border: 5px solid black;
        margin: auto;
        vertical-align: middle;
        width: 680px;
        height: 500px;
        background-color:#FF9900;
        -webkit-border-radius: 10px;
        -moz-border-radius: 10px;
        border-radius: 10px;
    }

    .DivProfiePIC {
        height: 160px;
        width: 160px;
        position: absolute;
        margin-left: 250.5px;
    }

    .DivSTDProfileCell{
        width: 100%;
        height: 100px;
        border:5px solid transparent;
    }

    .DivSTDProfileRow {
        width: 100%;
        height: 50px;
    }

    .DivSTDProfileText{
        font-family:ArabicFont;
        width:200px;
        height:30px;      
        margin-left:65px;
        background-color:transparent;
        border: 2px solid transparent;
        border-bottom-color:black;
        border-top-color:black;
        border-radius:5px;
        color:black;        
        box-shadow: inset 0 0 45px white;
        font-size:large;
    }

    .DivSTDProfileButton {
        font-family:ArabicFont;
        width: 100px;
        height: 35px;       
        margin-left: 208px;
        border: 2px solid black;
        border-radius:5px;
        font-size: medium;
        transition:0.4s;
    }

    .DivSTDProfileButton:hover{
        font-size:large;
        color:chocolate;
    }
    
    .MoreInfo{
        width:40px;
        height:40px;
        border-color: #BDC3C7;
        background-color: black;
        border-radius: 5px;
        box-shadow: inset 0 0 10px #BDC3C7;        
        color:#D35400;
        font-size:small;
        transition:0.4s;
        position:absolute;
    }

        .MoreInfo:hover {
            box-shadow: inset 0 0 10px #D35400;
            border-color: coral;
        }


    .HeaderCellStyleStudents {
        width: 250px;
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

    .ButtonShowMarks {
        font-family: ArabicFont;
        background-color: #1E5F8A;
        position: absolute;
        margin-top: 40px;
        width: 185px;
        height:30px;
        color: white;
        border: 2px solid white;
        border-radius: 3px;
        font-size: medium;
        box-shadow: inset 0 0 10px black;
        transition: 0.4s;
    }

    .ButtonShowMarks:hover {
        color: orange;
        box-shadow: inset 0 0 5px orange;
    }

    .GoldenLine{
        position:absolute;
        background-color:transparent;
        border-color:transparent;
        height:25px;
        width:670px;
        margin-top:210px;
        margin-left:624px;
        background-repeat:no-repeat;
        background-size: cover;
    }

    .MarksHeader{
        width:410px;
        height:40px;
        border: 3px solid black;
        border-radius:5px;
        margin-top:5px;
        box-shadow: inset 0 0 50px #1E5F8A;
    }

    .GridViewMarks {
        width: 405px;
        background-color:#E67E22;
    }

    .MarksHeaderCell{
        border-color:transparent;
        border-radius:5px;
        width:130px;
        box-shadow: inset 0 0 30px white;
    }

    .GridMarksButtons{
        background-color:transparent;
        font-family:ArabicFont;
        font-size:medium;
        margin-left:20px;
    }

    .CSButtonClose {
        font-family: ArabicFont;
        font-size: large;
        width: 200px;
        height: 35px;
        color: azure;
        background-color: black;
        border: 3px solid #CACFD2;
        border-radius: 5px 5px 15px 15px;
        margin-top:7px;
        transition: 0.4s;
    }

     .CSButtonClose:hover{
         color:darkorange;
         font-size:larger;
         height:38px;
         border-color:#7D5013;
         box-shadow: inset 0 0 10px #7D5013;
     }

    .search-boxStudent {
        font-family: 'ArabicFont';
        margin-top: 61px;
        margin-left: 145px;
        z-index: 1;
        position: absolute;
        transform: translate(-50%,-50%);
        background: #2b2b2b;
        height: 35px;
        border-radius: 15px;
        padding: 10px;
        background: #212000;
        transition:0.4s;
    }

    .search-boxStudent:hover{
        box-shadow: inset 0 0 15px orange;
    }

    .switchMode {
        margin-left: 295px;
        margin-top:40px;
        border-radius: 10px;
        height: 35px;
        width: 35px;
        transition: 0.4s;
    }

    .switchMode:hover {
        height: 39px;
        width: 39px;
    }

</style>


<%--*************************************** STYLES END ***************************************
******************************************* STYLES END ***************************************
******************************************* STYLES END ***************************************--%>

</head>
<body >

    <form id="form1" runat="server" onsubmit="ShowLoading()" >


        <asp:Button ID="BackClick" class="BackButton" Font-Bold="true" OnClick="BackClick_Click" runat="server" Text="⟸" />
        
        <%--============================= Search Option =============================--%>
        <%--============================= Search Option =============================--%>

    

            <div id="Div" runat="server" style="background-image: url( Images/GridEditRow.Gif );" class="search-boxStudent" >        
                         
            <asp:TextBox CssClass="search-txt" ID="TextFind" placeholder="ENTER TECHER ID" MaxLength="10" min="1" max="999999999" Font-Bold="true"  runat="server"></asp:TextBox>  
  
            <asp:Button text="S" class="search-btn" ID="ButtonFind" runat="server" Font-Bold="true"  OnClick="ButtonFind_Click"  />   
            
            <asp:ImageButton ID="ImageButton1" class="search-btn" ImageUrl="Gifs/Refresh.Gif" runat="server" Font-Bold="true" OnClick="ImageButton1_Click" />      
                          
            </div>

            
        <%--============================= Logo =============================--%>

        <div  >

         <img src="Images/Logo.png" alt="Alternate Text" Width="110px" height="100px" align="Right" />
        

        </div>


        <%--============================= Upload Image Button =============================--%>
        <div class="ShowCSButton" style="text-align:left">       
                    
        <asp:Table ID="Table1" style="width:200px; height:30px; margin-top:5px" runat="server">
            <asp:TableRow>

                <asp:TableCell Width="100px">

                    <asp:FileUpload CssClass="fileup" ID="FileUpload1" runat="server" />  

                </asp:TableCell>

                <asp:TableCell Width="100px">

                    <asp:Label ID="selectimagebutton" class="labelUpload" Font-Bold="true" text="Select Image" runat="server"></asp:Label>    

                </asp:TableCell>

            </asp:TableRow>
        </asp:Table>

        </div>


        <asp:ImageButton ID="ChangeFind" ImageUrl="Gifs/Tap.gif" class="switchMode" BorderColor="Black" BorderWidth="3px" OnClick="ChangeFind_Click" runat="server"/>

        <br />
        <br />


<%--*************************************** Grid1 ***************************************
******************************************* Grid1 ***************************************
******************************************* Grid1 ***************************************--%>


            <asp:Table ID="Grid1HeaderTabel" CssClass="GridHeader" runat="server" >


                <asp:TableRow >
<%--===================================================================CELL===============================================================>--%>
                    <asp:TableCell CssClass="HeaderCellStyleStudents" style="box-shadow: inset 0 0 0px #00000000;" Width="260px" >

                        <img src="Gifs/3Lines.gif" class="EditGif" />

                    </asp:TableCell>

<%--===================================================================CELL===============================================================>--%>
                    <asp:TableCell CssClass="HeaderCellStyleStudents"  >

                        <asp:Label ID="HeaderStudentName" CssClass="LabelStudents"  runat="server" Text="STUDENT NAME"></asp:Label>

                    </asp:TableCell>

<%--===================================================================CELL===============================================================>--%>
                    <asp:TableCell CssClass="HeaderCellStyleStudents" >

                        <asp:Label ID="HeaderStudentID" CssClass="LabelStudents"  runat="server" Text="STUDENT ID"></asp:Label>

                    </asp:TableCell>

<%--===================================================================CELL===============================================================>--%>
                    <asp:TableCell CssClass="HeaderCellStyleStudents" >

                        <asp:Label ID="HeaderParents" CssClass="LabelStudents"  runat="server" Text="PARENTS ID"></asp:Label>

                    </asp:TableCell>

<%--===================================================================CELL===============================================================>--%>
                    <asp:TableCell CssClass="HeaderCellStyleStudents" >

                        <asp:Label ID="HeaderStudentClass" CssClass="LabelStudents"  runat="server" Text="CLASS"></asp:Label>

                    </asp:TableCell>


                </asp:TableRow>
              

            </asp:Table>

              <div id="GRIDVDIV" onscroll="SetDivPosition()" runat="server" class="ScrollDiv" >               
              <asp:GridView ID="Grid1" ShowFooter="false" ShowHeader="false" CssClass="rcgv" runat="server" OnRowCommand="Grid1_RowCommand" style=" overflow: auto; max-height: 500px"
              AutoGenerateColumns="False" DataKeyNames="SID" OnRowEditing="Grid1_RowEditing" OnRowCancelingEdit="Grid1_RowCancelingEdit"
              OnRowUpdating="Grid1_RowUpdating" BorderColor="Transparent" CellPadding="5" CellSpacing="5" OnRowDeleting="Grid1_RowDeleting" Font-Bold="True" 
              Font-Names="Franklin Gothic Medium" Font-Overline="False" Font-Size="Medium" Font-Strikeout="False" Font-Underline="True" ForeColor="Black"
              HorizontalAlign="Center" BorderStyle="None" Width="1180px" >

              <Columns >  

              <asp:TemplateField ItemStyle-Width="250px" ControlStyle-CssClass="ButtonS2"  >
  
              <ItemTemplate >
    
              <asp:Button CommandArgument='<%# Container.DataItemIndex %>' Class="ADDDELETE" Height="35px" Width="120px" CommandName="Edit"  ToolTip="Edit"
                Font-Bold="true" Font-Size="Medium" Text="EDIT"  ForeColor="#FFD800" ID="Edit" runat="server"  />             
                       
              <asp:Button CommandArgument='<%# Eval("SID")%>' Class="ADDDELETE" style="color:crimson" Height="35px" Width="120px" CommandName="Delete" ToolTip="Delete"
                Font-Bold="true" Font-Size="Medium" Text="Delete" ForeColor="#FFD800" ID="Delete" runat="server" />

                 
  
              </ItemTemplate>

              <EditItemTemplate >
           
              <asp:Button  CommandName="Update" Class="ButtonS" ToolTip="Update" Font-Bold="true" Font-Size="Medium" Text="Update" ForeColor="#FFD800" Width="120px" Height="35px"  ID="Update" runat="server" />
              <asp:Button CommandName="Cancel" Class="ButtonS" ToolTip="Cancel" Font-Bold="true" Font-Size="Medium" Text="Cancel" ForeColor="#FFD800" Width="120px" Height="35px" style="color:crimson"  ID="Cancel" runat="server" />
              <br />
              <br />
              <asp:Button CommandArgument='<%# Eval("SID")%>' CommandName="ChangeID" Class="ButtonS" ID="ChangeID" Font-Bold="true" ForeColor="#FFD800"  Text="ChangeID"  Width="243px" Height="40px" runat="server" />

              </EditItemTemplate>

            

              </asp:TemplateField>



                    <asp:TemplateField HeaderText="Name" ItemStyle-Width="220px" >
                        <ItemTemplate >

                            <div class="GridRowMaxWidth" >

                            <asp:Label ID="SName" style="color:darkblue" Font-Underline="true" CssClass="GridViewLabe2" Width="130px" runat="server"  Text='<%# Eval("SName")%>'></asp:Label>


                                                                                
                                <asp:Image ID="ProfilePic" class="ImagesStyle" align="right" runat="server" />
                                <asp:Image src="Images/BGPannel.png" class="ImagesStyle" align="right" runat="server" />
                                <asp:Image src="Images/glass.png" class="ImagesStyle" align="right" runat="server" />
                                <asp:Image src="Images/RoundPannel.png" class="ImagesStyle" align="right" runat="server" />
                                
                                
                            <asp:Button CommandName="ChangePic" CommandArgument='<%# Container.DataItemIndex %>' ID="ChangePic" class="ImagesStyleChangePic" runat="server" />
                                                               

                            </div>
                            

                        </ItemTemplate>
                        <EditItemTemplate>
                            <asp:TextBox  Text='<%# Eval("SName")%>' style="color:darkblue" Font-Underline="true" ID="TextName" Font-Size="Medium" Font-Bold="true" MaxLength="15" Height="30px" CssClass="GridViewTextBox" runat="server"></asp:TextBox>
                        </EditItemTemplate>
                     
                    </asp:TemplateField>

                   


                    <asp:TemplateField HeaderText="Student ID" ItemStyle-Width="220px">

                        <ItemTemplate>
                            <asp:Label ID="SID" CssClass="mydropdownlist" BorderWidth="1px" brodercolor="black" Width="140px" Height="20px" runat="server" BorderColor="Black" BackColor="#F8B334" Text='<%# Eval("SID")%>'></asp:Label>
                        </ItemTemplate>

                        <EditItemTemplate>

                            <img src="Gifs/lockgifid.gif" height="52px" width="47px" align="center" />

                            <br />
                                                                                                                                                         
                            <asp:Label ID="SID" runat="server" CssClass="mydropdownlist" Height="17px" Width="115px" TextMode="Number"  Text='<%# Eval("SID")%>'></asp:Label>   
                            
                        </EditItemTemplate>
                      
                    </asp:TemplateField>


                    <asp:TemplateField HeaderText="Parents ID" ItemStyle-Width="220px" >
                        <ItemTemplate>
                            <asp:Label ID="PID" CssClass="GridViewLabe2" Width="200px" runat="server" Text='<%# Eval("PID")%>'></asp:Label>
                        </ItemTemplate>
                        <EditItemTemplate>
                            <asp:TextBox  Text='<%# Eval("PID")%>'  Height="30px" CssClass="GridViewTextBox" Font-Size="Medium" Font-Bold="true" ID="TextPID" runat="server" TextMode="Number" MaxLength="9"></asp:TextBox>
                        </EditItemTemplate>
                    
                    </asp:TemplateField>         
                    

                    <asp:TemplateField HeaderText="ClassCode" ItemStyle-Width="220px" >
                        <ItemTemplate>
                            <asp:Label ID="ClassCode"  CssClass="GridViewLabe2" Width="100px" runat="server"  Text='<%# Eval("ClassCode")%>'></asp:Label>
                            <asp:Button ID="MoreInfo" CommandArgument='<%# Eval("SID")%>' CssClass="MoreInfo" CommandName="MoreInfo" Text="●●●" runat="server" />
                        </ItemTemplate>
                        <EditItemTemplate>
                            <asp:DropDownList onmousedown="this.size=3;" onfocusout="this.size=1;" style="margin-left:20px" Font-Size="Medium" Font-Bold="true" CssClass="DropDownStyle2" ID="ddlClasscode" runat="server" ></asp:DropDownList>
                        </EditItemTemplate>
                      
                    </asp:TemplateField>


                </Columns>  

                <EditRowStyle BackColor="Silver" CssClass="GridEditRow" BorderColor="Black" Font-Size="Medium" HorizontalAlign="Center" />

                <FooterStyle BackColor="Black" BorderWidth="0px" ForeColor="Black" Font-Bold="True" Font-Size="Medium" />
                <HeaderStyle BackColor="Black" BorderStyle="Double" ForeColor="#FF9900" Font-Bold="True" Font-Size="Large" Height="60px" Font-Strikeout="False" HorizontalAlign="Center" />
                <PagerStyle BackColor="Black" />

                <RowStyle BackColor="#FF9900" BorderWidth="1px" Height="60px" CssClass="GridRow" BorderColor="Black" HorizontalAlign="Center"  ForeColor="Black" Wrap="True"  Font-Bold="True" Font-Size="Medium" />

                <SelectedRowStyle BackColor="#FF3300" />

                </asp:GridView>


                </div>
        
            <asp:Table ID="Grid1FooterTabel" CssClass="GridFooter" runat="server">


                <asp:TableRow >


                    <%--===================================================================CELL===============================================================>--%>
                    <asp:TableCell CssClass="FooterCellStyle"  Width="100%" >

                        <asp:Button ID="AddStudButton" Class="ButtonS3" Font-Bold="true" ForeColor="#FFD800" Font-Size="Large" Text="ADD" BorderWidth="3" runat="server" OnClick="ADD_Click" /> <br /> <br />    

                    </asp:TableCell>

                </asp:TableRow>
              

            </asp:Table>

<%--*************************************** Grid1 END ***************************************
******************************************* Grid1 END ***************************************
******************************************* Grid1 END ***************************************--%>
                             
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

              <asp:GridView ID="Grid2" runat="server" BackColor="Black" ShowFooter="true"  OnRowCommand="Grid1_RowCommand"
              AutoGenerateColumns="False"   DataKeyNames="SID"  OnRowUpdating="Grid2_RowUpdating" BorderColor="Transparent"
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


                    <asp:TemplateField HeaderText="Student ID">
                        <ItemTemplate >

                            <asp:TextBox ID="TextSID" TextMode="Number" CssClass="GridViewTextBox" runat="server" Height="30px" Width="170px" Font-Size="Medium" Font-Bold="true" BorderColor="#FF9900"   Text='<%# Eval("SID")%>' ></asp:TextBox>
                                                       
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


       
             <section>



           

<%--*************************************** Grid2 END ***************************************
******************************************* Grid2 END ***************************************
******************************************* Grid2 END ***************************************--%>

           <div class="wave">

           </div>

<%--*************************************** PopUp Add ***************************************
******************************************* PopUp Add ***************************************
******************************************* PopUp Add ***************************************--%>

        
         <div  id="DivPop" runat="server" class="AddParentsPopUp" >
     

            <br /> <br />
            <br /> <br />
            <br /> <br />
            <br /> <br />
            <br /> <br />

              
            <table id="PopTable" cellspacing="10px" cellpadding="3px" style="width:500px; height:400px;"  class="Tabel" align="center" border="1" >
                 <%--============ Row ============= >--%>
            <tr>
                <td class="CellStyle" align="center" colspan="2" height="20px" >   
                 
                    <img src="Gifs/brand.gif"  alt="gif image" height="70px" width="70px" />

                </td>

            </tr>
                <%--============ Row ============= >--%>
            <tr>
                <td class="CellStyle">&nbsp;
                    <asp:TextBox CssClass="TextBox" placeholder="Parent Name" style="font-family:ArabicFont; margin-left:50px; font-size:x-large" ID="TextBoxPname" runat="server" Font-Bold="True"  Font-Underline="True" ForeColor="Black" MaxLength="15"></asp:TextBox> </td>
                
            </tr>
                 <%--============ Row ============= >--%>
            <tr>
                <td class="CellStyle">&nbsp;

                    <asp:Label CssClass="TextBox" style="margin-bottom:15px; font-family:ArabicFont; margin-left:155px; font-size:x-large" TextMode="Number" ID="TextBoxPID" runat="server" Font-Bold="True"  Font-Underline="True" ForeColor="Black"></asp:Label> </td>
            </tr>
                 <%--============ Row ============= >--%>
            <tr style="height:70px">

                                              <%--============ DivPhoneNum ============= >--%>          
      <div class="divPhone" style="background-image: url( Images/GridEditRow.Gif ); position:absolute; margin-top:263px; margin-left:865px" >

            <asp:DropDownList CssClass="DropDownPhone" Font-Bold="true" ID="DropDownNumsPhoneNumber" runat="server">

                    <asp:ListItem Text="050" Value="050"></asp:ListItem>
                    <asp:ListItem Text="052" Value="052"></asp:ListItem>
                    <asp:ListItem Text="054" Value="054"></asp:ListItem>

            </asp:DropDownList>

            <asp:TextBox CssClass="TextPhone" Font-Bold="true" placeholder="Parent Phone" ID="TextBoxPphone" TextMode="Number" min="7" max="9999999" runat="server"></asp:TextBox>

      </div>


            </tr>
                 <%--============ Row ============= >--%>
            <tr>
                <td class="CellStyle" align="center" colspan="2">&nbsp;

                    <asp:Button Class="ButtonS" Font-Bold="True" Text="Cancel" ID="PopCancel" runat="server" ForeColor="#FFD800" OnClick="PopCancel_Click" />
                    <asp:Button Class="ButtonS" Font-Bold="True" Text="ADD" ID="PopAdd" runat="server" ForeColor="#FFD800" OnClick="PopAdd_Click"  />
                    
                </td>
            </tr>

            </table>
        
              
         </div>
        
<%--*************************************** PopUp Add END ***************************************
******************************************* PopUp Add END ***************************************
******************************************* PopUp Add END ***************************************--%>

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

<%--*************************************** PopUp Student Profile ***************************************
******************************************* PopUp Student Profile ***************************************
******************************************* PopUp Student Profile ***************************************--%>

        <div runat="server" visible="false" style="z-index:2" class="PopUpMessage" id="DIVSTDProfile">

            <br /> <br />
            <br /> <br />
            <br /> <br />

           <table id="TableSTDProfile" class="DivSTDProfile" align="center" >
               <%-----------------------------ROW-----------------------------%>

                    <%////////////// Golden Line Button%>
                    <%--<asp:Button ID="GoldenLineButton" CssClass="GoldenLine" style="background-image: url( Gifs/GoldLine.png );" runat="server" />--%>

            <%--//======= Tabel Row--%>
            <tr >
                <td class="DivSTDProfileCell" >

                  
                    <%////////////// Show Marks Button%>
                    <asp:Button ID="ShowSTDMarks" Font-Bold="true" CssClass="ButtonShowMarks" OnClick="ShowSTDMarks_Click" runat="server" Text="Show Marks" />
                   
                    <%////////////// File Upload Button%>
                    <asp:Button ID="FileUpload2Button" Font-Bold="true" CssClass="DivSTDUploadButton" runat="server" Text="Upload" OnClick="FileUpload2Button_Click" />

                                <%////////////// Images %>
                                <asp:Image ID="DivProfilePic" style="height:155px; width:155px; margin-top:7px" class="DivProfiePIC" align="center" runat="server" />
                                <asp:Image src="Images/BGPannel.png" style="margin-top:3px" class="DivProfiePIC" align="center" runat="server" />
                                <asp:Image src="Images/glass.png" class="DivProfiePIC" align="center" runat="server" />
                                <asp:Image src="Images/RoundPannel.png" style="height:175px; width:175px; margin-left:245px" class="DivProfiePIC" align="center" runat="server" />
                   

                    <%////////////// File Upload Div%>
                    <div class="DivSTDuploadDiv">
                            <asp:FileUpload ID="FileUpload2" style="margin-top:5px; margin-left:5px; width:80px;" runat="server" />                          
                    </div>
                   
                    <br /> <br />
                    <br /> <br />
                    <br /> <br />
                    <br /> <br />
                    <br /> 
                </td>
            </tr>

                              <%--//======= Tabel Row--%>
            <tr style="background-image: url( Images/GridEditRow.Gif );">
                <td class="DivSTDProfileRow" >
                    <asp:Image src="Gifs/lockgifid.gif" style="position:absolute; margin-left:565px; margin-top:6.5px" ID="UnlockGif" Visible="false" height="34px" width="34px" align="center" runat="server" />
                    <asp:TextBox ID="FooterName" MaxLength="15" Height="30px" placeholder="ENTER STUDENT NAME" Font-Bold="true" CssClass="DivSTDProfileText" runat="server"></asp:TextBox>
                    <asp:TextBox ID="FooterSID" TextMode="Number" MaxLength="9" placeholder="ENTER STUDENT ID" Font-Bold="true" style="margin-left:120px" CssClass="DivSTDProfileText" runat="server"></asp:TextBox>
                    <asp:Label ID="FooterLabelSID"  Width="200px" Height="30px" CssClass="DivSTDProfileText" Font-Bold="true" style="margin-left:120px" Visible="false" runat="server"></asp:Label>
                    
                </td>


            </tr>

                              <%--//======= Tabel Row--%>
            <tr style="background-image: url( Images/GridEditRow.Gif );">
                <td class="DivSTDProfileRow" >

                    
                              <%--============ DivPhoneNum ============= >--%>          
      <div class="divPhone" style="background-image: url( Gifs/graygif.Gif ); margin-left:410px; margin-bottom:50px; position:absolute; height:35px; width:180px" >

            <asp:DropDownList CssClass="DropDownPhone" Height="35px" Font-Bold="true" ID="FooterPhoneDrop2" runat="server">

                    <asp:ListItem Text="050" Value="050"></asp:ListItem>
                    <asp:ListItem Text="052" Value="052"></asp:ListItem>
                    <asp:ListItem Text="054" Value="054"></asp:ListItem>

            </asp:DropDownList>

            <asp:TextBox CssClass="TextPhone" placeholder="STUDENT PHONE" ForeColor="Black" style="width:100px; height:25px; font-size:medium" Font-Bold="true" ID="FooterPhone2" TextMode="Number" min="7" max="9999999" runat="server"></asp:TextBox>

      </div>

                    <asp:TextBox ID="FooterPID" placeholder="ENTER PARENT ID" TextMode="Number" MaxLength="9" Font-Bold="true" CssClass="DivSTDProfileText" runat="server"></asp:TextBox>                    
                </td>
            </tr>

                              <%--//======= Tabel Row--%>
            <tr style="background-image: url( Images/GridEditRow.Gif );">
                <td class="DivSTDProfileRow" >
                    <asp:TextBox ID="FooterPlace" placeholder="ENTER STUDENT address" MaxLength="20" Font-Bold="true" CssClass="DivSTDProfileText" runat="server"></asp:TextBox>
                    <asp:TextBox ID="FooterBDate" textmode="Date" Font-Bold="true" style="margin-left:120px" CssClass="DivSTDProfileText" runat="server"></asp:TextBox>
                </td>
            </tr>

            <tr style="background-image: url( Images/GridEditRow.Gif );">
                <td class="DivSTDProfileRow" style="height:90px" >
                     <asp:DropDownList ID="FooterClassCode" Font-Size="Medium" Font-Bold="true" CssClass="DropDownStyle2" onmousedown="this.size=3;" onfocusout="this.size=1;" runat="server" ></asp:DropDownList>
                </td>
            </tr>

            <tr style="background-image: url( Images/GridEditRow.Gif );">
                <td class="DivSTDProfileRow" >
                    <asp:Button ID="DivSTDADD" Font-Underline="true" Font-Bold="true" CssClass="DivSTDProfileButton" OnClick="DivSTDADD_Click" runat="server" Text="ADD" />
                    <asp:Button ID="DivSTDExit" Font-Underline="true" Font-Bold="true" CssClass="DivSTDProfileButton" OnClick="DivSTDExit_Click" style="margin-left:45px" runat="server" Text="Cancel" />
                </td>
            </tr>

            </table>

         </div>


<%--*************************************** PopUp Student Marks ***************************************
******************************************* PopUp Student Marks ***************************************
******************************************* PopUp Student Marks ***************************************--%>

                 <div runat="server" visible="false" style="z-index:3" class="PopUpMessage" id="DIVSTDMarks">

                    <br /> <br />
                    <br /> <br />
                    <br /> <br />
                    <br /> <br />
                    <br /> 

                     <%--////////////////// Panel --%>
                     <div id="TableSTDMarks" style="border-color:#CACFD2; width:425px; height:400px" class="DivSTDProfile" align="center" >

                         <%--////////////////// Header --%>
                     <asp:Table ID="TabelMarksHeader" CssClass="MarksHeader" runat="server">

                         <%--////////////////// Row --%>
                         <asp:TableRow>

                             <asp:TableCell CssClass="MarksHeaderCell">

                                 <asp:Button ID="MarksSubName" Font-Bold="true" ForeColor="#273746" BackColor="Transparent" style="font-family:ArabicFont; margin-left:25px; font-size:large; border-color:transparent" runat="server" Text="Subject" />

                             </asp:TableCell>

                             <asp:TableCell CssClass="MarksHeaderCell">

                                 <asp:Button ID="MarksMark" Font-Bold="true" ForeColor="#273746" BackColor="Transparent" style="font-family:ArabicFont; margin-left:25px; font-size:large; border-color:transparent" runat="server" Text="Mark" />

                             </asp:TableCell>

                             <asp:TableCell CssClass="MarksHeaderCell">

                                 <asp:Button ID="MarksChapter" Font-Bold="true" ForeColor="#273746" BackColor="Transparent" style="font-family:ArabicFont; margin-left:25px; font-size:large; border-color:transparent" runat="server" Text="Chapter" />

                             </asp:TableCell>

                         </asp:TableRow>

                     </asp:Table>

                         <%--////////////////// GridView --%>
                         <div style="width:420px; height:auto; max-height:350px" class="ScrollDiv">
                             
                         <asp:GridView ID="GridMarks" AutoGenerateColumns="False" OnRowCommand="GridMarks_RowCommand"
                            ShowFooter="false" ShowHeader="false" CssClass="GridViewMarks" runat="server">
                             <Columns>

                                 <%--////////////////// ItemSubject --%>
                                 <asp:TemplateField ItemStyle-Width="136px" ItemStyle-Height="15px">

                                     <ItemTemplate>

                                         <asp:Label ID="ClassPrint" runat="server" Visible="false" Text='<%# Eval("CCode")%>'></asp:Label>

                                         <asp:ImageButton ID="PrintMarks" CommandArgument='<%# Container.DataItemIndex %>' 
                                             OnClick="PrintMarks_Click" ImageUrl="Gifs/print.Gif" Width="30px" Height="30px" 
                                             style="border:1px solid black; border-radius:5px; margin-left:10px; margin-top:3px;
                                             position:absolute" Visible="false" CommandName="Print" runat="server" />

                                         <asp:Label ID="SubName" CssClass="GridMarksButtons" runat="server" Text='<%# Eval("SubName")%>'></asp:Label>
                                         <br />
                                         <asp:Label ID="MarkKind" CssClass="GridMarksButtons" ForeColor="#1F618D" runat="server" Text='<%# Eval("Kind")%>'></asp:Label>

                                     </ItemTemplate>

                                 </asp:TemplateField>

                                 <%--////////////////// ItemMark --%>
                                 <asp:TemplateField ItemStyle-Width="130px" ItemStyle-Height="15px">

                                     <ItemTemplate>

                                         <asp:Label ID="Mark" style="margin-left:18px; font-size:large; text-shadow: 2px 2px 10px #283747" Font-Bold="true" CssClass="GridMarksButtons" Font-Underline="true" runat="server" Text='<%# Eval("Mark")%>'></asp:Label>

                                     </ItemTemplate>

                                 </asp:TemplateField>

                                 <%--////////////////// ItemChapter --%>
                                 <asp:TemplateField ItemStyle-Width="130px" ItemStyle-Height="15px">

                                     <ItemTemplate>

                                         <asp:Label ID="Chapter" CssClass="GridMarksButtons" runat="server" Text='<%# Eval("Chapter")%>'></asp:Label>
                                         <br />
                                         <asp:Label ID="ClassN" CssClass="GridMarksButtons" ForeColor="#1F618D" runat="server" Text='<%# Eval("Class")%>'></asp:Label>

                                     </ItemTemplate>

                                 </asp:TemplateField>

                             </Columns>
                         </asp:GridView>

                             
                         </div>

                         <asp:Button ID="STDMarksClose" CssClass="CSButtonClose" OnClick="STDMarksClose_Click" runat="server" Text="Close" />

                     </div>
                     
                 </div>


<%--*************************************** PopUp Print ***************************************
******************************************* PopUp Print ***************************************
******************************************* PopUp Print ***************************************--%>

                 <div runat="server" visible="false" style="z-index:5" class="PopUpMessage" id="DivPrint">

                     
                     <div ID="PrintPanel" style="border: 1px solid black; width:800px; height:820px; margin-top:50px" class="DivSTDProfile" runat="server">
                         <%--================ School Name ================--%>
                         <asp:Label ID="PrintLabelSchool" style="position:absolute; width:300px; height:55px; font-size:x-large; font-family:ArabicFont; margin-left:310px; margin-top:50px" 
                             Font-Bold="true" runat="server" Text=""></asp:Label>

                                             <%--================ Print Icon ================--%>
                                             <asp:ImageButton ID="PrintMarksPage" ImageUrl="Gifs/print.Gif" Width="30px" Height="30px" 
                                             style="border:1px solid black; border-radius:5px; margin-left:10px; margin-top:10px;
                                             position:absolute" Visible="true" runat="server" />

                         <%--================ Student Info ================--%>
                         <div style="text-align:right; position:absolute; margin-left:500px; margin-top:15px; width:300px; height:100px" >
                             
                         <asp:Label ID="PrintLabelSTDName" style="margin-right:20px; font-family:ArabicFont" Font-Bold="true" runat="server" Text=""></asp:Label>
                             <br />
                         <asp:Label ID="PrintLabelSID" style="margin-right:20px; font-family:ArabicFont" Font-Bold="true" runat="server" Text=""></asp:Label>
                             <br />
                         <asp:Label ID="PrintLabelCName" style="margin-right:20px; font-family:ArabicFont" Font-Bold="true" runat="server" Text=""></asp:Label>
                             <br />

                         </div>

                         
                         <%--============== GridViewPrint--%>
                         <asp:GridView ID="GridPrintMarks" style="font-family:ArabicFont; margin-top:110px" Width="800px" AutoGenerateColumns="false" runat="server">

                             <Columns>

                                 <%--============== Template--%>
                                 <asp:TemplateField >

                                     <ItemTemplate>

                                         <div style="text-align:center">
                                             <asp:Label ID="PrintPass" style="font-family:ArabicFont; font-size:smaller" Font-Bold="true" runat="server" Text='<%# Eval("Pass")%>'></asp:Label>
                                         </div>
                                         
                                     </ItemTemplate>

                                 </asp:TemplateField>

                                 <%--============== Template--%>
                                 <asp:TemplateField >

                                     <ItemTemplate>

                                         <div style="text-align:center">
                                             <asp:Label ID="PrintMark" style="font-family:ArabicFont; font-size:smaller" Font-Bold="true" runat="server" Text='<%# Eval("Mark")%>'></asp:Label>
                                         </div>                                         

                                     </ItemTemplate>

                                 </asp:TemplateField>

                                 <%--============== Template--%>
                                 <asp:TemplateField>

                                     <ItemTemplate>

                                             <asp:Label ID="PrintSubject" style="font-family:ArabicFont; font-size:smaller" Font-Bold="true" runat="server" Text='<%# Eval("Subject")%>'></asp:Label>                                      

                                     </ItemTemplate>

                                 </asp:TemplateField>

                                 <%--============== Template--%>
                                 <asp:TemplateField>

                                     <ItemTemplate>

                                         <asp:Label ID="PrintChapter" style="font-family:ArabicFont; font-size:smaller" Font-Bold="true" runat="server" Text='<%# Eval("Chapter")%>'></asp:Label>

                                     </ItemTemplate>

                                 </asp:TemplateField>

                             </Columns>

                             <RowStyle HorizontalAlign="right" VerticalAlign="Middle" />

                         </asp:GridView>

                         <div style="text-align:right; position:absolute; margin-left:450px; margin-top:15px; width:300px; height:100px" >
                             <asp:Label ID="PrintLabelAVG" Font-Underline="true" style="font-family:ArabicFont; font-size:x-large;" runat="server" Text="Label"></asp:Label>
                         </div>     
                         
                         <asp:Image ID="PrintLogo" style="position:absolute; margin-top:5px; margin-left:10px" Width="55px" Height="50px" ImageUrl="~/Images/Logo.png" runat="server" />
                        
                     </div>

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

    </form>

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

    </body>

</html>
