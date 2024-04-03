using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace bulochka
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private Student _currentStudent = new Student();
        L4Entities bd = new L4Entities();
        public MainWindow()
        {
            InitializeComponent();
            DataContext = _currentStudent;
            DataGridStudent.ItemsSource = L4Entities.GetContext().Student.ToList();
            DataGridStudent.ItemsSource = L4Entities.GetContext().Student.OrderBy(x => x.IDStudent).ToList();
        }
        private void ButtonAdd_Click(object sender, RoutedEventArgs e)
        {
            Pages.AddInfoWindow _addInfoWindow = new Pages.AddInfoWindow();
            _addInfoWindow.Show();
            this.Close();
        }

        private void ButtonDeleteGrid_Click(object sender, RoutedEventArgs e)
        {
            var StudentRemoving = DataGridStudent.SelectedItems.Cast<Student>().ToList();
            if (MessageBox.Show($"Подтвердить удаление?", "!",
                MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
            {
                L4Entities.GetContext().Student.RemoveRange(StudentRemoving);
                L4Entities.GetContext().SaveChanges();
                MessageBox.Show("Ура! Удалилось!");
                DataGridStudent.ItemsSource = L4Entities.GetContext().Student.OrderBy(x => x.IDStudent).ToList();
            }
        }

        private void ButtonEditGrid_Click(object sender, RoutedEventArgs e)
        {
            Student item = (Student)DataGridStudent.SelectedItem;
            Pages.EditInfoWindow _editInfoWindow = new Pages.EditInfoWindow(item);
            _editInfoWindow.Show();
            this.Close();
        }
    }
}