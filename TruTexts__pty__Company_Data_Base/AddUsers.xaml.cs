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
using TruTexts.ClassLibrary;

namespace TruTexts__pty__Company_Data_Base
{
    /// <summary>
    /// Interaction logic for AddUsers.xaml
    /// </summary>
    public partial class AddUsers : Window
    {
        DatabaseObject db = new DatabaseObject();

        Customer customer = new Customer();
        Employee employee = new Employee();
        Administrator administrator = new Administrator();

        public AddUsers()
        {
            InitializeComponent();
        }

        private void btnAdd_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                //customer.username = txtinsertusername.Text;
                //customer.password = txtinsertpassword.Text;
                customer.firstname = txtinsertfirstname.Text;
                customer.lastname = txtinsertlastname.Text;
                customer.physicalAddress = txtInsertAddress.Text;
                customer.city = txtinsertcity.Text;
                customer.cellnumber = txtinsertcellnum.Text;

                //db.Customers = new List<Customer>();
                db.Customers.Add(customer);

                db.InsertCustomer(customer);
            }
            catch (Exception ex)
            {

                txtErrorField.Text = ex.ToString();
            }

        }

        private void btnAddEmployee_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                employee.username = txtinsertusername.Text;
                employee.password = txtinsertpassword.Text;
                employee.firstname = txtinsertfirstname.Text;
                employee.lastname = txtinsertlastname.Text;


                db.employees.Add(employee);

                db.InsertEmployee(employee);
            }
            catch (Exception ex)
            {

                txtErrorField.Text = ex.ToString();
            }
        }

        private void btnAddAdmin_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                administrator.username = txtinsertusername.Text;
                administrator.password = txtinsertpassword.Text;
                administrator.firstname = txtinsertfirstname.Text;
                administrator.lastname = txtinsertlastname.Text;


                db.administrators.Add(administrator);

                db.InsertAdmin(administrator);
            }
            catch (Exception ex)
            {

                txtErrorField.Text = ex.ToString();
            }

        }

        //private void btnAddAdmin_Click(object sender, RoutedEventArgs e)
        //{
        //    try
        //    {
        //        employee.username = txtinsertusername.Text;
        //        employee.password = txtinsertpassword.Text;
        //        employee.firstname = txtinsertfirstname.Text;
        //        employee.lastname = txtinsertlastname.Text;


        //        db.employees.Add(employee);

        //        db.InsertEmployee(employee);
        //    }
        //    catch (Exception ex)
        //    {

        //        txtErrorField.Text = ex.ToString();
        //    }

        //}



        private void btnpreviousepage_Click(object sender, RoutedEventArgs e)
        {
            MainPage page = new MainPage();

            page.Show();
            this.Close();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            MainWindow m = new MainWindow();
            m.Show();
            this.Close();
        }
    }
}
