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

namespace EventDriven1.EventDriven2014
{
    /// <summary>
    /// Interaction logic for Manager.xaml
    /// </summary>
    public partial class Manager : Window
    {
        /// <summary>
        /// Variables are created for the employee database, list of employees,
        ///and get and set for current position in the 
        /// list of employees
        /// </summary>
        EmployeeDB empdb;
        List<Employee> emps;
        Employee employee;
        int pos { get; set; }

        /// <summary>
        ///Using EmployeeDB, the list of employees is declared, and the
        /// position in the list of employees is set to 0
        /// </summary>
        public Manager()
        {
            empdb = EmployeeDB.Instance;
            emps = empdb.employees;
            pos = 0;
            InitializeComponent();
        }

        /// <summary>
        /// Lists an employee, giving access to the relevant buttons required to
        /// navigate through the list
        /// </summary>
        private void displayEmployees()
        {
            if (employee != null)
            {
                txtbxEmpl.Text = employee.fName + " " + employee.lName;
                txtbxUname.Text = employee.fName.Substring(0, 1) + employee.lName;
                txtbxHrem.Text = employee.holiday.ToString();
                txtbxPg.Text = employee.pGrade;
                btnFirst.IsEnabled = true;
                btnLast.IsEnabled = true;
                btnNext.IsEnabled = true;
                btnPrev.IsEnabled = true;
            }
            else if (employee == null)
            {
                txtbxEmpl.Text = "None found";
                btnFirst.IsEnabled = false;
                btnLast.IsEnabled = false;
                btnNext.IsEnabled = false;
                btnPrev.IsEnabled = false;
            }
        }

        /// <summary>
        /// Shows the first employee in the list
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnFirst_Click(object sender, RoutedEventArgs e)
        {
            
            if (pos > 0)
            {
                pos = 0;
                employee = emps[pos];
                displayEmployees();
            }
            else
            {
                MessageBox.Show("At first employee");
            }
        }

        /// <summary>
        /// Displays the employee who is in the previous position in the list to
        /// the current position
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnPrev_Click(object sender, RoutedEventArgs e)
        {
            if (pos <= 0)
            {
                MessageBox.Show("Start of list");
            }
            else
            {
                pos--;
                employee = emps[pos];
                displayEmployees();
            }
        }

        /// <summary>
        /// Displays the employee next in the list to current position
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnNext_Click(object sender, RoutedEventArgs e)
        {
            if (pos < (emps.Count - 1))
            {
                pos++;
                employee = emps[pos];
                displayEmployees();
            }
            else
            {
                MessageBox.Show("End of list");
            }
        }

        /// <summary>
        /// Displays the employee at the last position in the list
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnLast_Click(object sender, RoutedEventArgs e)
        {
            if (pos < emps.Count - 1)
            {
                pos = emps.Count - 1;
                employee = emps[pos];
                displayEmployees();
            }
            else
            {
                MessageBox.Show("At last employee");
            }
        }

        /// <summary>
        /// Displays all employees in list
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnListAll_Click(object sender, RoutedEventArgs e)
        {
            lstbxEl.Items.Clear();
            lstbxEl.Items.Add(String.Format("All employees" + "\n" + "{0,-10}" + "{1,15}" + "{2,12}" + "{3,10}", "Name", "Username", "Holidays", "Pay Grade"));
            foreach (Employee emplo in emps)
            {
                lstbxEl.Items.Add(String.Format("{0,-10}" + "{1,15}" + "{2,12}" + "{3,10}" + "\n", emplo.fName + " " + emplo.lName, emplo.uName, emplo.holiday, emplo.pGrade));
            }
        }

        /// <summary>
        /// Returns to login screen
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnLogout_Click(object sender, RoutedEventArgs e)
        {
            if (MessageBox.Show("Are you sure?", "Logout", MessageBoxButton.YesNo) == MessageBoxResult.Yes)
            {
                MainWindow main = new MainWindow();
                main.Show();
                this.Close();
            }
        }

        /// <summary>
        /// Adds a new employee to the list
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnNe_Click(object sender, RoutedEventArgs e)
        {
            Addemp nemp = new Addemp();
            nemp.Show();
            this.Close();

        }

        /// <summary>
        /// Displays all employees who have less than 5 holidays remaining
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnLtf_Click(object sender, RoutedEventArgs e)
        {
            lstbxEl.Items.Clear();
            lstbxEl.Items.Add(String.Format("All employees" + "\n" + "{0,-10}" + "{1,15}" + "{2,12}" + "{3,10}", "Name", "Username", "Holidays", "Pay Grade"));
            foreach (Employee emplo in emps)
            {
                if (emplo.holiday < 5)
                {
                    lstbxEl.Items.Add(String.Format("{0,-10}" + "{1,15}" + "{2,12}" + "{3,10}" + "\n", emplo.fName + " " + emplo.lName, emplo.uName, emplo.holiday, emplo.pGrade));
                }
            }

        }
    }
}
