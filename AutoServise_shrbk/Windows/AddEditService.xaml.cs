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
    /// Логика взаимодействия для AddEditService.xaml
    /// </summary>
    public partial class AddEditService : Window
    {

        bool isEdit = false;
        EF.Service editService = new EF.Service();
        public AddEditService()
        {
            InitializeComponent();
        }
        public AddEditService(EF.Service service)
        {
            InitializeComponent();
            tbName.Text = "Изменение услуги";
            tb_title.Text = service.Title;
            tb_price.Text = service.Cost.ToString();
            tb_description.Text = service.Description;
            editService = service;
            isEdit = true;
        }
        private void textBoxes_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            e.Handled = "ячсмитьбюфывапролджэйцукенгшщзхъЯЧСМИТЬБЮФЫВАПРОЛДЖЭЙЦУКЕНГШЩЗХЪ-1234567890?!.,/".IndexOf(e.Text) < 0;
        }
        private void tb_phone_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            e.Handled = "1234567890".IndexOf(e.Text) < 0;
        }

        private void btn_add_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(tb_title.Text))
            {
                MessageBox.Show("Укажите название", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            if (string.IsNullOrWhiteSpace(tb_price.Text))
            {
                MessageBox.Show("Укажите цену", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            if (isEdit)
            {
                var resClick = MessageBox.Show("Изменить услугу?", "Подтверждение", MessageBoxButton.YesNo, MessageBoxImage.Question);

                if (resClick == MessageBoxResult.No)
                {
                    return;
                }
                editService.Title = tb_title.Text;
                editService.Cost = Convert.ToDecimal(tb_price.Text);
                editService.Description = tb_description.Text;

                EF.AppData.Context.SaveChanges();
                MessageBox.Show("Услуга изменена");
                this.Close();
            }
            else
            {
                var resClick = MessageBox.Show("Добавить услугу?", "Подтверждение", MessageBoxButton.YesNo, MessageBoxImage.Question);

                if (resClick == MessageBoxResult.No)
                {

                }

                EF.Service service = new EF.Service();

                service.Title = tb_title.Text;
                service.Cost = Convert.ToDecimal(tb_price.Text);
                service.Description = tb_description.Text;
                EF.AppData.Context.Service.Add(service);
                EF.AppData.Context.SaveChanges();
                MessageBox.Show("Услуга добавлена");
                this.Close();
            }
        }

        private void btn_back_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }

}
