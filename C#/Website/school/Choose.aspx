<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Choose.aspx.cs" Inherits="school.Choose" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">

    
    <link href="stylepage2.css" rel="stylesheet" />
    <link href="FinalStyleXX.css" rel="stylesheet" />

    <title></title>

    <style>

        @font-face {
            font-family: 'ArabicFont';
            src: url(fonts/AR.ttf);
            font-style: normal;
            font-weight: 100;
        }

        .TabelSelect {
            position: absolute;
            top: 35%;
            left: 50%;
            -webkit-border-radius: 10px;
            -moz-border-radius: 10px;
            border-radius: 10px;
        }

        .TabelSelect2 {
            width: auto;
            position: absolute;
            top: 50%;
            left: 50%;
            -webkit-border-radius: 10px;
            -moz-border-radius: 10px;
            border-radius: 10px;
        }

        .TabelSelectcell {
            -webkit-border-radius: 10px;
            -moz-border-radius: 10px;
            border-radius: 10px;
            border-width: 3px;
        }

        .middle2 {
            transform: translate(-50%,-50%);
        }


        .menu2 {
            width: 300px;
            border-radius: 8px;
            overflow: hidden;
            height: auto;
        }
    </style>

 <style type="text/css" <%--Button Style--%> >

    @font-face {
        font-family: 'ArabicFont';
        src: url(fonts/AR.ttf);
        font-style: normal;
        font-weight: 100;
    }

    .ButtonInfo {
        font-family: ArabicFont;
        font-size: x-large;
        color: orange;
        height: 100px;
        width: 100px;
        border: 3px solid gray;
        -webkit-border-radius: 10px;
        -moz-border-radius: 10px;
        border-radius: 10px;
        margin-left:40px;
        transition: 0.4s;
    }

        .ButtonInfo:hover {
            height: 110px;
            width: 110px;
            border-color:crimson;
        }

    .CancelInfo {
        font-family: ArabicFont;
        width: 130px;
        height: 40px;
        border: 2px solid orange;
        -webkit-border-radius: 10px;
        -moz-border-radius: 10px;
        border-radius: 10px;
        font-size:large;
        margin-left:170px;
        transition: 0.4s;
    }

        .CancelInfo:hover {
            height: 45px;
            width: 140px;
            border-color: crimson;
            margin-left:165px;
        }

     .TabelVido {
         border: 4px solid;
         border-color: crimson;
         margin: auto;
         vertical-align: middle;
         width: 960px;
         height: 540px;
         background-color: orange;
         -webkit-border-radius: 10px;
         -moz-border-radius: 10px;
         border-radius: 10px;
     }

     
    .CancelInfo2 {
        font-family: ArabicFont;
        width: 130px;
        height: 40px;
        border: 2px solid orange;
        -webkit-border-radius: 10px;
        -moz-border-radius: 10px;
        border-radius: 10px;
        font-size:large;
        margin-left:406px;
        transition: 0.4s;
    }

        .CancelInfo2:hover {
            height: 45px;
            width: 140px;
            border-color: crimson;
        }


     .Video {
         width: 960px;
         height: 540px;
         -webkit-border-radius: 10px;
         -moz-border-radius: 10px;
         border-radius: 10px;
         border: 4px solid;
         border-color: black;
     }

     /*/////////////////////////////////*/
     /*/////////////////////////////////*/

     .ButtonInfo2 {
         font-family: ArabicFont;
         font-size: x-large;
         color: orange;
         height: 100px;
         width: 100px;
         border: 3px solid gray;
         -webkit-border-radius: 10px;
         -moz-border-radius: 10px;
         border-radius: 10px;
         margin-left: 87px;
         transition: 0.4s;
     }

     .ButtonInfo2:hover {
         height: 110px;
         width: 110px;
         border-color: crimson;
     }

</style>

    <style>

        .PromotDIV {
            margin-left: 470px;
            margin-top: 100.6px;
        }

        .PromotVideo{
            height:420px;
            width:640px;
            margin-top:2px;
            background-color:black;
            border:5px solid #CACFD2;
            border-radius:10px;
        }

        .PromotLabel{
            font-family:ArabicFont;
            width:200px;
            height:30px;
            background-color:red;
            margin-left:200px;
            font-size:larger;
            border:1px solid Black;
            border-radius: 5px 5px 0px 0px;
        }

    </style>

    <link rel="stylesheet" href="https://use.fontawesome.com/releases/v5.8.1/css/all.css"
