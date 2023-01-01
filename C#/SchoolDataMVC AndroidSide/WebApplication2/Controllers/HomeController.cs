using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data;
using WebApplication2;
using System.Text;
using Twilio;
using Twilio.Rest.Api.V2010.Account;

namespace WebApplication2.Controllers
{

    public class HomeController : Controller
    {

        static public string SchoolDatabase = @"Data Source=SQL6007.site4now.net;Initial Catalog=DB_A50589_School1Data;User Id=DB_A50589_School1Data_admin;Password=need4speed123159;";
        static public string SchoolDatabaseKIDS = @"Data Source=SQL6007.site4now.net;Initial Catalog=DB_A50589_SchoolDataKids;User Id=DB_A50589_SchoolDataKids_admin;Password=need4speed123159;";
        static public string PublicDatabase = @"Data Source=SQL6007.site4now.net;Initial Catalog=DB_A50589_PublicData;User Id=DB_A50589_PublicData_admin;Password=need4speed123159;";
        // "Data Source=SQL6007.site4now.net;Initial Catalog=DB_A50589_SchoolDataKids;User Id=DB_A50589_SchoolDataKids_admin;Password=need4speed123159;"

        static public SqlConnection Con1 = new SqlConnection();
        static public SqlCommand Com1 = new SqlCommand(null);
        static public SqlDataAdapter Adapter = new SqlDataAdapter();
        static public DataTable MyDataTable = new DataTable();

        static public string SchoolCode = "748";



        //********************************************** May Use **********************************************
        //********************************************** May Use **********************************************


        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Contacts Is working";

            return View();
        }

        public void Tonull()
        {

        }



        public string ForTests()
        {
            try
            {
                string Quary;
                Com1.Parameters.Clear();

                Quary = "UPDATE Notification set Notifi = '" + "1" + "',Kind='" + "Message" + "' Where PID='" + "023423452" + "'";

                Con1.ConnectionString = PublicDatabase;
                Con1.Open();
                Com1.CommandText = Quary;
                Com1.Connection = Con1;
                Com1.Parameters.Add("@Notifi", SqlDbType.VarChar).Value = "1";
                Com1.Parameters.Add("@Kind", SqlDbType.VarChar).Value = "Message";
                Com1.ExecuteNonQuery();
            }

            catch(Exception e)
            {
                return e.Message.ToString();
            }

            finally
            {
                Con1.Close();
            }

            return "worked";
        }

        public void TestCode()
        {
            string DayName = "";
            DateTime dateValue = new DateTime(2021, 01, 17);
            DayName = dateValue.DayOfWeek.ToString();
        }
//[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[REMOVER]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]
//[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[REMOVER]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]
        public string RemoveallrowsinPublicData()
        {

            ////////////////////////
            ////////////////////////
            Con1 = new SqlConnection();
            Com1 = new SqlCommand(null);

            try
            {
                string query;
                query = "DELETE from SchoolTID";
                Con1.ConnectionString = PublicDatabase;
                Con1.Open();
                Com1.CommandText = query;
                Com1.Connection = Con1;

                Com1.ExecuteNonQuery();

            }
            catch (Exception a)
            {
                return a.Message + "Table Error" + a.ToString();
            }
            finally
            {
                Con1.Close();
            }

            ////////////////////////
            ////////////////////////
            Con1 = new SqlConnection();
            Com1 = new SqlCommand(null);

            try
            {
                string query;
                query = "DELETE from SchoolPID";
                Con1.ConnectionString = PublicDatabase;
                Con1.Open();
                Com1.CommandText = query;
                Com1.Connection = Con1;

                Com1.ExecuteNonQuery();

            }
            catch (Exception a)
            {
                return a.Message + "Table Error" + a.ToString();
            }
            finally
            {
                Con1.Close();
            }


            ////////////////////////
            ////////////////////////
            Con1 = new SqlConnection();
            Com1 = new SqlCommand(null);

            try
            {
                string query;
                query = "DELETE from ParentsLogin";
                Con1.ConnectionString = PublicDatabase;
                Con1.Open();
                Com1.CommandText = query;
                Com1.Connection = Con1;

                Com1.ExecuteNonQuery();

            }
            catch (Exception a)
            {
                return a.Message + "Table Error" + a.ToString();
            }
            finally
            {
                Con1.Close();
            }



            ////////////////////////
            ////////////////////////
            Con1 = new SqlConnection();
            Com1 = new SqlCommand(null);

            try
            {
                string query;
                query = "DELETE from Notification";
                Con1.ConnectionString = PublicDatabase;
                Con1.Open();
                Com1.CommandText = query;
                Com1.Connection = Con1;

                Com1.ExecuteNonQuery();

            }
            catch (Exception a)
            {
                return a.Message + "Table Error" + a.ToString();
            }
            finally
            {
                Con1.Close();
            }


            ////////////////////////
            ////////////////////////
            Con1 = new SqlConnection();
            Com1 = new SqlCommand(null);

            try
            {
                string query;
                query = "DELETE from Logintecher";
                Con1.ConnectionString = PublicDatabase;
                Con1.Open();
                Com1.CommandText = query;
                Com1.Connection = Con1;

                Com1.ExecuteNonQuery();

            }
            catch (Exception a)
            {
                return a.Message + "Table Error" + a.ToString();
            }
            finally
            {
                Con1.Close();
            }


            //////////////////////
            //////////////////////
            Con1 = new SqlConnection();
            Com1 = new SqlCommand(null);

            try
            {
                string query;
                query = "DELETE from Connections";
                Con1.ConnectionString = PublicDatabase;
                Con1.Open();
                Com1.CommandText = query;
                Com1.Connection = Con1;

                Com1.ExecuteNonQuery();

            }
            catch (Exception a)
            {
                return a.Message + "Table Error" + a.ToString();
            }
            finally
            {
                Con1.Close();
            }


            Con1 = new SqlConnection();
            Com1 = new SqlCommand(null);

            try
            {
                string query;
                query = "DELETE from SLogin";
                Con1.ConnectionString = PublicDatabase;
                Con1.Open();
                Com1.CommandText = query;
                Com1.Connection = Con1;

                Com1.ExecuteNonQuery();

            }
            catch (Exception a)
            {
                return a.Message + "Table Error" + a.ToString();
            }
            finally
            {
                Con1.Close();
            }

            return "Removed";
   
        }


        public string RemoveTabel()
        {
            Tonull();
            Con1 = new SqlConnection();
            Com1 = new SqlCommand(null);

            try
            {
                string query;
                query = "DROP TABLE Parents";
                Con1.ConnectionString = SchoolDatabase;
                Con1.Open();
                Com1.CommandText = query;
                Com1.Connection = Con1;

                Com1.ExecuteNonQuery();

            }
            catch (Exception a)
            {
                return a.Message + "Table Error" + a.ToString();
            }
            finally
            {
                Con1.Close();
            }

            return "Removed";
        }






        public string IDMAKER()
        {

            int num1, save1, i = -1;
            string ID = "";


            int until = 0;

            while (until == 0)
            {
                Random rnd = new Random();
                int IDRand = rnd.Next(111111111, 999999999);
                ID = IDRand.ToString();

                num1 = 0;
                while (++i != 9)
                {
                    if (i % 2 == 0) num1 += int.Parse(ID[i].ToString());
                    else
                    {
                        save1 = 2 * int.Parse(ID[i].ToString());
                        num1 += save1 % 10 + save1 / 10;
                    }
                }


                if (num1 % 10 == 0)
                {
                    return ID;
                }

                else
                {
                    until = 0;
                    i = -1;
                    num1 = 0;
                    save1 = 0;
                    ID = "";
                }
            }

            return ID;

        }

        public string RemoveSTabelRows()
        {
            Tonull();
            Con1 = new SqlConnection();
            Com1 = new SqlCommand(null);

            try
            {
                string query;
                query = "DELETE from QustionsSolve";
                Con1.ConnectionString = SchoolDatabase;
                Con1.Open();
                Com1.CommandText = query;
                Com1.Connection = Con1;

                Com1.ExecuteNonQuery();

            }
            catch (Exception a)
            {
                return a.Message + "Table Error" + a.ToString();
            }
            finally
            {
                Con1.Close();
            }

            return "Removed";
        }



        public string RemoveSTabelRows2()
        {
            Tonull();
            Con1 = new SqlConnection();
            Com1 = new SqlCommand(null);

            try
            {
                string query;
                query = "DELETE from SLogin where SchoolCode='" + "123456789" + "'";
                Con1.ConnectionString = PublicDatabase;
                Con1.Open();
                Com1.CommandText = query;
                Com1.Connection = Con1;

                Com1.ExecuteNonQuery();

            }
            catch (Exception a)
            {
                return a.Message + "Table Error" + a.ToString();
            }
            finally
            {
                Con1.Close();
            }

            return "Removed";
        }


        public string test()
        {
            return "Working";
        }


        public string CreateTebels()
        {
            string Result = "";


            try
            {
                Result += CreateTableParents();
                Result += " -------------> ";
                Result += CreateTableClasses();
                Result += " -------------> ";
                Result += CreateTableStudents();
                Result += " -------------> ";
                Result += CreateTableMarks();
                Result += " -------------> ";
                Result += CreateTableMessages();
                Result += " -------------> ";
                Result += CreateTableSubjects();
                Result += " -------------> ";
                Result += CreateTableTechers();
                Result += " -------------> ";
                Result += CreateTableSubjectsTecher();
                Result += " -------------> ";
                Result += CreateTableClassTechers();
                Result += " -------------> ";
                Result += CreateTableImages();
                Result += " -------------> ";
                Result += CreateTableImagesAndroid();
                Result += " -------------> ";
                Result += CreateTabelTecherSchedule();
            }

            catch (Exception e)
            {
                Result += "Error" + e.Message.ToString() + "`";
            }

            if (Result[Result.Length - 1].Equals('`'))
            {
                return Result;
            }
            else
            {
                return "All Tabels Created !";
            }
        }


        //================================================= Android Parents Side Functions =================================================>
        //================================================= Android Parents Side Functions =================================================>
        //================================================= Android Parents Side Functions =================================================>



        static private DataTable SelectData(string Quary, string @StrConnection)
        {
            string Corrector = @"";
            @Corrector += @StrConnection;

            SqlConnection Connection = new SqlConnection(@Corrector);


            DataTable dt = new DataTable();

            Com1.CommandText = Quary;
            Com1.Connection = Connection;

            Adapter.SelectCommand = Com1;
            try
            {
                Connection.Open();
                Adapter.Fill(dt);
                return dt;
            }
            catch (Exception e)
            {
                throw e;
            }
            finally
            {
                Connection.Close();
            }
        }


        public string GetSelectedHWorkSubject(string WCode, string @Connection)
        {
            DataTable DT = new DataTable();
            string StringWorks = "";

            string Query = "SELECT SubName from Works Where WCode ='" + WCode + "'";
            DT = SelectData(Query, @Connection);

            if (DT.Rows.Count != 0)
                return DT.Rows[0][0].ToString();
           
            return "";
        }

        public string RemoveHWork(string WCode,string @Connection)
        {
            try
            {
                string Query = "DELETE from QustionsSolve Where WCode ='" + WCode + "'";
                SelectData(Query, @Connection);

                Query = "DELETE from Qustions Where WCode ='" + WCode + "'";
                SelectData(Query, @Connection);

                Query = "DELETE from QustionsA Where WCode ='" + WCode + "'";
                SelectData(Query, @Connection);

                Query = "DELETE from Works Where WCode ='" + WCode + "'";
                SelectData(Query, @Connection);
            }

            catch(Exception e)
            {
                return e.Message;
            }

            return "OK";
        }

        public string GetHomeWorks(string TID,string ClassCode,string @Connection)
        {
            DataTable DT = new DataTable();
            string StringWorks = "";

            string Query = "SELECT * from Works Where TID ='" + TID + "' AND ClassCode ='"+ClassCode+"'";
            DT = SelectData(Query, @Connection);

            for(int i=0;i<DT.Rows.Count;i++)
            {
                StringWorks += DT.Rows[i][2] + "#";
                StringWorks += DT.Rows[i][3] + "#";
                StringWorks += DT.Rows[i][4] + "#";               
            }
            StringWorks += "*";

            return StringWorks;
        }

        public string GetHomeWorksStudent(string ClassCode, string @Connection)
        {
            DataTable DT = new DataTable();
            DataTable DTCheck = new DataTable();
            string StringWorks = "";

            string Query = "SELECT * from Works Where ClassCode ='" + ClassCode + "'";
            DT = SelectData(Query, @Connection);

            for (int i = 0; i < DT.Rows.Count; i++)
            {
                StringWorks += DT.Rows[i][2] + "#";
                StringWorks += DT.Rows[i][3] + "#";
                StringWorks += DT.Rows[i][4] + "#";

                Query = "SELECT * from QustionsSolve Where WCode ='" + DT.Rows[i][2] + "'";
                DTCheck = SelectData(Query, @Connection);

                if (DTCheck.Rows.Count != 0)
                    StringWorks += "1";
                else
                    StringWorks += "0";

                StringWorks += "#";

            }
            StringWorks += "*";

            return StringWorks;
        }

        public string GetHomeWorkQustions(string WCode, string @Connection)
        {
            DataTable DT = new DataTable();
            string AllQustions = "";

            try
            {
                string Query = "SELECT * from Qustions Where WCode ='" + WCode + "'";
                DT = SelectData(Query, @Connection);

                for (int i = 0; i < DT.Rows.Count; i++)
                {
                    AllQustions += DT.Rows[i][0] + "#";
                    AllQustions += DT.Rows[i][1] + "#";
                    AllQustions += DT.Rows[i][2] + "#";
                    AllQustions += DT.Rows[i][3] + "#";
                    AllQustions += DT.Rows[i][4] + "#";
                }
                AllQustions += "*";
            }

            catch(Exception e)
            {
                return "*";
            }

            return AllQustions;
        }

        public string GetHomeWorkQustionsA(string WCode, string @Connection)
        {
            DataTable DT = new DataTable();
            string AllQustions = "";

            try
            {
                string Query = "SELECT * from QustionsA Where WCode ='" + WCode + "'";
                DT = SelectData(Query, @Connection);

                for (int i = 0; i < DT.Rows.Count; i++)
                {
                    AllQustions += DT.Rows[i][0] + "#";
                    AllQustions += DT.Rows[i][1] + "#";
                    AllQustions += DT.Rows[i][2] + "#";
                    AllQustions += DT.Rows[i][3] + "#";
                    AllQustions += DT.Rows[i][4] + "#";
                    AllQustions += DT.Rows[i][5] + "#";
                    AllQustions += DT.Rows[i][6] + "#";
                    AllQustions += DT.Rows[i][7] + "#";
                    AllQustions += DT.Rows[i][8] + "#";
                }
                AllQustions += "*";
            }

            catch (Exception e)
            {
                return "*";
            }

            return AllQustions;
        }

