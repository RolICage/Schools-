using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;
using school.App_Code;
using System.Data.SqlTypes;
using System.Text;
using System.IO;
using school.App_Code;
using System.Net;
using System.Web.UI.WebControls;

namespace school.App_Code
{
    public class MyClass
    {

        //////////////////////////////////////////////ReadFunctions///////////////////////////////////////////
        //////////////////////////////////////////////ReadFunctions///////////////////////////////////////////
        //////////////////////////////////////////////ReadFunctions///////////////////////////////////////////
        //////////////////////////////////////////////ReadFunctions///////////////////////////////////////////
        //////////////////////////////////////////////ReadFunctions///////////////////////////////////////////
        //////////////////////////////////////////////ReadFunctions///////////////////////////////////////////
        //////////////////////////////////////////////ReadFunctions///////////////////////////////////////////



        //////////////////////////////////////////////Base Read Function///////////////////////////////////////////
        //////////////////////////////////////////////Base Read Function///////////////////////////////////////////

        public static bool NetCheck = false;
        static private string ConStr = @"";
        static private string GetConnection = @"";
        public static byte[] theBytes;

        static private string PublicConStr = @"Data Source=SQL6007.site4now.net;Initial Catalog=DB_A50589_PublicData;User Id=DB_A50589_PublicData_admin;Password=need4speed123159;";
        


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

        //////////////////////////////////////////////Constractors///////////////////////////////////////////
        //////////////////////////////////////////////Constractors///////////////////////////////////////////

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


        static public string IDChecker(string ID)
        {

            int num1, save1, i = -1;


            num1 = ID.Length;

            if (num1 == 9)
            {
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
                    return "1";
                }

                else
                {
                    return "0";
                }

            }
            else
            {
                return "0";
            }

        }


        static public string CreateRandomPassword(string ID, string Case)
        {

            string save = "", strings = "", Result = "";
            int i = 0;
            string pass = "", Pass2 = "";
            int randomchar;
            char char2;


            Random rand = new Random();


            while (pass.Length <= (randomchar = rand.Next(6, 8)))
            {

                randomchar = rand.Next(70, 140);

                if (randomchar >= 97 && randomchar <= 122)
                {
                    char2 = (char)randomchar;
                    pass += char2.ToString();
                }
                else
                {
                    strings = randomchar.ToString();
                    pass += strings;
                }

            }

            return Result = CreateAccount(ID, pass, Case);

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
                return Error=a.Message + "Parents Create Accounts Faild -->" + a.ToString();
            }
            finally
            {
                PublicCon1.Close();
            }

