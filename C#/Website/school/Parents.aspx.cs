using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net.NetworkInformation;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using school.App_Code;

namespace school
{
    public partial class WebForm2 : System.Web.UI.Page
    {
        public static DataTable MyTable, MyTable2;
        public static int C;
        bool Check = false;

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        ////////////////////////////////////////////////////////////////////////////////////////////////////
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        protected void Page_Load(object sender, EventArgs e)
        {
            if (System.Web.HttpContext.Current.Session["SCODE"] != null)
            {

                MyClass.CheckForInternetConnection();
                if (MyClass.NetCheck == true)
                {
                    ChangeIDPopUp.Visible = false;
                    DivMessage.Visible = false;

                    if (!IsPostBack)
                    {
                        Grid1FooterTabel.Style["background-image"] = "Gifs/ezgiffot.gif";
                        Session["ParentID"] = "All";
                        GetParents(-1);
                    }
                }
                else
                {
                    DivMessage.Visible = true;
                    LabelMessage.Text = "There Is no internet!";
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

        public void GetParents(int index)
        {

            if (Session["ParentID"].Equals("All"))
                MyTable = MyClass.ShowParents();

            else
                MyTable = MyClass.SelectParent(Session["ParentID"].ToString());

            GridParents.DataSource = MyTable;
            GridParents.DataBind();

            //============================ Change Lang ============================
            if (!Session["Lang"].ToString().Equals("EN"))
            {
                //============================ Change Edits Lang ============================
                Button Edits;

                for (int rowindex = 0; rowindex < GridParents.Rows.Count; rowindex++)
                {
                    if (rowindex == index)
                    {
                        Edits = ((Button)GridParents.Rows[rowindex].FindControl("Update"));
                        Edits.Text = "تحديث";

                        Edits = ((Button)GridParents.Rows[rowindex].FindControl("Cancel"));
                        Edits.Text = "الغاء";

                        Edits = ((Button)GridParents.Rows[rowindex].FindControl("ChangeID"));
                        Edits.Text = "تغيير رقم الهوية";
                    }

                    else
                    {
                        Edits = ((Button)GridParents.Rows[rowindex].FindControl("Edit"));
                        Edits.Text = "اعداد";

                        Edits = ((Button)GridParents.Rows[rowindex].FindControl("Delete"));
                        Edits.Text = "حذف";
                    }
                }
                TextFind.Attributes.Add("placeholder", "رقم هوية الوالدين");
                HeaderPName.Text = "الاسم";
                HeaderPID.Text = "رقم الهوية";
                HeaderPPhone.Text = "رقم الهاتف";
            }
        }


        ////////////////////////////////////////////////////////////////////////////////////////////////////
        ////////////////////////////////////////////////////////////////////////////////////////////////////
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        protected void GridParents_RowEditing(object sender, GridViewEditEventArgs e)
        {

            int index = e.NewEditIndex;
            GridParents.EditIndex = e.NewEditIndex;


            string PID = "";

            PID = GridParents.DataKeys[index].Value.ToString();

            DataTable PIDExist;
            PIDExist = MyClass.SelectParent(PID);

            if (PIDExist.Rows.Count > 0)
            {
                GetParents(index);

                GridParents.Rows[index].BackColor = System.Drawing.ColorTranslator.FromHtml("#303030");
                GridParents.Rows[index].Style["background-image"] = "Images/GridEditRow.Gif";
            }

            else
                GetParents(-1);
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        ////////////////////////////////////////////////////////////////////////////////////////////////////
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        protected void GridParents_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            GridParents.EditIndex = -1;
            GetParents(-1);
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        ////////////////////////////////////////////////////////////////////////////////////////////////////
        ////////////////////////////////////////////////////////////////////////////////////////////////////
        protected void GridParents_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            string Name = "", PID = "", Result, Phone = "";
            int Phone2;

            MyClass.CheckForInternetConnection();
            if (MyClass.NetCheck == true)
            {

                PID = GridParents.DataKeys[e.RowIndex].Value.ToString();
                Name = (GridParents.Rows[e.RowIndex].FindControl("TextPName") as TextBox).Text.ToString();
                Phone = (GridParents.Rows[e.RowIndex].FindControl("TextPhoneNumber") as TextBox).Text.ToString();

                DataTable PIDExist;
                PIDExist = MyClass.SelectParent(PID);

                if (PIDExist.Rows.Count > 0)
                {
                    if (Name != "" && PID != "" && Phone != "")
                    {

                        if (Phone.Length <= 10 && Phone.Length >= 9)
                        {
                            Phone2 = int.Parse(Phone.ToString());

                            Result = MyClass.UpdateParent(Name, PID, Phone2);

                            DivMessage.Visible = true;
                            if (Session["Lang"].ToString().Equals("EN"))
                                LabelMessage.Text = "Updated";
                            else
                                LabelMessage.Text = "تم التحديث";
                            GridParents.EditIndex = -1;
                            GetParents(-1);
                        }

                        else
                        {
                            DivMessage.Visible = true;
                            if (Session["Lang"].ToString().Equals("EN"))
                                LabelMessage.Text = "The phone number is illegal!";
                            else
                                LabelMessage.Text = "رقم الهاتف غير قانوني";
                        }

                    }

                    else
                    {
                        DivMessage.Visible = true;
                        if (Session["Lang"].ToString().Equals("EN"))
                            LabelMessage.Text = "There Is Empty Boxes!";
                        else
                            LabelMessage.Text = "هناك سطور فارغة";
                    }
                }

                else
                    GetParents(-1);
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

        protected void GridParents_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName.Equals("ChangeID"))
            {
                if (!e.CommandArgument.Equals("023423452"))
                {
                    string id = e.CommandArgument.ToString();

                    MyTable = MyClass.SelectParent(id);

                    if (MyTable.Rows.Count > 0)
                    {
                        ChangeIDPopUp.Visible = true;

                        if (Session["Lang"].ToString().Equals("EN"))
                            Grid2.Columns[1].HeaderText = "Parent ID";

                        else
                            Grid2.Columns[1].HeaderText = "رقم الهويه";

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
                        GetParents(-1);

                }

            }
        }

        protected void GridParents_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            string PID = "";

            MyClass.CheckForInternetConnection();
            if (MyClass.NetCheck == true)
            {
                PID = GridParents.DataKeys[e.RowIndex].Value.ToString();

                DataTable PIDExist;
                PIDExist = MyClass.SelectParent(PID);

                if (PIDExist.Rows.Count > 0)
                {
                    MyTable2 = MyClass.SelectStudentsByPID(PID);

                    if (MyTable2.Rows.Count == 0)
                    {
                        MyClass.RemoveParent(PID);
                        GetParents(-1);
                    }

                    else
                    {
                        DivMessage.Visible = true;
                        if (Session["Lang"].ToString().Equals("EN"))
                            LabelMessage.Text = "This Parent Have Many Connections Cannot Remove !";
                        else
                            LabelMessage.Text = "هذا الوالد لديه العديد من الاتصالات التي لا يمكن إزالتها";
                    }
                }

                else
                    GetParents(-1);
            }
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        ////////////////////////////////////////////////////////////////////////////////////////////////////
        ////////////////////////////////////////////////////////////////////////////////////////////////////
        protected void Grid2_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            string Name, OldPID, NewPID = "", IDChecker = "", Result = "", Phone = "";
            int ClassCode;

            MyClass.CheckForInternetConnection();
            if (MyClass.NetCheck == true)
            {
                OldPID = Grid2.DataKeys[e.RowIndex].Value.ToString();
                Name = MyTable.Rows[0].ItemArray[0].ToString();
                Phone = MyTable.Rows[0].ItemArray[2].ToString();

                DataTable PIDExist;
                PIDExist = MyClass.SelectParent(OldPID);

                if (PIDExist.Rows.Count > 0)
                {
                    NewPID = (Grid2.Rows[e.RowIndex].FindControl("TextPID") as TextBox).Text.ToString();
                    IDChecker = MyClass.IDChecker(NewPID);

                    if (!NewPID.Equals(""))
                    {
                        if (IDChecker.Equals("1"))
                        {
                            MyTable = MyClass.SelectParent(NewPID);

                            if (MyTable.Rows.Count == 1)
                            {
                                DivMessage.Visible = true;
                                if (Session["Lang"].ToString().Equals("EN"))
                                    LabelMessage.Text = "   ID Allready USED";
                                else
                                    LabelMessage.Text = "   الهويه مستعملة";
                            }

                            else
                            {
                                Grid2.Visible = false;


                                MyClass.AddParents(Name, NewPID, Phone);

                                MyClass.UpdatePIDinStudents(NewPID, OldPID);

                                MyTable2 = MyClass.SelectParentPublicDBAccount(NewPID);
                                if (MyTable2.Rows.Count == 0)
                                    MyClass.CreateRandomPassword(NewPID, "P");

                                MyTable2 = MyClass.SelectParentPublicDB2(NewPID, Session["SCODE"].ToString());
                                if (MyTable2.Rows.Count == 0)
                                    MyClass.AddParentsToPublicDB(NewPID, Session["SCODE"].ToString());

                                MyTable2 = MyClass.SelectNotification(NewPID);
                                if (MyTable2.Rows.Count == 0)
                                    MyClass.AddNotification(NewPID);

                                MyClass.RemoveParent(OldPID);

                                GridParents.EditIndex = -1;
                                GetParents(-1);

                                DivMessage.Visible = true;
                                if (Session["Lang"].ToString().Equals("EN"))
                                    LabelMessage.Text = "   Parents ID Updated";
                                else
                                    LabelMessage.Text = "   تم تحديث هوية الاب";
                                ChangeIDPopUp.Visible = false;
                            }
                        }

                        else
                        {
                            DivMessage.Visible = true;
                            if (Session["Lang"].ToString().Equals("EN"))
                                LabelMessage.Text = "Parents ID IS illegal";
                            else
                                LabelMessage.Text = "هويةالوالدين غير قانوني";

                        }

                    }

                    else
                    {
                        DivMessage.Visible = true;
                        if (Session["Lang"].ToString().Equals("EN"))
                            LabelMessage.Text = "   ID Box Is Empty";
                        else
                            LabelMessage.Text = "هناك سطور فارغة";
                    }
                }

                else
                    GetParents(-1);
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

        protected void ButtonMessage_Click(object sender, EventArgs e)
        {

            MyClass.CheckForInternetConnection();
            if (MyClass.NetCheck == true)
            {
                DivMessage.Visible = false;
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

        protected void ButtonFind_Click1(object sender, EventArgs e)
        {
            string PID = "", GridString = "";

            MyClass.CheckForInternetConnection();
            if (MyClass.NetCheck == true)
            {
                GridParents.EditIndex = -1;

                MyTable.Clear();

                for (int row = 0; row < GridParents.Rows.Count; row++)
                {

                    GridParents.Rows[row].BackColor = System.Drawing.Color.FromArgb(255, 153, 0);

                }


                if (!TextFind.Text.Equals(""))
                {
                    PID = TextFind.Text.ToString();

                    if (PID.Length == 9)
                    {
                        MyTable = MyClass.SelectParent(PID);

                        if (MyTable.Rows.Count == 1)
                        {
                            for (int row = 0; row < GridParents.Rows.Count; row++)
                            {
                                GridString = GridParents.DataKeys[row].Value.ToString();

                                if (GridString.Equals(PID))
                                {
                                    GridParents.EditIndex = -1;

                                    MyTable.Clear();

                                    MyTable = MyClass.SelectParent(TextFind.Text);

                                    if (MyTable.Rows.Count != 0)
                                    {
                                        Session["ParentID"] = TextFind.Text;
                                        GetParents(-1);
                                    }

                                    else
                                    {                                    
                                        DivMessage.Visible = true;
                                        if (Session["Lang"].ToString().Equals("EN"))
                                            LabelMessage.Text = "Parents Not Found!";
                                        else
                                            LabelMessage.Text = "!لم يتم العثور على الوالدين";
                                    }
                                }
                            }
                        }

                        else
                        {
                            DivMessage.Visible = true;
                            if (Session["Lang"].ToString().Equals("EN"))
                                LabelMessage.Text = "Parents Not Found!";
                            else
                                LabelMessage.Text = "!لم يتم العثور على الوالدين";
                        }
                    }

                    else
                    {
                        DivMessage.Visible = true;
                        if (Session["Lang"].ToString().Equals("EN"))
                            LabelMessage.Text = "ID Must be 9 Characters!";
                        else
                            LabelMessage.Text = "رقم الهوية غير قانةني!";
                    }

                }

                else
                {
                    DivMessage.Visible = true;
                    if (Session["Lang"].ToString().Equals("EN"))
                        LabelMessage.Text = "Search Box Is Empty!";
                    else
                        LabelMessage.Text = "!مربع البحث فارغ";
                }

            }
            else
            {
                DivMessage.Visible = true;
                if (Session["Lang"].ToString().Equals("EN"))
                    LabelMessage.Text = "There Is no internet!";
                else
                    LabelMessage.Text = "لا يوجد هناك انترنت !";
            }
        }

        protected void ImageButton1_Click(object sender, ImageClickEventArgs e)
        {

            MyClass.CheckForInternetConnection();
            if (MyClass.NetCheck == true)
            {

                GridParents.EditIndex = -1;
                Session["ParentID"] = "All";
                GridParents.EditIndex = -1;
                GetParents(-1);
            }
            else
            {
                DivMessage.Visible = true;
                if (Session["Lang"].ToString().Equals("EN"))
                    LabelMessage.Text = "There Is no internet!";
                else
                    LabelMessage.Text = "لا يوجد هناك انترنت !";
            }
        }

        protected void BackClick_Click(object sender, EventArgs e)
        {
            Response.Redirect("Choose.aspx");
        }

    }
}