        public string GetHomeWorkQustionsSolve(string WCode, string @Connection)
        {
            DataTable DT = new DataTable();
            DataTable DTSolve = new DataTable();
            string AllQustions = "";

            try
            {
                string Query = "SELECT * from Qustions Where WCode ='" + WCode + "'";
                DT = SelectData(Query, @Connection);

                for (int i = 0; i < DT.Rows.Count; i++)
                {
                    AllQustions += DT.Rows[i][0] + "#";
                    AllQustions += DT.Rows[i][1] + "#";
                    AllQustions += DT.Rows[i][2] + "#";
                    AllQustions += DT.Rows[i][3] + "#";
                    AllQustions += DT.Rows[i][4] + "#";

                    Query = "SELECT * from QustionsSolve Where WCode ='" + WCode + "' AND QCode ='"+ DT.Rows[i][1].ToString()+"'";
                    DTSolve = SelectData(Query, @Connection);
                    AllQustions += DTSolve.Rows[0][3] + "#";
                }
                AllQustions += "*";
            }

            catch (Exception e)
            {
                return "*";
            }

            return AllQustions;
        }

        public string GetHomeWorkQustionsSolveA(string WCode, string @Connection)
        {
            DataTable DT = new DataTable();
            DataTable DTSolve = new DataTable();
            string AllQustions = "";

            try
            {
                string Query = "SELECT * from QustionsA Where WCode ='" + WCode + "'";
                DT = SelectData(Query, @Connection);

                for (int i = 0; i < DT.Rows.Count; i++)
                {
                    AllQustions += DT.Rows[i][0] + "#";
                    AllQustions += DT.Rows[i][1] + "#";
                    AllQustions += DT.Rows[i][2] + "#";
                    AllQustions += DT.Rows[i][3] + "#";
                    AllQustions += DT.Rows[i][4] + "#";
                    AllQustions += DT.Rows[i][5] + "#";
                    AllQustions += DT.Rows[i][6] + "#";
                    AllQustions += DT.Rows[i][7] + "#";
                    AllQustions += DT.Rows[i][8] + "#";

                    Query = "SELECT * from QustionsSolve Where WCode ='" + WCode + "' AND QCode ='" + DT.Rows[i][1].ToString() + "'";
                    DTSolve = SelectData(Query, @Connection);
                    AllQustions += DTSolve.Rows[0][3] + "#";
                }
                AllQustions += "*";
            }

            catch (Exception e)
            {
                return "*";
            }

            return AllQustions;
        }

        public string InsertHWorkSolve(string WCode, string QAnswers, string SID, string @Connection)
        {
            string Quary = "", Answer = "", QKind = "", QCode = "";
            char ch;
            int cnt = 0;


            if (!QAnswers.ToString().Equals("*"))
            {
                ch = QAnswers[cnt++];
                while (ch != '*')
                {
                    ///////// Get QCode
                    while (ch != '`')
                    {
                        QCode += ch;
                        ch = QAnswers[cnt++];
                    }
                    ch = QAnswers[cnt++];

                    ///////// Get QKind
                    while (ch != '`')
                    {
                        Answer += ch;
                        ch = QAnswers[cnt++];
                    }
                    ch = QAnswers[cnt++];

                    ///////// Get Answer
                    while (ch != '`')
                    {
                        QKind += ch;
                        ch = QAnswers[cnt++];
                    }
                    ch = QAnswers[cnt++];


                    ///////////// Insert QSolve TO DB
                    try
                    {
                        Com1.Parameters.Clear();
                        Quary = "insert into QustionsSolve(WCode,QCode,QKind,Answer,SID)  values(@WCode,@QCode,@QKind,@Answer,@SID)";
                        Con1 = new SqlConnection(@Connection);
                        Con1.Open();
                        Com1 = new SqlCommand(Quary, Con1);
                        Com1.Parameters.Add("@WCode", SqlDbType.VarChar).Value = WCode.ToString();
                        Com1.Parameters.Add("@QCode", SqlDbType.VarChar).Value = QCode.ToString();
                        Com1.Parameters.Add("@QKind", SqlDbType.VarChar).Value = QKind.ToString();
                        Com1.Parameters.Add("@Answer", SqlDbType.NVarChar).Value = Answer.ToString();
                        Com1.Parameters.Add("@SID", SqlDbType.VarChar).Value = SID.ToString();
                        Com1.ExecuteNonQuery();
                    }

                    catch (Exception e)
                    {
                        return "Error";
                    }

                    finally
                    {
                        Con1.Close();
                    }

                    Answer = "";
                    QCode = "";
                    QKind = "";
                }
            }

            return "OK";
        }

        public string InsertNewHWork(string Qustions, string QustionsA, string TID, string ClassCode, string SubName, string Per, string @Connection)
        {
            char ch;
            int cnt = 0;
            string QCode = "", QKind = "", Qustion = "", QPer = "", Quary = "", WCode = "0";
            string A1 = "", A2 = "", A3 = "", A4 = "", A5 = "";


            ///////////////////// Generating New WCode For HWork
            ///////////////////// Generating New WCode For HWork
            while (WCode.ToString().Equals("0"))
                WCode = GenerateRandomCode(@Connection);

            /////////////////// Add HWork to DB
            try
            {
                Com1.Parameters.Clear();
                Quary = "insert into Works(TID,ClassCode,WCode,SubName,Per)  values(@TID,@ClassCode,@WCode,@SubName,@Per)";
                Con1 = new SqlConnection(@Connection);
                Con1.Open();
                Com1 = new SqlCommand(Quary, Con1);
                Com1.Parameters.Add("@TID", SqlDbType.VarChar).Value = TID.ToString();
                Com1.Parameters.Add("@ClassCode", SqlDbType.Int).Value = int.Parse(ClassCode.ToString());
                Com1.Parameters.Add("@WCode", SqlDbType.VarChar).Value = WCode.ToString();
                Com1.Parameters.Add("@SubName", SqlDbType.NVarChar).Value = SubName.ToString();
                Com1.Parameters.Add("@Per", SqlDbType.Int).Value = int.Parse(Per.ToString());
                Com1.ExecuteNonQuery();
            }

            catch (Exception e)
            {
                return "Error";
            }

            finally
            {
                Con1.Close();
            }

            ///////////////////// Add List Qustions To DB
            if (!Qustions.ToString().Equals(""))
            {
                ch = Qustions[cnt++];
                while (ch != '*')
                {
                    ///////// Get QCode
                    while (ch != '`')
                    {
                        QCode += ch;
                        ch = Qustions[cnt++];
                    }
                    ch = Qustions[cnt++];

                    ///////// Get QKind
                    while (ch != '`')
                    {
                        QKind += ch;
                        ch = Qustions[cnt++];
                    }
                    ch = Qustions[cnt++];

                    ///////// Get Qustion
                    while (ch != '`')
                    {
                        Qustion += ch;
                        ch = Qustions[cnt++];
                    }
                    ch = Qustions[cnt++];

                    ///////// Get QPer
                    while (ch != '`')
                    {
                        QPer += ch;
                        ch = Qustions[cnt++];
                    }
                    ch = Qustions[cnt++];


                    /////////////////// Add Qustion to DB
                    try
                    {
                        Com1.Parameters.Clear();
                        Quary = "insert into Qustions(WCode,QCode,QKind,Qustion,QPer)  values(@WCode,@QCode,@QKind,@Qustion,@QPer)";
                        Con1 = new SqlConnection(@Connection);
                        Con1.Open();
                        Com1 = new SqlCommand(Quary, Con1);
                        Com1.Parameters.Add("@WCode", SqlDbType.VarChar).Value = WCode.ToString();
                        Com1.Parameters.Add("@QCode", SqlDbType.VarChar).Value = QCode.ToString();
                        Com1.Parameters.Add("@QKind", SqlDbType.VarChar).Value = QKind.ToString();
                        Com1.Parameters.Add("@Qustion", SqlDbType.NVarChar).Value = Qustion.ToString();
                        Com1.Parameters.Add("@QPer", SqlDbType.Int).Value = int.Parse(QPer.ToString());
                        Com1.ExecuteNonQuery();
                    }

                    catch (Exception e)
                    {
                        return "Error " + e.Message;
                    }

                    finally
                    {
                        Con1.Close();
                    }

                    QCode = "";
                    QKind = "";
                    Qustion = "";
                    QPer = "";
                }
                cnt = 0;
            }

            ///////////////////// Add List QustionsA To DB
            if (!QustionsA.ToString().Equals("*"))
            {
                ch = QustionsA[cnt++];
                while (ch != '*')
                {
                    ///////// Get QCode
                    while (ch != '`')
                    {
                        QCode += ch;
                        ch = QustionsA[cnt++];
                    }
                    ch = QustionsA[cnt++];

                    ///////// Get Qustion
                    while (ch != '`')
                    {
                        Qustion += ch;
                        ch = QustionsA[cnt++];
                    }
                    ch = QustionsA[cnt++];

                    ///////// Get Qustion
                    while (ch != '`')
                    {
                        A1 += ch;
                        ch = QustionsA[cnt++];
                    }
                    ch = QustionsA[cnt++];

                    ///////// Get Qustion
                    while (ch != '`')
                    {
                        A2 += ch;
                        ch = QustionsA[cnt++];
                    }
                    ch = QustionsA[cnt++];

                    ///////// Get Qustion
                    while (ch != '`')
                    {
                        A3 += ch;
                        ch = QustionsA[cnt++];
                    }
                    ch = QustionsA[cnt++];

                    ///////// Get Qustion
                    while (ch != '`')
                    {
                        A4 += ch;
                        ch = QustionsA[cnt++];
                    }
                    ch = QustionsA[cnt++];

                    ///////// Get Qustion
                    while (ch != '`')
                    {
                        A5 += ch;
                        ch = QustionsA[cnt++];
                    }
                    ch = QustionsA[cnt++];

                    ///////// Get QPer
                    while (ch != '`')
                    {
                        QPer += ch;
                        ch = QustionsA[cnt++];
                    }
                    ch = QustionsA[cnt++];


                    /////////////////// Add Qustion to DB
                    try
                    {
                        Com1.Parameters.Clear();
                        Quary = "insert into QustionsA(WCode,QCode,Qustion,A1,A2,A3,A4,A5,QPer)  values(@WCode,@QCode,@Qustion,@A1,@A2,@A3,@A4,@A5,@QPer)";
                        Con1 = new SqlConnection(@Connection);
                        Con1.Open();
                        Com1 = new SqlCommand(Quary, Con1);
                        Com1.Parameters.Add("@WCode", SqlDbType.VarChar).Value = WCode;
                        Com1.Parameters.Add("@QCode", SqlDbType.VarChar).Value = QCode;
                        Com1.Parameters.Add("@Qustion", SqlDbType.NVarChar).Value = Qustion;
                        Com1.Parameters.Add("@A1", SqlDbType.NVarChar).Value = A1;
                        Com1.Parameters.Add("@A2", SqlDbType.NVarChar).Value = A2;
                        Com1.Parameters.Add("@A3", SqlDbType.NVarChar).Value = A3;
                        Com1.Parameters.Add("@A4", SqlDbType.NVarChar).Value = A4;
                        Com1.Parameters.Add("@A5", SqlDbType.NVarChar).Value = A5;
                        Com1.Parameters.Add("@QPer", SqlDbType.Int).Value = int.Parse(QPer.ToString());
                        Com1.ExecuteNonQuery();
                    }

                    catch (Exception e)
                    {
                        return "Error " + e.Message;
                    }

                    finally
                    {
                        Con1.Close();
                    }

                    QCode = "";
                    Qustion = "";
                    A1 = "";
                    A2 = "";
                    A3 = "";
                    A4 = "";
                    A5 = "";
                    QPer = "";
                }
            }

            return "OK";
        }

