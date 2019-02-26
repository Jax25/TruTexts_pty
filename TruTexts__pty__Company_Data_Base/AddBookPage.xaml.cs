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
    /// Interaction logic for AddBookPage.xaml
    /// </summary>
    public partial class AddBookPage : Window
    {
        DatabaseObject db = new DatabaseObject();

        Books book = new Books();
        Suppliers supplier = new Suppliers();

        public AddBookPage()
        {
            InitializeComponent();
        }

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

        private void btnAddBook_Click(object sender, RoutedEventArgs e)
        {
            

            try
            {
                book.bookTitle = txtinsertBookTitle.Text;
                book.author = txtinsertAuthor.Text;
                book.yearPublished = txtInsertYearPublished.Text;


                db.books.Add(book);

                db.InsertBook(book);
            }
            catch (Exception ex)
            {

                txtErrorField.Text = ex.ToString();
            }
        }

        private void btnAddSupplier_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                supplier.supplierName = txtinsertSupplierName.Text;

                db.suppliers.Add(supplier);

                db.InsertSupplier(supplier);
            }
            catch (Exception ex)
            {

                txtErrorField.Text = ex.ToString();
            }
        }
    }
}

