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
    /// Логика взаимодействия для ServiceList.xaml
    /// </summary>
    public partial class ServiceList : Window
    {
        public ServiceList()
        {
            InitializeComponent();
            Filter();
        }

        private void btn_back_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
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
                AddEditService service = new AddEditService(srv);
                this.Hide();
                service.ShowDialog();
                Filter();
                this.ShowDialog();
            }
        }

        private void lv_service_KeyDown(object sender, KeyEventArgs e)
        {
            if (lv_service.SelectedItem is EF.Service)
            {
                if (e.Key == Key.Delete || e.Key == Key.Back)
                {
                    var resClick = MessageBox.Show("Удалить услугу?", "Удаление", MessageBoxButton.YesNo, MessageBoxImage.Question);

                    if (resClick == MessageBoxResult.No)
                    {
                        return;
                    }
                    var srv = lv_service.SelectedItem as EF.Service;

                    srv.IsDeleted = true;

                    EF.AppData.Context.SaveChanges();

                    MessageBox.Show("Услуга успешно удалена", "Готово", MessageBoxButton.OK, MessageBoxImage.Information);
                    Filter();
                }
            }
            Filter();
        }

        private void btn_add_Click(object sender, RoutedEventArgs e)
        {
            AddEditService service = new AddEditService();
            this.Hide();
            service.ShowDialog();
            Filter();
            this.ShowDialog();
            
        }

        private void tb_search_TextChanged(object sender, TextChangedEventArgs e)
        {
            Filter();
        }
    }
}
