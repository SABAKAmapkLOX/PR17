using Microsoft.EntityFrameworkCore;
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

namespace PR17
{
    public class Data
    {
        public static Student? student;
    }
    
    public partial class AddItemDataGrid : Window
    {
        StudentContext _db = new StudentContext ();
        Student _student;
        
        public AddItemDataGrid()
        {
            InitializeComponent();
        }
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            if (Data.student == null)
            {
                this.Title = "Добавление записи";
                btnAddItem.Content = "Добавить";
                _student = new Student();
            }
            else
            {
                this.Title = "Редактирование записи";
                btnAddItem.Content = "Изменить";
                _student = _db.Students.Find(Data.student.Id);
            }
            this.DataContext = _student;
        }

        private void btnAddItem_Click(object sender, RoutedEventArgs e)
        {
            StringBuilder error = new StringBuilder();
            
            //проверки всякие
            if (tbFamilia.Text.Length == 0 || tbFamilia.Text.Length >= 50) error.AppendLine("Введите Фамилию");
            if (tbIma.Text.Length == 0 || tbIma.Text.Length >= 50) error.AppendLine("Введите Имя");
            if (tbOtchestvo.Text.Length == 0 || tbOtchestvo.Text.Length >= 50) error.AppendLine("Введите Отчество");
            if (tbIdZachetnoKnigi.Text.Length == 0 || int.TryParse(tbIdZachetnoKnigi.Text, out int IdKnigi) == false) error.AppendLine("Введите id зачетной книги");
            if (tbIdGruppa.Text.Length == 0 || int.TryParse(tbIdGruppa.Text, out int IdGruppa) == false) error.AppendLine("Введите id группы");

            //Это для CheckBox что бы он записывал в БД True или False
            _student.ChivetVobchaga = boolChivetVObchaga.IsChecked;
            _student.Math = boolMath.IsChecked;
            _student.History = boolHistory.IsChecked;
            _student.PhysicalEdication = boolPhysicalEdication.IsChecked;
            _student.Informatic = boolInformatic.IsChecked;
            _student.English = boolEnglish.IsChecked;

            //Если есть ошибки то выводим MessageBox и не сохраняем
            if (error.Length > 0)
            {
                MessageBox.Show(error.ToString());
                return;
            }


            try
            {
                if (Data.student == null)
                {
                    _db.Students.Add(_student);
                    _db.SaveChanges();
                }
                else
                {
                    
                    _db.SaveChanges();
                }
                MessageBox.Show("Все хорошо");
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
        }

        private void btnClose_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
