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
    /// Interaction logic for MainPage.xaml
    /// </summary>
    public partial class MainPage : Window
    {
        public MainPage()
        {
            InitializeComponent();
            List<string> tableNames = new List<string>();
            tableNames.Add("Employee");
            tableNames.Add("Customers");
            tableNames.Add("Admin");
            tableNames.Add("Suppliers");
            tableNames.Add("Books");

            List<string> Pages = new List<string>();
            Pages.Add("Add Admin");
            Pages.Add("Add Employee");
            Pages.Add("Add Supplier");
            Pages.Add("Add Customer");
            Pages.Add("Add Books");


            cbTableName.ItemsSource = tableNames;
            cbAdd.ItemsSource = Pages;

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            MainWindow m = new MainWindow();
            m.Show();
            this.Close();
        }

        private void cbTableName_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            DatabaseObject db = new DatabaseObject();// this should be created in the contructor; using get and set before constructor

            if (cbTableName.SelectedValue.ToString() == "Customers")
            {
                db.ReadCustomers();
                dgTableData.ItemsSource = db.Customers;
            }

            else if (cbTableName.SelectedValue.ToString() == "Employee")
            {
                db.ReadEmployees();
                dgTableData.ItemsSource = db.employees;
            }

            else if (cbTableName.SelectedValue.ToString() == "Admin")
            {
                db.ReadAdmin();
                dgTableData.ItemsSource = db.administrators;
            }

            else if (cbTableName.SelectedValue.ToString() == "Suppliers")
            {
                db.ReadSupplier();
                dgTableData.ItemsSource = db.suppliers;
            }

            else if(cbTableName.SelectedValue.ToString() == "Books")
            {
                db.ReadBook();
                dgTableData.ItemsSource = db.books;
            }

            db.CloseConnection();
        }

        private void btnAddCustomer_Click(object sender, RoutedEventArgs e)
        {
            AddUsers addCustomers = new AddUsers();

            addCustomers.btnAddAdmin.Visibility = Visibility.Hidden;
            addCustomers.Show();
            this.Close();
        }

        private void btnAddAdmin_Click(object sender, RoutedEventArgs e)
        {
            AddUsers addAdmin = new AddUsers();
            addAdmin.btnAdd.Visibility = Visibility.Hidden;
            addAdmin.btnAddEmployee.Visibility = Visibility.Hidden;

            addAdmin.tbAddress.Visibility = Visibility.Hidden;
            addAdmin.txtInsertAddress.Visibility = Visibility.Hidden;
            addAdmin.tbcity.Visibility = Visibility.Hidden;
            addAdmin.txtinsertcity.Visibility = Visibility.Hidden;
            addAdmin.tbCellnum.Visibility = Visibility.Hidden;
            addAdmin.txtinsertcellnum.Visibility = Visibility.Hidden;

            addAdmin.Show();
            this.Close();
        }

        private void btnAddEmployee_Click(object sender, RoutedEventArgs e)
        {
            AddUsers addEmployee = new AddUsers();
            addEmployee.btnAdd.Visibility = Visibility.Hidden;
            addEmployee.btnAddAdmin.Visibility = Visibility.Hidden;

            addEmployee.tbAddress.Visibility = Visibility.Hidden;
            addEmployee.txtInsertAddress.Visibility = Visibility.Hidden;
            addEmployee.tbcity.Visibility = Visibility.Hidden;
            addEmployee.txtinsertcity.Visibility = Visibility.Hidden;
            addEmployee.tbCellnum.Visibility = Visibility.Hidden;
            addEmployee.txtinsertcellnum.Visibility = Visibility.Hidden;

            addEmployee.Show();
            this.Close();
        }

        private void cnAdd_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (cbAdd.SelectedValue.ToString() == "Add Admin")
            {
                AddUsers addAdmin = new AddUsers();
                addAdmin.btnAdd.Visibility = Visibility.Hidden;
                addAdmin.btnAddEmployee.Visibility = Visibility.Hidden;

                addAdmin.tbAddress.Visibility = Visibility.Hidden;
                addAdmin.txtInsertAddress.Visibility = Visibility.Hidden;
                addAdmin.tbcity.Visibility = Visibility.Hidden;
                addAdmin.txtinsertcity.Visibility = Visibility.Hidden;
                addAdmin.tbCellnum.Visibility = Visibility.Hidden;
                addAdmin.txtinsertcellnum.Visibility = Visibility.Hidden;

                addAdmin.Show();
                this.Close();
            }

            else if (cbAdd.SelectedValue.ToString() == "Add Employee")
            {
                AddUsers addEmployee = new AddUsers();
                addEmployee.btnAdd.Visibility = Visibility.Hidden;
                addEmployee.btnAddAdmin.Visibility = Visibility.Hidden;

                addEmployee.tbAddress.Visibility = Visibility.Hidden;
                addEmployee.txtInsertAddress.Visibility = Visibility.Hidden;
                addEmployee.tbcity.Visibility = Visibility.Hidden;
                addEmployee.txtinsertcity.Visibility = Visibility.Hidden;
                addEmployee.tbCellnum.Visibility = Visibility.Hidden;
                addEmployee.txtinsertcellnum.Visibility = Visibility.Hidden;

                addEmployee.Show();
                this.Close();
            }

            else if (cbAdd.SelectedValue.ToString() == "Add Supplier")
            {
                AddBookPage addSupplier = new AddBookPage();

                addSupplier.btnAddBook.Visibility = Visibility.Hidden;
                addSupplier.tbBookTitle.Visibility = Visibility.Hidden;
                addSupplier.txtinsertBookTitle.Visibility = Visibility.Hidden;
                addSupplier.tbAuthor.Visibility = Visibility.Hidden;
                addSupplier.txtinsertAuthor.Visibility = Visibility.Hidden;
                addSupplier.tbYearPublished.Visibility = Visibility.Hidden;
                addSupplier.txtInsertYearPublished.Visibility = Visibility.Hidden;

                addSupplier.Show();
                this.Close();
            }

            else if (cbAdd.SelectedValue.ToString() == "Add Customer")
            {
                AddUsers addCustomers = new AddUsers();

                addCustomers.btnAddAdmin.Visibility = Visibility.Hidden;
                addCustomers.btnAddEmployee.Visibility = Visibility.Hidden;

                addCustomers.Show();
                this.Close();
            }

            else if (cbAdd.SelectedValue.ToString() == "Add Books")
            {
                AddBookPage addbooks = new AddBookPage();
                addbooks.tbSupplierName.Visibility = Visibility.Hidden;
                addbooks.txtinsertSupplierName.Visibility = Visibility.Hidden;
                addbooks.btnAddSupplier.Visibility = Visibility.Hidden;

                addbooks.Show();
                this.Close();
            }
        }
    }
}