        public string UpdateHWork(string WCodeOld, string Qustions, string QustionsA, string TID, string ClassCode, string SubName, string Per, string @Connection)
        {
            char ch;
            int cnt = 0;
            string QCode = "", QKind = "", Qustion = "", QPer = "", Quary = "", WCode = "0";
            string A1 = "", A2 = "", A3 = "", A4 = "", A5 = "";


            //////////////////////// Remove Old HWork
            //////////////////////// Remove Old HWork
            string Query = "DELETE from QustionsSolve Where WCode ='" + WCodeOld + "'";
            SelectData(Query, @Connection);

            Query = "DELETE from Qustions Where WCode ='" + WCodeOld + "'";
            SelectData(Query, @Connection);

            Query = "DELETE from QustionsA Where WCode ='" + WCodeOld + "'";
            SelectData(Query, @Connection);

            Query = "DELETE from Works Where WCode ='" + WCodeOld + "'";
            SelectData(Query, @Connection);


            ///////////////////// Generating New WCode For HWork
            ///////////////////// Generating New WCode For HWork
            while (WCode.ToString().Equals("0"))
                WCode = GenerateRandomCode(@Connection);

            /////////////////// Add HWork to DB
            try
            {
                Com1.Parameters.Clear();
                Quary = "insert into Works(TID,ClassCode,WCode,SubName,Per)  values(@TID,@ClassCode,@WCode,@SubName,@Per)";
                Con1 = new SqlConnection(@Connection);
                Con1.Open();
                Com1 = new SqlCommand(Quary, Con1);
                Com1.Parameters.Add("@TID", SqlDbType.VarChar).Value = TID.ToString();
                Com1.Parameters.Add("@ClassCode", SqlDbType.Int).Value = int.Parse(ClassCode.ToString());
                Com1.Parameters.Add("@WCode", SqlDbType.VarChar).Value = WCode.ToString();
                Com1.Parameters.Add("@SubName", SqlDbType.NVarChar).Value = SubName.ToString();
                Com1.Parameters.Add("@Per", SqlDbType.Int).Value = int.Parse(Per.ToString());
                Com1.ExecuteNonQuery();
            }

            catch (Exception e)
            {
                return "Qustion Error";
            }

            finally
            {
                Con1.Close();
            }

            ///////////////////// Add List Qustions To DB
            if (!Qustions.ToString().Equals("*"))
            {
                ch = Qustions[cnt++];
                while (ch != '*')
                {
                    ///////// Get QCode
                    while (ch != '`')
                    {
                        QCode += ch;
                        ch = Qustions[cnt++];
                    }
                    ch = Qustions[cnt++];

                    ///////// Get QKind
                    while (ch != '`')
                    {
                        QKind += ch;
                        ch = Qustions[cnt++];
                    }
                    ch = Qustions[cnt++];

                    ///////// Get Qustion
                    while (ch != '`')
                    {
                        Qustion += ch;
                        ch = Qustions[cnt++];
                    }
                    ch = Qustions[cnt++];

                    ///////// Get QPer
                    while (ch != '`')
                    {
                        QPer += ch;
                        ch = Qustions[cnt++];
                    }
                    ch = Qustions[cnt++];


                    /////////////////// Add Qustion to DB
                    try
                    {
                        Com1.Parameters.Clear();
                        Quary = "insert into Qustions(WCode,QCode,QKind,Qustion,QPer)  values(@WCode,@QCode,@QKind,@Qustion,@QPer)";
                        Con1 = new SqlConnection(@Connection);
                        Con1.Open();
                        Com1 = new SqlCommand(Quary, Con1);
                        Com1.Parameters.Add("@WCode", SqlDbType.VarChar).Value = WCode.ToString();
                        Com1.Parameters.Add("@QCode", SqlDbType.VarChar).Value = QCode.ToString();
                        Com1.Parameters.Add("@QKind", SqlDbType.VarChar).Value = QKind.ToString();
                        Com1.Parameters.Add("@Qustion", SqlDbType.NVarChar).Value = Qustion.ToString();
                        Com1.Parameters.Add("@QPer", SqlDbType.Int).Value = int.Parse(QPer.ToString());
                        Com1.ExecuteNonQuery();
                    }

                    catch (Exception e)
                    {
                        return "Work Error";
                    }

                    finally
                    {
                        Con1.Close();
                    }

                    QCode = "";
                    QKind = "";
                    Qustion = "";
                    QPer = "";
                }
                cnt = 0;
            }

            ///////////////////// Add List QustionsA To DB
            if (!QustionsA.ToString().Equals("*"))
            {
                ch = QustionsA[cnt++];
                while (ch != '*')
                {
                    ///////// Get QCode
                    while (ch != '`')
                    {
                        QCode += ch;
                        ch = QustionsA[cnt++];
                    }
                    ch = QustionsA[cnt++];

                    ///////// Get Qustion
                    while (ch != '`')
                    {
                        Qustion += ch;
                        ch = QustionsA[cnt++];
                    }
                    ch = QustionsA[cnt++];

                    ///////// Get Qustion
                    while (ch != '`')
                    {
                        A1 += ch;
                        ch = QustionsA[cnt++];
                    }
                    ch = QustionsA[cnt++];

                    ///////// Get Qustion
                    while (ch != '`')
                    {
                        A2 += ch;
                        ch = QustionsA[cnt++];
                    }
                    ch = QustionsA[cnt++];

                    ///////// Get Qustion
                    while (ch != '`')
                    {
                        A3 += ch;
                        ch = QustionsA[cnt++];
                    }
                    ch = QustionsA[cnt++];

                    ///////// Get Qustion
                    while (ch != '`')
                    {
                        A4 += ch;
                        ch = QustionsA[cnt++];
                    }
                    ch = QustionsA[cnt++];

                    ///////// Get Qustion
                    while (ch != '`')
                    {
                        A5 += ch;
                        ch = QustionsA[cnt++];
                    }
                    ch = QustionsA[cnt++];

                    ///////// Get QPer
                    while (ch != '`')
                    {
                        QPer += ch;
                        ch = QustionsA[cnt++];
                    }
                    ch = QustionsA[cnt++];


                    /////////////////// Add Qustion to DB
                    try
                    {
                        Com1.Parameters.Clear();
                        Quary = "insert into QustionsA(WCode,QCode,Qustion,A1,A2,A3,A4,A5,QPer)  values(@WCode,@QCode,@Qustion,@A1,@A2,@A3,@A4,@A5,@QPer)";
                        Con1 = new SqlConnection(@Connection);
                        Con1.Open();
                        Com1 = new SqlCommand(Quary, Con1);
                        Com1.Parameters.Add("@WCode", SqlDbType.VarChar).Value = WCode;
                        Com1.Parameters.Add("@QCode", SqlDbType.VarChar).Value = QCode;
                        Com1.Parameters.Add("@Qustion", SqlDbType.NVarChar).Value = Qustion;
                        Com1.Parameters.Add("@A1", SqlDbType.NVarChar).Value = A1;
                        Com1.Parameters.Add("@A2", SqlDbType.NVarChar).Value = A2;
                        Com1.Parameters.Add("@A3", SqlDbType.NVarChar).Value = A3;
                        Com1.Parameters.Add("@A4", SqlDbType.NVarChar).Value = A4;
                        Com1.Parameters.Add("@A5", SqlDbType.NVarChar).Value = A5;
                        Com1.Parameters.Add("@QPer", SqlDbType.Int).Value = int.Parse(QPer.ToString());
                        Com1.ExecuteNonQuery();
                    }

                    catch (Exception e)
                    {
                        return "QustionA Error";
                    }

                    finally
                    {
                        Con1.Close();
                    }

                    QCode = "";
                    Qustion = "";
                    A1 = "";
                    A2 = "";
                    A3 = "";
                    A4 = "";
                    A5 = "";
                    QPer = "";
                }
            }

            return "OK";
        }

        public string GenerateRandomCode(string @Connection)
        {
            var chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789";
            var stringChars = new char[9];
            var random = new Random();

            for (int i = 0; i < stringChars.Length; i++)
            {
                stringChars[i] = chars[random.Next(chars.Length)];
            }

            var finalString = new String(stringChars);

            string check = "0";

            check= CheckHWorkCode(finalString, @Connection);

            if (check.ToString().Equals("1"))
                return finalString.ToString();

            else
                return "0";     
        }

        public string CheckHWorkCode(string WCode,string @Connection)
        {
            DataTable DT = new DataTable();

            string Query = "Select * from Works Where WCode  ='" + WCode + "'";
            DT = SelectData(Query, @Connection);

            if (DT.Rows.Count == 1)
                return "0";
            else
                return "1";
        }

        public string GetGPSInfo(string SID)
        {
            DataTable DT = new DataTable();
            string Info = "";

            string Query = "Select * from GPS Where SID ='" + SID + "'";
            DT = SelectData(Query, @PublicDatabase);

            if (DT.Rows.Count != 0)
            {
                Info = DT.Rows[0][1].ToString();
                Info += "#";
                Info += DT.Rows[0][2].ToString();
                Info += "#";
                Info += DT.Rows[0][3].ToString();
                Info += "#";
                Info += DT.Rows[0][4].ToString();
                Info += "#";
                Info += DT.Rows[0][5].ToString();
                Info += "#*";
                return Info;
            }
            else
                return "";
        }

        public string UpdateGPS(string SID,string Lat,string Long,string address, string Name,string Postal)
        {
            DataTable VlaueResult = new DataTable();

            string Quary = "SELECT * from GPS Where SID ='" + SID + "'";
            VlaueResult = SelectData(Quary, @PublicDatabase);

            Com1.Parameters.Clear();

            if (VlaueResult.Rows.Count==0)
            {
                try
                {
                    Quary = "insert into GPS(SID,Lat,Long,address,Name,Postal)  values(@SID,@Lat,@Long,@address,@Name,@Postal)";
                    Con1 = new SqlConnection(@PublicDatabase);
                    Con1.Open();
                    Com1 = new SqlCommand(Quary, Con1);
                    Com1.Parameters.Add("@SID", SqlDbType.VarChar).Value = SID;
                    Com1.Parameters.Add("@Lat", SqlDbType.VarChar).Value = Lat;
                    Com1.Parameters.Add("@Long", SqlDbType.VarChar).Value = Long;
                    Com1.Parameters.Add("@address", SqlDbType.VarChar).Value = address;
                    Com1.Parameters.Add("@Name", SqlDbType.VarChar).Value = Name;
                    Com1.Parameters.Add("@Postal", SqlDbType.VarChar).Value = Postal;
                    Com1.ExecuteNonQuery();
                }

                catch(Exception e)
                {
                    return e.Message.ToString();
                }

                finally
                {
                    Con1.Close();
                }
            }

            else
            {
                try
                {
                    Quary = "UPDATE GPS set Lat = '" + Lat + "' , Long ='" + Long + "' , address ='" + address + "' , Name='" + Name + "' , Postal ='" + Postal + "' Where SID='" + SID + "'";
                    Con1.ConnectionString = PublicDatabase;
                    Con1.Open();
                    Com1.CommandText = Quary;
                    Com1.Connection = Con1;
                    Com1.Parameters.Add("@Lat", SqlDbType.VarChar).Value = Lat;
                    Com1.Parameters.Add("@Long", SqlDbType.VarChar).Value = Long;
                    Com1.Parameters.Add("@address", SqlDbType.VarChar).Value = address;
                    Com1.Parameters.Add("@Name", SqlDbType.VarChar).Value = Name;
                    Com1.Parameters.Add("@Postal", SqlDbType.VarChar).Value = Postal;
                    Com1.ExecuteNonQuery();
                    Con1.Close();
                }

                catch (Exception e)
                {
                    return e.Message.ToString();
                }

                finally
                {
                    Con1.Close();
                }
            }
       
            return "";
        }

        public string GetClassCodbySID(string SID,string @Connection)
        {
            string Query = "Select ClassCode from Students Where SID ='" + SID + "'";
            string SID2= SelectData(Query, @Connection).Rows[0][0].ToString();
            return SID2;
        }

        public string CheckPerExam(string ClassCode,string SubName, string Chapter,string per, string @Connection)
        {
            string Query = "SELECT per from Exams Where ClassCode='" + ClassCode + "' AND SubName=N'" + SubName + "' AND Chapter='" + Chapter + "'";
            DataTable DT = SelectData(Query, @Connection);

            int Perc = int.Parse(per.ToString());

            for (int i = 0; i < DT.Rows.Count; i++)
                Perc +=int.Parse(DT.Rows[i][0].ToString());

            if (Perc<=100)
                return "1";

            else
                return "0";
        }

        public string GetExamsClass(string ClassCode, string @Connection)
        {
            int Cnt = 0;
            string FinalString = "";
            DataTable VlaueResult = new DataTable();

            try
            {
                string Q = "SELECT * from Exams Where ClassCode ='" + ClassCode + "'";
                VlaueResult = SelectData(Q, @Connection);

                while (Cnt < VlaueResult.Rows.Count)
                {
                    FinalString += VlaueResult.Rows[Cnt][5].ToString();
                    FinalString += "#";

                    FinalString += VlaueResult.Rows[Cnt][2].ToString();
                    FinalString += "#";

                    FinalString += VlaueResult.Rows[Cnt][3].ToString();
                    FinalString += "#";

                    FinalString += VlaueResult.Rows[Cnt][4].ToString();
                    FinalString += "#";

                    FinalString += VlaueResult.Rows[Cnt][6].ToString();
                    FinalString += "#";

                    FinalString += VlaueResult.Rows[Cnt][7].ToString();
                    FinalString += "#";

                    Cnt++;
                }

                if (FinalString.Equals(""))
                {
                    return FinalString;
                }

                FinalString += "*";

                return FinalString;
            }
            catch (Exception a)
            {
                return a.Message + "Search Exam Faild --> " + a.ToString();
            }
            finally
            {
                Con1.Close();
            }
        }

        public string GetExams(string TID, string ClassCode, string @Connection)
        {
            int Cnt = 0;
            string FinalString = "";
            DataTable VlaueResult = new DataTable();

            try
            {
                string Q = "SELECT * from Exams Where ClassCode ='" + ClassCode + "' AND TID ='" + TID + "'";
                VlaueResult = SelectData(Q, @Connection);

                while (Cnt < VlaueResult.Rows.Count)
                {
                    FinalString += VlaueResult.Rows[Cnt][5].ToString();
                    FinalString += "#";

                    FinalString += VlaueResult.Rows[Cnt][2].ToString();
                    FinalString += "#";

                    FinalString += VlaueResult.Rows[Cnt][3].ToString();
                    FinalString += "#";

                    FinalString += VlaueResult.Rows[Cnt][4].ToString();
                    FinalString += "#";

                    FinalString += VlaueResult.Rows[Cnt][6].ToString();
                    FinalString += "#";

                    FinalString += VlaueResult.Rows[Cnt][7].ToString();
                    FinalString += "#";

                    Cnt++;
                }

                if (FinalString.Equals(""))
                {
                    return FinalString;
                }

                FinalString += "*";

                return FinalString;
            }
            catch (Exception a)
            {
                return a.Message + "Search Exam Faild --> " + a.ToString();
            }
            finally
            {
                Con1.Close();
            }
        }

        public void RemoveOneExam(string ClassCode, string Lesson, string Day,string Chapter, string @Connection)
        {
            string Query = "DELETE from Exams Where ClassCode ='" + ClassCode + "' AND Lesson='" + Lesson + "'AND Day='" + Day + "'AND Chapter='" + Chapter+"'";
            SelectData(Query, @Connection);
        }

        public string AddExam(string ClassCode, string TID, string SubName, string Lesson, string per, string Day,string Chapter,string Kind, string @Connection)
        {
            string Quary;

            MyDataTable.Rows.Clear();
            MyDataTable.Columns.Clear();
            MyDataTable.Clear();
            Com1.Parameters.Clear();


            Quary = "insert into Exams(ClassCode,TID,SubName,Lesson,per,Day,Chapter,Kind)  values(@ClassCode,@TID,@SubName,@Lesson,@per,@Day,@Chapter,@Kind)";

            Con1 = new SqlConnection(@Connection);
            Con1.Open();
            Com1 = new SqlCommand(Quary, Con1);
            Com1.Parameters.Add("@ClassCode", SqlDbType.Int).Value = int.Parse(ClassCode.ToString());
            Com1.Parameters.Add("@TID", SqlDbType.VarChar).Value = TID;
            Com1.Parameters.Add("@SubName", SqlDbType.NVarChar).Value = SubName;
            Com1.Parameters.Add("@Lesson", SqlDbType.VarChar).Value = Lesson;
            Com1.Parameters.Add("@per", SqlDbType.VarChar).Value = int.Parse(per.ToString());
            Com1.Parameters.Add("@Day", SqlDbType.VarChar).Value = Day;
            Com1.Parameters.Add("@Chapter", SqlDbType.VarChar).Value = Chapter;
            Com1.Parameters.Add("@Kind", SqlDbType.VarChar).Value = Kind;
            Com1.ExecuteNonQuery();
            Con1.Close();

            return "Exam Added";
        }

        public string CheckDayExam(string Day, string Lesson, string ClassCode, string @Connection)
        {
            string Query = "SELECT * from Exams Where Day='" + Day + "' AND ClassCode='" + ClassCode + "' AND Lesson='"+ Lesson+"'";
            DataTable DT = SelectData(Query, @Connection);

            if (DT.Rows.Count > 0)
                return "1";

            else
                return "0";
        }

        public string GetTeacherClassSubjects(string TID,string ClassCode,string @Connection)
        {
            string Query = "SELECT SubCode from SubjectsTecher Where TID ='" + TID + "' AND ClassCode='"+ClassCode+"'";
            DataTable DT = SelectData(Query, @Connection);

            string FinalResult = "";

            for(int i=0;i<DT.Rows.Count;i++)
            {
                Query = "SELECT SubName from Subjects Where SubCode ='" + DT.Rows[i][0] + "'";
                FinalResult+= SelectData(Query, @Connection).Rows[0][0].ToString();
                FinalResult += "#";
            }

            return FinalResult+="*";
        }

