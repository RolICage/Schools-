using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using school.App_Code;
using System.Drawing.Text;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.Net.NetworkInformation;
using static school.WebForm1;

namespace school
{
    public partial class SchoolMain : System.Web.UI.Page
    {
        public static DataTable MyTable, MyTable2, MyClassTable, CheckTabel, NewTable;
        static private string Parentname, Parentpid, Parentchilds, Parentnumber;
        public static int x = 0;
        public static int PopUpFixer = 0;
        public Image ProfilePic = new Image();
        bool Check = true;
        public string Case="All";


    //////////////////////////////////////////////Constractors///////////////////////////////////////////
    //////////////////////////////////////////////Constractors///////////////////////////////////////////

        public static string Parentname1 { get => Parentname; set => Parentname = value; }
        public static string Parentpid1 { get => Parentpid; set => Parentpid = value; }
        public static string Parentchilds1 { get => Parentchilds; set => Parentchilds = value; }
        public static string Parentnumber1 { get => Parentnumber; set => Parentnumber = value; }


        //////////////////////////////////////////////Constractors///////////////////////////////////////////
        //////////////////////////////////////////////Constractors///////////////////////////////////////////
        protected void Page_Load(object sender, EventArgs e)
        {

            if (System.Web.HttpContext.Current.Session["SCODE"] != null)
            {
                DivPop.Visible = false;
                DivMessage.Visible = false;

                if (Session["Lang"].ToString().Equals("AR"))
                {
                    selectimagebutton.Text = "اختر صورة";
                }

                if (!IsPostBack)
                {
                    FooterPID.TextMode = TextBoxMode.Number;
                    FooterPID.MaxLength = 9;

                    FooterSID.TextMode = TextBoxMode.Number;
                    FooterSID.MaxLength = 9;


                    Session["Switch"] = "All";
                    Session["Case"] = "All";
                    Session["Student"] = "";
                    Session["Class"] = "";
                    Session["Case2"] = "0";
                    Session["ProfilePicToAdd"] = "";
                    TextFind.Attributes.Add("Type", "number");
                    Grid1FooterTabel.Style["background-image"] = "Gifs/ezgiffot.gif";
                    Grid1.ShowFooter = false;
                    ChangeIDPopUp.Visible = false;
                    PopUpAccept.Visible = false;

                    SortGrid();
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

        public void SortGrid()
        {
            GetImages(-1);
            GetClass();
        }
        
        public void GetImages(int index)
        {
            string SID, Image;
            int ClassCode;

            //============================ GetAll Students ============================
            //============================ GetAll Students ============================
            if (Session["Case"].ToString().Equals("All"))
            {
                GetStudents();
            }

            //============================ Get One Student (Student Searched) ============================
            //============================ Get One Student (Student Searched) ============================
            else if (Session["Case"].ToString().Equals("Student"))
            {
                MyTable = MyClass.SelectStudent(Session["Student"].ToString());

                Fill(MyTable);
            }

            //============================ Get Class (Class Searched) ============================
            //============================ Get Class (Class Searched) ============================
            else if (Session["Case"].ToString().Equals("Class"))
            {
                ClassCode = int.Parse(Session["Class"].ToString());

                MyTable = MyClass.SelectStudentsByClassCode2(ClassCode);

                Fill(MyTable);
            }



            //============================ Set Students Images ============================
            //============================ Set Students Images ============================
            int Cnt = MyTable.Rows.Count;

            for (int i=0;i< Cnt; i++)
            {
                if (i == index)
                    i++;

                if(i< Cnt)
                {
                    SID = MyTable.Rows[i][1].ToString();
                    Image = MyClass.FindImageBySID(SID);

                    ProfilePic = (Image)Grid1.Rows[i].FindControl("ProfilePic");


                    if (!Image.Equals(""))
                    {
                        ProfilePic.ImageUrl = "~/Images/" + Image;
                    }

                    else
                    {
                        ProfilePic.ImageUrl = "~/Images/studentpic2.png";
                    }
                }
                                 

            }


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

                        Edits = ((Button)Grid1.Rows[rowindex].FindControl("ChangeID"));
                        Edits.Text = "ChangeID";
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
                TextFind.Attributes.Add("placeholder", "Enter Student ID");

                //============================ Change Select Image Lang ============================
                selectimagebutton.Text = "Select Image";

                //============================ Change Header Lang ============================
                HeaderStudentName.Text = "STUDENT NAME";
                HeaderStudentID.Text = "STUDENT ID";
                HeaderParents.Text = "PARENT ID";
                HeaderStudentClass.Text = "CLASS";

                //============================ Change Footer Add Lang ============================
                AddStudButton.Text = "ADD STUDENT";

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

                        Edits = ((Button)Grid1.Rows[rowindex].FindControl("ChangeID"));
                        Edits.Text = "تحديث رقم الهويه";                        
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
                TextFind.Attributes.Add("placeholder", "  رقم هويه الطالب  ");

                //============================ Change Select Image Lang ============================
                selectimagebutton.Text = "اختر صوره";

                //============================ Change Header Lang ============================
                HeaderStudentName.Text = "اسم الطالب";
                HeaderStudentID.Text = "هويه الطالب";
                HeaderParents.Text = "هويه الاب";
                HeaderStudentClass.Text = "الصف";
                PopCancel.Text = "الغاء";
                PopAdd.Text = "اضف";
                ButtonMessage.Text = "اغلاق";
                STDMarksClose.Text = "اغلاق";

                //============================ Change Footer Add Lang ============================
                AddStudButton.Text = "اضف الطالب";
                

                //============================ Change Header Marks Lang ============================
                MarksSubName.Text = "الموضوع";
                MarksMark.Text = "العلامه";
                MarksChapter.Text = "الفصل";
                ShowSTDMarks.Text = "عرض العلامات";

                //=================== Parents Add Lang >
                TextBoxPname.Attributes.Add("placeholder", "اسم الاب");
                TextBoxPphone.Attributes.Add("placeholder", "هاتف الاب");


                FooterName.Attributes.Add("placeholder", "اسم الطالب");
                FooterSID.Attributes.Add("placeholder", "رقم هويه الطالب");
                FooterPID.Attributes.Add("placeholder", "رقم هويه الاب");
                FooterPhone2.Attributes.Add("placeholder", "هاتف الطالب");
                FooterPlace.Attributes.Add("placeholder", "العنوان");
                FileUpload2Button.Text = "رفع الصوره";
                DivSTDADD.Text = "اضف";
                DivSTDExit.Text = "الغاء";
                FooterPlace.Text = "";
            }

        }

        public void GetStudents()
        {
            //============================ Getting The First Class in DB ============================
            //============================ Getting The First Class in DB ============================
            int ClassCode;

            MyTable = MyClass.ShowStudents();

            ClassCode = int.Parse(MyTable.Rows[0][3].ToString());

            MyTable = MyClass.SelectStudentsByClassCode2(ClassCode);

            //============================ Convert Code To Names ============================
            //============================ Convert Code To Names ============================
            Fill(MyTable);


            //============================ Fill DropDown Classes ============================
            //============================ Fill DropDown Classes ============================
            GetClass();
        }

        public void GetClass()
        {

            FooterClassCode.Items.Clear();

            MyClassTable = MyClass.ShowClasses();

            int Length = MyClassTable.Rows.Count;

            if (Length > 0)
            {


                if (Session["Lang"].ToString().Equals("EN"))
                {
                    FooterClassCode.DataSource = MyClassTable;
                    FooterClassCode.DataValueField = "ClassCode";
                    FooterClassCode.DataTextField = "CName";                  
                }

                else
                {

                    FooterClassCode.DataSource = MyClassTable;
                    FooterClassCode.DataValueField = "ClassCode";
                    FooterClassCode.DataTextField = "CName";

                    DataTable ARClassTabel;
                    string ClassNameNow = "", ARClassName = "";
                    char LastChar;

                    for (int rowindex = 0; rowindex < MyClassTable.Rows.Count; rowindex++)
                    {

                        ClassNameNow = MyClassTable.Rows[rowindex][0].ToString();

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

                        MyClassTable.Rows[rowindex][0] = ARClassName;
                    }
                }

                FooterClassCode.DataBind();
            }
        }

        public void Fill(DataTable Table)
        {
            int i = 0;
            string StudentName, StudentID, ParentID, ClassName, CCode;

            NewTable = new DataTable();

            //============================ Convert Code To Names ============================
            //============================ Convert Code To Names ============================
            while (i < Table.Rows.Count)
            {
                StudentName = Table.Rows[i][0].ToString();
                StudentID = Table.Rows[i][1].ToString();
                ParentID = Table.Rows[i][2].ToString();
                CCode = Table.Rows[i][3].ToString();

                ClassName = MyClass.SelectClassNameByCode(int.Parse(CCode)).Rows[0][0].ToString();

                //============================ Change Lang ============================
                //============================ Change Lang ============================
                if (!Session["Lang"].ToString().Equals("EN"))
                {
                    string ClassNameNow = "", ARClassName = "";
                    char LastChar;

                    ClassNameNow = ClassName;

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

                    ClassName = ARClassName;
                }

                DataRow Row = null;


                if (i == 0)
                {
                    NewTable.Columns.Add(new DataColumn("SName", typeof(string)));
                    NewTable.Columns.Add(new DataColumn("SID", typeof(string)));
                    NewTable.Columns.Add(new DataColumn("PID", typeof(string)));
                    NewTable.Columns.Add(new DataColumn("ClassCode", typeof(string)));
                }

                Row = NewTable.NewRow();
                Row["SName"] = StudentName.ToString();
                Row["SID"] = StudentID.ToString();
                Row["PID"] = ParentID.ToString();
                Row["ClassCode"] = ClassName.ToString();
                NewTable.Rows.Add(Row);

                i++;
            }

            Grid1.DataSource = NewTable;
            Grid1.DataBind();
        }


        ////////////////////////////////////////////////////////////////////////////////////////////////////
        ////////////////////////////////////////////////////////////////////////////////////////////////////
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        protected void Grid1_RowEditing(object sender, GridViewEditEventArgs e)
        {

            if (Check == true)
            {
                //===================================== Getting SID to check if exists before doing any action =====================================
                DataTable SIDExist;
                SIDExist = MyClass.SelectStudent(Session["StudentIDSID"].ToString());

                if (SIDExist.Rows.Count > 0)
                {
                    int index = e.NewEditIndex;
                    Grid1.EditIndex = e.NewEditIndex;


                    GetImages(index);
                    GetClass();


                    Grid1.Rows[index].BackColor = System.Drawing.ColorTranslator.FromHtml("#303030");
                    Grid1.Rows[index].Style["background-image"] = "Images/GridEditRow.Gif";


                    DropDownList ddlClassCode = ((DropDownList)Grid1.Rows[index].FindControl("ddlClasscode"));

                    DataTable MyClassTable;

                    MyClassTable = MyClass.ShowClasses();

                    ddlClassCode.DataSource = MyClassTable;
                    ddlClassCode.DataValueField = "ClassCode";
                    ddlClassCode.DataTextField = "CName";


                    if (!Session["Lang"].ToString().Equals("EN"))
                    {

                        string ClassNameNow = "", ARClassName = "";
                        char LastChar;

                        for (int rowindex = 0; rowindex < MyClassTable.Rows.Count; rowindex++)
                        {

                            ClassNameNow = MyClassTable.Rows[rowindex][0].ToString();

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

                            MyClassTable.Rows[rowindex][0] = ARClassName;
                        }

                    }

                    ddlClassCode.DataBind();

                    ddlClassCode.Items.FindByText(Session["ClassName"].ToString()).Selected = true;

                    x = 0;
                }

                else
                    SortGrid();

            }

            else
            {
                DivMessage.Visible = true;

                if (Session["Lang"].ToString().Equals("EN"))
                    LabelMessage.Text = "Connection Time Out !";

                else
                    LabelMessage.Text = "لا يوجد انترنت !";
            }
        }


        ////////////////////////////////////////////////////////////////////////////////////////////////////
        ////////////////////////////////////////////////////////////////////////////////////////////////////
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        protected void Grid1_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            Grid1.EditIndex = -1;
            Grid2.Visible = false;
            GetImages(-1);
            GetClass();
        }


        ////////////////////////////////////////////////////////////////////////////////////////////////////
        ////////////////////////////////////////////////////////////////////////////////////////////////////
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        protected void Grid1_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            string Name = "", SID = "", PID = "", Result = "", C = "";
            int ClassCode, IDResult, cnt = 0;


            if (Check == true)
            {

                SID = Grid1.DataKeys[e.RowIndex].Value.ToString();
                Name = (Grid1.Rows[e.RowIndex].FindControl("TextName") as TextBox).Text.ToString();
                PID = (Grid1.Rows[e.RowIndex].FindControl("TextPID") as TextBox).Text.ToString();
                C = (Grid1.Rows[e.RowIndex].FindControl("ddlClasscode") as DropDownList).SelectedItem.Value.ToString();
                LabelMessage.Text = C;

                //===================================== Getting SID to check if exists before doing any action =====================================
                DataTable SIDExist;
                SIDExist = MyClass.SelectStudent(SID);

                if (SIDExist.Rows.Count > 0)
                {
                    //===================================== Check Example =====================================
                    //===================================== Check Example =====================================
                    if (!SID.Equals("205879463"))
                    {
                        //===================================== Check if Empty =====================================
                        //===================================== Check if Empty =====================================
                        if (Name != "" && PID != "" && C != "" && SID != "")
                        {

                            ClassCode = int.Parse(C.ToString());
                            Session["Class"] = ClassCode.ToString();

                            //===================================== Check ID =====================================
                            //===================================== Check ID =====================================
                            IDResult = int.Parse(MyClass.IDChecker(PID).ToString());

                            if (IDResult == 1)
                            {
                                //===================================== Check if parent added =====================================
                                //===================================== Check if parent added =====================================
                                MyTable = MyClass.SelectParent(PID);

                                if (MyTable.Rows.Count == 1)
                                {
                                    MyClass.UpdateClassCodeinMessages2(ClassCode, SID);
                                    Result = MyClass.UpdateStudent(Name, SID, PID, ClassCode);

                                    DivMessage.Visible = true;

                                    if (Session["Lang"].ToString().Equals("EN"))
                                        LabelMessage.Text = "   " + Result;

                                    else
                                        LabelMessage.Text = "تم تحديث معلومات الطالب";

                                    Grid1.EditIndex = -1;
                                    GetImages(-1);
                                    GetClass();
                                }


                                else
                                {
                                    Session["Case2"] = "1";
                                    Session["StudentName"] = Name.ToString();
                                    Session["StudentID"] = SID.ToString();
                                    Session["ParentsID"] = PID.ToString();
                                    Session["ClassCode"] = ClassCode.ToString();

                                    DivPop.Visible = true;
                                    TextBoxPID.Text = PID.ToString();

                                }
                            }

                            else
                            {
                                DivMessage.Visible = true;

                                if (Session["Lang"].ToString().Equals("EN"))
                                    LabelMessage.Text = "Parents ID Is illegal !";

                                else
                                    LabelMessage.Text = "رقم هويه الوالد غير قانوني !";
                            }

                        }


                        else
                        {
                            DivMessage.Visible = true;

                            if (Session["Lang"].ToString().Equals("EN"))
                                LabelMessage.Text = "There is An Empty Boxies !";

                            else
                                LabelMessage.Text = "هناك سطور فارغه !";
                        }
                    }
                }

                else
                    SortGrid();

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

        protected void Grid1_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            string SID, ImageName = "", PID = "", Result = "";
            int Checking = 0;


            if (Check == true)
            {
                SID = Grid1.DataKeys[e.RowIndex].Value.ToString();

                //===================================== Getting SID to check if exists before doing any action =====================================
                DataTable SIDExist;
                SIDExist = MyClass.SelectStudent(SID);

                if (SIDExist.Rows.Count > 0)
                {
                    if (!SID.Equals("205879463"))
                    {

                        MyTable2 = MyClass.SelectSchoolRank(Session["SCODE"].ToString());

                        Result = MyTable2.Rows[0][0].ToString();

                        if (!Result.Equals("1"))
                        {
                            MyTable = MyClass.SelectMarkBySID(SID);
                            if (MyTable.Rows.Count > 0)
                                Checking++;
                        }


                        MyTable = MyClass.SelectfromImagesBySID(SID);
                        if (MyTable.Rows.Count > 0)
                            Checking++;

                        MyTable = MyClass.Messages(SID);
                        if (MyTable.Rows.Count > 0)
                            Checking++;

                        MyTable = MyClass.SelectImagesAndroid(SID);
                        if (MyTable.Rows.Count > 0)
                            Checking++;

                        MyTable = MyClass.Presences(SID);
                        if (MyTable.Rows.Count > 0)
                            Checking++;


                        if (Checking > 0)
                        {
                            Session["SID"] = SID.ToString();

                            if (Session["Lang"].ToString().Equals("EN"))
                                LabelAccept.Text = "There Is Data Will Be Removed From Other Tabels       (Cannot undo changes)        Do You Want To Continue ?";

                            else
                                LabelAccept.Text = "هناك بيانات ستتم إزالتها من جداول أخرى   (لا يمكن التراجع عن التغييرات)   هل تريد المتابعة؟";

                            Accept.Text = "موافق";
                            Cancel.Text = "إلغاء";

                            PopUpAccept.Visible = true;
                            Checking = 0;
                        }


                        else
                        {

                            MyTable = MyClass.SelectStudent(SID);
                            PID = MyTable.Rows[0][2].ToString();
                            ImageName = MyClass.FindImageBySID(SID).ToString();

                            MyClass.RemoveImage(SID);
                            ServerRemoveImage(ImageName);
                            MyClass.RemoveStudent(SID);



                            GetImages(-1);
                            GetClass();

                            DivMessage.Visible = true;

                            if (Session["Lang"].ToString().Equals("EN"))
                                LabelMessage.Text = SID.ToString() + "  Student Removed";

                            else
                                LabelMessage.Text = SID.ToString() + "  تم حذف الطالب";
                        }

                    }
                }

                else
                    SortGrid();
            }

            else
            {
                DivMessage.Visible = true;

                if (Session["Lang"].ToString().Equals("EN"))
                    LabelMessage.Text = "Connection Time Out !";

                else
                    LabelMessage.Text = "لا يوجد هناك انترنت !";

            }

            Checking = 0;
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        ////////////////////////////////////////////////////////////////////////////////////////////////////
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        protected void Grid1_RowCommand(object sender, GridViewCommandEventArgs e)
        {

            if (Check == true)
            {
                if (e.CommandName.Equals("ChangeID"))
                {
                    if (!e.CommandArgument.Equals("205879463"))
                    {
                        string id = e.CommandArgument.ToString();

                        MyTable = MyClass.SelectStudent(id);

                        //===================================== Getting SID to check if exists before doing any action =====================================
                        if (MyTable.Rows.Count > 0)
                        {
                            id = MyTable.Rows[0].ItemArray[1].ToString();

                            ChangeIDPopUp.Visible = true;

                            if (Session["Lang"].ToString().Equals("EN"))
                                Grid2.Columns[1].HeaderText = "Student ID";

                            else
                                Grid2.Columns[1].HeaderText = "هويه الطالب";

                            Grid2.DataSource = MyTable;
                            Grid2.DataBind();

                            Grid2.Rows[0].Style["background-image"] = "Images/GridEditRow.Gif";

                            //============================ Change Lang ============================
                            //============================ Change Lang ============================
                            Button Edits;

                            if (Session["Lang"].ToString().Equals("EN"))
                            {
                                Edits = ((Button)Grid2.Rows[0].FindControl("Update"));
                                Edits.Text = "Update";

                                Edits = ((Button)Grid2.Rows[0].FindControl("Cancel"));
                                Edits.Text = "Cancel";
                            }

                            else
                            {
                                Edits = ((Button)Grid2.Rows[0].FindControl("Update"));
                                Edits.Text = "تحديث";

                                Edits = ((Button)Grid2.Rows[0].FindControl("Cancel"));
                                Edits.Text = "الغاء";
                            }

                            Grid2.Visible = true;
                        }

                        else
                            SortGrid();
                    }
                }


                else if (e.CommandName.Equals("ChangePic"))
                {

                    int RowIndex = int.Parse(e.CommandArgument.ToString());
                    string OldImage = "";

                    ProfilePic = (Image)Grid1.Rows[RowIndex].Cells[1].FindControl("ProfilePic");



                    string SID = (Grid1.Rows[RowIndex].Cells[2].FindControl("SID") as Label).Text.ToString();

                    string folderPath = Server.MapPath("~/Images/");

                    string strname = FileUpload1.FileName.ToString();

                    int len = strname.Length;
                    string ImageTybe="", ImageTybe2 = "";


                    if(FileUpload1.HasFile)
                    {
                        //================================ Get Image Type ================================
                        //================================ Get Image Type ================================
                        while (strname[len - 1] != '.')
                        {
                            ImageTybe += strname[len - 1];
                            len--;
                        }

                        len = ImageTybe.Length;

                        while (len > 0)
                        {
                            ImageTybe2 += ImageTybe[len - 1];
                            len--;
                        }


                        //================================ Check Image Type ================================
                        //================================ Check Image Type ================================
                        if (ImageTybe2.Equals("jpg") || ImageTybe2.Equals("png"))
                        {
                            if (FileUpload1.HasFile)
                            {
                                OldImage = MyClass.FindImageBySID(SID).ToString();
                                MyClass.RemoveImage(SID);
                                ServerRemoveImage(OldImage);

                                FileUpload1.SaveAs(folderPath + Path.GetFileName(FileUpload1.FileName));

                                MyClass.AddImage(SID, strname);

                                Grid1.EditIndex = -1;
                                GetImages(-1);
                                GetClass();

                                if (Session["Lang"].ToString().Equals("EN"))
                                    LabelMessage.Text = "Image Added";
                                else
                                    LabelMessage.Text = "تمت إضافة الصورة";

                                DivMessage.Visible = true;
                            }

                            else
                            {
                                if (Session["Lang"].ToString().Equals("EN"))
                                    LabelMessage.Text = "Select Image Please !";

                                else
                                    LabelMessage.Text = "اختر صوره !";

                                DivMessage.Visible = true;
                            }
                        }

                        else
                        {
                            if (Session["Lang"].ToString().Equals("EN"))
                                LabelMessage.Text = "Select Image Please Jpg or Png only!";

                            else
                                LabelMessage.Text = "حدد صورة من فضلك Jpg أو Png فقط!";

                            DivMessage.Visible = true;
                        }
                    }

                    else
                    {
                        if (Session["Lang"].ToString().Equals("EN"))
                            LabelMessage.Text = "Select Image Please !";

                        else
                            LabelMessage.Text = "اختر صوره !";

                        DivMessage.Visible = true;
                    }


                }
                
                else if (e.CommandName.Equals("Edit"))
                {
                    int index;
                    string ClassName,SID;

                    //===================================== Save ClassCode =====================================
                    //===================================== Save ClassCode =====================================
                    index = int.Parse(e.CommandArgument.ToString());

                    ClassName = (Grid1.Rows[index].FindControl("ClassCode") as Label).Text.ToString();
                    SID = (Grid1.Rows[index].FindControl("SID") as Label).Text.ToString();

                    Session["ClassName"] = ClassName.ToString();
                    Session["StudentIDSID"] = SID.ToString();
                }

                else if(e.CommandName.Equals("MoreInfo"))
                {
                    string CurrntSID = e.CommandArgument.ToString();
                    DataTable GetSTDInfo = new DataTable();

                    string SName = "", SID = "", PID = "", ClassCode = "", Phone = "", Adress = "", BDate = "",Image="";                  

                    GetSTDInfo = MyClass.SelectStudent(CurrntSID);
                    SName = GetSTDInfo.Rows[0][0].ToString();
                    SID = GetSTDInfo.Rows[0][1].ToString();
                    PID = GetSTDInfo.Rows[0][2].ToString();
                    ClassCode = GetSTDInfo.Rows[0][3].ToString();

                    ///////////// Spilt Code and fill text box.. (get number without first 3 digits)
                    string FullPhone = "",Phone3Digits="",PhoneRest="";
                    FullPhone= GetSTDInfo.Rows[0][4].ToString();

                    Phone3Digits = FullPhone[0].ToString();
                    Phone3Digits += FullPhone[1].ToString();
                    Phone3Digits += FullPhone[2].ToString();

                    for(int ic=3;ic<FullPhone.Length;ic++)
                        PhoneRest += FullPhone[ic].ToString();

                    Adress = GetSTDInfo.Rows[0][5].ToString();
                    BDate = GetSTDInfo.Rows[0][6].ToString();
                    GetSTDInfo = MyClass.SelectImageBySID(SID);
                    if (GetSTDInfo.Rows.Count!=0)
                        Image =GetSTDInfo.Rows[0][1].ToString();

                    FooterName.Text = SName;
                    FooterLabelSID.Text = SID;
                    FooterPID.Text = PID;
                    FooterClassCode.Items.FindByValue(ClassCode).Selected = true;
                    FooterPhoneDrop2.SelectedItem.Selected = false;
                    FooterPhoneDrop2.Items.FindByValue(Phone3Digits.ToString()).Selected = true;
                    FooterPhone2.Text = PhoneRest;
                    FooterPlace.Text = Adress;
                    FooterBDate.Text = BDate;
                    if(!Image.Equals(""))
                    {
                        DivProfilePic.ImageUrl = "~/Images/" + Image;
                        Session["ProfilePicToAdd"] = Image;
                    }


                    if (Session["Lang"].ToString().Equals("EN"))
                        DivSTDADD.Text = "UPDATE";
                    else
                        DivSTDADD.Text = "تحديث";

                    FooterClassCode.SelectedItem.Selected = false;
                    UnlockGif.Visible = true;
                    FooterLabelSID.Visible = true;
                    FooterSID.Visible = false;
                    DIVSTDProfile.Visible = true;
                    ShowSTDMarks.Visible = true;
                }
            }
            else
            {
                DivMessage.Visible = true;

                if (Session["Lang"].ToString().Equals("EN"))
                    LabelMessage.Text = "Connection Time Out !";

                else
                    LabelMessage.Text = "لا يوجد انترنت !";

                Grid1.EditIndex = -1;
            }
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        ////////////////////////////////////////////////////////////////////////////////////////////////////
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        protected void Grid2_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            string Name, OldSID, PID, C, NewSID = "",IDChecker="", Result="",Phone="",Adress="",BDate="";
            int ClassCode;


            if (Check == true)
            {
                OldSID = Grid2.DataKeys[e.RowIndex].Value.ToString();
                Name = MyTable.Rows[0].ItemArray[0].ToString();
                PID = MyTable.Rows[0].ItemArray[2].ToString();
                C = MyTable.Rows[0].ItemArray[3].ToString();

                DataTable GetMoreInfo = new DataTable();

                GetMoreInfo = MyClass.SelectStudent(OldSID);

                Phone = GetMoreInfo.Rows[0][4].ToString();
                Adress = GetMoreInfo.Rows[0][5].ToString();
                BDate = GetMoreInfo.Rows[0][6].ToString();


                NewSID = (Grid2.Rows[e.RowIndex].FindControl("TextSID") as TextBox).Text.ToString();
                IDChecker = MyClass.IDChecker(NewSID);


                //===================================== Getting SID to check if exists before doing any action =====================================
                DataTable SIDExist;
                SIDExist = MyClass.SelectStudent(OldSID);

                if (SIDExist.Rows.Count > 0)
                {
                    if (!NewSID.Equals(""))
                    {
                        if (IDChecker.Equals("1"))
                        {
                            MyTable = MyClass.FindStudentByID(NewSID);

                            if (MyTable.Rows.Count == 1)
                            {
                                DivMessage.Visible = true;

                                if (Session["Lang"].ToString().Equals("EN"))
                                    LabelMessage.Text = "   ID Allready USED";

                                else
                                    LabelMessage.Text = "   رقم هويه الطالب مستعمل !";
                            }


                            else
                            {
                                ClassCode = int.Parse(C.ToString());


                                Grid2.Visible = false;


                                MyClass.AddStudent(Name, NewSID, PID, ClassCode,Phone,Adress,BDate);

                                MyTable2 = MyClass.SelectSchoolRank(Session["SCODE"].ToString());

                                Result = MyTable2.Rows[0][0].ToString();

                                if (!Result.Equals("1"))
                                    MyClass.UpdateSIDINMarks(NewSID, OldSID);

                                MyClass.UpdateSIDINImages(NewSID, OldSID);

                                MyClass.UpdateSIDINImagesAndroid(NewSID, OldSID);

                                MyClass.UpdateSIDINMessages(NewSID, OldSID);

                                MyClass.UpdateSIDINPresences(NewSID, OldSID);

                                MyClass.RemoveStudent(OldSID);

                                Session["Student"] = NewSID.ToString();
                                Session["Class"] = ClassCode.ToString();


                                Grid1.EditIndex = -1;
                                GetImages(-1);
                                GetClass();
                                DivMessage.Visible = true;

                                if (Session["Lang"].ToString().Equals("EN"))
                                    LabelMessage.Text = "   Student ID Updated";

                                else
                                    LabelMessage.Text = "   تم تحديث رقم هويه الطالب";

                                ChangeIDPopUp.Visible = false;
                            }
                        }

                        else
                        {
                            DivMessage.Visible = true;

                            if (Session["Lang"].ToString().Equals("EN"))
                                LabelMessage.Text = "Student ID IS illegal";

                            else
                                LabelMessage.Text = "رقم هويه الطالب غير قانوني !";
                        }

                    }

                    else
                    {
                        DivMessage.Visible = true;

                        if (Session["Lang"].ToString().Equals("EN"))
                            LabelMessage.Text = "   ID Box Is Empty";

                        else
                            LabelMessage.Text = "   سطر رقم الهويه فارغ !";
                    }
                }

                else
                    SortGrid();
            }

            else
            {
                DivMessage.Visible = true;

                if (Session["Lang"].ToString().Equals("EN"))
                    LabelMessage.Text = "Connection Time Out !";

                else
                    LabelMessage.Text = "لا يوجد انترنت !";
            }

        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        ////////////////////////////////////////////////////////////////////////////////////////////////////
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        protected void Grid2_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {         
            Grid2.Visible = false;
            ChangeIDPopUp.Visible = false;
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        ////////////////////////////////////////////////////////////////////////////////////////////////////
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        protected void PopAdd_Click(object sender, EventArgs e)
        {
            if (Check == true)
            {
                Parentname1 = TextBoxPname.Text.ToString();
                Parentpid1 = TextBoxPID.Text.ToString();
                Parentnumber1 = DropDownNumsPhoneNumber.SelectedValue.ToString() + TextBoxPphone.Text.ToString();

                if (!Parentname1.Equals("") && !Parentpid1.Equals("") && !Parentnumber1.Equals(""))
                {
                    if (Parentnumber1.Length <= 10 && Parentnumber1.Length >= 9)
                    {
                        int IDResult;

                        IDResult = int.Parse(MyClass.IDChecker(Parentpid1).ToString());


                        if (IDResult == 1)
                        {
                            ////////////////////////// ADD Parents //////////////////////////
                            ////////////////////////// ADD Parents //////////////////////////

                            MyTable2 = MyClass.SelectNotification(Parentpid1);
                            if (MyTable2.Rows.Count == 0)
                                MyClass.AddNotification(Parentpid1);

                            MyTable2 = MyClass.SelectParentPublicDBAccount(Parentpid1);
                            if (MyTable2.Rows.Count == 0)
                                MyClass.CreateRandomPassword(Parentpid1, "P");

                            MyTable2 = MyClass.SelectParentPublicDB2(Parentpid1, Session["SCODE"].ToString());
                            if (MyTable2.Rows.Count == 0)
                                MyClass.AddParentsToPublicDB(Parentpid1, Session["SCODE"].ToString());

                            MyTable2 = MyClass.SelectParent(Parentpid1);
                            if (MyTable2.Rows.Count == 0)
                                MyClass.AddParents(Parentname1, Parentpid1, Parentnumber1);


                            if ((Session["Case2"].ToString()).Equals("0"))
                            {
                                MyClass.AddStudent(Session["StudentName"].ToString(), Session["StudentID"].ToString(), Session["ParentsID"].ToString(), int.Parse(Session["ClassCode"].ToString()), Session["Phone"].ToString(), Session["Adress"].ToString(), Session["BDate"].ToString());
                                AddImge(Session["StudentID"].ToString());
                            }

                            else
                            {
                                string OldClassCode = MyClass.SelectStudent(Session["StudentID"].ToString()).Rows[0][3].ToString();
                                MyClass.UpdateClassCodeinMessages(int.Parse(Session["ClassCode"].ToString()), Session["StudentID"].ToString());

                                if (Session["Case2"].ToString().Equals("2"))
                                {
                                    MyClass.UpdateAllStudentInfo(Session["StudentName"].ToString(), Session["StudentID"].ToString(), Session["ParentsID"].ToString(), int.Parse(Session["ClassCode"].ToString()), Session["Phone"].ToString(), Session["Adress"].ToString(), Session["BDate"].ToString());
                                    AddImge(Session["StudentID"].ToString());
                                }                                 

                                else
                                    MyClass.UpdateStudent(Session["StudentName"].ToString(), Session["StudentID"].ToString(), Session["ParentsID"].ToString(), int.Parse(Session["ClassCode"].ToString()));

                                Grid1.EditIndex = -1;
                                Session["Case2"] = "0";
                                GetImages(-1);
                                GetClass();
                            }

                            FooterName.Text = "";
                            FooterSID.Text = "";
                            FooterPID.Text = "";
                            TextBoxPname.Text = "";
                            TextBoxPID.Text = "";
                            TextBoxPphone.Text = "";
                            DivMessage.Visible = true;

                            if (Session["Lang"].ToString().Equals("EN"))
                                LabelMessage.Text = "   " + Session["Result"].ToString();

                            else
                                LabelMessage.Text = "تم الاضافه";

                            FooterName.Text = "";
                            FooterSID.Text = "";
                            FooterPID.Text = "";
                            FooterPhone2.Text = "";
                            FooterPlace.Text = "";
                            DIVSTDProfile.Visible = false;
                            DivPop.Visible = false;
                            
                            GetImages(-1);
                            GetClass();
                        }

                        else
                        {
                            if (Session["Lang"].ToString().Equals("EN"))
                                LabelMessage.Text = "Parents ID IS illegal";

                            else
                                LabelMessage.Text = "رقم هويه الوالد غير قانوني";

                            DivMessage.Visible = true;
                            PopUpFixer = 1;


                            TextBoxPID.BorderColor = System.Drawing.Color.Transparent;
                            PopAdd.BackColor = System.Drawing.Color.Black;
                        }
                    }

                    else
                    {

                        if (Session["Lang"].ToString().Equals("EN"))
                            LabelMessage.Text = "Phone Number Is not ok !";

                        else
                            LabelMessage.Text = "رقم الهاتف غير قانوني !";

                        DivMessage.Visible = true;
                        PopUpFixer = 1;

                        TextBoxPphone.Text = "";

                        TextBoxPID.BorderColor = System.Drawing.Color.Transparent;
                        PopAdd.BackColor = System.Drawing.Color.Black;
                    }


                }

                else
                {
                    if (Session["Lang"].ToString().Equals("EN"))
                        LabelMessage.Text = "   There is An Empty Boxies";

                    else
                        LabelMessage.Text = "   هناك سطور فارغه !";

                    DivMessage.Visible = true;


                    TextBoxPID.BorderColor = System.Drawing.Color.Transparent;
                    PopAdd.BackColor = System.Drawing.Color.Black;
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

        protected void PopCancel_Click(object sender, EventArgs e)
        {
            
            TextBoxPname.Text = "";
            TextBoxPID.Text = "";
            TextBoxPphone.Text = "";

            TextBoxPID.BorderColor = System.Drawing.Color.Transparent;
            PopAdd.BackColor = System.Drawing.Color.Black;
            DivPop.Visible = false;            
        }

        protected void ButtonMessage_Click(object sender, EventArgs e)
        {

            if (Check == true)
            {
                DivMessage.Visible = false;

                if (PopUpFixer == 1)
                {
                    DivPop.Visible = true;
                    PopUpFixer = 0;
                }

                LabelMessage.Text = "";
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


        //============================================= Other Functions =============================================
        //============================================= Other Functions =============================================
        //============================================= Other Functions =============================================

        public void ServerRemoveImage(string ImageName)
        {
            string Directory = Server.MapPath(@"~/Images/");
            string fileName = ImageName;
            string path = @Directory + fileName;
            FileInfo fileInfo = new FileInfo(@path);


            if (fileInfo.Exists)
            {
                fileInfo.Delete();
            }

        }

        protected void ButtonFind_Click(object sender, EventArgs e)
        {
            string SID = "", GridString = "",ClassCode="",ClassName="";

            if (Check == true)
            {
                MyTable.Clear();


                //============================== if u searched student or All ==============================
                //============================== if u searched student or All ==============================
                if (Session["Switch"].Equals("All"))
                {
                    if (!TextFind.Text.Equals(""))
                    {
                        SID = TextFind.Text.ToString();
                        MyTable = MyClass.SelectStudent(SID);

                        if (MyTable.Rows.Count == 1)
                        {
                            Session["Case"] = "Student";
                            Session["Student"] = SID.ToString();
                            GetImages(-1);
                            GetClass();
                        }

                        else
                        {
                            DivMessage.Visible = true;

                            if (Session["Lang"].ToString().Equals("EN"))
                                LabelMessage.Text = "Student Not Found";

                            else
                                LabelMessage.Text = "لم يتم العثور على الطالب !";

                        }
                    }

                    else
                    {
                        Session["Case"] = "All";
                        DivMessage.Visible = true;

                        if (Session["Lang"].ToString().Equals("EN"))
                            LabelMessage.Text = "   Search Box Is Empty";

                        else
                            LabelMessage.Text = "   سطر البحث فارغ !";

                    }
                }

                //============================== if u searched Class ==============================
                //============================== if u searched Class ==============================
                else
                {
                    if (!TextFind.Text.Equals(""))
                    {
                        //========================== Save The Case ==========================//
                        ClassName = TextFind.Text.ToString();

                        //============================ Change Lang ============================
                        //============================ Change Lang ============================
                        if (!Session["Lang"].ToString().Equals("EN"))
                        {
                            string ARClassName = "";
                            char LastChar;


                            LastChar = ClassName[ClassName.Length - 1];

                            ClassName = ClassName.Remove(ClassName.Length - 1);

                            if (ClassName.Equals("البستان "))
                                ARClassName = "KIDS";

                            else if (ClassName.Equals("الاول "))
                                ARClassName = "One";

                            else if (ClassName.Equals("الثاني "))
                                ARClassName = "Two";

                            else if (ClassName.Equals("الثالث "))
                                ARClassName = "Three";

                            else if (ClassName.Equals("الرابع "))
                                ARClassName = "four";

                            else if (ClassName.Equals("الخامس "))
                                ARClassName = "five";

                            else if (ClassName.Equals("السادس "))
                                ARClassName = "six";

                            else if (ClassName.Equals("السابع "))
                                ARClassName = "seven";

                            else if (ClassName.Equals("الثامن "))
                                ARClassName = "eight";

                            else if (ClassName.Equals("التاسع "))
                                ARClassName = "nine";




                            if (LastChar == 'ا')
                                LastChar = 'A';

                            else if (LastChar == 'ب')
                                LastChar = 'B';

                            else if (LastChar == 'ت')
                                LastChar = 'C';

                            else if (LastChar == 'ث')
                                LastChar = 'D';

                            else if (LastChar == 'ج')
                                LastChar = 'E';

                            else if (LastChar == 'ح')
                                LastChar = 'F';

                            else if (LastChar == 'خ')
                                LastChar = 'G';

                            else if (LastChar == 'د')
                                LastChar = 'H';

                            else if (LastChar == 'ذ')
                                LastChar = 'I';


                            ARClassName += " ";
                            ARClassName += LastChar;

                            ClassName = ARClassName;
                        }

                        MyTable = MyClass.SelectClassByName(ClassName);


                        if ((MyTable.Rows.Count) >= 1)
                        {

                            ClassCode = MyTable.Rows[0][1].ToString();

                            MyTable = MyClass.SelectStudentsByClassCode2(int.Parse(ClassCode.ToString()));


                            if (MyTable.Rows.Count >= 1)
                            {
                                Session["Case"] = "Class";
                                Session["Class"] = ClassCode.ToString();
                                GetImages(-1);
                                GetClass();
                                DivMessage.Visible = true;

                                if (Session["Lang"].ToString().Equals("EN"))
                                    LabelMessage.Text = " Class " + TextFind.Text.ToString() + " Found ";

                                else
                                    LabelMessage.Text = " تم العثور على  " + TextFind.Text.ToString();

                            }

                            else
                            {
                                DivMessage.Visible = true;

                                if (Session["Lang"].ToString().Equals("EN"))
                                    LabelMessage.Text = "There Is No Students For This Class !";

                                else
                                    LabelMessage.Text = "لا يوجد تلاميذ في الصف !";
                            }
                        }

                        else
                        {
                            DivMessage.Visible = true;

                            if (Session["Lang"].ToString().Equals("EN"))
                                LabelMessage.Text = "Class Not Found Or Incorrect";

                            else
                                LabelMessage.Text = "لم يتم العثور على الصف !";
                        }

                    }

                    else
                    {
                        Session["Case"] = "All";
                        DivMessage.Visible = true;

                        if (Session["Lang"].ToString().Equals("EN"))
                            LabelMessage.Text = "   Search Box Is Empty";

                        else
                            LabelMessage.Text = "   سطر البحث فارغ !";

                        GetImages(-1);
                        GetClass();
                    }
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

        protected void ChangeFind_Click(object sender, EventArgs e)
        {
            
            if(Session["Switch"].Equals("0"))
            {
                //============================ Change Lang ============================
                if (Session["Lang"].ToString().Equals("EN"))               
                    TextFind.Attributes.Add("placeholder", "Enter Student ID");
                else
                    TextFind.Attributes.Add("placeholder", "  رقم هويه الطالب  ");

                TextFind.Attributes.Add("Type", "number");
                ButtonFind.BorderColor = System.Drawing.Color.Green;
                TextFind.Text = "";
                Session["Switch"] = "All";
            }

            else
            {
                //============================ Change Lang ============================
                if (Session["Lang"].ToString().Equals("EN"))
                    TextFind.Attributes.Add("placeholder", "Enter Class Name");
                else
                    TextFind.Attributes.Add("placeholder", "  ادخل اسم الصف  ");

                TextFind.Attributes.Add("Type", "SingleLine");
                ButtonFind.BorderColor = System.Drawing.ColorTranslator.FromHtml("#f6be00");
                TextFind.Text = "";
                Session["Switch"] = "0";
            }
            
        }

        protected void Accept_Click(object sender, EventArgs e)
        {

            string ImageName = "",PID="", Result="";

            if (Check == true)
            {
                //======================================================================================== Remove Data =================
                //======================================================================================== Remove Data =================
                MyTable = MyClass.SelectStudent(Session["SID"].ToString());
                PID = MyTable.Rows[0][2].ToString();
                ImageName = MyClass.FindImageBySID(Session["SID"].ToString()).ToString();

                MyTable2 = MyClass.SelectSchoolRank(Session["SCODE"].ToString());

                Result = MyTable2.Rows[0][0].ToString();

                if (!Result.Equals("1"))
                    MyClass.RemoveMarkBySID(Session["SID"].ToString());


                MyClass.RemoveImage(Session["SID"].ToString());
                MyClass.RemoveImagesAndroid(Session["SID"].ToString());
                MyClass.RemoveMessages(Session["SID"].ToString());
                MyClass.RemovePresences(Session["SID"].ToString());
                MyClass.RemoveStudent(Session["SID"].ToString());
                ServerRemoveImage(ImageName);

                MyTable = MyClass.SelectParentsCountBySID(PID);

                if (MyTable.Rows.Count == 0)
                {
                    MyClass.RemoveParent(PID);
                    //MyClass.RemoveParentFromPDB(PID);
                }


                LabelAccept.Text = "";
                PopUpAccept.Visible = false;

                DivMessage.Visible = true;

                if (Session["Lang"].ToString().Equals("EN"))
                    LabelMessage.Text = "Student   " + Session["SID"].ToString() + "   Removed  With Other Data !";

                else
                    LabelMessage.Text = "تم حذف الطالب مع جميع البيانات التابعه له !" + Session["SID"].ToString();

                GetImages(-1);
                GetClass();
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

        protected void Cancel_Click(object sender, EventArgs e)
        {

            LabelAccept.Text = "";
            PopUpAccept.Visible = false;

        }

        //============================================= Refresh Button
        protected void ImageButton1_Click(object sender, ImageClickEventArgs e)
        {
            TextFind.Attributes.Add("Type", "number");
            Session["Switch"] = "All";
            Session["Case"] = "All";
            TextFind.Text = "";
            Grid1.EditIndex = -1;
            GetImages(-1);
            GetClass();
        }

        protected void DivSTDExit_Click(object sender, EventArgs e)
        {
            FooterName.Text = "";
            FooterSID.Text = "";
            FooterPID.Text = "";
            FooterPhone2.Text = "";
            FooterPlace.Text = "";
            DivProfilePic.ImageUrl = "~/Images/studentpic2.png";
            Session["ProfilePicToAdd"] = "";
            FooterClassCode.SelectedItem.Selected = false;
            UnlockGif.Visible = false;
            FooterLabelSID.Visible = false;
            FooterSID.Visible = true;
            DIVSTDProfile.Visible = false;
        }

        protected void ADD_Click(object sender, EventArgs e)
        {
            FooterName.Text = "";
            FooterSID.Text = "";
            FooterPID.Text = "";
            FooterPhone2.Text = "";
            FooterPlace.Text = "";
            if (Session["Lang"].ToString().Equals("EN"))
                DivSTDADD.Text = "Add";
            else
                DivSTDADD.Text = "اضف";
            DivProfilePic.ImageUrl = "~/Images/studentpic2.png";
            Session["ProfilePicToAdd"] = "";
            UnlockGif.Visible = false;
            FooterLabelSID.Visible = false;
            FooterSID.Visible = true;
            DIVSTDProfile.Visible = true;
            ShowSTDMarks.Visible = false;
        }

        protected void DivSTDADD_Click(object sender, EventArgs e)
        {
            string Name = "", SID = "", PID = "", Phone = "", Adress = "", BDate = "", Result, C = "";
            int ClassCode;
            int IDResult;

            if (Check == true)
            {
                FooterPID.BorderColor = System.Drawing.ColorTranslator.FromHtml("#FF9900");
                FooterSID.BorderColor = System.Drawing.ColorTranslator.FromHtml("#FF9900");
                CheckTabel = new DataTable();

                Name = FooterName.Text.ToString();
                if (DivSTDADD.Text.Equals("ADD") || DivSTDADD.Text.Equals("اضف"))
                {
                    SID = FooterSID.Text.ToString();
                    Session["Case2"] = "0";
                }
                    
                else
                {
                    SID = FooterLabelSID.Text.ToString();
                    Session["Case2"] = "2";
                }
                    
                PID = FooterPID.Text.ToString();

                if (!FooterPhone2.Text.ToString().Equals(""))
                    Phone = FooterPhoneDrop2.SelectedItem.Text.ToString() + FooterPhone2.Text.ToString();

                Adress = FooterPlace.Text.ToString();
                BDate = FooterBDate.Text.ToString();
                C = FooterClassCode.SelectedValue.ToString();
                LabelMessage.Text = C;

                IDResult = int.Parse(MyClass.IDChecker(SID).ToString());

                if (Name != "" && SID != "" && PID != "" && C != "" && Phone != "" && Adress != "" && BDate != "")
                {
                    if (Phone.Length == 10)
                    {
                        if (IDResult == 1)
                        {
                            MyTable = new DataTable();

                            if (DivSTDADD.Text.Equals("ADD") || DivSTDADD.Text.Equals("اضف"))
                                MyTable = MyClass.SelectStudent(SID);              

                            if (MyTable.Rows.Count == 0)
                            {
                                if (!SID.Equals(PID))
                                {
                                    IDResult = int.Parse(MyClass.IDChecker(PID).ToString());

                                    if (IDResult == 1)
                                    {
                                        //////////////////// Checking if Parent Exists
                                        MyTable = MyClass.SelectParent(PID);

                                        //////////////////// if parent not exists
                                        if (MyTable.Rows.Count == 0)
                                        {
                                           
                                            DivPop.Visible = true;
                                            DIVSTDProfile.Visible = false;
                                            TextBoxPID.Text = PID.ToString();

                                            Session["ClassCode"] = C.ToString();
                                            Session["StudentID"] = SID.ToString();
                                            Session["StudentName"] = Name.ToString();
                                            Session["ParentsID"] = PID.ToString();
                                            Session["Adress"] = Adress.ToString();
                                            Session["Phone"] = Phone.ToString();
                                            Session["BDate"] = BDate.ToString();

                                            if (Session["Lang"].ToString().Equals("AR"))
                                            {
                                                TextBoxPphone.Attributes.Add("placeholder", "رقم الهاتف");
                                                PopAdd.Text = "اضف";
                                                PopCancel.Text = "الغاء";
                                            }
                                        }

                                        //////////////////// if parent exists
                                        else
                                        {
                                            ////////////////////////// ADD STUDENT //////////////////////////
                                            ////////////////////////// ADD STUDENT //////////////////////////

                                            if (DivSTDADD.Text.Equals("ADD") || DivSTDADD.Text.Equals("اضف"))
                                            {
                                                ClassCode = int.Parse(C.ToString());
                                                Result = MyClass.AddStudent(Name, SID, PID, ClassCode, Phone, Adress, BDate);
                                                AddImge(SID);
                                                FooterName.Text = "";
                                                FooterSID.Text = "";
                                                FooterPID.Text = "";
                                                FooterPhone2.Text = "";
                                                FooterPlace.Text = "";
                                                DivSTDADD.Text = "Add";
                                                DivProfilePic.ImageUrl = "~/Images/studentpic2.png";
                                                UnlockGif.Visible = false;
                                                FooterLabelSID.Visible = false;
                                                FooterSID.Visible = true;
                                                DIVSTDProfile.Visible = false;
                                                DivMessage.Visible = true;

                                                if (Session["Lang"].ToString().Equals("EN"))
                                                    LabelMessage.Text = "   " + Result;

                                                else
                                                    LabelMessage.Text = "تم تحديث معلومات الطالب";

                                                DivPop.Visible = false;
                                                Session["ProfilePicToAdd"] = "";

                                                FooterPID.BorderColor = System.Drawing.ColorTranslator.FromHtml("#FF9900");
                                                FooterSID.BorderColor = System.Drawing.ColorTranslator.FromHtml("#FF9900");
                                            }

                                            else
                                            {
                                                ClassCode = int.Parse(C.ToString());
                                                Result = MyClass.UpdateAllStudentInfo(Name, SID, PID, ClassCode, Phone, Adress, BDate);
                                                AddImge(SID);
                                              
                                                FooterName.Text = "";
                                                FooterSID.Text = "";
                                                FooterPID.Text = "";
                                                FooterPhone2.Text = "";
                                                FooterPlace.Text = "";
                                                DivSTDADD.Text = "Add";
                                                DivProfilePic.ImageUrl = "~/Images/studentpic2.png";
                                                UnlockGif.Visible = false;
                                                FooterLabelSID.Visible = false;
                                                FooterSID.Visible = true;
                                                DIVSTDProfile.Visible = false;
                                                DivMessage.Visible = true;

                                                if (Session["Lang"].ToString().Equals("EN"))
                                                    LabelMessage.Text = "   " + Result;

                                                else
                                                    LabelMessage.Text = "تم تحديث معلومات الطالب";

                                                DivPop.Visible = false;
                                                Session["ProfilePicToAdd"] = "";

                                                FooterPID.BorderColor = System.Drawing.ColorTranslator.FromHtml("#FF9900");
                                                FooterSID.BorderColor = System.Drawing.ColorTranslator.FromHtml("#FF9900");
                                            }

                                            GetImages(-1);
                                            GetClass();
                                            FooterClassCode.SelectedItem.Selected = false;
                                            Session["Case"] = "All";
                                        }
                                    }

                                    else
                                    {
                                        DivMessage.Visible = true;

                                        if (Session["Lang"].ToString().Equals("EN"))
                                            LabelMessage.Text = "Parents ID IS illegal";

                                        else
                                            LabelMessage.Text = "رقم هويه الاب غير قانوني !";

                                        FooterPID.Text = "";
                                        FooterPID.BorderColor = System.Drawing.Color.Red;
                                        CheckTabel.Clear();
                                    }
                                }

                                else
                                {
                                    DivMessage.Visible = true;

                                    if (Session["Lang"].ToString().Equals("EN"))
                                        LabelMessage.Text = "Student ID And Parent ID Cannot Be the same !";

                                    else
                                        LabelMessage.Text = "لا يمكن ان يكون رقم هويه الاب و الطالب متماثلين !";

                                    FooterPID.Text = "";
                                    FooterSID.Text = "";
                                    FooterPID.BorderColor = System.Drawing.Color.Red;
                                    FooterSID.BorderColor = System.Drawing.Color.Red;
                                    CheckTabel.Clear();
                                }

                            }

                            else
                            {
                                DivMessage.Visible = true;

                                if (Session["Lang"].ToString().Equals("EN"))
                                    LabelMessage.Text = "Student Allready Added !";

                                else
                                    LabelMessage.Text = "هذا الطالب قد تمه اضافته من قبل !";

                                FooterSID.Text = "";
                                FooterSID.BorderColor = System.Drawing.Color.Red;
                                CheckTabel.Clear();
                            }


                        }


                        else
                        {
                            DivMessage.Visible = true;

                            if (Session["Lang"].ToString().Equals("EN"))
                                LabelMessage.Text = "Student ID IS illegal";

                            else
                                LabelMessage.Text = "رقم هويه الطالب غير قانوني !";

                            FooterSID.Text = "";
                            FooterSID.BorderColor = System.Drawing.Color.Red;
                            CheckTabel.Clear();
                        }
                    }

                    else
                    {
                        DivMessage.Visible = true;

                        if (Session["Lang"].ToString().Equals("EN"))
                            LabelMessage.Text = "Phone Number Must Be 10 digits";

                        else
                            LabelMessage.Text = "يجب أن يكون رقم الهاتف من 10 أرقام";
                    }
                }


                else
                {
                    DivMessage.Visible = true;

                    if (Session["Lang"].ToString().Equals("EN"))
                        LabelMessage.Text = "   There is An Empty Boxies";

                    else
                        LabelMessage.Text = "    هناك سطور فارغه !";

                    FooterSID.BorderColor = System.Drawing.ColorTranslator.FromHtml("#808080");
                    FooterPID.BorderColor = System.Drawing.ColorTranslator.FromHtml("#808080");
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

        protected void FileUpload2Button_Click(object sender, EventArgs e)
        {
            string folderPath = Server.MapPath("~/Images/");

            string strname = FileUpload2.FileName.ToString();

            int len = strname.Length;
            string ImageTybe = "", ImageTybe2 = "";


            if (FileUpload2.HasFile)
            {
                //================================ Get Image Type ================================
                //================================ Get Image Type ================================
                while (strname[len - 1] != '.')
                {
                    ImageTybe += strname[len - 1];
                    len--;
                }

                len = ImageTybe.Length;

                while (len > 0)
                {
                    ImageTybe2 += ImageTybe[len - 1];
                    len--;
                }


                //================================ Check Image Type ================================
                //================================ Check Image Type ================================
                if (ImageTybe2.Equals("jpg") || ImageTybe2.Equals("png"))
                {
                    if (FileUpload2.HasFile)
                    {
                        FileUpload2.SaveAs(folderPath + Path.GetFileName(FileUpload2.FileName));

                        DivProfilePic.ImageUrl = "~/Images/" + strname;

                        Session["ProfilePicToAdd"] = FileUpload2.FileName.ToString();
                    }

                    else
                    {
                        if (Session["Lang"].ToString().Equals("EN"))
                            LabelMessage.Text = "Select Image Please !";

                        else
                            LabelMessage.Text = "اختر صوره !";

                        DivMessage.Visible = true;
                    }
                }

                else
                {
                    if (Session["Lang"].ToString().Equals("EN"))
                        LabelMessage.Text = "Select Image Please Jpg or Png only!";

                    else
                        LabelMessage.Text = "حدد صورة من فضلك Jpg أو Png فقط!";

                    DivMessage.Visible = true;
                }
            }

            else
            {
                if (Session["Lang"].ToString().Equals("EN"))
                    LabelMessage.Text = "Select Image Please !";

                else
                    LabelMessage.Text = "اختر صوره !";

                DivMessage.Visible = true;
            }
        }

        protected void GridMarks_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName.ToString().Equals("Print"))
            {
                int rowclicked = int.Parse(e.CommandArgument.ToString());
                int ClassCode;
                string SID;


                Label CCode = (Label)GridMarks.Rows[rowclicked + 1].FindControl("ClassPrint");
                ClassCode = int.Parse(CCode.Text.ToString());

                /////////////////////// fill abov info.. 
                if (Session["Lang"].ToString().Equals("EN"))
                {
                    PrintLabelSchool.Text = "School :" + MyClass.SelectSchoolByCode(Session["SCODE"].ToString()).Rows[0][3].ToString();
                    PrintLabelSTDName.Text = "Student Name :" + MyClass.SelectStudent(FooterLabelSID.Text.ToString()).Rows[0][0].ToString();
                    PrintLabelSID.Text = "ID :" + FooterLabelSID.Text.ToString();
                    PrintLabelCName.Text = "Class :" + MyClass.SelectClass(ClassCode).Rows[0][0].ToString();
                }

                else
                {
                    PrintLabelSchool.Text = "المدرسة :" + MyClass.SelectSchoolByCode(Session["SCODE"].ToString()).Rows[0][3].ToString();
                    PrintLabelSTDName.Text = "اسم الطالب :" + MyClass.SelectStudent(FooterLabelSID.Text.ToString()).Rows[0][0].ToString();
                    PrintLabelSID.Text = "رقم الهويه :" + FooterLabelSID.Text.ToString();
                    PrintLabelCName.Text = "الصف :" + ConvertClassToArabic(MyClass.SelectClass(ClassCode).Rows[0][0].ToString());
                }

                DataTable DTMarksFinal = new DataTable();
                DTMarksFinal.Columns.Add(new DataColumn("Chapter", typeof(string)));
                DTMarksFinal.Columns.Add(new DataColumn("Subject", typeof(string)));
                DTMarksFinal.Columns.Add(new DataColumn("Mark", typeof(string)));
                DTMarksFinal.Columns.Add(new DataColumn("SubCount", typeof(string)));
                DTMarksFinal.Columns.Add(new DataColumn("Pass", typeof(string)));

                SID = FooterLabelSID.Text.ToString();

                DataTable DTMarks = MyClass.SelectMarksByClassAndSID(SID, ClassCode);
                DataTable DTSubjects = MyClass.ShowSubjects();

                List<string> ListOFChapters = new List<string>();

                for (int i = 0; i < DTMarks.Rows.Count; i++)
                {
                    if (!ListOFChapters.Contains(DTMarks.Rows[i][4].ToString()))
                        ListOFChapters.Add(DTMarks.Rows[i][4].ToString());
                }

                float AVG = 0;
                int AVGCount = 0;
                DataRow Row;
                int IFRowAdded = 0;
                int ChapterExist = 0;


                for (int i2 = 1; i2 <= 3; i2++)
                {
                    for (int i3 = 0; i3 < DTSubjects.Rows.Count; i3++)
                    {
                        for (int i4 = 0; i4 < DTMarks.Rows.Count; i4++)
                        {
                            if (DTMarks.Rows[i4][4].ToString().Equals(i2.ToString()) && DTMarks.Rows[i4][1].ToString().Equals(DTSubjects.Rows[i3][1].ToString()))
                            {
                                ChapterExist = 1;
                                ///////////////// check if row added in final tabel
                                for (int cnti = 0; cnti < DTMarksFinal.Rows.Count; cnti++)
                                {
                                    //////////////////// Convert Chapters
                                    string Chapter = "";
                                    if (DTMarks.Rows[i4][4].ToString().Equals("1"))
                                    {
                                        if (Session["Lang"].ToString().Equals("EN"))
                                            Chapter = "Chapter 1";
                                        else
                                            Chapter = "الفصل 1";
                                    }

                                    else if (DTMarks.Rows[i4][4].ToString().Equals("2"))
                                    {
                                        if (Session["Lang"].ToString().Equals("EN"))
                                            Chapter = "Chapter 2";
                                        else
                                            Chapter = "الفصل 2";
                                    }

                                    else if (DTMarks.Rows[i4][4].ToString().Equals("3"))
                                    {
                                        if (Session["Lang"].ToString().Equals("EN"))
                                            Chapter = "Chapter 3";
                                        else
                                            Chapter = "الفصل 3";
                                    }

                                    //////////////////// Convert Subjects
                                    string SubName = MyClass.SelectSubject(DTMarks.Rows[i4][1].ToString()).Rows[0][0].ToString();


                                    if (DTMarksFinal.Rows[cnti][0].ToString().Equals(Chapter) && DTMarksFinal.Rows[cnti][1].ToString().Equals(SubName))
                                    {
                                        IFRowAdded = 1;
                                        float MarkSum = float.Parse(DTMarksFinal.Rows[cnti][2].ToString());
                                        float MarkCurrent = (100 / int.Parse(DTMarks.Rows[i4][6].ToString())) * int.Parse(DTMarks.Rows[i4][2].ToString());
                                        MarkSum += MarkCurrent;
                                        DTMarksFinal.Rows[cnti][2] = MarkSum.ToString();
                                        DTMarksFinal.Rows[cnti][3] = (int.Parse(DTMarksFinal.Rows[cnti][3].ToString()) + 1).ToString();
                                    }
                                }

                                //////////////////// Add Row if not Exists
                                if (IFRowAdded == 0)
                                {
                                    Row = DTMarksFinal.NewRow();
                                    //////////////////// Convert Chapters
                                    if (DTMarks.Rows[i4][4].ToString().Equals("1"))
                                    {
                                        if (Session["Lang"].ToString().Equals("EN"))
                                            Row["Chapter"] = "Chapter 1";
                                        else
                                            Row["Chapter"] = "الفصل 1";
                                    }

                                    else if (DTMarks.Rows[i4][4].ToString().Equals("2"))
                                    {
                                        if (Session["Lang"].ToString().Equals("EN"))
                                            Row["Chapter"] = "Chapter 2";
                                        else
                                            Row["Chapter"] = "الفصل 2";
                                    }

                                    else if (DTMarks.Rows[i4][4].ToString().Equals("3"))
                                    {
                                        if (Session["Lang"].ToString().Equals("EN"))
                                            Row["Chapter"] = "Chapter 3";
                                        else
                                            Row["Chapter"] = "الفصل 3";
                                    }

                                    //////////////////// Convert Subjects
                                    string SubName = MyClass.SelectSubject(DTMarks.Rows[i4][1].ToString()).Rows[0][0].ToString();
                                    Row["Subject"] = SubName.ToString();

                                    //////////////////// Convert Marks
                                    int TM= (100 / int.Parse(DTMarks.Rows[i4][6].ToString())) * int.Parse(DTMarks.Rows[i4][2].ToString());
                                    if (DTMarks.Rows[i4][6].ToString().Equals(DTMarks.Rows[i4][2].ToString()))
                                        Row["Mark"] = 100;
                                    else
                                        Row["Mark"] = TM;

                                    

                                    Row["SubCount"] = 1;
                                    Row["Pass"] = "•";
                                    DTMarksFinal.Rows.Add(Row);
                                }
                                IFRowAdded = 0;
                            }
                        }
                    }

                    /////////////// Add Line Row Betwen every Chapter
                    if (ChapterExist == 1)
                    {
                        Row = DTMarksFinal.NewRow();
                        Row["Chapter"] = i2.ToString();
                        Row["Subject"] = "•";
                        Row["Mark"] = "•";
                        Row["SubCount"] = "•";
                        Row["Pass"] = "•";
                        DTMarksFinal.Rows.Add(Row);

                        Row = DTMarksFinal.NewRow();
                        Row["Chapter"] = "🔵";
                        Row["Subject"] = "🔵";
                        Row["Mark"] = "🔵";
                        Row["SubCount"] = "🔵";
                        Row["Pass"] = "🔵";
                        DTMarksFinal.Rows.Add(Row);
                    }

                    ChapterExist = 0;
                }

                /////////////////// Caulating AVG for Every Chapter
                float FinalYearAVG = 0, ChapAVG = 0;
                int FinalCount = 0, ChapCount = 0;
                string ChapterNow = "";

                for (int ichap = 1; ichap <= 3; ichap++)
                {
                    //////////////////// Convert Chapters
                    if (ichap.ToString().Equals("1"))
                    {
                        if (Session["Lang"].ToString().Equals("EN"))
                            ChapterNow = "Chapter 1";
                        else
                            ChapterNow = "الفصل 1";
                    }

                    else if (ichap.ToString().Equals("2"))
                    {
                        if (Session["Lang"].ToString().Equals("EN"))
                            ChapterNow = "Chapter 2";
                        else
                            ChapterNow = "الفصل 2";
                    }

                    else if (ichap.ToString().Equals("3"))
                    {
                        if (Session["Lang"].ToString().Equals("EN"))
                            ChapterNow = "Chapter 3";
                        else
                            ChapterNow = "الفصل 3";
                    }

                    for (int g1 = 0; g1 < DTMarksFinal.Rows.Count; g1++)
                    {
                        //////////////////////////// Caulating Subjects Avg
                        if (!DTMarksFinal.Rows[g1][2].ToString().Equals("•") && !DTMarksFinal.Rows[g1][2].ToString().Equals("🔵"))
                        {
                            if (DTMarksFinal.Rows[g1][0].ToString().Equals(ChapterNow))
                            {
                                int SubAvg = int.Parse(DTMarksFinal.Rows[g1][2].ToString()) / int.Parse(DTMarksFinal.Rows[g1][3].ToString());
                                DTMarksFinal.Rows[g1][2] = SubAvg.ToString();

                                if (SubAvg == 100)
                                    DTMarksFinal.Rows[g1][4] = "⭐";
                                else if (SubAvg >= 55)
                                    DTMarksFinal.Rows[g1][4] = "✔️";
                                else
                                    DTMarksFinal.Rows[g1][4] = "❌";

                                /////////////////// Caulating Avg for Chapter
                                ChapAVG += SubAvg;
                                ChapCount++;
                            }
                        }
                    }

                    //////////////////////////// Adding avg to every chapter
                    if (ChapCount != 0)
                    {
                        for (int g2 = 0; g2 < DTMarksFinal.Rows.Count; g2++)
                        {
                            if (DTMarksFinal.Rows[g2][0].ToString().Equals(ichap.ToString()))
                            {
                                if (Session["Lang"].ToString().Equals("EN"))
                                    DTMarksFinal.Rows[g2][0] = "Chapter AVG : " + float.Parse((ChapAVG / ChapCount).ToString("#.#"));

                                else
                                    DTMarksFinal.Rows[g2][0] = "معدل الفصل " + ichap + " : " + float.Parse((ChapAVG / ChapCount).ToString("#.#"));

                                /////////////////// Caulating Avg for Yearly
                                FinalYearAVG += float.Parse((ChapAVG / ChapCount).ToString("#.#"));
                                FinalCount++;

                                ChapAVG = 0;
                                ChapCount = 0;
                            }
                        }
                    }
                }


                ////////////////// checking avg if pass or not
                if ((FinalYearAVG / FinalCount) == 100)
                    PrintLabelAVG.Text = "⭐";
                else if ((FinalYearAVG / FinalCount) >= 55)
                    PrintLabelAVG.Text = "✔️";
                else
                    PrintLabelAVG.Text = "❌";

                if (Session["Lang"].ToString().Equals("EN"))
                {
                    PrintLabelAVG.Text += "Yearly AVG :" + (FinalYearAVG / FinalCount).ToString("#.#");
                    GridPrintMarks.Columns[0].HeaderText = "AVG Subject";
                    GridPrintMarks.Columns[1].HeaderText = "Subject";
                    GridPrintMarks.Columns[2].HeaderText = "Chapter";
                }

                else
                {
                    PrintLabelAVG.Text += "المعدل السنوي :" + (FinalYearAVG / FinalCount).ToString("#.#");
                    GridPrintMarks.Columns[0].HeaderText = "النجاح";
                    GridPrintMarks.Columns[1].HeaderText = "العلامه";
                    GridPrintMarks.Columns[2].HeaderText = "الموضوع";
                    GridPrintMarks.Columns[3].HeaderText = "الفصل";
                }


                GridPrintMarks.DataSource = DTMarksFinal;
                GridPrintMarks.DataBind();

                //////////////////////////// Changing Row Color Bettwen Chapters
                for (int j = 0; j < GridPrintMarks.Rows.Count; j++)
                {
                    Label titel = (Label)GridPrintMarks.Rows[j].FindControl("PrintSubject");
                    string logo = titel.Text.ToString();

                    if (logo.ToString().Equals("🔵"))
                    {
                        DataControlFieldCell TitelCell = (DataControlFieldCell)GridPrintMarks.Rows[j].Cells[0];
                        TitelCell.BackColor = System.Drawing.ColorTranslator.FromHtml("#1F618D");

                        TitelCell = (DataControlFieldCell)GridPrintMarks.Rows[j].Cells[1];
                        TitelCell.BackColor = System.Drawing.ColorTranslator.FromHtml("#1F618D");

                        TitelCell = (DataControlFieldCell)GridPrintMarks.Rows[j].Cells[2];
                        TitelCell.BackColor = System.Drawing.ColorTranslator.FromHtml("#1F618D");

                        TitelCell = (DataControlFieldCell)GridPrintMarks.Rows[j].Cells[3];
                        TitelCell.BackColor = System.Drawing.ColorTranslator.FromHtml("#1F618D");

                        titel.Text = " ";

                        titel = (Label)GridPrintMarks.Rows[j].FindControl("PrintPass");
                        titel.Text = " ";

                        titel = (Label)GridPrintMarks.Rows[j].FindControl("PrintMark");
                        titel.Text = " ";

                        titel = (Label)GridPrintMarks.Rows[j].FindControl("PrintChapter");
                        titel.Text = " ";
                    }
                }
            }
        }

        protected void PrintMarks_Click(object sender, ImageClickEventArgs e)
        {
            PrintMarksPage.Attributes.Add("onclick", "window.print();");
            DivPrint.Visible = true;
        }

        protected void ShowSTDMarks_Click(object sender, EventArgs e)
        {
            DataTable DTMarks = new DataTable();
            DataTable DTMarksFinal = new DataTable();
            DataTable DTSubjects = new DataTable();
            List<string> ListClasses = new List<string>();

            DTMarks = MyClass.SelectMarkBySID2(FooterLabelSID.Text.ToString());
            DTMarksFinal.Columns.Add(new DataColumn("SubName", typeof(string)));
            DTMarksFinal.Columns.Add(new DataColumn("Mark", typeof(string)));
            DTMarksFinal.Columns.Add(new DataColumn("Chapter", typeof(string)));
            DTMarksFinal.Columns.Add(new DataColumn("Class", typeof(string)));
            DTMarksFinal.Columns.Add(new DataColumn("CCode", typeof(string)));
            DTMarksFinal.Columns.Add(new DataColumn("Kind", typeof(string)));

            ///////////////////////// Getting Student ClassCode and Getting Subjects That Student learn
            DTSubjects = MyClass.ShowSubjects();

            float AVG=0;
            int AVGCount = 0;

            for(int checker=0;checker<DTMarks.Rows.Count;checker++)
            {
                if (!ListClasses.Contains(DTMarks.Rows[checker][3].ToString()))
                    ListClasses.Add(DTMarks.Rows[checker][3].ToString());
            }

            ///////////////////////// Fill The Row and add to the datatabel
            for (int ii2 = 0; ii2 < ListClasses.Count; ii2++)
            {
                ///////////////////////// set titel for every class marks
                DataRow RowNewClass = DTMarksFinal.NewRow();

                ///////////////////////// Getting ClassName
                string ClassMarktitel = MyClass.SelectClass(int.Parse(ListClasses[ii2].ToString())).Rows[0][0].ToString();

                if (Session["Lang"].ToString().Equals("EN"))
                    RowNewClass["Mark"] = "•   💠" + ClassMarktitel;
                else
                    RowNewClass["Mark"] = "•   💠" + ConvertClassToArabic(ClassMarktitel);

                DTMarksFinal.Rows.Add(RowNewClass);

                ///////////////////////// For Chapters
                for (int chapcnt = 1; chapcnt <= 3; chapcnt++)
                {
                    ///////////////////////// For on Subjects Tabel
                    for (int fi = 0; fi < DTSubjects.Rows.Count; fi++)
                    {
                        ///////////////////////// For on All Marks Tabel
                        for (int i = 0; i < DTMarks.Rows.Count; i++)
                        {
                            ///////////////////////// Getting Marks for every subject alone AND every Class
                            if ((DTMarks.Rows[i][1].ToString().Equals(DTSubjects.Rows[fi][1].ToString())) && (DTMarks.Rows[i][3].ToString().Equals(ListClasses[ii2].ToString())) && (DTMarks.Rows[i][4].ToString().Equals(chapcnt.ToString())))
                            {
                                DataRow Row = DTMarksFinal.NewRow();
                                string SubName = MyClass.SelectSubject(DTMarks.Rows[i][1].ToString()).Rows[0][0].ToString();
                                string Chapter = "";

                                if (DTMarks.Rows[i][4].ToString().Equals("1"))
                                {
                                    if (Session["Lang"].ToString().Equals("EN"))
                                        Chapter = "Chapter 1";
                                    else
                                        Chapter = "الفصل 1";
                                }

                                else if (DTMarks.Rows[i][4].ToString().Equals("2"))
                                {
                                    if (Session["Lang"].ToString().Equals("EN"))
                                        Chapter = "Chapter 2";
                                    else
                                        Chapter = "الفصل 2";
                                }

                                else if (DTMarks.Rows[i][4].ToString().Equals("3"))
                                {
                                    if (Session["Lang"].ToString().Equals("EN"))
                                        Chapter = "Chapter 3";
                                    else
                                        Chapter = "الفصل 3";
                                }

                                ///////////////////////// Getting ClassName for this mark
                                string ClassMark = MyClass.SelectClass(int.Parse(DTMarks.Rows[i][3].ToString())).Rows[0][0].ToString();

                                ///////////////////////// Getting ClassCode for print Use
                                Row["CCode"] = int.Parse(DTMarks.Rows[i][3].ToString());

                                ///////////////////////// Getting Kind
                                string Kind = "";

                                if (DTMarks.Rows[i][5].ToString().Equals("1"))
                                {
                                    if (!Session["Lang"].ToString().Equals("EN"))
                                        Kind = "امتحان";

                                    else
                                        Kind = "Test";
                                }

                                else if (DTMarks.Rows[i][5].ToString().Equals("2"))
                                {
                                    if (!Session["Lang"].ToString().Equals("EN"))
                                        Kind = "وظيفه";

                                    else
                                        Kind = "HomeWork";
                                }

                                else if (DTMarks.Rows[i][5].ToString().Equals("3"))
                                {
                                    if (!Session["Lang"].ToString().Equals("EN"))
                                        Kind = "بحث";

                                    else
                                        Kind = "Project";
                                }

                                ///////////////////////// Fill The Row and add to the datatabel
                                Row["SubName"] = "● " + SubName;
                                Row["Mark"] = "–       " + DTMarks.Rows[i][2].ToString() + "/" + DTMarks.Rows[i][6].ToString();

                                ///////////////////////// Caulating The Mark if pass or not
                                float Mark = float.Parse(DTMarks.Rows[i][2].ToString());
                                float Per = float.Parse(DTMarks.Rows[i][6].ToString());
                                float Res = (100 / Per) * Mark;

                                AVG += (100 / Per) * Mark;
                                AVGCount++;

                                if (Mark == Per)
                                    Row["Mark"] += "⭐";

                                else if (Res >= 55)
                                    Row["Mark"] += "✔️";

                                else
                                    Row["Mark"] += "❌";

                                Row["Chapter"] = Chapter;
                                if (!Session["Lang"].ToString().Equals("EN"))
                                    Row["Class"] = "الصف :" + ConvertClassToArabic(ClassMark);
                                else
                                    Row["Class"] = "Class :" + ClassMark;
                                Row["Kind"] = Kind;
                                DTMarksFinal.Rows.Add(Row);
                            }
                        }
                    }
                }
            }
            
            GridMarks.DataSource = DTMarksFinal;
            GridMarks.DataBind();
            DIVSTDMarks.Visible = true;

            ////////////////////////////////////////// To Change Titel Class Name Color AND Avg text Color
            for (int ig=0;ig< GridMarks.Rows.Count;ig++)
            {
                Label titel = (Label)GridMarks.Rows[ig].FindControl("Mark");
                string logo = titel.Text[0].ToString();

                Label titelavg = (Label)GridMarks.Rows[ig].FindControl("Mark");
                string logoavg = titel.Text.ToString();

                if (logo.Equals("•"))
                {
                    DataControlFieldCell TitelCell = (DataControlFieldCell)GridMarks.Rows[ig].Cells[0];
                    TitelCell.BackColor = System.Drawing.ColorTranslator.FromHtml("#1F618D");

                    TitelCell = (DataControlFieldCell)GridMarks.Rows[ig].Cells[1];
                    TitelCell.BackColor = System.Drawing.ColorTranslator.FromHtml("#1F618D");
                    TitelCell.ForeColor = System.Drawing.Color.Snow;

                    TitelCell = (DataControlFieldCell)GridMarks.Rows[ig].Cells[2];
                    TitelCell.BackColor = System.Drawing.ColorTranslator.FromHtml("#1F618D");

                    // Making Print Marks Button
                    ImageButton Print = (ImageButton)GridMarks.Rows[ig].FindControl("PrintMarks");
                    Print.Visible = true;
                }

                if(logoavg.Contains(":"))
                {
                    DataControlFieldCell TitelCell2 = (DataControlFieldCell)GridMarks.Rows[ig].Cells[1];   
                    TitelCell2.ForeColor= System.Drawing.ColorTranslator.FromHtml("#5B2C6F");
                }
            }
        }

        public void AddImge(string SID)
        {

            MyClass.AddImage(SID, Session["ProfilePicToAdd"].ToString());

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

        protected void STDMarksClose_Click(object sender, EventArgs e)
        {
            DIVSTDMarks.Visible = false;
        }

        protected void BackClick_Click(object sender, EventArgs e)
        {
            Response.Redirect("Choose.aspx");
        }

    }
}