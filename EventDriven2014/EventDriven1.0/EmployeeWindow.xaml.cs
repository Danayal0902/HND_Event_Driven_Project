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
    /// Interaction logic for EmpWindow.xaml
    /// </summary>
    public partial class EmpWindow : Window
    {
        private Employee emp;

        public EmpWindow(Employee e)
        {
            emp = e;
            InitializeComponent();
            txtRequest.Focus();
        }

        /// <summary>
        /// Logs user out and returns to login screen
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
        /// Clears all content from textboxes
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnClear_Click(object sender, RoutedEventArgs e)
        {
            txtRequest.Clear();
            txtRequest.Focus();
        }

        /// <summary>
        /// When window loads username and holidays remaining are populated
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            txtUser.Text = emp.fName + " " + emp.lName;
            txtHoliday.Text = emp.holiday.ToString();
        }

        /// <summary>
        /// Sends holiday request to manager
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnRequest_Click(object sender, RoutedEventArgs e)
        {
            int request;
            if (int.TryParse(txtRequest.Text, out request))
            {
                if (request > emp.holiday)
                {
                    MessageBox.Show("No holidays remaining");
                }
                if (request > 0 && request <= emp.holiday)
                {
                    MessageBox.Show("Request sent");
                    MessageBox.Show("You now have" + (emp.holiday - request) + "days remaining");
                    int strout = emp.holiday - request;
                    txtHoliday.Text = strout.ToString();
                    emp.holiday = strout;
                }
                if (request <= 0)
                {
                    MessageBox.Show(request + " is invalid, try again");
                }
            }
            else
            {
                MessageBox.Show("Numerical values only");
            }
        }
    }
}
