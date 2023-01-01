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
    public partial class NewYear : System.Web.UI.Page
    {
        public DataTable MyTabel = new DataTable();
        public List<int> Indexes = new List<int>();
        public List<int> Indexes2 = new List<int>();
        bool Check = false;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (System.Web.HttpContext.Current.Session["SCODE"] == null)
            {
                Response.Redirect("Login Page.aspx");
            }

            //============================ Change Lang ============================
            if (Session["Lang"].ToString().Equals("EN"))
            {
                LabelAccept.Text = "Are You Sure Do U Want To Higher The Classes ?                       EnterPass";
                Accept.Text = "Accept";
                Cancel.Text = "Cancel";
            }


            else
            {
                LabelAccept.Text = "اضغط تاكيد لبدايه سنه جديده                       ادخل كلمه السر";
                Accept.Text = "تاكيد";
                Cancel.Text = "الغاء";
                ButtonMessage.Text = "اغلاق";
            }            

        }
         

        protected void Accept_Click(object sender, EventArgs e)
        {

            MyClass.CheckForInternetConnection();
            if (MyClass.NetCheck == true)
            {
                if(!TextSCode.Text.Equals(""))
                {
                    string Res = "";

                    Res = MyClass.SchoolLoginCheck(int.Parse(Session["SCODE"].ToString()), TextSCode.Text.ToString());

                    if(Res.Equals("1"))
                    {
                        MyTabel = MyClass.ShowClasses();
                        int Cnt = 0;
                        int Max = 0;
                        List<int> Classes = new List<int>();
                        List<int> Indexes = new List<int>();
                        bool result;

                        for (int j = MyTabel.Rows.Count - 1; j >= 0; j--)
                        {
                            DataRow dr = MyTabel.Rows[j];
                            if (int.Parse(dr["ClassCode"].ToString()) == Max)
                            {
                                Indexes.Add(j);
                                j = 0;
                            }
                        }


                        string Result = "";

                        //Result = MyClass.RemoveAllData();

                        Result = MyClass.RemoveAllData2();

                        HigherClasses(MyTabel);
                    }

                    else
                    {
                        TextSCode.Text = "";
                        DivMessage.Visible = true;
                        if (Session["Lang"].ToString().Equals("EN"))
                            LabelMessage.Text = "Wrong Pass";
                        else
                            LabelMessage.Text = "كلمه السر خطا";
                    }
                }

            }
            else
            {
                DivMessage.Visible = true;
                LabelMessage.Text = "There Is no internet!";
            }
        }

        public void HigherClasses(DataTable Classes)
        {
            int ToDo,C1,C2;
            string Result = "";
            DataTable Check = new DataTable();

            for (int i = 0; i < Classes.Rows.Count; i++)
            {

                ToDo = int.Parse(Classes.Rows[i][1].ToString());
                Check = MyClass.SelectStudentsByClassCode(int.Parse(Classes.Rows[i][1].ToString()));

                if (Check.Rows.Count != 0)
                {
                    if (ToDo != 1)
                    {
                        if (ToDo >= 91 || ToDo >= 61)
                        {
                            //Test//////////////

                            MyClass.AddClass2(Classes.Rows[i][0].ToString() + " " + (int.Parse(DateTime.Now.ToString("yyy"))).ToString(), int.Parse(Classes.Rows[i][1].ToString() + (int.Parse(DateTime.Now.ToString("yyy"))).ToString()));

                            MyClass.UpdateClassCodeinStudents(int.Parse(Classes.Rows[i][1].ToString() + (int.Parse(DateTime.Now.ToString("yyy"))).ToString()), int.Parse(Classes.Rows[i][1].ToString()));


                            //Test//////////////


                            //Result = MyClass.RemoveClassData(ToDo);
                        }

                        else
                        {

                            Indexes.Add(int.Parse(Classes.Rows[i][1].ToString()));

                        }
                    }
                }

            }

            if(Indexes.Count!=0)
            {
                SortClassesFromHighToLow();
                int C22;

                for (int cnt = 0; cnt < Indexes2.Count; cnt++)
                {
                    C1 = int.Parse(Indexes2[cnt].ToString()) % 10;
                    C2 = int.Parse(Indexes2[cnt].ToString()) % 100 / 10;


                    C22 = C2;

                    C22++;
                    C22 *= 10;

                    MyTabel = MyClass.SelectClassNameByCode(1 + C22);

                    string Class1 = MyTabel.Rows[0][0].ToString();

                    string ClassName = "";
                    int counter = 0;

                    while(Class1[counter]!=' ')
                    {
                        ClassName += Class1[counter++];
                    }


                    char c = Convert.ToChar(64+C1);
                    ClassName += " " + c;



                    C2++;
                    C2 *= 10;

                    MyTabel = MyClass.SelectClass((C1 + C2));

                    if (MyTabel.Rows.Count == 0)
                        MyClass.AddClass2(ClassName, (C1 + C2));


                    MyClass.UpdateClassCodeinStudents((C1 + C2), int.Parse(Indexes2[cnt].ToString()));

                    Class1 = "";
                    ClassName = "";
                    counter = 0;

                }

                //============================ Change Lang ============================
                //============================ Change Lang ============================
                if (Session["Lang"].ToString().Equals("EN"))
                    LabelMessage.Text = "Done New Year Started !";
                else
                    LabelMessage.Text = "تم.. ";

                DivMessage.Visible = true;
                
            }

            else
            {
                DivMessage.Visible = true;

                if (Session["Lang"].ToString().Equals("EN"))
                    LabelMessage.Text = "There Is No Students In the School!";

                if (Session["Lang"].ToString().Equals("EN"))
                    LabelMessage.Text = "لائحه الطلاب فارغه !";
            }


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



        public void SortClassesFromHighToLow()
        {
            int max = 0;
            int bigindex = 0;
            max = int.Parse(Indexes[0].ToString());
            bigindex = 0;


            for (int row=0;row < Indexes.Count;row++)
            {
                max = int.Parse(Indexes[row].ToString());
                bigindex = row;

                for (int i = 0; i < Indexes.Count; i++)
                {
                    if (int.Parse(Indexes[i].ToString()) > max)
                    {
                        max = int.Parse(Indexes[i].ToString());
                        bigindex = i;
                    }           
                }

                Indexes2.Add(max);
                Indexes.RemoveAt(bigindex);

                row = -1;

                int s = Indexes.Count;
            }

        }

        protected void Cancel_Click(object sender, EventArgs e)
        {

            MyClass.CheckForInternetConnection();
            if (MyClass.NetCheck == true)
            {
                Response.Redirect("Choose.aspx");
            }
            else
            {
                DivMessage.Visible = true;
                LabelMessage.Text = "There Is no internet!";
            }
        }
    }
}