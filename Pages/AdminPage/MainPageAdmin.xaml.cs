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

namespace WPFChitaiGorod.Pages.AdminPage
{
    /// <summary>
    /// Логика взаимодействия для MainPageAdmin.xaml
    /// </summary>
    public partial class MainPageAdmin : Page
    {
        public MainPageAdmin()
        {
            InitializeComponent();
        }

        private void TovarPageButton(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new TovarMainPage());
        }

        private void ZakazPageButton(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new ZakazMainPage());
        }
    }
}
