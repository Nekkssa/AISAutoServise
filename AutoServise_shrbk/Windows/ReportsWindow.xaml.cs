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
    /// Логика взаимодействия для ReportsWindow.xaml
    /// </summary>
    public partial class ReportsWindow : Window
    {
        public ReportsWindow()
        {
            InitializeComponent();
            dp_end.SelectedDate = DateTime.Now;
            dp_begin.SelectedDate = DateTime.Now.AddMonths(-1);
            Filter();
        }

        private void Filter()
        {
            decimal sum = 0;
            List<EF.Order> report = EF.AppData.Context.Order.ToList();
            if (dp_begin.SelectedDate > dp_end.SelectedDate)
            {
                report = report.Where(i => i.StartTime <= dp_begin.SelectedDate && i.StartTime >= dp_end.SelectedDate).ToList();
            }
            else
            {
                report = report.Where(i => i.StartTime >= dp_begin.SelectedDate && i.StartTime <= dp_end.SelectedDate).ToList();
            }

            lv_report.ItemsSource = report;

            foreach (EF.Order order in report)
            {
                sum += Convert.ToDecimal(order.Service.Cost);
            }
            tb_finalSum.Text = sum.ToString();
        }

        private void btn_back_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void dp_begin_SelectedDateChanged(object sender, SelectionChangedEventArgs e)
        {
            Filter();
        }

        private void dp_end_SelectedDateChanged(object sender, SelectionChangedEventArgs e)
        {
            Filter();
        }
    }
}
