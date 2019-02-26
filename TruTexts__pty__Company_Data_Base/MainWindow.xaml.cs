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
using TruTexts.ClassLibrary;

namespace TruTexts__pty__Company_Data_Base
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void btnLogin_Click(object sender, RoutedEventArgs e)
        {
            DatabaseObject db = new DatabaseObject();

            User unauthenticated_user = new UnauthenticatedUser();
            unauthenticated_user.username = txtusername.Text;
            unauthenticated_user.password = txtpassword.Password;

            IValidator loginValidator = new LoginValidator();
            IValidator adminAccessValidator = new AdminAccessValidator();

            if (loginValidator.Isvalid(unauthenticated_user))
            {
                MainPage page = new MainPage();
                if (!adminAccessValidator.Isvalid(unauthenticated_user)) //!means not if not.....
                {
                    page.btnUpdate.Visibility = Visibility.Hidden;
                    page.btnAddAdmin.Visibility = Visibility.Hidden;
                    page.btnAddCustomer.Visibility = Visibility.Hidden;
                    page.btnAddEmployee.Visibility = Visibility.Hidden;
                    page.btnDelete.Visibility = Visibility.Hidden;
                    page.cbTableName.Visibility = Visibility.Hidden;
                    page.tbselecttable.Visibility = Visibility.Hidden;
                    page.cbAdd.Visibility = Visibility.Hidden;
                    

                    page.cbTableName.SelectedValue = "Customer";
                    page.cbTableName.IsEnabled = false;
                    db.ReadCustomers();
                    page.dgTableData.ItemsSource = db.Customers;

                }

                db.CloseConnection();
                page.Show();
                this.Close();
            }
            else
            {
                MessageBox.Show("username or password is incorrect!!!");
            }
        }
    }
}
//singleton