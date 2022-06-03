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
    /// Логика взаимодействия для AddEditClient.xaml
    /// </summary>
    public partial class AddEditClient : Window
    {
        bool isEdit = false;
        EF.Client editClient= new EF.Client();
        public AddEditClient()
        {
            InitializeComponent();
            cb_gender.ItemsSource = EF.AppData.Context.Gender.ToList();
            cb_gender.DisplayMemberPath = "Title";
            cb_gender.SelectedIndex = 0;
        }
        public AddEditClient(EF.Client client)
        {
            InitializeComponent();
            cb_gender.ItemsSource = EF.AppData.Context.Gender.ToList();
            cb_gender.DisplayMemberPath = "Title";
            tb_title.Text = "Изменение клиента";
            tb_firstName.Text = client.FirstName;
            tb_secondName.Text = client.SecondName;
            tb_patronymic.Text = client.Patronymic;
            tb_mail.Text = client.Email;
            tb_phone.Text=client.Phone;
            dp_birthday.SelectedDate = client.Birthday;
            cb_gender.SelectedIndex = client.IDGender - 1;

            isEdit = true;
            editClient = client;
        }

        private void btn_back_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void tb_text_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            e.Handled = "ячсмитьбюфывапролджэйцукенгшщзхъЯЧСМИТЬБЮФЫВАПРОЛДЖЭЙЦУКЕНГШЩЗХЪ-".IndexOf(e.Text) < 0;
        }

        private void tb_phone_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            e.Handled = "1234567890".IndexOf(e.Text) < 0;
        }

        private void btnSend_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(tb_firstName.Text))
            {
                MessageBox.Show("Укажите имя", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            if (string.IsNullOrWhiteSpace(tb_secondName.Text))
            {
                MessageBox.Show("Укажите фамилию", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            if (string.IsNullOrWhiteSpace(tb_phone.Text))
            {
                MessageBox.Show("Укажите номер телефона", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            if (string.IsNullOrWhiteSpace(tb_mail.Text))
            {
                MessageBox.Show("Укажите почту", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            if (dp_birthday.SelectedDate == null)
            {
                MessageBox.Show("Укажите день рождения", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            if ((tb_mail.Text.Contains('@') && ((tb_mail.Text.Contains(".com") || tb_mail.Text.Contains(".ru") || tb_mail.Text.Contains(".net")))) == false)
            {
                MessageBox.Show("Почта указана неверно", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            if (isEdit)
            {
                var resClick = MessageBox.Show("Изменить клиента?", "Подтверждение", MessageBoxButton.YesNo, MessageBoxImage.Question);

                if (resClick == MessageBoxResult.No)
                {
                    return;
                }

                editClient.FirstName = tb_firstName.Text;
                editClient.SecondName = tb_secondName.Text;
                editClient.Patronymic = tb_patronymic.Text;
                editClient.Phone = tb_phone.Text;
                editClient.Email = tb_mail.Text;
                editClient.IDGender = cb_gender.SelectedIndex + 1;

                EF.AppData.Context.SaveChanges();
                MessageBox.Show("Клиент изменен");
                this.Close();
            }
            else
            {
                var resClick = MessageBox.Show("Добавить клиента?", "Подтверждение", MessageBoxButton.YesNo, MessageBoxImage.Question);

                if (resClick == MessageBoxResult.No)
                {
                    return;
                }

                EF.Client newClient = new EF.Client();

                newClient.FirstName = tb_firstName.Text;
                newClient.SecondName = tb_secondName.Text;
                newClient.Patronymic = tb_patronymic.Text;
                newClient.Phone = tb_phone.Text;
                newClient.Email = tb_mail.Text;
                newClient.IDGender = cb_gender.SelectedIndex + 1;
                newClient.Birthday = Convert.ToDateTime(dp_birthday.SelectedDate);

                EF.AppData.Context.Client.Add(newClient);
                EF.AppData.Context.SaveChanges();
                MessageBox.Show("Клиент добавлен");
                this.Close();
            }
            
        }
    }
}