        public string SelectMarksRowC(string ListofStudents, string SCode, string Chapter, string percentage, string @Connection)
        {
            DataTable DT = new DataTable();
            int per = 0, IdCnt = 0, Cnt = 0;
            string StudentID = "";


            ////////////////////// Storing Student ID //////////////////////
            ////////////////////// Storing Student ID //////////////////////

            while (Cnt < ListofStudents.Length)
            {
                while (IdCnt != 9)
                {
                    StudentID += ListofStudents[Cnt++];
                    IdCnt++;
                }

                string Query = "SELECT * from Marks Where SID ='" + StudentID + "'AND SubCode = '" + SCode + "'AND Chapter='" + Chapter + "'";
                DT = SelectData(Query, @Connection);


                if (DT.Rows.Count != 0)
                {
                    for (int i = 0; i < DT.Rows.Count; i++)
                    {
                        per += int.Parse(DT.Rows[i][6].ToString());
                    }
                }

                per += int.Parse(percentage.ToString());

                if (per > 100)
                    return "0";


                IdCnt = 0;
                per = 0;
                StudentID = "";
            }

            return "1";

        }

        public string GetTecherLessons(string TID, string @Connection)
        {
            string Date = DateTime.Now.ToString("dd.MM.yyy");

            string stringDay = "", stringMonth = "", stringYear = "";
            string DayName = "";

            //================================= Getting Day Name From Date>
            stringDay = Date[0].ToString() + Date[1].ToString();
            stringMonth = Date[3].ToString() + Date[4].ToString();
            stringYear = Date[6].ToString() + Date[7].ToString() + Date[8].ToString() + Date[9].ToString();

            DateTime dateValue = new DateTime(int.Parse(stringYear.ToString()), int.Parse(stringMonth.ToString()), int.Parse(stringDay.ToString()));
            DayName = dateValue.DayOfWeek.ToString();

            //================================= Converting Day Name To DB Days Names>
            if (DayName.Equals("Sunday"))
                DayName = "One";
            else if (DayName.Equals("Monday"))
                DayName = "Two";
            else if (DayName.Equals("Tuesday"))
                DayName = "Three";
            else if (DayName.Equals("Wednesday"))
                DayName = "Four";
            else if (DayName.Equals("Thursday"))
                DayName = "Five";
            else if (DayName.Equals("friday"))
                DayName = "Six";
            else if (DayName.Equals("Saturday"))
                DayName = "Seven";


            string Query = "SELECT * from Schedules Where TID ='" + TID + "'AND Day='" + DayName + "'";
            MyDataTable = SelectData(Query, @Connection);

            string Cnt = "";

            for(int i=1;i<=7;i++)
            {
                if (!MyDataTable.Rows[0][i].Equals("Break#Break"))
                    Cnt += i.ToString()+"#";
                
            }

            if (!Cnt.Equals(""))
                Cnt += "*";

            return Cnt;
        }

        public string GetMessages2(string SID, string TID, string @Connection)
        {
            int Cnt = 0;
            string FinalString = "", ClassName = "";
            DataTable VlaueResult = new DataTable();
            DataTable ClassNameTabel = new DataTable();

            try
            {
                string Q = "SELECT * from Messages Where SID ='" + SID + "'AND TID='" + TID + "'";
                VlaueResult = SelectData(Q, @Connection);

                while (Cnt < VlaueResult.Rows.Count)
                {
                    FinalString += VlaueResult.Rows[Cnt][0].ToString();
                    FinalString += "#";
                    FinalString += VlaueResult.Rows[Cnt][1].ToString();
                    FinalString += "#";
                    FinalString += VlaueResult.Rows[Cnt][2].ToString();
                    FinalString += "#";

                    Q = "SELECT CName from Classes Where ClassCode ='" + VlaueResult.Rows[Cnt][3].ToString() + "'";
                    ClassNameTabel = SelectData(Q, @Connection);

                    FinalString += ClassNameTabel.Rows[0][0].ToString();
                    FinalString += "#";

                    Q = "SELECT TName from Techers Where TID ='" + TID + "'";
                    ClassNameTabel = SelectData(Q, @Connection);

                    FinalString += ClassNameTabel.Rows[0][0].ToString();
                    FinalString += "#";

                    FinalString += "$";
                    ClassNameTabel.Rows.Clear();
                    Cnt++;
                }

                if (FinalString.Equals(""))
                {
                    return FinalString;
                }

                FinalString += "*";

                return FinalString;
            }
            catch (Exception a)
            {
                return a.Message + "Search Messages Faild --> " + a.ToString();
            }
            finally
            {
                Con1.Close();
            }

        }

        public string GetMessages(string SID, string @Connection)
        {
            int Cnt = 0;
            string FinalString = "", ClassName = "";
            DataTable VlaueResult = new DataTable();
            DataTable ClassNameTabel = new DataTable();

            try
            {
                string Q = "SELECT * from Messages Where SID ='" + SID + "'";
                VlaueResult = SelectData(Q, @Connection);

                while (Cnt < VlaueResult.Rows.Count)
                {
                    FinalString += VlaueResult.Rows[Cnt][0].ToString();
                    FinalString += "#";
                    FinalString += VlaueResult.Rows[Cnt][1].ToString();
                    FinalString += "#";
                    FinalString += VlaueResult.Rows[Cnt][2].ToString();
                    FinalString += "#";

                    Q = "SELECT CName from Classes Where ClassCode ='" + VlaueResult.Rows[Cnt][3].ToString() + "'";
                    ClassNameTabel = SelectData(Q, @Connection);

                    FinalString += ClassNameTabel.Rows[0][0].ToString();
                    FinalString += "#";

                    Q = "SELECT TName from Techers Where TID ='" + VlaueResult.Rows[Cnt][4].ToString() + "'";
                    ClassNameTabel = SelectData(Q, @Connection);

                    FinalString += ClassNameTabel.Rows[0][0].ToString();
                    FinalString += "#";

                    FinalString += "$";
                    ClassNameTabel.Rows.Clear();
                    Cnt++;
                }

                if (FinalString.Equals(""))
                {
                    return FinalString;
                }

                FinalString += "*";

                return FinalString;
            }
            catch (Exception a)
            {
                return a.Message + "Search Messages Faild --> " + a.ToString();
            }
            finally
            {
                Con1.Close();
            }

        }    

        public string TecherSendMessage(string @Connection, string ListofStudents, string Message, string ClassCode, string TID)
        {
            int Cnt = 0, IdCnt = 0;
            string StudentID = "";
            string Quary;
            string Q;

            MyDataTable.Rows.Clear();
            MyDataTable.Columns.Clear();
            MyDataTable.Clear();


            Com1.Parameters.Clear();

            try
            {

                while (Cnt < ListofStudents.Length)
                {
                    ////////////////////// Storing Student ID //////////////////////
                    ////////////////////// Storing Student ID //////////////////////
                    while (IdCnt != 9)
                    {
                        StudentID += ListofStudents[Cnt++];
                        IdCnt++;
                    }


                    Com1.Parameters.Clear();
                    Quary = "insert into Messages(SID,Message,Date,ClassCode,TID)  values(@SID,@Message,@Date,@ClassCode,@TID)";

                    Con1 = new SqlConnection(@Connection);
                    Con1.Open();
                    Com1 = new SqlCommand(Quary, Con1);
                    Com1.Parameters.Add("@SID", SqlDbType.VarChar).Value = StudentID;
                    Com1.Parameters.Add("@Message", SqlDbType.NVarChar).Value = Message;
                    Com1.Parameters.Add("@Date", SqlDbType.VarChar).Value = DateTime.Now.ToString("dd.MM.yyy");
                    Com1.Parameters.Add("@ClassCode", SqlDbType.VarChar).Value = ClassCode;
                    Com1.Parameters.Add("@TID", SqlDbType.VarChar).Value = TID;
                    Com1.ExecuteNonQuery();
                    Con1.Close();

                    StudentID = "";
                    IdCnt = 0;

                }

                UpdateNotification(@Connection, ListofStudents, "Message");
            }
            catch (Exception a)
            {
                return a.Message + "Presences Error -->" + a.ToString();
            }
            finally
            {
                Con1.Close();
            }


            return "Presences Updated";

        }

        public string GetStudentPresences(string SID, string @Connection)
        {
            int Cnt = 0;
            string Result = "", Today = "";
            MyDataTable.Rows.Clear();
            MyDataTable.Columns.Clear();
            MyDataTable.Clear();

            try
            {
                string Q = "SELECT * from Presences Where SID ='" + SID + "'";
                MyDataTable = SelectData(Q, @Connection);

                while (Cnt < MyDataTable.Rows.Count)
                {
                    Result += MyDataTable.Rows[Cnt][0].ToString();
                    Result += "#";

                    Result += MyDataTable.Rows[Cnt][1].ToString();
                    Result += "#";

                    Result += MyDataTable.Rows[Cnt][2].ToString();
                    Result += "#";

                    Result += MyDataTable.Rows[Cnt][3].ToString();
                    Result += "#";

                    Result += MyDataTable.Rows[Cnt][4].ToString();
                    Result += "#";

                    Result += "$";

                    Cnt++;
                }

                if (Result.Equals(""))
                    return Result;

                Result += "*";

                return Result;
            }

            catch (Exception a)
            {
                return a.Message + "GetStudentPresences Faild --> " + a.ToString();
            }

            finally
            {
                Con1.Close();
            }
        }

        public string GetStudentPresences2(string SID, string TID, string @Connection)
        {
            int Cnt = 0;
            string Result = "", Today = "";
            MyDataTable.Rows.Clear();
            MyDataTable.Columns.Clear();
            MyDataTable.Clear();

            try
            {
                string Q = "SELECT * from Presences Where SID ='" + SID + "'AND TID='" + TID + "'";
                MyDataTable = SelectData(Q, @Connection);

                while (Cnt < MyDataTable.Rows.Count)
                {
                    Result += MyDataTable.Rows[Cnt][0].ToString();
                    Result += "#";

                    Result += MyDataTable.Rows[Cnt][1].ToString();
                    Result += "#";

                    Result += MyDataTable.Rows[Cnt][2].ToString();
                    Result += "#";

                    Result += MyDataTable.Rows[Cnt][3].ToString();
                    Result += "#";

                    Result += MyDataTable.Rows[Cnt][4].ToString();
                    Result += "#";

                    Result += "$";

                    Cnt++;
                }

                if (Result.Equals(""))
                    return Result;

                Result += "*";

                return Result;
            }

            catch (Exception a)
            {
                return a.Message + "GetStudentPresences Faild --> " + a.ToString();
            }

            finally
            {
                Con1.Close();
            }
        }

        public string GetStudentPresencesCount(string SID, string @Connection)
        {
            string Final = "",Class="";
            int Count = 0;

            ////////////////////////// Get Presences
            ////////////////////////// Get Presences
            string Q = "SELECT * from Presences Where SID ='" + SID + "'";
            MyDataTable = SelectData(Q, @Connection);

            Final = MyDataTable.Rows.Count.ToString();

            MyDataTable.Rows.Clear();
            MyDataTable.Columns.Clear();
            MyDataTable.Clear();


            ////////////////////////// Get ClassCode
            ////////////////////////// Get ClassCode
            Q = "SELECT ClassCode from Students Where SID ='" + SID + "'";
            MyDataTable = SelectData(Q, @Connection);

            Class = MyDataTable.Rows[0][0].ToString();

            MyDataTable.Rows.Clear();
            MyDataTable.Columns.Clear();
            MyDataTable.Clear();

            ////////////////////////// Get ClassName
            ////////////////////////// Get ClassName
            Q = "SELECT CName from Classes Where ClassCode ='" + Class + "'";
            MyDataTable = SelectData(Q, @Connection);

            Class = MyDataTable.Rows[0][0].ToString();

            MyDataTable.Rows.Clear();
            MyDataTable.Columns.Clear();
            MyDataTable.Clear();

            ////////////////////////// Get OverAll 
            ////////////////////////// Get OverAll
            Q = "SELECT * from ClassSchedules Where Class ='" + Class + "'";
            MyDataTable = SelectData(Q, @Connection);

            int Row = 0,Col=0;

            for( Row=0; Row < MyDataTable.Rows.Count; Row++){

                for (Col = 1; Col <= 7; Col++){

                    if (!MyDataTable.Rows[Row][Col].ToString().Equals("Break"))
                        Count++;

                }

            }


            Final += "#" + Count + "*";


            return Final;
        }

        public string UpdatePresences(string @Connection, string ListofStudents, string TID, string Lesson)
        {
            int Cnt = 0, IdCnt = 0, subcnt = 0;
            string StudentID = "";
            string Quary;
            string Q;
            string Subject = "", LessonNumber = "";
            DataTable LisonTabel = new DataTable();
            DataTable SubTabel = new DataTable();
            MyDataTable.Rows.Clear();
            MyDataTable.Columns.Clear();
            MyDataTable.Clear();
            Com1.Parameters.Clear();

            string stringDay = "", stringMonth = "", stringYear = "";
            string DayName = "";

            string Date = DateTime.Now.ToString("dd.MM.yyy");
            //================================= Getting Day Name From Date>
            stringDay = Date[0].ToString() + Date[1].ToString();
            stringMonth = Date[3].ToString() + Date[4].ToString();
            stringYear = Date[6].ToString() + Date[7].ToString() + Date[8].ToString() + Date[9].ToString();

            DateTime dateValue = new DateTime(int.Parse(stringYear.ToString()), int.Parse(stringMonth.ToString()), int.Parse(stringDay.ToString()));
            DayName = dateValue.DayOfWeek.ToString();

            //================================= Converting Day Name To DB Days Names>
            if (DayName.Equals("Sunday"))
                DayName = "One";
            else if (DayName.Equals("Monday"))
                DayName = "Two";
            else if (DayName.Equals("Tuesday"))
                DayName = "Three";
            else if (DayName.Equals("Wednesday"))
                DayName = "Four";
            else if (DayName.Equals("Thursday"))
                DayName = "Five";
            else if (DayName.Equals("friday"))
                DayName = "Six";
            else if (DayName.Equals("Saturday"))
                DayName = "Seven";

            try
            {

                while (Cnt < ListofStudents.Length)
                {
                    ////////////////////// Storing Student ID //////////////////////
                    ////////////////////// Storing Student ID //////////////////////
                    while (IdCnt != 9)
                    {
                        StudentID += ListofStudents[Cnt++];
                        IdCnt++;
                    }

                    ////////////////////// Storing Subject //////////////////////
                    ////////////////////// Storing Subject //////////////////////

                    for (int j = 0; j < Lesson.Length; j++)
                    {
                        if (j == Lesson.Length - 1)
                            LessonNumber = Lesson[j].ToString();
                    }

                    Q = "SELECT L" + LessonNumber + " from Schedules Where Day ='" + DayName + "' AND TID ='" + TID + "'";
                    SubTabel = SelectData(Q, @Connection);

                    string r = SubTabel.Rows[0][0].ToString();

                    while (r[subcnt] != '#')
                    {
                        Subject += r[subcnt];
                        subcnt++;
                    }

                    SubTabel.Rows.Clear();
                    SubTabel.Columns.Clear();
                    SubTabel.Clear();

                    Q = "SELECT * from Subjects Where SubCode ='" + Subject + "'";
                    SubTabel = SelectData(Q, @Connection);


                    Subject = SubTabel.Rows[0][0].ToString();



                    Com1.Parameters.Clear();
                    Quary = "insert into Presences(SID,IsHere,Lison,Date,Subject,TID)  values(@SID,@IsHere,@Lison,@Date,@Subject,@TID)";

                    Con1 = new SqlConnection(@Connection);
                    Con1.Open();
                    Com1 = new SqlCommand(Quary, Con1);
                    Com1.Parameters.Add("@SID", SqlDbType.VarChar).Value = StudentID;
                    Com1.Parameters.Add("@IsHere", SqlDbType.VarChar).Value = "1";
                    Com1.Parameters.Add("@Lison", SqlDbType.VarChar).Value = Lesson;
                    Com1.Parameters.Add("@Date", SqlDbType.VarChar).Value = DateTime.Now.ToString("dd.MM.yyy");
                    Com1.Parameters.Add("@Subject", SqlDbType.NVarChar).Value = Subject;
                    Com1.Parameters.Add("@TID", SqlDbType.VarChar).Value = TID;
                    Com1.ExecuteNonQuery();
                    Con1.Close();

                    StudentID = "";
                    IdCnt = 0;
                    subcnt = 0;
                    Subject = "";

                    SubTabel.Rows.Clear();
                    SubTabel.Columns.Clear();
                    SubTabel.Clear();

                }

                UpdateNotification(@Connection, ListofStudents, "Presences");
            }
            catch (Exception a)
            {
                return a.Message + "Presences Error -->" + a.ToString();
            }
            finally
            {
                Con1.Close();
            }

            return "Presences Updated";
        }

