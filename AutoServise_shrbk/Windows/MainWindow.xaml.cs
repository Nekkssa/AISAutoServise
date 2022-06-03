using AutoServise_shrbk.Windows;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace AutoServise_shrbk
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow(bool access)
        {
            InitializeComponent();
            if(access==false)
            {
                btn_employeeList.Visibility = Visibility.Collapsed;
                btn_reports.Visibility = Visibility.Collapsed;
            }
        }

        private void btn_clientList_Click(object sender, RoutedEventArgs e)
        {
            ClientList clientList = new ClientList();
            this.Hide();
            clientList.ShowDialog();
            this.ShowDialog();
        }

        private void btn_employeeList_Click(object sender, RoutedEventArgs e)
        {
            EmployeeList employeeList = new EmployeeList();
            this.Hide();
            employeeList.ShowDialog();
            this.ShowDialog();
        }

        private void btn_serviceList_Click(object sender, RoutedEventArgs e)
        {
            ServiceList service = new ServiceList();
            this.Hide();
            service.ShowDialog();
            this.ShowDialog();
        }

        private void btn_order_Click(object sender, RoutedEventArgs e)
        {
            OrderList orderList = new OrderList();
            this.Hide();
            orderList.ShowDialog();
            this.ShowDialog();
        }

        private void btn_reports_Click(object sender, RoutedEventArgs e)
        {
            ReportsWindow reportsWindow = new ReportsWindow();
            this.Hide();
            reportsWindow.ShowDialog();
            this.ShowDialog();
        }

        private void btn_back_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
