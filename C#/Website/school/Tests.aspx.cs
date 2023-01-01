using school.App_Code;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WhatsAppApi;

namespace school
{
    public partial class Tests : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Random rand = new Random();
            int numIterations = 0;
            numIterations = rand.Next(111111111, 999999999);
            string done = "21";

            while (IDChecker(numIterations.ToString()).Equals("0"))
            {
                numIterations = rand.Next(111111111, 999999999);
                done = numIterations.ToString();
            }

            Response.Write(done.ToString());



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


    }
}