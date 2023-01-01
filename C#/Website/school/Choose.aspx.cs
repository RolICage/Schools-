using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using school.App_Code;


namespace school
{
    public partial class Choose : System.Web.UI.Page
    {
        public DataTable Select = new DataTable();
        public string Result = "";

        protected void Page_Load(object sender, EventArgs e)
        {
            if (System.Web.HttpContext.Current.Session["SCODE"] != null)
            {
                string URL = "";
                DataTable DTGetURL = new DataTable();

                DTGetURL = MyClass.SelectPromotVideo();

                if (DTGetURL.Rows.Count == 0)
                    URL = "https://www.youtube.com/embed/RGdk3hESsCI";

                else
                    URL = DTGetURL.Rows[0][0].ToString();

                var videoFrame = new Literal();
                videoFrame.Text = string.Format(@"<iframe width=""640"" height=""420"" src=""{0}"" frameborder=""0"" allowfullscreen></iframe>", URL);
                PromotVideo.Controls.Add(videoFrame);

                if (!IsPostBack)
                {
                    if (Session["Lang"].ToString().Equals("EN"))
                    {
                        titlestudnet.InnerText = "Students";
                        titleparents.InnerText = "Parents";
                        titleteachers.InnerText = "Teachers";
                        titlesubjects.InnerText = "Subjects";
                        titlenewyear.InnerText = "New Year";
                        titlesubteacher.InnerText = "Subjects & Teachers";
                        titleschedules.InnerText = "Schedules";
                        titleclasses.InnerText = "Classes";


                        studentbutton.InnerText = "Show Students";
                        parentsbutton.InnerText = "Show Parents";
                        teacherbutton.InnerText = "Show Teachers";
                        subbutton.InnerText = "Show Subjects";
                        newyearbutton.InnerText = "Start New Year";
                        subteacherbutton.InnerText = "Edit Subjects & Teachers";
                        schedulesbutton.InnerText = "Edit Schedules";
                        classesbutton.InnerText = "Edit Classes";


                        e1.InnerText = "INFO";
                        e2.InnerText = "INFO";
                        e3.InnerText = "INFO";
                        e4.InnerText = "INFO";
                        e5.InnerText = "INFO";
                        e6.InnerText = "INFO";
                        e7.InnerText = "INFO";
                        e8.InnerText = "INFO";
                    }

                    else
                    {
                        titlestudnet.InnerText = "الطلاب";
                        titleparents.InnerText = "الاباء";
                        titleteachers.InnerText = "المعلمين";
                        titlesubjects.InnerText = "المواضيع";
                        titlenewyear.InnerText = "سنه جديده";
                        titlesubteacher.InnerText = "مواضيع المعلمين";
                        titleschedules.InnerText = "برامج الحصص";
                        titleclasses.InnerText = "الصفوف";


                        studentbutton.InnerText = "عرض الطلاب";
                        parentsbutton.InnerText = "عرض الاباء";
                        teacherbutton.InnerText = "عرض المعلمين";
                        subbutton.InnerText = "عرض المواضيع";
                        newyearbutton.InnerText = "بدايه سنه جديده";
                        subteacherbutton.InnerText = "اعداد مواضيع المعلمين";
                        schedulesbutton.InnerText = "اعداد برامج الحصص";
                        classesbutton.InnerText = "اعداد الصفوف";


                        e1.InnerText = "معلومات";
                        e2.InnerText = "معلومات";
                        e3.InnerText = "معلومات";
                        e4.InnerText = "معلومات";
                        e5.InnerText = "معلومات";
                        e6.InnerText = "معلومات";
                        e7.InnerText = "معلومات";
                        e8.InnerText = "معلومات";

                        InfoAdd.Text = "اضافه";
                        InfoUpdate.Text = "تحديث";
                        InfoID.Text = "الهويه";
                        InfoUpdate2.Text = "تحديث";
                        InfoID2.Text = "الهويه";
                        CancelInfo.Text = "الغاء";
                        CancelInfo2.Text = "الغاء";
                        CancelInfoParent.Text = "الغاء";
                    }

                    Select = MyClass.SelectSchoolRank(Session["SCODE"].ToString());

                    Result = Select.Rows[0][0].ToString();

                    if (!Result.Equals("1"))
                    {
                        NewYear.Visible = true;
                    }
                }

            }
            else
            {
                Response.Redirect("Login Page.aspx");
            }

        }

        //============ if Student infro clicked >
        //============ if Student infro clicked >
        protected void e1_ServerClick(object sender, EventArgs e)
        {
            DivINFO.Visible = true;
        }

        protected void InfoAdd_Click(object sender, EventArgs e)
        {

            DivVideo.Visible = true;

            var videoFrame = new Literal();
            videoFrame.Text = string.Format(@"<iframe width=""960"" height=""540"" src=""{0}"" frameborder=""0"" allowfullscreen></iframe>", "https://www.youtube.com/embed/eGh6dvLhij0");
            youtubeVideo.Controls.Add(videoFrame);

        }

        protected void InfoUpdate_Click(object sender, EventArgs e)
        {
            DivVideo.Visible = true;

            var videoFrame = new Literal();
            videoFrame.Text = string.Format(@"<iframe width=""960"" height=""540"" src=""{0}"" frameborder=""0"" allowfullscreen></iframe>", "https://www.youtube.com/embed/7emqGZowZJ0");
            youtubeVideo.Controls.Add(videoFrame);

        }

        protected void InfoID_Click(object sender, EventArgs e)
        {
            DivVideo.Visible = true;

            var videoFrame = new Literal();
            videoFrame.Text = string.Format(@"<iframe width=""960"" height=""540"" src=""{0}"" frameborder=""0"" allowfullscreen></iframe>", "https://www.youtube.com/embed/P2THgDmPW2s");
            youtubeVideo.Controls.Add(videoFrame);

        }

        //============ if Parents infro clicked >
        //============ if Parents infro clicked >
        protected void e2_ServerClick(object sender, EventArgs e)
        {
            DivINFO2.Visible = true;
        }

        protected void InfoUpdate2_Click(object sender, EventArgs e)
        {
            DivVideo.Visible = true;

            var videoFrame = new Literal();
            videoFrame.Text = string.Format(@"<iframe width=""960"" height=""540"" src=""{0}"" frameborder=""0"" allowfullscreen></iframe>", "https://www.youtube.com/embed/7emqGZowZJ0");
            youtubeVideo.Controls.Add(videoFrame);
        }

        protected void InfoID2_Click(object sender, EventArgs e)
        {
            DivVideo.Visible = true;

            var videoFrame = new Literal();
            videoFrame.Text = string.Format(@"<iframe width=""960"" height=""540"" src=""{0}"" frameborder=""0"" allowfullscreen></iframe>", "https://www.youtube.com/embed/P2THgDmPW2s");
            youtubeVideo.Controls.Add(videoFrame);
        }

        protected void CancelInfo_Click(object sender, EventArgs e)
        {
            DivINFO.Visible = false;
            DivVideo.Visible = false;
            DivINFO2.Visible = false;
        }

    }
}