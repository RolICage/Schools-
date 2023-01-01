using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Net.NetworkInformation;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using school.App_Code;

namespace school
{
    public partial class Techers : System.Web.UI.Page
    {
        public static DataTable MyTable, MyClassTable, CheckTabel;
        public static int x = 0;
        public static int PopUpFixer = 0;
        bool Check = false;
        public string Case = "All";
        public static List<string> TechersToRemove = new List<string>();



        ////////////////////////////////////////////////////////////////////////////////////////////////////
        ////////////////////////////////////////////////////////////////////////////////////////////////////
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        protected void Page_Load(object sender, EventArgs e)
        {

            if (System.Web.HttpContext.Current.Session["SCODE"] != null)
            {
                if (!IsPostBack)
                {

                    //============================ Change Lang ============================
                    if (Session["Lang"].ToString().Equals("EN"))                   
                        TextFind.Attributes.Add("placeholder", "Enter Techer ID");

                    else
                        TextFind.Attributes.Add("placeholder", "ادخل رقم هويه المعلم");

                    Grid1FooterTabel.Style["background-image"] = "Gifs/ezgiffot.gif";
                    Session["Case"] = "All";
                    Grid1.ShowFooter = false;
                    DivMessage.Visible = false;
                    ChangeIDPopUp.Visible = false;
                    PopUpAccept.Visible = false;

                    GetTechers(-1);

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

        public void GetTechers(int index)
        {
            MyTable = MyClass.ShowTechers();


            if (!Session["Case"].ToString().Equals("All"))
            {
                MyTable = MyClass.SelectTecher(Session["Case"].ToString());

                Grid1.DataSource = MyTable;
                Grid1.DataBind();
            }
            else
            {
                MyTable = MyClass.ShowTechers();
                Grid1.DataSource = MyTable;
                Grid1.DataBind();
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

                        Edits = ((Button)Grid1.Rows[rowindex].FindControl("showpassbutton"));
                        Edits.Text = "Show Password";
                    }
                }

                //============================ Change Search Lang ============================
                TextFind.Attributes.Add("placeholder", "Enter Student ID");

                //============================ Change Footer Add Lang ============================
                addteacherbutton.Text = "ADD Teacher";

                //============================ Change Header Lang ============================
                HeaderTecherName.Text = "Teacher Name";
                HeaderTID.Text = "Teacher ID";

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

                        Edits = ((Button)Grid1.Rows[rowindex].FindControl("showpassbutton"));
                        Edits.Text = "عرض كلمه السر";
                    }
                }

                //============================ Change Search Lang ============================
                TextFind.Attributes.Add("placeholder", "  رقم هويه المعلم  ");

                //============================ Change Footer Add Lang ============================
                addteacherbutton.Text = "اضف المعلم";
                ButtonMessage.Text = "اغلاق";

                //============================ Change Header Lang ============================
                HeaderTecherName.Text = "اسم المعلم";
                HeaderTID.Text = "هويه المعلم";
                HeaderPhone.Text = "رقم الهاتف";
                FooterPhone2.Attributes.Add("placeholder", "رقم الهاتف");

                //============================ Change Footer Lang ============================
                FooterTName.Attributes.Add("placeholder", "اسم المعلم");
                FooterTecherID.Attributes.Add("placeholder", "رقم هويه المعلم");
            }
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        ////////////////////////////////////////////////////////////////////////////////////////////////////
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        protected void Grid1_RowEditing(object sender, GridViewEditEventArgs e)
        {

            int index = e.NewEditIndex;
            Grid1.EditIndex = e.NewEditIndex;

            /////// will use it when update id
            Session["RowIndeX"] = index.ToString();

            string TID = "";

            TID = Grid1.DataKeys[index].Value.ToString();

            DataTable TIDExist;
            TIDExist = MyClass.SelectTecher(TID);

            if (TIDExist.Rows.Count > 0)
            {
                GetTechers(index);

                ////////////////// Getting Phone NUM
                string Phone = "",PhoneDR="",PhoneTextRest="";
                Phone = TIDExist.Rows[0][2].ToString();

                PhoneDR = Phone[0].ToString();
                PhoneDR += Phone[1].ToString();
                PhoneDR += Phone[2].ToString();

                for (int i = 3; i < Phone.Length; i++)
                    PhoneTextRest += Phone[i].ToString();

                DropDownList PhoneDrop = (DropDownList)Grid1.Rows[index].FindControl("EditPhoneDrop");
                TextBox PhoneText = (TextBox)Grid1.Rows[index].FindControl("EditPhone");               

                PhoneDrop.Items.FindByText(PhoneDR).Selected = true;
                PhoneText.Text = PhoneTextRest.ToString();          

                Grid1.Rows[index].Style["background-image"] = "Images/GridEditRow.Gif";
            }

            else
                GetTechers(-1);

            x = 0;
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        ////////////////////////////////////////////////////////////////////////////////////////////////////
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        protected void Grid1_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            Grid1.EditIndex = -1;
            Grid2.Visible = false;
            GetTechers(-1);
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        ////////////////////////////////////////////////////////////////////////////////////////////////////
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        protected void Grid1_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            string TName = "", TID = "", Result = "",Phone="";

            MyClass.CheckForInternetConnection();
            if (MyClass.NetCheck == true)
            {
                TName = (Grid1.Rows[e.RowIndex].Cells[1].FindControl("TextBoxTName") as TextBox).Text.ToString();
                TID = Grid1.DataKeys[e.RowIndex].Value.ToString();

                TextBox PhoneText = (TextBox)Grid1.Rows[int.Parse(Session["RowIndeX"].ToString())].FindControl("EditPhone");
                DropDownList PhoneDrop = (DropDownList)Grid1.Rows[int.Parse(Session["RowIndeX"].ToString())].FindControl("EditPhoneDrop");

                if (!PhoneText.Text.Equals(""))
                    Phone = PhoneDrop.SelectedItem.Text.ToString() + PhoneText.Text.ToString();

                DataTable TIDExist;
                TIDExist = MyClass.SelectTecher(TID);

                if (TIDExist.Rows.Count > 0)
                {
                    if (!TID.Equals("205784989"))
                    {
                        if (TName != "")
                        {
                            Result = MyClass.UpdateTecherName(TName, Phone, TID);
                            DivMessage.Visible = true;

                            if (Session["Lang"].ToString().Equals("EN"))
                                LabelMessage.Text = "Teacher Updated";

                            else
                                LabelMessage.Text = "تم تحديث معلومات المعلم";

                            Grid1.EditIndex = -1;
                            GetTechers(-1);
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
                    GetTechers(-1);
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
            string TID;
            int Checking = 0;

            MyClass.CheckForInternetConnection();
            if (MyClass.NetCheck == true)
            {
                TID = Grid1.DataKeys[e.RowIndex].Value.ToString();

                DataTable TIDExist;
                TIDExist = MyClass.SelectTecher(TID);

                if (TIDExist.Rows.Count > 0)
                {

                    if (!TID.Equals("205784989"))
                    {
                        MyTable = MyClass.SelectSchedulesByTID(TID);
                        if (MyTable.Rows.Count > 0)
                            Checking++;

                        MyTable = MyClass.SelectSubjectsTecherByTID(TID);
                        if (MyTable.Rows.Count > 0)
                            Checking++;

                        MyTable = MyClass.SelectExamBYTID(TID);
                        if (MyTable.Rows.Count > 0)
                            Checking++;

                        MyTable = MyClass.SelectWorkByTID(TID);
                        if (MyTable.Rows.Count > 0)
                            Checking++;

                        if (Checking > 0)
                        {

                            Session["TID"] = TID.ToString();


                            if (Session["Lang"].ToString().Equals("EN"))
                                LabelAccept.Text = "There Is Data Will Be Removed From Other Tabels       (Cannot undo changes)        Do You Want To Continue ?";

                            else
                                LabelAccept.Text = "هناك بيانات ستتم إزالتها من جداول أخرى   (لا يمكن التراجع عن التغييرات)   هل تريد المتابعة؟";

                            PopUpAccept.Visible = true;
                            Checking = 0;
                        }

                        else
                        {
                            MyClass.RemoveTecher(TID);

                            GetTechers(-1);

                            Regenerate();

                            DivMessage.Visible = true;

                            if (Session["Lang"].ToString().Equals("EN"))
                                LabelMessage.Text = "Class   " + TID.ToString() + " Removed";

                            else
                                LabelMessage.Text = "تم الحذف ! " + TID.ToString();
                        }

                    }
                }

                else
                    GetTechers(-1);
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
            MyClass.CheckForInternetConnection();
            if (MyClass.NetCheck == true)
            {
                if (e.CommandName.Equals("Edit"))
                {
                    Session["RowIndex"] = e.CommandArgument.ToString();
                }


                if (e.CommandName.Equals("ChangeID"))
                {
                    if (!e.CommandArgument.Equals("205784989"))
                    {
                        string id = e.CommandArgument.ToString();

                        string TecherName = "";
                        int Row = int.Parse(Session["RowIndex"].ToString());

                        TecherName = (Grid1.Rows[Row].FindControl("TextBoxTName") as TextBox).Text.ToString();
                        Session["TecherName"] = TecherName.ToString();

                        MyTable = MyClass.SelectTecher(id);

                        if (MyTable.Rows.Count > 0)
                        {
                            ChangeIDPopUp.Visible = true;

                            //============================ Change Lang ============================
                            if (Session["Lang"].ToString().Equals("EN"))
                                Grid2.Columns[1].HeaderText = "Teacher ID";

                            else
                                Grid2.Columns[1].HeaderText = "هويه المعلم";


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
                        {
                            Grid1.EditIndex = -1;
                            GetTechers(-1);
                        }
                            
                    }
                }

                if (e.CommandName.Equals("FindPass"))
                {
                    string TID = e.CommandArgument.ToString();

                    if (!e.CommandArgument.Equals("205784989"))
                    {

                        MyTable = MyClass.SelectTecher(TID);

                        if (MyTable.Rows.Count > 0)
                        {
                            MyTable = MyClass.SelectTecherPass(TID);

                            DivMessage.Visible = true;

                            if (Session["Lang"].ToString().Equals("EN"))
                                LabelMessage.Text = "(" + TID + ")  Pass Is = " + MyTable.Rows[0][1].ToString();

                            else
                                LabelMessage.Text = MyTable.Rows[0][1].ToString() + " كلمه السر هي ";
                        }

                        else
                        {
                            Grid1.EditIndex = -1;
                            GetTechers(-1);
                        }
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

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        ////////////////////////////////////////////////////////////////////////////////////////////////////
        ////////////////////////////////////////////////////////////////////////////////////////////////////
        protected void Grid2_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            string TID, Name, NewTID, IDchecker = "",Phone="";

            MyClass.CheckForInternetConnection();

            if (MyClass.NetCheck == true)
            {
                TID = Grid2.DataKeys[e.RowIndex].Value.ToString();
                Name = MyTable.Rows[0][0].ToString();

                TextBox PhoneText = (TextBox)Grid1.Rows[int.Parse(Session["RowIndeX"].ToString())].FindControl("EditPhone");
                DropDownList PhoneDrop = (DropDownList)Grid1.Rows[int.Parse(Session["RowIndeX"].ToString())].FindControl("EditPhoneDrop");

                if(!PhoneText.Text.Equals(""))
                    Phone = PhoneDrop.SelectedItem.Text.ToString() + PhoneText.Text.ToString();

                DataTable TIDExist;
                TIDExist = MyClass.SelectTecher(TID);

                if (TIDExist.Rows.Count > 0)
                {
                    NewTID = (Grid2.Rows[e.RowIndex].Cells[1].FindControl("TextTecherID") as TextBox).Text.ToString();

                    if (!NewTID.Equals(""))
                    {
                        IDchecker = MyClass.IDChecker(NewTID);

                        if (IDchecker.Equals("1"))
                        {
                            MyTable = MyClass.SelectTecher(NewTID);

                            if (MyTable.Rows.Count == 1)
                            {
                                DivMessage.Visible = true;
                                if (Session["Lang"].ToString().Equals("EN"))
                                    LabelMessage.Text = "   Teacher Allready Added !";

                                else
                                    LabelMessage.Text = "هذا المعلم قد تمه اضافته من قبل !";
                            }


                            else
                            {

                                Grid2.Visible = false;

                                MyClass.AddTechers(Name, NewTID,Phone);

                                MyClass.UpdateTIDInSchedules(NewTID, TID);

                                MyClass.UpdateTIDinSunjectsTecher(NewTID, TID);

                                MyClass.UpdateTecherIDINWorks(NewTID, TID);

                                string R= MyClass.UpdateTecherIDINExams(NewTID, TID);
                             
                                if(MyClass.SelectTecherPublicDB2(NewTID, Session["SCODE"].ToString()).Rows.Count==0)
                                    MyClass.AddTechersToPublicDB(NewTID, Session["SCODE"].ToString());

                                MyClass.UpdateTecherName(Session["TecherName"].ToString(), NewTID, Phone);

                                MyClass.RemoveTecher(TID);

                                Regenerate();


                                Grid1.EditIndex = -1;
                                DivMessage.Visible = true;

                                if (Session["Lang"].ToString().Equals("EN"))
                                    LabelMessage.Text = "   Techer ID Updated";

                                else
                                    LabelMessage.Text = "   تم تحديث رقم هويه المعلم";

                                ChangeIDPopUp.Visible = false;
                                Session["Case"] = NewTID.ToString();
                                Grid1.EditIndex = -1;
                                GetTechers(-1);
                            }
                        }

                        else
                        {
                            DivMessage.Visible = true;

                            if (Session["Lang"].ToString().Equals("EN"))
                                LabelMessage.Text = "   ID Vaild (Not ligal)";

                            else
                                LabelMessage.Text = "رقم الهويه غير قانوني !";

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
                    GetTechers(-1);
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

        protected void Grid2_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            Grid2.Visible = false;
            ChangeIDPopUp.Visible = false;
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


            string Name = "", TID = "", Result = "",CheckID="",Phone="";


            CheckTabel = new DataTable();

            MyClass.CheckForInternetConnection();
            if (MyClass.NetCheck == true)
            {
                Name = FooterTName.Text.ToString();
                TID = FooterTecherID.Text.ToString();

                if(!FooterPhone2.Text.ToString().Equals(""))
                    Phone = FooterPhoneDrop2.SelectedItem.Text.ToString() + FooterPhone2.Text.ToString();


                if (Name != "" && TID != "" &&Phone!="")
                {
                    CheckID = MyClass.IDChecker(TID).ToString();

                    if (CheckID.Equals("1"))
                    {
                        CheckTabel.Clear();
                        CheckTabel = MyClass.SelectTecher(TID);

                        if (CheckTabel.Rows.Count == 0)
                        {

                            //////////////////// Add Class ////////////////////
                            //////////////////// Add Class //////////////////// 

                            //////////////////// Check if techer have Account //////////////////// 
                            MyTable = MyClass.SelectTecherPublicDB(TID);
                            if (MyTable.Rows.Count == 0)
                                MyClass.CreateRandomPassword(TID, "T");

                            //////////////////// Check if techer in PDB //////////////////// 
                            MyTable = MyClass.SelectTecherPublicDB2(TID, Session["SCODE"].ToString());
                            if (MyTable.Rows.Count == 0)
                                MyClass.AddTechersToPublicDB(TID, Session["SCODE"].ToString());

                            //////////////////// Check if techer in SDB //////////////////// 
                            MyTable = MyClass.SelectTecher(TID);
                            if (MyTable.Rows.Count == 0)
                                MyClass.AddTechers(Name, TID,Phone);


                            FooterTName.Text = "";
                            FooterTecherID.Text = "";

                            DivMessage.Visible = true;

                            if (Session["Lang"].ToString().Equals("EN"))                         
                                LabelMessage.Text = "Techer Added";
                         
                            else
                            {
                                LabelMessage.Text = "تمه اضافه المعلم";
                                ButtonMessage.Text = "اغلاق";
                            }
                                
                            FooterTName.BorderColor = System.Drawing.ColorTranslator.FromHtml("#808080");
                            FooterTecherID.BorderColor = System.Drawing.ColorTranslator.FromHtml("#808080");
                            GetTechers(-1);
                        }



                        else
                        {
                            DivMessage.Visible = true;

                            if (Session["Lang"].ToString().Equals("EN"))
                                LabelMessage.Text += "The Techer Allready Added";

                            else
                                LabelMessage.Text = "هذا المعلم قد تمه اضافته من قبل !";

                            GetTechers(-1);
                        }
                    }

                    else
                    {
                        DivMessage.Visible = true;

                        if (Session["Lang"].ToString().Equals("EN"))
                            LabelMessage.Text = "   ID Vaild (Not ligal)";

                        else
                            LabelMessage.Text = "رقم الهويه غير قانوني !";
                    }



                    GetTechers(-1);

                }



                else
                {
                    DivMessage.Visible = true;

                    if (Session["Lang"].ToString().Equals("EN"))
                        LabelMessage.Text = "   There is An Empty Boxies";

                    else
                        LabelMessage.Text = "    هناك سطور فارغه !";

                    FooterTName.BorderColor = System.Drawing.ColorTranslator.FromHtml("#808080");
                    FooterTecherID.BorderColor = System.Drawing.ColorTranslator.FromHtml("#808080");
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
       
        protected void ButtonFind_Click(object sender, EventArgs e)
        {
            string TID = "", GridString = "";

            MyTable.Clear();

            MyClass.CheckForInternetConnection();
            if (MyClass.NetCheck == true)
            {

                if (!TextFind.Text.Equals(""))
                {
                    TID = TextFind.Text.ToString();
                    MyTable = MyClass.SelectTecher(TID);

                    if ((MyTable.Rows.Count) == 1)
                    {
                        Session["Case"] = TID.ToString();
                        GetTechers(-1);
                    }

                    else
                    {
                        DivMessage.Visible = true;

                        if (Session["Lang"].ToString().Equals("EN"))
                            LabelMessage.Text = "Techer Not Found";

                        else
                            LabelMessage.Text = "لم يتم العثور على المعلم !";
                    }
                }

                else
                {
                    DivMessage.Visible = true;

                    if (Session["Lang"].ToString().Equals("EN"))
                        LabelMessage.Text = "   Search Box Is Empty";

                    else
                        LabelMessage.Text = "   سطر البحث فارغ !";
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

        protected void Accept_Click(object sender, EventArgs e)
        {
            //======================================================================================== Remove Data =================
            //======================================================================================== Remove Data =================

            MyClass.CheckForInternetConnection();
            if (MyClass.NetCheck == true)
            {
                MyClass.RemoveScheduleByTID(Session["TID"].ToString());

                MyClass.RemoveFromExams(Session["TID"].ToString());

                MyClass.RemoveFromWorks(Session["TID"].ToString());

                MyClass.RemoveSubjectTecherByTID(Session["TID"].ToString());

                MyClass.RemoveTecher(Session["TID"].ToString());

                Regenerate();

                PopUpAccept.Visible = false;

                DivMessage.Visible = true;

                if (Session["Lang"].ToString().Equals("EN"))
                    LabelMessage.Text = "Techer   " + Session["TID"].ToString() + "   Removed  With Other Data !";

                else
                    LabelMessage.Text = "تم حذف جميع بيانات المعلم !   " + Session["TID"].ToString();

                GetTechers(-1);
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

        protected void ImageButton1_Click(object sender, ImageClickEventArgs e)
        {
            MyClass.CheckForInternetConnection();
            if (MyClass.NetCheck == true)
            {
                Session["Case"] = "All";
                Grid1.EditIndex = -1;
                GetTechers(-1);
                TextFind.Text = "";
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
                            GetTechers(-1);
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