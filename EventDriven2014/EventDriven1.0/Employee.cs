using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventDriven1.EventDriven2014
{
    public class Employee
    {
        /// <summary>
        /// Variables to store the first name, last name, holidays remaining, 
        /// pay grade, username, and password.
        /// </summary>
        public string fName { get; set; }
        public string lName { get; set; }
        public int holiday { get; set; }
        public string pGrade { get; set; }
        public string uName { get; set; }
        public string pWord { get; set; }

        /// <summary>
        /// Overridden tostring method to dictate format of output when returning
        /// employee information
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return fName + " " + lName + holiday + pGrade;    
        }

        /// <summary>
        /// Method which takes in parameters to confirm holiday allocation
        /// </summary>
        /// <param name="fn">First Name</param>
        /// <param name="ln">last Name</param>
        /// <param name="pg">Pay Grade</param>
        public Employee(string fn, string ln, string pg)
        {
            fName = fn;
            lName = ln;
            pGrade = pg;

            if (pGrade == "1")
                holiday = 20;
            if (pGrade == "2")
                holiday = 15;
            if (pGrade == "3")
                holiday = 10;
            if (pGrade == "4")
                holiday = 7;
            if (pGrade == "5")
                holiday = 4;
            if (pGrade == "6")
                holiday = 2;
            else
                holiday = 21;
            createuName();
            
        }

        /// <summary>
        /// Creates variables for the employees first name, last name, holidays,
        /// and pay grade, then calling the create username method using the 
        /// variables below
        /// </summary>
        /// <param name="fn">First Name</param>
        /// <param name="ln">Last Name</param>
        /// <param name="h">Holidays</param>
        /// <param name="pg">Pay Grade</param>
        public Employee(string fn, string ln, int h, string pg)
        {
            fName = fn;
            lName = ln;
            holiday = h;
            pGrade = pg;
            createuName();
        }


        /// <summary>
        /// Calls parent class to retrieve attributes
        /// </summary>
        public Employee()
            : base()
        {
        }

        /// <summary>
        /// Creates usernames and passwords for all members of staff, using the 
        /// first letter of their first name and last name concatenated for the 
        /// username and the last name in uppercase for the password
        /// </summary>
        public void createuName()
        {
            uName = fName.Substring(0, 1) + lName;
            pWord = lName.ToUpper();
        }
    } 
}
