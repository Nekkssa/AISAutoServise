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
    /// Логика взаимодействия для ChooseEmployee.xaml
    /// </summary>
    public partial class ChooseEmployee : Window
    {
        List<string> listSort = new List<string>()
            {
                "По умолчанию",
                "По фамилии",
                "По имени",
                "По логину",
                "По должности"
            };
        public ChooseEmployee()
        {
            InitializeComponent();
            cb_sort.ItemsSource = listSort;
            cb_sort.SelectedIndex = 0;
            Filter();
        }
        private void Filter()
        {
            List<EF.Employee> listEmployee = new List<EF.Employee>();
            listEmployee = EF.AppData.Context.Employee.Where(i => i.IsDeleted == false).ToList();

            listEmployee = listEmployee.
                Where(i => i.SecondName.ToLower().Contains(tb_search.Text.ToLower())
                || i.FirstName.ToLower().Contains(tb_search.Text.ToLower())
                || i.Patronymic.ToLower().Contains(tb_search.Text.ToLower())
                || i.Login.ToLower().Contains(tb_search.Text.ToLower())
                || i.Phone.ToLower().Contains(tb_search.Text.ToLower())
                || i.FIO.ToLower().Contains(tb_search.Text.ToLower())).ToList();

            switch (cb_sort.SelectedIndex)
            {
                case 0:
                    listEmployee = listEmployee.OrderBy(i => i.ID).ToList();
                    break;
                case 1:
                    listEmployee = listEmployee.OrderBy(i => i.FirstName).ToList();
                    break;
                case 2:
                    listEmployee = listEmployee.OrderBy(i => i.SecondName).ToList();
                    break;
                case 3:
                    listEmployee = listEmployee.OrderBy(i => i.Login).ToList();
                    break;
                case 4:
                    listEmployee = listEmployee.OrderBy(i => i.IDRole).ToList();
                    break;
                default:
                    listEmployee = listEmployee.OrderBy(i => i.ID).ToList();
                    break;
            }

            lv_employee.ItemsSource = listEmployee;
        }
        private void btn_back_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
        private void tb_search_TextChanged(object sender, TextChangedEventArgs e)
        {
            Filter();
        }

        private void cb_sort_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Filter();
        }

        private void lv_employee_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            if (lv_employee.SelectedItem is EF.Employee)
            {
                var empl = lv_employee.SelectedItem as EF.Employee;
                GetEmployee = empl;
                this.Close();
            }


        }
    }
}
