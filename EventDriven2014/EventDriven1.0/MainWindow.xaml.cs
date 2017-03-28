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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace EventDriven1.EventDriven2014
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        /// <summary>
        /// Variable for Employee DB and an attempt counter to measure number
        /// of login attempts
        /// </summary>
        private EmployeeDB employees;
        int attempts = 0;

        /// <summary>
        /// EmployeeDB is instantiated before the main login window
        /// Also sets the number of login attempts at 0
        /// </summary>
        public MainWindow()
        {
            employees = EmployeeDB.Instance;
            attempts = 0;
            InitializeComponent();
            txtUname.Focus();
        }

        /// <summary>
        /// Method which compares the manager/employee user input against the set login 
        /// details below, in the case of a failed attempt the number of failed attempts 
        /// are counted
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnLogin_Click(object sender, RoutedEventArgs e)
        {
            string un = txtUname.Text;
            string pw = pwdPassword.Password;


            if (un == "" || pw == "")
            {
                MessageBox.Show("No phone number entered");
            }
            else
            {
                if (attempts == 3)
                {
                    btnLogin.IsEnabled = false;
                    MessageBox.Show("Your account has been locked, see manager");
                    return;
                }



                else

                    if (un == "admin")
                    {
                        attempts++;
                        if (pw == "password")
                        {
                            Manager manager = new Manager();
                            manager.Show();
                            this.Close();
                            return;
                        }
                    }
                    else
                    {
                        foreach (Employee em in employees.employees)
                        {
                            if (em.uName == un)
                            {
                                attempts++;
                                if (em.pWord == pw)
                                {
                                    attempts = 0;
                                    EmpWindow emwi = new EmpWindow(em);
                                    emwi.Show();
                                    this.Close();
                                    return;
                                }
                            }
                        }
                    }

                {
                    pwdPassword.Clear();
                    MessageBox.Show("Wrong username or password");
                    pwdPassword.Focus();
                }
            }
        }
                    
                
            
        
        /// <summary>
        /// Empties the login screen of all data, refreshes and resets the attempts counter
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnClear_Click(object sender, RoutedEventArgs e)
        {
            if (MessageBox.Show("Are you sure?", "Clear All", MessageBoxButton.YesNo) == MessageBoxResult.Yes)
            {
                MainWindow main = new MainWindow();
                main.Show();
                this.Close();
            }
        }
    }
}

        
    






        
    

