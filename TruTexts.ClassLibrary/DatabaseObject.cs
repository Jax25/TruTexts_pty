using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;

namespace TruTexts.ClassLibrary
{
    public class DatabaseObject
    {
        private SqlConnection sqlCon { get; set; }

        private SqlCommand sqlcmd { get; set; }

        private string connectionString { get; set; }

        private SqlDataReader reader { get; set; }

        public List<Employee> employees { get; set; }

        public List<Customer> Customers { get; set; }

        public List<User> listofusers { get; set; }

        public List<Administrator> administrators { get; set; }

        public List<Suppliers> suppliers { get; set; }

        public List<Books> books { get; set; }

        public DatabaseObject()
        {
            this.connectionString = $@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename={Environment.CurrentDirectory}\TRUTEXTS_CUSTOMERS.MDF;Integrated Security=True";
            this.sqlCon = new SqlConnection();
            this.sqlcmd = new SqlCommand();
            this.sqlCon.ConnectionString = this.connectionString;
            this.sqlCon.Open();
            this.sqlcmd.Connection = this.sqlCon;

            this.employees = new List<Employee>();

            this.administrators = new List<Administrator>();

            this.Customers = new List<Customer>();

            this.listofusers = new List<User>();

            this.suppliers = new List<Suppliers>();

            this.books = new List<Books>();
        }

        public void InsertEmployee(Employee employee)
        {
            this.sqlcmd.CommandType = CommandType.Text;
            this.sqlcmd.CommandText =
                $"Insert into dbo.Employees values('{employee.username}',N'{employee.password}','{employee.firstname}','{employee.lastname}')";

            this.sqlcmd.ExecuteNonQuery();
        }

        public void ReadEmployees()
        {
            this.sqlcmd.CommandType = CommandType.Text;
            this.sqlcmd.CommandText = $"select EmpUsername,Emppassword,EmpFirstName,EmpLastName from dbo.Employees";

            this.reader = this.sqlcmd.ExecuteReader();

            if (this.reader.HasRows)
            {
                while (this.reader.Read())
                {
                    Employee employee = new Employee();
                    employee.username = this.reader["EmpUsername"].ToString();
                    employee.password = this.reader["Emppassword"].ToString();
                    employee.firstname = this.reader["EmpFirstName"].ToString();
                    employee.lastname = this.reader["EmpLastName"].ToString();

                    this.employees.Add(employee);
                }
            }
            this.reader.Close();
        }

        public void InsertAdmin(Administrator administrator)
        {
            this.sqlcmd.CommandType = CommandType.Text;
            this.sqlcmd.CommandText = $"Insert into dbo.Administrator values('{administrator.username}',N'{administrator.password}','{administrator.firstname}','{administrator.lastname}')";

            this.sqlcmd.ExecuteNonQuery();
        }

        public void ReadAdmin()
        {
            this.sqlcmd.CommandType = CommandType.Text;
            this.sqlcmd.CommandText = $"select AdminUsername,Adminpassword,AdminFirstName,AdminLastName from dbo.Administrator";

            this.reader = this.sqlcmd.ExecuteReader();

            if (this.reader.HasRows)
            {
                while (this.reader.Read())
                {
                    Administrator admin = new Administrator();
                    admin.username = this.reader["AdminUsername"].ToString();
                    admin.password = this.reader["Adminpassword"].ToString();
                    admin.firstname = this.reader["AdminFirstName"].ToString();
                    admin.lastname = this.reader["AdminLastName"].ToString();

                    this.administrators.Add(admin);
                }
            }

            this.reader.Close();
        }

        public void InsertCustomer(Customer customer)
        {
            this.sqlcmd.CommandType = CommandType.Text;
            this.sqlcmd.CommandText = $"Insert into dbo.Customer values('{customer.firstname}','{customer.lastname}','{customer.physicalAddress}','{customer.city}',N'{customer.cellnumber}')";

            this.sqlcmd.ExecuteNonQuery();
        }

        public void ReadCustomers()
        {
            this.sqlcmd.CommandType = CommandType.Text;
            this.sqlcmd.CommandText = $"select CustFirstname,CustLastname,CustphysicalAddress,CustCity,CustCellnumber from dbo.Customer";

            this.reader = this.sqlcmd.ExecuteReader();

            if (this.reader.HasRows)
            {
                while (this.reader.Read())
                {
                    Customer customer = new Customer();
                    customer.firstname = this.reader["CustFirstname"].ToString();
                    customer.lastname = this.reader["CustLastname"].ToString();
                    customer.physicalAddress = this.reader["CustPhysicalAddress"].ToString();
                    customer.city = this.reader["CustCity"].ToString();
                    customer.cellnumber = this.reader["CustCellnumber"].ToString();

                    this.Customers.Add(customer);
                }
            }
            this.reader.Close();
        }

        public void InsertSupplier(Suppliers suppliers)
        {
            this.sqlcmd.CommandType = CommandType.Text;
            this.sqlcmd.CommandText = $"Insert into dbo.Suppliers values('{suppliers.supplierName}')";

            this.sqlcmd.ExecuteNonQuery();
        }

        public void ReadSupplier()
        {
            this.sqlcmd.CommandType = CommandType.Text;
            this.sqlcmd.CommandText = $"select SuppliersName from dbo.Suppliers";

            this.reader = this.sqlcmd.ExecuteReader();

            if (this.reader.HasRows)
            {
                while (this.reader.Read())
                {
                    Suppliers supplier = new Suppliers();
                    supplier.supplierName = this.reader["SuppliersName"].ToString();

                    this.suppliers.Add(supplier);
                }
            }
            this.reader.Close();
        }

        public void InsertBook(Books books)
        {
            this.sqlcmd.CommandType = CommandType.Text;
            this.sqlcmd.CommandText = $"Insert into dbo.Books values('{books.bookTitle}','{books.author}','{books.yearPublished}')";

            this.sqlcmd.ExecuteNonQuery();
        }

        public void ReadBook()
        {
            this.sqlcmd.CommandType = CommandType.Text;
            this.sqlcmd.CommandText = $"select BooksTitle,BooksAuthor,BooksYearPublished from dbo.Books";

            this.reader = this.sqlcmd.ExecuteReader();

            if (this.reader.HasRows)
            {
                while (this.reader.Read())
                {
                    Books books = new Books();
                    books.bookTitle = this.reader["BooksTitle"].ToString();
                    books.author = this.reader["BooksAuthor"].ToString();
                    books.yearPublished = this.reader["BooksYearPublished"].ToString();

                    this.books.Add(books);
                }
            }

            this.reader.Close();
        }

        public void ReadUsers()
        {

            ReadEmployees();
            this.listofusers.AddRange(employees);

            ReadAdmin();
            this.listofusers.AddRange(administrators);
        }

        public void CloseConnection()
        {
            this.sqlCon.Close();
        }
    }
}