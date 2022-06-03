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

namespace AutoServise_shrbk.Windows
{
    /// <summary>
    /// Логика взаимодействия для Authorization.xaml
    /// </summary>
    public partial class Authorization : Window
    {
        public Authorization()
        {
            InitializeComponent();
        }

        private void tb_login_PreviewMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            if (tb_login.Text == "Логин")
            {
                tb_login.Text = "";
            }
            if (tb_pas.Password == "")
            {
                tb_pas.Password = "Пароль";
            }
        }


        private void tb_pas_PreviewMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            if (tb_pas.Password == "Пароль")
            {
                tb_pas.Password = "";
            }
            if (tb_login.Text == "")
            {
                tb_login.Text = "Логин";
            }
        }

        private void btn_enter_Click(object sender, RoutedEventArgs e)
        {
            if (tb_pas.Password == "")
            {
                tb_pas.Password = "Пароль";
            }
            if (tb_login.Text == "")
            {
                tb_login.Text = "Логин";
            }
            if (string.IsNullOrWhiteSpace(tb_login.Text)|| tb_login.Text =="Логин")
            {
                MessageBox.Show("Введите логин", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            if (string.IsNullOrWhiteSpace(tb_pas.Password)|| tb_pas.Password == "Пароль")
            {
                MessageBox.Show("Введите пароль", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            var authUser = EF.AppData.Context.Employee.ToList().
                Where(i => i.Login == tb_login.Text && i.Password == tb_pas.Password).FirstOrDefault();
            if (authUser != null)
            {
                bool access = false;
                if (authUser.IDRole == 1)
                {
                    access = true;
                }               
                    MainWindow mainWindow = new MainWindow(access);
                    this.Hide();
                    mainWindow.ShowDialog();
                    this.ShowDialog();
                

            }
            else
            {
                MessageBox.Show("Пользователь не найден", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
        }
    }
}