        public string ParentsLoginIN(string PID, string Pass)
        {
            string Query = "SELECT * from ParentsLogin Where PID ='" + PID + "' AND Pass='"+Pass+"'";
            MyDataTable = SelectData(Query, PublicDatabase);

            if (MyDataTable.Rows.Count != 0)
                return "1";

            return "0";
        }

        public string TecherLoginIN(string TID, string Pass)
        {
            try
            {
                string Query = "SELECT * from Logintecher Where TID ='" + TID + "' AND Pass='" + Pass + "'";
                MyDataTable = SelectData(Query, PublicDatabase);

                string Pass2 = MyDataTable.Rows[0][1].ToString();

                if (Pass2.Equals(Pass))
                    return "1";

                return "0";
            }

            catch(Exception e)
            {
                return "0";
            }

        }

        public string StudentLoginIN(string PID, string SID)
        {
            string x = "0";
            string Pass = "";
            int Cnt = 0;
            string Connection = "";

            MyDataTable.Rows.Clear();
            MyDataTable.Columns.Clear();
            MyDataTable.Clear();

            try
            {
                string Query;
                Query = "SELECT * from ParentsLogin where PID ='" + PID + "'";
                MyDataTable = SelectData(Query, PublicDatabase);

                if (MyDataTable.Rows.Count != 0)
                {
                    Pass = MyDataTable.Rows[0][1].ToString();

                    Query = "SELECT * from SchoolPID where PID ='" + PID + "'";
                    MyDataTable = SelectData(Query, PublicDatabase);
                    DataTable DT = new DataTable();
                    DataTable DTStudent = new DataTable();

                    for (int i = 0; i < MyDataTable.Rows.Count; i++)
                    {
                        Query = "SELECT * from Connections where SchoolCode  ='" + MyDataTable.Rows[i][1] + "'";
                        DT = SelectData(Query, PublicDatabase);

                        Connection = DT.Rows[0][1].ToString();


                        Query = "SELECT * from Students where SID ='" + SID + "' AND  PID='" + PID + "'";
                        DTStudent = SelectData(Query, Connection);

                        if (DTStudent.Rows.Count != 0 && !Pass.Equals(""))
                            return Connection;

                    }

                }

                return "Not";
            }
            catch (Exception a)
            {
                return a.Message + "Login Error  --> " + a.ToString();
            }
            finally
            {
                Con1.Close();
            }
        }

        public void RemoveOneMark(string Row, string @Connection)
        {
            string Query = "DELETE from Marks Where Cnt ='" + int.Parse(Row.ToString()) + "'";
            SelectData(Query, @Connection);
        }

        public void RemoveOneMessage(string SID,string Message,string Date, string @Connection)
        {
            string Query = "DELETE from Messages Where SID ='" + SID + "' AND Message=N'"+ Message+ "'AND Date='"+Date+"'";
            SelectData(Query, @Connection);
        }

        public void RemoveOnePresences(string SID, string Lesson, string Date, string @Connection)
        {
            string Query = "DELETE from Presences Where SID ='" + SID + "' AND Lison ='" + Lesson + "'AND Date='" + Date + "'";
            SelectData(Query, @Connection);
        }

        public string TecherAddMark(string @Connection, string ListofStudents, string SubName, string ClassCode,string Chapter, string Kind, string Pers, string Mark)
        {

            int Cnt = 0, IdCnt = 0;
            string StudentID = "", SubCode = "";
            string Quary;

            if (Chapter.Equals("One"))
                Chapter = "1";
            if (Chapter.Equals("Two"))
                Chapter = "2";
            if (Chapter.Equals("Three"))
                Chapter = "3";


            if (Kind.Equals("Test"))
                Kind = "1";
            if (Kind.Equals("HomeWork"))
                Kind = "2";
            if (Kind.Equals("Project"))
                Kind = "3";


            MyDataTable.Rows.Clear();
            MyDataTable.Columns.Clear();
            MyDataTable.Clear();
            Com1.Parameters.Clear();


            try
            {
                string Q = "SELECT SubCode from Subjects Where SubName =N'" + SubName + "'";
                DataTable DT = SelectData(Q, @Connection);
                SubCode = DT.Rows[0][0].ToString();

                while (Cnt < ListofStudents.Length)
                {
                    ////////////////////// Storing Student ID //////////////////////
                    ////////////////////// Storing Student ID //////////////////////
                    while (IdCnt != 9)
                    {
                        StudentID += ListofStudents[Cnt++];
                        IdCnt++;
                    }


                    Com1.Parameters.Clear();
                    Quary = "insert into Marks(SID,SubCode,Mark,ClassCode,Chapter,Kind,percentage)  values(@SID,@SubCode,@Mark,@ClassCode,@Chapter,@Kind,@percentage)";

                    Con1 = new SqlConnection(@Connection);
                    Con1.Open();
                    Com1 = new SqlCommand(Quary, Con1);
                    Com1.Parameters.Add("@SID", SqlDbType.VarChar).Value = StudentID;
                    Com1.Parameters.Add("@SubCode", SqlDbType.VarChar).Value = SubCode;
                    Com1.Parameters.Add("@Mark", SqlDbType.Int).Value = int.Parse(Mark.ToString());
                    Com1.Parameters.Add("@ClassCode", SqlDbType.Int).Value = int.Parse(ClassCode.ToString());
                    Com1.Parameters.Add("@Chapter", SqlDbType.VarChar).Value = Chapter;
                    Com1.Parameters.Add("@Kind", SqlDbType.VarChar).Value = Kind;
                    Com1.Parameters.Add("@percentage", SqlDbType.Int).Value = int.Parse(Pers.ToString());
                    Com1.ExecuteNonQuery();
                    Con1.Close();

                    StudentID = "";
                    IdCnt = 0;

                }
            }
            catch (Exception a)
            {
                return a.Message + "Marks Error -->" + a.ToString();
            }
            finally
            {
                Con1.Close();
            }


            return "Marks Added";

        }

        public string ShowTecherClassSubjects(string TID, string ClassCode,string @Connection)
        {
            string Result = "",Subject="";
            int i = 0;
            DataTable DT = new DataTable();
            DataTable DT2 = new DataTable();

            string Query = "SELECT * from SubjectsTecher Where TID ='" + TID + "' AND ClassCode='" + ClassCode + "'";
            DT = SelectData(Query, @Connection);
                

            while(i<DT.Rows.Count)
            {
                Subject = DT.Rows[i][0].ToString();

                string Q = "SELECT SubName from Subjects Where SubCode  ='" + Subject + "'";
                DT2 = SelectData(Q, @Connection);

                Result += DT2.Rows[0][0].ToString();
                Result += "#";
                Result += Subject;
                Result += "#";
                i++;
            }

            if (Result.Equals(""))
                return "";

            return Result + "*";
        }

        public string CheckLogined(string PID)
        {
            string Query = "SELECT Logined from ParentsLogin Where PID ='" + PID + "'";
            PID = SelectData(Query, PublicDatabase).Rows[0][0].ToString();

            return PID;
        }

        public string CheckLogined2(string TID)
        {
            string Query = "SELECT Logined from Logintecher Where TID ='" + TID + "'";
            TID = SelectData(Query, PublicDatabase).Rows[0][0].ToString();

            return TID;
        }

        public string UpdateParentLogin(string PID)
        {
            try
            {
                string Quary;
                Com1.Parameters.Clear();

                Quary = "UPDATE ParentsLogin set Logined = '" + "1" + "'Where PID='" + PID + "'";

                Con1.ConnectionString = PublicDatabase;
                Con1.Open();
                Com1.CommandText = Quary;
                Com1.Connection = Con1;
                Com1.Parameters.Add("@Logined", SqlDbType.VarChar).Value = "1";
                Com1.ExecuteNonQuery();

            }
            catch (Exception a)
            {
                return a.Message + "Update ParentsLogin Faild Error -->" + a.ToString();
            }
            finally
            {
                Con1.Close();
            }

            return "";
        }

        public string UpdateParentLogin2(string PID)
        {
            try
            {
                string Quary;
                Com1.Parameters.Clear();

                Quary = "UPDATE ParentsLogin set Logined = '" + "0" + "'Where PID='" + PID + "'";

                Con1.ConnectionString = PublicDatabase;
                Con1.Open();
                Com1.CommandText = Quary;
                Com1.Connection = Con1;
                Com1.Parameters.Add("@Logined", SqlDbType.VarChar).Value = "1";
                Com1.ExecuteNonQuery();

            }
            catch (Exception a)
            {
                return a.Message + "Update ParentsLogin Faild Error -->" + a.ToString();
            }
            finally
            {
                Con1.Close();
            }

            return "";
        }

        public string UpdateTecherLogin(string TID)
        {
            try
            {
                string Quary;
                Com1.Parameters.Clear();

                Quary = "UPDATE Logintecher set Logined = '" + "1" + "'Where TID='" + TID + "'";

                Con1.ConnectionString = PublicDatabase;
                Con1.Open();
                Com1.CommandText = Quary;
                Com1.Connection = Con1;
                Com1.Parameters.Add("@Logined", SqlDbType.VarChar).Value = "1";
                Com1.ExecuteNonQuery();

            }
            catch (Exception a)
            {
                return a.Message + "Update Logintecher Faild Error -->" + a.ToString();
            }
            finally
            {
                Con1.Close();
            }

            return "";
        }

        public string UpdateTecherLogin2(string TID)
        {
            try
            {
                string Quary;
                Com1.Parameters.Clear();

                Quary = "UPDATE Logintecher set Logined = '" + "0" + "'Where TID='" + TID + "'";

                Con1.ConnectionString = PublicDatabase;
                Con1.Open();
                Com1.CommandText = Quary;
                Com1.Connection = Con1;
                Com1.Parameters.Add("@Logined", SqlDbType.VarChar).Value = "1";
                Com1.ExecuteNonQuery();

            }
            catch (Exception a)
            {
                return a.Message + "Update Logintecher Faild Error -->" + a.ToString();
            }
            finally
            {
                Con1.Close();
            }

            return "";
        }

        public string ForgetPass(string PID, string SID)
        {
            string x = "0";
            string Pass = "";
            int Cnt = 0;
            string Connection = "";

            MyDataTable.Rows.Clear();
            MyDataTable.Columns.Clear();
            MyDataTable.Clear();

            try
            {
                string Query;
                Query = "SELECT * from ParentsLogin where PID ='"+PID+"'";
                MyDataTable = SelectData(Query, PublicDatabase);

                if(MyDataTable.Rows.Count!=0)
                {
                    Pass = MyDataTable.Rows[0][1].ToString();

                    Query = "SELECT * from SchoolPID where PID ='" + PID + "'";
                    MyDataTable = SelectData(Query, PublicDatabase);
                    DataTable DT = new DataTable();
                    DataTable DTStudent = new DataTable();

                    for (int i=0;i<MyDataTable.Rows.Count;i++)
                    {
                        Query = "SELECT * from Connections where SchoolCode  ='" + MyDataTable.Rows[i][1] + "'";
                        DT = SelectData(Query, PublicDatabase);

                        Connection = DT.Rows[0][1].ToString();


                        Query = "SELECT * from Students where SID ='" + SID + "' AND  PID='"+PID+"'";
                        DTStudent = SelectData(Query, Connection);

                        if (DTStudent.Rows.Count != 0&&!Pass.Equals(""))
                            return Pass;

                    }

                }

                return "Not";
            }
            catch (Exception a)
            {
                return a.Message + "Login Error  --> " + a.ToString();
            }
            finally
            {
                Con1.Close();
            }
        }

        public string StudentRemoveMessages2(string @Connection, string SID)
        {

            try
            {

                string Query = "DELETE from Messages where SID ='" + SID + "'";
                SelectData(Query, @Connection);

            }
            catch (Exception a)
            {
                return a.Message + "Messages Error -->" + a.ToString();
            }
            finally
            {
                Con1.Close();
            }


            return "Messages Removed";

        }

