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
using bulochka.Pages;

namespace bulochka
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private Student _currentStudent = new Student();

        public MainWindow()
        {
            InitializeComponent();
            DataContext = _currentStudent;
            DataGridStudent.ItemsSource = L4Entities.GetContext().Student.ToList();
            DataGridStudent.ItemsSource = L4Entities.GetContext().Student.OrderBy(x => x.IDStudent).ToList();
        }
        private void ButtonAdd_Click(object sender, RoutedEventArgs e)
        {
            new AddInfoWindow().Show();
            Close();
        }

        private void ButtonDeleteGrid_Click(object sender, RoutedEventArgs e)
        {
            var studentRemoving = DataGridStudent.SelectedItems.Cast<Student>().ToList();
            if (MessageBox.Show($"Подтвердить удаление?", "!",
                    MessageBoxButton.YesNo, MessageBoxImage.Question) != MessageBoxResult.Yes) return;
            
            L4Entities.GetContext().Student.RemoveRange(studentRemoving);
            L4Entities.GetContext().SaveChanges();
            MessageBox.Show("Ура! Удалилось!");
            DataGridStudent.ItemsSource = L4Entities.GetContext().Student.OrderBy(x => x.IDStudent).ToList();
        }

        private void ButtonEditGrid_Click(object sender, RoutedEventArgs e)
        {
            var item = (Student)DataGridStudent.SelectedItem;
            new EditInfoWindow(item).Show();
            Close();
        }
    }
}