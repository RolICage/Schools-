using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data;
using WebApplication1;
using System.Text;

namespace WebApplication1.Controllers
{

    public class HomeController : Controller
    {

        static private string PublicConStr = @"Data Source=SQL6007.site4now.net;Initial Catalog=DB_A50589_PublicData;User Id=DB_A50589_PublicData_admin;Password=need4speed123159;";
        static private string ConStr = @"Data Source=SQL6007.site4now.net;Initial Catalog=DB_A50589_School1Data;User Id=DB_A50589_School1Data_admin;Password=need4speed123159";
        static private SqlConnection Con;
        static private SqlConnection PublicCon = new SqlConnection(PublicConStr1);
        static private SqlCommand Cmd = new SqlCommand();
        static private SqlDataAdapter Adapter = new SqlDataAdapter();


        //////////////////////////////////////////////Constractors///////////////////////////////////////////
        //////////////////////////////////////////////Constractors///////////////////////////////////////////
        public static string PublicConStr1 { get => PublicConStr; set => PublicConStr = value; }
        public static SqlConnection Con1 { get => Con; set => Con = value; }
        public static SqlConnection PublicCon1 { get => PublicCon; set => PublicCon = value; }
        public static SqlCommand Cmd1 { get => Cmd; set => Cmd = value; }
        public static SqlDataAdapter Adapter1 { get => Adapter; set => Adapter = value; }

        public static string PDB = @"Data Source=SQL6007.site4now.net;Initial Catalog=DB_A50589_PublicData;User Id=DB_A50589_PublicData_admin;Password=need4speed123159;";
        string SchoolCode = "748";


