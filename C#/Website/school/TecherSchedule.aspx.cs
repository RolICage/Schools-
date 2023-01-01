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
    public partial class TecherSchedule : System.Web.UI.Page
    {
        bool Check = false;
        public static DataTable MyTable, DropTable, EditRowTabel, MyTable2;

        protected void Page_Load(object sender, EventArgs e)
        {

            if (System.Web.HttpContext.Current.Session["SCODE"] != null)
            {
                if (!IsPostBack)
                {
                    MyTable = new DataTable();
                    MyTable2 = new DataTable();

                    TextFind.Attributes.Add("placeholder", "Enter Techer ID");
                    Grid1FooterTabel.Style["background-image"] = "Gifs/ezgiffot.gif";
                    Session["TecherID"] = "";
                    Session["TecherDay"] = "";
                    Session["EditDay"] = "";
                    Session["SelectedTecher"] = "None";
                    Session["SelectedNone"] = "Do";
                    Session["UpdateOrnot"] = "Do";
                    Session["DontCont"] = "Do";
                    Session["DontCont2"] = "Do";
                    Session["ItsUpdate"] = "No";

                    DivLoading.Visible = false;
                    Grid1.ShowFooter = false;
                    DivMessage.Visible = false;
                    CalenderPopUp.Visible = false;

                    RefresDDLists();
                    RefreshGrid(-1);
                }
            }
            else
            {
                Response.Redirect("Login Page.aspx");
            }
        }


    //<%--//////////////////////////////////// Loading--%>
    //<%--//////////////////////////////////// Loading--%>

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        ////////////////////////////////////////////////////////////////////////////////////////////////////
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public void Clear()
        {
            MyTable.Columns.Clear();
            MyTable.Rows.Clear();
            MyTable.Clear();

            MyTable2.Columns.Clear();
            MyTable2.Rows.Clear();
            MyTable2.Clear();
        }

        public void RefreshGrid(int index)
        {
            int i = 0, i2 = 1, RowIndexer = 1;
            string TName, Day, SqlRow = "";
            string TecherID, ClassCode = "", SubjectCode = "";
            string Test = "";

            Clear();

            //========== initializing List ((String Type)) ==========>
            //========== initializing List ((String Type)) ==========>
            List<string> SplitCodes = new List<string>();


            //========== Checking if Techer Searched ((To View Data About The Techer)) ==========>
            //========== Checking if Techer Searched ((To View Data About The Techer)) ==========>
            if (!Session["TecherID"].ToString().Equals(""))
            {
                MyTable = MyClass.SelectSchedulesByTID(Session["TecherID"].ToString());
            }


            //========== Get All Schedules ==========>
            //========== Get All Schedules ==========>
            else
            {
                MyTable = MyClass.ShowTecherSchedules();
            }


            //========== Converting Data To New Tabel ==========>
            //========== Converting Data To New Tabel ==========>

            while (i < MyTable.Rows.Count)
            {
                //========== Clear ListItems ==========>
                //========== Clear ListItems ==========>
                SplitCodes.Clear();



                //========== Read Values From DataBase ==========>
                //========== Read Values From DataBase ==========>
                TecherID = MyTable.Rows[i][8].ToString();
                Day = MyTable.Rows[i][9].ToString();
                SqlRow = MyTable.Rows[i][0].ToString();


                for (i2 = 1; i2 <= 7; i2++)
                {
                    SplitCodes.Add(MyTable.Rows[i][i2].ToString());
                }

                TName = MyClass.SelectTecher(TecherID).Rows[0][0].ToString() + "\r\n" + TecherID;

                //========== Creating Row ==========>
                //========== Creating Row ==========>
                DataRow Row = null;
                Row = MyTable2.NewRow();



                //========== Creating Columns ((New Tabel)) ==========>
                //========== Creating Columns ((New Tabel)) ==========>
                if (i == 0)
                {
                    MyTable2.Columns.Add(new DataColumn("TName", typeof(string)));
                    MyTable2.Columns.Add(new DataColumn("Day", typeof(string)));

                    for (RowIndexer = 1; RowIndexer <= 7; RowIndexer++)
                    {
                        MyTable2.Columns.Add(new DataColumn("Subject" + RowIndexer, typeof(string)));
                        MyTable2.Columns.Add(new DataColumn("Class" + RowIndexer, typeof(string)));
                    }

                    MyTable2.Columns.Add(new DataColumn("Cnt", typeof(string)));
                }



                //========== Fill New Tabel ((Converting Codes To Names)) ==========>
                //========== Fill New Tabel ((Converting Codes To Names)) ==========>
                Row["TName"] = TName.ToString();

                for (RowIndexer = 1; RowIndexer <= 7; RowIndexer++)
                {
                    int Charindex = 0;
                    int Length = 0;

                    Test = SplitCodes[RowIndexer - 1];

                    while (SplitCodes[RowIndexer - 1][Charindex] != '#')
                    {
                        SubjectCode += SplitCodes[RowIndexer - 1][Charindex++].ToString();
                    }

                    Charindex++;
                    Length = SplitCodes[RowIndexer - 1].Length - 1;


                    while (Charindex <= Length)
                    {
                        ClassCode += SplitCodes[RowIndexer - 1][Charindex++].ToString();
                    }


                    if (SubjectCode.Equals("Break") || ClassCode.Equals("Break"))
                    {
                        Row["Subject" + RowIndexer] = "Break";
                        Row["Class" + RowIndexer] = "Break";
                    }

                    else
                    {
                        //============================ Change Lang ============================
                        if (Session["Lang"].ToString().Equals("EN"))
                        {
                            Row["Day"] = Day.ToString();
                            Row["Subject" + RowIndexer] = MyClass.SelectSubject(SubjectCode.ToString()).Rows[0][0].ToString();
                            Row["Class" + RowIndexer] = MyClass.SelectClass(int.Parse(ClassCode.ToString())).Rows[0][0].ToString();
                        }

                        //============================ Change Lang AR ============================
                        else
                        {
                            string ClassNameNow = "", ARClassName = "";
                            char LastChar;

                            //===== Convert Day To Arabic =====
                            Row["Day"] = ConvertDayToArabic(Day).ToString();


                            ClassNameNow = MyClass.SelectClass(int.Parse(ClassCode.ToString())).Rows[0][0].ToString();

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

                            Row["Subject" + RowIndexer] = MyClass.SelectSubject(SubjectCode.ToString()).Rows[0][0].ToString();
                            Row["Class" + RowIndexer] = ARClassName;
                        }

                    }

                    SubjectCode = "";
                    ClassCode = "";
                }

                Row["Cnt"] = SqlRow.ToString();


                MyTable2.Rows.Add(Row);

                i++;
            }


            //========== Updating GridView ==========>
            //========== Updating GridView ==========>
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

                //============================ Change Search Lang ============================
                TextFind.Attributes.Add("placeholder", "Enter Teacher ID");

                //============================ Change Footer Header Lang ============================
                addschudbutton.Text = "Add Row";
                if (CheckSlid.Checked == true)
                    ButtonCalendar.Text = "Select Day";
                HeaderTName.Text = "Teacher";
                HeaderDays.Text = "Day";
                HeaderLesson1.Text = "Lesson 1";
                HeaderLesson2.Text = "Lesson 2";
                HeaderLesson3.Text = "Lesson 3";
                HeaderLesson4.Text = "Lesson 4";
                HeaderLesson5.Text = "Lesson 5";
                HeaderLesson6.Text = "Lesson 6";
                HeaderLesson7.Text = "Lesson 7";
                AddClassesSchedules.Text = "Generate Classes Schedules";
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

                //============================ Change Search Lang ============================
                TextFind.Attributes.Add("placeholder", "  رقم هويه المعلم  ");

                //============================ Change Footer Header Lang ============================
                addschudbutton.Text = "اضف البرنامج";
                if(CheckSlid.Checked==true)
                    ButtonCalendar.Text = "اختر يوم";
                HeaderTName.Text = "المعلم";
                HeaderDays.Text = "اليوم";
                HeaderLesson1.Text = "الدرس 1";
                HeaderLesson2.Text = "الدرس 2";
                HeaderLesson3.Text = "الدرس 3";
                HeaderLesson4.Text = "الدرس 4";
                HeaderLesson5.Text = "الدرس 5";
                HeaderLesson6.Text = "الدرس 6";
                HeaderLesson7.Text = "الدرس 7";
                AddClassesSchedules.Text = "إنشاء جداول الحصص";
                CalendarLabel.Text = "اختر يوم";
                CalendarCancele.Text = "الغاء";
                ButtonMessage.Text= "اغلاق";
                AddCalendarDate.Text = "اضافه";
                ClassSchudClose.Text = "اغلاق";
            }
        }

        public void RefresDDLists()
        {

            FooterTName.Items.Clear();
            FooterDayWeek.Items.Clear();
            DivDayWeek.Items.Clear();

            FooterLesson1.Items.Clear();
            FooterClass1.Items.Clear();

            FooterLesson2.Items.Clear();
            FooterClass2.Items.Clear();

            FooterLesson3.Items.Clear();
            FooterClass3.Items.Clear();

            FooterLesson4.Items.Clear();
            FooterClass4.Items.Clear();

            FooterLesson5.Items.Clear();
            FooterClass5.Items.Clear();

            FooterLesson6.Items.Clear();
            FooterClass6.Items.Clear();

            FooterLesson7.Items.Clear();
            FooterClass7.Items.Clear();


            DropTable = MyClass.ShowTechers();
            int Length = DropTable.Rows.Count;
            DataRow Row = null;

            if (Length > 0)
            {
                //\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\ FILL TECHERS DROPDOWN \\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\
                //\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\ FILL TECHERS DROPDOWN \\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\

                int i = 0;
                string TName, TID;

                MyTable2 = new DataTable();

                MyTable = MyClass.ShowTechers();

                FooterTName.Items.Clear();

                if (MyTable.Rows.Count != 0)
                {
                    while (i < MyTable.Rows.Count)
                    {
                        TName = MyTable.Rows[i][0].ToString();
                        TID = MyTable.Rows[i][1].ToString();

                        if (i == 0)
                        {
                            MyTable2.Columns.Add(new DataColumn("TName", typeof(string)));
                            MyTable2.Columns.Add(new DataColumn("TID", typeof(string)));
                        }


                        Row = MyTable2.NewRow();
                        Row["TName"] = TName.ToString() + " : " + TID.ToString();
                        Row["TID"] = TID.ToString();
                        MyTable2.Rows.Add(Row);

                        i++;
                    }

                    FooterTName.DataSource = MyTable2;
                    FooterTName.DataValueField = "TID";
                    FooterTName.DataTextField = "TName";
                    FooterTName.DataBind();
                }

                else
                {
                    FooterTName.Items.Add("None");
                }
            }

            else
            {
                FooterTName.Items.Add("None");
            }

            //================= Adding Arabic Days to Footer Days DropDown
            if (!Session["Lang"].ToString().Equals("EN"))
            {
                FooterDayWeek.Items.Add(new ListItem("الاحد", "One"));
                FooterDayWeek.Items.Add(new ListItem("الاثنين", "Two"));
                FooterDayWeek.Items.Add(new ListItem("الثلاثاء", "Three"));
                FooterDayWeek.Items.Add(new ListItem("الاربعاء", "Four"));
                FooterDayWeek.Items.Add(new ListItem("الخميس", "Five"));
                FooterDayWeek.Items.Add(new ListItem("الجمعه", "Six"));
                FooterDayWeek.Items.Add(new ListItem("السبت", "Seven"));

                //================= Adding Arabic Days to Div Days DropDown
                DivDayWeek.Items.Add(new ListItem("الاحد", "One"));
                DivDayWeek.Items.Add(new ListItem("الاثنين", "Two"));
                DivDayWeek.Items.Add(new ListItem("الثلاثاء", "Three"));
                DivDayWeek.Items.Add(new ListItem("الاربعاء", "Four"));
                DivDayWeek.Items.Add(new ListItem("الخميس", "Five"));
                DivDayWeek.Items.Add(new ListItem("الجمعه", "Six"));
                DivDayWeek.Items.Add(new ListItem("السبت", "Seven"));
            }

            else
            {
                FooterDayWeek.Items.Add(new ListItem("One", "One"));
                FooterDayWeek.Items.Add(new ListItem("Two", "Two"));
                FooterDayWeek.Items.Add(new ListItem("Three", "Three"));
                FooterDayWeek.Items.Add(new ListItem("Four", "Four"));
                FooterDayWeek.Items.Add(new ListItem("Five", "Five"));
                FooterDayWeek.Items.Add(new ListItem("Six", "Six"));
                FooterDayWeek.Items.Add(new ListItem("Seven", "Seven"));

                //================= Adding ENG Days to Div Days DropDown
                DivDayWeek.Items.Add(new ListItem("One", "One"));
                DivDayWeek.Items.Add(new ListItem("Two", "Two"));
                DivDayWeek.Items.Add(new ListItem("Three", "Three"));
                DivDayWeek.Items.Add(new ListItem("Four", "Four"));
                DivDayWeek.Items.Add(new ListItem("Five", "Five"));
                DivDayWeek.Items.Add(new ListItem("Six", "Six"));
                DivDayWeek.Items.Add(new ListItem("Seven", "Seven"));
            }

            FooterDayWeek.Items.FindByValue("One").Selected = true;
            ButtonCalendar.Text = FooterDayWeek.SelectedItem.Text;

            //=============================== Saving The Selected Techer ((So We Can Show The Subject And Classes for The Techer <In DropDownLists>)) ===============================
            Session["SelectedTecher"] = FooterTName.SelectedItem.Value.ToString();
            FixDDLists("No", -1);          
        }

        public void FixDDLists(string IsEdit, int Rowindex)
        {
            if (!Session["SelectedTecher"].Equals("None"))
            {
                //\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\ FILL SUBJECTS && Classes DROPDOWN \\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\
                //\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\ FILL SUBJECTS && Classes DROPDOWN \\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\

                List<string> SubjectsL = new List<string>();
                List<string> ClassesL = new List<string>();

                int LessonIndex = 1;

                string Checker = "", Dont = "Do";
                int Counter, Counter2 = 0;

                //========================================= Saving Subjects In List =========================================
                //========================================= Saving Subjects In List =========================================
                MyTable2 = MyClass.SelectInfoSubjectTecher(Session["SelectedTecher"].ToString());

                for (Counter = 0; Counter < MyTable2.Rows.Count; Counter++)
                {
                    Checker = MyTable2.Rows[Counter][0].ToString();

                    for (Counter2 = 0; Counter2 < SubjectsL.Count; Counter2++)
                    {
                        if (SubjectsL[Counter2].Equals(Checker))
                        {
                            Dont = "Dont";
                        }
                    }

                    if (Dont.Equals("Do"))
                        SubjectsL.Add(Checker);

                    Counter2 = 0;
                    Dont = "Do";
                }

                Counter2 = 0;
                Dont = "Do";
                Checker = "";

                //========================================= Saving Classes In List =========================================
                //========================================= Saving Classes In List =========================================
                MyTable2 = MyClass.SelectInfoSubjectTecher(Session["SelectedTecher"].ToString());

                for (Counter = 0; Counter < MyTable2.Rows.Count; Counter++)
                {
                    Checker = MyTable2.Rows[Counter][1].ToString();

                    for (Counter2 = 0; Counter2 < ClassesL.Count; Counter2++)
                    {
                        if (ClassesL[Counter2].Equals(Checker))
                        {
                            Dont = "Dont";
                        }
                    }

                    if (Dont.Equals("Do"))
                        ClassesL.Add(Checker);

                    Counter2 = 0;
                    Dont = "Do";
                }

                Clear();
                //========== Creating Custom Tabels  ==========>
                //========== Creating Custom Tabels ==========>
                DataTable DataSubjects = new DataTable();
                DataTable DataClasses = new DataTable();
                DataRow Row2 = null;

                //========== Defining Subject DataTabel ((New Tabel)) ==========>
                //========== Defining Subject DataTabel ((New Tabel)) ==========>
                int index = 0;

                DataSubjects.Columns.Add(new DataColumn("SubName", typeof(string)));
                DataSubjects.Columns.Add(new DataColumn("SubCode", typeof(string)));

                for (index = 0; index < SubjectsL.Count; index++)
                {
                    Row2 = DataSubjects.NewRow();
                    Row2["SubName"] = MyClass.SelectSubject(SubjectsL[index].ToString()).Rows[0][0].ToString();
                    Row2["SubCode"] = SubjectsL[index].ToString();


                    DataSubjects.Rows.Add(Row2);
                }


                //========== Defining Classes DataTabel ((New Tabel)) ==========>
                //========== Defining Classes DataTabel ((New Tabel)) ==========>
                index = 0;
                string ClassNameNow = "", ARClassName = "";
                char LastChar;

                DataClasses.Columns.Add(new DataColumn("CName", typeof(string)));
                DataClasses.Columns.Add(new DataColumn("ClassCode", typeof(string)));

                for (index = 0; index < ClassesL.Count; index++)
                {
                    ClassNameNow = MyClass.SelectClass(int.Parse(ClassesL[index].ToString())).Rows[0][0].ToString();

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

                    Row2 = DataClasses.NewRow();
                    Row2["CName"] = ARClassName;
                    Row2["ClassCode"] = ClassesL[index].ToString();

                    DataClasses.Rows.Add(Row2);
                }


                //========== If Its Not Edit ==========>
                //========== If Its Not Edit ==========>
                if (IsEdit.Equals("No"))
                {
                    for (; LessonIndex <= 7; LessonIndex++)
                    {
                        //========== Check If It Comeing From Edit Row Or Not ==========>
                        //========== Check If It Comeing From Edit Row Or Not ==========>

                        DropDownList Lessons = new DropDownList();
                        DropDownList Classes = new DropDownList();

                        Lessons = (Page.FindControl("FooterLesson" + LessonIndex.ToString()) as DropDownList);
                        Classes = (Page.FindControl("FooterClass" + LessonIndex.ToString()) as DropDownList);
                        Lessons.Items.Clear();
                        Classes.Items.Clear();

                        if (DataSubjects.Rows.Count != 0)
                        {
                            Lessons.DataSource = DataSubjects;
                            Lessons.DataValueField = "SubCode";
                            Lessons.DataTextField = "SubName";
                            Lessons.DataBind();

                            //======================= Adding And Selecting Break for Subjects DropDowns
                            Lessons.Items.Add("Break");                           
                            Lessons.Items.FindByText("Break").Selected = true;
                        }
                        else
                        {
                            Lessons.Items.Add("None");
                        }


                        if (DataClasses.Rows.Count != 0)
                        {
                            Classes.DataSource = DataClasses;
                            Classes.DataValueField = "ClassCode";
                            Classes.DataTextField = "CName";
                            Classes.DataBind();
                        }
                        else
                        {
                            Classes.Items.Add("None");
                        }

                    }
                }


                //========== If Its Edit ==========>
                //========== If Its Edit ==========>
                else
                {
                    int Column;
                    int i = 0;
                    string Class = "", Subject = "";
                    string Split = "";

                    //////////////////////////////////////////////// Fill DropDown Subjects //////////////////////////////////////////////
                    //////////////////////////////////////////////// Fill DropDown Subjects //////////////////////////////////////////////
                    for (Column = 3; Column <= 9; Column++, i = 0, Subject = "")
                    {
                        DropDownList DDLSubjects = ((DropDownList)Grid1.Rows[Rowindex].FindControl("DropDownSubject" + (Column - 2).ToString()));

                        DDLSubjects.DataSource = DataSubjects;
                        DDLSubjects.DataValueField = "SubCode";
                        DDLSubjects.DataTextField = "SubName";
                        DDLSubjects.DataBind();
                        DDLSubjects.Items.Add("Break");


                        Split = EditRowTabel.Rows[0][Column - 2].ToString();

                        while (Split[i] != '#')
                        {
                            Subject += Split[i++];
                        }

                        if (Subject.Equals("Break"))
                        {
                            DropDownList HideClassesDrop = ((DropDownList)Grid1.Rows[Rowindex].FindControl("DropDownClass" + (Column - 2).ToString()));

                            HideClassesDrop.Visible = false;
                        }

                        DDLSubjects.Items.FindByValue(Subject.ToString()).Selected = true;
                    }


                    //////////////////////////////////////////////// Fill DropDown Classes //////////////////////////////////////////////
                    //////////////////////////////////////////////// Fill DropDown Classes //////////////////////////////////////////////
                    for (Column = 3; Column <= 9; Column++, i = 0, Class = "")
                    {
                        DropDownList ddlClasses = ((DropDownList)Grid1.Rows[Rowindex].FindControl("DropDownClass" + (Column - 2).ToString()));
                        DropDownList DDLSubjects = ((DropDownList)Grid1.Rows[Rowindex].FindControl("DropDownSubject" + (Column - 2).ToString()));


                        ///////////////////////// Getting Teacher ID
                        Label TeacherID = new Label();
                        TeacherID = (Grid1.Rows[Rowindex].FindControl("EditLabelTId") as Label);
                        string TID = "";

                        for (int ID9 = 0; ID9 < 9; ID9++)
                            TID += TeacherID.Text[ID9].ToString();

                        ///////////////////////// Getting Classes For Selected Subject
                        DataTable DTNOW = new DataTable();
                        DTNOW= MyClass.SelectClassesByClassANDSUBJECT(TID, DDLSubjects.SelectedValue.ToString());

                        //============================ Change Lang ============================
                        if (Session["Lang"].ToString().Equals("EN"))
                        {
                            ddlClasses.DataSource = DTNOW;
                            ddlClasses.DataValueField = "ClassCode";
                            ddlClasses.DataTextField = "CName";
                            ddlClasses.DataBind();
                        }

                        else
                            for (int item = 0; item < DTNOW.Rows.Count; item++)
                                ddlClasses.Items.Add(new ListItem(ConvertClassToArabic(DTNOW.Rows[item][0].ToString()), DTNOW.Rows[item][1].ToString()));

                        Split = EditRowTabel.Rows[0][Column - 2].ToString();

                        while (Split[i] != '#')
                        {
                            i++;
                        }
                        i++;
                        while (i < Split.Length)
                        {
                            Class += Split[i++];
                        }

                        if (!DDLSubjects.SelectedValue.ToString().Equals("Break"))
                            ddlClasses.Items.FindByValue(Class.ToString()).Selected = true;

                        else
                            ddlClasses.Visible = false;
                    }
                }

                SubjectsL.Clear();
                ClassesL.Clear();
                DataSubjects.Rows.Clear();
                DataSubjects.Columns.Clear();
                DataSubjects.Clear();
                DataClasses.Rows.Clear();
                DataClasses.Columns.Clear();
                DataClasses.Clear();
            }

            else
            {
                DivMessage.Visible = true;
                //============================ Change Lang ============================
                if (Session["Lang"].ToString().Equals("EN"))          
                LabelMessage.Text = "You Should Add Techer First !                                                                    Cannot Add !";
                else
                    LabelMessage.Text = "!يجب عليك اضافة المعلم اولا!                                                            لا يمكن اضافتة";
            }

            Session["SelectedTecher"] = "None";
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

        protected void Grid1_RowEditing(object sender, GridViewEditEventArgs e)
        {
            int index = e.NewEditIndex;
            Grid1.EditIndex = e.NewEditIndex;
            Session["EditDay"] = index.ToString();
            Session["DDDays"] = index.ToString();
            Session["ToHideDrops"] = index.ToString();

            if (!Session["TecherID2"].ToString().Equals(""))
            {
                RefreshGrid(index);
                RefresDDLists();

                Grid1.Rows[index].Style["background-image"] = "Images/GridEditRow.Gif";

                //////////////////////////////////////////////// Fill Label Techers //////////////////////////////////////////////
                //////////////////////////////////////////////// Fill Label Techers //////////////////////////////////////////////


                Label DDLTechers = ((Label)Grid1.Rows[index].FindControl("EditLabelTId"));

                DDLTechers.Text = Session["TecherID2"].ToString() + "\r\n" + MyClass.SelectTecher(Session["TecherID2"].ToString()).Rows[0][0].ToString();

                ////////////////////////////////////////////// Fill Label Day //////////////////////////////////////////////
                ////////////////////////////////////////////// Fill Label Day //////////////////////////////////////////////

                Button Days = ((Button)Grid1.Rows[index].FindControl("EditDay2"));
               
                //Convert Day To Arabic
                if (Session["Lang"].ToString().Equals("EN"))
                    Days.Text = EditRowTabel.Rows[0][9].ToString();

                else
                    Days.Text = ConvertDayToArabic(EditRowTabel.Rows[0][9].ToString());

                //////////////////////////////////////////////// Fill DropDown Classes //////////////////////////////////////////////
                //////////////////////////////////////////////// Fill DropDown Classes //////////////////////////////////////////////           
                Session["SelectedTecher"] = Session["TecherID2"];
                FixDDLists("Yes", index);

            }

            else
            {
                Grid1.EditIndex = -1;
                RefresDDLists();
                RefreshGrid(-1);
            }
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        ////////////////////////////////////////////////////////////////////////////////////////////////////
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        protected void Grid1_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            Grid1.EditIndex = -1;
            RefreshGrid(-1);
            RefresDDLists();
            Session["EditDay"] = "";
            Session["TecherID"] = "";
            Session["ItsUpdate"] = "No";
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        ////////////////////////////////////////////////////////////////////////////////////////////////////
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        protected void Grid1_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            string TecherID, Day, Class, Subject, Result = "";
            int LessonIndex = 3, Row, Row2 = -1;           
            Session["ItsUpdate"] = "Update";

            MyClass.CheckForInternetConnection();
            if (MyClass.NetCheck == true)
            {
                Row = int.Parse(e.RowIndex.ToString());

                DropDownList Subjects = new DropDownList();
                DropDownList Classes = new DropDownList();
                List<string> SubjectsList = new List<string>();
                List<string> ClassesList = new List<string>();

                SubjectsList.Clear();
                ClassesList.Clear();
                Clear();


                //============================ Checking if exist before doing any action ============================

                if (!Session["RowToUpdate"].ToString().Equals(""))
                {
                    Button Days = ((Button)Grid1.Rows[Row].FindControl("EditDay2"));

                    if (CheckSlid.Checked == false)
                        Day = DivDayWeek.Items.FindByText(Days.Text.ToString()).Value.ToString();
                    else
                        Day = Days.Text.ToString();

                    TecherID = Session["TecherID2"].ToString();

                    int SqlRow = int.Parse(Session["RowToUpdate"].ToString());
                    MyTable2 = MyClass.SelectTecherSchedulByDay(TecherID, Day);

                    if (MyTable2.Rows.Count == 1)
                    {
                        Row2 = int.Parse(MyTable2.Rows[0][0].ToString());
                    }

                    if ((MyTable2.Rows.Count == 1 && Row2 == SqlRow) || MyTable2.Rows.Count == 0)
                    {
                        for (LessonIndex = 3; LessonIndex <= 9; LessonIndex++)
                        {

                            Subjects = (Grid1.Rows[Row].FindControl("DropDownSubject" + (LessonIndex - 2).ToString()) as DropDownList);
                            Classes = (Grid1.Rows[Row].FindControl("DropDownClass" + (LessonIndex - 2).ToString()) as DropDownList);


                            Subject = Subjects.SelectedValue.ToString();
                            Class = Classes.SelectedValue.ToString();

                            if (Subject.Equals("Break"))
                            {
                                SubjectsList.Add("Break");
                                ClassesList.Add("Break");
                            }

                            else
                            {

                                Result = ClassLessonCheck((LessonIndex - 2).ToString(), Class, Day);


                                if (Result.Equals("Do"))
                                {
                                    MyTable2 = MyClass.SelectSubjectsTecherRow3(Subject, int.Parse(Class.ToString()));

                                    if (MyTable2.Rows.Count != 0)
                                    {
                                        SubjectsList.Add(Subject.ToString());
                                        ClassesList.Add(Class.ToString());
                                    }

                                    else
                                    {
                                        Session["UpdateOrnot"] = "Dont";
                                        LessonIndex = 10;
                                    }
                                }

                                else
                                {
                                    Session["DontCont2"] = "Dont";
                                    LessonIndex = 10;
                                }

                            }

                        }

                        if (Session["DontCont2"].Equals("Do"))
                        {
                            if (Session["UpdateOrnot"].Equals("Dont"))
                            {
                                DivMessage.Visible = true;
                                //============================ Change Lang ============================
                                if (Session["Lang"].ToString().Equals("EN"))
                                    LabelMessage.Text = "Class Not Learning This Subject !";
                                else
                                    LabelMessage.Text = "الصف لا يتعلم هذا الموضوع";
                                Session["UpdateOrnot"] = "Do";
                            }

                            else
                            {
                                Grid1.EditIndex = -1;

                                MyClass.UpdateSchedule(TecherID, Day, SubjectsList, ClassesList, DateTime.Now.ToString("dd.MM.yyy"), SqlRow);
                                RefresDDLists();
                                RefreshGrid(-1);
                                Session["EditDay"] = "";

                                if (Session["Lang"].ToString().Equals("EN"))
                                    LabelMessage.Text = "Schedules Updated";

                                else
                                    LabelMessage.Text = "تم تحديث البرامج الدراسيه";

                                DivMessage.Visible = true;
                                
                            }
                        }

                        else
                        {
                            DivMessage.Visible = true;
                            //============================ Change Lang ============================
                            if (Session["Lang"].ToString().Equals("EN"))
                                LabelMessage.Text = "There Is Techer Allready Learning The Class                                                         Cannot Add!";
                            else
                                LabelMessage.Text = "!هناك معلم يعلم هذا الصف                                                                       لا يمكن اضافتة";
                            Session["DontCont2"] = "Do";
                        }

                        Regenerate();
                    }

                    else
                    {
                        DivMessage.Visible = true;
                        LabelMessage.Text = "Techer " + FooterTName.Items.FindByValue(TecherID).Text.ToString() + " Allready Working On " + Day;
                    }
                }

                else
                {
                    Grid1.EditIndex = -1;
                    RefresDDLists();
                    RefreshGrid(-1);
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

            MyClass.CheckForInternetConnection();
            if (MyClass.NetCheck == true)
            {
                if (!Session["RowToRemove"].ToString().Equals(""))
                {
                    Line = Session["RowToRemove"].ToString();
                    Row = int.Parse(Line.ToString());

                    MyClass.RemoveSchedule(Row);

                    RefreshGrid(-1);
                    RefresDDLists();

                    DivMessage.Visible = true;
                    if (Session["Lang"].ToString().Equals("EN"))
                        LabelMessage.Text = "* Removed *";

                    else
                        LabelMessage.Text = "تم الحذف";

                    Regenerate();

                }

                else
                {
                    Grid1.EditIndex = -1;
                    RefresDDLists();
                    RefreshGrid(-1);
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
                if (e.CommandName.Equals("Edit"))
                {
                    int index;

                    index = int.Parse(e.CommandArgument.ToString());

                    Session["TecherID2"] = "";

                    MyTable2 = MyClass.SelectSchedulesByRow(index);


                    if(MyTable2.Rows.Count>0)
                    {
                        Session["TecherID2"] = MyTable2.Rows[0][8].ToString();
                        EditRowTabel = MyClass.SelectSchedulesByRow(index);
                    }

                    else
                    {
                        Grid1.EditIndex = -1;
                        RefresDDLists();
                        RefreshGrid(-1);
                    }
                }

                else if (e.CommandName.Equals("Delete"))
                {
                    Session["RowToRemove"] = "";

                    DataTable SchExist = MyClass.SelectSchedulesByRow(int.Parse(e.CommandArgument.ToString()));

                    if(SchExist.Rows.Count>0)
                        Session["RowToRemove"] = e.CommandArgument.ToString();
                    else
                    {
                        Grid1.EditIndex = -1;
                        RefresDDLists();
                        RefreshGrid(-1);
                    }
                }

                else if (e.CommandName.Equals("Update"))
                {
                    Session["RowToUpdate"] = "";

                    DataTable SchExist = MyClass.SelectSchedulesByRow(int.Parse(e.CommandArgument.ToString()));

                    if (SchExist.Rows.Count > 0)
                        Session["RowToUpdate"] = e.CommandArgument.ToString();
                    else
                    {
                        Grid1.EditIndex = -1;
                        RefresDDLists();
                        RefreshGrid(-1);
                    }
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

        protected void ImageButton1_Click(object sender, ImageClickEventArgs e)
        {

            MyClass.CheckForInternetConnection();
            if (MyClass.NetCheck == true)
            {
                Session["TecherID"] = "";
                TextFind.Text = "";
                Grid1.EditIndex = -1;
                RefreshGrid(-1);
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

        protected void CalendarLabelConvert_Click(object sender, EventArgs e)
        {
            string date = "";
            int ThisDay, CalendarDay, ThisMonth, CalendarMonth, ThisYear, CalendarYear;

            date = MyCalendar.SelectedDate.ToString("dd.MM.yyy");

            CalendarYear = int.Parse(MyCalendar.SelectedDate.ToString("yyy"));
            ThisYear = int.Parse(DateTime.Now.ToString("yyy"));

            CalendarMonth = int.Parse(MyCalendar.SelectedDate.ToString("MM"));
            ThisMonth = int.Parse(DateTime.Now.ToString("MM"));

            CalendarDay = int.Parse(MyCalendar.SelectedDate.ToString("dd"));
            ThisDay = int.Parse(DateTime.Now.ToString("dd"));


            if (CalendarYear > ThisYear)
            {
                CalendarLabel.Text = date;
                CalendarLabel.ForeColor = System.Drawing.ColorTranslator.FromHtml("#FFA500");
                Session["TecherDay"] = date.ToString();
            }

            else if (CalendarYear == ThisYear)
            {
                if (CalendarMonth > ThisMonth)
                {
                    CalendarLabel.Text = date;
                    CalendarLabel.ForeColor = System.Drawing.ColorTranslator.FromHtml("#FFA500");
                    Session["TecherDay"] = date.ToString();

                }

                else if (CalendarMonth == ThisMonth)
                {
                    if (CalendarDay >= ThisDay)
                    {
                        CalendarLabel.Text = date;
                        CalendarLabel.ForeColor = System.Drawing.ColorTranslator.FromHtml("#FFA500");
                        Session["TecherDay"] = date.ToString();
                    }

                    else
                    {
                        CalendarLabel.Text = "OutDate  " + date;
                        CalendarLabel.ForeColor = System.Drawing.ColorTranslator.FromHtml("#FF0000");
                        Session["TecherDay"] = "";
                    }
                }

                else
                {
                    CalendarLabel.Text = "OutDate  " + date;
                    CalendarLabel.ForeColor = System.Drawing.ColorTranslator.FromHtml("#FF0000");
                    Session["TecherDay"] = "";
                }
            }

            else
            {
                CalendarLabel.Text = "OutDate  " + date;
                CalendarLabel.ForeColor = System.Drawing.ColorTranslator.FromHtml("#FF0000");
                Session["TecherDay"] = "";
            }

        }

        protected void ButtonCalendar_Click(object sender, EventArgs e)
        {
            CalenderPopUp.Visible = true;

            Grid1.EditIndex = -1;
            RefreshGrid(-1);

            Session["EditDay"] = "";

            //============================ Change Lang ============================
            if (Session["Lang"].ToString().Equals("EN"))
                CalendarLabel.Text = "Select Day";

            else
                CalendarLabel.Text = "اختر يوم";
        }

        protected void CalendarCancele_Click(object sender, EventArgs e)
        {
            CalenderPopUp.Visible = false;
            Session["TecherDay"] = "";
            CalendarLabel.ForeColor = System.Drawing.ColorTranslator.FromHtml("#FFA500");
            //============================ Change Lang ============================
            if (Session["Lang"].ToString().Equals("EN"))
            {
                CalendarLabel.Text = "Select Day";
                ButtonCalendar.Text = "Select Day";
            }

            else
            {
                CalendarLabel.Text = "اختر يوم";
                ButtonCalendar.Text = "اختر يوم";
            }
        }

        protected void AddCalendarDate_Click(object sender, EventArgs e)
        {
            if (Session["EditDay"].Equals(""))
            {
                if (!Session["TecherDay"].Equals(""))
                {
                    ButtonCalendar.Text = Session["TecherDay"].ToString();
                    Session["TecherDay"] = "";
                    CalendarLabel.ForeColor = System.Drawing.ColorTranslator.FromHtml("#FFA500");

                    if (Session["Lang"].ToString().Equals("EN"))
                        CalendarLabel.Text = "Select Day";
                    else
                        CalendarLabel.Text = "اختر يوم";

                    CalenderPopUp.Visible = false;
                }

                else
                {
                    CalendarLabel.ForeColor = System.Drawing.ColorTranslator.FromHtml("#FF0000");

                    if (Session["Lang"].ToString().Equals("EN"))
                        CalendarLabel.Text = "Cannot Select This Date !";

                    else
                        CalendarLabel.Text = "لا يمكن تحديد هذا التاريخ";

                }
            }

            else
            {
                if (!Session["TecherDay"].Equals(""))
                {
                    CalendarLabel.ForeColor = System.Drawing.ColorTranslator.FromHtml("#FFA500");

                    if (Session["Lang"].ToString().Equals("EN"))
                        CalendarLabel.Text = "Select Day";
                    else
                        CalendarLabel.Text = "اختر يوم";

                    string a = Session["EditDay"].ToString();

                    Button Days = ((Button)Grid1.Rows[int.Parse(Session["EditDay"].ToString())].FindControl("EditDay2"));
                    Days.Text = Session["TecherDay"].ToString();
                    CalenderPopUp.Visible = false;
                }

                else
                {
                    CalendarLabel.ForeColor = System.Drawing.ColorTranslator.FromHtml("#FF0000");

                    if (Session["Lang"].ToString().Equals("EN"))
                        CalendarLabel.Text = "Cannot Select This Date !";

                    else
                        CalendarLabel.Text = "لا يمكن تحديد هذا التاريخ";
                }
            }

        }

        protected void EditDay2_Click(object sender, EventArgs e)
        {
            if (CheckSlid.Checked == false)
                DivDivDayWeek.Visible = true;

            else
                CalenderPopUp.Visible = true;
        }

        protected void ButtonMessage_Click(object sender, EventArgs e)
        {
            MyClass.CheckForInternetConnection();
            if (MyClass.NetCheck == true)
            {
                DivMessage.Visible = false;

                LabelMessage.Text = "";
            }
        }

        protected void ADD_Click(object sender, EventArgs e)
        {

            string TecherID, Day="", Result = "";
            int LessonIndex = 1;

            MyClass.CheckForInternetConnection();
            if (MyClass.NetCheck == true)
            {
                if (!ButtonCalendar.Text.Equals("Select Day")&& !ButtonCalendar.Text.Equals("اختر يوم"))
                {
                    DropDownList Subjects = new DropDownList();
                    DropDownList Classes = new DropDownList();
                    List<string> SubjectsList = new List<string>();
                    List<string> ClassesList = new List<string>();
                    string Sub;
                    int Clas;

                    SubjectsList.Clear();
                    ClassesList.Clear();
                    Clear();

                    Session["SelectedNone"] = "Do";

                    TecherID = FooterTName.SelectedValue.ToString();

                    if (CheckSlid.Checked == false)
                        Day = FooterDayWeek.Items.FindByText(ButtonCalendar.Text.ToString()).Value.ToString();

                    else
                        Day = ButtonCalendar.Text.ToString();

                    for (; LessonIndex <= 7; LessonIndex++)
                    {
                        Subjects = (Page.FindControl("FooterLesson" + LessonIndex.ToString()) as DropDownList);
                        Classes = (Page.FindControl("FooterClass" + LessonIndex.ToString()) as DropDownList);


                        if (!Subjects.SelectedItem.Text.Equals("None") && !Classes.SelectedItem.Text.Equals("None"))
                        {

                            if (Subjects.SelectedItem.Text.Equals("Break"))
                            {
                                SubjectsList.Add(Subjects.SelectedValue.ToString());
                                ClassesList.Add(Subjects.SelectedValue.ToString());
                            }

                            else
                            {

                                Result = ClassLessonCheck(LessonIndex.ToString(), Classes.SelectedValue.ToString(), Day);

                                if (Result.Equals("Do"))
                                {
                                    Sub = Subjects.SelectedValue.ToString();
                                    Clas = int.Parse(Classes.SelectedValue.ToString());

                                    MyTable2 = MyClass.SelectSubjectsTecherRow3(Sub, Clas);

                                    if (MyTable2.Rows.Count != 0)
                                    {
                                        SubjectsList.Add(Subjects.SelectedValue.ToString());
                                        ClassesList.Add(Classes.SelectedValue.ToString());
                                    }

                                    else
                                    {
                                        Session["SelectedNone"] = "Dont";
                                        LessonIndex = 8;

                                    }

                                }

                                else
                                {
                                    LessonIndex = 8;
                                    Session["DontCont"] = "Dont";
                                }

                            }
                        }

                        else
                        {
                            Session["SelectedNone"] = "Dont";
                            LessonIndex = 8;
                        }


                    }

                    if (Session["DontCont"].Equals("Do"))
                    {
                        if (Session["SelectedNone"].ToString().Equals("Do"))
                        {
                            MyTable2 = MyClass.SelectTecherSchedulByDay(TecherID, Day);

                            if (MyTable2.Rows.Count == 0)
                            {
                                MyClass.AddSchedule(TecherID, Day, SubjectsList, ClassesList);
                                DivMessage.Visible = true;

                                if (Session["Lang"].ToString().Equals("EN"))
                                    LabelMessage.Text = "Added";
                                else
                                    LabelMessage.Text = "تمت الاضافه";

                                Session["TecherDay"] = "";
                                CalendarLabel.ForeColor = System.Drawing.ColorTranslator.FromHtml("#FFA500");
                                CalendarLabel.Text = "Select Day";
                                ButtonCalendar.Text = "Select Day";
                                Grid1.EditIndex = -1;
                                SortFooter();
                                RefresDDLists();
                                RefreshGrid(-1);
                                Regenerate();
                            }

                            else
                            {
                                DivMessage.Visible = true;
                                if (Session["Lang"].ToString().Equals("EN"))
                                    LabelMessage.Text = "Techer " + FooterTName.Items.FindByValue(TecherID).Text.ToString() + " Allready Working On " + Day;

                                else
                                    LabelMessage.Text = Day+" هذا المعلم يعمل مسبقا في هذا اليوم ";
                            }
                        }

                        else
                        {
                            DivMessage.Visible = true;
                            //============================ Change Lang ============================
                            if (Session["Lang"].ToString().Equals("EN"))
                                LabelMessage.Text = "You Should Add Classes And Subject To this Techer First !                                                         Cannot Add!";
                            else
                                LabelMessage.Text = "!اولا يجب عليك اضافة الصفوف والمواضيع لهاذا المعلم                                                        لا يمكن الإضافة";
                        }
                    }

                    else
                    {
                        DivMessage.Visible = true;
                        //============================ Change Lang ============================
                        if (Session["Lang"].ToString().Equals("EN"))
                            LabelMessage.Text = "There Is Techer Allready Learning The Class                                                         Cannot Add!";
                        else
                            LabelMessage.Text = "!هناك معلم يعلم هذا الصف                                                                       لا يمكن اضافتة";
                        Session["DontCont"] = "Do";
                    }
                }

                else
                {
                    DivMessage.Visible = true;
                    //============================ Change Lang ============================
                    if (Session["Lang"].ToString().Equals("EN"))
                        LabelMessage.Text = "Select Day Please";
                    else
                        LabelMessage.Text = "حدد اليوم من فضلك";
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

        public string ClassLessonCheck(string Lesson, string ClassCode, string Date)
        {
            string ThisClass = "", ThisDate = "", Data = "";
            DataTable DT = new DataTable();
            int Col = 1, Row = 0,i=0,TheRow=-1,TheRow2=-2;


            DT = MyClass.ShowTecherSchedules();            

            for (Row = 0; Row < DT.Rows.Count; Row++)
            {
                if(Session["ItsUpdate"].Equals("Update"))
                {
                    TheRow = int.Parse(Session["RowToUpdate"].ToString());
                    TheRow2 = int.Parse(DT.Rows[Row][0].ToString());
                }

                if(TheRow!=TheRow2)
                {
                    for (Col = 1; Col <= 7; Col++)
                    {
                        Data = DT.Rows[Row][Col].ToString() + "#";
                        ThisDate = DT.Rows[Row][9].ToString();
                        i = 0;

                        while (Data[i++] != '#') { }

                        while (Data[i] != '#')
                            ThisClass += Data[i++].ToString();

                        if (ThisClass.Equals(ClassCode) && ThisDate.Equals(Date) && Col.ToString().Equals(Lesson))
                            return "Dont";

                        ThisClass = "";
                    }
                }


            }

            return "Do";
        }

        protected void ButtonFind_Click(object sender, EventArgs e)
        {
            string TID;

            MyClass.CheckForInternetConnection();
            if (MyClass.NetCheck == true)
            {
                TID = TextFind.Text.ToString();

                Clear();

                if (!TID.Equals(""))
                {
                    MyTable = MyClass.SelectSchedulesByTID(TID);

                    if (MyTable.Rows.Count >= 1)
                    {
                        Session["TecherID"] = TID.ToString();
                        RefreshGrid(-1);
                        RefresDDLists();
                        TextFind.Text = "";
                    }

                    else
                    {
                        //============================ Change Lang ============================
                        if (Session["Lang"].ToString().Equals("EN"))
                            LabelMessage.Text = "Techer Not Found Or ID Is Wrong !";
                        else
                            LabelMessage.Text = "!لم يتم العثور على المعلم أو أن الهوية خاطئة";
                        DivMessage.Visible = true;
                        TextFind.Text = "";
                    }
                }

                else
                {
                    //============================ Change Lang ============================
                    if (Session["Lang"].ToString().Equals("EN"))
                        LabelMessage.Text = "Search Box is Empty !";
                    else
                        LabelMessage.Text = "! سطر البحث فارغ";
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

        protected void FooterTName_SelectedIndexChanged(object sender, EventArgs e)
        {
            MyClass.CheckForInternetConnection();
            if (MyClass.NetCheck == true)
            {
                SortFooter();
                Session["SelectedTecher"] = FooterTName.SelectedValue.ToString();
                FixDDLists("No", -1);
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

        protected void Dropdownchanged(object sender, EventArgs e)
        {
            MyClass.CheckForInternetConnection();
            if (MyClass.NetCheck == true)
            {
                DropDownList DropChenged = (DropDownList)sender;

                if (DropChenged.SelectedValue.Equals("Break"))
                {
                    string buttonId = DropChenged.ID;

                    //========================== if its coming from footer ==========================>
                    //========================== if its coming from footer ==========================>
                    if (buttonId[0] != 'D')
                    {
                        buttonId = buttonId[buttonId.Length - 1].ToString();

                        DropDownList Change = new DropDownList();

                        Change = (Page.FindControl("FooterClass" + buttonId) as DropDownList);

                        Change.Visible = false;
                    }

                    //========================== if its coming from Edit ==========================>
                    //========================== if its coming from Edit ==========================>
                    else
                    {
                        buttonId = buttonId[buttonId.Length - 1].ToString();

                        DropDownList Change = new DropDownList();

                        int row = int.Parse(Session["ToHideDrops"].ToString());

                        Change = (Grid1.Rows[row].FindControl("DropDownClass" + buttonId) as DropDownList);

                        Change.Visible = false;
                    }


                }

                else
                {
                    string buttonId = DropChenged.ID;

                    //========================== if its coming from footer ==========================>
                    //========================== if its coming from footer ==========================>
                    if (buttonId[0] != 'D')
                    {
                        buttonId = buttonId[buttonId.Length - 1].ToString();

                        ///////////////////////// Finding DropDown Subject 
                        DropDownList ChangeSub = new DropDownList();
                        ChangeSub = (Page.FindControl("FooterLesson" + buttonId) as DropDownList);

                        ///////////////////////// Finding DropDown Class 
                        DropDownList Change = new DropDownList();
                        Change = (Page.FindControl("FooterClass" + buttonId) as DropDownList);
                        Change.Items.Clear();

                        ///////////////////////// Getting Class That Learn This Subject
                        DataTable DTNOW = new DataTable();
                        DTNOW = MyClass.SelectClassesByClassANDSUBJECT(FooterTName.SelectedValue.ToString(), ChangeSub.SelectedValue.ToString());

                        //============================ Change Lang ============================
                        if (Session["Lang"].ToString().Equals("EN"))
                        {
                            Change.DataSource = DTNOW;
                            Change.DataTextField = "CName";
                            Change.DataValueField = "ClassCode";
                            Change.DataBind();
                        }

                        else
                            for (int item = 0; item < DTNOW.Rows.Count; item++)
                                Change.Items.Add(new ListItem(ConvertClassToArabic(DTNOW.Rows[item][0].ToString()), DTNOW.Rows[item][1].ToString()));

                        Change.Visible = true;
                    }

                    //========================== if its coming from Edit ==========================>
                    //========================== if its coming from Edit ==========================>
                    else
                    {
                        buttonId = buttonId[buttonId.Length - 1].ToString();
                        int row = int.Parse(Session["ToHideDrops"].ToString());

                        ///////////////////////// Finding DropDown Subject 
                        DropDownList ChangeSub = new DropDownList();
                        ChangeSub = (Grid1.Rows[row].FindControl("DropDownSubject" + buttonId) as DropDownList);

                        ///////////////////////// Finding DropDown Class 
                        DropDownList Change = new DropDownList();
                        Change = (Grid1.Rows[row].FindControl("DropDownClass" + buttonId) as DropDownList);
                        Change.Visible = true;

                        ///////////////////////// Getting Teacher ID
                        Label TeacherID = new Label();
                        TeacherID = (Grid1.Rows[row].FindControl("EditLabelTId") as Label);
                        string TID = "";

                        for (int ID9 = 0; ID9 < 9; ID9++)
                            TID += TeacherID.Text[ID9].ToString();

                        ///////////////////////// Getting Class That Learn This Subject                            
                        DataTable DTNOW = new DataTable();
                        DTNOW = MyClass.SelectClassesByClassANDSUBJECT(TID, ChangeSub.SelectedValue.ToString());
                        Change.Items.Clear();

                        //============================ Change Lang ============================
                        if (Session["Lang"].ToString().Equals("EN"))
                        {
                            Change.DataSource = DTNOW;
                            Change.DataTextField = "CName";
                            Change.DataValueField = "ClassCode";
                            Change.DataBind();
                        }

                        else
                            for (int item = 0; item < DTNOW.Rows.Count; item++)
                                Change.Items.Add(new ListItem(ConvertClassToArabic(DTNOW.Rows[item][0].ToString()), DTNOW.Rows[item][1].ToString()));

                        Change.Visible = true;
                    }
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

        protected void FooterDayWeek_SelectedIndexChanged(object sender, EventArgs e)
        {
            ButtonCalendar.Text=FooterDayWeek.SelectedItem.Text.ToString();
        }

        protected void AddClassesSchedules_Click(object sender, EventArgs e)
        {

            MyClass.CheckForInternetConnection();
            if (MyClass.NetCheck == true)
            {
                Regenerate();
             
                DataTable DTParent = new DataTable();
                DTParent.Columns.Add(new DataColumn("Grids", typeof(DataTable)));

                //////////////////////// Select From DB and Add New Grid
                DataTable AllClassSchedules = new DataTable();
                AllClassSchedules = MyClass.ShowClassesSchedulesSorted();


                //////////////////////// Start Add Class Schudles 
                DataTable ClassSchudles;
                DataTable ClassSchudlesCopy;
                DropDownList IfExist = new DropDownList();
                string CName = "";

                
                for (int i = 0; i < AllClassSchedules.Rows.Count; i++)
                {
                    //////////////////////// Checking if Class Name Repeated
                    CName = AllClassSchedules.Rows[i].ItemArray[8].ToString();

                    if (IfExist.Items.FindByText(CName) == null)
                    {
                        //////////////////////// Opining Empty Table so we can put values in it 
                        IfExist.Items.Add(CName);
                        ClassSchudles = new DataTable();

                        ClassSchudles.Columns.Add(new DataColumn("Cnt", typeof(int)));
                        ClassSchudles.Columns.Add(new DataColumn("L1", typeof(string)));
                        ClassSchudles.Columns.Add(new DataColumn("L2", typeof(string)));
                        ClassSchudles.Columns.Add(new DataColumn("L3", typeof(string)));
                        ClassSchudles.Columns.Add(new DataColumn("L4", typeof(string)));
                        ClassSchudles.Columns.Add(new DataColumn("L5", typeof(string)));
                        ClassSchudles.Columns.Add(new DataColumn("L6", typeof(string)));
                        ClassSchudles.Columns.Add(new DataColumn("L7", typeof(string)));
                        ClassSchudles.Columns.Add(new DataColumn("Class", typeof(string)));
                        ClassSchudles.Columns.Add(new DataColumn("Day", typeof(string)));

                        //////////////////////// Getting Class Schudles
                        ClassSchudlesCopy = new DataTable();
                        ClassSchudlesCopy = MyClass.SelectClassSchedules(AllClassSchedules.Rows[i].ItemArray[8].ToString());

                        for (int Row = 0; Row < ClassSchudlesCopy.Rows.Count; Row++)
                        {
                            //////////////////////// Adding Empty Row 
                            int therow;
                            DataRow EmptyRow = ClassSchudles.NewRow();
                            EmptyRow["Cnt"] = 0;
                            EmptyRow["L1"] = "❌";
                            EmptyRow["L2"] = "❌";
                            EmptyRow["L3"] = "❌";
                            EmptyRow["L4"] = "❌";
                            EmptyRow["L5"] = "❌";
                            EmptyRow["L6"] = "❌";
                            EmptyRow["L7"] = "❌";
                            EmptyRow["Class"] = "❌";
                            EmptyRow["Day"] = "❌";
                            ClassSchudles.Rows.Add(EmptyRow);

                            //////////////////////// Copying Values From ClassSchudlesCopy to ClassSchudles (Empty Tabel)

                            if (!ClassSchudlesCopy.Rows[Row][1].ToString().Equals("Break")&& !ClassSchudlesCopy.Rows[Row][1].ToString().Equals("❌"))
                            {
                                therow = int.Parse(ClassSchudlesCopy.Rows[Row][1].ToString()[7].ToString());                                
                                ClassSchudles.Rows[Row][therow] = ClassSchudlesCopy.Rows[Row][1].ToString().Remove(0, 9);
                            }

                            if (!ClassSchudlesCopy.Rows[Row][2].ToString().Equals("Break") && !ClassSchudlesCopy.Rows[Row][1].ToString().Equals("❌"))
                            {
                                therow = int.Parse(ClassSchudlesCopy.Rows[Row][2].ToString()[7].ToString());
                                ClassSchudles.Rows[Row][therow] = ClassSchudlesCopy.Rows[Row][2].ToString().Remove(0, 9);
                            }

                            if (!ClassSchudlesCopy.Rows[Row][3].ToString().Equals("Break") && !ClassSchudlesCopy.Rows[Row][1].ToString().Equals("❌"))
                            {
                                therow = int.Parse(ClassSchudlesCopy.Rows[Row][3].ToString()[7].ToString());
                                ClassSchudles.Rows[Row][therow] = ClassSchudlesCopy.Rows[Row][3].ToString().Remove(0, 9);
                            }

                            if (!ClassSchudlesCopy.Rows[Row][4].ToString().Equals("Break") && !ClassSchudlesCopy.Rows[Row][1].ToString().Equals("❌"))
                            {
                                therow = int.Parse(ClassSchudlesCopy.Rows[Row][4].ToString()[7].ToString());
                                ClassSchudles.Rows[Row][therow] = ClassSchudlesCopy.Rows[Row][4].ToString().Remove(0, 9);
                            }

                            if (!ClassSchudlesCopy.Rows[Row][5].ToString().Equals("Break") && !ClassSchudlesCopy.Rows[Row][1].ToString().Equals("❌"))
                            {
                                therow = int.Parse(ClassSchudlesCopy.Rows[Row][5].ToString()[7].ToString());
                                ClassSchudles.Rows[Row][therow] = ClassSchudlesCopy.Rows[Row][5].ToString().Remove(0, 9);
                            }

                            if (!ClassSchudlesCopy.Rows[Row][6].ToString().Equals("Break") && !ClassSchudlesCopy.Rows[Row][1].ToString().Equals("❌"))
                            {
                                therow = int.Parse(ClassSchudlesCopy.Rows[Row][6].ToString()[7].ToString());
                                ClassSchudles.Rows[Row][therow] = ClassSchudlesCopy.Rows[Row][6].ToString().Remove(0, 9);
                            }

                            if (!ClassSchudlesCopy.Rows[Row][7].ToString().Equals("Break") && !ClassSchudlesCopy.Rows[Row][1].ToString().Equals("❌"))
                            {
                                therow = int.Parse(ClassSchudlesCopy.Rows[Row][7].ToString()[7].ToString());
                                ClassSchudles.Rows[Row][therow] = ClassSchudlesCopy.Rows[Row][7].ToString().Remove(0, 9);
                            }


                            //////////////////////// Converting Data To Arabic  
                            if (!Session["Lang"].ToString().Equals("EN"))
                            {
                                ClassSchudles.Rows[Row][8] = ConvertClassToArabic(ClassSchudlesCopy.Rows[Row].ItemArray[8].ToString()).ToString();
                                ClassSchudles.Rows[Row][9] = ConvertDayToArabic(ClassSchudlesCopy.Rows[Row].ItemArray[9].ToString()).ToString();
                            }
                        }


                        //////////////////////// Adding Class Schudles to Parent GridView
                        DataRow RowParent = null;
                        RowParent = DTParent.NewRow();
                        RowParent["Grids"] = ClassSchudles;
                        DTParent.Rows.Add(RowParent);
                    }                 
                }

                GridClassSC.DataSource = DTParent;
                GridClassSC.DataBind();
                DivClassSC.Visible = true;
                
                //////////////////////// Converting Title Class Names To Arabic  
                if (!Session["Lang"].ToString().Equals("EN"))
                {
                    for (int i = 0; i < GridClassSC.Rows.Count; i++)
                    {
                        Button ClassNameX = ((Button)GridClassSC.Rows[i].FindControl("GridClassButtonTitle"));

                        ClassNameX.Text = ConvertClassToArabic(IfExist.Items[i].ToString());

                        for (int i2 = 1; i2 <= 7; i2++)
                        {
                            Label Lesson = ((Label)GridClassSC.Rows[i].FindControl("LabelL" + i2));

                            Lesson.Text = ConvrtLessonToArabic(Lesson.Text);
                        }
                    }

                }

                IfExist.Items.Clear();
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

        public string ConvertClassToArabic(string CName)
        {

            string ARClassName = "";
            char LastChar;

            LastChar = CName[CName.Length - 1];

            CName = CName.Remove(CName.Length - 1);


            if (CName.Equals("KIDS "))
                ARClassName = "البستان";

            else if (CName.Equals("One "))
                ARClassName = "الاول";

            else if (CName.Equals("Two "))
                ARClassName = "الثاني";

            else if (CName.Equals("Three "))
                ARClassName = "الثالث";

            else if (CName.Equals("four "))
                ARClassName = "الرابع";

            else if (CName.Equals("five "))
                ARClassName = "الخامس";

            else if (CName.Equals("six "))
                ARClassName = "السادس";

            else if (CName.Equals("seven "))
                ARClassName = "السابع";

            else if (CName.Equals("eight "))
                ARClassName = "الثامن";

            else if (CName.Equals("nine "))
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

            return ARClassName;
        }

        public string ConvertDayToArabic(string Day)
        {
            string ConvertedDay = "";

            if (Day.Equals("One"))
                ConvertedDay = "الاحد";

            else if (Day.Equals("Two"))
                ConvertedDay = "الاثنين";

            else if (Day.Equals("Three"))
                ConvertedDay = "الثلاثاء";

            else if (Day.Equals("Four"))
                ConvertedDay = "الاربعاء";

            else if (Day.Equals("Five"))
                ConvertedDay = "الخميس";

            else if (Day.Equals("Six"))
                ConvertedDay = "الجمعه";

            else if (Day.Equals("Seven"))
                ConvertedDay = "السبت";

            else
                ConvertedDay = Day;

            return ConvertedDay;
        }

        public string ConvrtLessonToArabic(string Lesson)
        {
            string ResultLesson = "";

            if (Lesson.Equals("Lesson 1"))
                ResultLesson = "الدرس 1";

            else if (Lesson.Equals("Lesson 2"))
                ResultLesson = "الدرس 2";

            else if (Lesson.Equals("Lesson 3"))
                ResultLesson = "الدرس 3";

            else if (Lesson.Equals("Lesson 4"))
                ResultLesson = "الدرس 4";

            else if (Lesson.Equals("Lesson 5"))
                ResultLesson = "الدرس 5";

            else if (Lesson.Equals("Lesson 6"))
                ResultLesson = "الدرس 6";

            else if (Lesson.Equals("Lesson 7"))
                ResultLesson = "الدرس 7";

            return ResultLesson;
        }

        public void SortFooter()
        {
            int LessonIndex=1;
            DropDownList Subjects, Classes;

            MyClass.CheckForInternetConnection();
            if (MyClass.NetCheck == true)
            {

                for (; LessonIndex <= 7; LessonIndex++)
                {
                    Subjects = (Page.FindControl("FooterLesson" + LessonIndex.ToString()) as DropDownList);
                    Classes = (Page.FindControl("FooterClass" + LessonIndex.ToString()) as DropDownList);

                    //======================== After Select Teacher in DR Teachers Making the Classes DropDowns None Visible
                    Subjects.Visible = true;
                    Classes.Visible = false;
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

                        if(!Row.Equals("Break#Break"))
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
                                            ListOfClasses.Add(MyTable.Rows[TabelRow][TabelCol].ToString()+" "+ TabelCol.ToString());
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





                string Break = "Break", TheDate = "", TheClass = "", SubjectName = "",LessonNumber="";
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

                        LessonNumber = ListOfClasses[i+1][ListOfClasses[i + 1].Length-1].ToString();

                        if (!SubjectName.Equals("Break"))
                            SubjectName = MyClass.SelectSubject(SubjectName).Rows[0][0].ToString();



                        if (Subjects.Count >= 7)
                        {
                            i = ListOfClasses.Count;
                            TheClass = MyClass.SelectClassNameByCode(int.Parse(TheClass.ToString())).Rows[0][0].ToString();
                            Message = "Max Lessons Is (8)....                Class " + TheClass + " Cannot Have More Than 8 Lessons In a Day !";
                            MyClass.RemoveClassSchedules();
                            MyClass.RemoveTecherSchedulesLastRow();
                            Session["Generate"] = "Dont";

                            RefresDDLists();
                            RefreshGrid(-1);
                            Regenerate();

                            LabelMessage.Text = Message;
                            DivMessage.Visible = true;
                        }

                        else
                        {
                            Subjects.Add("Lesson "+ (LessonNumber).ToString()+" "+SubjectName);
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

        protected void ClassSchudClose_Click(object sender, EventArgs e)
        {
            DivClassSC.Visible = false;
        }

        protected void BackButton2_Click(object sender, EventArgs e)
        {
            Response.Redirect("Choose.aspx");
        }

        protected void CheckSlid_CheckedChanged(object sender, EventArgs e)
        {

            if (CheckSlid.Checked == true)
            {
                FooterDayWeek.Visible = false;
                ButtonCalendar.Visible = true;

                /////////////////////////// Making Text Select Day
                if (Session["Lang"].ToString().Equals("EN"))
                    ButtonCalendar.Text = "Select Day";

                else
                    ButtonCalendar.Text = "اختر يوم";
            }

            else
            {
                FooterDayWeek.Visible = true;
                ButtonCalendar.Visible = false;

                /////////////////////////// Selecting First Day from dropdown Days                
                FooterDayWeek.SelectedItem.Selected = false;
                FooterDayWeek.Items.FindByValue("One").Selected = true;
                ButtonCalendar.Text = FooterDayWeek.SelectedItem.Text;
            }
        }

        protected void DivDayWeek_SelectedIndexChanged(object sender, EventArgs e)
        {
            Button Days = ((Button)Grid1.Rows[int.Parse(Session["EditDay"].ToString())].FindControl("EditDay2"));
            Days.Text = DivDayWeek.SelectedItem.Text.ToString();
            DivDivDayWeek.Visible = false;
        }

        protected void BackClick_Click(object sender, EventArgs e)
        {
            Response.Redirect("Choose.aspx");
        }
    }
}
    



