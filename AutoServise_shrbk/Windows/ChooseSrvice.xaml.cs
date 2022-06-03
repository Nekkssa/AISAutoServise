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
    /// Логика взаимодействия для ChooseSrvice.xaml
    /// </summary>
    public partial class ChooseSrvice : Window
    {
        public ChooseSrvice()
        {
            InitializeComponent();
            Filter();
        }
        private void Filter()
        {
            List<EF.Service> listService = new List<EF.Service>();
            listService = EF.AppData.Context.Service.Where(i => i.IsDeleted == false).ToList();

            listService = listService.
                Where(i => i.Title.ToLower().Contains(tb_search.Text.ToLower())
                || i.Cost.ToString().Contains(tb_search.Text.ToLower())).ToList();

            lv_service.ItemsSource = listService;
        }

        private void lv_service_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            if (lv_service.SelectedItem is EF.Service)
            {
                var srv = lv_service.SelectedItem as EF.Service;
                GetService = srv;
                this.Close();
            }
        }

        private void btn_back_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void tb_search_TextChanged(object sender, TextChangedEventArgs e)
        {
            Filter();
        }
    }
}
