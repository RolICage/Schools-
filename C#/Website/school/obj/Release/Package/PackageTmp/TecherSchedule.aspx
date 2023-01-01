<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="TecherSchedule.aspx.cs" Inherits="school.TecherSchedule" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>

    <%--******************************************* Stylesheets ***************************************--%>
    <link href="Stylepage1.css" rel="stylesheet" />

    <link href="FinalStyleXX.css" rel="stylesheet" />
<%--******************************************* Stylesheets END ***************************************--%>

<style>
    .DropDownStyleSchedules0 {
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

    .DropDownStyleSchedules {
        font-family: ArabicFont;
        color: black;
        width: 150px;
        font-size: 20px;
        padding: 5px 10px;
        border-radius: 12px 12px 0px 0px;
        background-color: #F8B334;
        border-color: whitesmoke;
        font-weight: bold;
        transition: 0.4s;
    }

    .DropDownStyleSchedules2 {
        font-family: ArabicFont;
        color: black;
        width: 150px;
        font-size: 20px;
        padding: 5px 10px;
        border-radius: 0px 0px 12px 12px;
        background-color: #F8B334;
        border-color: whitesmoke;
        font-weight: bold;
        transition: 0.4s;
    }

    .DropDownStyleSchedules22 {
        font-family: ArabicFont;
        color: black;
        width: 100%;
        font-size: 20px;
        padding: 5px 10px;
        border-radius: 0px 0px 12px 12px;
        background-color: #F8B334;
        border-color: whitesmoke;
        font-weight: bold;
        transition: 0.4s;
    }
      
    .DropDownStyle2 {
        font-family: ArabicFont;
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
        margin-top: 2px;
    }

    .DropDownStyle22 {
        font-family: ArabicFont;
        color: black;
        width: 150px;
        font-size: 20px;
        padding: 5px 10px;
        border-radius: 12px 12px 12px 12px;        
        background-color: #F8B334;
        border-color: whitesmoke;
        border-width: 2px;
        font-weight: bold;
        transition: 0.3s;
        margin-top: 5px;
    }

    .DropDownStyle2:hover{
        background-color: dimgrey;
        border-color: yellow;
    }

    .TabelLoading {
        border: 5px solid;
        border-color: #FF9900;
        margin: auto;
        vertical-align: middle;
        width: 300px;
        height: 200px;
        background-color: #000000D9;
        -webkit-border-radius: 10px;
        -moz-border-radius: 10px;
        border-radius: 10px;
    }

    .DropDownStyle3 {
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

        .DropDownStyle3:hover {
            width: 250px;
            height: 75px;
        }

    .DropDownDaysWeek {
        width: 115px;
        height: 55px;
        font-family: ArabicFont;
        font-size: large;
        border-width: 3px;
        border-color: #BDC3C7;
        background-color: black;
        border-radius: 5px;
        box-shadow: inset 0 0 10px #BDC3C7;        
        color:#D35400;
        transition: 0.4s;
    }

        .DropDownDaysWeek:hover {
            box-shadow: inset 0 0 10px #D35400;
            border-color: coral;
            height: 75px;
        }

</style>

<style>
    .ScrollDivSchedules {
        width: 1505px;
        height: auto;
        max-height: 400px;
        overflow: auto;
        position: relative;
    }

</style>

<style>
    .LabelSechedules {
        font-family: ArabicFont;
        background-color: transparent;
        border-color: transparent;
        width: 110px;
        height: 100%;
        font-size: large;
        vertical-align: middle;
        text-align: center;
        color: #D35400;
    }


</style>


<style>
    .EditGifechedules {
        height: 45px;
        width: 60px;
        -webkit-border-radius: 10px;
        -moz-border-radius: 10px;
        border-radius: 10px;
    }
</style>

<style>

    .ADDDELETE2 {
        font-family: ArabicFont;
        width: 120px;
        height: 35px;
        font-size: large;
        border-width: 3px;
        border-color: #FF9900;
        background-color: black;
        border-radius: 12px 12px 12px 12px;
        transition: 0.4s;
    }

    .ADDDELETE2:hover{
        background-color: dimgrey;
        border-color: yellow;
    }

    @font-face {
        font-family: 'ArabicFont';
        src: url(fonts/AR.ttf);
        font-style: normal;
        font-weight: 100;
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
</style>


<style>

.HeaderCellStyleSchecdules {
    width: 110px;
    border: 2.2px solid #BDC3C7;
    border-radius: 5px;
    background-color: black;   
    font-size: large;
    box-shadow: inset 0 0 10px #BDC3C7;
    text-align: center;
}

.FooterCellStyleSchecdules {
    width: 110px;
    border: 20px;
    border-radius: 10px;
    background-color: transparent;
    font-size: large;
    text-align: center;    
}

</style>



<style>

    .myCalendar {
        background-color: #F3CB58;
        -webkit-border-radius: 8px;
        -moz-border-radius: 8px;
        border-radius: 8px;
        overflow: hidden;    
        width: 450px;
        border: 3px;
        border-color:black;
        border-top: 0px !important;
        font-size:large;     
    }

    .CalendarCell {
        -webkit-border-radius: 3px;
        -moz-border-radius: 3px;
        border-radius: 3px;
    }

    .AddTSButton {
        width: 115px;
        height: 50px;
        font-family: ArabicFont;
        font-size: large;
        border-width: 3px;
        border-color: #BDC3C7;
        background-color: black;
        border-radius: 5px;
        box-shadow: inset 0 0 10px #BDC3C7;        
        color:#D35400;
        transition: 0.4s;
    }

    .AddTSButton:hover{
        box-shadow: inset 0 0 10px #D35400;
        border-color:coral;      
    }



/*===================== Back button Design =====================*/
/*===================== Back button Design =====================*/

.href {
    font-size: xx-large;
    margin-left:2px;
}

.BackButton {
    height: 50px;
    width: 80px;
    background-color: #1F618D;
    color:white;
    border: solid;
    border-width: 1px;
    border-color: white;
    border-radius: 10px;
    margin-left: 975px;
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
        margin-left:970px;
    }

</style>

    
 <style>

     @font-face {
         font-family: 'ArabicFont';
         src: url(fonts/AR.ttf);
         font-style: normal;
         font-weight: 100;
     }

     .ScrollDivSchedulesX {
         width: 700px;
         height: 550px;
         max-height: 550px;
         overflow: auto;
         position: relative;
         -webkit-border-radius: 5px;
         -moz-border-radius: 5px;
         border-radius: 5px;
     }

     .GridClassSC {
         width: 687px;
         height: 550px;
         max-height: 550px;
         background-color: transparent;
     }

     .ClassSC {
         width: 700px;
         height: 550px;
         margin-left: 600px;
         background-color: orange;
         border: 4px solid #636A71;
         -webkit-border-radius: 10px;
         -moz-border-radius: 10px;
         border-radius: 10px;
         background-image: url(Gifs/classbggif.Gif);
         background-repeat: no-repeat;
         background-size: cover;
     }

     .ClassHeader {
         background-color: black;
         border: 2px solid black;
         -webkit-border-radius: 10px;
         -moz-border-radius: 10px;
         height: 20px;
         margin-left:45px;
     }

     .ClassScHeaderCell {
         width: 65px;
         height: 20px;
         background-color: black;
         border: 2px solid #D4AC0D;
         -webkit-border-radius: 4px;
         -moz-border-radius: 4px;
         align-items:center;
     }

     .ClassScHeaderCellImage {
         width: 65px;
         height: 20px;
         background-color: black;
         border: 2px solid #D4AC0D;
         -webkit-border-radius: 4px;
         -moz-border-radius: 4px;
         align-items: center;
         background-image: url(Gifs/blackfooter.Gif);
         background-repeat: no-repeat;
         background-size: cover;
     }

     .ClassScHeaderButton {
         width: 65px;
         height: 20px;
         color: darkgoldenrod;
         font-family: ArabicFont;
         text-align: center;
         border: 1px solid black;
         -webkit-border-radius: 3px;
         -moz-border-radius: 3px;
     }

     .GridClassSCInside{
         background-color:#EB984E;
         width:540px;
         margin-left:47.5px;         
     }

     .GridClassSCInsideButtons {
         font-family: ArabicFont;
         background-color: transparent;
         width: 70px;
         height: 20px;
         border: 1px solid transparent;
         font-size:small;
     }

     .GridClassButtonTitle {
         width: 300px;
         height: 30px;
         font-family: ArabicFont;
         background-color: #1F618D;
         border: 2px solid #17202A;
         -webkit-border-radius: 4px;
         -moz-border-radius: 4px;
         color:#BDC3C7;
         margin-top:30px;
         margin-bottom:3px;
         margin-left:190px;
         font-size:larger;
     }

     .GridClassFooter {
         width: 585px;
         height: 20px;
         background-color: transparent;
         background-image: url(Gifs/GoldLine.png);
         background-repeat: no-repeat;
         background-size: cover;
         -webkit-border-radius: 8px;
         -moz-border-radius: 8px;
         margin-left:47.5px;
         margin-bottom:30px;
         border: 0px solid transparent;
     }

     .CSButtonClose{
         font-family:ArabicFont;
         font-size:large;
         width:200px;
         height:35px;
         color:azure;
         background-color:black;
         border: 3px solid #636A71;
         border-radius: 5px 5px 15px 15px;
         margin-left:240px;
         transition:0.4s;
     }
     .CSButtonClose:hover{
         color:darkorange;
         font-size:larger;
         height:38px;
         border-color:#7D5013;
         box-shadow: inset 0 0 10px #7D5013;
     }

     .DownArrowButton{
         width:55px;
         height:55px;
         background-color:#1F618DB3;
         border: 3px solid black;
         border-radius: 5px;
         margin-left:312.5px;
         margin-bottom:20px;   
         box-shadow: inset 0 0 10px black;
     }


     .ShowCSButton {
         font-family: ArabicFont;
         width: 300px;
         height: 40px;
         font-size: large;
         color:#E5E7E9;
         border:3px solid #E5E7E9;
         border-radius: 5px;
         background-color: #1F618D;         
         margin-right: 20px;
         margin-top: 10px;
         box-shadow: inset 0 0 10px black;
         transition: 0.4s;
     }

     .ShowCSButton:hover{
         font-size:larger;
         color:#F5B041;
     }


 </style>


    <style>

    .switch {
        position: relative;
        display: inline-block;
        width: 50px;
        height: 20px;
        border: 2px solid orange;
        -webkit-border-radius: 20px;
        -moz-border-radius: 20px;   
        transform: rotate(90deg);
    }

        .switch input {
            display: none;
        }

    .slider {
        position: absolute;
        cursor: pointer;
        top: 0;
        left: 0;
        right: 0;
        bottom: 0;
        background-color: #ccc;
        -webkit-transition: .4s;
        transition: .4s;
    }

        .slider:before {
            position: absolute;
            content: "";
            height: 13px;
            width: 13px;
            left: 4px;
            bottom: 4px;
            background-color: white;
            -webkit-transition: .4s;
            transition: .4s;
        }

    input:checked + .slider {
        background-color: #2196F3;
    }

    input:focus + .slider {
        box-shadow: 0 0 1px #2196F3;
    }

    input:checked + .slider:before {
        -webkit-transform: translateX(26px);
        -ms-transform: translateX(26px);
        transform: translateX(26px);
    }

/* Rounded sliders */
    .slider.round {
        border-radius: 34px;
    }

        .slider.round:before {
            border-radius: 50%;
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


            <asp:TextBox CssClass="search-txt" ID="TextFind" placeholder="ENTER TECHER ID" min="1" max="999999999" Font-Bold="true"  runat="server" TextMode="Number"></asp:TextBox>  
  
            <asp:Button text="S" class="search-btn" ID="ButtonFind" runat="server" Font-Bold="true"  OnClick="ButtonFind_Click"  />

           <asp:ImageButton ID="ImageButton1" class="search-btn" ImageUrl="Gifs/Refresh.Gif" runat="server" Font-Bold="true" OnClick="ImageButton1_Click" />
            
         
       </div>


        
            
        <%--============================= Logo =============================--%>
        <%--============================= Logo =============================--%>
        <div class="alingLogo" align="right"  >

         <img src="Images/Logo.png" alt="Alternate Text" Width="110px" height="100px" align="right" />

            <br />
            <br />

               <asp:Button Class="ShowCSButton" id="AddClassesSchedules" align="right"
                Font-Bold="true" Text="Generate Classes Schedules" 
                runat="server" OnClick="AddClassesSchedules_Click"/>

        </div>

            
<%--*************************************** Grid Header ***************************************
******************************************* Grid Header ***************************************
******************************************* Grid Header ***************************************--%>
            <asp:Table ID="Grid1HeaderTabel" Width="1500px"  CssClass="GridHeader" runat="server" >

<%--===================================================================Row===============================================================>--%>
                <asp:TableRow >

<%--===================================================================CELL===============================================================>--%>
                    <asp:TableCell CssClass="HeaderCellStyleSchecdules" style="box-shadow: inset 0 0 0px #00000000;" Width="110px" >

                        <img src="Gifs/3Lines2.gif" class="EditGifechedules" />

                    </asp:TableCell>

<%--===================================================================CELL===============================================================>--%>
                    <asp:TableCell CssClass="HeaderCellStyleSchecdules" Width="110px"  >

                        <asp:Label ID="HeaderTName" CssClass="LabelSechedules"  runat="server" Text="TEACHER"></asp:Label>

                    </asp:TableCell>
<%--===================================================================CELL===============================================================>--%>
                    <asp:TableCell CssClass="HeaderCellStyleSchecdules" Width="110px" >

                        <asp:Label ID="HeaderDays" CssClass="LabelSechedules"  runat="server" Text="DAY"></asp:Label>

                    </asp:TableCell>
<%--===================================================================CELL===============================================================>--%>
                    <asp:TableCell CssClass="HeaderCellStyleSchecdules" Width="110px" >

                        <asp:Label ID="HeaderLesson1" CssClass="LabelSechedules"  runat="server" Text="Lesson 1"></asp:Label>

                    </asp:TableCell>
<%--===================================================================CELL===============================================================>--%>
                    <asp:TableCell CssClass="HeaderCellStyleSchecdules" Width="110px" >

                        <asp:Label ID="HeaderLesson2" CssClass="LabelSechedules" runat="server" Text="Lesson 2"></asp:Label>

                    </asp:TableCell>
<%--===================================================================CELL===============================================================>--%>
                    <asp:TableCell CssClass="HeaderCellStyleSchecdules" Width="110px" >

                        <asp:Label ID="HeaderLesson3" CssClass="LabelSechedules" runat="server" Text="Lesson 3"></asp:Label>

                    </asp:TableCell>
<%--===================================================================CELL===============================================================>--%>
                    <asp:TableCell CssClass="HeaderCellStyleSchecdules" Width="110px" >

                        <asp:Label ID="HeaderLesson4" CssClass="LabelSechedules" runat="server" Text="Lesson 4"></asp:Label>

                    </asp:TableCell>
<%--===================================================================CELL===============================================================>--%>
                    <asp:TableCell CssClass="HeaderCellStyleSchecdules" Width="110px" >

                        <asp:Label ID="HeaderLesson5" CssClass="LabelSechedules"  runat="server" Text="Lesson 5"></asp:Label>

                    </asp:TableCell>
<%--===================================================================CELL===============================================================>--%>
                    <asp:TableCell CssClass="HeaderCellStyleSchecdules" Width="110px" >

                        <asp:Label ID="HeaderLesson6" CssClass="LabelSechedules" runat="server" Text="Lesson 6"></asp:Label>

                    </asp:TableCell>
<%--===================================================================CELL===============================================================>--%>
                    <asp:TableCell CssClass="HeaderCellStyleSchecdules" Width="110px" >

                        <asp:Label ID="HeaderLesson7" CssClass="LabelSechedules"   runat="server" Text="Lesson 7"></asp:Label>

                    </asp:TableCell>


                </asp:TableRow>              

            </asp:Table>


<%--*************************************** GridViewTecher ***************************************
******************************************* GridViewTecher ***************************************
******************************************* GridViewTecher ***************************************--%>

              <div id="GRIDVDIV" runat="server" onscroll="SetDivPosition()" class="ScrollDivSchedules" >
            
              <asp:GridView ID="Grid1" ShowFooter="false" ShowHeader="false" CssClass="rcgv" runat="server" OnRowCommand="Grid1_RowCommand" style=" overflow:auto; max-height:500px"
              AutoGenerateColumns="False" OnRowEditing="Grid1_RowEditing" OnRowCancelingEdit="Grid1_RowCancelingEdit" 
              OnRowUpdating="Grid1_RowUpdating" BorderColor="black"  CellPadding="5" CellSpacing="5" OnRowDeleting="Grid1_RowDeleting" Font-Bold="True" 
              Font-Names="Franklin Gothic Medium" Font-Overline="False" Font-Size="Medium" Font-Strikeout="False" Font-Underline="false" ForeColor="Black"
              OnSelectedIndexChanged="Grid1_SelectedIndexChanged" HorizontalAlign="Center" BorderStyle="None" OnRowDataBound="Grid1_RowDataBound" Width="1490px" >
                  
<%--==================================================================== Columns ====================================================================--%>
<%--==================================================================== Columns ====================================================================--%>
              <Columns >  

<%--==================================================================== TemplateField EDIT ====================================================================--%>
<%--==================================================================== TemplateField EDIT ====================================================================--%>
              <asp:TemplateField ItemStyle-Width="110px">
  
              <%--============================= Item Template =============================--%>
              <%--============================= Item Template =============================--%>
              <ItemTemplate >
    
              <asp:Button   Class="ADDDELETE2"  CommandName="Edit"  CommandArgument='<%# Eval("Cnt")%>' ToolTip="Edit"
                Font-Bold="true" Font-Size="Medium" Text="EDIT"  ForeColor="#FFD800" ID="Edit" runat="server"  />      
                  
                  <br />
                       
              <asp:Button  Class="ADDDELETE2" CommandName="Delete" style="color:crimson" CommandArgument='<%# Eval("Cnt")%>' ToolTip="Delete"
                Font-Bold="true" Font-Size="Medium" Text="Delete" ForeColor="#FFD800" ID="Delete" runat="server" />
             
              </ItemTemplate>


              <%--============================= Edit Template =============================--%>
              <%--============================= Edit Template =============================--%>
              <EditItemTemplate >
           
              <asp:Button  CommandName="Update" Class="ADDDELETE2" CommandArgument='<%# Eval("Cnt")%>' ToolTip="Update" Font-Bold="true" Font-Size="Medium" Text="Update" ForeColor="#FFD800"  ID="Update" runat="server" />
              <asp:Button CommandName="Cancel"  Class="ADDDELETE2" style="color:crimson" ToolTip="Cancel" Font-Bold="true" Font-Size="Medium" Text="Cancel" ForeColor="#FFD800"  ID="Cancel" runat="server" />

              </EditItemTemplate>

            

              </asp:TemplateField>


<%--==================================================================== TemplateField Techer  ====================================================================--%>
<%--==================================================================== TemplateField Techer  ====================================================================--%>

                    <asp:TemplateField ItemStyle-Width="110px"  >

                        <%--============================= Item Template =============================--%>
                        <%--============================= Item Template =============================--%>
                        <ItemTemplate >
                            
                            <div class="GridRowMaxWidth" >

                            <asp:Label ID="LabelTID" CssClass="DropDownStyleSchedules0" style="color:darkblue" Font-Underline="true" BorderWidth="1px" BorderColor="Black" Width="120px" runat="server" Text='<%# Eval("TName")%>'></asp:Label>                                                                                     

                            </div>
                            
                        <%--============================= Edit Template =============================--%>
                        <%--============================= Edit Template =============================--%>
                        </ItemTemplate>

                        <EditItemTemplate>

                            <asp:Label ID="EditLabelTId" CssClass="DropDownStyle2" style="color:darkblue" Font-Underline="true" BorderWidth="1px" BorderColor="Black" Width="120px" runat="server"></asp:Label>  

                        </EditItemTemplate>
                     
                     
                    </asp:TemplateField>

                    

<%--==================================================================== TemplateField Days ====================================================================--%>
<%--==================================================================== TemplateField Days ====================================================================--%>

                    <asp:TemplateField ItemStyle-Width="110px" >

                        <%--============================= CLASS =============================--%>
                        <%--============================= CLASS =============================--%>
                        <ItemTemplate>

                            <asp:Label ID="LabelDay" style="color:darkblue" Font-Underline="true" CssClass="DropDownStyleSchedules0" BorderWidth="1px" brodercolor="black" Width="110px" Height="20px" runat="server" BorderColor="Black" BackColor="#F8B334" Text='<%# Eval("Day")%>'></asp:Label>

                        </ItemTemplate>

                        <%--============================= Edit Template =============================--%>
                        <%--============================= Edit Template =============================--%>
                        <EditItemTemplate>
                                                                                                                                                         
                            <asp:Button  ID="EditDay2" style="color:darkblue" Font-Underline="true" Font-Size="Large" Font-Bold="true" CssClass="DropDownStyle2" Width="130px" BorderColor="White" Height="33px" OnClick="EditDay2_Click" runat="server"/>
                            
                        </EditItemTemplate>
                      
                      
                    </asp:TemplateField>



<%--==================================================================== TemplateField Lesson1 ====================================================================--%>
<%--==================================================================== TemplateField Lesson1 ====================================================================--%>

                    <asp:TemplateField ItemStyle-Width="110px" >

                        <%--============================= Lesson1 =============================--%>
                        <%--============================= Lesson1 =============================--%>
                        <ItemTemplate>

                            <asp:Label ID="LabelSubject1" CssClass="DropDownStyleSchedules" BorderWidth="1px" brodercolor="black" Width="110px" Height="20px" runat="server" BorderColor="Black" BackColor="#F8B334" Text='<%# Eval("Subject1")%>'></asp:Label>

                            <br />

                            <asp:Label ID="LabelClass1" CssClass="DropDownStyleSchedules2" BorderWidth="1px" brodercolor="black" Width="110px" Height="20px" runat="server" BorderColor="Black" BackColor="#F8B334" Text='<%# Eval("Class1")%>'></asp:Label>

                        </ItemTemplate>

                        <%--============================= Edit Lesson1 =============================--%>
                        <%--============================= Edit Lesson1 =============================--%>
                        <EditItemTemplate>
                                                                                                                                                         
                            <asp:DropDownList  ID="DropDownSubject1" Font-Size="Medium" Font-Bold="true" CssClass="DropDownStyle2" Width="110px"  Height="33px" runat="server" OnSelectedIndexChanged="Dropdownchanged" AutoPostBack="true" ></asp:DropDownList>

                            <br />

                            <asp:DropDownList  ID="DropDownClass1" Font-Size="Medium" Font-Bold="true" CssClass="DropDownStyle2" Width="110px"  Height="33px" runat="server" ></asp:DropDownList>
                            
                        </EditItemTemplate>
                      
                      
                    </asp:TemplateField>




<%--==================================================================== TemplateField Lesson2 ====================================================================--%>
<%--==================================================================== TemplateField Lesson2 ====================================================================--%>

                    <asp:TemplateField ItemStyle-Width="110px"  >

                        <%--============================= Lesson2 =============================--%>
                        <%--============================= Lesson2 =============================--%>
                        <ItemTemplate>

                            <asp:Label ID="LabelSubject2" CssClass="DropDownStyleSchedules" BorderWidth="1px" brodercolor="black" Width="110px" Height="20px" runat="server" BorderColor="Black" BackColor="#F8B334" Text='<%# Eval("Subject2")%>'></asp:Label>

                            <br />

                            <asp:Label ID="LabelClass2" CssClass="DropDownStyleSchedules2" BorderWidth="1px" brodercolor="black" Width="110px" Height="20px" runat="server" BorderColor="Black" BackColor="#F8B334" Text='<%# Eval("Class2")%>'></asp:Label>

                        </ItemTemplate>

                        <%--============================= Edit Lesson2 =============================--%>
                        <%--============================= Edit Lesson2 =============================--%>
                        <EditItemTemplate>
                                                                                                                                                         
                            <asp:DropDownList  ID="DropDownSubject2" Font-Size="Medium" Font-Bold="true" CssClass="DropDownStyle2" Width="110px"  Height="33px" runat="server" OnSelectedIndexChanged="Dropdownchanged" AutoPostBack="true" ></asp:DropDownList>

                            <br />

                            <asp:DropDownList  ID="DropDownClass2" Font-Size="Medium" Font-Bold="true" CssClass="DropDownStyle2" Width="110px"  Height="33px" runat="server" ></asp:DropDownList>
                            
                        </EditItemTemplate>
                      
                      
                    </asp:TemplateField>

<%--==================================================================== TemplateField Lesson3 ====================================================================--%>
<%--==================================================================== TemplateField Lesson3 ====================================================================--%>

                    <asp:TemplateField ItemStyle-Width="110px" >

                        <%--============================= Lesson3 =============================--%>
                        <%--============================= Lesson3 =============================--%>
                        <ItemTemplate>

                            <asp:Label ID="LabelSubject3" CssClass="DropDownStyleSchedules" BorderWidth="1px" brodercolor="black" Width="110px" Height="20px" runat="server" BorderColor="Black" BackColor="#F8B334" Text='<%# Eval("Subject3")%>'></asp:Label>

                            <br />

                            <asp:Label ID="LabelClass3" CssClass="DropDownStyleSchedules2" BorderWidth="1px" brodercolor="black" Width="110px" Height="20px" runat="server" BorderColor="Black" BackColor="#F8B334" Text='<%# Eval("Class3")%>'></asp:Label>

                        </ItemTemplate>

                        <%--============================= Edit Lesson3 =============================--%>
                        <%--============================= Edit Lesson3 =============================--%>
                        <EditItemTemplate>
                                                                                                                                                         
                            <asp:DropDownList  ID="DropDownSubject3" Font-Size="Medium" Font-Bold="true" CssClass="DropDownStyle2" Width="110px"  Height="33px" runat="server" OnSelectedIndexChanged="Dropdownchanged" AutoPostBack="true" ></asp:DropDownList>

                            <br />

                            <asp:DropDownList  ID="DropDownClass3" Font-Size="Medium" Font-Bold="true" CssClass="DropDownStyle2" Width="110px" Height="33px" runat="server" ></asp:DropDownList>
                            
                        </EditItemTemplate>
                      
                      
                    </asp:TemplateField>

<%--==================================================================== TemplateField Lesson4 ====================================================================--%>
<%--==================================================================== TemplateField Lesson4 ====================================================================--%>

                    <asp:TemplateField ItemStyle-Width="110px" >

                        <%--============================= Lesson4 =============================--%>
                        <%--============================= Lesson4 =============================--%>
                        <ItemTemplate>

                            <asp:Label ID="LabelSubject4" CssClass="DropDownStyleSchedules" BorderWidth="1px" brodercolor="black" Width="110px" Height="20px" runat="server" BorderColor="Black" BackColor="#F8B334" Text='<%# Eval("Subject4")%>'></asp:Label>

                            <br />

                            <asp:Label ID="LabelClass4" CssClass="DropDownStyleSchedules2" BorderWidth="1px" brodercolor="black" Width="110px" Height="20px" runat="server" BorderColor="Black" BackColor="#F8B334" Text='<%# Eval("Class4")%>'></asp:Label>

                        </ItemTemplate>

                        <%--============================= Edit Lesson3 =============================--%>
                        <%--============================= Edit Lesson3 =============================--%>
                        <EditItemTemplate>
                                                                                                                                                         
                            <asp:DropDownList  ID="DropDownSubject4" Font-Size="Medium" Font-Bold="true" CssClass="DropDownStyle2" Width="110px"  Height="33px" runat="server" OnSelectedIndexChanged="Dropdownchanged" AutoPostBack="true" ></asp:DropDownList>

                            <br />

                            <asp:DropDownList  ID="DropDownClass4" Font-Size="Medium" Font-Bold="true" CssClass="DropDownStyle2" Width="110px"  Height="33px" runat="server" ></asp:DropDownList>
                            
                        </EditItemTemplate>
                      
                      
                    </asp:TemplateField>

<%--==================================================================== TemplateField Lesson5 ====================================================================--%>
<%--==================================================================== TemplateField Lesson5 ====================================================================--%>

                    <asp:TemplateField ItemStyle-Width="110px" >

                        <%--============================= Lesson5 =============================--%>
                        <%--============================= Lesson5 =============================--%>
                        <ItemTemplate>

                            <asp:Label ID="LabelSubject5" CssClass="DropDownStyleSchedules" BorderWidth="1px" brodercolor="black" Width="110px" Height="20px" runat="server" BorderColor="Black" BackColor="#F8B334" Text='<%# Eval("Subject5")%>'></asp:Label>

                            <br />

                            <asp:Label ID="LabelClass5" CssClass="DropDownStyleSchedules2" BorderWidth="1px" brodercolor="black" Width="110px" Height="20px" runat="server" BorderColor="Black" BackColor="#F8B334" Text='<%# Eval("Class5")%>'></asp:Label>

                        </ItemTemplate>

                        <%--============================= Edit Lesson5 =============================--%>
                        <%--============================= Edit Lesson5 =============================--%>
                        <EditItemTemplate>
                                                                                                                                                         
                            <asp:DropDownList  ID="DropDownSubject5" Font-Size="Medium" Font-Bold="true" CssClass="DropDownStyle2" Width="110px"  Height="33px" runat="server" OnSelectedIndexChanged="Dropdownchanged" AutoPostBack="true" ></asp:DropDownList>

                            <br />

                            <asp:DropDownList  ID="DropDownClass5" Font-Size="Medium" Font-Bold="true" CssClass="DropDownStyle2" Width="110px"  Height="33px" runat="server" ></asp:DropDownList>
                            
                        </EditItemTemplate>
                      
                      
                    </asp:TemplateField>

<%--==================================================================== TemplateField Lesson6 ====================================================================--%>
<%--==================================================================== TemplateField Lesson6 ====================================================================--%>

                    <asp:TemplateField ItemStyle-Width="110px" >

                        <%--============================= Lesson6 =============================--%>
                        <%--============================= Lesson6 =============================--%>
                        <ItemTemplate>

                            <asp:Label ID="LabelSubject6" CssClass="DropDownStyleSchedules" BorderWidth="1px" brodercolor="black" Width="110px" Height="20px" runat="server" BorderColor="Black" BackColor="#F8B334" Text='<%# Eval("Subject6")%>'></asp:Label>

                            <br />

                            <asp:Label ID="LabelClass6" CssClass="DropDownStyleSchedules2" BorderWidth="1px" brodercolor="black" Width="110px" Height="20px" runat="server" BorderColor="Black" BackColor="#F8B334" Text='<%# Eval("Class6")%>'></asp:Label>

                        </ItemTemplate>

                        <%--============================= Edit Lesson6 =============================--%>
                        <%--============================= Edit Lesson6 =============================--%>
                        <EditItemTemplate>
                                                                                                                                                         
                            <asp:DropDownList  ID="DropDownSubject6" Font-Size="Medium" Font-Bold="true" CssClass="DropDownStyle2" Width="110px"  Height="33px" runat="server" OnSelectedIndexChanged="Dropdownchanged" AutoPostBack="true" ></asp:DropDownList>

                            <br />

                            <asp:DropDownList  ID="DropDownClass6" Font-Size="Medium" Font-Bold="true" CssClass="DropDownStyle2" Width="110px"  Height="33px" runat="server" ></asp:DropDownList>
                            
                        </EditItemTemplate>
                      
                      
                    </asp:TemplateField>
<%--==================================================================== TemplateField Lesson7 ====================================================================--%>
<%--==================================================================== TemplateField Lesson7 ====================================================================--%>

                    <asp:TemplateField ItemStyle-Width="110px" >

                        <%--============================= Lesson7 =============================--%>
                        <%--============================= Lesson7 =============================--%>
                        <ItemTemplate>

                            <asp:Label ID="LabelSubject7" CssClass="DropDownStyleSchedules" BorderWidth="1px" brodercolor="black" Width="110px" Height="20px" runat="server" BorderColor="Black" BackColor="#F8B334" Text='<%# Eval("Subject7")%>'></asp:Label>

                            <br />

                            <asp:Label ID="LabelClass7" CssClass="DropDownStyleSchedules2" BorderWidth="1px" brodercolor="black" Width="110px" Height="20px" runat="server" BorderColor="Black" BackColor="#F8B334" Text='<%# Eval("Class7")%>'></asp:Label>

                        </ItemTemplate>

                        <%--============================= Edit Lesson7 =============================--%>
                        <%--============================= Edit Lesson7 =============================--%>
                        <EditItemTemplate>
                                                                                                                                                         
                            <asp:DropDownList  ID="DropDownSubject7" Font-Size="Medium" Font-Bold="true" CssClass="DropDownStyle2" Width="110px"  Height="33px" runat="server" OnSelectedIndexChanged="Dropdownchanged" AutoPostBack="true" ></asp:DropDownList>

                            <br />

                            <asp:DropDownList  ID="DropDownClass7" Font-Size="Medium" Font-Bold="true" CssClass="DropDownStyle2" Width="110px"  Height="33px" runat="server" ></asp:DropDownList>
                            
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
                    <asp:TableCell CssClass="FooterCellStyleSchecdules" Width="110px" >
                        <br />
                        <asp:Button ID="addschudbutton" CssClass="AddTSButton" Font-Bold="true" Text="ADD" runat="server" OnClick="ADD_Click" /> <br /> <br />

                    </asp:TableCell>

                    <%--===================================================================CELL===============================================================>--%>
                    <asp:TableCell CssClass="FooterCellStyleSchecdules" Width="110px" >

                        <asp:DropDownList  ID="FooterTName" Font-Size="Medium" Font-Bold="true" onmousedown="this.size=3;" onfocusout="this.size=1;" CssClass="DropDownStyle3" runat="server"
                            AutoPostBack="True" OnSelectedIndexChanged="FooterTName_SelectedIndexChanged" ></asp:DropDownList>

                    </asp:TableCell>

                    <%--===================================================================CELL===============================================================>--%>
                    <asp:TableCell CssClass="FooterCellStyleSchecdules" Width="110px" colspan="0">
                  


            <table style="height:60px" >

                  <tr>

                      <td>                         
                                                 <%--========= Switch for Days and Date =========--%>
                                    <label class="switch">

                                     <asp:CheckBox id="CheckSlid" OnCheckedChanged="CheckSlid_CheckedChanged" AutoPostBack="true" runat="server" />
                                     <span class="slider round"></span>

                                    </label>
                      </td>

                      <td> 

                                <asp:Button Class="AddTSButton" Text="Select Day" Font-Bold="true" Visible="false" Font-Size="Large" runat="server" ID="ButtonCalendar" OnClick="ButtonCalendar_Click" />

                                <asp:DropDownList ID="FooterDayWeek" AutoPostBack="True" CssClass="DropDownDaysWeek" onmousedown="this.size=3;" onfocusout="this.size=1;" OnSelectedIndexChanged="FooterDayWeek_SelectedIndexChanged" runat="server">

                                 <asp:listitem text="One" value="One"></asp:listitem>
                                 <asp:listitem text="Two" value="Two"></asp:listitem>
                                 <asp:listitem text="Three" value="Three"></asp:listitem>
                                 <asp:listitem text="Four" value="Four"></asp:listitem>
                                 <asp:listitem text="Five" value="Five"></asp:listitem>
                                 <asp:listitem text="Six" value="Six"></asp:listitem>
                                 <asp:listitem text="Seven" value="Seven"></asp:listitem>

                                </asp:DropDownList>
                          
                      </td>

                  </tr>

              </table>
                     
                    </asp:TableCell>

                    <%--===================================================================CELL===============================================================>--%>
                    <asp:TableCell CssClass="FooterCellStyleSchecdules" Width="140px" >

                        <asp:DropDownList  ID="FooterLesson1" Font-Size="Medium" Font-Bold="true" CssClass="DropDownStyle2" Width="110px"  Height="33px" runat="server" OnSelectedIndexChanged="Dropdownchanged" AutoPostBack="true" ></asp:DropDownList>                        

                        <asp:DropDownList  ID="FooterClass1" Visible="false" Font-Size="Medium" Font-Bold="true" CssClass="DropDownStyle22" Width="110px"  Height="33px" runat="server" ></asp:DropDownList>

                    </asp:TableCell>
                   <%--===================================================================CELL===============================================================>--%>
                    <asp:TableCell CssClass="FooterCellStyleSchecdules" Width="140px" >

                        <asp:DropDownList  ID="FooterLesson2" Font-Size="Medium" Font-Bold="true" CssClass="DropDownStyle2" Width="110px"  Height="33px" runat="server" OnSelectedIndexChanged="Dropdownchanged" AutoPostBack="true" ></asp:DropDownList>

                        <asp:DropDownList  ID="FooterClass2" Visible="false" Font-Size="Medium" Font-Bold="true" CssClass="DropDownStyle22" Width="110px"  Height="33px" runat="server" ></asp:DropDownList>

                    </asp:TableCell>
                   <%--===================================================================CELL===============================================================>--%>
                    <asp:TableCell CssClass="FooterCellStyleSchecdules" Width="140px" >

                        <asp:DropDownList  ID="FooterLesson3" Font-Size="Medium" Font-Bold="true" CssClass="DropDownStyle2" Width="110px"  Height="33px" runat="server" OnSelectedIndexChanged="Dropdownchanged" AutoPostBack="true" ></asp:DropDownList>

                        <asp:DropDownList  ID="FooterClass3" Visible="false" Font-Size="Medium" Font-Bold="true" CssClass="DropDownStyle22" Width="110px"  Height="33px" runat="server" ></asp:DropDownList>

                    </asp:TableCell>
                   <%--===================================================================CELL===============================================================>--%>
                    <asp:TableCell CssClass="FooterCellStyleSchecdules" Width="140px" >

                        <asp:DropDownList  ID="FooterLesson4" Font-Size="Medium" Font-Bold="true" CssClass="DropDownStyle2" Width="110px"  Height="33px" runat="server" OnSelectedIndexChanged="Dropdownchanged" AutoPostBack="true" ></asp:DropDownList>

                        <asp:DropDownList  ID="FooterClass4" Visible="false" Font-Size="Medium" Font-Bold="true" CssClass="DropDownStyle22" Width="110px"  Height="33px" runat="server" ></asp:DropDownList>

                    </asp:TableCell>
                   <%--===================================================================CELL===============================================================>--%>
                    <asp:TableCell CssClass="FooterCellStyleSchecdules" Width="140px" >

                        <asp:DropDownList  ID="FooterLesson5" Font-Size="Medium" Font-Bold="true" CssClass="DropDownStyle2"  Width="110px" Height="33px" runat="server" OnSelectedIndexChanged="Dropdownchanged" AutoPostBack="true" ></asp:DropDownList>

                        <asp:DropDownList  ID="FooterClass5" Visible="false" Font-Size="Medium" Font-Bold="true" CssClass="DropDownStyle22" Width="110px"  Height="33px" runat="server" ></asp:DropDownList>

                    </asp:TableCell>
                   <%--===================================================================CELL===============================================================>--%>
                    <asp:TableCell CssClass="FooterCellStyleSchecdules" Width="140px" >

                        <asp:DropDownList  ID="FooterLesson6" Font-Size="Medium" Font-Bold="true" CssClass="DropDownStyle2" Width="110px"  Height="33px" runat="server" OnSelectedIndexChanged="Dropdownchanged" AutoPostBack="true" ></asp:DropDownList>

                        <asp:DropDownList  ID="FooterClass6" Visible="false" Font-Size="Medium" Font-Bold="true" CssClass="DropDownStyle22" Width="110px"  Height="33px" runat="server" ></asp:DropDownList>

                    </asp:TableCell>
                   <%--===================================================================CELL===============================================================>--%>
                    <asp:TableCell CssClass="FooterCellStyleSchecdules" Width="140px" >

                        <asp:DropDownList  ID="FooterLesson7" Font-Size="Medium" Font-Bold="true" CssClass="DropDownStyle2" Width="110px"  Height="33px" runat="server" OnSelectedIndexChanged="Dropdownchanged" AutoPostBack="true" ></asp:DropDownList>

                        <asp:DropDownList  ID="FooterClass7" Visible="false" Font-Size="Medium" Font-Bold="true" CssClass="DropDownStyle22" Width="110px"  Height="33px" runat="server" ></asp:DropDownList>

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



<%--*************************************** PopUp Calendar ***************************************
******************************************* PopUp Calendar ***************************************
******************************************* PopUp Calendar ***************************************--%>

        <div runat="server" class="PopUpMessage"  id="CalenderPopUp">

            <br /> <br />
            <br /> <br />
            <br /> <br />
            <br /> <br />
            <br /> <br />
            <br /> <br />
            <br /> <br />


           <table id="CalenderPopUpTable" cellspacing="0px" cellpadding="13px" class="Tabel2" align="center" border="1">

               <%-----------------------------ROW-----------------------------%>
            <tr >

                <br />
                <br />

                <td class="CellStyle2" align="center" colspan="2" >


                    <asp:Calendar ID="MyCalendar" CssClass="myCalendar" Font-Bold="true" runat="server" OnSelectionChanged="CalendarLabelConvert_Click">

                        <TodayDayStyle ForeColor="Red" CssClass="CalendarCell" BackColor="#F3CB58"></TodayDayStyle>

                        <DayStyle Font-Bold="True" BorderWidth="1px" BorderStyle="Solid" BorderColor="Black"></DayStyle>

                        <NextPrevStyle ForeColor="Blue" Font-Bold="true" Font-Size="X-Large"/>

                        <DayHeaderStyle Font-Size="Large" Font-Bold="True" ForeColor="Orange" BorderColor="Orange" BackColor="Black" ></DayHeaderStyle>

                        <TitleStyle Font-Size="Larger" Font-Bold="True" BackColor="#F3CB58"></TitleStyle>

                        <WeekendDayStyle BackColor="#C0C0C0"></WeekendDayStyle>

                        <SelectedDayStyle ForeColor="Orange" BorderColor="Orange" CssClass="CalendarCell" BackColor="Black" />


                    </asp:Calendar>


                </td>

            </tr>

            <%-----------------------------ROW-----------------------------%>
            <tr>
                <td class="CellStyle2" align="center" colspan="2" >&nbsp;

                 <asp:Label ID="CalendarLabel" BackColor="Transparent" Font-Bold="true" ForeColor="Orange" Font-Size="Larger" runat="server" Text="Select Day"></asp:Label>
                 <asp:Button ID="CalendarLabelConvert" Visible="false" runat="server" OnClick="CalendarLabelConvert_Click"/>

                </td>

            </tr>


               <%-----------------------------ROW-----------------------------%>
            <tr>
                <td class="CellStyle2" align="center" colspan="2" >&nbsp;

                    <asp:Button Class="ButtonS" Font-Bold="True" Text="Cancele" ID="CalendarCancele" runat="server" ForeColor="#FFD800" OnClick="CalendarCancele_Click" />

                    <asp:Button Class="ButtonS" Font-Bold="True" Text="Add" ID="AddCalendarDate" runat="server" ForeColor="#FFD800" OnClick="AddCalendarDate_Click" />

                </td>

            </tr>

            </table>


         </div>


     <%--------------------------------------PopUp ClassSchudels--------------------------------%>
     <%--------------------------------------PopUp ClassSchudels--------------------------------%>
          <div runat="server" visible="false" class="PopUpMessage" id="DivClassSC">

            <br /> <br />
            <br /> <br />
            <br /> <br />

               <div runat="server" visible="true" class="ClassSC">

                  <div id="Div1" runat="server" class="ScrollDivSchedulesX" >
                                        <%--------------------------------------GridView--------------------------------%>
                  <asp:GridView ID="GridClassSC" CssClass="GridClassSC" ShowHeader="false" AutoGenerateColumns="false" HeaderStyle-Height="35px" runat="server" >

                      <Columns>
                          
                          <%--===== Teplate =====--%>
                          <asp:TemplateField ItemStyle-Width="500px" >

                              <ItemTemplate>

                                  <%--===== Title Class Name =====--%>
                                  <asp:Button ID="GridClassButtonTitle" CssClass="GridClassButtonTitle" Font-Bold="true" runat="server" Text="Title" />


             <%--===== Table Header =====--%>
             <%--===== Table Header =====--%>
             <asp:Table ID="GridClassSchuds" CssClass="ClassHeader" runat="server" >

<%--===================================================================Row===============================================================>--%>
                <asp:TableRow >

<%--===================================================================CELL===============================================================>--%>
                    <asp:TableCell CssClass="ClassScHeaderCellImage" >


                    </asp:TableCell>

<%--===================================================================CELL===============================================================>--%>
                    <asp:TableCell CssClass="ClassScHeaderCell" >

                        <asp:Label ID="LabelL1" runat="server" CssClass="ClassScHeaderButton" Text="Lesson 1"></asp:Label>

                    </asp:TableCell>
<%--===================================================================CELL===============================================================>--%>
                    <asp:TableCell CssClass="ClassScHeaderCell" >

                        <asp:Label ID="LabelL2" runat="server" CssClass="ClassScHeaderButton" Text="Lesson 2"></asp:Label>

                    </asp:TableCell>
<%--===================================================================CELL===============================================================>--%>
                    <asp:TableCell CssClass="ClassScHeaderCell" >

                        <asp:Label ID="LabelL3" runat="server" CssClass="ClassScHeaderButton" Text="Lesson 3"></asp:Label>

                    </asp:TableCell>
<%--===================================================================CELL===============================================================>--%>
                    <asp:TableCell CssClass="ClassScHeaderCell" >

                        <asp:Label ID="LabelL4" runat="server" CssClass="ClassScHeaderButton" Text="Lesson 4"></asp:Label>

                    </asp:TableCell>
<%--===================================================================CELL===============================================================>--%>
                    <asp:TableCell CssClass="ClassScHeaderCell" >

                        <asp:Label ID="LabelL5" runat="server" CssClass="ClassScHeaderButton" Text="Lesson 5"></asp:Label>

                    </asp:TableCell>
<%--===================================================================CELL===============================================================>--%>
                    <asp:TableCell CssClass="ClassScHeaderCell" >

                        <asp:Label ID="LabelL6" runat="server" CssClass="ClassScHeaderButton" Text="Lesson 6"></asp:Label>

                    </asp:TableCell>
<%--===================================================================CELL===============================================================>--%>
                    <asp:TableCell CssClass="ClassScHeaderCell" >

                        <asp:Label ID="LabelL7" runat="server" CssClass="ClassScHeaderButton" Text="Lesson 7"></asp:Label>

                    </asp:TableCell>

                </asp:TableRow>              

            </asp:Table>

                                   <%--===== GridViews =====--%>
                                  <asp:GridView ID="GridView1" CssClass="GridClassSCInside" AutoGenerateColumns="false" ShowHeader="false" runat="server" DataSource='<%# Eval("Grids")%>'>

                                      <Columns>
                                                                   
                                          <%--====== Template ====--%>
                                          <asp:TemplateField>

                                              <ItemTemplate>
                                                  <asp:Button ID="Day" CssClass="GridClassSCInsideButtons" style="color:blue;" Font-Bold="true" runat="server" Text='<%# Eval("Day")%>' />
                                              </ItemTemplate>

                                          </asp:TemplateField>

                                                                                    <%--====== Template ====--%>
                                          <asp:TemplateField>

                                              <ItemTemplate>
                                                  <asp:Button ID="L1" CssClass="GridClassSCInsideButtons" runat="server" Text='<%# Eval("L1")%>' />
                                              </ItemTemplate>

                                          </asp:TemplateField>

                                                                                    <%--====== Template ====--%>
                                          <asp:TemplateField>

                                              <ItemTemplate>
                                                  <asp:Button ID="L2" CssClass="GridClassSCInsideButtons" runat="server" Text='<%# Eval("L2")%>' />
                                              </ItemTemplate>

                                          </asp:TemplateField>

                                                                                    <%--====== Template ====--%>
                                          <asp:TemplateField>

                                              <ItemTemplate>
                                                  <asp:Button ID="L3" CssClass="GridClassSCInsideButtons" runat="server" Text='<%# Eval("L3")%>' />
                                              </ItemTemplate>

                                          </asp:TemplateField>

                                                                                    <%--====== Template ====--%>
                                          <asp:TemplateField>

                                              <ItemTemplate>
                                                  <asp:Button ID="L4" CssClass="GridClassSCInsideButtons" runat="server" Text='<%# Eval("L4")%>' />
                                              </ItemTemplate>

                                          </asp:TemplateField>

                                                                                    <%--====== Template ====--%>
                                          <asp:TemplateField>

                                              <ItemTemplate>
                                                  <asp:Button ID="L5" CssClass="GridClassSCInsideButtons" runat="server" Text='<%# Eval("L5")%>' />
                                              </ItemTemplate>

                                          </asp:TemplateField>

                                                                                    <%--====== Template ====--%>
                                          <asp:TemplateField>

                                              <ItemTemplate>
                                                  <asp:Button ID="L6" CssClass="GridClassSCInsideButtons" runat="server" Text='<%# Eval("L6")%>' />
                                              </ItemTemplate>

                                          </asp:TemplateField>

                                                                                    <%--====== Template ====--%>
                                          <asp:TemplateField>

                                              <ItemTemplate>
                                                  <asp:Button ID="L7" CssClass="GridClassSCInsideButtons" runat="server" Text='<%# Eval("L7")%>' />
                                              </ItemTemplate>

                                          </asp:TemplateField>

                                      </Columns>

                                  </asp:GridView>

                                  <%--===== Footer (GoldLine) =====--%>
                                  <asp:Button ID="FooterGoldLine" CssClass="GridClassFooter" Font-Bold="true" runat="server"/>

                                  <%--===== (DownArrowButton GIF) =====--%>
                                  <asp:Button ID="DownArrowButton" CssClass="DownArrowButton" style="background-image:url(Gifs/DownArrow.Gif);" runat="server"/>

                              </ItemTemplate>

                          </asp:TemplateField>

                      </Columns>                    

                  </asp:GridView>                     
                    
                  </div>

                   <asp:Button ID="ClassSchudClose" Class="CSButtonClose" Font-Bold="True" Text="Close" OnClick="ClassSchudClose_Click" runat="server" />
                   
              </div>
           
          </div>


<%--*************************************** PopUp Loading ***************************************
******************************************* PopUp Loading ***************************************
******************************************* PopUp Loading ***************************************--%>



        <div runat="server" class="PopUpMessage" id="DivLoading">


            <br /> <br />
            <br /> <br />
            <br /> <br />
            <br /> <br />
            <br /> <br />
            <br /> <br />
            <br /> <br />
            <br /> <br />
            <br /> <br />


           <table id="TabelLoading" width="250px" height="250px"  class="TabelLoading" align="center" >
               <%-----------------------------ROW-----------------------------%>

            <tr >
                <td class="CellStyle2" align="center" colspan="2" height="20px" >   
                 
                   <img src="Gifs/Loading1.gif" height="100px" width="100px" />

                   <br />

                   <asp:Label ID="Label1" BackColor="Transparent" Font-Size="Large" ForeColor="#FFB053" runat="server" Text="One Moment..."></asp:Label>

                    <br />
                    <br />

                </td>

            </tr>
               <%-----------------------------ROW-----------------------------%>

            </table>


         </div>


     <%--------------------------------------DivSelectDayWeek--------------------------------%>
     <%--------------------------------------DivSelectDayWeek--------------------------------%>
          <div runat="server" visible="false" class="PopUpMessage" id="DivDivDayWeek">

              <div class="Tabel2" style="height:130px; width:200px; margin-left:850px; margin-top:350px">

                                <asp:DropDownList ID="DivDayWeek" AutoPostBack="True" CssClass="DropDownDaysWeek" onmousedown="this.size=3;"
                                    OnSelectedIndexChanged="DivDayWeek_SelectedIndexChanged" style="margin-left:43px; margin-top:35px"
                                    onfocusout="this.size=1;" runat="server">

                                 <asp:listitem text="One" value="One"></asp:listitem>
                                 <asp:listitem text="Two" value="Two"></asp:listitem>
                                 <asp:listitem text="Three" value="Three"></asp:listitem>
                                 <asp:listitem text="Four" value="Four"></asp:listitem>
                                 <asp:listitem text="Five" value="Five"></asp:listitem>
                                 <asp:listitem text="Six" value="Six"></asp:listitem>
                                 <asp:listitem text="Seven" value="Seven"></asp:listitem>

                                </asp:DropDownList>

              </div>
         
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

<%--*************************************** Tests END ***************************************
******************************************* Tests END ***************************************
******************************************* Tests END ***************************************--%>
       
    </form>

    <script type="text/javascript">
        function ShowLoading(e) {
            var divBG = document.createElement('divBG');
            var div = document.createElement('div');
            var img = document.createElement('img');
            img.src = 'Gifs/Loading2.Gif';
            img.style.cssText ='width:100px;  height:100px'
            div.innerHTML = "<br\>Loading...<br\>";
            div.style.cssText = 'position: fixed; color:#E5E7E9; Font-Bold:true; font-size:larger; top: 33%; left: 43.5%; z-index: 5000; border-radius: 10px; width: 222px; text-align: center; background: #000000A6; border: 4px solid #CACFD2; box-shadow: inset 0 0 30px #D4AC0D;';
            div.appendChild(img);

            divBG.style.cssText = 'width:100%; height: 100%; background: #000000A6; z-index: 5; position: absolute;'
            divBG.appendChild(div);

            document.body.appendChild(divBG);

            // These 2 lines cancel form submission, so only use if needed.
            // window.event.cancelBubble = true;
            // e.stopPropagation();
        }
    </script>
</body>
</html>
