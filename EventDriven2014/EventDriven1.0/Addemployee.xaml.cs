using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using System.IO;

namespace EventDriven1.EventDriven2014
{
    /// <summary>
    /// Interaction logic for Addemp.xaml
    /// </summary>
    public partial class Addemp : Window
    {
        /// <summary>
        /// Variables to store an employee, employeedb, and the list of employees
        /// </summary>
        Employee employe = new Employee();
        EmployeeDB edb;
        List<Employee> el;

        /// <summary>
        /// Creates staff database before the windows loads
        /// </summary>
        public Addemp()
        {
            edb = EmployeeDB.Instance;
            el = edb.Employees;
            InitializeComponent();
            txtbxFname.Focus();
        }


        /// <summary>
        /// Adds new employee to the list
        /// </summary>
        /// <param name="fn"></param>
        /// <param name="ln"></param>
        /// <param name="pg"></param>
        public void addemps(string fn, string ln, string pg)
        {
            employe = new Employee(fn, ln, pg);
        }

        /// <summary>
        /// Verifies new employee information and adds to the list
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnAdd_Click(object sender, RoutedEventArgs e)
        {
            string fn;
            string ln;
            string pg;

            if (this.txtbxFname.Text == "")
            {
                txtbxFname.Focus();
                MessageBox.Show("No First Name entered");
                return;
            }
            else if (this.txtbxLname.Text == "")
            {
                txtbxLname.Focus();
                MessageBox.Show("No last name entered");
                return;
            }
            else if (this.txtbxPg.Text == "")
            {
                txtbxPg.Focus();
                MessageBox.Show("No pay grade entered");
                return;
            }
            else if (txtbxPg.Text != "1" && txtbxPg.Text != "2" && txtbxPg.Text != "3" && txtbxPg.Text != "4" && txtbxPg.Text != "5" && txtbxPg.Text != "6")
            {
                MessageBox.Show("Pay Grade requires a value ranging from 1 to 6");
                txtbxPg.Clear();
                txtbxPg.Focus();
                return;
            }


            fn = txtbxFname.Text;
            ln = txtbxLname.Text;
            pg = txtbxPg.Text;

            addemps(fn, ln, pg);
            edb.Employees.Add(employe);
            employe.createuName();

            txtbxUname.Text = employe.uName;
            addStaff();

            txtbxFname.Clear();
            txtbxLname.Clear();
            txtbxUname.Clear();
            txtbxPg.Clear();
            txtbxFname.Focus();
            return;
        }

        /// <summary>
        /// Returns user to the manager window
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnReturn_Click(object sender, RoutedEventArgs e)
        {
            Manager gmanager = new Manager();
            gmanager.Show();
            this.Close();
        }



        /// <summary>
        /// Adds list of employees to text file
        /// </summary>
        public void addStaff()
        {

            if (MessageBox.Show("Employee Added", "System Update", MessageBoxButton.OK) == MessageBoxResult.OK)//Display message, if Ok is clicked
            {

                FileStream file = new FileStream("C:\\MyPrograms - Danayal Iftikhar\\EventDriven2014\\EventDriven1.0\\bin\\Debug\\EmployeeList2.txt", FileMode.Open, FileAccess.ReadWrite); //Create new file called testfile
                StreamWriter sw = new StreamWriter(file); //create new streamwriter to write to testfile

                foreach (Employee emp in edb.Employees) //search through list
                {

                    sw.WriteLine(emp.fName + "\t" + emp.lName + "\t" + emp.holiday + "\t" + emp.pGrade); //display each member of list in testfile



                }
                sw.Close(); //close streamwriter
                edb.generate(); //populate the system with the updated file
            }
        }
    }
}
           
            
            




        
    


