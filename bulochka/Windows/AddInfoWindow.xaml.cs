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
    /// Логика взаимодействия для AddInfoWindow.xaml
    /// </summary>
    public partial class AddInfoWindow : Window
    {
        private readonly Student _currentStudent = new Student();
        private readonly L4Entities _bd = new L4Entities();

        public AddInfoWindow()
        {
            InitializeComponent();
            DataContext = _currentStudent;
            ComboBoxSpecialization.ItemsSource = L4Entities.GetContext().Specialization.ToList();
            ComboBoxCurator.ItemsSource = L4Entities.GetContext().Curator.ToList();
        }

        private void ButtonSave_Click(object sender, RoutedEventArgs e)
        {
            var flag = true;
            foreach (Control c in GridAdd.Children)
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
            if (flag) {
                L4Entities.GetContext().Student.Add(_currentStudent);
                L4Entities.GetContext().SaveChanges();
                MessageBox.Show("Ура! Добавилось!");
                new MainWindow().Show();
                Close();
            }
            else MessageBox.Show("Пусто и грустно :( ");
        }

        private void ButtonAddBack_Click(object sender, RoutedEventArgs e)
        {
            new MainWindow().Show();
            Close();
        }

        private void TextBoxCourse_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            if (!char.IsDigit(e.Text, 0))
            {
                e.Handled = true;
            }
        }

        private void TextBoxName_PreviewTextInput(object sender, TextCompositionEventArgs e)
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
