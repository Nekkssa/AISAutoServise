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
    /// Логика взаимодействия для OrderList.xaml
    /// </summary>
    public partial class OrderList : Window
    {
        List<string> listSort = new List<string>()
            {
                "По умолчанию",
                "По клиенту",
                "По сотруднику",
                "По названию",
                "По цене"
            };
        public OrderList()
        {
            InitializeComponent();
            cb_sort.ItemsSource = listSort;
            cb_sort.SelectedIndex = 0;
            Filter();
        }
        private void Filter()
        {
            List<EF.Order> listOrder = new List<EF.Order>();
            listOrder = EF.AppData.Context.Order.ToList();

            listOrder = listOrder.
                Where(i => i.Client.FIO.ToLower().Contains(tb_search.Text.ToLower())
                || i.Employee.FIO.ToLower().Contains(tb_search.Text.ToLower())
                || i.Service.Title.ToLower().Contains(tb_search.Text.ToLower())
                || i.StartTime.ToString().ToLower().Contains(tb_search.Text.ToLower())
                || i.Service.Cost.ToString().ToLower().Contains(tb_search.Text.ToLower())).ToList();

            switch (cb_sort.SelectedIndex)
            {
                case 0:
                    listOrder = listOrder.OrderBy(i => i.ID).ToList();
                    break;
                case 1:
                    listOrder = listOrder.OrderBy(i => i.Client.FIO).ToList();
                    break;
                case 2:
                    listOrder = listOrder.OrderBy(i => i.Employee.FIO).ToList();
                    break;
                case 3:
                    listOrder = listOrder.OrderBy(i => i.Service.Title).ToList();
                    break;
                case 4:
                    listOrder = listOrder.OrderBy(i => i.Service.Cost).ToList();
                    break;
            }

            lv_order.ItemsSource = listOrder;
        }

        private void btn_back_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void btn_add_Click(object sender, RoutedEventArgs e)
        {
            AddEditOrder addEditOrder = new AddEditOrder();
            this.Hide();
            addEditOrder.ShowDialog();
            this.ShowDialog();
            Filter();
        }

        private void tb_search_TextChanged(object sender, TextChangedEventArgs e)
        {
            Filter();
        }

        private void cb_sort_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Filter();
        }
    }
}
