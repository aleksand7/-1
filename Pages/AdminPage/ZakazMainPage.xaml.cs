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
using WPFChitaiGorod.Scripts;

namespace WPFChitaiGorod.Pages.AdminPage
{
    /// <summary>
    /// Логика взаимодействия для ZakazMainPage.xaml
    /// </summary>
    public partial class ZakazMainPage : Page
    {
        public ZakazMainPage()
        {
            InitializeComponent();
            TovarTableItems.ItemsSource = DataBaseConnestion.bd.Ckeck_.ToList();
        }

        private void AddZakazPageButton(object sender, RoutedEventArgs e)
        {

        }

        private void DeletZakazButton(object sender, RoutedEventArgs e)
        {

        }

        private void RedZakazButton(object sender, RoutedEventArgs e)
        {

        }

        private void BackButton(object sender, RoutedEventArgs e)
        {

        }
    }
}
