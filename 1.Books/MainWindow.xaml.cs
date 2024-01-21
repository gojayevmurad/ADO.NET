using System.ComponentModel;
using System.Data.SqlClient;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace _1.Books
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window, INotifyPropertyChanged
    {

        private List<Book> books;

        public event PropertyChangedEventHandler? PropertyChanged;

        private Book book;

        public Book Book
        {
            get { return book; }
            set { book = value; OnPropertyChanged(); }
        }


        public List<Book> Books
        {
            get { return books; }
            set { books = value; OnPropertyChanged(); }
        }

        private void OnPropertyChanged([System.Runtime.CompilerServices.CallerMemberName] string propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }


        public MainWindow()
        {
            Book = new Book();
            Book.Name = "New Book";
            this.DataContext = this;
            InitializeComponent();
            Books = DB.GetAllBooks();
        }

        public void addNewBook(object sender, RoutedEventArgs e)
        {
            int affectedRows=  DB.addNewBook(Book);

            MessageBox.Show($"Affected rows: {affectedRows}");
            Books = DB.GetAllBooks();

            Book = new Book();
        }
    }
}