            return "Parents Account Created";

        }

        //////////////////////////////////////////////Students///////////////////////////////////////////
        //////////////////////////////////////////////Students///////////////////////////////////////////
        //////////////////////////////////////////////Students///////////////////////////////////////////

        static public DataTable ShowStudents()
        {
            string Query = "SELECT * from Students";
            return SelectData(Query, ConStr);
        }

        static public DataTable SelectStudent(string SID)
        {
            string Query = "SELECT * from Students Where SID =" + SID;
            return SelectData(Query, ConStr);
        }

        static public DataTable SelectStudentsByClassCode (int ClassCode)
        {
            string Query = "SELECT SID from Students Where ClassCode ='" + ClassCode + "'";
            return SelectData(Query, ConStr);
        }

        static public DataTable SelectStudentsByPID(string PID)
        {
            string Query = "SELECT * from Students Where PID ='" + PID + "'";
            return SelectData(Query, ConStr);
        }

        static public DataTable SelectStudentsByClassCode2(int ClassCode)
        {
            string Query = "SELECT * from Students Where ClassCode ='" + ClassCode + "'";
            return SelectData(Query, ConStr);
        }

        static public DataTable SelectStudentsByName(string Name)
        {
            string Query = "SELECT SID from Students Where SName ='" + Name + "'";
            return SelectData(Query, ConStr);
        }

        static public DataTable FindStudentByID(string SID)
        {
            string Query = "SELECT * from Students Where SID ="+SID;
            return SelectData(Query, ConStr);
        }

        static public DataTable RemoveStudent(string SID)
        {
            string Query = "DELETE from Students where SID =" + SID;
            return SelectData(Query, ConStr);
        }

        static public DataTable RemoveStudentByPID(string PID)
        {
            string Query = "DELETE from Students where PID =" + PID;
            return SelectData(Query, ConStr);
        }

        static public DataTable RemoveStudentByClassCode(int ClassCode)
        {
            string Query = "DELETE from Students where ClassCode =" + ClassCode;
            return SelectData(Query, ConStr);
        }

        static public DataTable SetClass(int CCode)
        {
            string Query = "SELECT CName from Classes Where ClassCode ="+ CCode;
            return SelectData(Query, ConStr);
        }


        //////////////////////////////////////////////Parents///////////////////////////////////////////
        //////////////////////////////////////////////Parents///////////////////////////////////////////
        //////////////////////////////////////////////Parents///////////////////////////////////////////

        static public DataTable ShowParents()
        {
            string Query = "SELECT * from Parents";
            return SelectData(Query, ConStr);
        }

        static public DataTable SelectParent(string PID)
        {
            string Query = "SELECT PName , PID, PhoneNumber from Parents Where PID ='"+PID+"'";
            return SelectData(Query, ConStr);
        }

        static public DataTable SelectParentsCountBySID(string PID)
        {
            string Query = "SELECT * from Students Where PID ='" + PID + "'";
            return SelectData(Query, ConStr);
        }
        static public DataTable SelectParentPublicDBAccount(string PID)
        {
            string Query = "SELECT * from ParentsLogin where PID ='" + PID + "'";
            return SelectData(Query, PublicConStr1);
        }

        static public DataTable SelectParentPublicDB(string PID)
        {
            string Query = "SELECT * from SchoolPID where PID ='" + PID +"'";
            return SelectData(Query, PublicConStr1);
        }

        static public DataTable SelectParentPublicDB2(string PID,string SchoolCode)
        {
            string Query = "SELECT * from SchoolPID where PID ='" + PID + "'AND SchoolCode='"+ SchoolCode+"'";
            return SelectData(Query, PublicConStr1);
        }

        static public DataTable RemoveParent(string PID)
        {
            string Query = "DELETE from Parents where PID ='" + PID+"'";
            return SelectData(Query, ConStr);
        }

        static public DataTable RemoveParentFromPDB(string PID)
        {
            string Query = "DELETE from SchoolPID where PID =" + PID;
            return SelectData(Query, PublicConStr1);
        }

        static public DataTable FindParentByID(string PID)
        {
            string Query = "SELECT * from Parents Where PID =" + PID;
            return SelectData(Query, ConStr);
        }

        static public DataTable SelectParentAndScool (string PID , int SCODE)
        {
            string Query = "SELECT PID , SchoolCode from SchoolPID Where PID ='" + PID + "' AND SchoolCode ='" + SCODE + "'";
            return SelectData(Query, PublicConStr1);
        }

        static public DataTable RemoveParentAndScool(string PID)
        {
            string Query = "DELETE from SchoolPID where PID =" + PID;
            return SelectData(Query, PublicConStr1);
        }


        //////////////////////////////////////////////Classes///////////////////////////////////////////
        //////////////////////////////////////////////Classes///////////////////////////////////////////
        //////////////////////////////////////////////Classes///////////////////////////////////////////

        static public DataTable ShowClasses()
        {
            string Query = "SELECT * from Classes";
            return SelectData(Query, ConStr);
        }

        static public DataTable RemoveClass(int ClassCode)
        {
            string Query = "DELETE from Classes where ClassCode ='" + ClassCode + "'";
            return SelectData(Query, ConStr);
        }

        static public DataTable SelectClass(int ClassCode)
        {
            string Query = "SELECT CName , ClassCode from Classes Where ClassCode ='" + ClassCode +"'";
            return SelectData(Query, ConStr);
        }

        static public DataTable SelectClassNameByCode(int ClassCode)
        {
            string Query = "SELECT CName from Classes Where ClassCode ='" + ClassCode + "'";
            return SelectData(Query, ConStr);
        }

        static public DataTable SelectClassByName(string CName)
        {
            string Query = "SELECT * from Classes Where CName ='" + CName +"'";
            return SelectData(Query, ConStr);
        }

        static public DataTable FindClassByCode(int ClassCode)
        {
            string Query = "SELECT * from Classes Where ClassCode =" + ClassCode;
            return SelectData(Query, ConStr);
        }

        static public DataTable SelectClassesByClassANDSUBJECT(string TID, string SubCode)
        {
            string Query = "SELECT * from SubjectsTecher Where TID='" + TID + "' AND SubCode='" + SubCode + "'";
            DataTable DTNOW= SelectData(Query, ConStr);

            DataTable FinalClasses = new DataTable();

            FinalClasses.Columns.Add(new DataColumn("CName", typeof(string)));
            FinalClasses.Columns.Add(new DataColumn("ClassCode", typeof(string)));

            DataRow CRow;

            for (int i=0;i<DTNOW.Rows.Count;i++)
            {
                Query = "SELECT * from Classes Where ClassCode='" + DTNOW.Rows[i][2] + "'";
                DataTable DTClasses = SelectData(Query, ConStr);

                CRow = FinalClasses.NewRow();
                CRow["CName"] = DTClasses.Rows[0][0].ToString();
                CRow["ClassCode"] = DTClasses.Rows[0][1].ToString();
                FinalClasses.Rows.Add(CRow);
            }

            return FinalClasses;
        }

        //////////////////////////////////////////////Images///////////////////////////////////////////
        //////////////////////////////////////////////Images///////////////////////////////////////////
        //////////////////////////////////////////////Images///////////////////////////////////////////

        static public DataTable RemoveImage(string SID)
        {
            string Query = "DELETE from Images where SID =" + SID;
            return SelectData(Query, ConStr);
        }

        static public DataTable SelectfromImagesBySID(string SID)
        {
            string Query = "SELECT SID from Images Where SID ='" + SID + "'";
            return SelectData(Query, ConStr);
        }

        static public DataTable SelectImageBySID(string SID)
        {
            string Query = "SELECT * from Images Where SID ='" + SID + "'";
            return SelectData(Query, ConStr);
        }

        static public DataTable SelectImagesAndroid(string SID)
        {
            string Query = "SELECT * from ImagesAndroid Where SID ='" + SID + "'";
            return SelectData(Query, ConStr);
        }

        static public DataTable RemoveImagesAndroid(string SID)
        {
            string Query = "DELETE from ImagesAndroid where SID =" + SID;
            return SelectData(Query, ConStr);
        }

        //////////////////////////////////////////////Marks///////////////////////////////////////////
        //////////////////////////////////////////////Marks///////////////////////////////////////////
        //////////////////////////////////////////////Marks///////////////////////////////////////////

        static public DataTable ShowMarks()
        {
            string Query = "SELECT * from Marks";
            return SelectData(Query, ConStr);
        }

        static public DataTable SelectMarkByClassCode(int ClassCode)
        {
            string Query = "SELECT SID from Marks Where ClassCode ='" + ClassCode + "'";
            return SelectData(Query, ConStr);
        }

        static public DataTable SelectMarksRow(string SID, string SCode, int ClassCode, int Mark, string Chapter)
        {
            string Query = "SELECT * from Marks Where SID ='" + SID + "'AND SubName = '" + SCode + "'AND ClassCode='" + ClassCode + "'AND Mark='" + Mark + "'AND Chapter='"+ Chapter +"'";
            return SelectData(Query, ConStr);
        }

        static public DataTable SelectMarksRowC(string SID, string SCode, string Chapter)
        {
            string Query = "SELECT * from Marks Where SID ='" + SID + "'AND SubCode = '" + SCode + "'AND Chapter='" + Chapter + "'";
            return SelectData(Query, ConStr);
        }

        static public DataTable SelectMarksByClassAndSID(string SID, int ClassCode)
        {
            string Query = "SELECT * from Marks Where SID ='" + SID + "'AND ClassCode = '" + ClassCode + "'";
            return SelectData(Query, ConStr);
        }

        static public DataTable SelectMarkBySubCode(string SubCode)
        {
            string Query = "SELECT *from Marks Where SubCode ='" + SubCode + "'";
            return SelectData(Query, ConStr);
        }

        static public DataTable SelectMarkBySID(string SID)
        {
            string Query = "SELECT SID from Marks Where SID ='" + SID + "'";
            return SelectData(Query, ConStr);
        }

        static public DataTable SelectMarkBySID2(string SID)
        {
            string Query = "SELECT * from Marks Where SID ='" + SID + "'";
            return SelectData(Query, ConStr);
        }

        static public DataTable RemoveMarkBySID(string SID)
        {
            string Query = "DELETE from Marks where SID ='" + SID + "'";
            return SelectData(Query, ConStr);
        }

        static public DataTable RemoveMark(string SID,string SubName,int ClassCode,string Chapter)
        {
            string Query = "DELETE from Marks where SID ='" + SID + "' AND SubName = '"+ SubName+"' AND ClassCode ='"+ClassCode+"' AND Chapter ='"+ Chapter+"'";
            return SelectData(Query, ConStr);
        }

        static public DataTable RemoveMarkBySubCode(string SubCode)
        {
            string Query = "DELETE from Marks where SubCode ='" + SubCode + "'";
            return SelectData(Query, ConStr);
        }

        static public DataTable RemoveMarkByRow(int Row)
        {
            string Query = "DELETE from Marks where Cnt =" + Row;
            return SelectData(Query, ConStr);
        }

        static public DataTable RemoveMarkByClassCode(int ClassCode)
        {
            string Query = "DELETE from Marks where ClassCode ='" + ClassCode + "'";
            return SelectData(Query, ConStr);
        }

        static public DataTable SelectMark(string SID, string SubName,int ClassCode, string Chapter)
        {
            string Query = "SELECT SID , SubName, Mark, ClassCode,Chapter from Marks Where SID ='" + SID +"' AND SubName ='"+SubName+"' AND Chapter ='"+Chapter+"'";
            return SelectData(Query, ConStr);
        }

        //////////////////////////////////////////////SubjectTecher///////////////////////////////////////////
        //////////////////////////////////////////////SubjectTecher///////////////////////////////////////////
        //////////////////////////////////////////////SubjectTecher///////////////////////////////////////////


        static public DataTable ShowSubjectTecher()
        {
            string Query = "SELECT * from SubjectsTecher";
            return SelectData(Query, ConStr);
        }

        static public DataTable SelectInfoSubjectTecher(string TID)
        {
            string Query = "SELECT SubCode , ClassCode from SubjectsTecher where TID='"+ TID+"'";
            return SelectData(Query, ConStr);
        }

        static public DataTable SelectInfoSubjectClass(string ClassCode)
        {
            string Query = "SELECT SubCode from SubjectsTecher where ClassCode='" + ClassCode + "'";
            return SelectData(Query, ConStr);
        }

        static public DataTable SelectInfoSubjectTecherByClassCode(string ClassCode)
        {
            string Query = "SELECT SubCode from SubjectsTecher where ClassCode='" + ClassCode + "'";
            return SelectData(Query, ConStr);
        }

        static public DataTable RemoveSubjectTecherByClassCode(int ClassCode)
        {
            string Query = "DELETE from SubjectsTecher where ClassCode ='" + ClassCode + "'";
            return SelectData(Query, ConStr);
        }

        static public DataTable SelectSubjectsTecherRow(string SCode, string TID,int ClassCode)
        {
            string Query = "SELECT * from SubjectsTecher Where TID ='" + TID + "'AND ClassCode = '" + ClassCode + "'AND SubCode='"+SCode+"'";
            return SelectData(Query, ConStr);
        }

        static public DataTable SelectSubjectsTecherRow3(string SCode, int ClassCode)
        {
            string Query = "SELECT * from SubjectsTecher Where SubCode = '" + SCode + "'AND ClassCode='" + ClassCode + "'";
            return SelectData(Query, ConStr);
        }

        static public DataTable SelectSubjectsTecherRow2(int Row)
        {
            string Query = "SELECT * from SubjectsTecher Where Cnt ='" + Row + "'";
            return SelectData(Query, ConStr);
        }

        static public DataTable SelectSubjectTecherByClassCode(int ClassCode)
        {
            string Query = "SELECT ClassCode from SubjectsTecher Where ClassCode ='" + ClassCode + "'";
            return SelectData(Query, ConStr);
        }

        static public DataTable SelectSubjectTecherBySCode(string SubCode)
        {
            string Query = "SELECT * from SubjectsTecher Where SubCode ='" + SubCode + "'";
            return SelectData(Query, ConStr);
        }

        static public DataTable SelectSubjectsTecherByTID(string TID)
        {
            string Query = "SELECT * from SubjectsTecher Where TID ='" + TID + "'";
            return SelectData(Query, ConStr);
        }


        static public DataTable SelectSubjectTecher(string TID)
        {
            string Query = "SELECT * from SubjectsTecher Where TID ='" + TID + "'";
            return SelectData(Query, ConStr);
        }

        static public DataTable RemoveSubjectTecherByRow(int Row)
        {
            string Query = "DELETE from SubjectsTecher where Cnt ='" + Row+"'";
            return SelectData(Query, ConStr);
        }

        static public DataTable RemoveSubjectTecherByTID(string TID)
        {
            string Query = "DELETE from SubjectsTecher where TID =" + TID;
            return SelectData(Query, ConStr);
        }

        static public DataTable RemoveSubjectTecherBySubCode(string SubCode)
        {
            string Query = "DELETE from SubjectsTecher where SubCode =" + SubCode;
            return SelectData(Query, ConStr);
        }

        //////////////////////////////////////////////Techers///////////////////////////////////////////
        //////////////////////////////////////////////Techers///////////////////////////////////////////
        //////////////////////////////////////////////Techers///////////////////////////////////////////

        static public DataTable ShowTechers()
        {
            string Query = "SELECT * from Techers";
            return SelectData(Query, ConStr);
        }

        static public DataTable RemoveTecherFromPDB(string TID)
        {
            string Query = "DELETE from SchoolTID where TID =" + TID;
            return SelectData(Query, PublicConStr1);
        }

        static public DataTable RemoveTecher(string TID)
        {
            string Query = "DELETE from Techers where TID =" + TID;
            return SelectData(Query, ConStr);
        }

        static public DataTable SelectTecher(string TID)
        {
            string Query = "SELECT * from Techers Where TID ='" + TID + "'";
            return SelectData(Query, ConStr);
        }

        static public DataTable SelectTecherPass(string TID)
        {
            string Query = "SELECT * from Logintecher Where TID ='" + TID + "'";
            return SelectData(Query, PublicConStr1);
        }

        static public DataTable SelectTecherPublicDB(string TID)
        {
            string Query = "SELECT * from SchoolTID where TID ='" + TID + "'";
            return SelectData(Query, PublicConStr1);
        }

        static public DataTable SelectTecherPublicDB2(string TID,string SchoolCode)
        {
            string Query = "SELECT * from SchoolTID where TID ='" + TID + "'AND SchoolCode ='" + SchoolCode + "'";
            return SelectData(Query, PublicConStr1);
        }

        static public DataTable RemoveFromExams(string TID)
        {
            string Query = "DELETE from Exams where TID ='" + TID +"'";
            return SelectData(Query, ConStr);
        }

        static public DataTable SelectExamBYTID(string TID)
        {
            string Query = "SELECT * from Exams Where TID ='" + TID + "'";
            return SelectData(Query, ConStr);
        }

        static public DataTable RemoveFromWorks(string TID)
        {
            string Query = "DELETE from Works where TID ='" + TID + "'";
            return SelectData(Query, ConStr);
        }

        static public DataTable SelectWorkByTID(string TID)
        {
            string Query = "SELECT * from Works Where TID ='" + TID + "'";
            return SelectData(Query, ConStr);
        }

        //////////////////////////////////////////////Techer Schedules///////////////////////////////////////////
        //////////////////////////////////////////////Techer Schedules///////////////////////////////////////////
        //////////////////////////////////////////////Techer Schedules///////////////////////////////////////////

        static public DataTable ShowTecherSchedules()
        {
            string Query = "SELECT * from Schedules";
            return SelectData(Query, ConStr);
        }

        static public DataTable SelectSchedulesByRow(int Row)
        {
            string Query = "SELECT * from Schedules Where Cnt='" + Row + "'";
            return SelectData(Query, ConStr);
        }

        static public void RemoveClassSchedules()
        {
            string Query = "DELETE from ClassSchedules";
            SelectData(Query, ConStr);
        }

        static public void RemoveTecherSchedulesLastRow()
        {
            string Query = "DELETE from Schedules Where Cnt in(SELECT MAX(Cnt) FROM Schedules)";
            SelectData(Query, ConStr);
        }
   
        static public DataTable SelectSchedulesByTID(string TID)
        {
            string Query = "SELECT * from Schedules Where TID ='" + TID + "'";
            return SelectData(Query, ConStr);
        }

        static public DataTable SelectTecherSchedulByDay(string TID, string Day)
        {
            string Query = "SELECT * from Schedules Where TID ='" + TID + "'AND Day='" + Day + "'";
            return SelectData(Query, ConStr);
        }

        static public DataTable RemoveSchedule(int Row)
        {
            string Query = "DELETE from Schedules where Cnt ='" + Row +"'";
            return SelectData(Query, ConStr);
        }

        static public DataTable RemoveScheduleByTID(string TID)
        {
            string Query = "DELETE from Schedules where TID ='" + TID + "'";
            return SelectData(Query, ConStr);
        }

        static public DataTable ShowClassesSchedulesSorted()
        {
            string Query = "SELECT * from Classes";
            DataTable DTClasses = SelectData(Query, ConStr);
            DataTable FinalSchedules = new DataTable();
            DataTable CurrentSchedules = new DataTable();
            int DONT = 0;


            FinalSchedules.Columns.Add(new DataColumn("Cnt", typeof(int)));
            FinalSchedules.Columns.Add(new DataColumn("L1", typeof(string)));
            FinalSchedules.Columns.Add(new DataColumn("L2", typeof(string)));
            FinalSchedules.Columns.Add(new DataColumn("L3", typeof(string)));
            FinalSchedules.Columns.Add(new DataColumn("L4", typeof(string)));
            FinalSchedules.Columns.Add(new DataColumn("L5", typeof(string)));
            FinalSchedules.Columns.Add(new DataColumn("L6", typeof(string)));
            FinalSchedules.Columns.Add(new DataColumn("L7", typeof(string)));
            FinalSchedules.Columns.Add(new DataColumn("Class", typeof(string)));
            FinalSchedules.Columns.Add(new DataColumn("Day", typeof(string)));

            //////////// Getting All Classes
            for (int row = 0; row < DTClasses.Rows.Count; row++)
            {
                //////////// Checking if ClassName Exist IN Final Tabel
                for (int cnt = 0; cnt < FinalSchedules.Rows.Count; cnt++)
                {
                    if (FinalSchedules.Rows[cnt][8].ToString().Equals(DTClasses.Rows[row][0]))
                    {
                        DONT = 1;
                    }
                }

                //////////// if not Exist then add the Rows
                if (DONT != 1)
                {
                    //////////// Getting Class Schdules 
                    string Query2 = "SELECT * from ClassSchedules Where Class='" + DTClasses.Rows[row][0] + "'";
                    CurrentSchedules = SelectData(Query2, ConStr);

                    //////////// Adding Schdules Rows To Final Tabel
                    foreach (DataRow dr in CurrentSchedules.Rows)
                    {
                        FinalSchedules.Rows.Add(dr.ItemArray);
                    }
                }

                DONT = 0;
            }

            return FinalSchedules;
        }

        static public DataTable ShowClassesSchedules()
        {
            string Query = "SELECT * from ClassSchedules";
            return SelectData(Query, ConStr);
        }
        static public DataTable SelectClassSchedules(string ClassName)
        {
            string Query = "SELECT * from ClassSchedules Where Class='" + ClassName + "'";
            DataTable CurrentSchedules = SelectData(Query, ConStr);

            DataTable FinalSchedules = new DataTable();

            FinalSchedules.Columns.Add(new DataColumn("Cnt", typeof(int)));
            FinalSchedules.Columns.Add(new DataColumn("L1", typeof(string)));
            FinalSchedules.Columns.Add(new DataColumn("L2", typeof(string)));
            FinalSchedules.Columns.Add(new DataColumn("L3", typeof(string)));
            FinalSchedules.Columns.Add(new DataColumn("L4", typeof(string)));
            FinalSchedules.Columns.Add(new DataColumn("L5", typeof(string)));
            FinalSchedules.Columns.Add(new DataColumn("L6", typeof(string)));
            FinalSchedules.Columns.Add(new DataColumn("L7", typeof(string)));
            FinalSchedules.Columns.Add(new DataColumn("Class", typeof(string)));
            FinalSchedules.Columns.Add(new DataColumn("Day", typeof(string)));

            //////////// Adding Schdules Rows AND Add 7 Days AND Sort The DAYS 
            int indx = 0,Exist=0;
            foreach (DataRow dr in CurrentSchedules.Rows)
            {
                if (CurrentSchedules.Rows[indx++][9].ToString().Equals("One"))
                {
                    FinalSchedules.Rows.Add(dr.ItemArray);
                    Exist = 1;
                }
                    
            }

            if(Exist==0)
            {
                DataRow EmptyRow = FinalSchedules.NewRow();
                EmptyRow["Cnt"] = 0;
                EmptyRow["L1"] = "❌";
                EmptyRow["L2"] = "❌";
                EmptyRow["L3"] = "❌";
                EmptyRow["L4"] = "❌";
                EmptyRow["L5"] = "❌";
                EmptyRow["L6"] = "❌";
                EmptyRow["L7"] = "❌";
                EmptyRow["Class"] = "❌";
                EmptyRow["Day"] = "One";
                FinalSchedules.Rows.Add(EmptyRow);
                Exist = 0;
            }

            Exist = 0;
            indx = 0;
            foreach (DataRow dr in CurrentSchedules.Rows)
            {
                if (CurrentSchedules.Rows[indx++][9].ToString().Equals("Two"))
                {
                    FinalSchedules.Rows.Add(dr.ItemArray);
                    Exist = 1;
                }
            }

            if (Exist == 0)
            {
                DataRow EmptyRow = FinalSchedules.NewRow();
                EmptyRow["Cnt"] = 0;
                EmptyRow["L1"] = "❌";
                EmptyRow["L2"] = "❌";
                EmptyRow["L3"] = "❌";
                EmptyRow["L4"] = "❌";
                EmptyRow["L5"] = "❌";
                EmptyRow["L6"] = "❌";
                EmptyRow["L7"] = "❌";
                EmptyRow["Class"] = "❌";
                EmptyRow["Day"] = "Two";
                FinalSchedules.Rows.Add(EmptyRow);
                Exist = 0;
            }

            Exist = 0;
            indx = 0;
            foreach (DataRow dr in CurrentSchedules.Rows)
            {
                if (CurrentSchedules.Rows[indx++][9].ToString().Equals("Three"))
                {
                    FinalSchedules.Rows.Add(dr.ItemArray);
                    Exist = 1;
                }
                    
            }

            if (Exist == 0)
            {
                DataRow EmptyRow = FinalSchedules.NewRow();
                EmptyRow["Cnt"] = 0;
                EmptyRow["L1"] = "❌";
                EmptyRow["L2"] = "❌";
                EmptyRow["L3"] = "❌";
                EmptyRow["L4"] = "❌";
                EmptyRow["L5"] = "❌";
                EmptyRow["L6"] = "❌";
                EmptyRow["L7"] = "❌";
                EmptyRow["Class"] = "❌";
                EmptyRow["Day"] = "Three";
                FinalSchedules.Rows.Add(EmptyRow);
                Exist = 0;
            }

            Exist = 0;
            indx = 0;
            foreach (DataRow dr in CurrentSchedules.Rows)
            {
                if (CurrentSchedules.Rows[indx++][9].ToString().Equals("Four"))
                {
                    FinalSchedules.Rows.Add(dr.ItemArray);
                    Exist = 1;
                }
                    
            }

            if (Exist == 0)
            {
                DataRow EmptyRow = FinalSchedules.NewRow();
                EmptyRow["Cnt"] = 0;
                EmptyRow["L1"] = "❌";
                EmptyRow["L2"] = "❌";
                EmptyRow["L3"] = "❌";
                EmptyRow["L4"] = "❌";
                EmptyRow["L5"] = "❌";
                EmptyRow["L6"] = "❌";
                EmptyRow["L7"] = "❌";
                EmptyRow["Class"] = "❌";
                EmptyRow["Day"] = "Four";
                FinalSchedules.Rows.Add(EmptyRow);
                Exist = 0;
            }

            Exist = 0;
            indx = 0;
            foreach (DataRow dr in CurrentSchedules.Rows)
            {
                if (CurrentSchedules.Rows[indx++][9].ToString().Equals("Five"))
                {
                    FinalSchedules.Rows.Add(dr.ItemArray);
                    Exist = 1;
                }
                    
            }

            if (Exist == 0)
            {
                DataRow EmptyRow = FinalSchedules.NewRow();
                EmptyRow["Cnt"] = 0;
                EmptyRow["L1"] = "❌";
                EmptyRow["L2"] = "❌";
                EmptyRow["L3"] = "❌";
                EmptyRow["L4"] = "❌";
                EmptyRow["L5"] = "❌";
                EmptyRow["L6"] = "❌";
                EmptyRow["L7"] = "❌";
                EmptyRow["Class"] = "❌";
                EmptyRow["Day"] = "Five";
                FinalSchedules.Rows.Add(EmptyRow);
                Exist = 0;
            }

            Exist = 0;
            indx = 0;
            foreach (DataRow dr in CurrentSchedules.Rows)
            {
                if (CurrentSchedules.Rows[indx++][9].ToString().Equals("Six"))
                {
                    FinalSchedules.Rows.Add(dr.ItemArray);
                    Exist = 1;
                }
                    
            }

            if (Exist == 0)
            {
                DataRow EmptyRow = FinalSchedules.NewRow();
                EmptyRow["Cnt"] = 0;
                EmptyRow["L1"] = "❌";
                EmptyRow["L2"] = "❌";
                EmptyRow["L3"] = "❌";
                EmptyRow["L4"] = "❌";
                EmptyRow["L5"] = "❌";
                EmptyRow["L6"] = "❌";
                EmptyRow["L7"] = "❌";
                EmptyRow["Class"] = "❌";
                EmptyRow["Day"] = "Six";
                FinalSchedules.Rows.Add(EmptyRow);
                Exist = 0;
            }

            Exist = 0;
            indx = 0;
            foreach (DataRow dr in CurrentSchedules.Rows)
            {
                if (CurrentSchedules.Rows[indx++][9].ToString().Equals("Seven"))
                {
                    FinalSchedules.Rows.Add(dr.ItemArray);
                    Exist = 1;
                }
                    
            }

            if (Exist == 0)
            {
                DataRow EmptyRow = FinalSchedules.NewRow();
                EmptyRow["Cnt"] = 0;
                EmptyRow["L1"] = "❌";
                EmptyRow["L2"] = "❌";
                EmptyRow["L3"] = "❌";
                EmptyRow["L4"] = "❌";
                EmptyRow["L5"] = "❌";
                EmptyRow["L6"] = "❌";
                EmptyRow["L7"] = "❌";
                EmptyRow["Class"] = "❌";
                EmptyRow["Day"] = "Seven";
                FinalSchedules.Rows.Add(EmptyRow);
                Exist = 0;
            }

            indx = 0;
            foreach (DataRow dr in CurrentSchedules.Rows)
            {
                string Dayy = CurrentSchedules.Rows[indx++][9].ToString();

                if (!Dayy.Equals("One")&& !Dayy.Equals("Two") && !Dayy.Equals("Three") && !Dayy.Equals("Four") && !Dayy.Equals("Five") && !Dayy.Equals("Six") && !Dayy.Equals("Seven"))
                    FinalSchedules.Rows.Add(dr.ItemArray);
            }

            return FinalSchedules;
        }

        //////////////////////////////////////////////Subjects///////////////////////////////////////////
        //////////////////////////////////////////////Subjects///////////////////////////////////////////
        //////////////////////////////////////////////Subjects///////////////////////////////////////////

        static public DataTable ShowSubjects()
        {
            string Query = "SELECT * from Subjects";
            return SelectData(Query, ConStr);
        }

        static public DataTable SelectSubject(string SubCode)
        {
            string Query = "SELECT * from Subjects Where SubCode ='" + SubCode + "'";
            return SelectData(Query, ConStr);
        }

        static public DataTable SelectSubjectByName(string Name)
        {
            string Query = "SELECT * from Subjects Where SubName =N'"+Name+"'";
            return SelectData(Query, ConStr);
        }

        static public DataTable RemoveSubject(string SubCode)
        {
            string Query = "DELETE from Subjects where SubCode =" + SubCode;
            return SelectData(Query, ConStr);
        }

        //////////////////////////////////////////////Messages///////////////////////////////////////////
        //////////////////////////////////////////////Messages///////////////////////////////////////////
        //////////////////////////////////////////////Messages///////////////////////////////////////////

        static public DataTable Messages(string SID)
        {
            string Query = "SELECT * from Messages where SID='"+SID+"'";
            return SelectData(Query, ConStr);
        }

        static public DataTable RemoveMessages(string SID)
        {
            string Query = "DELETE from Messages where SID =" + SID;
            return SelectData(Query, ConStr);
        }

        //////////////////////////////////////////////Presences///////////////////////////////////////////
        //////////////////////////////////////////////Presences///////////////////////////////////////////
        //////////////////////////////////////////////Presences///////////////////////////////////////////

        static public DataTable Presences(string SID)
        {
            string Query = "SELECT * from Presences where SID='" + SID + "'";
            return SelectData(Query, ConStr);
        }

        static public DataTable RemovePresences(string SID)
        {
            string Query = "DELETE from Presences where SID =" + SID;
            return SelectData(Query, ConStr);
        }

        //////////////////////////////////////////////Wright///////////////////////////////////////////
        //////////////////////////////////////////////Wright///////////////////////////////////////////
        //////////////////////////////////////////////Wright///////////////////////////////////////////
        //////////////////////////////////////////////Wright///////////////////////////////////////////
        //////////////////////////////////////////////Wright///////////////////////////////////////////
        //////////////////////////////////////////////Wright///////////////////////////////////////////
        //////////////////////////////////////////////Wright///////////////////////////////////////////


        //////////////////////////////////////////////Students///////////////////////////////////////////
        //////////////////////////////////////////////Students///////////////////////////////////////////

        public static string AddStudent(string SName, string SID, string PID, int ClassCode,string Phone,string Adress,string BDate)
        {
            
            try
            {
                string Quary;
                Quary = "insert into Students(SName,SID,PID,ClassCode,Phone,Adress,BDate)  values(@SName,@SID,@PID,@ClassCode,@Phone,@Adress,@BDate)";
                Cmd1.Parameters.Clear();
                Con1.Open();
                Cmd1.CommandText = Quary;
                Cmd1.Connection = Con1;
                Cmd1.Parameters.Add("@SName", SqlDbType.NVarChar).Value = SName;
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
                s = a.Message.ToString()+"Error"+a.ToString();

                return a.Message + "Add Student Faild -->" + a.ToString();
            }
            finally
            {
                Con1.Close();
            }

            return "Student Added";
        }

        public static string AddStudent2(string SName, string SID, string PID, int ClassCode, string @Connection)
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
                Cmd1.Parameters.Add("@SName", SqlDbType.VarChar).Value = SName;
                Cmd1.Parameters.Add("@SID", SqlDbType.VarChar).Value = SID;
                Cmd1.Parameters.Add("@PID", SqlDbType.VarChar).Value = PID;
                Cmd1.Parameters.Add("@ClassCode", SqlDbType.Int).Value = ClassCode;
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

        public static string UpdateStudent(string SName,string SID, string PID, int ClassCode)
        {           
            try
            {
                string Quary;
                Cmd1.Parameters.Clear();

                Quary = "UPDATE Students set SName = @SName, ClassCode = @ClassCode, PID = @PID WHERE SID = @SID";

                Con1.Open();
                Cmd1.CommandText = Quary;
                Cmd1.Connection = Con1;
                Cmd1.Parameters.AddWithValue("@SName", SqlDbType.NVarChar).Value = SName;
                Cmd1.Parameters.AddWithValue("@ClassCode", SqlDbType.Int).Value = ClassCode;
                Cmd1.Parameters.AddWithValue("@PID", SqlDbType.VarChar).Value = PID;
                Cmd1.Parameters.AddWithValue("@SID", SqlDbType.VarChar).Value = SID;                        
                Cmd1.ExecuteNonQuery();


            }
            catch (Exception a)
            {
                return a.Message + "Update Student Faild Error -->" + a.ToString();
            }
            finally
            {
                Con1.Close();
            }

            return "Student Updated";
        }

        public static string UpdateAllStudentInfo(string SName, string SID, string PID, int ClassCode,string Phone,string Adress,string BDate)
        {
            try
            {
                string Quary;
                Cmd1.Parameters.Clear();

                Quary = "UPDATE Students set SName = @SName, ClassCode = @ClassCode, PID = @PID,Phone= @Phone,Adress=@Adress,BDate=@BDate WHERE SID = @SID";

                Con1.Open();
                Cmd1.CommandText = Quary;
                Cmd1.Connection = Con1;
                Cmd1.Parameters.AddWithValue("@SName", SqlDbType.NVarChar).Value = SName;
                Cmd1.Parameters.AddWithValue("@ClassCode", SqlDbType.Int).Value = ClassCode;
                Cmd1.Parameters.AddWithValue("@PID", SqlDbType.VarChar).Value = PID;
                Cmd1.Parameters.AddWithValue("@SID", SqlDbType.VarChar).Value = SID;
                Cmd1.Parameters.AddWithValue("@Phone", SqlDbType.VarChar).Value = Phone;
                Cmd1.Parameters.AddWithValue("@Adress", SqlDbType.NVarChar).Value = Adress.ToString();
                Cmd1.Parameters.AddWithValue("@BDate", SqlDbType.VarChar).Value = BDate;
                Cmd1.ExecuteNonQuery();


            }
            catch (Exception a)
            {
                return a.Message + "Update Student Faild Error -->" + a.ToString();
            }
            finally
            {
                Con1.Close();
            }

            return "Student Updated";
        }

        public static string UpdatePIDinStudents(string NewPID, string OLDPID)
        {
            try
            {
                string Quary;
                Cmd1.Parameters.Clear();
                Quary = "UPDATE Students set PID = '" + NewPID + "'Where PID = '" + OLDPID + "'";
                Con1.Open();
                Cmd1.CommandText = Quary;
                Cmd1.Connection = Con1;
                Cmd1.Parameters.Add("@PID", SqlDbType.VarChar).Value = NewPID;
                Cmd1.ExecuteNonQuery();
            }
            catch (Exception a)
            {
                return a.Message + "Update Student Faild Error -->" + a.ToString();
            }
            finally
            {
                Con1.Close();
            }

            return "Student Updated";
        }

        public static string UpdateClassCodeinStudents(int NewClassCode, int OldClassCode)
        {
            try
            {
                string Quary;
                Cmd1.Parameters.Clear();
                Quary = "UPDATE Students set ClassCode = '" + NewClassCode + "' Where ClassCode ='" + OldClassCode + "'";
                Con1.Open();
                Cmd1.CommandText = Quary;
                Cmd1.Connection = Con1;
                Cmd1.Parameters.Add("@ClassCode", SqlDbType.Int).Value = NewClassCode;
                Cmd1.ExecuteNonQuery();

            }
            catch (Exception a)
            {
                return a.Message + "Update Student Faild Error -->" + a.ToString();
            }
            finally
            {
                Con1.Close();
            }

            return "Student Updated";
        }

        //////////////////////////////////////////////Parents///////////////////////////////////////////
        //////////////////////////////////////////////Parents///////////////////////////////////////////

        public static string AddParents(string PName, string PID, string PhoneNumber)
        {
            string BackResult = "";

            BackResult = Con1.ConnectionString.ToString();
            try
            {
                string Quary;
                Quary = "insert into Parents(PName,PID,PhoneNumber)  values(@PName,@PID,@PhoneNumber)";
                Cmd1.Parameters.Clear();               
                Con1.Open();
                Cmd1.CommandText = Quary;
                Cmd1.Connection = Con1;
                Cmd1.Parameters.Add("@PName", SqlDbType.NVarChar).Value = PName;
                Cmd1.Parameters.Add("@PID", SqlDbType.VarChar).Value = PID;
                Cmd1.Parameters.Add("@PhoneNumber", SqlDbType.VarChar).Value = PhoneNumber;

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

        public static string AddParents2(string PName, string PID, int PhoneNumber,string Connection)
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

        public static string AddScoolPID(string PID, int SchoolCode)
        {

            try
            {
                string Quary;
                Quary = "insert into SchoolPID(PID,SchoolCode)  values(@PID,@SchoolCode)";
                Cmd1.Parameters.Clear();
                PublicCon1.Open();
                Cmd1.CommandText = Quary;
                Cmd1.Connection = PublicCon1;
                Cmd1.Parameters.Add("@PID", SqlDbType.VarChar).Value = PID;
                Cmd1.Parameters.Add("@SchoolCode", SqlDbType.Int).Value = SchoolCode;
               
                Cmd1.ExecuteNonQuery();
               
            }
            catch (Exception a)
            {
                return a.Message + "SchoolParents Faild  -->" + a.ToString();
            }
            finally
            {
                PublicCon1.Close();
            }

            return "SchoolParents Added";
        }

        public static string UpdateSchoolPID(string NewPID, string OldPID)
        {
            try
            {
                string Quary;
                Quary = "UPDATE SchoolPID set PID = '" + NewPID + "' Where PID = '" + OldPID + "'";
                Cmd1.Parameters.Clear();
                PublicCon1.Open();
                Cmd1.CommandText = Quary;
                Cmd1.Connection = PublicCon1;
                Cmd1.Parameters.Add("@PID", SqlDbType.VarChar).Value = NewPID;

                Cmd1.ExecuteNonQuery();
            }
            catch (Exception a)
            {
                return a.Message + "Update Parent in SchoolPID Faild Error -->" + a.ToString();
            }
            finally
            {
                PublicCon1.Close();
            }

            return "Parent Updated in SchoolPID";
        }

        public static string UpdateParent(string PName, string PID, int PhoneNumber)
        {
            try
            {
                string Quary;

                Quary = "UPDATE Parents set PName = @PName, PhoneNumber = @PhoneNumber Where PID = @PID";

                Cmd1.Parameters.Clear();
                Con1.Open();
                Cmd1.CommandText = Quary;
                Cmd1.Connection = Con1;
                Cmd1.Parameters.Add("@PName", SqlDbType.NVarChar).Value = PName;
                Cmd1.Parameters.Add("@PID", SqlDbType.VarChar).Value = PID;
                Cmd1.Parameters.Add("@PhoneNumber", SqlDbType.Int).Value = PhoneNumber;
                Cmd1.ExecuteNonQuery();
                
            }
            catch (Exception a)
            {
                return a.Message + "Update Parent Faild Error -->" + a.ToString();
            }
            finally
            {
                Con1.Close();
            }

            return "Parent Updated";
        }

        //////////////////////////////////////////////Class///////////////////////////////////////////
        //////////////////////////////////////////////Class///////////////////////////////////////////

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
            finally
            {
                Con1.Close();
            }

            return "Class Added";
        }

        public static string AddClass2(string ClassName, int ClassCode)
        {
            SqlConnection Con2 = new SqlConnection();

            try
            {
                string Quary;
                Quary = "insert into Classes(CName,ClassCode)  values(@CName,@ClassCode)";
                Cmd1.Parameters.Clear();
                Con1.Open();
                Cmd1.CommandText = Quary;
                Cmd1.Connection = Con1;
                Cmd1.Parameters.Add("@CName", SqlDbType.VarChar).Value = ClassName;
                Cmd1.Parameters.Add("@ClassCode", SqlDbType.Int).Value = ClassCode;

                Cmd1.ExecuteNonQuery();


            }
            catch (Exception a)
            {
                return a.Message + "Add Class Faild -->" + a.ToString();
            }
            finally
            {
                Con1.Close();
            }

            return "Class Added";
        }

        public static string UpdateClass(string CName, int ClassCode)
        {
            try
            {
                string Quary;
                Cmd1.Parameters.Clear();
                Quary = "UPDATE Classes set CName = '" + CName + "' Where ClassCode = '" + ClassCode + "'";
                Con1.Open();
                Cmd1.CommandText = Quary;
                Cmd1.Connection = Con1;
                Cmd1.Parameters.Add("@CName", SqlDbType.VarChar).Value = CName;
                
                Cmd1.ExecuteNonQuery();
               
            }
            catch (Exception a)
            {
                return a.Message + "Update Class Faild Error -->" + a.ToString();
            }
            finally
            {
                Con1.Close();
            }

            return "Class Updated";
        }

        public static string UpdateClassCodeinMessages(int NewClassCode,string SID)
        {
            try
            {
                string Quary;
                Cmd1.Parameters.Clear();
                Quary = "UPDATE Messages set ClassCode = '" + NewClassCode + "' Where SID ='" + SID + "'";
                Con1.Open();
                Cmd1.CommandText = Quary;
                Cmd1.Connection = Con1;
                Cmd1.Parameters.Add("@ClassCode", SqlDbType.Int).Value = NewClassCode;
                Cmd1.ExecuteNonQuery();

            }
            catch (Exception a)
            {
                return a.Message + "Update Messages Faild Error -->" + a.ToString();
            }
            finally
            {
                Con1.Close();
            }

            return "Messages Updated";
        }

        public static string UpdateClassCodeinMessages2(int NewClassCode, string SID)
        {
            try
            {
                string Quary;
                Cmd1.Parameters.Clear();
                Quary = "UPDATE Messages set ClassCode = '" + NewClassCode + "' Where SID ='" + SID + "'";
                Con1.Open();
                Cmd1.CommandText = Quary;
                Cmd1.Connection = Con1;
                Cmd1.Parameters.Add("@ClassCode", SqlDbType.Int).Value = NewClassCode;
                Cmd1.ExecuteNonQuery();

            }
            catch (Exception a)
            {
                return a.Message + "Update Messages Faild Error -->" + a.ToString();
            }
            finally
            {
                Con1.Close();
            }

            return "Messages Updated";
        }

        //////////////////////////////////////////////Marks///////////////////////////////////////////
        //////////////////////////////////////////////Marks///////////////////////////////////////////

        public static string UpdateSIDinMarks(string SID, int Row)
        {
            try
            {
                string Quary;
                Cmd1.Parameters.Clear();
                Quary = "UPDATE Marks set SID = '" + SID + "' Where Cnt ='" + Row + "'";
                Con1.Open();
                Cmd1.CommandText = Quary;
                Cmd1.Connection = Con1;
                Cmd1.Parameters.Add("@SID", SqlDbType.VarChar).Value = SID;
                Cmd1.ExecuteNonQuery();

            }

            catch (Exception a)
            {
                return a.Message + "Update Marks Faild Error -->" + a.ToString();
            }

            finally
            {
                Con1.Close();
            }

            return "Marks Updated";
        }

        public static string UpdateSubjectinMarks(string SCode, int Row)
        {
            try
            {
                string Quary;
                Cmd1.Parameters.Clear();
                Quary = "UPDATE Marks set SubName = '" + SCode + "' Where Cnt ='" + Row + "'";
                Con1.Open();
                Cmd1.CommandText = Quary;
                Cmd1.Connection = Con1;
                Cmd1.Parameters.Add("@SubName", SqlDbType.VarChar).Value = SCode;
                Cmd1.ExecuteNonQuery();

            }

            catch (Exception a)
            {
                return a.Message + "Update Marks Faild Error -->" + a.ToString();
            }

            finally
            {
                Con1.Close();
            }

            return "Marks Updated";
        }

        public static string UpdateClassCodeinMarks(string ClassCode, int Row)
        {
            try
            {
                string Quary;
                Cmd1.Parameters.Clear();
                Quary = "UPDATE Marks set ClassCode = '" + ClassCode + "' Where Cnt ='" + Row + "'";
                Con1.Open();
                Cmd1.CommandText = Quary;
                Cmd1.Connection = Con1;
                Cmd1.Parameters.Add("@ClassCode", SqlDbType.Int).Value = int.Parse(ClassCode.ToString());
                Cmd1.ExecuteNonQuery();

            }

            catch (Exception a)
            {
                return a.Message + "Update Marks Faild Error -->" + a.ToString();
            }

            finally
            {
                Con1.Close();
            }

            return "Marks Updated";
        }

        public static string UpdateMarkinMarks(string Mark, int Row)
        {
            try
            {
                string Quary;
                Cmd1.Parameters.Clear();
                Quary = "UPDATE Marks set Mark = '" + Mark + "' Where Cnt ='" + Row + "'";
                Con1.Open();
                Cmd1.CommandText = Quary;
                Cmd1.Connection = Con1;
                Cmd1.Parameters.Add("@Mark", SqlDbType.Int).Value = int.Parse(Mark.ToString());
                Cmd1.ExecuteNonQuery();

            }

            catch (Exception a)
            {
                return a.Message + "Update Marks Faild Error -->" + a.ToString();
            }

            finally
            {
                Con1.Close();
            }

            return "Marks Updated";
        }

        public static string UpdateChapterinMarks(string Chapter, int Row)
        {
            try
            {
                string Quary;
                Cmd1.Parameters.Clear();
                Quary = "UPDATE Marks set Chapter = '" + Chapter + "' Where Cnt ='" + Row + "'";
                Con1.Open();
                Cmd1.CommandText = Quary;
                Cmd1.Connection = Con1;
                Cmd1.Parameters.Add("@Chapter", SqlDbType.VarChar).Value = Chapter.ToString();
                Cmd1.ExecuteNonQuery();

            }

            catch (Exception a)
            {
                return a.Message + "Update Marks Faild Error -->" + a.ToString();
            }

            finally
            {
                Con1.Close();
            }

            return "Marks Updated";
        }

        public static string AddMark(string SID, string SubName,int ClassCode, int Mark, string Chapter, string Kind, string percentage)
        {

            try
            {
                string Quary;
                Quary = "insert into Marks(SID,SubCode,Mark,ClassCode,Chapter,Kind,percentage)  values(@SID,@SubCode,@Mark,@ClassCode,@Chapter,@Kind,@percentage)";
                Cmd1.Parameters.Clear();
                Con1.Open();
                Cmd1.CommandText = Quary;
                Cmd1.Connection = Con1;
                Cmd1.Parameters.Add("@SID", SqlDbType.VarChar).Value = SID;
                Cmd1.Parameters.Add("@SubCode", SqlDbType.VarChar).Value = SubName;
                Cmd1.Parameters.Add("@Mark", SqlDbType.Int).Value = Mark;
                Cmd1.Parameters.Add("@ClassCode", SqlDbType.Int).Value = ClassCode;
                Cmd1.Parameters.Add("@Chapter", SqlDbType.VarChar).Value = Chapter;
                Cmd1.Parameters.Add("@Kind", SqlDbType.VarChar).Value = Kind;
                Cmd1.Parameters.Add("@percentage", SqlDbType.Int).Value = int.Parse(percentage.ToString());

                Cmd1.ExecuteNonQuery();


            }
            catch (Exception a)
            {
                return a.Message + "Add Mark Faild -->" + a.ToString();
            }
            finally
            {
                Con1.Close();
            }

            return "Mark Added";
        }

        public static string UpdateMark(string SID, int Mark, string Chapter, string Kind, string percentage ,int Row)
        {
            try
            {
                string Quary;
                Cmd1.Parameters.Clear();
                Quary = "UPDATE Marks set  Mark = '" + Mark + "' ,Chapter = '" + Chapter + "' ,Kind='"+ Kind+ "' ,percentage='" + percentage + "' Where Cnt ='" + Row + "'";
                Con1.Open();
                Cmd1.CommandText = Quary;
                Cmd1.Connection = Con1;
                Cmd1.Parameters.Add("@Mark", SqlDbType.Int).Value = Mark;
                Cmd1.Parameters.Add("@Chapter", SqlDbType.VarChar).Value = Chapter;
                Cmd1.Parameters.Add("@Kind", SqlDbType.VarChar).Value = Kind;
                Cmd1.Parameters.Add("@percentage", SqlDbType.Int).Value = int.Parse(percentage.ToString());
                Cmd1.ExecuteNonQuery();
                
            }
            catch (Exception a)
            {
                return a.Message + "Update Mark Faild Error -->" + a.ToString();
            }
            finally
            {
                Con1.Close();
            }

            return "Mark Updated";
        }

        public static string UpdateSIDINMarks(string NewSID,string OldSID)
        {
            try
            {
                string Quary;
                Cmd1.Parameters.Clear();
                Quary = "UPDATE Marks set SID = '" + NewSID +  "' Where SID ='" + OldSID + "'";
                Con1.Open();
                Cmd1.CommandText = Quary;
                Cmd1.Connection = Con1;
                Cmd1.Parameters.Add("@SID", SqlDbType.VarChar).Value = NewSID;
                Cmd1.ExecuteNonQuery();

            }
            catch (Exception a)
            {
                return a.Message + "Update Mark Faild Error -->" + a.ToString();
            }
            finally
            {
                Con1.Close();
            }

            return "Mark Updated";
        }

        public static string UpdateClassCodeBySIDinMarks(int ClassCode, string SID)
        {
            try
            {
                string Quary;
                Cmd1.Parameters.Clear();
                Quary = "UPDATE Marks set ClassCode = '" + ClassCode + "' Where SID ='" + SID + "'";
                Con1.Open();
                Cmd1.CommandText = Quary;
                Cmd1.Connection = Con1;
                Cmd1.Parameters.Add("@ClassCode", SqlDbType.Int).Value = ClassCode;
                Cmd1.ExecuteNonQuery();

            }
            catch (Exception a)
            {
                return a.Message + "Update Mark Faild Error -->" + a.ToString();
            }
            finally
            {
                Con1.Close();
            }

            return "Mark Updated";
        }

        //////////////////////////////////////////////Images///////////////////////////////////////////
        //////////////////////////////////////////////Images///////////////////////////////////////////

        public static string AddImage(string SID, string strname)
        {

            string Check = "";


            Check = MyClass.FindImageBySID(SID);

            if (Check.Equals(""))
            {
                Con1.Open();

                SqlCommand cmd = new SqlCommand("insert into Images values('" + SID + "','" + strname + "')", Con1);

                cmd.ExecuteNonQuery();

                Con1.Close();

                cmd.Parameters.Clear();
                Cmd1.Parameters.Clear();

                return "Image Added";
            }

            else
            {
                string Quary;
                Cmd1.Parameters.Clear();

                Quary = "UPDATE Images set Image = '" + strname + "' Where SID = '" + SID + "'";
                Con1.Open();
                Cmd1.CommandText = Quary;
                Cmd1.Connection = Con1;
                Cmd1.Parameters.Add("@Image", SqlDbType.VarChar).Value = strname;
                Cmd1.ExecuteNonQuery();
                Cmd1.Parameters.Clear();

                Con1.Close();

                return "Image Updated";
            }

        }

        public static string FindImageBySID(string SID)
        {
            try
            {
                string Quary;
                Quary = "SELECT * from Images where SID = " + SID;
                Con1.Open();
                Cmd1.CommandText = Quary;
                Cmd1.Connection = @Con1;

                Cmd1.ExecuteNonQuery();

                SqlDataReader Reader1 = Cmd1.ExecuteReader();
                string image = "";

                while (Reader1.Read())
                {
                    if (Reader1["SID"].ToString() == SID.ToString())
                    {
                        image = Reader1["Image"].ToString();
                        return image;
                    }
                }
                return image;

            }


            finally
            {
                Con1.Close();
            }
        }

        public static string UpdateSIDINImages(string NewSID, string OldSID)
        {
            try
            {
                string Quary;
                Cmd1.Parameters.Clear();
                Quary = "UPDATE Images set SID = '" + NewSID + "' Where SID ='" + OldSID + "'";
                Con1.Open();
                Cmd1.CommandText = Quary;
                Cmd1.Connection = Con1;
                Cmd1.Parameters.Add("@SID", SqlDbType.VarChar).Value = NewSID;
                Cmd1.ExecuteNonQuery();

            }
            catch (Exception a)
            {
                return a.Message + "Update Images Faild Error -->" + a.ToString();
            }
            finally
            {
                Con1.Close();
            }

            return "Images SID Updated";
        }

        public static string UpdateSIDINImagesAndroid(string NewSID, string OldSID)
        {
            try
            {
                string Quary;
                Cmd1.Parameters.Clear();
                Quary = "UPDATE ImagesAndroid set SID = '" + NewSID + "' Where SID ='" + OldSID + "'";
                Con1.Open();
                Cmd1.CommandText = Quary;
                Cmd1.Connection = Con1;
                Cmd1.Parameters.Add("@SID", SqlDbType.VarChar).Value = NewSID;
                Cmd1.ExecuteNonQuery();

            }
            catch (Exception a)
            {
                return a.Message + "Update Images Faild Error -->" + a.ToString();
            }
            finally
            {
                Con1.Close();
            }

            return "Images SID Updated";
        }

        public static string UpdateSIDINMessages(string NewSID, string OldSID)
        {
            try
            {
                string Quary;
                Cmd1.Parameters.Clear();
                Quary = "UPDATE Messages set SID = '" + NewSID + "' Where SID ='" + OldSID + "'";
                Con1.Open();
                Cmd1.CommandText = Quary;
                Cmd1.Connection = Con1;
                Cmd1.Parameters.Add("@SID", SqlDbType.VarChar).Value = NewSID;
                Cmd1.ExecuteNonQuery();

            }
            catch (Exception a)
            {
                return a.Message + "Update Messages Faild Error -->" + a.ToString();
            }
            finally
            {
                Con1.Close();
            }

            return "Messages SID Updated";
        }

        public static string UpdateSIDINPresences(string NewSID, string OldSID)
        {
            try
            {
                string Quary;
                Cmd1.Parameters.Clear();
                Quary = "UPDATE Presences set SID = '" + NewSID + "' Where SID ='" + OldSID + "'";
                Con1.Open();
                Cmd1.CommandText = Quary;
                Cmd1.Connection = Con1;
                Cmd1.Parameters.Add("@SID", SqlDbType.VarChar).Value = NewSID;
                Cmd1.ExecuteNonQuery();

            }
            catch (Exception a)
            {
                return a.Message + "Update Presences Faild Error -->" + a.ToString();
            }
            finally
            {
                Con1.Close();
            }

            return "Presences SID Updated";
        }

        //////////////////////////////////////////////Techers///////////////////////////////////////////
        //////////////////////////////////////////////Techers///////////////////////////////////////////

        public static string AddTechers(string TName, string TID,string Phone)
        {

            try
            {
                string Quary;
                Quary = "insert into Techers(TName,TID,Phone)  values(@TName,@TID,@Phone)";
                Cmd1.Parameters.Clear();
                Con1.Open();
                Cmd1.CommandText = Quary;
                Cmd1.Connection = Con1;
                Cmd1.Parameters.Add("@TName", SqlDbType.NVarChar).Value = TName;
                Cmd1.Parameters.Add("@TID", SqlDbType.VarChar).Value = TID;
                Cmd1.Parameters.Add("@Phone", SqlDbType.VarChar).Value = Phone;

                Cmd1.ExecuteNonQuery();
            }
            catch (Exception a)
            {
                string s;
                s = a.Message.ToString() + "Error" + a.ToString();

                return a.Message + "Add Techer Faild -->" + a.ToString();
            }
            finally
            {
                Con1.Close();
            }

            return "Techer Added";
        }

        public static string AddTechers2(string TName, string TID,string @Connection)
        {
            SqlConnection Con2 = new SqlConnection();
            try
            {
                string Quary;
                Quary = "insert into Techers(TName,TID)  values(@TName,@TID)";
                Cmd1.Parameters.Clear();
                Con2.ConnectionString = @Connection;
                Con2.Open();
                Cmd1.CommandText = Quary;
                Cmd1.Connection = Con2;
                Cmd1.Parameters.Add("@TName", SqlDbType.VarChar).Value = TName;
                Cmd1.Parameters.Add("@TID", SqlDbType.VarChar).Value = TID;

                Cmd1.ExecuteNonQuery();


            }
            catch (Exception a)
            {
                string s;
                s = a.Message.ToString() + "Error" + a.ToString();

                return a.Message + "Add Techer Faild -->" + a.ToString();
            }
            finally
            {
                Con1.Close();
            }

            return "Techer Added";
        }

        public static string UpdateTecherName(string TName,string Phone,string TID)
        {
            try
            {
                string Quary;
                Cmd1.Parameters.Clear();
                Quary = "UPDATE Techers set TName = @TName, Phone = @Phone WHERE TID = @TID";
                
                Con1.Open();
                Cmd1.CommandText = Quary;
                Cmd1.Connection = Con1;
                Cmd1.Parameters.Add("@TName", SqlDbType.NVarChar).Value = TName.ToString();
                Cmd1.Parameters.Add("@Phone", SqlDbType.VarChar).Value = Phone;
                Cmd1.Parameters.Add("@TID", SqlDbType.NVarChar).Value = TID;
                Cmd1.ExecuteNonQuery();

            }
            catch (Exception a)
            {
                return a.Message + "Update Techer Faild Error -->" + a.ToString();
            }
            finally
            {
                Con1.Close();
            }

            return "Techer Name Updated";
        }

        public static string UpdateTecherIDINExams(string NewTID, string OldID)
        {
            try
            {
                string Quary;
                Cmd1.Parameters.Clear();
                Quary = "UPDATE Exams set TID='" + NewTID + "' WHERE TID ='" + OldID + "'";

                Con1.Open();
                Cmd1.CommandText = Quary;
                Cmd1.Connection = Con1;
                Cmd1.Parameters.Add("@TID", SqlDbType.VarChar).Value = NewTID.ToString();
                Cmd1.ExecuteNonQuery();

            }
            catch (Exception a)
            {
                return a.Message + "Update Techer Faild Error -->" + a.ToString();
            }
            finally
            {
                Con1.Close();
            }

            return "Techer ID Updated";
        }

        public static string UpdateTecherIDINWorks(string NewTID, string OldID)
        {
            try
            {
                string Quary;
                Cmd1.Parameters.Clear();
                Quary = "UPDATE Works set TID='" + NewTID + "' WHERE TID ='" + OldID + "'";

                Con1.Open();
                Cmd1.CommandText = Quary;
                Cmd1.Connection = Con1;
                Cmd1.Parameters.Add("@TID", SqlDbType.VarChar).Value = NewTID.ToString();
                Cmd1.ExecuteNonQuery();

            }
            catch (Exception a)
            {
                return a.Message + "Update Techer Faild Error -->" + a.ToString();
            }
            finally
            {
                Con1.Close();
            }

            return "Techer ID Updated";
        }

        //////////////////////////////////////////////Subjects///////////////////////////////////////////
        //////////////////////////////////////////////Subjects///////////////////////////////////////////
        public static string AddSubjects(string SubName, string SubCode)
        {

            try
            {
                string Quary;
                Quary = "insert into Subjects(SubName,SubCode)  values(@SubName,@SubCode)";
                Cmd1.Parameters.Clear();
                Con1.Open();
                Cmd1.CommandText = Quary;
                Cmd1.Connection = Con1;
                Cmd1.Parameters.Add("@SubName", SqlDbType.NVarChar).Value = SubName;
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

        public static string AddSubjects2(string SubName, string SubCode,string @Connection)
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

        public static string UpdateNameinSunjects(string NewName,string Old)
        {
            try
            {
                string Quary;
                Cmd1.Parameters.Clear();
                Quary = "UPDATE Subjects set SubName = @NewName Where SubName = @Old";
                Con1.Open();
                Cmd1.CommandText = Quary;
                Cmd1.Connection = Con1;
                Cmd1.Parameters.Add("@NewName", SqlDbType.NVarChar).Value = NewName;
                Cmd1.Parameters.Add("@Old", SqlDbType.NVarChar).Value = Old;
                Cmd1.ExecuteNonQuery();

            }
            catch (Exception a)
            {
                return a.Message + "Update Subject Faild Error -->" + a.ToString();
            }
            finally
            {
                Con1.Close();
            }

            return "Subject Updated";
        }

        public static string UpdateClassCodeinSunjects(int NewClassCode, int OldClassCode)
        {
            try
            {
                string Quary;
                Cmd1.Parameters.Clear();
                Quary = "UPDATE Subjects set ClassCode = '" + NewClassCode + "' Where ClassCode ='" + OldClassCode + "'";
                Con1.Open();
                Cmd1.CommandText = Quary;
                Cmd1.Connection = Con1;
                Cmd1.Parameters.Add("@ClassCode", SqlDbType.Int).Value = NewClassCode;
                Cmd1.ExecuteNonQuery();

            }
            catch (Exception a)
            {
                return a.Message + "Update Subject Faild Error -->" + a.ToString();
            }
            finally
            {
                Con1.Close();
            }

            return "Subject Updated";
        }

        //////////////////////////////////////////////Subjects Techer///////////////////////////////////////////
        //////////////////////////////////////////////Subjects Techer///////////////////////////////////////////
        public static string AddSubjectsTecher(string SCode, string TID, int ClassCode)
        {
            try
            {
                string Quary;
                Quary = "insert into SubjectsTecher(SubCode,TID,ClassCode)  values(@SubCode,@TID,@ClassCode)";
                Cmd1.Parameters.Clear();
                Con1.Open();
                Cmd1.CommandText = Quary;
                Cmd1.Connection = Con1;
                Cmd1.Parameters.Add("@SubCode", SqlDbType.VarChar).Value = SCode;
                Cmd1.Parameters.Add("@TID", SqlDbType.VarChar).Value = TID;
                Cmd1.Parameters.Add("@ClassCode", SqlDbType.Int).Value = ClassCode;

                Cmd1.ExecuteNonQuery();

            }

            catch (Exception a)
            {
                string s;
                s = a.Message.ToString() + "Error" + a.ToString();

                return a.Message + "Add SubjectsTecher Faild -->" + a.ToString();
            }

            finally
            {
                Con1.Close();
            }

            return "SubjectsTecher Added";
        }

        public static string UpdateClassCodeinSunjectsTecher(int NewClassCode, int OldClassCode)
        {
            try
            {
                string Quary;
                Cmd1.Parameters.Clear();
                Quary = "UPDATE SubjectsTecher set ClassCode = '" + NewClassCode + "' Where ClassCode ='" + OldClassCode + "'";
                Con1.Open();
                Cmd1.CommandText = Quary;
                Cmd1.Connection = Con1;
                Cmd1.Parameters.Add("@ClassCode", SqlDbType.Int).Value = NewClassCode;
                Cmd1.ExecuteNonQuery();

            }
            catch (Exception a)
            {
                return a.Message + "Update SubjectsTecher Faild Error -->" + a.ToString();
            }
            finally
            {
                Con1.Close();
            }

            return "SubjectsTecher Updated";
        }

        public static string UpdateTIDinSunjectsTecher(string NewTID, string OldTID)
        {
            try
            {
                string Quary;
                Cmd1.Parameters.Clear();
                Quary = "UPDATE SubjectsTecher set TID = '" + NewTID + "' Where TID ='" + OldTID + "'";
                Con1.Open();
                Cmd1.CommandText = Quary;
                Cmd1.Connection = Con1;
                Cmd1.Parameters.Add("@TID", SqlDbType.VarChar).Value = NewTID;
                Cmd1.ExecuteNonQuery();

            }
            catch (Exception a)
            {
                return a.Message + "Update SubjectsTecher Faild Error -->" + a.ToString();
            }
            finally
            {
                Con1.Close();
            }

            return "SubjectsTecher Updated";
        }

        public static string UpdateSubCodeinSunjectsTecher(string NewSubCode, string OldSubCode)
        {
            try
            {
                string Quary;
                Cmd1.Parameters.Clear();
                Quary = "UPDATE SubjectsTecher set SubCode = '" + NewSubCode + "' Where SubCode ='" + OldSubCode + "'";
                Con1.Open();
                Cmd1.CommandText = Quary;
                Cmd1.Connection = Con1;
                Cmd1.Parameters.Add("@SubCode", SqlDbType.VarChar).Value = NewSubCode;
                Cmd1.ExecuteNonQuery();

            }
            catch (Exception a)
            {
                return a.Message + "Update SubjectsTecher Faild Error -->" + a.ToString();
            }
            finally
            {
                Con1.Close();
            }

            return "SubjectsTecher Updated";
        }

        public static string UpdateSubCodeInTechers(int Row, string SCode)
        {
            try
            {
                string Quary;
                Cmd1.Parameters.Clear();

                Quary = "UPDATE SubjectsTecher set SubCode = '" + SCode + "'Where Cnt='" + Row + "'";

                Con1.Open();
                Cmd1.CommandText = Quary;
                Cmd1.Connection = Con1;
                Cmd1.Parameters.Add("@SubCode", SqlDbType.VarChar).Value = SCode;
                Cmd1.ExecuteNonQuery();

            }
            catch (Exception a)
            {
                return a.Message + "Update SubjectsTecher Faild Error -->" + a.ToString();
            }
            finally
            {
                Con1.Close();
            }

            return "SubjectsTecher Updated";
        }

        public static string UpdateTIDInTechers(int Row, string TID)
        {
            try
            {
                string Quary;
                Cmd1.Parameters.Clear();

                Quary = "UPDATE SubjectsTecher set TID = '" + TID + "'Where Cnt='" + Row + "'";

                Con1.Open();
                Cmd1.CommandText = Quary;
                Cmd1.Connection = Con1;
                Cmd1.Parameters.Add("@TID", SqlDbType.VarChar).Value = TID;
                Cmd1.ExecuteNonQuery();

            }
            catch (Exception a)
            {
                return a.Message + "Update SubjectsTecher Faild Error -->" + a.ToString();
            }
            finally
            {
                Con1.Close();
            }

            return "SubjectsTecher Updated";
        }

        public static string UpdateCCodeInTechers(int Row, int ClassCode)
        {
            try
            {
                string Quary;
                Cmd1.Parameters.Clear();

                Quary = "UPDATE SubjectsTecher set ClassCode = '" + ClassCode + "'Where Cnt='" + Row + "'";

                Con1.Open();
                Cmd1.CommandText = Quary;
                Cmd1.Connection = Con1;
                Cmd1.Parameters.Add("@ClassCode", SqlDbType.Int).Value = ClassCode;
                Cmd1.ExecuteNonQuery();

            }
            catch (Exception a)
            {
                return a.Message + "Update SubjectsTecher Faild Error -->" + a.ToString();
            }
            finally
            {
                Con1.Close();
            }

            return "SubjectsTecher Updated";
        }

        public static string UpdateSubjectTecher(string TID, int Row)
        {
            try
            {
                string Quary;
                Cmd1.Parameters.Clear();
                Quary = "UPDATE SubjectsTecher set TID = '" + TID + "' where Cnt='"+Row+"'";
                Con1.Open();
                Cmd1.CommandText = Quary;
                Cmd1.Connection = Con1;
                Cmd1.Parameters.Add("@TID", SqlDbType.VarChar).Value = TID;


                Cmd1.ExecuteNonQuery();

            }
            catch (Exception a)
            {
                return a.Message + "Update SubjectsTecher Faild Error -->" + a.ToString();
            }
            finally
            {
                Con1.Close();
            }

            return "SubjectsTecher Updated";
        }

        //////////////////////////////////////////////Class Techer///////////////////////////////////////////
        //////////////////////////////////////////////Class Techer///////////////////////////////////////////

        public static string AddClassTecher(string TID, int ClassCode)
        {


            try
            {
                string Quary;
                Quary = "insert into ClassTechers(TID,ClassCode)  values(@TID,@ClassCode)";
                Cmd1.Parameters.Clear();
                Con1.Open();
                Cmd1.CommandText = Quary;
                Cmd1.Connection = Con1;
                Cmd1.Parameters.Add("@TID", SqlDbType.VarChar).Value = TID;
                Cmd1.Parameters.Add("@ClassCode", SqlDbType.Int).Value = ClassCode;

                Cmd1.ExecuteNonQuery();

            }

            catch (Exception a)
            {
                string s;
                s = a.Message.ToString() + "Error" + a.ToString();

                return a.Message + "Add ClassTecher Faild -->" + a.ToString();
            }

            finally
            {
                Con1.Close();
            }

            return "ClassTecher Added";
        }

        public static string UpdateTIDinClassTecher(string NewTID, string OldTID)
        {
            try
            {
                string Quary;
                Cmd1.Parameters.Clear();
                Quary = "UPDATE ClassTechers set TID = '" + NewTID + "' Where TID ='" + OldTID + "'";
                Con1.Open();
                Cmd1.CommandText = Quary;
                Cmd1.Connection = Con1;
                Cmd1.Parameters.Add("@TID", SqlDbType.VarChar).Value = NewTID;
                Cmd1.ExecuteNonQuery();

            }
            catch (Exception a)
            {
                return a.Message + "Update ClassTechers Faild Error -->" + a.ToString();
            }
            finally
            {
                Con1.Close();
            }

            return "ClassTechers Updated";
        }

        public static string UpdateClassTecher(int ClassCode,int Row)
        {
            try
            {
                string Quary;
                Cmd1.Parameters.Clear();
                Quary = "UPDATE ClassTechers set ClassCode = '" + ClassCode + "' Where Cnt ='" + Row + "'";
                Con1.Open();
                Cmd1.CommandText = Quary;
                Cmd1.Connection = Con1;
                Cmd1.Parameters.Add("@ClassCode", SqlDbType.VarChar).Value = ClassCode;
                Cmd1.ExecuteNonQuery();

            }
            catch (Exception a)
            {
                return a.Message + "Update ClassTechers Faild Error -->" + a.ToString();
            }
            finally
            {
                Con1.Close();
            }

            return "ClassTechers Updated";
        }

        public static string UpdateClassTecher2(string TID, int Row)
        {
            try
            {
                string Quary;
                Cmd1.Parameters.Clear();
                Quary = "UPDATE ClassTechers set TID = '" + TID + "' Where Cnt ='" + Row + "'";
                Con1.Open();
                Cmd1.CommandText = Quary;
                Cmd1.Connection = Con1;
                Cmd1.Parameters.Add("@TID", SqlDbType.VarChar).Value = TID;
                Cmd1.ExecuteNonQuery();

            }
            catch (Exception a)
            {
                return a.Message + "Update ClassTechers Faild Error -->" + a.ToString();
            }
            finally
            {
                Con1.Close();
            }

            return "ClassTechers Updated";
        }

        public static string SelectClassTecherRow2(string TID, int ClassCode)
        {
            try
            {
                string Query;
                Query = "SELECT * from ClassTechers";

                Con1.Open();
                Cmd1.CommandText = Query;
                Cmd1.Connection = Con1;
                Cmd1.ExecuteNonQuery();

                SqlDataReader Reader1 = Cmd1.ExecuteReader();
                string Row = "";

                while (Reader1.Read())
                {
                    if ((Reader1["TID"].ToString()).Equals(TID) && (Reader1["ClassCode"].ToString()).Equals(ClassCode.ToString()))
                    {
                        Row = Reader1["Cnt"].ToString();
                    }
                }
                return Row;

            }
            catch (Exception a)
            {
                return a.Message + "Find Row Faild --> " + a.ToString();
            }
            finally
            {
                Con1.Close();
            }

        }

        ////////////////////////////////////////////// Schedules ///////////////////////////////////////////
        ////////////////////////////////////////////// Schedules ///////////////////////////////////////////

        public static string AddSchedule(string TecherID, string Day, List<string> Subjects, List<string> Classes)
        {                  

            try
            {
                string Quary;
                string Value = "";

                Quary = "insert into Schedules(L1,L2,L3,L4,L5,L6,L7,TID,Day)  values(@L1,@L2,@L3,@L4,@L5,@L6,@L7,@TID,@Day)";
                Cmd1.Parameters.Clear();
                Con1.Open();
                Cmd1.CommandText = Quary;
                Cmd1.Connection = Con1;

                for (int i = 1; i <= 7;i++)
                {
                    Value = Subjects[i - 1].ToString();
                    Value += "#";
                    Value += Classes[i - 1].ToString();

                    Cmd1.Parameters.Add(("@L"+i.ToString()), SqlDbType.VarChar).Value = Value;
                }

                Cmd1.Parameters.Add("@TID", SqlDbType.VarChar).Value = TecherID.ToString();
                Cmd1.Parameters.Add("@Day", SqlDbType.VarChar).Value = Day.ToString();

                Cmd1.ExecuteNonQuery();


            }
            catch (Exception a)
            {
                string s;
                s = a.Message.ToString() + "Error" + a.ToString();

                return a.Message + "Add Schedule Faild -->" + a.ToString();
            }
            finally
            {
                Con1.Close();
            }

            return "Schedule Added";
        }

        public static string UpdateSchedule(string TecherID, string Day, List<string> Subjects, List<string> Classes,string Date,int Row)
        {
            try
            {
                string Value = "";
                string Quary;
                Cmd1.Parameters.Clear();

                //======================== Making Quaru ========================
                //======================== Making Quaru ========================

                Quary = "UPDATE Schedules set TID = '" + TecherID + "', Day = '" + Day;

                for(int i=0;i<7;i++)
                {
                    Value = Subjects[i].ToString();
                    Value += "#";
                    Value += Classes[i].ToString();

                    Quary += "',L"+(i+1).ToString()+"='" + Value;
                }

                Quary += "' Where Cnt='" + Row + "'";

                Con1.Open();
                Cmd1.CommandText = Quary;
                Cmd1.Connection = Con1;


                //======================== Making Parameters ========================
                //======================== Making Parameters ========================

                Cmd1.Parameters.Add("@TID", SqlDbType.VarChar).Value = TecherID.ToString();
                Cmd1.Parameters.Add("@Day", SqlDbType.VarChar).Value = Day.ToString();

                for(int i=0;i<7;i++)
                {
                    Cmd1.Parameters.Add("@L"+(i+1).ToString(), SqlDbType.VarChar).Value = (Subjects[i]+"#"+ Classes[i]).ToString();
                }
   

                Cmd1.ExecuteNonQuery();

            }
            catch (Exception a)
            {
                return a.Message + "Update SubjectsTecher Faild Error -->" + a.ToString();
            }
            finally
            {
                Con1.Close();
            }

            return "SubjectsTecher Updated";
        }

        public static string AddClassSchedule(string Class, string Day, List<string> Subjects)
        {

            try
            {
                string Quary;
                string Value = "";

                Quary = "insert into ClassSchedules(L1,L2,L3,L4,L5,L6,L7,Class,Day)  values(@L1,@L2,@L3,@L4,@L5,@L6,@L7,@Class,@Day)";
                Cmd1.Parameters.Clear();
                Con1.Open();
                Cmd1.CommandText = Quary;
                Cmd1.Connection = Con1;

                for (int i = 1; i <= 7; i++)
                {
                    Value = Subjects[i - 1].ToString();

                    Cmd1.Parameters.Add(("@L" + i.ToString()), SqlDbType.NVarChar).Value = Value;
                }

                Cmd1.Parameters.Add("@Class", SqlDbType.VarChar).Value = Class.ToString();
                Cmd1.Parameters.Add("@Day", SqlDbType.VarChar).Value = Day.ToString();

                Cmd1.ExecuteNonQuery();


            }
            catch (Exception a)
            {
                string s;
                s = a.Message.ToString() + "Error" + a.ToString();

                return a.Message + "Add ClassSchedules Faild -->" + a.ToString();
            }
            finally
            {
                Con1.Close();
            }

            return "ClassSchedules Added";
        }

        public static string UpdateTIDInSchedules(string TIDNew, string TIDOld)
        {
            try
            {
                string Quary;
                Cmd1.Parameters.Clear();

                Quary = "UPDATE Schedules set TID = '" + TIDNew + "'Where TID='" + TIDOld + "'";

                Con1.Open();
                Cmd1.CommandText = Quary;
                Cmd1.Connection = Con1;
                Cmd1.Parameters.Add("@TID", SqlDbType.VarChar).Value = TIDNew;
                Cmd1.ExecuteNonQuery();

            }
            catch (Exception a)
            {
                return a.Message + "Update Schedules Faild Error -->" + a.ToString();
            }
            finally
            {
                Con1.Close();
            }

            return "Schedules Updated";
        }


        ////////////////////////////////////////////// School ///////////////////////////////////////////
        ////////////////////////////////////////////// School ///////////////////////////////////////////


        public static string AddMessage(string SID, string Message,string Date,string ClassCode,string @Connect)
        {
            SqlConnection Con2 = new SqlConnection();
            SqlCommand Cmd2 = new SqlCommand();

            try
            {
                string Quary;
                Quary = "insert into Messages(SID,Message,Date,ClassCode)  values(@SID,@Message,@Date,@ClassCode)";
                Cmd2.Parameters.Clear();
                Con2.ConnectionString = @Connect;
                Con2.Open();
                Cmd2.CommandText = Quary;
                Cmd2.Connection = Con2;
                Cmd2.Parameters.Add("@SID", SqlDbType.VarChar).Value = SID;
                Cmd2.Parameters.Add("@Message", SqlDbType.VarChar).Value = Message;
                Cmd2.Parameters.Add("@Date", SqlDbType.VarChar).Value = Date;
                Cmd2.Parameters.Add("@ClassCode", SqlDbType.VarChar).Value = ClassCode;

                Cmd2.ExecuteNonQuery();


            }
            catch (Exception a)
            {
                return a.Message + "Add Messages Faild -->" + a.ToString();
            }
            finally
            {
                Con2.Close();
            }

            return "Messages Added";
        }

        //////////////////////////////////////////////School Login///////////////////////////////////////////
        //////////////////////////////////////////////School Login///////////////////////////////////////////
        //////////////////////////////////////////////School Login///////////////////////////////////////////
        //////////////////////////////////////////////School Login///////////////////////////////////////////
        //////////////////////////////////////////////School Login///////////////////////////////////////////
        //////////////////////////////////////////////School Login///////////////////////////////////////////
        //////////////////////////////////////////////School Login///////////////////////////////////////////


        public static string SchoolLoginCheck(int SchoolCode, string Pass)
        {
            try
            {
                string Quary;
                Quary = "SELECT * from SLogin where SchoolCode = '" + SchoolCode + "' AND Pass = '" + Pass + "'";
                Cmd1.Parameters.Clear();
                PublicCon1.Open();
                Cmd1.CommandText = Quary;
                Cmd1.Connection = PublicCon1;
                Cmd1.ExecuteNonQuery();

                SqlDataReader Reader1 = Cmd1.ExecuteReader();
                string All = "0",Pass2;
                int Scode ;

                while (Reader1.Read())
                {
                    Scode = int.Parse(Reader1["SchoolCode"].ToString());
                    Pass2 = Reader1["Pass"].ToString();

                    if (Scode.Equals(SchoolCode) && Pass2.Equals(Pass))
                    {
                        All = "1";
                    }
                }

                //=========================== if pass and id is ok ===========================
                if (All.Equals("1"))
                {
                    DataTable DTCon = new DataTable();

                    DTCon = SelectDatabase(SchoolCode);

                    //=========================== if there is connection ===========================
                    if (DTCon.Rows.Count == 1)
                    {
                        All = DTCon.Rows[0].ItemArray[0].ToString();

                        GetConnection += All;

                        //=========================== storing connection to use it ===========================
                        ConnectionCorrector();

                        return "1";
                    }

                    else
                    {
                        return "0";
                    }

                }

                return "0";

            }

            catch (Exception a)
            {
                return "School Account Erorr --> " + a.Message;
            }

            finally
            {
                PublicCon1.Close();
            }
        }

        static public DataTable SelectDatabase(int SchoolCode)
        {
            string Query = "SELECT Connection from Connections Where SchoolCode ='" + SchoolCode + "'";
            return SelectData(Query, PublicConStr1);
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

        public static string AddTechersToPublicDB(string TID, string SchoolCode)
        {

            string BackResult = "";
            try
            {
                string Quary;
                Quary = "insert into SchoolTID(TID,SchoolCode)  values(@TID,@SchoolCode)";
                Cmd1.Parameters.Clear();

                PublicCon1.Open();

                Cmd1.CommandText = Quary;
                Cmd1.Connection = PublicCon1;
                Cmd1.Parameters.Add("@TID", SqlDbType.VarChar).Value = TID.ToString();
                Cmd1.Parameters.Add("@SchoolCode", SqlDbType.Int).Value = int.Parse(SchoolCode.ToString());

                Cmd1.ExecuteNonQuery();

                CreateRandomPassword(TID,"T");

                BackResult = "TechersPublic DB Added";
            }

            catch (Exception a)
            {
                return a.Message + "TechersPublic DB Faild -->" + a.ToString();
            }

            finally
            {
                PublicCon1.Close();
            }

            return BackResult;
        }

        public static void ConnectionCorrector()
        {
            ConStr += GetConnection;
            Con1 = new SqlConnection(@ConStr);
        }


        public static string RemoveClassData(int ClassCode)
        {
            try
            {
                string Query = "DELETE from Students where ClassCode='" + ClassCode + "'";
                SelectData(Query, ConStr);
            }

            catch (Exception a)
            {
                return a.Message + "Cant Classes Data" + a.ToString();
            }

            return "Classes Data Removed !";

        }


        public static string RemoveAllData()
        {
            try
            {
                string Query = "DELETE from Images";
                SelectData(Query, ConStr);

                Query = "DELETE from ImagesAndroid";
                SelectData(Query, ConStr);

                Query = "DELETE from Messages";
                SelectData(Query, ConStr);

                Query = "DELETE from Presences";
                SelectData(Query, ConStr);

                Query = "DELETE from Marks";
                SelectData(Query, ConStr);

                Query = "DELETE from Schedules";
                SelectData(Query, ConStr);

                Query = "DELETE from SubjectsTecher";
                SelectData(Query, ConStr);
            }

            catch (Exception a)
            {
                return a.Message + "Cant Remove School Data" + a.ToString();
            }

            return "DataRemoved !";

        }


        public static string RemoveAllData2()
        {
            try
            {
                string Query = "";


                Query = "DELETE from Messages";
                SelectData(Query, ConStr);

                Query = "DELETE from Presences";
                SelectData(Query, ConStr);

                Query = "DELETE from Exams";
                SelectData(Query, ConStr);
            }

            catch (Exception a)
            {
                return a.Message + "Cant Remove School Data" + a.ToString();
            }

            return "DataRemoved !";

        }

        public static string AddNotification(string PID)
        {

            try
            {
                string Notifi = "0",Kind="0";
                string Quary;
                Quary = "insert into Notification(PID,Kind,Notifi)  values(@PID,@Kind,@Notifi)";
                Cmd1.Parameters.Clear();
                PublicCon1.Open();

                Cmd1.CommandText = Quary;
                Cmd1.Connection = PublicCon1;
                Cmd1.Parameters.Add("@PID", SqlDbType.VarChar).Value = PID;
                Cmd1.Parameters.Add("@Kind", SqlDbType.VarChar).Value = Kind;
                Cmd1.Parameters.Add("@Notifi", SqlDbType.VarChar).Value = Notifi;

                Cmd1.ExecuteNonQuery();

            }

            catch (Exception a)
            {
                string s;
                s = a.Message.ToString() + "Error" + a.ToString();

                return a.Message + "Add Notification Faild -->" + a.ToString();
            }

            finally
            {
                Con1.Close();
            }

            return "Notification Added";
        }

        static public DataTable SelectNotification(string PID)
        {
            string Query = "SELECT * from Notification Where PID ='" + PID + "'";
            return SelectData(Query, PublicConStr1);
        }

        static public DataTable SelectSchoolByCode(string SchoolCode)
        {
            string Query = "SELECT * from SLogin Where SchoolCode ='" + SchoolCode+ "'";
            return SelectData(Query, PublicConStr1);
        }

        static public DataTable SelectSchoolRank(string SchoolCode)
        {
            string Query = "SELECT SchoolRank from SLogin Where SchoolCode ='" + SchoolCode +"'";
            return SelectData(Query, PublicConStr1);
        }

        static public DataTable SelectPromotVideo()
        {
            string Query = "SELECT * from Promot";
            return SelectData(Query, PublicConStr1);
        }

        public static void CheckForInternetConnection()
        {
            try
            {
                using (var client = new WebClient())
                using (client.OpenRead("http://google.com/generate_204"))
                    NetCheck = true;
            }
            catch
            {
                NetCheck = false;
            }
        }


        ///////////////////// Test 
        ///


        public static string AddToLang(string Text)
        {
            string BackResult = "";
            string SchoolDatabase = @"Data Source=SQL6007.site4now.net;Initial Catalog=DB_A50589_School1Data;User Id=DB_A50589_School1Data_admin;Password=need4speed123159;";
            SqlConnection Connn= new SqlConnection();
            Connn.ConnectionString = SchoolDatabase;
            try
            {
                string Quary;
                Quary = "insert into LangTest(Text)  values(@Text)";
                Cmd1.Parameters.Clear();
                Connn.Open();
                Cmd1.CommandText = Quary;
                Cmd1.Connection = Connn;
                Cmd1.Parameters.Add("@Text", SqlDbType.NVarChar).Value = Text;

                Cmd1.ExecuteNonQuery();

                BackResult = "Text Added";
            }

            catch (Exception a)
            {
                return a.Message + "Add Text Faild -->" + a.ToString();
            }

            finally
            {
                Connn.Close();
            }

            return BackResult;
        }

    }
  
}