        public string GetSchedules2(string @Connection,string ClassCode, string SID, string Date)
        {

            string FinalString = "", Class = "";
            int Cnt = 0;
            DataTable VlaueResult = new DataTable();
            DataTable GetNames = new DataTable();
            string Query = "";

            string stringDay = "", stringMonth = "", stringYear = "";
            string DayName = "";

            //================================= Getting Day Name From Date>
            stringDay = Date[0].ToString() + Date[1].ToString();
            stringMonth = Date[3].ToString() + Date[4].ToString();
            stringYear = Date[6].ToString() + Date[7].ToString() + Date[8].ToString() + Date[9].ToString();

            DateTime dateValue = new DateTime(int.Parse(stringYear.ToString()), int.Parse(stringMonth.ToString()), int.Parse(stringDay.ToString()));
            DayName = dateValue.DayOfWeek.ToString();

            //================================= Converting Day Name To DB Days Names>
            if (DayName.Equals("Sunday"))
                DayName = "One";
            else if (DayName.Equals("Monday"))
                DayName = "Two";
            else if (DayName.Equals("Tuesday"))
                DayName = "Three";
            else if (DayName.Equals("Wednesday"))
                DayName = "Four";
            else if (DayName.Equals("Thursday"))
                DayName = "Five";
            else if (DayName.Equals("friday"))
                DayName = "Six";
            else if (DayName.Equals("Saturday"))
                DayName = "Seven";

            Query = "SELECT CName from Classes where ClassCode ='" + int.Parse(ClassCode.ToString()) + "'";
            Class = SelectData(Query, @Connection).Rows[0][0].ToString();

            try
            {
                string Q = "SELECT * from ClassSchedules Where Class ='" + Class + "'AND Day='" + Date + "'";
                VlaueResult = SelectData(Q, @Connection);


                if (VlaueResult.Rows.Count != 0)
                {

                    FinalString += VlaueResult.Rows[0][1].ToString();
                    FinalString += "#";
                    FinalString += VlaueResult.Rows[0][2].ToString();
                    FinalString += "#";
                    FinalString += VlaueResult.Rows[0][3].ToString();
                    FinalString += "#";
                    FinalString += VlaueResult.Rows[0][4].ToString();
                    FinalString += "#";
                    FinalString += VlaueResult.Rows[0][5].ToString();
                    FinalString += "#";
                    FinalString += VlaueResult.Rows[0][6].ToString();
                    FinalString += "#";
                    FinalString += VlaueResult.Rows[0][7].ToString();
                    FinalString += "#";
                    FinalString += "*";
                }

                else
                {
                    Q = "SELECT * from ClassSchedules Where Class ='" + Class + "'AND Day='" + DayName + "'";
                    VlaueResult = SelectData(Q, @Connection);

                    if (VlaueResult.Rows.Count != 0)
                    {

                        FinalString += VlaueResult.Rows[0][1].ToString();
                        FinalString += "#";
                        FinalString += VlaueResult.Rows[0][2].ToString();
                        FinalString += "#";
                        FinalString += VlaueResult.Rows[0][3].ToString();
                        FinalString += "#";
                        FinalString += VlaueResult.Rows[0][4].ToString();
                        FinalString += "#";
                        FinalString += VlaueResult.Rows[0][5].ToString();
                        FinalString += "#";
                        FinalString += VlaueResult.Rows[0][6].ToString();
                        FinalString += "#";
                        FinalString += VlaueResult.Rows[0][7].ToString();
                        FinalString += "#";
                        FinalString += "*";
                    }
                }

                if (FinalString.Equals(""))
                {
                    return FinalString;
                }

                FinalString += "*";

                return FinalString;

            }
            catch (Exception a)
            {
                return a.Message + "ClassSchedules Faild --> " + a.ToString();
            }
            finally
            {
                Con1.Close();
            }

        }

        public string StudentRemoveMessages(string @Connection, string SID)
        {

            try
            {

                string Query = "DELETE from Presences where SID ='" + SID + "'";
                SelectData(Query, @Connection);

            }
            catch (Exception a)
            {
                return a.Message + "Messages Error -->" + a.ToString();
            }
            finally
            {
                Con1.Close();
            }


            return "Messages Removed";

        }

        public string GetSchedules(string @Connection, string TID, string Date)
        {

            string FinalString = "", Split = "", Subject = "", Class="";
            int Cnt = 0;
            DataTable VlaueResult = new DataTable();
            DataTable GetNames = new DataTable();

            string stringDay = "", stringMonth = "", stringYear = "";
            string DayName = "";

            //================================= Getting Day Name From Date>
            stringDay = Date[0].ToString() + Date[1].ToString();
            stringMonth = Date[3].ToString() + Date[4].ToString();
            stringYear = Date[6].ToString() + Date[7].ToString() + Date[8].ToString() + Date[9].ToString();

            DateTime dateValue = new DateTime(int.Parse(stringYear.ToString()), int.Parse(stringMonth.ToString()), int.Parse(stringDay.ToString()));
            DayName = dateValue.DayOfWeek.ToString();

            //================================= Converting Day Name To DB Days Names>
            if (DayName.Equals("Sunday"))
                DayName = "One";
            else if (DayName.Equals("Monday"))
                DayName = "Two";
            else if (DayName.Equals("Tuesday"))
                DayName = "Three";
            else if (DayName.Equals("Wednesday"))
                DayName = "Four";
            else if (DayName.Equals("Thursday"))
                DayName = "Five";
            else if (DayName.Equals("friday"))
                DayName = "Six";
            else if (DayName.Equals("Saturday"))
                DayName = "Seven";

            try
            {
                string Q = "SELECT * from Schedules Where TID ='" + TID + "'AND Day='" + DayName + "'";
                VlaueResult = SelectData(Q, @Connection);

    
                if(VlaueResult.Rows.Count!=0)
                {

                    for(int i=1;i<8;i++)
                    {
                        ///////////////////// GetSubject Name /////////////////////
                        ///////////////////// GetSubject Name /////////////////////
                        Split += VlaueResult.Rows[0][i].ToString();

                        while (Split[Cnt] != '#')
                        {
                            Subject += Split[Cnt++];
                        }
                        Cnt++;

                        if(Subject.Equals("Break"))
                        {
                            FinalString += Subject;                           
                        }

                        else
                        {
                            Q = "SELECT SubName from Subjects Where SubCode ='" + Subject + "'";
                            GetNames = SelectData(Q, @Connection);
                            FinalString += GetNames.Rows[0][0];
                        }

                        FinalString += "#";



                        ///////////////////// GetClass Name /////////////////////
                        ///////////////////// GetClass Name /////////////////////
                        while (Split.Length>Cnt)
                        {
                            Class += Split[Cnt++];
                        }

                        if(Class.Equals("Break"))
                        {
                            FinalString += Class;
                        }

                        else
                        {
                            Q = "SELECT CName from Classes Where ClassCode ='" + Class + "'";
                            GetNames = SelectData(Q, @Connection);
                            FinalString += GetNames.Rows[0][0];
                        }


                        FinalString += "#";

                        FinalString += "$";
                        Split = "";
                        Subject = "";
                        Class = "";
                        Cnt = 0;

                    }

                }


                if (FinalString.Equals(""))
                {
                    return FinalString;
                }

                FinalString += "*";

                return FinalString;

            }
            catch (Exception a)
            {
                return a.Message + "Search Schedules Faild --> " + a.ToString();
            }
            finally
            {
                Con1.Close();
            }

        }

        public string TecherCheckSchedules(string TID, string @Connection)
        {

            int Cnt = 0;
            string TecherDay = "",Today="",Result="0", stringDay="", stringMonth="", stringYear="", DayName="";
            MyDataTable.Rows.Clear();
            MyDataTable.Columns.Clear();
            MyDataTable.Clear();

            Today = DateTime.Now.ToString("dd.MM.yyy");

            //================================= Getting Day Name From Date>
            stringDay = Today[0].ToString() + Today[1].ToString();
            stringMonth = Today[3].ToString() + Today[4].ToString();
            stringYear = Today[6].ToString() + Today[7].ToString() + Today[8].ToString() + Today[9].ToString();

            DateTime dateValue = new DateTime(int.Parse(stringYear.ToString()), int.Parse(stringMonth.ToString()), int.Parse(stringDay.ToString()));
            DayName = dateValue.DayOfWeek.ToString();

            //================================= Converting Day Name To DB Days Names>
            if (DayName.Equals("Sunday"))
                DayName = "One";
            else if (DayName.Equals("Monday"))
                DayName = "Two";
            else if (DayName.Equals("Tuesday"))
                DayName = "Three";
            else if (DayName.Equals("Wednesday"))
                DayName = "Four";
            else if (DayName.Equals("Thursday"))
                DayName = "Five";
            else if (DayName.Equals("friday"))
                DayName = "Six";
            else if (DayName.Equals("Saturday"))
                DayName = "Seven";

            try
            {
                string Q = "SELECT Day from Schedules Where TID ='" + TID + "' AND Day='"+ DayName+"'";
                MyDataTable = SelectData(Q, @Connection);

                if (MyDataTable.Rows.Count != 0)
                    return "ok";
                else
                    return "";

            }
            catch (Exception a)
            {
                return a.Message + "TecherCheckSchedules Faild --> " + a.ToString();
            }
            finally
            {
                Con1.Close();
            }

        }

        public  string UpdateNotification(string @Connection, string ListofStudents, string Kind)
        {
            int Cnt = 0, IdCnt = 0,len=0;
            string StudentID = "";
            string Query="",PID="";
            DataTable LisonTabel = new DataTable();
            DataTable SubTabel = new DataTable();
            MyDataTable.Rows.Clear();
            MyDataTable.Columns.Clear();
            MyDataTable.Clear();


            Com1.Parameters.Clear();

            try
            {

                while (len < (ListofStudents.Length/9))
                {
                    ////////////////////// Storing Student ID //////////////////////
                    ////////////////////// Storing Student ID //////////////////////
                    while (IdCnt != 9)
                    {
                        StudentID += ListofStudents[Cnt++];
                        IdCnt++;
                    }

                    IdCnt = 0;


                    Query = "SELECT PID from Students Where SID ='" + StudentID + "'";
                    PID = SelectData(Query, @Connection).Rows[0][0].ToString();


                    try
                    {
                        string Quary;
                        Com1.Parameters.Clear();

                        Quary = "UPDATE Notification set Notifi = '" + 1 + "',Kind='" + Kind + "'Where PID='" + PID + "'";

                        Con1.ConnectionString = PublicDatabase;
                        Con1.Open();
                        Com1.CommandText = Quary;
                        Com1.Connection = Con1;
                        Com1.Parameters.Add("@Notifi", SqlDbType.VarChar).Value = "1";
                        Com1.Parameters.Add("@Kind", SqlDbType.VarChar).Value = Kind;
                        Com1.ExecuteNonQuery();
                        StudentID = "";
                        len++;

                    }
                    catch (Exception a)
                    {
                        return a.Message + "Update Notification Faild Error -->" + a.ToString();
                    }
                    finally
                    {
                        Con1.Close();
                    }

                }

            }
            catch (Exception a)
            {
                return a.Message + "Presences Error -->" + a.ToString();
            }
            finally
            {
                Con1.Close();
            }


            return "Presences Updated";

        }

        public string UpdateNotificationService(string PID)
        {
            DataTable LisonTabel = new DataTable();
            DataTable SubTabel = new DataTable();
            MyDataTable.Rows.Clear();
            MyDataTable.Columns.Clear();
            MyDataTable.Clear();

            Com1.Parameters.Clear();

            try
            {
                try
                {
                    string Quary;
                    Com1.Parameters.Clear();

                    Quary = "UPDATE Notification set Notifi = '" + 0 + "',Kind='" + 0 + "'Where PID='" + PID + "'";

                    Con1.ConnectionString = PublicDatabase;
                    Con1.Open();
                    Com1.CommandText = Quary;
                    Com1.Connection = Con1;
                    Com1.Parameters.Add("@Notifi", SqlDbType.VarChar).Value = 0;
                    Com1.Parameters.Add("@Kind", SqlDbType.VarChar).Value = 0;
                    Com1.ExecuteNonQuery();

                }
                catch (Exception a)
                {
                    return a.Message + "Update Notification Faild Error -->" + a.ToString();
                }
                finally
                {
                    Con1.Close();
                }

            }
            catch (Exception a)
            {
                return a.Message + "Presences Error -->" + a.ToString();
            }
            finally
            {
                Con1.Close();
            }


            return "Presences Updated";
        }

        public string SelectNotification(string PID)
        {
            DataTable DT = new DataTable();

            string PID2 = PID;

            string Query = "SELECT * from Notification Where PID ='" + PID + "'";
            DT = SelectData(Query, PublicDatabase);

            PID = DT.Rows[0][2].ToString();
            PID += "#";
            PID += DT.Rows[0][1].ToString();
            PID += "#";

            UpdateNotificationService(PID2);

            return PID;
        }

        public string SendNotificationTest()
        {
            DataTable DT = new DataTable();

            try
            {
                Com1.Parameters.Clear();
                string Quary = "UPDATE Notification set Notifi = '" + "1" + "',Kind='" + "Message" + "'Where PID='" + "023423452" + "'";
                Con1.ConnectionString = PublicDatabase;
                Con1.Open();
                Com1.CommandText = Quary;
                Com1.Connection = Con1;
                Com1.Parameters.Add("@Notifi", SqlDbType.VarChar).Value = "1";
                Com1.Parameters.Add("@Kind", SqlDbType.VarChar).Value = "Message";
                Com1.ExecuteNonQuery();
                Con1.Close();
                return "Updated";
            }

            catch(Exception e)
            {
                return "Eror";
            }
        }

        public string GetClassStudents(string ClassCode, string @Connection)
        {

            int Cnt = 0;
            string FinalString="";
            MyDataTable.Rows.Clear();
            MyDataTable.Columns.Clear();
            MyDataTable.Clear();


            try
            {
                string Q = "SELECT * from Students Where ClassCode ='" + ClassCode + "'";
                MyDataTable = SelectData(Q, @Connection);

                while (Cnt < MyDataTable.Rows.Count)
                {
                    FinalString += MyDataTable.Rows[Cnt][0].ToString();
                    FinalString += "#";
                    FinalString += MyDataTable.Rows[Cnt][1].ToString();
                    FinalString += "#";

                    FinalString += "$";

                    Cnt++;
                }

                if (FinalString.Equals(""))
                {
                    return FinalString;
                }

                FinalString += "*";

                return FinalString;

            }
            catch (Exception a)
            {
                return a.Message + "Select Students By Class Faild --> " + a.ToString();
            }
            finally
            {
                Con1.Close();
            }

        }

        public string SelectTecherClasses(string @SchoolConnection, string TID)
        {
            int Cnt = 0;

            MyDataTable.Rows.Clear();
            MyDataTable.Columns.Clear();
            MyDataTable.Clear();

            try
            {
                string Query;
                Query = "SELECT ClassCode from SubjectsTecher Where TID='" + TID + "'";
                Con1.ConnectionString = @SchoolConnection;
                Con1.Open();

                Com1 = new SqlCommand(Query, @Con1);

                Adapter.SelectCommand = Com1;
                Adapter.Fill(MyDataTable);

                DataTable CName = new DataTable();
                string All = "";
                string NoRepeat = "";
                string NoRepeat2 = "";
                int Dont = 0;
                int i = 0;


                while (MyDataTable.Rows.Count != Cnt)
                {
                    NoRepeat = MyDataTable.Rows[Cnt][0].ToString();

                    while (i < Cnt)
                    {
                        NoRepeat2 = MyDataTable.Rows[i][0].ToString();

                        if(NoRepeat2.Equals(NoRepeat))
                        {
                            Dont = 1;
                        }
                        i++;

                    }

                    if(Dont==0)
                    {
                        All += MyDataTable.Rows[Cnt][0].ToString();
                        All += "#";


                        Query = "SELECT * from Classes Where ClassCode='" + MyDataTable.Rows[Cnt][0].ToString() + "'";

                        Com1 = new SqlCommand(Query, @Con1);

                        Adapter.SelectCommand = Com1;
                        Adapter.Fill(CName);


                        All += CName.Rows[0][0].ToString();
                        All += "#";
                        All += "$";

                        CName.Rows.Clear();

                    }

                    Dont = 0;
                    i = 0;
                    Cnt++;
                }

                if(All.Equals(""))
                {
                    return All;
                }

                All += "*";

                return All;

            }
            catch (Exception a)
            {
                return a.Message + "Getting TecherClasses Error  --> " + a.ToString();
            }
            finally
            {
                Con1.Close();
            }
        }

