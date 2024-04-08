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

namespace bulochka.Pages
{
    /// <summary>
    /// Логика взаимодействия для EditInfoWindow.xaml
    /// </summary>
    public partial class EditInfoWindow : Window
    {
        private Student _currentStudent = new Student();
        L4Entities bd = new L4Entities();

        public EditInfoWindow(Student selectStudent)
        {
            InitializeComponent();
            if (selectStudent == null) return;
            
            _currentStudent = selectStudent;
            DataContext = _currentStudent;
            ComboBoxEditSpecialization.ItemsSource = L4Entities.GetContext().Specialization.ToList();
            ComboBoxEditCurator.ItemsSource = L4Entities.GetContext().Curator.ToList();
        }
   
        private void ButtonEdit_Click(object sender, RoutedEventArgs e)
        {
            var flag = true;
            foreach (Control c in GridEdit.Children)
            {
                if (c.GetType() == typeof(TextBox))
                {
                    if (((TextBox)c).Text == String.Empty)
                    {
                        flag = false;
                    }
                }

                if (c.GetType() == typeof(ComboBox))
                {
                    if (((ComboBox)c).Text == String.Empty)
                    {
                        flag = false;
                    }
                }
            }
            if (flag)
            {
                L4Entities.GetContext().SaveChanges();
                MessageBox.Show("Ура! Изменилось!");
                new MainWindow().Show();
                Close();
            }
            else MessageBox.Show("Пусто и грустно :( ");

        }

        private void ButtonEditBack_Click(object sender, RoutedEventArgs e)
        {
            new MainWindow().Show(); 
            Close();
        }

        private void TextBoxEditCourse_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            if (!char.IsDigit(e.Text, 0))
            {
                e.Handled = true;
            }
        }

        private void TextBoxEditName_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            foreach (char c in e.Text)
            {
                if (!char.IsLetter(c))
                {
                    e.Handled = true;
                    break;
                }
            }
        }
    }
}
