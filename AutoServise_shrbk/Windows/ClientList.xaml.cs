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
    /// Логика взаимодействия для ClientList.xaml
    /// </summary>
    public partial class ClientList : Window
    {

        List<string> listSort = new List<string>()
            {
                "По умолчанию",
                "По фамилии",
                "По имени",
                "По дню рождения",
                "По почте"
            };
        public ClientList()
        {
            InitializeComponent();
            cb_sort.ItemsSource = listSort;
            cb_sort.SelectedIndex = 0;
            Filter();
        }
        private void Filter()
        {
            List<EF.Client> listClient = new List<EF.Client>();
            listClient = EF.AppData.Context.Client.Where(i => i.IsDeleted == false).ToList();

            listClient = listClient.
                Where(i => i.SecondName.ToLower().Contains(tb_search.Text.ToLower())
                || i.FirstName.ToLower().Contains(tb_search.Text.ToLower())
                || i.Patronymic.ToLower().Contains(tb_search.Text.ToLower())
                || i.Email.ToLower().Contains(tb_search.Text.ToLower())
                || i.Phone.ToLower().Contains(tb_search.Text.ToLower())
                || i.FIO.ToLower().Contains(tb_search.Text.ToLower())).ToList();

            switch (cb_sort.SelectedIndex)
            {
                case 0:
                    listClient = listClient.OrderBy(i => i.ID).ToList();
                    break;
                case 1:
                    listClient = listClient.OrderBy(i => i.SecondName).ToList();
                    break;
                case 2:
                    listClient = listClient.OrderBy(i => i.FirstName).ToList();
                    break;
                case 3:
                    listClient = listClient.OrderBy(i => i.Birthday).ToList();
                    break;
                case 4:
                    listClient = listClient.OrderBy(i => i.Email).ToList();
                    break;
                default:
                    listClient = listClient.OrderBy(i => i.ID).ToList();
                    break;
            }

            lv_client.ItemsSource = listClient;
        }
        private void tb_search_TextChanged(object sender, TextChangedEventArgs e)
        {
            Filter();
        }

        private void cb_sort_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Filter();
        }

        private void btn_back_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void btn_add_Click(object sender, RoutedEventArgs e)
        {
            AddEditClient addEditClient= new AddEditClient();
            this.Hide();
            addEditClient.ShowDialog();
            Filter();
            this.ShowDialog();
        }

        private void lv_employee_KeyDown(object sender, KeyEventArgs e)
        {
            if (lv_client.SelectedItem is EF.Client)
            {
                if (e.Key == Key.Delete || e.Key == Key.Back)
                {
                    var resClick = MessageBox.Show("Удалить клиента?", "Удаление", MessageBoxButton.YesNo, MessageBoxImage.Question);

                    if (resClick == MessageBoxResult.No)
                    {
                        return;
                    }
                    var clnt = lv_client.SelectedItem as EF.Client;

                    clnt.IsDeleted = true;

                    EF.AppData.Context.SaveChanges();

                    MessageBox.Show("Клиент успешно удален", "Готово", MessageBoxButton.OK, MessageBoxImage.Information);
                    Filter();
                }
            }            
        }

        private void lv_employee_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            if (lv_client.SelectedItem is EF.Client)
            {
                var clnt = lv_client.SelectedItem as EF.Client;
                AddEditClient addEditClient = new AddEditClient(clnt);
                this.Hide();
                addEditClient.ShowDialog();
                Filter();
                this.ShowDialog();
            }
        }
    }
}