</head>
<body>

    <form id="form1" runat="server">

        <%--============================== PromotVideo ==============================--%>

        <div class="PromotDIV">
            <asp:Label ID="Label1" Font-Bold="true" CssClass="PromotLabel" runat="server" Text="- Advertise Your video Here -"></asp:Label>

               <div class="PromotVideo" runat="server" >
            
                 <asp:Panel ID="PromotVideo" runat="server"></asp:Panel>

               </div>
        </div>
        


        <%--============================== Men 1 ==============================--%>
        <%--============================== Men 1 ==============================--%>

        <table class="TabelSelect" style="margin-left:320px" >
            <tr class="TabelSelectcell" >

                <%--============================== Col ==============================--%>
                <td  class="TabelSelectcell" >
                    <div class="TabelSelectcell" >
       <div class="middle2" >
           <div class="menu2" >

                  <li class="Students" id="Students">
                      <a runat="server" style="font-size:large" id="titlestudnet" href="#Students" class="btn"><i class="fas fa-user-graduate"></i></a>
                      <div class="smenu">
                          <a runat="server" style="font-family:ArabicFont; font-size:medium" id="studentbutton" href="Students.aspx" ></a>
                          <a runat="server" style="font-family:ArabicFont; color:crimson" id="e1" onserverclick="e1_ServerClick" href="#" ></a>                        
                      </div>
                  </li>

               <%------------------>--%>

               <li class="Students" id="Parents" runat="server" >
                      <a runat="server" style="font-size:large" id="titleparents" href="#Parents" class="btn"><i class="fas fa-book"></i></a>
                      <div class="smenu">
                          <a runat="server" style="font-family:ArabicFont; font-size:medium" id="parentsbutton" href="Parents.aspx" ></a>
                          <a runat="server" style="font-family:ArabicFont; color:crimson" id="e2" href="#" onserverclick="e2_ServerClick" ></a>
                     </div>
                </li> 

               <%------------------>--%>
              
                  <li class="Students" id="Techers">
                      <a runat="server" style="font-size:large" id="titleteachers" href="#Techers" class="btn"><i class="fas fa-book"></i></a>
                      <div class="smenu">
                          <a runat="server" style="font-family:ArabicFont; font-size:medium" id="teacherbutton" href="Techers.aspx" ></a>
                          <a runat="server" style="font-family:ArabicFont; color:crimson" id="e3" href="#" ></a>
                      </div>
                  </li> 

               <%------------------>--%>
                            
                <li class="Students" id="Subjects">
                      <a runat="server" style="font-size:large" id="titlesubjects" href="#Subjects" class="btn"><i class="fas fa-book"></i></a>
                      <div class="smenu">
                          <a runat="server" style="font-family:ArabicFont; font-size:medium" id="subbutton" href="Subjects.aspx" ></a>
                          <a runat="server" style="font-family:ArabicFont; color:crimson" id="e4" href="#" ></a>
                      </div>
                  </li> 

               <%------------------>--%>

                <li class="Students" id="NewYear" runat="server" visible="false">
                      <a runat="server" style="font-size:large" id="titlenewyear" href="#NewYear" class="btn"><i class="fas fa-book"></i></a>
                      <div class="smenu">
                          <a runat="server" style="font-family:ArabicFont; font-size:medium" id="newyearbutton" href="NewYear.aspx" ></a>
                          <a runat="server" style="font-family:ArabicFont; color:crimson" id="e5" href="#" ></a>
                      </div>
                  </li> 

               <%------------------>--%>

               <li class="Students" id="SubTecher" runat="server" >
                      <a runat="server" style="font-size:large" id="titlesubteacher" href="#SubTecher" class="btn"><i class="fas fa-book"></i></a>
                      <div class="smenu">
                          <a runat="server" style="font-family:ArabicFont; font-size:medium" id="subteacherbutton" href="SubTecher.aspx" ></a>
                          <a runat="server" style="font-family:ArabicFont; color:crimson" id="e6" href="#" ></a>
                      </div>
                  </li> 

               <%------------------>--%>


               <li class="Students" id="TecherSchedule" runat="server" >
                      <a runat="server" style="font-size:large" id="titleschedules" href="#TecherSchedule" class="btn"><i class="fas fa-book"></i></a>
                      <div class="smenu">
                          <a runat="server" style="font-family:ArabicFont; font-size:medium" id="schedulesbutton" href="TecherSchedule.aspx" ></a>
                          <a runat="server" style="font-family:ArabicFont; color:crimson" id="e7" href="#" ></a>
                     </div>
                </li>
               
               <%------------------>--%>

                 <li class="Students" id="Classes" runat="server" >
                      <a runat="server" style="font-size:large" id="titleclasses" href="#Classes" class="btn"><i class="fas fa-book"></i></a>
                      <div class="smenu">
                          <a runat="server" style="font-family:ArabicFont; font-size:medium" id="classesbutton" href="Classes.aspx" ></a>
                          <a runat="server" style="font-family:ArabicFont; color:crimson" id="e8" href="#" ></a>
                     </div>
                </li>                         
           </div>
       </div>
    </div>
                </td>             
            </tr>
        </table>

     <%--------------------------------------PopUp--------------------------------%>
     <%--------------------------------------PopUp--------------------------------%>
          <div runat="server" visible="false" class="PopUpMessage" id="DivINFO">

            <br /> <br />
            <br /> <br />
            <br /> <br />
            <br /> <br />
            <br /> <br />
            <br /> <br />
            <br /> <br />

           <table id="PopTable2" class="Tabel2" border="1">
           <%-----------------------------ROW-----------------------------%>
            <tr>
                <%--========== TD ====--%>
                <td class="CellStyle2" style="margin-top:10px;">&nbsp;

                     <asp:Button ID="InfoAdd" CssClass="ButtonInfo" runat="server" style="background-image: url( Images/bginfo.Gif );" Text="اضافه" OnClick="InfoAdd_Click" />
                     <asp:Button ID="InfoUpdate" CssClass="ButtonInfo" runat="server" style="background-image: url( Images/bginfo.Gif );" Text="اضافه" OnClick="InfoUpdate_Click" />
                     <asp:Button ID="InfoID" CssClass="ButtonInfo" runat="server" style="background-image: url( Images/bginfo.Gif );" Text="اضافه" OnClick="InfoID_Click" />

                </td>

            </tr>

            <%-----------------------------ROW-----------------------------%>
            <tr>
                <%--========== TD ====--%>
                <td class="CellStyle2">&nbsp;
                    <asp:Button Class="CancelInfo" style="background-image: url( Images/GridEditRow.Gif );" Font-Bold="True" Text="Close" ID="CancelInfo" OnClick="CancelInfo_Click" runat="server" ForeColor="#FFD800" />
                <br /> <br />   
                </td>
            </tr>

            </table>

         </div>


        
     <%--------------------------------------PopUp 2--------------------------------%>
     <%--------------------------------------PopUp 2--------------------------------%>
          <div runat="server" visible="false" class="PopUpMessage" id="DivINFO2">

            <br /> <br />
            <br /> <br />
            <br /> <br />
            <br /> <br />
            <br /> <br />
            <br /> <br />
            <br /> <br />

           <table id="PopTable2" class="Tabel2" border="1">
           <%-----------------------------ROW-----------------------------%>
            <tr>
                <%--========== TD ====--%>
                <td class="CellStyle2" style="margin-top:10px;">&nbsp;

                     <asp:Button ID="InfoUpdate2" CssClass="ButtonInfo2" runat="server" OnClick="InfoUpdate2_Click" style="background-image: url( Images/bginfo.Gif );" Text="اضافه"  />
                     <asp:Button ID="InfoID2" CssClass="ButtonInfo2" runat="server" OnClick="InfoID2_Click" style="background-image: url( Images/bginfo.Gif );" Text="اضافه"  />

                </td>

            </tr>

            <%-----------------------------ROW-----------------------------%>
            <tr>
                <%--========== TD ====--%>
                <td class="CellStyle2">&nbsp;
                    <asp:Button Class="CancelInfo" style="background-image: url( Images/GridEditRow.Gif );" Font-Bold="True" Text="Close" ID="CancelInfoParent" OnClick="CancelInfo_Click" runat="server" ForeColor="#FFD800" />
                <br /> <br />   
                </td>
            </tr>

            </table>

         </div>



     <%--------------------------------------PopUp--------------------------------%>
     <%--------------------------------------PopUp--------------------------------%>
          <div runat="server" visible="false" class="PopUpMessage" id="DivVideo">

            <br /> <br />
            <br /> <br />
            <br /> <br />

           <table id="TableVideo" class="TabelVido" border="1">
           <%-----------------------------ROW-----------------------------%>
            <tr>
                <%--========== TD ====--%>
                <td class="CellStyle2" style="margin-top:10px;">&nbsp;

                    <%--//////////////////// video frame--%>
                    <asp:Panel CssClass="Video" ID="youtubeVideo" runat="server"></asp:Panel>


                </td>

            </tr>

           <%-----------------------------ROW-----------------------------%>
            <tr>
                <%--========== TD ====--%>
                <td class="CellStyle2">&nbsp;
                    <asp:Button CssClass="CancelInfo2" style="background-image: url( Images/GridEditRow.Gif );" Font-Bold="True" Text="Close" ID="CancelInfo2" OnClick="CancelInfo_Click" runat="server" ForeColor="#FFD800" />
                <br /> <br />   
                </td>
            </tr>


            </table>

          </div>

        <%/*-------------------------------------------------------photo wave*/%>
       <section>
           <div class="wave">
              
           </div>
       </section>


    </form>
</body>
</html>
