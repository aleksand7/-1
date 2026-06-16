using Suhankin.AppConnectBD;
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

namespace Suhankin
{
    /// <summary>
    /// Логика взаимодействия для KlientTovar.xaml
    /// </summary>
    public partial class KlientTovar : Page
    {
        public KlientTovar()
        {
            InitializeComponent();
            Tovar.ItemsSource = AppConnect.bd.Tovar.ToList();
        }

       

        private void Button_Nazad(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Page1());
        }
    }
}
