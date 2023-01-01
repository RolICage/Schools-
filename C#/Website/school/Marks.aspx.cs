using school.App_Code;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net.NetworkInformation;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace school
{
    public partial class Marks : System.Web.UI.Page
    {
        public static DataTable MyTable, DropTable, CheckTabel, MyTable2;
        public static int x = 0;
        public static int PopUpFixer = 0;
        public string Case = "All";
        public static bool Check = false;



        //////////////////////////////////////////////Constractors///////////////////////////////////////////
        //////////////////////////////////////////////Constractors///////////////////////////////////////////



        ////////////////////////////////////////////////////////////////////////////////////////////////////
        ////////////////////////////////////////////////////////////////////////////////////////////////////
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        protected void Page_Load(object sender, EventArgs e)
        {
            if (System.Web.HttpContext.Current.Session["SCODE"] != null)
            {

                if (!IsPostBack)
                {
                    DropTable = new DataTable();
                    MyTable = new DataTable();
                    MyTable2 = new DataTable();
                    Session["StudentID"] = "";
                    Grid1FooterTabel.Style["background-image"] = "Gifs/ezgiffot.gif";
                    Grid1.ShowFooter = false;
                    DivMessage.Visible = false;

                    RefreshAll();
                }
            }
            else
            {
                Response.Redirect("Login Page.aspx");
            }
        }

        public void RefreshAll()
        {
            RefresDDLists();
            FillChapters();
            FillKind();
            RefreshGrid();                 
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        ////////////////////////////////////////////////////////////////////////////////////////////////////
        ////////////////////////////////////////////////////////////////////////////////////////////////////



        public void Clear()
        {
            DropTable.Columns.Clear();
            DropTable.Rows.Clear();
            DropTable.Clear();

            MyTable.Columns.Clear();
            MyTable.Rows.Clear();
            MyTable.Clear();

            MyTable2.Columns.Clear();
            MyTable2.Rows.Clear();
            MyTable2.Clear();
        }

        public void FillChapters()
        {
            Clear();

            DropTable.Columns.Add(new DataColumn("Code", typeof(string)));
            DropTable.Columns.Add(new DataColumn("Name", typeof(string)));

            DataRow Row;

            for (int i=1;i<=3;i++)
            {
                Row = DropTable.NewRow();

                Row["Code"] = i.ToString();
                Row["Name"] = "Chapter "+i.ToString();

                DropTable.Rows.Add(Row);
            }

            FooterChapter.DataSource = DropTable;
            FooterChapter.DataValueField = "Code";
            FooterChapter.DataTextField = "Name";
            FooterChapter.DataBind();
        }

        public void FillKind()
        {
            Clear();

            DropTable.Columns.Add(new DataColumn("Code", typeof(string)));
            DropTable.Columns.Add(new DataColumn("Name", typeof(string)));

            DataRow Row;

            for (int i = 1; i <= 3; i++)
            {
                Row = DropTable.NewRow();

                Row["Code"] = i.ToString();
                if (i == 1)
                {
                    Row["Code"] = i.ToString();
                    Row["Name"] = "Test";                
                }

                if (i == 2)
                {
                    Row["Code"] = i.ToString();
                    Row["Name"] = "HomeWork";
                }

                if (i == 3)
                {
                    Row["Code"] = i.ToString();
                    Row["Name"] = "Project";
                }

                DropTable.Rows.Add(Row);
            }

            FooterKind.DataSource = DropTable;
            FooterKind.DataValueField = "Code";
            FooterKind.DataTextField = "Name";
            FooterKind.DataBind();
        }

        public void RefreshGrid()
        {

            int i = 0;
            string SubjectName, ClassName;
            string SID ,SCode, CCode,Chapter ,Mark, Kind, percentage, Cnt;

            Clear();

            if(Session["StudentID"].Equals(""))
            {
                MyTable = MyClass.ShowMarks();
            }

            else
            {
                MyTable = MyClass.SelectMarkBySID2(Session["StudentID"].ToString());
            }
            

            while (i < MyTable.Rows.Count)
            {
                SID = MyTable.Rows[i][0].ToString();
                SCode = MyTable.Rows[i][1].ToString();
                CCode = MyTable.Rows[i][3].ToString();
                Mark = MyTable.Rows[i][2].ToString();
                Chapter = MyTable.Rows[i][4].ToString();
                Kind = MyTable.Rows[i][5].ToString();
                percentage = MyTable.Rows[i][6].ToString();
                Cnt = MyTable.Rows[i][7].ToString();


                SubjectName = MyClass.SelectSubject(SCode).Rows[0][0].ToString();
                ClassName = MyClass.SelectClass(int.Parse(CCode.ToString())).Rows[0][0].ToString();

                DataRow Row = null;


                if (i == 0)
                {
                    MyTable2.Columns.Add(new DataColumn("Student", typeof(string)));
                    MyTable2.Columns.Add(new DataColumn("Subject", typeof(string)));
                    MyTable2.Columns.Add(new DataColumn("Class", typeof(string)));
                    MyTable2.Columns.Add(new DataColumn("Mark", typeof(string)));
                    MyTable2.Columns.Add(new DataColumn("Chapter", typeof(string)));
                    MyTable2.Columns.Add(new DataColumn("Kind", typeof(string)));
                    MyTable2.Columns.Add(new DataColumn("percentage", typeof(string)));
                    MyTable2.Columns.Add(new DataColumn("Cnt", typeof(string)));
                }


                Row = MyTable2.NewRow();

                Row["Student"] = SID.ToString();
                Row["Subject"] = SubjectName.ToString();
                Row["Class"] = ClassName.ToString();
                Row["Mark"] = Mark.ToString();
                Row["Chapter"] = FooterChapter.Items.FindByValue(Chapter.ToString());
                Row["Kind"] = FooterKind.Items.FindByValue(Kind.ToString());
                Row["percentage"] = percentage.ToString();
                Row["Cnt"] = Cnt.ToString();

                MyTable2.Rows.Add(Row);

                i++;
            }

            Grid1.DataSource = MyTable2;
            Grid1.DataBind();

        }

        public void RefresDDLists()
        {

            FooterSName.Items.Clear();
            FooterCName.Items.Clear();
            FooterChapter.Items.Clear();
            FooterKind.Items.Clear();
            FooterStudentName.Text = "";
            FooterMark.Text = "";

            DropTable = MyClass.ShowSubjects();

            int Length = DropTable.Rows.Count;

            if (Length > 0)
            {

                FooterSName.DataSource = DropTable;
                FooterSName.DataValueField = "SubCode";
                FooterSName.DataTextField = "SubName";
                FooterSName.DataBind();

            }

            DropTable = MyClass.ShowClasses();

            Length = DropTable.Rows.Count;

            if (Length > 0)
            {

                FooterCName.DataSource = DropTable;
                FooterCName.DataValueField = "ClassCode";
                FooterCName.DataTextField = "CName";
                FooterCName.DataBind();

            }

        }


        ////////////////////////////////////////////////////////////////////////////////////////////////////
        ////////////////////////////////////////////////////////////////////////////////////////////////////
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        protected void Grid1_RowEditing(object sender, GridViewEditEventArgs e)
        {

            int index = e.NewEditIndex;
            Grid1.EditIndex = e.NewEditIndex;



            RefreshAll();

            Grid1.Rows[index].Style["background-image"] = "Images/GridEditRow.Gif";


            ////////////////////////////////////////////// Fill DropDown Chapters //////////////////////////////////////////////
            ////////////////////////////////////////////// Fill DropDown Chapters //////////////////////////////////////////////


            DropDownList Chapter = ((DropDownList)Grid1.Rows[index].FindControl("DropDownChapter"));

            DropTable.Columns.Clear();
            DropTable.Clear();

            DropTable.Columns.Add(new DataColumn("Code", typeof(string)));
            DropTable.Columns.Add(new DataColumn("Name", typeof(string)));


            for (int i = 1; i <= 3; i++)
            {
                DataRow Row = DropTable.NewRow();

                Row["Code"] = i.ToString();
                Row["Name"] = "Chapter " + i.ToString();

                DropTable.Rows.Add(Row);
            }


            Chapter.DataSource = DropTable;
            Chapter.DataValueField = "Code";
            Chapter.DataTextField = "Name";
            Chapter.DataBind();

            Chapter.Items.FindByText(Session["Chapter"].ToString()).Selected = true;

            ////////////////////////////////////////////// Fill DropDown Chapters //////////////////////////////////////////////
            ////////////////////////////////////////////// Fill DropDown Chapters //////////////////////////////////////////////

            DropDownList Kind = ((DropDownList)Grid1.Rows[index].FindControl("DropDownKind"));
            string Kind2 = "";

            DropTable.Columns.Clear();
            DropTable.Clear();

            DropTable.Columns.Add(new DataColumn("Code", typeof(string)));
            DropTable.Columns.Add(new DataColumn("Name", typeof(string)));



            for (int i = 1; i <= 3; i++)
            {
                DataRow Row = DropTable.NewRow();

                Row["Code"] = i.ToString();
                if (i == 1)
                {
                    Row["Code"] = i.ToString();
                    Row["Name"] = "Test";
                }

                if (i == 2)
                {
                    Row["Code"] = i.ToString();
                    Row["Name"] = "HomeWork";
                }

                if (i == 3)
                {
                    Row["Code"] = i.ToString();
                    Row["Name"] = "Project";
                }

                DropTable.Rows.Add(Row);
            }


            Kind.DataSource = DropTable;
            Kind.DataValueField = "Code";
            Kind.DataTextField = "Name";
            Kind.DataBind();

            Kind2 = Session["Kind"].ToString();

            Kind.Items.FindByText(Kind2).Selected = true;

        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        ////////////////////////////////////////////////////////////////////////////////////////////////////
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        protected void Grid1_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            Grid1.EditIndex = -1;
            RefreshAll();
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        ////////////////////////////////////////////////////////////////////////////////////////////////////
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        protected void Grid1_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            string SID = "", Mark="", Chapter="",Kind="",percentage="", Result = "", SIDCodeToRow = "", ClassCodeToRow = "", SCodeToRow, MarkToRow="", ChapterToRow="";
            int Row;

            Check = CheckNet();

            if (Check == true)
            {

                SID = (Grid1.Rows[e.RowIndex].FindControl("TextBoxStudentName") as TextBox).Text.ToString();
                Mark = (Grid1.Rows[e.RowIndex].FindControl("TextBoxMark") as TextBox).Text.ToString();
                Chapter = (Grid1.Rows[e.RowIndex].FindControl("DropDownChapter") as DropDownList).SelectedValue.ToString();
                Kind = (Grid1.Rows[e.RowIndex].FindControl("DropDownKind") as DropDownList).SelectedValue.ToString();
                percentage = (Grid1.Rows[e.RowIndex].FindControl("DropDownpercentage") as TextBox).Text.ToString();


                Row = int.Parse(Session["RowToUpdate"].ToString());


                if (SID != "" && Mark != "" && Chapter != "" && Kind != "" && percentage != "")
                {
                    MyTable = MyClass.SelectStudent(SID);

                    if (MyTable.Rows.Count == 1)
                    {
                        Result = MyClass.UpdateMark(SID, int.Parse(Mark.ToString()), Chapter, Kind, percentage, Row);

                        DivMessage.Visible = true;
                        LabelMessage.Text = "   " + Result;
                        Grid1.EditIndex = -1;
                        RefreshAll();
                    }

                    else
                    {
                        DivMessage.Visible = true;
                        LabelMessage.Text = "Student Not Found !";
                    }

                }


                else
                {
                    DivMessage.Visible = true;
                    LabelMessage.Text = "Value is Not Selected";
                }
            }
            else
            {
                DivMessage.Visible = true;
                LabelMessage.Text = "There Is no internet!";
            }

        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        ////////////////////////////////////////////////////////////////////////////////////////////////////
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        protected void Grid1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        //////////////////////////////////////////////////////////////////////////////////////////////////////
        //////////////////////////////////////////////////////////////////////////////////////////////////////
        //////////////////////////////////////////////////////////////////////////////////////////////////////

        protected void Grid1_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            int Row;
            Check = CheckNet();

            if (Check == true)
            {
                Row = int.Parse(Session["RowToRemove"].ToString());

                MyClass.RemoveMarkByRow(Row);

                RefreshAll();

                DivMessage.Visible = true;
                LabelMessage.Text = "* Removed *";
            }
            else
            {
                DivMessage.Visible = true;
                LabelMessage.Text = "There Is no internet!";
            }

        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        ////////////////////////////////////////////////////////////////////////////////////////////////////
        ////////////////////////////////////////////////////////////////////////////////////////////////////
        protected void Grid1_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            Check = CheckNet();

            if (Check == true)
            {
                if (e.CommandName.Equals("Edit"))
                {
                    int index;
                    string StudentName, SubjectName, ClassName, Mark, Chapter, Kind;

                    index = int.Parse(e.CommandArgument.ToString());

                    StudentName = (Grid1.Rows[index].FindControl("LabelStudentName") as Label).Text.ToString();
                    SubjectName = (Grid1.Rows[index].FindControl("LabelSubjectName") as Label).Text.ToString();
                    ClassName = (Grid1.Rows[index].FindControl("LabelClassName") as Label).Text.ToString();
                    Mark = (Grid1.Rows[index].FindControl("LabelMark") as Label).Text.ToString();
                    Chapter = (Grid1.Rows[index].FindControl("LabelChapter") as Label).Text.ToString();
                    Kind = (Grid1.Rows[index].FindControl("KindChapter") as Label).Text.ToString();

                    Session["StudentName"] = StudentName;
                    Session["SubjectName"] = SubjectName;
                    Session["ClassName"] = ClassName;
                    Session["Mark"] = Mark;
                    Session["Chapter"] = Chapter;
                    Session["Kind"] = Kind;

                }

                else if (e.CommandName.Equals("Delete"))
                {
                    Session["RowToRemove"] = e.CommandArgument.ToString();
                }

                else if (e.CommandName.Equals("Update"))
                {
                    Session["RowToUpdate"] = e.CommandArgument.ToString();
                }
            }
            else
            {
                DivMessage.Visible = true;
                LabelMessage.Text = "There Is no internet!";
            }

        }


        ////////////////////////////////////////////////////////////////////////////////////////////////////
        ////////////////////////////////////////////////////////////////////////////////////////////////////
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        protected void Grid1_RowDataBound(object sender, GridViewRowEventArgs e)
        {


        }


        ////////////////////////////////////////////////////////////////////////////////////////////////////
        ////////////////////////////////////////////////////////////////////////////////////////////////////
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        protected void ButtonMessage_Click(object sender, EventArgs e)
        {

            Check = CheckNet();

            if (Check == true)
            {
                DivMessage.Visible = false;

                if (PopUpFixer == 1)
                {
                    PopUpFixer = 0;
                }

                LabelMessage.Text = "";
            }
        }

        protected void Refresh_Click(object sender, ImageClickEventArgs e)
        {

            Check = CheckNet();

            if (Check == true)
            {
                TextFind.Text = "";
                Session["StudentID"] = "";
                RefreshAll();
            }
            else
            {
                DivMessage.Visible = true;
                LabelMessage.Text = "There Is no internet!";
            }
        }

        protected void ADD_Click(object sender, EventArgs e)
        {

            string SID="", SCode="", ClassCode="", Mark="", Chapter="" , Kind="" , percentage="";
            string Check = "";

            Marks.Check = CheckNet();

            if (Marks.Check == true)
            {
                SID = FooterStudentName.Text.ToString();
                SCode = FooterSName.SelectedValue.ToString();
                ClassCode = FooterCName.SelectedValue.ToString();
                Mark = FooterMark.Text.ToString();
                Chapter = FooterChapter.SelectedValue.ToString();
                Kind = FooterKind.SelectedValue.ToString();
                percentage = Footerpercentage.Text.ToString();


                if (SID != "" && SCode != "" && ClassCode != "" && Mark != "" && Chapter != "" && Kind != "" && percentage != "")
                {
                    MyTable = MyClass.SelectStudent(SID);

                    if (MyTable.Rows.Count != 0)
                    {
                        if (int.Parse(percentage.ToString()) >= 5 && int.Parse(percentage.ToString()) <= 100)
                        {
                            if (int.Parse(Mark.ToString()) >= 0 && int.Parse(Mark.ToString()) <= 100)
                            {
                                if (int.Parse(percentage.ToString()) >= int.Parse(Mark.ToString()))
                                {
                                    Check = MyClass.SelectStudent(SID).Rows[0][3].ToString();

                                    if (Check.Equals(ClassCode))
                                    {
                                        Check = "Not";

                                        MyTable = MyClass.SelectInfoSubjectTecherByClassCode(ClassCode);

                                        for (int Cnt = 0; Cnt < MyTable.Rows.Count; Cnt++)
                                        {
                                            if (MyTable.Rows[Cnt][0].Equals(SCode))
                                            {
                                                Check = "OK";
                                            }
                                        }



                                        if (Check.Equals("OK"))
                                        {
                                            string R = CheckChapter(SID, SCode, Chapter, percentage);

                                            if (R.Equals("OK"))
                                            {
                                                LabelMessage.Text = MyClass.AddMark(SID, SCode, int.Parse(ClassCode.ToString()), int.Parse(Mark.ToString()), Chapter, Kind, percentage);
                                                DivMessage.Visible = true;
                                            }

                                            else
                                            {
                                                LabelMessage.Text = "You Cannot Pass 100% in a Chapter !";
                                                DivMessage.Visible = true;
                                            }

                                        }

                                        else
                                        {
                                            LabelMessage.Text = "Student Is Not Learning This Subject !";
                                            DivMessage.Visible = true;
                                        }

                                    }

                                    else
                                    {
                                        LabelMessage.Text = "Student Is not Realated To This Class !";
                                        DivMessage.Visible = true;
                                    }

                                }

                                else
                                {
                                    LabelMessage.Text = "Mark Must Be Smaller Than Percentage !";
                                    DivMessage.Visible = true;
                                }

                            }

                            else
                            {
                                LabelMessage.Text = "Mark Must Be Between 0 - 100 !";
                                DivMessage.Visible = true;
                            }

                        }

                        else
                        {
                            LabelMessage.Text = "Percentage Must Be Between 5 - 100 !";
                            DivMessage.Visible = true;
                        }

                    }

                    else
                    {
                        LabelMessage.Text = "Student Not Found !";
                        DivMessage.Visible = true;
                    }

                }

                else
                {
                    LabelMessage.Text = "There is Empty Boxes";
                    DivMessage.Visible = true;
                }

                RefreshAll();
                Clear();
            }
            else
            {
                DivMessage.Visible = true;
                LabelMessage.Text = "There Is no internet!";
            }
        }

        public string CheckChapter(string SID,string Subject,string Chapter,string percentage)
        {
            DataTable DT = new DataTable();

            DT = MyClass.SelectMarksRowC(SID, Subject, Chapter);
            int per = 0;


            if(DT.Rows.Count!=0)
            {
                for(int i=0;i<DT.Rows.Count;i++)
                {
                    per += int.Parse(DT.Rows[i][6].ToString());
                }
            }

            per += int.Parse(percentage.ToString());

            if (per <= 100)
                return "OK";

            else
              return "Not";
        }

        protected void ButtonFind_Click(object sender, EventArgs e)
        {
            int i = 0;
            string SubjectName, ClassName;
            string SID, SCode, CCode, Chapter, Mark, Kind, percentage, Cnt;

            Check = CheckNet();

            if (Check == true)
            {
                SID = TextFind.Text.ToString();

                MyTable2 = new DataTable();

                MyTable = MyClass.SelectMarkBySID2(SID);

                if (MyTable.Rows.Count != 0)
                {
                    Session["StudentID"] = SID.ToString();

                    while (i < MyTable.Rows.Count)
                    {
                        SID = MyTable.Rows[i][0].ToString();
                        SCode = MyTable.Rows[i][1].ToString();
                        CCode = MyTable.Rows[i][3].ToString();
                        Mark = MyTable.Rows[i][2].ToString();
                        Chapter = MyTable.Rows[i][4].ToString();
                        Kind = MyTable.Rows[i][5].ToString();
                        percentage = MyTable.Rows[i][6].ToString();
                        Cnt = MyTable.Rows[i][7].ToString();


                        SubjectName = MyClass.SelectSubject(SCode).Rows[0][0].ToString();
                        ClassName = MyClass.SelectClass(int.Parse(CCode.ToString())).Rows[0][0].ToString();

                        DataRow Row = null;


                        if (i == 0)
                        {
                            MyTable2.Columns.Add(new DataColumn("Student", typeof(string)));
                            MyTable2.Columns.Add(new DataColumn("Subject", typeof(string)));
                            MyTable2.Columns.Add(new DataColumn("Class", typeof(string)));
                            MyTable2.Columns.Add(new DataColumn("Mark", typeof(string)));
                            MyTable2.Columns.Add(new DataColumn("Chapter", typeof(string)));
                            MyTable2.Columns.Add(new DataColumn("Kind", typeof(string)));
                            MyTable2.Columns.Add(new DataColumn("percentage", typeof(string)));
                            MyTable2.Columns.Add(new DataColumn("Cnt", typeof(string)));
                        }


                        Row = MyTable2.NewRow();

                        Row["Student"] = SID.ToString();
                        Row["Subject"] = SubjectName.ToString();
                        Row["Class"] = ClassName.ToString();
                        Row["Mark"] = Mark.ToString();
                        Row["Chapter"] = FooterChapter.Items.FindByValue(Chapter.ToString());
                        Row["Kind"] = FooterKind.Items.FindByValue(Kind.ToString());
                        Row["percentage"] = percentage.ToString();
                        Row["Cnt"] = Cnt.ToString();

                        MyTable2.Rows.Add(Row);

                        i++;
                    }

                    Grid1.DataSource = MyTable2;
                    Grid1.DataBind();
                    MyTable2.Clear();
                }

                else
                {
                    DivMessage.Visible = true;
                    LabelMessage.Text = "Student Not Found !                                       or There is no Marks for him !";
                }

                TextFind.Text = "";
            }
            else
            {
                DivMessage.Visible = true;
                LabelMessage.Text = "There Is no internet!";
            }
        }

        public bool CheckNet()
        {
            try
            {
                Ping myPing = new Ping();
                String host = "google.com";
                byte[] buffer = new byte[32];
                int timeout = 1000;
                PingOptions pingOptions = new PingOptions();
                PingReply reply = myPing.Send(host, timeout, buffer, pingOptions);
                return true;
            }
            catch (Exception)
            {
                return false;
            }

        }
    }
}