        public string AddImageToAndroid(string SID, string ImagePhoto, string @SchoolConnection)
        {

            if (!SID.Equals("-1"))
            {
                Com1.Parameters.Clear();

                try
                {
                    string query;

                    query = "insert into ImagesAndroid(SID,Image)  values(@SID,@Image)";
                    Con1 = new SqlConnection(@SchoolConnection);
                    Con1.Open();
                    Com1 = new SqlCommand(query, Con1);
                    Com1.Parameters.Add("@SID", SqlDbType.VarChar).Value = SID;
                    Com1.Parameters.Add("@Image", SqlDbType.VarChar).Value = ImagePhoto;
                    Com1.ExecuteNonQuery();

                }
                catch (Exception a)
                {
                    return a.Message + "Add Image Faild Error -->" + a.ToString();
                }
                finally
                {
                    Con1.Close();
                }

            }

            return "ImageAndroid Added";

        }

        public string SelectImage(string StudentId, string @Connection)
        {
            string query,Image="";
            query = "SELECT * from ImagesAndroid where SID ='" + StudentId + "'";
            MyDataTable = SelectData(query, @Connection);

            if (MyDataTable.Rows.Count != 0)
                Image = MyDataTable.Rows[0][1].ToString();

            return Image;
        }

        public string GetStudentMarks(string SID,string ClassCode, string @Connection)
        {

            MyDataTable.Rows.Clear();
            MyDataTable.Columns.Clear();
            MyDataTable.Clear();

            try
            {
                string Query;
                Query = "SELECT * from Marks Where SID ='" + SID + "' AND ClassCode ='"+ClassCode+"'";
                Con1.ConnectionString = @Connection;
                Con1.Open();

                Com1 = new SqlCommand(Query, Con1);

                Adapter.SelectCommand = Com1;
                Adapter.Fill(MyDataTable);



                int Cnt = 0;
                string TableItem = "", FinalString = "";
                DataTable VlaueResult = new DataTable();

                while (Cnt != MyDataTable.Rows.Count)
                {
                    //================================================= Getting Subject Name ==================\\>
                    //================================================= Getting Subject Name ==================\\>
                    TableItem = MyDataTable.Rows[Cnt][1].ToString();

                    string Q = "SELECT SubName from Subjects Where SubCode ='" + TableItem + "'";
                    VlaueResult = SelectData(Q, @Connection);

                    FinalString += VlaueResult.Rows[0][0].ToString();

                    FinalString += "#";

                    VlaueResult.Rows.Clear();
                    VlaueResult.Columns.Clear();


                    //================================================= Getting Mark ==================\\>
                    //================================================= Getting Mark ==================\\>
                    FinalString += MyDataTable.Rows[Cnt][2].ToString();

                    FinalString += "#";


                    //================================================= Getting Class Name ==================\\>
                    //================================================= Getting Class Name ==================\\>
                    TableItem = MyDataTable.Rows[Cnt][3].ToString();

                    Q = "SELECT CName from Classes Where ClassCode ='" + TableItem + "'";
                    VlaueResult = SelectData(Q, @Connection);

                    FinalString += VlaueResult.Rows[0][0].ToString();

                    FinalString += "#";

                    VlaueResult.Rows.Clear();
                    VlaueResult.Columns.Clear();


                    //================================================= Getting Chapter ==================\\>
                    //================================================= Getting Chapter ==================\\>
                    FinalString += MyDataTable.Rows[Cnt][4].ToString();

                    FinalString += "#";


                    //================================================= Getting Kind  ==================\\>
                    //================================================= Getting Kind  ==================\\>
                    FinalString += MyDataTable.Rows[Cnt][5].ToString();

                    FinalString += "#";


                    //================================================= Getting percentage  ==================\\>
                    //================================================= Getting percentage  ==================\\>
                    FinalString += MyDataTable.Rows[Cnt][6].ToString();

                    FinalString += "#";



                    //================================================= Spliting Subject ==================\\>
                    FinalString += "$";

                    Cnt++;
                }


                //================================================= End Of Student Marks ==================\\>
                FinalString += "*";



                if (FinalString.Equals("*"))
                {
                    FinalString = "";
                }

                return FinalString;

            }
            catch (Exception a)
            {
                return a.Message + "Getting Marks Error  --> " + a.ToString();
            }
            finally
            {
                Con1.Close();
            }
        }

        public string GetStudentMarks2(string SID, string SubCode, string @Connection)
        {

            MyDataTable.Rows.Clear();
            MyDataTable.Columns.Clear();
            MyDataTable.Clear();

            try
            {
                string Query = "Select ClassCode from Students Where SID ='" + SID + "'";
                string ClassCode = SelectData(Query, @Connection).Rows[0][0].ToString();

                Query = "SELECT * from Marks Where SID ='" + SID + "' AND SubCode ='" + SubCode + "' AND ClassCode='" + ClassCode + "'";
                Con1.ConnectionString = @Connection;
                Con1.Open();
                Com1 = new SqlCommand(Query, Con1);
                Adapter.SelectCommand = Com1;
                Adapter.Fill(MyDataTable);

                int Cnt = 0;
                string TableItem = "", FinalString = "";
                DataTable VlaueResult = new DataTable();

                if (MyDataTable.Rows.Count != 0)
                {
                    while (Cnt != MyDataTable.Rows.Count)
                    {
                        //================================================= Getting Subject Name ==================\\>
                        //================================================= Getting Subject Name ==================\\>
                        TableItem = MyDataTable.Rows[Cnt][1].ToString();

                        string Q = "SELECT SubName from Subjects Where SubCode ='" + TableItem + "'";
                        VlaueResult = SelectData(Q, @Connection);

                        FinalString += VlaueResult.Rows[0][0].ToString();

                        FinalString += "#";

                        VlaueResult.Rows.Clear();
                        VlaueResult.Columns.Clear();


                        //================================================= Getting Mark ==================\\>
                        //================================================= Getting Mark ==================\\>
                        FinalString += MyDataTable.Rows[Cnt][2].ToString();

                        FinalString += "#";


                        //================================================= Getting Class Name ==================\\>
                        //================================================= Getting Class Name ==================\\>
                        TableItem = MyDataTable.Rows[Cnt][3].ToString();

                        Q = "SELECT CName from Classes Where ClassCode ='" + TableItem + "'";
                        VlaueResult = SelectData(Q, @Connection);

                        FinalString += VlaueResult.Rows[0][0].ToString();

                        FinalString += "#";

                        VlaueResult.Rows.Clear();
                        VlaueResult.Columns.Clear();


                        //================================================= Getting Chapter ==================\\>
                        //================================================= Getting Chapter ==================\\>
                        FinalString += MyDataTable.Rows[Cnt][4].ToString();

                        FinalString += "#";


                        //================================================= Getting Chapter ==================\\>
                        //================================================= Getting Chapter ==================\\>
                        FinalString += MyDataTable.Rows[Cnt][5].ToString();

                        FinalString += "#";


                        //================================================= Getting Chapter ==================\\>
                        //================================================= Getting Chapter ==================\\>
                        FinalString += MyDataTable.Rows[Cnt][6].ToString();

                        FinalString += "#";

                        //================================================= Getting Row ==================\\>
                        //================================================= Getting Row ==================\\>
                        FinalString += MyDataTable.Rows[Cnt][7].ToString();

                        FinalString += "#";




                        //================================================= Spliting Subject ==================\\>
                        FinalString += "$";

                        Cnt++;
                    }


                    //================================================= End Of Student Marks ==================\\>
                    FinalString += "*";

                    return FinalString;
                }

                else
                    return "";

            }
            catch (Exception a)
            {
                return a.Message + "Getting Marks Error  --> " + a.ToString();
            }
            finally
            {
                Con1.Close();
            }
        }

        public string SelectSchoolByParent(string PID)
        {
            string All = "";
            string TheSchoolCode;
            int Cnt = 0;

            MyDataTable.Rows.Clear();
            MyDataTable.Columns.Clear();
            MyDataTable.Clear();

            try
            {
                string Query;
                Query = "SELECT * from SchoolPID Where PID='" + PID + "'";
                Con1.ConnectionString = PublicDatabase;
                Con1.Open();

                Com1 = new SqlCommand(Query, Con1);

                Adapter.SelectCommand = Com1;
                Adapter.Fill(MyDataTable);

                DataTable GetSChool = new DataTable();

                Con1.Close();

                while (Cnt < MyDataTable.Rows.Count)
                {
                    TheSchoolCode = MyDataTable.Rows[Cnt][1].ToString();

                    Query = "SELECT SchoolName , SchoolCode  from SLogin Where SchoolCode='" + TheSchoolCode + "'";
                    Con1.ConnectionString = PublicDatabase;
                    Con1.Open();

                    Com1 = new SqlCommand(Query, Con1);

                    Adapter.SelectCommand = Com1;
                    Adapter.Fill(GetSChool);

                    Con1.Close();

                    All += GetSChool.Rows[0][0].ToString();
                    All += "#";
                    All += GetSChool.Rows[0][1].ToString();
                    All += "$";

                    GetSChool.Rows.Clear();
                    GetSChool.Columns.Clear();
                    GetSChool.Clear();

                    Cnt++;

                }

                All += "*";

                return All;

            }
            catch (Exception a)
            {
                return a.Message + "MVC ERROR --> " + a.ToString();
            }
            finally
            {
                Con1.Close();
            }
        }

        public string SelectSchoolByTecher(string TID)
        {
            string All = "";
            string TheSchoolCode;
            int Cnt = 0;

            MyDataTable.Rows.Clear();
            MyDataTable.Columns.Clear();
            MyDataTable.Clear();

            try
            {
                string Query;
                Query = "SELECT * from SchoolTID Where TID='" + TID + "'";
                Con1.ConnectionString = PublicDatabase;
                Con1.Open();

                Com1 = new SqlCommand(Query, Con1);

                Adapter.SelectCommand = Com1;
                Adapter.Fill(MyDataTable);

                DataTable GetSChool = new DataTable();

                Con1.Close();

                while (Cnt < MyDataTable.Rows.Count)
                {
                    TheSchoolCode = MyDataTable.Rows[Cnt][1].ToString();

                    Query = "SELECT SchoolName , SchoolCode  from SLogin Where SchoolCode='" + TheSchoolCode + "'";
                    Con1.ConnectionString = PublicDatabase;
                    Con1.Open();

                    Com1 = new SqlCommand(Query, Con1);

                    Adapter.SelectCommand = Com1;
                    Adapter.Fill(GetSChool);

                    Con1.Close();

                    All += GetSChool.Rows[0][0].ToString();
                    All += "#";
                    All += GetSChool.Rows[0][1].ToString();
                    All += "$";

                    GetSChool.Rows.Clear();
                    GetSChool.Columns.Clear();
                    GetSChool.Clear();

                    Cnt++;

                }

                if(All.Equals(""))
                {
                    return All;
                }

                All += "*";

                return All;

            }
            catch (Exception a)
            {
                return a.Message + "MVC ERROR --> " + a.ToString();
            }
            finally
            {
                Con1.Close();
            }
        }

        public string GetStudentsFromSchool(string @SchoolConnection, string PID)
        {
            int Cnt = 0;

            MyDataTable.Rows.Clear();
            MyDataTable.Columns.Clear();
            MyDataTable.Clear();

            try
            {
                string Query;
                Query = "SELECT * from Students Where PID='" + PID + "'";
                Con1.ConnectionString = @SchoolConnection;
                Con1.Open();

                Com1 = new SqlCommand(Query, @Con1);

                Adapter.SelectCommand = Com1;
                Adapter.Fill(MyDataTable);

                string All = "";


                while (MyDataTable.Rows.Count != Cnt)
                {
                    All += MyDataTable.Rows[Cnt][0].ToString();
                    All += "#";
                    All += MyDataTable.Rows[Cnt][1].ToString();
                    All += "$";
                    Cnt++;
                }

                All += "*";

                return All;

            }
            catch (Exception a)
            {
                return a.Message + "Getting Students Error  --> " + a.ToString();
            }
            finally
            {
                Con1.Close();
            }
        }

        public string GetSchoolConnection(string Code)
        {

            MyDataTable.Rows.Clear();
            MyDataTable.Columns.Clear();
            MyDataTable.Clear();

            try
            {
                string Query;
                Query = "SELECT * from Connections Where SchoolCode ='" + Code + "'";
                Con1.ConnectionString = PublicDatabase;
                Con1.Open();

                Com1 = new SqlCommand(Query, Con1);

                Adapter.SelectCommand = Com1;
                Adapter.Fill(MyDataTable);

                string Connection = "";

                Connection += MyDataTable.Rows[0][1].ToString();

                return Connection;

            }
            catch (Exception a)
            {
                return a.Message + "Getting Connection Error  --> " + a.ToString();
            }
            finally
            {
                Con1.Close();
            }
        }

        public string GetSchoolRank(string SchoolCode)
        {
            string Query = "SELECT SchoolRank from SLogin Where SchoolCode ='" + SchoolCode + "'";
            SchoolCode = SelectData(Query, PublicDatabase).Rows[0][0].ToString();

            return SchoolCode;
        }

        //================================================= Android Parents Side Functions =================================================>
        //================================================= Android Parents Side Functions =================================================>
        //================================================= Android Parents Side Functions =================================================>


        //***************************************IN SchoolDatabase***************************************
        //***************************************IN SchoolDatabase***************************************
        //***************************************IN SchoolDatabase***************************************

        public string CreateTableParents()
        {
            Tonull();

            try
            {
                string query;
                query = "create table Parents(PName varchar(20),PID varchar(9),StudentsNumber int,PhoneNumber int,PRIMARY KEY (PID))";
                Con1 = new SqlConnection(SchoolDatabase);  
                Con1.Open();
                Com1 = new SqlCommand(query, Con1);
               

                Com1.ExecuteNonQuery();             
            }

            catch (Exception a)
            {
                return a.Message + "  Error -->  " + a.ToString();
            }

            finally
            {
                Con1.Close();            
            }

            return "Table Parents Created";
        }

        //***************************************IN SchoolDatabase***************************************
        //***************************************IN SchoolDatabase***************************************
        //***************************************IN SchoolDatabase***************************************

