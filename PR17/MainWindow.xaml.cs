using Microsoft.IdentityModel.Tokens;
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
        private void MenuItem_Click(object sender, RoutedEventArgs e)
        {
            var s = sender as MenuItem;
            switch(s.Header)
            {
                case "Добавить":
                    AddItem();
                    break;
                case "Редактировать":
                    EditItem(); 
                    break;
                case "Удалить":
                    DelItem();
                    break;
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            var s = sender as Button;
            switch(s.Content)
            {
                case "Найти":
                    Find();
                    break;
                case "Фильтр":
                    Find();
                    break;
            }
        }


        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            LoadDBInDataGrid();
        }

        private void LoadDBInDataGrid()
        {
            using (StudentContext _db = new StudentContext())//Контекст
            {
                int selectedIndex = dataGrid.SelectedIndex;
                dataGrid.ItemsSource = _db.Students.ToList();//Привязываем 
                if (selectedIndex != -1)
                {
                    if (selectedIndex == dataGrid.Items.Count) selectedIndex--;
                    dataGrid.SelectedIndex = selectedIndex;
                    dataGrid.ScrollIntoView(dataGrid.SelectedIndex);
                }
                dataGrid.Focus();
            }
        }

        private void AddItem()
        {
            Data.student = null;
            AddItemDataGrid addItem = new AddItemDataGrid();
            addItem.Owner = this;
            addItem.ShowDialog();
            LoadDBInDataGrid();
        }
        
        private void EditItem()
        {
            Data.student = (Student)dataGrid.SelectedItem;
            AddItemDataGrid editItem = new AddItemDataGrid();
            editItem.Owner = this;
            editItem.ShowDialog();
            LoadDBInDataGrid();
        }

        private void DelItem()
        {
            MessageBoxResult result;
            result = MessageBox.Show("Удалить Запись?"," Удаление записи", MessageBoxButton.YesNo, MessageBoxImage.Warning);
            if (result == MessageBoxResult.Yes)
            {
                try
                {
                    Student row = (Student)dataGrid.SelectedItem;
                    if (row != null)
                    {

                        using (StudentContext _db = new StudentContext())
                        {
                            _db.Students.Remove(row);
                            _db.SaveChanges();
                            LoadDBInDataGrid();
                        }
                    }
                }
                catch
                {
                    MessageBox.Show("Ошибка удаления");
                }
            }
            else dataGrid.Focus();
        }

        private void Find()
        {
            //Получаем коллекцию элементов из dataGrid
            List<Student> listItem = (List<Student>)dataGrid.ItemsSource;
            //Используем метод Whee для фильтрации по заданному критерию 
            var filtered = listItem.Where(p => p.Familia.Contains(tbFind.Text));
            if (filtered.Count() > 0)
            {
                var item = filtered.First();
                dataGrid.SelectedItem = item;
                dataGrid.ScrollIntoView(item);
                dataGrid.Focus();
            }
            else MessageBox.Show("Нету");
        }

        private void Filter()
        {
            if (tbFindFilter.Text.IsNullOrEmpty() == false)
            {
                using (StudentContext _db = new StudentContext())
                {
                    var filter = _db.Students.Where(p => p.Familia == tbFindFilter.Text);
                    dataGrid.ItemsSource = filter.ToList();
                }
            }
            else LoadDBInDataGrid();
        }
    }
}