        static private DataTable SelectData(string Quary, string @StrConnection)
        {
            string Corrector = @"";
            @Corrector += @StrConnection;

            SqlConnection Connection = new SqlConnection(@Corrector);


            DataTable dt = new DataTable();

            Cmd1.CommandText = Quary;
            Cmd1.Connection = Connection;

            Adapter1.SelectCommand = Cmd1;
            try
            {
                Connection.Open();
                Adapter1.Fill(dt);
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


        public string Test()
        {

            //return CreateTableWorks(ConStr);
            //return CreateTableWorksA(ConStr);
            //return CreateTableQustions(ConStr);
            //return CreateTableQustionsSolve(ConStr);

            return "";

        }


        //=================================================== PUBLIC DB Create TABELS>
        //=================================================== PUBLIC DB Create TABELS>
        //=================================================== PUBLIC DB Create TABELS>
        public static string CreateTableNotification(string SchoolDatabase2)
        {
            try
            {
                string query;
                query = "create table Notification(PID varchar(9),Kind varchar(10),Notifi varchar(1))";
                Con1 = new SqlConnection(SchoolDatabase2);
                Con1.Open();
                Cmd1 = new SqlCommand(query, Con1);
                Cmd1.ExecuteNonQuery();

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

        public static string CreateTabelPromote(string SchoolDatabase2)
        {

            try
            {
                string query;
                query = "create table Promot(VideoURL varchar(300),PRIMARY KEY (VideoURL))";
                Con1 = new SqlConnection(SchoolDatabase2);
                Con1.Open();
                Cmd1 = new SqlCommand(query, Con1);
                Cmd1.ExecuteNonQuery();

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

        public static string CreateTableParentsLogin(string SchoolDatabase2)
        {

            try
            {
                string query;
                query = "create table ParentsLogin(PID varchar(9),Pass varchar(20),Logined varchar(1),PRIMARY KEY (PID))";
                Con1 = new SqlConnection(SchoolDatabase2);
                Con1.Open();
                Cmd1 = new SqlCommand(query, Con1);
                Cmd1.ExecuteNonQuery();

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

        public static string CreateTableLogintecher(string SchoolDatabase2)
        {

            try
            {
                string query;
                query = "create table Logintecher(TID varchar(9),Pass varchar(20),Logined varchar(1),PRIMARY KEY (TID))";
                Con1 = new SqlConnection(SchoolDatabase2);
                Con1.Open();
                Cmd1 = new SqlCommand(query, Con1);
                Cmd1.ExecuteNonQuery();

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

        public static string CreateTableSLogin(string SchoolDatabase2)
        {

            try
            {
                string query;
                query = "create table SLogin(SchoolCode int,Pass varchar(20),SchoolRank varchar(1),SchoolName NVARCHAR(100),PRIMARY KEY (SchoolCode))";
                Con1 = new SqlConnection(SchoolDatabase2);
                Con1.Open();
                Cmd1 = new SqlCommand(query, Con1);
                Cmd1.ExecuteNonQuery();

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

        public static string CreateTableSchoolPID(string SchoolDatabase2)
        {

            try
            {
                string query;
                query = "create table SchoolPID(PID varchar(9),SchoolCode int,FOREIGN KEY (SchoolCode) REFERENCES SLogin(SchoolCode))";
                Con1 = new SqlConnection(SchoolDatabase2);
                Con1.Open();
                Cmd1 = new SqlCommand(query, Con1);
                Cmd1.ExecuteNonQuery();

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

        public static string CreateTableSchoolTID(string SchoolDatabase2)
        {

            try
            {
                string query;
                query = "create table SchoolTID(TID varchar(9),SchoolCode int,FOREIGN KEY (SchoolCode) REFERENCES SLogin(SchoolCode))";
                Con1 = new SqlConnection(SchoolDatabase2);
                Con1.Open();
                Cmd1 = new SqlCommand(query, Con1);
                Cmd1.ExecuteNonQuery();

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

        public static string CreateTableConnections(string SchoolDatabase2)
        {
            try
            {
                string query;
                query = "create table Connections(SchoolCode int,Connection varchar(150),FOREIGN KEY (SchoolCode) REFERENCES SLogin(SchoolCode))";
                Con1 = new SqlConnection(SchoolDatabase2);
                Con1.Open();
                Cmd1 = new SqlCommand(query, Con1);
                Cmd1.ExecuteNonQuery();

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

        public static string CreateTableGPS(string SchoolDatabase2)
        {

            try
            {
                string query;
                query = "create table GPS(SID varchar(9),Lat varchar(50),Long varchar(50),address varchar(50),Name varchar(50),Postal varchar(20))";
                Con1 = new SqlConnection(SchoolDatabase2);
                Con1.Open();
                Cmd1 = new SqlCommand(query, Con1);
                Cmd1.ExecuteNonQuery();

            }

            catch (Exception a)
            {
                return a.Message + "  Error -->  " + a.ToString();
            }

            finally
            {
                Con1.Close();
            }

            return "Table GPS Created";
        }


        public static string CreateTableStudentLogined(string SchoolDatabase2)
        {
            try
            {
                string query;
                query = "create table StudentLogined(SID varchar(9),Logined int)";
                Con1 = new SqlConnection(SchoolDatabase2);
                Con1.Open();
                Cmd1 = new SqlCommand(query, Con1);
                Cmd1.ExecuteNonQuery();
            }

            catch (Exception a)
            {
                return a.Message + "  Error -->  " + a.ToString();
            }

            finally
            {
                Con1.Close();
            }

            return "Table StudentLogined Created";
        }

        //=================================================== PUBLIC DB Create TABELS END>
        //=================================================== PUBLIC DB Create TABELS END>
        //=================================================== PUBLIC DB Create TABELS END>

        //=================================================== PUBLIC DB Create TABELS END>
        //=================================================== PUBLIC DB Create TABELS END>
        //=================================================== PUBLIC DB Create TABELS END>

        ////////////////////////////////////////////// School Temp Functions ///////////////////////////////////////////
        ////////////////////////////////////////////// School Temp Functions ///////////////////////////////////////////

        public static string CreateTableParents(string SchoolDatabase2)
        {
            try
            {
                string query;
                query = "create table Parents(PName NVARCHAR(20),PID varchar(9),PhoneNumber varchar(10),PRIMARY KEY (PID))";
                Con1 = new SqlConnection(SchoolDatabase2);
                Con1.Open();
                Cmd1 = new SqlCommand(query, Con1);


                Cmd1.ExecuteNonQuery();
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

        public static string CreateTabelTecherSchedule(string SchoolDatabase2)
        {

            try
            {
                string query;

                query = "create table Schedules(Cnt int IDENTITY(0,1),L1 varchar(30),L2 varchar(30),L3 varchar(30),L4 varchar(30),L5 varchar(30),L6 varchar(30),L7 varchar(30),TID varchar(9),Day varchar(30),FOREIGN KEY (TID) REFERENCES Techers(TID))";
                Con1 = new SqlConnection(SchoolDatabase2);
                Con1.Open();
                Cmd1 = new SqlCommand(query, Con1);
                Cmd1.ExecuteNonQuery();
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

        public static string CreateTabelClassSchedule(string SchoolDatabase2)
        {

            try
            {
                string query;

                query = "create table ClassSchedules(Cnt int IDENTITY(0,1),L1 NVARCHAR(30),L2 NVARCHAR(30),L3 NVARCHAR(30),L4 NVARCHAR(30),L5 NVARCHAR(30),L6 NVARCHAR(30),L7 NVARCHAR(30),Class varchar(30),Day varchar(30))";
                Con1 = new SqlConnection(SchoolDatabase2);
                Con1.Open();
                Cmd1 = new SqlCommand(query, Con1);
                Cmd1.ExecuteNonQuery();
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

        public static string CreateTableStudents(string SchoolDatabase2)
        {

            try
            {
                string query;
                query = "create table Students(SName NVARCHAR(20),SID varchar(9),PID varchar(9),ClassCode int,Phone varchar(10),Adress NVARCHAR(20),BDate varchar(10),PRIMARY KEY (SID),FOREIGN KEY (PID) REFERENCES Parents(PID),FOREIGN KEY (ClassCode) REFERENCES Classes(ClassCode))";
                Con1 = new SqlConnection(SchoolDatabase2);
                Con1.Open();
                Cmd1 = new SqlCommand(query, Con1);
                Cmd1.ExecuteNonQuery();

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

        public static string CreateTableMarks(string SchoolDatabase2)
        {
            try
            {
                string query;

                query = "create table Marks(SID varchar(9),SubCode varchar(3),Mark int,ClassCode int,Chapter varchar(1),Kind varchar(1),percentage int,Cnt int IDENTITY(0,1),FOREIGN KEY (SID) REFERENCES Students(SID),FOREIGN KEY (ClassCode) REFERENCES Classes(ClassCode),FOREIGN KEY (SubCode) REFERENCES Subjects(SubCode))";
                Con1 = new SqlConnection(SchoolDatabase2);
                Con1.Open();
                Cmd1 = new SqlCommand(query, Con1);
                Cmd1.ExecuteNonQuery();

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

        public static string CreateTableMessages(string SchoolDatabase2)
        {

            try
            {
                string query;

                query = "create table Messages(SID varchar(9),Message NVARCHAR(100),Date varchar(20),ClassCode int,TID varchar(9),FOREIGN KEY (SID) REFERENCES Students(SID))";
                Con1 = new SqlConnection(SchoolDatabase2);
                Con1.Open();
                Cmd1 = new SqlCommand(query, Con1);
                Cmd1.ExecuteNonQuery();
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

        public static string CreateTableSubjects(string SchoolDatabase2)
        {

            try
            {
                string query;
                query = "create table Subjects(SubName NVARCHAR(20),SubCode varchar(3),PRIMARY KEY (SubCode))";
                Con1 = new SqlConnection(SchoolDatabase2);
                Con1.Open();
                Cmd1 = new SqlCommand(query, Con1);
                Cmd1.ExecuteNonQuery();
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

        public static string CreateTableSubjectsTecher(string SchoolDatabase2)
        {
            try
            {
                string query;
                query = "create table SubjectsTecher(SubCode varchar(3),TID varchar(9),ClassCode int,FOREIGN KEY (SubCode) REFERENCES Subjects(SubCode),Cnt int IDENTITY(0,1),FOREIGN KEY (TID) REFERENCES Techers(TID),FOREIGN KEY (ClassCode) REFERENCES Classes(ClassCode))";
                Con1 = new SqlConnection(SchoolDatabase2);
                Con1.Open();
                Cmd1 = new SqlCommand(query, Con1);
                Cmd1.ExecuteNonQuery();
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

        public static string CreateTableTechers(string SchoolDatabase2)
        {

            try
            {
                string query;
                query = "create table Techers(TName NVARCHAR(20),TID varchar(9),Phone varchar(10),PRIMARY KEY (TID))";
                Con1 = new SqlConnection(SchoolDatabase2);
                Con1.Open();
                Cmd1 = new SqlCommand(query, Con1);
                Cmd1.ExecuteNonQuery();

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

        public static string CreateTablePresences(string SchoolDatabase2)
        {
            Cmd1.Parameters.Clear();
            try
            {
                string query;
                query = "create table Presences(SID varchar(9),IsHere varchar(1),Lison varchar(1), Date varchar(30),Subject NVARCHAR(30),TID varchar(9),FOREIGN KEY (SID) REFERENCES Students(SID))";
                Con1 = new SqlConnection(SchoolDatabase2);
                Con1.Open();
                Cmd1 = new SqlCommand(query, Con1);
                Cmd1.ExecuteNonQuery();

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

        public static string CreateTableClassTechers(string SchoolDatabase2)
        {

            try
            {
                string query;
                query = "create table ClassTechers(Cnt int IDENTITY(0,1),TID varchar(9),ClassCode int,FOREIGN KEY (TID) REFERENCES Techers(TID))";
                Con1 = new SqlConnection(SchoolDatabase2);
                Con1.Open();
                Cmd1 = new SqlCommand(query, Con1);
                Cmd1.ExecuteNonQuery();

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

        public static string CreateTableImages(string SchoolDatabase2)
        {

            try
            {
                string query;
                query = "create table Images(SID varchar(9),Image varchar(100),FOREIGN KEY (SID) REFERENCES Students(SID))";
                Con1 = new SqlConnection(SchoolDatabase2);
                Con1.Open();
                Cmd1 = new SqlCommand(query, Con1);
                Cmd1.ExecuteNonQuery();

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

        public static string CreateTableImagesAndroid(string SchoolDatabase2)
        {
            try
            {
                string query;
                query = "create table ImagesAndroid(SID varchar(9),Image varchar(150),FOREIGN KEY (SID) REFERENCES Students(SID), UNIQUE (SID))";
                Con1 = new SqlConnection(SchoolDatabase2);
                Con1.Open();
                Cmd1 = new SqlCommand(query, Con1);
                Cmd1.ExecuteNonQuery();

            }

            catch (Exception a)
            {
                string s = a.Message + "   " + a.ToString();
                return a.Message + "  Error -->  " + a.ToString();
            }

            finally
            {
                Con1.Close();
            }

            return "Table ImagesImagesAndroid Created";
        }

        public static string CreateTableImagesAndroid2(string SchoolDatabase2)
        {
            try
            {
                string query;
                query = "create table ImagesAndroid2(SID varchar(9),Image varbinary(MAX),FOREIGN KEY (SID) REFERENCES Students(SID), UNIQUE (SID))";
                Con1 = new SqlConnection(SchoolDatabase2);
                Con1.Open();
                Cmd1 = new SqlCommand(query, Con1);
                Cmd1.ExecuteNonQuery();

            }

            catch (Exception a)
            {
                string s = a.Message + "   " + a.ToString();
                return a.Message + "  Error -->  " + a.ToString();
            }

            finally
            {
                Con1.Close();
            }

            return "Table ImagesImagesAndroid Created";
        }

        public static string CreateTableClasses(string SchoolDatabase2)
        {

            try
            {
                string query;
                query = "create table Classes(CName varchar(20),ClassCode int,PRIMARY KEY (ClassCode))";
                Con1 = new SqlConnection(SchoolDatabase2);
                Con1.Open();
                Cmd1 = new SqlCommand(query, Con1);
                Cmd1.ExecuteNonQuery();

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


        public static string CreateTableExams(string SchoolDatabase2)
        {

            try
            {
                string query;
                query = "create table Exams(ClassCode int,TID varchar(9),SubName NVARCHAR(60),Lesson varchar(1),per int,Day varchar(30),Chapter varchar(1),Kind varchar(1),FOREIGN KEY (ClassCode) REFERENCES Classes(ClassCode),FOREIGN KEY (TID) REFERENCES Techers(TID))";
                Con1 = new SqlConnection(SchoolDatabase2);
                Con1.Open();
                Cmd1 = new SqlCommand(query, Con1);
                Cmd1.ExecuteNonQuery();

            }

            catch (Exception a)
            {
                return a.Message + "  Error -->  " + a.ToString();
            }

            finally
            {
                Con1.Close();
            }

            return "Table Exams Created";
        }

        public static string CreateTableWorks(string SchoolDatabase2)
        {

            try
            {
                string query;
                query = "create table Works(TID varchar(9),ClassCode int,WCode varchar(10),SubName NVARCHAR(60),Per int ," +
                    "FOREIGN KEY (ClassCode) REFERENCES Classes(ClassCode),FOREIGN KEY (TID) REFERENCES Techers(TID)," +
                    "PRIMARY KEY (WCode))";
                Con1 = new SqlConnection(SchoolDatabase2);
                Con1.Open();
                Cmd1 = new SqlCommand(query, Con1);
                Cmd1.ExecuteNonQuery();

            }

            catch (Exception a)
            {
                return a.Message + "  Error -->  " + a.ToString();
            }

            finally
            {
                Con1.Close();
            }

            return "Table Works Created";
        }

        public static string CreateTableQustionsA(string SchoolDatabase2)
        {
            try
            {
                string query;
                query = "create table QustionsA(WCode varchar(10),QCode varchar(10),Qustion NVARCHAR(500)," +
                    "A1 NVARCHAR(150),A2 NVARCHAR(150),A3 NVARCHAR(150),A4 NVARCHAR(150),A5 NVARCHAR(150),QPer int," +
                    "FOREIGN KEY (WCode) REFERENCES Works(WCode))";
                Con1 = new SqlConnection(SchoolDatabase2);
                Con1.Open();
                Cmd1 = new SqlCommand(query, Con1);
                Cmd1.ExecuteNonQuery();

            }

            catch (Exception a)
            {
                return a.Message + "  Error -->  " + a.ToString();
            }

            finally
            {
                Con1.Close();
            }

            return "Table WorksA Created";
        }

        public static string CreateTableQustions(string SchoolDatabase2)
        {
            try
            {
                string query;
                query = "create table Qustions(WCode varchar(10),QCode varchar(10),QKind varchar(1),Qustion NVARCHAR(500),QPer int," +
                    "FOREIGN KEY (WCode) REFERENCES Works(WCode))";
                Con1 = new SqlConnection(SchoolDatabase2);
                Con1.Open();
                Cmd1 = new SqlCommand(query, Con1);
                Cmd1.ExecuteNonQuery();

            }

            catch (Exception a)
            {
                return a.Message + "  Error -->  " + a.ToString();
            }

            finally
            {
                Con1.Close();
            }

            return "Table Qustions Created";
        }

        public static string CreateTableQustionsSolve(string SchoolDatabase2)
        {
            try
            {
                string query;
                query = "create table QustionsSolve(WCode varchar(10),QCode varchar(10),QKind varchar(1),Answer NVARCHAR(500),SID varchar(9)," +
                    "FOREIGN KEY (WCode) REFERENCES Works(WCode))";
                Con1 = new SqlConnection(SchoolDatabase2);
                Con1.Open();
                Cmd1 = new SqlCommand(query, Con1);
                Cmd1.ExecuteNonQuery();

            }

            catch (Exception a)
            {
                return a.Message + "  Error -->  " + a.ToString();
            }

            finally
            {
                Con1.Close();
            }

            return "Table Qustions Created";
        }
        ////////////////////////////////////////////// School ///////////////////////////////////////////
        ////////////////////////////////////////////// School ///////////////////////////////////////////


        public static string AddSchool(int SchoolCode, string Pass, string SchoolName, string SchoolRank, string Connection)
        {
            try
            {
                string Quary;
                Quary = "insert into SLogin(SchoolCode,Pass,SchoolRank,SchoolName)  values(@SchoolCode,@Pass,@SchoolRank,@SchoolName)";
                Cmd1.Parameters.Clear();
                PublicCon.Open();
                Cmd1.CommandText = Quary;
                Cmd1.Connection = PublicCon;
                Cmd1.Parameters.Add("@SchoolCode", SqlDbType.Int).Value = SchoolCode;
                Cmd1.Parameters.Add("@Pass", SqlDbType.VarChar).Value = Pass;                
                Cmd1.Parameters.Add("@SchoolRank", SqlDbType.VarChar).Value = SchoolRank;
                Cmd1.Parameters.Add("@SchoolName", SqlDbType.NVarChar).Value = SchoolName.ToString();

                Cmd1.ExecuteNonQuery();

            }

            catch (Exception a)
            {
                string s;
                s = a.Message.ToString() + "Error" + a.ToString();

                return a.Message + "Add School Faild -->" + a.ToString();
            }

            PublicCon.Close();


            try
            {
                string Quary;
                Quary = "insert into Connections(SchoolCode,Connection)  values(@SchoolCode,@Connection)";
                Cmd1.Parameters.Clear();
                PublicCon.Open();
                Cmd1.CommandText = Quary;
                Cmd1.Connection = PublicCon;
                Cmd1.Parameters.Add("@SchoolCode", SqlDbType.Int).Value = SchoolCode;
                Cmd1.Parameters.Add("@Connection", SqlDbType.VarChar).Value = Connection;

                Cmd1.ExecuteNonQuery();

            }

            catch (Exception a)
            {
                string s;
                s = a.Message.ToString() + "Error" + a.ToString();

                return a.Message + "Add School Faild -->" + a.ToString();
            }

            finally
            {
                PublicCon.Close();
            }

            string Result = "";

            try
            {
                Result += CreateTableParents(@Connection);
                Result += " -------------> ";
                Result += CreateTableClasses(@Connection);
                Result += " -------------> ";
                Result += CreateTableStudents(@Connection);
                Result += " -------------> ";
                Result += CreateTableSubjects(@Connection);
                Result += " -------------> ";
                Result += CreateTableTechers(@Connection);
                Result += " -------------> ";
                Result += CreateTableSubjectsTecher(@Connection);
                Result += " -------------> ";
                Result += CreateTableMarks(@Connection);
                Result += " -------------> ";
                Result += CreateTableMessages(@Connection);
                Result += " -------------> ";
                Result += CreateTableImages(@Connection);
                Result += " -------------> ";
                Result += CreateTableImagesAndroid(@Connection);
                Result += " -------------> ";
                Result += CreateTabelTecherSchedule(@Connection);
                Result += " -------------> ";
                Result += CreateTablePresences(@Connection);
                Result += " -------------> ";
                Result += CreateTabelClassSchedule(@Connection);
                Result += " -------------> ";
                Result += CreateTableExams(@Connection);
                Result += " -------------> ";
                Result += CreateTableWorks(@Connection);
                Result += " -------------> ";
                Result += CreateTableQustions(@Connection);
                Result += " -------------> ";
                Result += CreateTableQustionsA(@Connection);
                Result += " -------------> ";
                Result += CreateTableQustionsSolve(@Connection);
            }

            catch (Exception e)
            {
                Result += "Error" + e.Message.ToString() + "`";
            }

            finally
            {
                PublicCon.Close();
            }

            if (Result[Result.Length - 1].Equals('`'))
            {
                return Result;
            }
            else
            {
                return "All Tabels Created !";
            }


            PublicCon.Close();

            return "New School Added";
        }

        public static string AddSchoolKids(int SchoolCode, string Pass, string SchoolName, string SchoolRank, string Connection)
        {
            try
            {
                string Quary;
                Quary = "insert into SLogin(SchoolCode,Pass,SchoolName,SchoolRank)  values(@SchoolCode,@Pass,@SchoolName,@SchoolRank)";
                Cmd1.Parameters.Clear();
                PublicCon.Open();
                Cmd1.CommandText = Quary;
                Cmd1.Connection = PublicCon;
                Cmd1.Parameters.Add("@SchoolCode", SqlDbType.Int).Value = SchoolCode;
                Cmd1.Parameters.Add("@Pass", SqlDbType.VarChar).Value = Pass;
                Cmd1.Parameters.Add("@SchoolName", SqlDbType.VarChar).Value = SchoolName;
                Cmd1.Parameters.Add("@SchoolRank", SqlDbType.VarChar).Value = SchoolRank;

                Cmd1.ExecuteNonQuery();

            }

            catch (Exception a)
            {
                string s;
                s = a.Message.ToString() + "Error" + a.ToString();

                return a.Message + "Add School Faild -->" + a.ToString();
            }

            PublicCon.Close();


            try
            {
                string Quary;
                Quary = "insert into Connections(SchoolCode,Connection)  values(@SchoolCode,@Connection)";
                Cmd1.Parameters.Clear();
                PublicCon.Open();
                Cmd1.CommandText = Quary;
                Cmd1.Connection = PublicCon;
                Cmd1.Parameters.Add("@SchoolCode", SqlDbType.Int).Value = SchoolCode;
                Cmd1.Parameters.Add("@Connection", SqlDbType.VarChar).Value = Connection;

                Cmd1.ExecuteNonQuery();

            }

            catch (Exception a)
            {
                string s;
                s = a.Message.ToString() + "Error" + a.ToString();

                return a.Message + "Add School Faild -->" + a.ToString();
            }

            finally
            {
                PublicCon.Close();
            }

            string Result = "";

            try
            {
                Result += CreateTableParents(@Connection);
                Result += " -------------> ";
                Result += CreateTableClasses(@Connection);
                Result += " -------------> ";
                Result += CreateTableStudents(@Connection);
                Result += " -------------> ";
                Result += CreateTableSubjects(@Connection);
                Result += " -------------> ";
                Result += CreateTableTechers(@Connection);
                Result += " -------------> ";
                Result += CreateTableSubjectsTecher(@Connection);
                Result += " -------------> ";
                Result += CreateTableMessages(@Connection);
                Result += " -------------> ";
                Result += CreateTableImages(@Connection);
                Result += " -------------> ";
                Result += CreateTableImagesAndroid(@Connection);
                Result += " -------------> ";
                Result += CreateTabelTecherSchedule(@Connection);
                Result += " -------------> ";
                Result += CreateTabelClassSchedule(@Connection);
                Result += " -------------> ";
                Result += CreateTablePresences(@Connection);
                Result += " -------------> ";
                Result += CreateTableExams(@Connection);
            }

            catch (Exception e)
            {
                Result += "Error" + e.Message.ToString() + "`";
            }

            finally
            {
                PublicCon.Close();
            }

            if (Result[Result.Length - 1].Equals('`'))
            {
                return Result;
            }
            else
            {
                return "All Tabels Created !";
            }


            PublicCon.Close();

            return "New School Added";
        }


        //================================================== Other Used functions
        //================================================== Other Used functions
        //================================================== Other Used functions

        static public DataTable SelectSchoolByCode(string SchoolCode)
        {
            string Query = "SELECT * from SLogin Where SchoolCode ='" + SchoolCode + "'";
            return SelectData(Query, PublicConStr1);
        }

        static public DataTable SelectParentPublicDB(string PID)
        {
            string Query = "SELECT * from SchoolPID where PID ='" + PID + "'";
            return SelectData(Query, PublicConStr1);
        }

        public static string AddClass(string ClassName, int ClassCode, string @Connection)
        {
            SqlConnection Con2 = new SqlConnection();

            try
            {
                string Quary;
                Quary = "insert into Classes(CName,ClassCode)  values(@CName,@ClassCode)";
                Cmd1.Parameters.Clear();
                Con2.ConnectionString = @Connection;
                Con2.Open();
                Cmd1.CommandText = Quary;
                Cmd1.Connection = Con2;
                Cmd1.Parameters.Add("@CName", SqlDbType.VarChar).Value = ClassName;
                Cmd1.Parameters.Add("@ClassCode", SqlDbType.Int).Value = ClassCode;
                Cmd1.ExecuteNonQuery();
            }
            catch (Exception a)
            {
                return a.Message + "Add Class Faild -->" + a.ToString();
            }

            Con1.Close();

            return "Class Added";
        }

        public static string AddParents2(string PName, string PID, int PhoneNumber, string Connection)
        {
            SqlConnection Con2 = new SqlConnection();
            DataTable ParentSchoolCheck = new DataTable();
            string BackResult = "";

            BackResult = Con1.ConnectionString.ToString();
            try
            {
                string Quary;
                Quary = "insert into Parents(PName,PID,PhoneNumber)  values(@PName,@PID,@PhoneNumber)";
                Cmd1.Parameters.Clear();
                Con2.ConnectionString = Connection;
                Con2.Open();
                Cmd1.CommandText = Quary;
                Cmd1.Connection = Con2;
                Cmd1.Parameters.Add("@PName", SqlDbType.VarChar).Value = PName;
                Cmd1.Parameters.Add("@PID", SqlDbType.VarChar).Value = PID;
                Cmd1.Parameters.Add("@PhoneNumber", SqlDbType.Int).Value = PhoneNumber;

                Cmd1.ExecuteNonQuery();

                BackResult = "Parents Added";
            }

            catch (Exception a)
            {
                return a.Message + "Add Parents Faild -->" + a.ToString();
            }

            finally
            {
                Con1.Close();
            }

            return BackResult;
        }


        public static string AddSubjects2(string SubName, string SubCode, string @Connection)
        {

            SqlConnection Con2 = new SqlConnection();

            try
            {
                string Quary;
                Quary = "insert into Subjects(SubName,SubCode)  values(@SubName,@SubCode)";
                Cmd1.Parameters.Clear();
                Con2.ConnectionString = Connection;
                Con2.Open();
                Cmd1.CommandText = Quary;
                Cmd1.Connection = Con2;
                Cmd1.Parameters.Add("@SubName", SqlDbType.VarChar).Value = SubName;
                Cmd1.Parameters.Add("@SubCode", SqlDbType.VarChar).Value = SubCode;

                Cmd1.ExecuteNonQuery();

            }

            catch (Exception a)
            {
                string s;
                s = a.Message.ToString() + "Error" + a.ToString();

                return a.Message + "Add Subjcet Faild -->" + a.ToString();
            }

            finally
            {
                Con1.Close();
            }

            return "Subjcet Added";
        }


        public static string AddParentsToPublicDB(string PID, string SchoolCode)
        {

            string BackResult = "";
            try
            {
                string Quary;
                Quary = "insert into SchoolPID(PID,SchoolCode)  values(@PID,@SchoolCode)";
                Cmd1.Parameters.Clear();

                PublicCon1.Open();

                Cmd1.CommandText = Quary;
                Cmd1.Connection = PublicCon1;
                Cmd1.Parameters.Add("@PID", SqlDbType.VarChar).Value = PID.ToString();
                Cmd1.Parameters.Add("@SchoolCode", SqlDbType.Int).Value = int.Parse(SchoolCode.ToString());

                Cmd1.ExecuteNonQuery();

                BackResult = "ParentsPublic DB Added";
            }

            catch (Exception a)
            {
                return a.Message + "ParentsPublic DB Faild -->" + a.ToString();
            }

            finally
            {
                PublicCon1.Close();
            }

            return BackResult;
        }

        static public string CreateAccount(string ID, string Pass, string Case)
        {
            string Error;
            try
            {
                string Quary;
                PublicCon1.Close();

                if (Case.Equals("P"))
                {
                    Quary = "insert into ParentsLogin(PID, Pass)  values(@PID, @Pass)";
                    Cmd1.Parameters.Clear();
                    PublicCon1.Open();
                    Cmd1.CommandText = Quary;
                    Cmd1.Connection = PublicCon1;
                    Cmd1.Parameters.Add("@PID", SqlDbType.VarChar).Value = ID;
                    Cmd1.Parameters.Add("@Pass", SqlDbType.VarChar).Value = Pass;

                    Cmd1.ExecuteNonQuery();
                }

                else
                {
                    Quary = "insert into Logintecher(TID, Pass)  values(@TID,@Pass)";
                    Cmd1.Parameters.Clear();
                    PublicCon1.Open();
                    Cmd1.CommandText = Quary;
                    Cmd1.Connection = PublicCon1;
                    Cmd1.Parameters.Add("@TID", SqlDbType.VarChar).Value = ID;
                    Cmd1.Parameters.Add("@Pass", SqlDbType.VarChar).Value = Pass;

                    Cmd1.ExecuteNonQuery();
                }

                PublicCon1.Close();

            }

            catch (Exception a)
            {
                return Error = a.Message + "Parents Create Accounts Faild -->" + a.ToString();
            }
            finally
            {
                PublicCon1.Close();
            }

            return "Parents Account Created";

        }

        public static string AddStudent2(string SName, string SID, string PID, int ClassCode,string Phone ,string Adress,string BDate, string @Connection)
        {
            SqlConnection Con2 = new SqlConnection();

            try
            {
                string Quary;
                Quary = "insert into Students(SName,SID,PID,ClassCode)  values(@SName,@SID,@PID,@ClassCode)";
                Cmd1.Parameters.Clear();
                Con2.ConnectionString = @Connection;
                Con2.Open();
                Cmd1.CommandText = Quary;
                Cmd1.Connection = Con2;
                Cmd1.Parameters.Add("@SName", SqlDbType.NVarChar).Value = SName.ToString();
                Cmd1.Parameters.Add("@SID", SqlDbType.VarChar).Value = SID;
                Cmd1.Parameters.Add("@PID", SqlDbType.VarChar).Value = PID;
                Cmd1.Parameters.Add("@ClassCode", SqlDbType.Int).Value = ClassCode;
                Cmd1.Parameters.Add("@Phone", SqlDbType.VarChar).Value = Phone;
                Cmd1.Parameters.Add("@Adress", SqlDbType.NVarChar).Value = Adress.ToString();
                Cmd1.Parameters.Add("@BDate", SqlDbType.VarChar).Value = BDate;
                Cmd1.ExecuteNonQuery();

            }
            catch (Exception a)
            {
                string s;
                s = a.Message.ToString() + "Error" + a.ToString();

                return a.Message + "Add Student Faild -->" + a.ToString();
            }
            finally
            {
                Con1.Close();
            }

            return "Student Added";
        }

        //======================================= Remove All School Data (Tabels)

        public string RemoveAllSchoolData()
        {
            ConStr = @"Data Source=SQL6007.site4now.net;Initial Catalog=DB_A50589_School1Data;User Id=DB_A50589_School1Data_admin;Password=need4speed123159";
            try
            {
                string Query;

                Query = "DROP TABLE Presences";
                SelectData(Query, ConStr);

                Query = "DROP TABLE Schedules";
                SelectData(Query, ConStr);

                Query = "DROP TABLE Messages";
                SelectData(Query, ConStr);

                Query = "DROP TABLE Marks";
                SelectData(Query, ConStr);

                Query = "DROP TABLE ImagesAndroid";
                SelectData(Query, ConStr);

                Query = "DROP TABLE Images";
                SelectData(Query, ConStr);

                Query = "DROP TABLE Exams";
                SelectData(Query, ConStr);

                Query = "DROP TABLE ClassSchedules";
                SelectData(Query, ConStr);

                Query = "DROP TABLE SubjectsTecher";
                SelectData(Query, ConStr);

                Query = "DROP TABLE Techers";
                SelectData(Query, ConStr);

                Query = "DROP TABLE Subjects";
                SelectData(Query, ConStr);

                Query = "DROP TABLE Students";
                SelectData(Query, ConStr);

                Query = "DROP TABLE Parents";
                SelectData(Query, ConStr);

                Query = "DROP TABLE Classes";
                SelectData(Query, ConStr);
            }

            catch (Exception a)
            {
                return a.Message + "Cant Remove School Data" + a.ToString();
            }

            return "DataRemoved !";
        }

        public string RemoveSchools()
        {
            DataTable Result = new DataTable();

            try
            {
                string Quary;

                Quary = "DELETE from ParentsLogin";

                Result = SelectData(Quary, PublicConStr1);

                Quary = "DELETE from Logintecher";

                Result = SelectData(Quary, PublicConStr1);

                Quary = "DELETE from Connections";

                Result = SelectData(Quary, PublicConStr1);

                Quary = "DELETE from SchoolPID";

                Result = SelectData(Quary, PublicConStr1);

                Quary = "DELETE from SchoolTID";

                Result = SelectData(Quary, PublicConStr1);

                Quary = "DELETE from Notification";

                Result = SelectData(Quary, PublicConStr1);

                Quary = "DELETE from SLogin";

                Result = SelectData(Quary, PublicConStr1);

                return "Removed";
            }

            catch (Exception a)
            {
                string s;
                s = a.Message.ToString() + "Error" + a.ToString();

                return a.Message + "Remove Schools Faild -->" + a.ToString();
            }

        }

        public void RemoveTabel()
        {
            string Query;


            Query = "DELETE from GPS";
            SelectData(Query, PublicConStr1);

        }
    }
}
