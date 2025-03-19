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
    /// <summary>
    /// Логика взаимодействия для AddItemDataGrid.xaml
    /// </summary>
    public partial class AddItemDataGrid : Window
    {
        public AddItemDataGrid()
        {
            InitializeComponent();
            Student student = new Student(); 
            student.ChivetVobchaga=boolChivetVObchaga.IsChecked;
            student.Math=boolMath.IsChecked;
            student.History=boolHistory.IsChecked;
            student.PhysicalEdication=boolPhysicalEdication.IsChecked;
            student.Informatic=boolInformatic.IsChecked;
            student.English=boolEnglish.IsChecked;
        }
    }
}
