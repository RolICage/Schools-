using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using WebApplication1.Controllers;
using System.Web.UI.WebControls;

namespace WebApplication1
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        DataTable ChoolChecker = new DataTable();
        protected void Page_Load(object sender, EventArgs e)
        {
            //HomeController.CreateTableQustionsSolve(@"Data Source=SQL6007.site4now.net;Initial Catalog=DB_A50589_School1Data;User Id=DB_A50589_School1Data_admin;Password=need4speed123159");
            //HomeController.CreateTableStudentLogined(@"Data Source=SQL6007.site4now.net;Initial Catalog=DB_A50589_PublicData;User Id=DB_A50589_PublicData_admin;Password=need4speed123159;");

            if (!IsPostBack)
            {
                DropDownSelectSchool.Items.Add(new ListItem("KIDS", "1"));
                DropDownSelectSchool.Items.Add(new ListItem("Primary", "2"));
                DropDownSelectSchool.Items.Add(new ListItem("Preparatory", "3"));
            }
        }

        protected void AddSchoolNow_Click(object sender, EventArgs e)
        {
            string SchoolCode, SchoolPass, SchoolName, SchoolRank, Connection = "";

            SchoolName = TextSchoolName.Text.ToString();
            SchoolCode = TextSchoolID.Value.ToString();
            SchoolPass = TextSchoolPass.Text;
            SchoolRank = DropDownSelectSchool.SelectedValue.ToString();
            Connection = TextConnection.Text;

            if (!SchoolName.Equals("") && !SchoolCode.Equals("") && !SchoolPass.Equals("") && !SchoolRank.Equals("") && !Connection.Equals(""))
            {
                if (SchoolName.Length <= 20 && SchoolCode.Length <= 15 && SchoolPass.Length <= 15 && Connection.Length <= 150)
                {
                    ChoolChecker = HomeController.SelectSchoolByCode(SchoolCode);

                    if (ChoolChecker.Rows.Count == 0)
                    {
                        try
                        {
                            if (SchoolRank.Equals("3"))
                            {
                                HomeController.AddSchool(int.Parse(SchoolCode.ToString()), SchoolPass, SchoolName.ToString(), SchoolRank, Connection);

                                HomeController.AddClass("seven A", 71, Connection);
                                HomeController.AddClass("seven B", 72, Connection);
                                HomeController.AddClass("seven C", 73, Connection);

                                HomeController.AddClass("eight A", 81, Connection);
                                HomeController.AddClass("eight B", 82, Connection);
                                HomeController.AddClass("eight C", 83, Connection);

                                HomeController.AddClass("nine A", 91, Connection);
                                HomeController.AddClass("nine B", 92, Connection);
                                HomeController.AddClass("nine C", 93, Connection);
                            }


                            else if (SchoolRank.Equals("2"))
                            {
                                HomeController.AddSchool(int.Parse(SchoolCode.ToString()), SchoolPass, SchoolName, SchoolRank, Connection);

                                HomeController.AddClass("One A", 11, Connection);
                                HomeController.AddClass("One B", 12, Connection);
                                HomeController.AddClass("One C", 13, Connection);

                                HomeController.AddClass("Two A", 21, Connection);
                                HomeController.AddClass("Two B", 22, Connection);
                                HomeController.AddClass("Two C", 23, Connection);

                                HomeController.AddClass("Three A", 31, Connection);
                                HomeController.AddClass("Three B", 32, Connection);
                                HomeController.AddClass("Three C", 33, Connection);

                                HomeController.AddClass("four A", 41, Connection);
                                HomeController.AddClass("four B", 42, Connection);
                                HomeController.AddClass("four C", 43, Connection);

                                HomeController.AddClass("five A", 51, Connection);
                                HomeController.AddClass("five B", 52, Connection);
                                HomeController.AddClass("five C", 53, Connection);

                                HomeController.AddClass("six A", 61, Connection);
                                HomeController.AddClass("six B", 62, Connection);
                                HomeController.AddClass("six C", 63, Connection);
                            }

                            else if (SchoolRank.Equals("1"))
                            {
                                HomeController.AddSchoolKids(int.Parse(SchoolCode.ToString()), SchoolPass, SchoolName, SchoolRank, Connection);

                                HomeController.AddClass("KIDS A", -1, Connection);
                                HomeController.AddClass("KIDS B", -2, Connection);
                            }

                            HomeController.AddParents2("Ex Khaled", "205768474", 0523700846, Connection);

                            ChoolChecker = HomeController.SelectParentPublicDB("205768474");

                            if (ChoolChecker.Rows.Count == 0)
                            {
                               HomeController.AddParentsToPublicDB("205768474", SchoolCode.ToString());
                               HomeController.CreateAccount("205768474", "123456789", "P");
                            }

                             HomeController.AddStudent2("Ex Maher", "205879463", "205768474", 11, "0523700846","arara","24-08-1995", Connection);

                            DivMessage.Visible = true;
                            LabelMessage.Text = "School Added !";
                        }

                        catch (Exception x)
                        {
                            DivMessage.Visible = true;
                            LabelMessage.Text = "Connection String Is Not Ok !";
                        }

                    }


                    else
                    {
                        DivMessage.Visible = true;
                        LabelMessage.Text = "School Allready Added !";
                    }

                }

                else
                {
                    DivMessage.Visible = true;
                    LabelMessage.Text = "Max Characters in each row must be less than 16";
                }

            }

            else
            {
                DivMessage.Visible = true;
                LabelMessage.Text = "Fill Texts !";
            }

        }

        protected void ButtonMessage_Click(object sender, EventArgs e)
        {
            DivMessage.Visible = false;

            LabelMessage.Text = "";
        }
    }
}