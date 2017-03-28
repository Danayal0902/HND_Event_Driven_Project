using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace EventDriven1.EventDriven2014
{
    public class EmployeeDB
    {
        /// <summary>
        /// Creates a list of employee members which is named employees
        /// Instantiates the EmployeeDB
        /// </summary>
        public List<Employee> employees;
        public static EmployeeDB instance;

        /// <summary>
        /// Method which parity checks the EmployeeDB instance to verify that it
        /// does not already exist, is this is the case EmployeeDB is instantiated
        /// </summary>
        public static EmployeeDB Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new EmployeeDB();
                    instance.generate();
                }
                return instance;
            }
        }

        /// <summary>
        /// method which returns the list of Employees stored
        /// </summary>
        public List<Employee> Employees
        {
            get { return employees; }
        }

        /// <summary>
        /// Creates a new Employee list
        /// </summary>
        public EmployeeDB()
        {
            employees = new List<Employee>();
        }

        /// <summary>
        /// Adds a new employee to the employees list
        /// </summary>
        /// <param name="fn">First name</param>
        /// <param name="ln">Last name</param>
        /// <param name="h">Holidays</param>
        /// <param name="pg">Pay grade</param>
        public void addnewEmployee(string fn, string ln, int h, string pg)
        {
            Employee emp = new Employee(fn, ln, h, pg);
            employees.Add(emp);
        }

        /// <summary>
        /// All currently stored employees are read into the system from an external text file
        /// </summary>
        public void generate()
        {
            using (StreamReader r = new StreamReader("C:\\MyPrograms - Danayal Iftikhar\\EventDriven2014\\EventDriven1.0\\bin\\Debug\\EmployeeList2.txt")) //The path of the text file
            {
                string line;
                while ((line = r.ReadLine()) != null) //If the text file is not null (has data within)
                {
                    string[] words = line.Split('\t'); //Data is seperated by tabs, data is input into seperate indexes of the string array words
                    
                    if (int.Parse(words[3]) >= 1 && int.Parse(words[3]) <= 6) //If the third index (the salary band) is between 1 and 6
                    {
                        
                        employees.Add(new Employee(words[0], words[1], int.Parse(words[2]), words[3])); // Add the data for a new employee from the words array to the list 
                    }
                    else
                    {
                        throw new Exception("Pay grade must be between 1 and 6"); //Throw exception to stop application
                    }
                }
            }
        }




        }
    }

