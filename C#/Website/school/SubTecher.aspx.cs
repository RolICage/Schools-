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
    public partial class SubTecher : System.Web.UI.Page
    {
        bool Check = false;
        public static DataTable MyTable, DropTable, CheckTabel, MyTable2;
        public static int x = 0;
        public static int PopUpFixer = 0;
        public string Case = "All";


        protected void Page_Load(object sender, EventArgs e)
        {
            if (System.Web.HttpContext.Current.Session["SCODE"] != null)
            {

                if (!IsPostBack)
                {
                    TextFind.Attributes.Add("placeholder", "Enter Techer ID");
                    Grid1FooterTabel.Style["background-image"] = "Gifs/ezgiffot.gif";
                    Session["TecherID"] = "";
                    Grid1.ShowFooter = false;
                    DivMessage.Visible = false;
                    PopUpAccept.Visible = false;

                    RefreshGrid();
                    RefresDDLists();
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

        public void RefreshGrid()
        {

            int i = 0;
            string TName, CName, SName, TID, CCode, SCode, Cnt;

            MyTable2 = new DataTable();

            if (!Session["TecherID"].ToString().Equals(""))
            {
                MyTable = MyClass.SelectSubjectsTecherByTID(Session["TecherID"].ToString());
            }

            else
            {
                MyTable = MyClass.ShowSubjectTecher();
            }


            while (i < MyTable.Rows.Count)
            {
                SCode = MyTable.Rows[i][0].ToString();
                TID = MyTable.Rows[i][1].ToString();
                CCode = MyTable.Rows[i][2].ToString();
                Cnt = MyTable.Rows[i][3].ToString();

                TName = MyClass.SelectTecher(TID).Rows[0][0].ToString();
                CName = MyClass.SelectClass(int.Parse(CCode.ToString())).Rows[0][0].ToString();
                SName = MyClass.SelectSubject(SCode).Rows[0][0].ToString();

                //============================ Change Lang ============================
                //============================ Change Lang ============================
                if (!Session["Lang"].ToString().Equals("EN"))
                {
                    string ClassNameNow = "", ARClassName = "";
                    char LastChar;

                    ClassNameNow = CName;

                    LastChar = ClassNameNow[ClassNameNow.Length - 1];

                    ClassNameNow = ClassNameNow.Remove(ClassNameNow.Length - 1);



                    if (ClassNameNow.Equals("KIDS "))
                        ARClassName = "البستان";

                    else if (ClassNameNow.Equals("One "))
                        ARClassName = "الاول";

                    else if (ClassNameNow.Equals("Two "))
                        ARClassName = "الثاني";

                    else if (ClassNameNow.Equals("Three "))
                        ARClassName = "الثالث";

                    else if (ClassNameNow.Equals("four "))
                        ARClassName = "الرابع";

                    else if (ClassNameNow.Equals("five "))
                        ARClassName = "الخامس";

                    else if (ClassNameNow.Equals("six "))
                        ARClassName = "السادس";

                    else if (ClassNameNow.Equals("seven "))
                        ARClassName = "السابع";

                    else if (ClassNameNow.Equals("eight "))
                        ARClassName = "الثامن";

                    else if (ClassNameNow.Equals("nine "))
                        ARClassName = "التاسع";



                    if (LastChar == 'A')
                        LastChar = 'ا';

                    else if (LastChar == 'B')
                        LastChar = 'ب';

                    else if (LastChar == 'C')
                        LastChar = 'ت';

                    else if (LastChar == 'D')
                        LastChar = 'ث';

                    else if (LastChar == 'E')
                        LastChar = 'ج';

                    else if (LastChar == 'F')
                        LastChar = 'ح';

                    else if (LastChar == 'G')
                        LastChar = 'خ';

                    else if (LastChar == 'H')
                        LastChar = 'د';

                    else if (LastChar == 'I')
                        LastChar = 'ذ';


                    ARClassName += " ";
                    ARClassName += LastChar;

                    CName = ARClassName;
                }

                DataRow Row = null;


                if (i == 0)
                {
                    MyTable2.Columns.Add(new DataColumn("TName", typeof(string)));
                    MyTable2.Columns.Add(new DataColumn("CName", typeof(string)));
                    MyTable2.Columns.Add(new DataColumn("SName", typeof(string)));
                    MyTable2.Columns.Add(new DataColumn("Cnt", typeof(string)));
                }


                Row = MyTable2.NewRow();

                Row["TName"] = TName.ToString();
                Row["CName"] = CName.ToString();
                Row["SName"] = SName.ToString();
                Row["Cnt"] = Cnt.ToString();

                MyTable2.Rows.Add(Row);

                i++;
            }

            Grid1.DataSource = MyTable2;
            Grid1.DataBind();
            MyTable2.Clear();

            //============================ Change Lang ============================
            //============================ Change Lang ============================
            if (Session["Lang"].ToString().Equals("EN"))
            {
                //============================ Change Edits Lang ============================
                Button Edits;

                for (int rowindex = 0; rowindex < Grid1.Rows.Count; rowindex++)
                {
                    Edits = ((Button)Grid1.Rows[rowindex].FindControl("Delete"));
                    Edits.Text = "Delete";
                }

                //============================ Change Header Footer Lang ============================
                HeaderTName.Text = "Teacher Name";
                HeaderCName.Text = "Class";
                HeaderSName.Text = "Subject";
                addsubteacherbutton.Text = "Add Row";
            }

            else
            {
                //============================ Change Edits Lang ============================
                Button Edits;

                for (int rowindex = 0; rowindex < Grid1.Rows.Count; rowindex++)
                {
                    Edits = ((Button)Grid1.Rows[rowindex].FindControl("Delete"));
                    Edits.Text = "حذف";
                }

                //============================ Change Header Footer Lang ============================
                HeaderTName.Text = "اسم المعلم";
                HeaderCName.Text = "الصف";
                HeaderSName.Text = "الموضوع";
                addsubteacherbutton.Text = "اضف";
            }

            //============================ Change Search Lang ============================
            TextFind.Attributes.Add("placeholder", "  رقم هويه المعلم  ");

        }

        public void RefresDDLists()
        {

            FooterTName.Items.Clear();
            FooterCName.Items.Clear();
            FooterSName.Items.Clear();

            DropTable = MyClass.ShowTechers();

            int Length = DropTable.Rows.Count;

            if (Length > 0)
            {
                //\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\ FILL TECHERS DROPDOWN \\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\
                //\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\ FILL TECHERS DROPDOWN \\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\

                int i = 0;
                string TName, TID;

                MyTable2 = new DataTable();

                MyTable = MyClass.ShowTechers();

                while (i < MyTable.Rows.Count)
                {
                    TName = MyTable.Rows[i][0].ToString();
                    TID = MyTable.Rows[i][1].ToString();

                    DataRow Row = null;

                    if (i == 0)
                    {
                        MyTable2.Columns.Add(new DataColumn("TName", typeof(string)));
                        MyTable2.Columns.Add(new DataColumn("TID", typeof(string)));
                    }


                    Row = MyTable2.NewRow();

                    Row["TName"] = TName.ToString()+ " >> " + TID.ToString();
                    Row["TID"] = TID.ToString();


                    MyTable2.Rows.Add(Row);

                    i++;

                }

                FooterTName.DataSource = MyTable2;
                FooterTName.DataValueField = "TID";
                FooterTName.DataTextField = "TName";
                FooterTName.DataBind();

                //\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\ FILL CLASS DROPDOWN \\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\
                //\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\ FILL CLASS DROPDOWN \\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\

                DropTable = MyClass.ShowClasses();

                Length = DropTable.Rows.Count;


                if (Length > 0)
                {

                    if (!Session["Lang"].ToString().Equals("EN"))
                    {

                        DataTable ARClassTabel;
                        string ClassNameNow = "", ARClassName = "";
                        char LastChar;

                        for (int rowindex = 0; rowindex < DropTable.Rows.Count; rowindex++)
                        {

                            ClassNameNow = DropTable.Rows[rowindex][0].ToString();

                            LastChar = ClassNameNow[ClassNameNow.Length - 1];

                            ClassNameNow = ClassNameNow.Remove(ClassNameNow.Length - 1);




                            if (ClassNameNow.Equals("KIDS "))
                                ARClassName = "البستان";

                            else if (ClassNameNow.Equals("One "))
                                ARClassName = "الاول";

                            else if (ClassNameNow.Equals("Two "))
                                ARClassName = "الثاني";

                            else if (ClassNameNow.Equals("Three "))
                                ARClassName = "الثالث";

                            else if (ClassNameNow.Equals("four "))
                                ARClassName = "الرابع";

                            else if (ClassNameNow.Equals("five "))
                                ARClassName = "الخامس";

                            else if (ClassNameNow.Equals("six "))
                                ARClassName = "السادس";

                            else if (ClassNameNow.Equals("seven "))
                                ARClassName = "السابع";

                            else if (ClassNameNow.Equals("eight "))
                                ARClassName = "الثامن";

                            else if (ClassNameNow.Equals("nine "))
                                ARClassName = "التاسع";




                            if (LastChar == 'A')
                                LastChar = 'ا';

                            else if (LastChar == 'B')
                                LastChar = 'ب';

                            else if (LastChar == 'C')
                                LastChar = 'ت';

                            else if (LastChar == 'D')
                                LastChar = 'ث';

                            else if (LastChar == 'E')
                                LastChar = 'ج';

                            else if (LastChar == 'F')
                                LastChar = 'ح';

                            else if (LastChar == 'G')
                                LastChar = 'خ';

                            else if (LastChar == 'H')
                                LastChar = 'د';

                            else if (LastChar == 'I')
                                LastChar = 'ذ';



                            ARClassName += " ";
                            ARClassName += LastChar;

                            DropTable.Rows[rowindex][0] = ARClassName;
                        }
                    }

                    FooterCName.DataSource = DropTable;
                    FooterCName.DataValueField = "ClassCode";
                    FooterCName.DataTextField = "CName";
                    FooterCName.DataBind();

                }

                //\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\ FILL SUBJECTS DROPDOWN \\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\
                //\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\ FILL SUBJECTS DROPDOWN \\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\

                DropTable = MyClass.ShowSubjects();

                Length = DropTable.Rows.Count;

                if (Length > 0)
                {

                    FooterSName.DataSource = DropTable;
                    FooterSName.DataValueField = "SubCode";
                    FooterSName.DataTextField = "SubName";
                    FooterSName.DataBind();

                }
            }
        }

        public string WhenUpdate(string TID, string ClassCode, string SCode)
        {
            string TIDCheck = "", ClassCodeCheck = "", SCodeCheck = "";

            int i = 0, Result = 0;

            
                if (TID != "" && ClassCode != "" && SCode != "")
                {
                    MyTable = MyClass.SelectSubjectTecher(TID);

                    while (i < MyTable.Rows.Count)
                    {
                        SCodeCheck = MyTable.Rows[i][0].ToString();
                        TIDCheck = MyTable.Rows[i][1].ToString();
                        ClassCodeCheck = MyTable.Rows[i][2].ToString();

                        if (TID.Equals(TIDCheck) && ClassCode.Equals(ClassCodeCheck) && SCode.Equals(SCodeCheck))
                        {
                            Result = 1;
                        }

                        i++;
                    }

                    if (Result == 1)
                    {
                        return "1";
                    }

                    else
                    {
                        return "0";
                    }

                }
     
            return "0";
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
            string Line = "";
            int Checking = 0;
            string TID;

            MyClass.CheckForInternetConnection();
            if (MyClass.NetCheck == true)
            {

                MyTable = MyClass.SelectSubjectsTecherRow2(int.Parse(Session["RowToRemove"].ToString()));

                if (MyTable.Rows.Count > 0)
                {
                    TID = MyTable.Rows[0][1].ToString();
                    Session["TecherID2"] = TID;


                    MyTable = MyClass.SelectSchedulesByTID(TID);
                    if (MyTable.Rows.Count > 0)
                        Checking++;


                    if (Checking > 0)
                    {
                        if (Session["Lang"].ToString().Equals("EN"))
                            LabelAccept.Text = "All Data Connected To this Techer Will be Removed       (Cannot undo changes)        Do You Want To Continue ?";

                        else
                            LabelAccept.Text = "سيتم حذف جميع البيانات المتصله في هذا السطر !";

                        PopUpAccept.Visible = true;
                        Checking = 0;
                    }


                    else
                    {
                        Line = Session["RowToRemove"].ToString();
                        Row = int.Parse(Line.ToString());


                        MyClass.RemoveSubjectTecherByRow(Row);

                        RefreshGrid();
                        RefresDDLists();

                        DivMessage.Visible = true;
                        //============================ Change Lang ============================
                        if (Session["Lang"].ToString().Equals("EN"))
                            LabelMessage.Text = "* Row Removed *";
                        else
                            LabelMessage.Text = "تم الحذف";
                    }
                }

                else
                {
                    Grid1.EditIndex = -1;
                    RefreshGrid();
                    RefresDDLists();
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
        protected void Grid1_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            MyClass.CheckForInternetConnection();
            if (MyClass.NetCheck == true)
            {
                Session["RowToRemove"] = e.CommandArgument.ToString();
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

        protected void ImageButton1_Click(object sender, ImageClickEventArgs e)
        {
            MyClass.CheckForInternetConnection();
            if (MyClass.NetCheck == true)
            {
                Session["TecherID"] = "";
                Grid1.EditIndex = -1;
                RefreshGrid();
                RefresDDLists();
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

            string TID, ClassCode,SCode;

            MyClass.CheckForInternetConnection();
            if (MyClass.NetCheck == true)
            {
                TID = FooterTName.SelectedValue.ToString();
                ClassCode = FooterCName.SelectedValue.ToString();
                SCode = FooterSName.SelectedValue.ToString();


                if (TID != "" && ClassCode != "" && SCode != "")
                {

                    if (WhenUpdate(TID, ClassCode, SCode).ToString().Equals("1"))
                    {
                        if (Session["Lang"].ToString().Equals("EN"))
                            LabelMessage.Text = "Row Allready Added !";

                        else
                            LabelMessage.Text = "قد تمت اضافه السطر من قبل";

                        DivMessage.Visible = true;
                    }

                    else
                    {
                        MyClass.AddSubjectsTecher(SCode, TID, int.Parse(ClassCode.ToString()));

                        if (Session["Lang"].ToString().Equals("EN"))
                            LabelMessage.Text = "Row Added";

                        else
                            LabelMessage.Text = "تمت الاضافه";

                        DivMessage.Visible = true;
                    }

                }

                Grid1.EditIndex = -1;
                RefreshGrid();
                RefresDDLists();
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
            MyClass.CheckForInternetConnection();
            if (MyClass.NetCheck == true)
            {
                MyClass.RemoveScheduleByTID(Session["TecherID2"].ToString());
                MyClass.RemoveSubjectTecherByRow(int.Parse(Session["RowToRemove"].ToString()));


                LabelAccept.Text = "";
                PopUpAccept.Visible = false;
                Regenerate();

                DivMessage.Visible = true;

                if (Session["Lang"].ToString().Equals("EN"))
                    LabelMessage.Text = "Techer   " + Session["TecherID2"].ToString() + "   Removed  With Schedules !";

                else
                    LabelMessage.Text = "تم الحذف";

                RefreshGrid();
                RefresDDLists();
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

        protected void Cancel_Click(object sender, EventArgs e)
        {
            LabelAccept.Text = "";
            PopUpAccept.Visible = false;
        }

        protected void ButtonFind_Click(object sender, EventArgs e)
        {
            string TID;

            MyClass.CheckForInternetConnection();
            if (MyClass.NetCheck == true)
            {
                TID = TextFind.Text.ToString();

                MyTable2.Columns.Clear();
                MyTable.Columns.Clear();
                MyTable2.Clear();
                MyTable.Clear();

                if (!TID.Equals(""))
                {
                    MyTable = MyClass.SelectSubjectsTecherByTID(TID);

                    if (MyTable.Rows.Count >= 1)
                    {
                        Session["TecherID"] = TID.ToString();
                        RefreshGrid();
                        RefresDDLists();
                    }

                    else
                    {
                        //============================ Change Lang ============================
                        if (Session["Lang"].ToString().Equals("EN"))
                            LabelMessage.Text = "Thecher Not Found !";
                        else
                            LabelMessage.Text = "لم يتم العثور على المعلم";
                        DivMessage.Visible = true;
                    }
                }

                else
                {
                    //============================ Change Lang ============================
                    if (Session["Lang"].ToString().Equals("EN"))
                        LabelMessage.Text = "Search Box is Empty !";
                    else
                        LabelMessage.Text = "مربع البحث فارغ!"; 
                    DivMessage.Visible = true;
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
                            RefreshGrid();
                            RefresDDLists();
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