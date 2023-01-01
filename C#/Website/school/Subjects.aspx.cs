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
    public partial class Subjects : System.Web.UI.Page
    {
        public static DataTable MyTable, MyClassTable, CheckTabel;
        public static int x = 0;
        public static int PopUpFixer = 0;
        public string Case = "All";
        bool Check = false;

        public static List<string> TechersToRemove = new List<string>();



        //////////////////////////////////////////////Constractors///////////////////////////////////////////
        //////////////////////////////////////////////Constractors///////////////////////////////////////////


        ////////////////////////////////////////////////////////////////////////////////////////////////////
        ////////////////////////////////////////////////////////////////////////////////////////////////////
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        protected void Page_Load(object sender, EventArgs e)
        {
            if (System.Web.HttpContext.Current.Session["SCODE"] != null)
            {

                DivMessage.Visible = false;

                if (!IsPostBack)
                {
                    PopUpAccept.Visible = false;
                    Grid1FooterTabel.Style["background-image"] = "Gifs/ezgiffot.gif";
                    Grid1.ShowFooter = false;
                    GetSubjects(-1);
                }
            }
            else
            {
                Response.Redirect("Login Page.aspx");
            }
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        ////////////////////////////////////////////////////////////////////////////////////////////////////
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public void GetSubjects(int index)
        {
            MyTable = MyClass.ShowSubjects();
            Grid1.DataSource = MyTable;
            Grid1.DataBind();

            //============================ Change Lang ============================
            //============================ Change Lang ============================
            if (Session["Lang"].ToString().Equals("EN"))
            {
                //============================ Change Edits Lang ============================
                Button Edits;

                for (int rowindex = 0; rowindex < Grid1.Rows.Count; rowindex++)
                {
                    if (rowindex == index)
                    {
                        Edits = ((Button)Grid1.Rows[rowindex].FindControl("Update"));
                        Edits.Text = "Update";

                        Edits = ((Button)Grid1.Rows[rowindex].FindControl("Cancel"));
                        Edits.Text = "Cancel";
                    }

                    else
                    {
                        Edits = ((Button)Grid1.Rows[rowindex].FindControl("Edit"));
                        Edits.Text = "EDIT";

                        Edits = ((Button)Grid1.Rows[rowindex].FindControl("Delete"));
                        Edits.Text = "Delete";
                    }
                }

                //============================ Change Header Lang ============================
                HeaderSubName.Text = "Subject Name";
                FooterSubName.Attributes.Add("placeholder", "Subject Name");

                //============================ Change Footer Lang ============================
                addsubjectbutton.Text = "Add Subject";
            }

            else
            {
                //============================ Change Edits Lang ============================
                Button Edits;

                for (int rowindex = 0; rowindex < Grid1.Rows.Count; rowindex++)
                {
                    if (rowindex == index)
                    {
                        Edits = ((Button)Grid1.Rows[rowindex].FindControl("Update"));
                        Edits.Text = "تحديث";

                        Edits = ((Button)Grid1.Rows[rowindex].FindControl("Cancel"));
                        Edits.Text = "الغاء";

                    }

                    else
                    {
                        Edits = ((Button)Grid1.Rows[rowindex].FindControl("Edit"));
                        Edits.Text = "اعداد";

                        Edits = ((Button)Grid1.Rows[rowindex].FindControl("Delete"));
                        Edits.Text = "حذف";
                    }

                }

                //============================ Change Header Lang ============================
                HeaderSubName.Text = "الموضوع";

                //============================ Change Footer Lang ============================
                addsubjectbutton.Text = "اضف الموضوع";
                FooterSubName.Attributes.Add("placeholder", "اسم الموضوع");
            }
        }

        public string RandomCode()
        {
            Random rand = new Random((int)DateTime.Now.Ticks);
            int numIterations = 0;
            string Code = "";
            int i = 1,Rows=0;

            while (i!=0)
            {
                Code = "";
                numIterations = rand.Next(0, 9);
                Code = numIterations.ToString();
                numIterations = rand.Next(0, 9);
                Code += numIterations.ToString();

                MyTable = MyClass.SelectSubject(Code);

                Rows = MyTable.Rows.Count;

                if (Rows == 0)
                    i = 0;
            }

            return Code;
        }


        ////////////////////////////////////////////////////////////////////////////////////////////////////
        ////////////////////////////////////////////////////////////////////////////////////////////////////
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        protected void Grid1_RowEditing(object sender, GridViewEditEventArgs e)
        {

            int index = e.NewEditIndex;
            Grid1.EditIndex = e.NewEditIndex;


            string Sub = "";

            Sub = Grid1.DataKeys[index].Value.ToString();

            DataTable SubExist;
            SubExist = MyClass.SelectSubject(Sub);

            if (SubExist.Rows.Count > 0)
            {
                GetSubjects(index);

                Grid1.Rows[index].Style["background-image"] = "Images/GridEditRow.Gif";
            }

            else
            {
                Grid1.EditIndex = -1;
                GetSubjects(-1);
            }          

            x = 0;
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        ////////////////////////////////////////////////////////////////////////////////////////////////////
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        protected void Grid1_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            Grid1.EditIndex = -1;
            GetSubjects(-1);
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        ////////////////////////////////////////////////////////////////////////////////////////////////////
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        protected void Grid1_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            string SubjectName = "", Result = "";


            MyClass.CheckForInternetConnection();
            if (MyClass.NetCheck == true)
            {

                DataTable SubExist;
                SubExist = MyClass.SelectSubjectByName(Session["SubName"].ToString());

                if (SubExist.Rows.Count > 0)
                {
                    SubjectName = (Grid1.Rows[e.RowIndex].Cells[1].FindControl("TextBoxSubName") as TextBox).Text.ToString();

                    if (SubjectName != "")
                    {
                        MyTable = MyClass.SelectSubjectByName(SubjectName);

                        if (MyTable.Rows.Count == 0)
                        {
                            Result = MyClass.UpdateNameinSunjects(SubjectName, Session["SubName"].ToString());
                            DivMessage.Visible = true;

                            //============================ Change Lang ============================
                            if (Session["Lang"].ToString().Equals("EN"))
                                LabelMessage.Text = "   " + Result;

                            else
                                LabelMessage.Text = "تم تحديث الموضوع";

                            Grid1.EditIndex = -1;
                            GetSubjects(-1);
                        }

                        else
                        {
                            DivMessage.Visible = true;

                            //============================ Change Lang ============================
                            if (Session["Lang"].ToString().Equals("EN"))
                                LabelMessage.Text = "SubName Name Allready Used !";

                            else
                                LabelMessage.Text = "قد تمه اضافه الموضوع من قبل !";
                        }

                    }

                    else
                    {
                        DivMessage.Visible = true;

                        if (Session["Lang"].ToString().Equals("EN"))
                            LabelMessage.Text = "   There is An Empty Boxies";

                        else
                            LabelMessage.Text = "    هناك سطور فارغه !";
                    }
                }

                else
                {
                    Grid1.EditIndex = -1;
                    GetSubjects(-1);
                }
                    
            }
            else
            {
                DivMessage.Visible = true;

                if (Session["Lang"].ToString().Equals("EN"))
                    LabelMessage.Text = "Connection Time Out !";

                else
                    LabelMessage.Text = "لا يوجد هناك انترنت !";
            }
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        ////////////////////////////////////////////////////////////////////////////////////////////////////
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        protected void Grid1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        ////////////////////////////////////////////////////////////////////////////////////////////////////
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        protected void Grid1_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            string SubCode="",SubName="", Result="";
            int Checking = 0;

            MyClass.CheckForInternetConnection();
            if (MyClass.NetCheck == true)
            {
                SubName = (Grid1.Rows[e.RowIndex].FindControl("LabelSubName") as Label).Text.ToString();
                
                DataTable SubExist;
                SubExist = MyClass.SelectSubject(SubName);

                if (SubExist.Rows.Count > 0)
                {
                    SubCode = MyClass.SelectSubjectByName(SubName).Rows[0][1].ToString();

                    if (!SubCode.Equals("111"))
                    {
                        MyTable = MyClass.SelectSchoolRank(Session["SCODE"].ToString());

                        Result = MyTable.Rows[0][0].ToString();

                        if (!Result.Equals("1"))
                        {
                            MyTable = MyClass.SelectMarkBySubCode(SubCode);
                            if (MyTable.Rows.Count > 0)
                                Checking++;
                        }


                        MyTable = MyClass.SelectSubjectTecherBySCode(SubCode);
                        if (MyTable.Rows.Count > 0)
                            Checking++;


                        if (Checking > 0)
                        {
                            for (int i = 0; i < MyTable.Rows.Count; i++)
                                TechersToRemove.Add(MyTable.Rows[i][1].ToString());

                            Session["SubCode"] = SubCode.ToString();
                            Session["SubName"] = SubName.ToString();


                            //============================ Change Lang ============================
                            if (Session["Lang"].ToString().Equals("EN"))
                                LabelAccept.Text = "There Is Data Will Be Removed From Other Tabels       (Cannot undo changes)        Do You Want To Continue ?";
                            else
                                LabelAccept.Text += "هذا الموضوع مرتبط ببيانات أخرى .. هل تريد حذفه؟";


                            PopUpAccept.Visible = true;
                            if (Session["Lang"].ToString().Equals("AR"))
                            {
                                Accept.Text = "موافق";
                                Cancel.Text = "الغاء";
                            }

                            Checking = 0;
                        }

                        else
                        {
                            MyClass.RemoveSubject(SubCode);

                            GetSubjects(-1);

                            DivMessage.Visible = true;

                            //============================ Change Lang ============================
                            if (Session["Lang"].ToString().Equals("EN"))
                                LabelMessage.Text = "Subject   " + SubName.ToString() + " Removed";

                            else
                                LabelMessage.Text = SubName.ToString() + " تم حذف الموضوع";


                            if (Session["Lang"].ToString().Equals("AR"))
                                ButtonMessage.Text = "اغلاق";
                        }
                    }
                }

                else
                {
                    Grid1.EditIndex = -1;
                    GetSubjects(-1);
                }
                    
                Checking = 0;
            }
            else
            {
                DivMessage.Visible = true;
                //============================ Change Lang ============================
                if (Session["Lang"].ToString().Equals("EN"))
                    LabelMessage.Text = "There Is no internet!";
                else
                    LabelMessage.Text = "لا يوجد هناك انترنت !";
            }

        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        ////////////////////////////////////////////////////////////////////////////////////////////////////
        ////////////////////////////////////////////////////////////////////////////////////////////////////
        protected void Grid1_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            MyClass.CheckForInternetConnection();
            if (MyClass.NetCheck == true)
            {
                if (e.CommandName.Equals("Edit"))
                {
                    string Name, ID;
                    int RowIndex;

                    RowIndex = int.Parse(e.CommandArgument.ToString());

                    Name = (Grid1.Rows[RowIndex].FindControl("LabelSubName") as Label).Text.ToString();

                    Session["SubName"] = Name;
                }
            }
            else
            {
                DivMessage.Visible = true;
                //============================ Change Lang ============================
                if (Session["Lang"].ToString().Equals("EN"))
                    LabelMessage.Text = "There Is no internet!";
                else
                LabelMessage.Text = "لا يوجد هناك انترنت !";
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
            MyClass.CheckForInternetConnection();
            if (MyClass.NetCheck == true)
            {
                DivMessage.Visible = false;

                if (PopUpFixer == 1)
                {
                    PopUpFixer = 0;
                }

                LabelMessage.Text = "";
            }
        }

        protected void ADD_Click(object sender, EventArgs e)
        {


            string SubName = "", SubCode = "", Result = "";


            if (Session["Lang"].ToString().Equals("AR"))
                ButtonMessage.Text = "اغلاق";

            CheckTabel = new DataTable();

            MyClass.CheckForInternetConnection();
            if (MyClass.NetCheck == true)
            {
                SubName = FooterSubName.Text.ToString();
                SubCode = RandomCode();


                if (SubName != "")
                {
                    CheckTabel.Clear();
                    CheckTabel = MyClass.SelectSubjectByName(SubName);

                    if (CheckTabel.Rows.Count == 0)
                    {

                        //////////////////// Add Subject ////////////////////
                        //////////////////// Add Subject //////////////////// 

                        Result = MyClass.AddSubjects(SubName, SubCode);
                        DivMessage.Visible = true;
                        //============================ Change Lang ============================
                        if (Session["Lang"].ToString().Equals("EN"))
                            LabelMessage.Text = "Subject Added";

                        else
                            LabelMessage.Text = "تمت إضافة الموضوع";

                        Grid1.EditIndex = -1;
                        GetSubjects(-1);

                        FooterSubName.Text = "";
                        DivMessage.Visible = true;
                        FooterSubName.BorderColor = System.Drawing.ColorTranslator.FromHtml("#808080");
                    }


                    else
                    {
                        DivMessage.Visible = true;
                        //============================ Change Lang ============================
                        if (Session["Lang"].ToString().Equals("EN"))
                            LabelMessage.Text += "The Subject Allready Added";
                        else
                            LabelMessage.Text += "تم اضافة الموضوع من قبل";
                        GetSubjects(-1);
                    }

                    CheckTabel.Clear();
                }


                else
                {
                    DivMessage.Visible = true;
                    //============================ Change Lang ============================
                    if (Session["Lang"].ToString().Equals("EN"))
                        LabelMessage.Text = "   There is An Empty Boxies";
                    else
                        LabelMessage.Text = "هناك سطور فارغة";
                    FooterSubName.BorderColor = System.Drawing.ColorTranslator.FromHtml("#808080");
                }
            }
            else
            {
                DivMessage.Visible = true;
                //============================ Change Lang ============================
                if (Session["Lang"].ToString().Equals("EN"))
                    LabelMessage.Text = "There Is no internet!";
                else
                    LabelMessage.Text = "لا يوجد هناك انترنت !";
            }
        }

        protected void Accept_Click(object sender, EventArgs e)
        {
            //======================================================================================== Remove Data =================
            //======================================================================================== Remove Data =================

            string Result = "";

            MyClass.CheckForInternetConnection();
            if (MyClass.NetCheck == true)
            {
                for (int i = 0; i < TechersToRemove.Count; i++)
                    MyClass.RemoveScheduleByTID(TechersToRemove[i].ToString());

                MyClass.RemoveSubjectTecherBySubCode(Session["SubCode"].ToString());

                MyTable = MyClass.SelectSchoolRank(Session["SCODE"].ToString());

                Result = MyTable.Rows[0][0].ToString();

                if (!Result.Equals("1"))
                {
                    MyClass.RemoveMarkBySubCode(Session["SubCode"].ToString());
                }

                MyClass.RemoveSubject(Session["SubCode"].ToString());

                Regenerate();

                TechersToRemove.Clear();

                LabelAccept.Text = "";
                PopUpAccept.Visible = false;

                DivMessage.Visible = true;
                //============================ Change Lang ============================
                if (Session["Lang"].ToString().Equals("EN"))
                    LabelMessage.Text = "Subject   " + Session["SubName"].ToString() + "   Removed  With Other Data !";

                else
                    LabelMessage.Text =" تم حذف الموضوع مع البيانات الأخرى";

                GetSubjects(-1);
            }
            else
            {
                DivMessage.Visible = true;
                LabelMessage.Text = "There Is no internet!";
            }
        }

        protected void Cancel_Click(object sender, EventArgs e)
        {
            LabelAccept.Text = "";
            PopUpAccept.Visible = false;
        }

        public void Regenerate()
        {
            List<string> ListOfClasses = new List<string>();
            List<string> ListCase = new List<string>();
            string Date = "", ClassCode = "", Row = "", Row2 = "", Case = "Do";

            MyClass.RemoveClassSchedules();

            MyTable = MyClass.ShowTecherSchedules();

            if (MyTable.Rows.Count != 0)
            {
                for (int Cnt = 0; Cnt < MyTable.Rows.Count; Cnt++)
                {
                    for (int Cnt2 = 1; Cnt2 <= 7; Cnt2++)
                    {
                        ClassCode = "";
                        Date = MyTable.Rows[Cnt][9].ToString();
                        Row = MyTable.Rows[Cnt][Cnt2].ToString();

                        if (!Row.Equals("Break#Break"))
                        {
                            ClassCode += Row[Row.Length - 2];
                            ClassCode += Row[Row.Length - 1];

                            Row = ClassCode + " " + Date;

                            for (int i = 0; i < ListCase.Count; i++)
                            {
                                if (ListCase[i].Equals(Row))
                                    Case = "Dont";
                            }

                            if (Case.Equals("Do"))
                            {
                                ClassCode = "";
                                ListOfClasses.Add(Row);

                                for (int TabelRow = 0; TabelRow < MyTable.Rows.Count; TabelRow++)
                                {
                                    Date = MyTable.Rows[TabelRow][9].ToString();

                                    for (int TabelCol = 1; TabelCol <= 7; TabelCol++)
                                    {
                                        Row2 = MyTable.Rows[TabelRow][TabelCol].ToString();
                                        ClassCode += Row2[Row2.Length - 2];
                                        ClassCode += Row2[Row2.Length - 1];

                                        Row2 = ClassCode + " " + Date;

                                        if (Row2.Equals(Row))
                                        {
                                            ListOfClasses.Add(MyTable.Rows[TabelRow][TabelCol].ToString() + " " + TabelCol.ToString());
                                        }

                                        ClassCode = "";
                                    }
                                }

                                ListOfClasses.Add("#");
                                ListCase.Add(Row);

                            }
                        }

                        Case = "Do";
                    }
                }





                string Break = "Break", TheDate = "", TheClass = "", SubjectName = "", LessonNumber = "";
                List<string> Subjects = new List<string>();
                int Cntr = 3, Lesson = 0, index = 0;
                string Message = "";
                Session["Generate"] = "Do";

                TheClass += ListOfClasses[0][0];
                TheClass += ListOfClasses[0][1];

                while (Cntr != ListOfClasses[0].Length)
                {
                    TheDate += ListOfClasses[0][Cntr++];
                }

                Cntr = 3;



                for (int i = 0; i < ListOfClasses.Count - 1; i++)
                {

                    if (!ListOfClasses[i + 1].Equals("#"))
                    {
                        while (ListOfClasses[i + 1].ToString()[index] != '#')
                        {
                            SubjectName += ListOfClasses[i + 1][index].ToString();
                            index++;
                        }

                        LessonNumber = ListOfClasses[i + 1][ListOfClasses[i + 1].Length - 1].ToString();

                        if (!SubjectName.Equals("Break"))
                            SubjectName = MyClass.SelectSubject(SubjectName).Rows[0][0].ToString();



                        if (Subjects.Count >= 7)
                        {
                            i = ListOfClasses.Count;
                            TheClass = MyClass.SelectClassNameByCode(int.Parse(TheClass.ToString())).Rows[0][0].ToString();
                            Message = "Max Lessons Is (8)....                Class " + TheClass + " Cannot Have More Than 8 Lessons In a Day !";
                            MyClass.RemoveClassSchedules();
                            Session["Generate"] = "Dont";
                            GetSubjects(-1);
                            Regenerate();

                            LabelMessage.Text = Message;
                            DivMessage.Visible = true;
                        }

                        else
                        {
                            Subjects.Add("Lesson " + (LessonNumber).ToString() + " " + SubjectName);
                            SubjectName = "";
                            index = 0;

                            Lesson++;
                        }

                    }

                    else
                    {
                        while (Lesson < 7)
                        {
                            Subjects.Add("Break");
                            Lesson++;
                        }
                        Lesson = 0;


                        TheClass = MyClass.SelectClassNameByCode(int.Parse(TheClass.ToString())).Rows[0][0].ToString();


                        MyClass.AddClassSchedule(TheClass, TheDate, Subjects);

                        if (i + 1 != ListOfClasses.Count - 1)
                        {
                            Subjects.Clear();

                            TheClass = "";
                            TheDate = "";
                            i++;

                            TheClass += ListOfClasses[i + 1][0];
                            TheClass += ListOfClasses[i + 1][1];

                            while (Cntr != ListOfClasses[i + 1].Length)
                            {
                                TheDate += ListOfClasses[i + 1][Cntr++];
                            }

                            Cntr = 3;
                        }

                        else
                        {
                            i = ListOfClasses.Count;
                        }

                    }

                }


            }


        }

        protected void BackClick_Click(object sender, EventArgs e)
        {
            Response.Redirect("Choose.aspx");
        }

    }
}