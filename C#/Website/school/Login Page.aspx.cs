using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using school.App_Code;
using System.Net.NetworkInformation;
using System.Net;
using System.Threading;

namespace school
{
    public partial class WebForm1 : System.Web.UI.Page
    {


        private Contact con = new Contact();


        protected void Page_Load(object sender, EventArgs e)
        {
            //------------------------------ Set Lang ----------------------->
            //------------------------------ Set Lang ----------------------->

            if (!IsPostBack)
            {
                if (Session["Lang"] == null)
                    Session["Lang"] = ChangeLangNow.Text;

                if (Session["Lang"].ToString().Equals("EN"))
                {
                    title1.InnerText = "Login";
                    CodeSpan.InnerText = "School Code";
                    PassSpan.InnerText = "Password";
                    Login.Text = "Login";
                    GorgetPass.Text = " Forget Pass Click ";
                    ChangeLangNow.Text = "EN";
                }

                else
                {
                    title1.InnerText = "تسجيل الدخول";
                    CodeSpan.InnerText = "كود المدرسه";
                    PassSpan.InnerText = "كلمه السر";
                    Login.Text = "دخول";
                    GorgetPass.Text = " نسيت كلمه السر ؟ ";
                    ChangeLangNow.Text = "AR";
                }
            }


            DivMessage.Visible = false;


            MyClass.CheckForInternetConnection();
            if (MyClass.NetCheck == false)
            {
                DivMessage.Visible = true;
                LabelMessage.Text = "There Is no internet!";
            }

            Session["SchoolCode"] = null;
            Session["SCODE"] = null;

            //////////////// Dont Tuch >>>>>>>
            string SchoolDatabase = @"Data Source=SQL6007.site4now.net;Initial Catalog=DB_A50589_School1Data;User Id=DB_A50589_School1Data_admin;Password=need4speed123159;";
            string SchoolDatabase2 = @"Data Source=SQL6007.site4now.net;Initial Catalog=DB_A50589_SchoolDataKids;User Id=DB_A50589_SchoolDataKids_admin;Password=need4speed123159;";
            string PublicDatabase = @"Data Source=SQL6007.site4now.net;Initial Catalog=DB_A50589_PublicData;User Id=DB_A50589_PublicData_admin;Password=need4speed123159;";


            // MyClass.CreateTabelPromote(@PublicDatabase);
            // MyClass.CreateTableMessages(@SchoolDatabase);
            // MyClass.CreateTablePresences(@SchoolDatabase);
            // MyClass.RemoveAllSchools();

        }

        protected void LoginClick(object sender, EventArgs e)
        {
            string Pass = "", SchoolCode = "", Result = null;
            int SchoolCode2;

            MyClass.CheckForInternetConnection();
            if (MyClass.NetCheck == false)
            {
                DivMessage.Visible = true;
                LabelMessage.Text = "There Is no internet!";
            }

            else
            {
                //======================= Saving ID And Pass =======================
                SchoolCode = TextSchoolCode.Text.ToString();
                Pass = TextPass.Text.ToString();


                //======================= Checking if its Empty =======================
                if (!Pass.Equals("") && !SchoolCode.Equals(""))
                {
                    if (Pass.Length <= 15)
                    {
                        if (SchoolCode.Length <= 15)
                        {
                            SchoolCode2 = int.Parse(SchoolCode.ToString());
                            Result = MyClass.SchoolLoginCheck(SchoolCode2, Pass);

                            if (Result.Equals("1"))
                            {
                                Session["SCODE"] = SchoolCode2.ToString();
                                Response.Redirect("Choose.aspx");
                            }

                            else
                            {
                                if (Session["Lang"].ToString().Equals("EN"))
                                    LabelMessage.Text = "Wrong ID or Pass";
                                else
                                    LabelMessage.Text = "خطاء في المعلومات";

                                DivMessage.Visible = true;
                            }
                        }

                        else
                        {
                            if (Session["Lang"].ToString().Equals("EN"))
                                LabelMessage.Text = "Wrong ID or Pass";

                            else
                                LabelMessage.Text = "خطاء في المعلومات";

                            DivMessage.Visible = true;       
                        }
                    }

                    else
                    {
                        if (Session["Lang"].ToString().Equals("EN"))
                            LabelMessage.Text = "Wrong ID or Pass";

                        else
                            LabelMessage.Text = "خطاء في المعلومات";

                        DivMessage.Visible = true;
                    }

                }

                else
                {

                    if (Session["Lang"].ToString().Equals("EN"))
                        LabelMessage.Text = "Fill The Information";

                    else
                        LabelMessage.Text = "املأ المعلومات";

                    DivMessage.Visible = true;

                    
                }
            }

        }

        protected void GorgetPass_Click(object sender, EventArgs e)
        {

            if (Session["Lang"].ToString().Equals("EN"))
                LabelMessage.Text = "Call Us At (" + "0523700846" + ")";

            else
                LabelMessage.Text = "اتصل بنا على (" + "0523700846" + ")";

            DivMessage.Visible = true;
            
        }

        protected void ButtonMessage_Click(object sender, EventArgs e)
        {
            DivMessage.Visible = false;
        }

        protected void ChangeLangNow_Click(object sender, EventArgs e)
        {
            DivLang.Visible = true;

        }

        protected void ButtonExit_Click(object sender, EventArgs e)
        {
            DivLang.Visible = false;
        }


        protected void BtAR_Click(object sender, EventArgs e)
        {
            ChangeLangNow.Text = "AR";
            DivLang.Visible = false;
            Session["Lang"] = "AR";
            Response.Redirect("Login Page.aspx");
        }

        protected void BtEN_Click1(object sender, EventArgs e)
        {
            ChangeLangNow.Text = "EN";
            DivLang.Visible = false;
            Session["Lang"] = "EN";
            Response.Redirect("Login Page.aspx");
        }
    }
}