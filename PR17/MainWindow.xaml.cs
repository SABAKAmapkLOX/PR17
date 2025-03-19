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

namespace PR17
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

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            LoadDBInDataGrid();
            AddItemDataGrid add = new AddItemDataGrid();
            add.ShowDialog();
        }

        private void LoadDBInDataGrid()
        {
            using (StudentContext _db = new StudentContext())
            {
                int selectedIndex = dataGrid.SelectedIndex;
                dataGrid.ItemsSource = _db.Students.ToList();
                if (selectedIndex != -1)
                {
                    if (selectedIndex == dataGrid.Items.Count) selectedIndex--;
                    dataGrid.SelectedIndex = selectedIndex;
                    dataGrid.ScrollIntoView(dataGrid.SelectedIndex);
                }
                dataGrid.Focus();
            }
        }
    }
}