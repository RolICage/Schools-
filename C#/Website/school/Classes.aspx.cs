using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using school.App_Code;

namespace school
{
    public partial class Classes : System.Web.UI.Page
    {
        public static DataTable MyTable, MyClassTable, CheckTabel;
        public static int x = 0;
        public static int PopUpFixer = 0;
        public string Case = "All";


        protected void Page_Load(object sender, EventArgs e)
        {
            DivMessage.Visible = false;

            if (System.Web.HttpContext.Current.Session["SCODE"] != null)
            {
                if (!IsPostBack)
                {
                    PopUpAccept.Visible = false;
                    Grid1FooterTabel.Style["background-image"] = "Gifs/ezgiffot.gif";
                    Grid1.ShowFooter = false;

                    GetClasses();
                    FillDropDowns();
                }
            }

            else
                Response.Redirect("Login Page.aspx");

        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        ////////////////////////////////////////////////////////////////////////////////////////////////////
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public void GetClasses()
        {

            MyTable = MyClass.ShowClasses();
            Button Edits;

            //============================ Change Lang ============================
            //============================ Change Lang ============================
            if (Session["Lang"].ToString().Equals("EN"))
            {
                //============================ Change Edits Lang ============================           

                for (int rowindex = 0; rowindex < Grid1.Rows.Count; rowindex++)
                {
                    Edits = ((Button)Grid1.Rows[rowindex].FindControl("Delete"));
                    Edits.Text = "Delete";
                }

                HeaderClassName.Text = "Class";
                addclassbutton.Text = "Add Class";
            }

            else
            {

                HeaderClassName.Text = "الصف";
                addclassbutton.Text = "اضف الصف";

                DataTable ARClassTabel;
                string ClassNameNow = "",ARClassName="";
                char LastChar;

                for (int rowindex = 0; rowindex < MyTable.Rows.Count; rowindex++)
                {

                    ClassNameNow = MyTable.Rows[rowindex][0].ToString();

                    LastChar = ClassNameNow[ClassNameNow.Length - 1];

                    ClassNameNow = ClassNameNow.Remove(ClassNameNow.Length - 1);




                    if (ClassNameNow.Equals("KIDS "))
                        ARClassName = "البستان";

                    else if(ClassNameNow.Equals("One "))
                        ARClassName = "الاول";

                    else if(ClassNameNow.Equals("Two "))
                        ARClassName = "الثاني";

                    else if(ClassNameNow.Equals("Three "))
                        ARClassName = "الثالث";

                    else if(ClassNameNow.Equals("four "))
                        ARClassName = "الرابع";

                    else if(ClassNameNow.Equals("five "))
                        ARClassName = "الخامس";

                    else if(ClassNameNow.Equals("six "))
                        ARClassName = "السادس";

                    else if(ClassNameNow.Equals("seven "))
                        ARClassName = "السابع";

                    else if(ClassNameNow.Equals("eight "))
                        ARClassName = "الثامن";

                    else if(ClassNameNow.Equals("nine "))
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

                    MyTable.Rows[rowindex][0] = ARClassName;
                }
            }

            Grid1.DataSource = MyTable;
            Grid1.DataBind();

            //============================ Change Edits Lang ============================

            for (int rowindex = 0; rowindex < Grid1.Rows.Count; rowindex++)
            {
                Edits = ((Button)Grid1.Rows[rowindex].FindControl("Delete"));
                Edits.Text = "حذف";
            }
        }

        public void FillDropDowns()
        {
            string Result = "";

            MyTable = MyClass.SelectSchoolRank(Session["SCODE"].ToString());

            Result = MyTable.Rows[0][0].ToString();

            if (Result.Equals("1"))
            {
                //============================ Change Lang ============================
                //============================ Change Lang ============================
                if (Session["Lang"].ToString().Equals("EN"))
                {
                    DropDownClasses.Items.Add(new ListItem("KIDS", "0"));

                    DropDownClassID.Items.Add(new ListItem("C", "-3"));
                    DropDownClassID.Items.Add(new ListItem("D", "-4"));
                    DropDownClassID.Items.Add(new ListItem("E", "-5"));
                    DropDownClassID.Items.Add(new ListItem("F", "-6"));
                }

                else
                {
                    DropDownClasses.Items.Add(new ListItem("البستان", "0"));

                    DropDownClassID.Items.Add(new ListItem("ت", "-3"));
                    DropDownClassID.Items.Add(new ListItem("ث", "-4"));
                    DropDownClassID.Items.Add(new ListItem("ج", "-5"));
                    DropDownClassID.Items.Add(new ListItem("ح", "-6"));
                }

            }

            else if (Result.Equals("2"))
            {
                //============================ Change Lang ============================
                //============================ Change Lang ============================
                if (Session["Lang"].ToString().Equals("EN"))
                {
                    DropDownClasses.Items.Add(new ListItem("One", "1"));
                    DropDownClasses.Items.Add(new ListItem("Two", "2"));
                    DropDownClasses.Items.Add(new ListItem("Three", "3"));
                    DropDownClasses.Items.Add(new ListItem("four", "4"));
                    DropDownClasses.Items.Add(new ListItem("five", "5"));
                    DropDownClasses.Items.Add(new ListItem("six", "6"));



                    DropDownClassID.Items.Add(new ListItem("A", "1"));
                    DropDownClassID.Items.Add(new ListItem("B", "2"));
                    DropDownClassID.Items.Add(new ListItem("C", "3"));

                    DropDownClassID.Items.Add(new ListItem("D", "4"));
                    DropDownClassID.Items.Add(new ListItem("E", "5"));
                    DropDownClassID.Items.Add(new ListItem("F", "6"));

                    DropDownClassID.Items.Add(new ListItem("G", "7"));
                    DropDownClassID.Items.Add(new ListItem("H", "8"));
                    DropDownClassID.Items.Add(new ListItem("I", "9"));
                }

                else
                {
                    DropDownClasses.Items.Add(new ListItem("الاول", "1"));
                    DropDownClasses.Items.Add(new ListItem("الثاني", "2"));
                    DropDownClasses.Items.Add(new ListItem("الثالث", "3"));
                    DropDownClasses.Items.Add(new ListItem("الرابع", "4"));
                    DropDownClasses.Items.Add(new ListItem("الخامس", "5"));
                    DropDownClasses.Items.Add(new ListItem("السادس", "6"));



                    DropDownClassID.Items.Add(new ListItem("ا", "1"));
                    DropDownClassID.Items.Add(new ListItem("ب", "2"));
                    DropDownClassID.Items.Add(new ListItem("ت", "3"));

                    DropDownClassID.Items.Add(new ListItem("ث", "4"));
                    DropDownClassID.Items.Add(new ListItem("ج", "5"));
                    DropDownClassID.Items.Add(new ListItem("ح", "6"));

                    DropDownClassID.Items.Add(new ListItem("خ", "7"));
                    DropDownClassID.Items.Add(new ListItem("د", "8"));
                    DropDownClassID.Items.Add(new ListItem("ذ", "9"));
                }
            }

            else if (Result.Equals("3"))
            {
                //============================ Change Lang ============================
                //============================ Change Lang ============================
                if (Session["Lang"].ToString().Equals("EN"))
                {
                    DropDownClasses.Items.Add(new ListItem("الاول", "1"));
                    DropDownClasses.Items.Add(new ListItem("الثاني", "2"));
                    DropDownClasses.Items.Add(new ListItem("الثالث", "3"));
                    DropDownClasses.Items.Add(new ListItem("الرابع", "4"));
                    DropDownClasses.Items.Add(new ListItem("الخامس", "5"));
                    DropDownClasses.Items.Add(new ListItem("السادس", "6"));
                    DropDownClasses.Items.Add(new ListItem("السابع", "7"));
                    DropDownClasses.Items.Add(new ListItem("الثامن", "8"));
                    DropDownClasses.Items.Add(new ListItem("التاسع", "9"));

                    DropDownClassID.Items.Add(new ListItem("A", "1"));
                    DropDownClassID.Items.Add(new ListItem("B", "2"));
                    DropDownClassID.Items.Add(new ListItem("C", "3"));

                    DropDownClassID.Items.Add(new ListItem("D", "4"));
                    DropDownClassID.Items.Add(new ListItem("E", "5"));
                    DropDownClassID.Items.Add(new ListItem("F", "6"));

                    DropDownClassID.Items.Add(new ListItem("G", "7"));
                    DropDownClassID.Items.Add(new ListItem("H", "8"));
                    DropDownClassID.Items.Add(new ListItem("I", "9"));
                }

                else
                {
                    DropDownClasses.Items.Add(new ListItem("One", "1"));
                    DropDownClasses.Items.Add(new ListItem("Two", "2"));
                    DropDownClasses.Items.Add(new ListItem("Three", "3"));
                    DropDownClasses.Items.Add(new ListItem("four", "4"));
                    DropDownClasses.Items.Add(new ListItem("five", "5"));
                    DropDownClasses.Items.Add(new ListItem("six", "6"));
                    DropDownClasses.Items.Add(new ListItem("seven", "7"));
                    DropDownClasses.Items.Add(new ListItem("eight", "8"));
                    DropDownClasses.Items.Add(new ListItem("nine", "9"));

                    DropDownClassID.Items.Add(new ListItem("ا", "1"));
                    DropDownClassID.Items.Add(new ListItem("ب", "2"));
                    DropDownClassID.Items.Add(new ListItem("ت", "3"));

                    DropDownClassID.Items.Add(new ListItem("ث", "4"));
                    DropDownClassID.Items.Add(new ListItem("ج", "5"));
                    DropDownClassID.Items.Add(new ListItem("ح", "6"));

                    DropDownClassID.Items.Add(new ListItem("خ", "7"));
                    DropDownClassID.Items.Add(new ListItem("د", "8"));
                    DropDownClassID.Items.Add(new ListItem("ذ", "9"));
                }

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
            string CName = "", CCode = "";
            int Checking = 0, ClassCheck = 0;

            MyClass.CheckForInternetConnection();
            if (MyClass.NetCheck == true)
            {
                CName = (Grid1.Rows[e.RowIndex].FindControl("LabelCName") as Label).Text.ToString();

                //============================ Change Lang ============================
                //============================ Change Lang ============================
                if (!Session["Lang"].ToString().Equals("EN"))
                {
                    string ARClassName = "";
                    char LastChar;


                    LastChar = CName[CName.Length - 1];

                    CName = CName.Remove(CName.Length - 1);

                    if (CName.Equals("البستان "))
                        ARClassName = "KIDS";

                    else if (CName.Equals("الاول "))
                        ARClassName = "One";

                    else if (CName.Equals("الثاني "))
                        ARClassName = "Two";

                    else if (CName.Equals("الثالث "))
                        ARClassName = "Three";

                    else if (CName.Equals("الرابع "))
                        ARClassName = "four";

                    else if (CName.Equals("الخامس "))
                        ARClassName = "five";

                    else if (CName.Equals("السادس "))
                        ARClassName = "six";

                    else if (CName.Equals("السابع "))
                        ARClassName = "seven";

                    else if (CName.Equals("الثامن "))
                        ARClassName = "eight";

                    else if (CName.Equals("التاسع "))
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

                    CName = ARClassName;
                }


                DataTable ClassExist;
                ClassExist = MyClass.SelectClassByName(CName);

                if (ClassExist.Rows.Count > 0)
                {

                    CCode = MyClass.SelectClassByName(CName).Rows[0][1].ToString();
                    ClassCheck = int.Parse(CCode[CCode.Length - 1].ToString());


                    if (ClassCheck != 1)
                    {
                        MyTable = MyClass.SelectStudentsByClassCode(int.Parse(CCode.ToString()));
                        if (MyTable.Rows.Count > 0)
                            Checking++;
                        MyTable = MyClass.SelectMarkByClassCode(int.Parse(CCode.ToString()));
                        if (MyTable.Rows.Count > 0)
                            Checking++;
                        MyTable = MyClass.SelectSubjectTecherByClassCode(int.Parse(CCode.ToString()));
                        if (MyTable.Rows.Count > 0)
                            Checking++;



                        if (!CCode.Equals("1"))
                        {
                            if (Checking > 0)
                            {
                                Session["CCode"] = CCode.ToString();
                                Session["CName"] = CName.ToString();

                                if (Session["Lang"].ToString().Equals("EN"))
                                    LabelAccept.Text = "There Is Data Will Be Removed From Other Tabels       (Cannot undo changes)        Do You Want To Continue ?";
                                else
                                    LabelAccept.Text = "سيتم حذف جميع البيانات المتصله في هذا الصف !";

                                PopUpAccept.Visible = true;
                                Checking = 0;
                            }

                            else
                            {
                                MyClass.RemoveClass(int.Parse(CCode.ToString()));

                                GetClasses();

                                DivMessage.Visible = true;

                                if (Session["Lang"].ToString().Equals("EN"))
                                    LabelMessage.Text = "Subject   " + CName.ToString() + " Removed";

                                else
                                    LabelMessage.Text = "تم الحذف";
                            }
                        }
                    }

                    else
                    {
                        DivMessage.Visible = true;
                        //============================ Change Lang ============================
                        if (Session["Lang"].ToString().Equals("EN"))
                            LabelMessage.Text = "Cannot Remove Base Classes !";
                        else
                            LabelMessage.Text = "لا يمكن ازالة الفئات الاساسية للصفوف";
                    }

                }

                else
                {
                    GetClasses();
                    FillDropDowns();
                }

                Checking = 0;
            }

            else
            {
                DivMessage.Visible = true;
                //============================ Change Lang ============================
                if (Session["Lang"].ToString().Equals("EN"))
                    LabelMessage.Text = "Connection Time Out !";
                else
                    LabelMessage.Text = "انتهى وقت محاولة الاتصال !";
            }
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        ////////////////////////////////////////////////////////////////////////////////////////////////////
        ////////////////////////////////////////////////////////////////////////////////////////////////////
        protected void Grid1_RowCommand(object sender, GridViewCommandEventArgs e)
        {


        }


        ////////////////////////////////////////////////////////////////////////////////////////////////////
        ////////////////////////////////////////////////////////////////////////////////////////////////////
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        protected void ButtonMessage_Click(object sender, EventArgs e)
        {
            DivMessage.Visible = false;

            if (PopUpFixer == 1)
            {
                PopUpFixer = 0;
            }

            LabelMessage.Text = "";
        }

        protected void ADD_Click(object sender, EventArgs e)
        {

            string CName = "", Result = "";
            int CCode;

            MyClass.CheckForInternetConnection();

            if (MyClass.NetCheck == true)
            {
                CheckTabel = new DataTable();

                CName = DropDownClasses.SelectedItem.Text + " " + DropDownClassID.SelectedItem.Text.ToString();
                CCode = (int.Parse(DropDownClasses.SelectedItem.Value) * 10) + int.Parse(DropDownClassID.SelectedItem.Value.ToString());

                //============================ Change Lang ============================
                //============================ Change Lang ============================
                if (!Session["Lang"].ToString().Equals("EN"))
                {
                    string ARClassName = "";
                    char LastChar;


                    LastChar = CName[CName.Length - 1];

                    CName = CName.Remove(CName.Length - 1);

                    if (CName.Equals("البستان "))
                        ARClassName = "KIDS";

                    else if (CName.Equals("الاول "))
                        ARClassName = "One";

                    else if (CName.Equals("الثاني "))
                        ARClassName = "Two";

                    else if (CName.Equals("الثالث "))
                        ARClassName = "Three";

                    else if (CName.Equals("الرابع "))
                        ARClassName = "four";

                    else if (CName.Equals("الخامس "))
                        ARClassName = "five";

                    else if (CName.Equals("السادس "))
                        ARClassName = "six";

                    else if (CName.Equals("السابع "))
                        ARClassName = "seven";

                    else if (CName.Equals("الثامن "))
                        ARClassName = "eight";

                    else if (CName.Equals("التاسع "))
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

                    CName = ARClassName;
                }


                MyTable = MyClass.SelectClassByName(CName);

                if (MyTable.Rows.Count == 0)
                {

                    //////////////////// Add Class ////////////////////
                    //////////////////// Add Class //////////////////// 


                    Result = MyClass.AddClass2(CName, CCode);

                    DivMessage.Visible = true;

                    if (Session["Lang"].ToString().Equals("EN"))
                        LabelMessage.Text = "Class Added";

                    else
                        LabelMessage.Text = "تمت اضافه الصف";

                    GetClasses();
                }

                else
                {
                    DivMessage.Visible = true;
                    //============================ Change Lang ============================
                    if (Session["Lang"].ToString().Equals("EN"))
                        LabelMessage.Text = "Class Allready Added !";
                    else
                        LabelMessage.Text = "تم اضافة الصف من قبل";
                }

                CheckTabel.Clear();
            }

            else
            {
                DivMessage.Visible = true;
                //============================ Change Lang ============================
                if (Session["Lang"].ToString().Equals("EN"))
                    LabelMessage.Text = "Connection Time Out !";
                else
                    LabelMessage.Text = "انتهى وقت محاولة الاتصال !";
            }

        }

        protected void Accept_Click(object sender, EventArgs e)
        {
            string ToRemove = "", ImageName = "";
            int Cnt = 0;


            MyClass.CheckForInternetConnection();
            if (MyClass.NetCheck == true)
            {
                //======================================================================================== Remove Data =================
                //======================================================================================== Remove Data =================

                MyClass.RemoveMarkByClassCode(int.Parse(Session["CCode"].ToString()));
                MyClass.RemoveSubjectTecherByClassCode(int.Parse(Session["CCode"].ToString()));


                MyTable = MyClass.SelectStudentsByClassCode(int.Parse(Session["CCode"].ToString()));

                while (Cnt != MyTable.Rows.Count)
                {
                    ToRemove = MyTable.Rows[Cnt][0].ToString();
                    MyClass.RemoveImage(ToRemove);
                    ImageName = MyClass.FindImageBySID(ToRemove).ToString();
                    ServerRemoveImage(ImageName);

                    Cnt++;
                }

                MyClass.RemoveStudentByClassCode(int.Parse(Session["CCode"].ToString()));
                MyClass.RemoveClass(int.Parse(Session["CCode"].ToString()));

                LabelAccept.Text = "";
                PopUpAccept.Visible = false;

                DivMessage.Visible = true;
                LabelMessage.Text = "Class   " + Session["CName"].ToString() + "   Removed  With Other Data !";

                GetClasses();
                Cnt = 0;
            }

            else
            {
                DivMessage.Visible = true;
                //============================ Change Lang ============================
                if (Session["Lang"].ToString().Equals("EN"))
                    LabelMessage.Text = "Connection Time Out !";
                else
                    LabelMessage.Text = "انتهى وقت محاولة الاتصال !";
            }

        }

        protected void Cancel_Click(object sender, EventArgs e)
        {
            LabelAccept.Text = "";
            PopUpAccept.Visible = false;
        }

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

        protected void BackClick_Click(object sender, EventArgs e)
        {
            Response.Redirect("Choose.aspx");
        }

    }

}