        public string CreateTabelTecherSchedule()
        {
            Tonull();

            try
            {
                string query;

                query = "create table Schedules(Cnt int IDENTITY(0,1),L1 varchar(30),L2 varchar(30),L3 varchar(30),L4 varchar(30),L5 varchar(30),L6 varchar(30),L7 varchar(30),TID varchar(9),Day varchar(1),FOREIGN KEY (TID) REFERENCES Techers(TID))";
                Con1 = new SqlConnection(SchoolDatabase);
                Con1.Open();
                Com1 = new SqlCommand(query, Con1);
                Com1.ExecuteNonQuery();
            }

            catch (Exception a)
            {
                return a.Message + "  Error -->  " + a.ToString();
            }

            finally
            {
                Con1.Close();
            }

            return "Table Schedules Created";
        }

        //***************************************IN SchoolDatabase***************************************
        //***************************************IN SchoolDatabase***************************************
        //***************************************IN SchoolDatabase***************************************

        public string CreateTableStudents() 
        {

            Tonull();

            try
            {
                string query;
                query = "create table Students(SName varchar(20),SID varchar(9),PID varchar(9),ClassCode int,PRIMARY KEY (SID),FOREIGN KEY (PID) REFERENCES Parents(PID),FOREIGN KEY (ClassCode) REFERENCES Classes(ClassCode))";
                Con1 = new SqlConnection(SchoolDatabase);
                Con1.Open();
                Com1 = new SqlCommand(query, Con1);
                Com1.ExecuteNonQuery();

            }

            catch (Exception a)
            {
                return a.Message + "  Error -->  " + a.ToString();
            }

            finally
            {
                Con1.Close();
            }

            return "Table Students Created";
        }


        //***************************************IN SchoolDatabase***************************************
        //***************************************IN SchoolDatabase***************************************
        //***************************************IN SchoolDatabase***************************************

        public string CreateTableMarks()
        {

            Tonull();

            try
            {
                string query;
               
                query = "create table Marks(SID varchar(9),SubCode varchar(3),Mark int,ClassCode int,Chapter varchar(1),Kind varchar(1),percentage int,Cnt int IDENTITY(0,1),FOREIGN KEY (SID) REFERENCES Students(SID),FOREIGN KEY (ClassCode) REFERENCES Classes(ClassCode),FOREIGN KEY (SubCode) REFERENCES Subjects(SubCode))";
                Con1 = new SqlConnection(SchoolDatabase);
                Con1.Open();
                Com1 = new SqlCommand(query, Con1);
                Com1.ExecuteNonQuery();

            }

            catch (Exception a)
            {
                return a.Message + "  Error -->  " + a.ToString();
            }

            finally
            {
                Con1.Close();
            }

            return "Table Marks Created";
        }


        //***************************************IN SchoolDatabase***************************************
        //***************************************IN SchoolDatabase***************************************
        //***************************************IN SchoolDatabase***************************************

        public string CreateTableMessages()
        {
            Tonull();

            try
            {
                string query;
                
                query = "create table Messages(SID varchar(9),Message varchar(100),Date Datetime,ClassCode int,FOREIGN KEY (SID) REFERENCES Students(SID))";
                Con1 = new SqlConnection(SchoolDatabase);
                Con1.Open();
                Com1 = new SqlCommand(query, Con1);
                Com1.ExecuteNonQuery();
            }

            catch (Exception a)
            {
                return a.Message + "  Error -->  " + a.ToString();
            }

            finally
            {
                Con1.Close();
            }

            return "Table Messages Created";
        }

        //***************************************IN PublicDatabase***************************************
        //***************************************IN PublicDatabase***************************************
        //***************************************IN PublicDatabase***************************************
        public string CreateTableParentsLogin()
        {
            Tonull();

            try
            {
                string query;
                query = "create table ParentsLogin(PID varchar(9),Pass varchar(20),FOREIGN KEY (PID) REFERENCES Parents(PID))";
                Con1 = new SqlConnection(PublicDatabase);
                Con1.Open();
                Com1 = new SqlCommand(query, Con1);
                Com1.ExecuteNonQuery();

            }

            catch (Exception a)
            {
                return a.Message + "  Error -->  " + a.ToString();
            }

            finally
            {
                Con1.Close();
            }

            return "Table Login Created";
        }

        //***************************************IN PublicDatabase***************************************
        //***************************************IN PublicDatabase***************************************
        //***************************************IN PublicDatabase***************************************

        public string CreateTableLogintecher()
        {
            Tonull();

            try
            {
                string query;
                query = "create table Logintecher(TID varchar(9),Pass varchar(20),FOREIGN KEY (TID) REFERENCES Techers(TID))";
                Con1 = new SqlConnection(PublicDatabase);
                Con1.Open();
                Com1 = new SqlCommand(query, Con1);
                Com1.ExecuteNonQuery();

            }

            catch (Exception a)
            {
                return a.Message + "  Error -->  " + a.ToString();
            }

            finally
            {
                Con1.Close();
            }

            return "Table Logintecher Created";
        }

        //***************************************IN PublicDatabase***************************************
        //***************************************IN PublicDatabase***************************************
        //***************************************IN PublicDatabase***************************************

        public string CreateTableSLogin()
        {
            Tonull();

            try
            {
                string query;
                query = "create table SLogin(SchoolCode int,Pass varchar(20),PRIMARY KEY (SchoolCode))";
                Con1 = new SqlConnection(PublicDatabase);
                Con1.Open();
                Com1 = new SqlCommand(query, Con1);
                Com1.ExecuteNonQuery();

            }

            catch (Exception a)
            {
                return a.Message + " SchoolLogin  Error -->  " + a.ToString();
            }

            finally
            {
                Con1.Close();
            }

            return "Table SchoolLogin Created";
        }

        //***************************************IN PublicDatabase***************************************
        //***************************************IN PublicDatabase***************************************
        //***************************************IN PublicDatabase***************************************

        public string CreateTableSchoolPID()
        {
            Tonull();

            try
            {
                string query;
                query = "create table SchoolPID(PID varchar(9),SchoolCode int,FOREIGN KEY (PID) REFERENCES Parents(PID),FOREIGN KEY (SchoolCode) REFERENCES SLogin(SchoolCode))";
                Con1 = new SqlConnection(PublicDatabase);
                Con1.Open();
                Com1 = new SqlCommand(query, Con1);
                Com1.ExecuteNonQuery();

            }

            catch (Exception a)
            {
                return a.Message + "  Error -->  " + a.ToString();
            }

            finally
            {
                Con1.Close();
            }

            return "Table SchoolPID Created";
        }

        //***************************************IN PublicDatabase***************************************
        //***************************************IN PublicDatabase***************************************
        //***************************************IN PublicDatabase***************************************

        public string CreateTableSchoolTID()
        {
            Tonull();

            try
            {
                string query;
                query = "create table SchoolTID(TID varchar(9),SchoolCode int,FOREIGN KEY (TID) REFERENCES Techers(TID),FOREIGN KEY (SchoolCode) REFERENCES SLogin(SchoolCode))";
                Con1 = new SqlConnection(PublicDatabase);
                Con1.Open();
                Com1 = new SqlCommand(query, Con1);
                Com1.ExecuteNonQuery();

            }

            catch (Exception a)
            {
                return a.Message + "  Error -->  " + a.ToString();
            }

            finally
            {
                Con1.Close();
            }

            return "Table SchoolTID Created";
        }

        //***************************************IN PublicDatabase***************************************
        //***************************************IN PublicDatabase***************************************
        //***************************************IN PublicDatabase***************************************

        public string CreateTableConnections()
        {
            Tonull();

            try
            {
                string query;
                query = "create table Connections(SchoolCode int,Connection varchar(150),FOREIGN KEY (SchoolCode) REFERENCES SLogin(SchoolCode))";
                Con1 = new SqlConnection(PublicDatabase);
                Con1.Open();
                Com1 = new SqlCommand(query, Con1);
                Com1.ExecuteNonQuery();

            }

            catch (Exception a)
            {
                return a.Message + "  Error -->  " + a.ToString();
            }

            finally
            {
                Con1.Close();
            }

            return "Table Connections Created";
        }

        //***************************************IN SchoolDatabase***************************************
        //***************************************IN SchoolDatabase***************************************
        //***************************************IN SchoolDatabase***************************************

        public string CreateTableSubjects()
        {

            Tonull();

            try
            {
                string query;
                query = "create table Subjects(SubName varchar(20),SubCode varchar(3),PRIMARY KEY (SubCode))";
                Con1 = new SqlConnection(SchoolDatabase);
                Con1.Open();
                Com1 = new SqlCommand(query, Con1);
                Com1.ExecuteNonQuery();
            }

            catch (Exception a)
            {
                return a.Message + "  Error -->  " + a.ToString();
            }

            finally
            {
                Con1.Close();
            }

            return "Table Subjects Created";
        }

        //***************************************IN SchoolDatabase***************************************
        //***************************************IN SchoolDatabase***************************************
        //***************************************IN SchoolDatabase***************************************

        public string CreateTableSubjectsTecher()
        {


            Tonull();

            try
            {
                string query;
                query = "create table SubjectsTecher(SubCode varchar(3),TID varchar(9),ClassCode int,FOREIGN KEY (SubCode) REFERENCES Subjects(SubCode),Cnt int IDENTITY(0,1),FOREIGN KEY (TID) REFERENCES Techers(TID),FOREIGN KEY (ClassCode) REFERENCES Classes(ClassCode))";
                Con1 = new SqlConnection(SchoolDatabase);
                Con1.Open();
                Com1 = new SqlCommand(query, Con1);
                Com1.ExecuteNonQuery();
            }

            catch (Exception a)
            {
                return a.Message + "  Error -->  " + a.ToString();
            }

            finally
            {
                Con1.Close();
            }

            return "Table SubjectsTecher Created";
        }

        //***************************************IN SchoolDatabase***************************************
        //***************************************IN SchoolDatabase***************************************
        //***************************************IN SchoolDatabase***************************************

        public string CreateTableTechers()
        {
            Tonull();

            try
            {
                string query;
                query = "create table Techers(TName varchar(20),TID varchar(9),PRIMARY KEY (TID))";
                Con1 = new SqlConnection(SchoolDatabase);
                Con1.Open();
                Com1 = new SqlCommand(query, Con1);
                Com1.ExecuteNonQuery();

            }

            catch (Exception a)
            {
                return a.Message + "  Error -->  " + a.ToString();
            }

            finally
            {
                Con1.Close();
            }

            return "Table Techers Created";
        }

        //***************************************IN SchoolDatabase***************************************
        //***************************************IN SchoolDatabase***************************************
        //***************************************IN SchoolDatabase***************************************

        public string CreateTableClassTechers()
        {
            Tonull();

            try
            {
                string query;
                query = "create table ClassTechers(Cnt int IDENTITY(0,1),TID varchar(9),ClassCode int,FOREIGN KEY (TID) REFERENCES Techers(TID))";
                Con1 = new SqlConnection(SchoolDatabase);
                Con1.Open();
                Com1 = new SqlCommand(query, Con1);
                Com1.ExecuteNonQuery();

            }

            catch (Exception a)
            {
                return a.Message + "  Error -->  " + a.ToString();
            }

            finally
            {
                Con1.Close();
            }

            return "Table Techers Created";
        }

        //***************************************IN SchoolDatabase***************************************
        //***************************************IN SchoolDatabase***************************************
        //***************************************IN SchoolDatabase***************************************

        public string CreateTableImages()
        {
            Tonull();

            try
            {
                string query;
                query = "create table Images(SID varchar(9),Image varchar(100),FOREIGN KEY (SID) REFERENCES Students(SID))";
                Con1 = new SqlConnection(SchoolDatabase);
                Con1.Open();
                Com1 = new SqlCommand(query, Con1);
                Com1.ExecuteNonQuery();

            }

            catch (Exception a)
            {
                return a.Message + "  Error -->  " + a.ToString();
            }

            finally
            {
                Con1.Close();
            }

            return "Table Images Created";
        }


        //public string CreateTableImagesAndroid()
        //{

        //    try
        //    {
        //        string query;
        //        query = "create table ImagesAndroid(SID varchar(9),Image varchar(150),FOREIGN KEY (SID) REFERENCES Students(SID) ,UNIQUE (SID))";
        //        Con1 = new SqlConnection(SchoolDatabase);
        //        Con1.Open();
        //        Com1 = new SqlCommand(query, Con1);
        //        Com1.ExecuteNonQuery();

        //    }

        //    catch (Exception a)
        //    {
        //        string s = a.Message + "   " + a.ToString();
        //        return a.Message + "  Error -->  " + a.ToString();
        //    }

        //    finally
        //    {
        //        Con1.Close();
        //    }

        //    return "Table ImagesImagesAndroid Created";
        //}


        public string CreateTableImagesAndroid()
        {
            Tonull();

            try
            {
                string query;
                query = "create table ImagesAndroid(SID varchar(9),Image VARBINARY(MAX),FOREIGN KEY (SID) REFERENCES Students(SID),UNIQUE (SID))";
                Con1 = new SqlConnection(SchoolDatabase);
                Con1.Open();
                Com1 = new SqlCommand(query, Con1);
                Com1.ExecuteNonQuery();

            }

            catch (Exception a)
            {
                return a.Message + "  Error -->  " + a.ToString();
            }

            finally
            {
                Con1.Close();
            }

            return "Table Images Created";
        }

        //***************************************IN SchoolDatabase***************************************
        //***************************************IN SchoolDatabase***************************************
        //***************************************IN SchoolDatabase***************************************

        public string CreateTableClasses()
        {
            Tonull();

            try
            {
                string query;
                query = "create table Classes(CName varchar(20),ClassCode int,PRIMARY KEY (ClassCode))";
                Con1 = new SqlConnection(SchoolDatabase);
                Con1.Open();
                Com1 = new SqlCommand(query, Con1);
                Com1.ExecuteNonQuery();

            }

            catch (Exception a)
            {
                return a.Message + "  Error -->  " + a.ToString();
            }

            finally
            {
                Con1.Close();
            }

            return "Table Classes Created";
        }

        public string SelectSchool(string PID)
        {
            string Result = "";

            try
            {
                string Query;
                Query = "SELECT * from SchoolPID where PID = '" + PID + "'";
                Con1 = new SqlConnection(PublicDatabase);
                Con1.Open();

                Com1 = new SqlCommand(Query, Con1);
                Com1.ExecuteNonQuery();

                SqlDataReader Reader1 = Com1.ExecuteReader();

                while (Reader1.Read())
                {
                    if (Reader1["PID"].ToString().Equals(PID.ToString()))
                    {
                        Result += Reader1["SchoolCode"].ToString();
                        Result += "#";
                    }
                }
                return Result;

            }
            catch (Exception a)
            {
                return a.Message + "Sever Error  --> " + a.ToString();
            }
            finally
            {
                Con1.Close();
            }
        }

    }

}
