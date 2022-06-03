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
using static AutoServise_shrbk.Classes.GlobalData;

namespace AutoServise_shrbk.Windows
{
    /// <summary>
    /// Логика взаимодействия для AddEditOrder.xaml
    /// </summary>
    public partial class AddEditOrder : Window
    {
        public AddEditOrder()
        {
            InitializeComponent();
        }

        private void tb_price_SelectedDateChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void btn_chooseClient_Click(object sender, RoutedEventArgs e)
        {
            ChooseClient chooseClient = new ChooseClient();
            chooseClient.ShowDialog();

            if (GetClient != null)
            {
                btn_chooseClient.FontSize = 15;
                btn_chooseClient.Content = GetClient.FIO;
            }
        }

        private void btn_chooseEmployee_Click(object sender, RoutedEventArgs e)
        {
            ChooseEmployee chooseEmployee = new ChooseEmployee();
            chooseEmployee.ShowDialog();

            if (GetEmployee != null)
            {
                btn_chooseEmployee.FontSize = 15;
                btn_chooseEmployee.Content = GetEmployee.FIO;
            }
        }

        private void btn_chooseService_Click(object sender, RoutedEventArgs e)
        {
            ChooseSrvice chooseSrvice = new ChooseSrvice();
            chooseSrvice.ShowDialog();
            if(GetService != null)
            {
                btn_chooseService.FontSize = 15;
                btn_chooseService.Content = GetService.Title;
                tb_cost.Text = GetService.Cost.ToString();
            }
        }

        private void btn_add_Click(object sender, RoutedEventArgs e)
        {
            if (GetClient == null)
            {
                MessageBox.Show("Выберите клиента", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            if (GetEmployee == null)
            {
                MessageBox.Show("Выберите сотрудника", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            if (GetService == null)
            {
                MessageBox.Show("Выберите оборудование", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            if(tb_price.SelectedDate==null)
            {
                MessageBox.Show("Выберите дату", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            var resClick = MessageBox.Show("Добавить запись?", "Подтверждение", MessageBoxButton.YesNo, MessageBoxImage.Question);

            if (resClick == MessageBoxResult.No)
            {
                return;
            }
            EF.Order order= new EF.Order();
            order.IDClient=GetClient.ID;
            order.IDEmployee = GetEmployee.ID;
            order.IDService = GetService.ID;
            order.StartTime =Convert.ToDateTime(tb_price.SelectedDate);

            EF.AppData.Context.Order.Add(order);
            EF.AppData.Context.SaveChanges();
            MessageBox.Show("Услуга успешно добавлена!");
            this.Close();
        }

        private void btn_back_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
