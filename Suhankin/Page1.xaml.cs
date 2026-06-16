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
using Suhankin.AppConnectBD;



namespace Suhankin
{
    /// <summary>
    /// Логика взаимодействия для Page1.xaml
    /// </summary>
    public partial class Page1 : Page
    {
        public Page1()
        {
            InitializeComponent();
            AppConnect.bd = new DataBaseLesopedikEntities1();
            
        }
        
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            var user = AppConnect.bd.Users.FirstOrDefault(x => x.Login == txtLogin.Text && x.Password == psbPass.Text);
            if (user == null)
            {
                MessageBox.Show("Такого пользователя нет!", "Ошибка авторизации", MessageBoxButton.OK, MessageBoxImage.Error);
                NavigationService.Navigate(new PageTovar());
            }
            else
            {
                switch(user.IdRoleUser)
                {
                    case 1:
                        MessageBox.Show("Здравствуйте Администратор" + user.Ima + "!", "Уведомление", MessageBoxButton.OK, MessageBoxImage.Information);
                        NavigationService.Navigate(new PageTovar());
                        break;
                    case 2:
                        MessageBox.Show("Здравствуйте Менеджер" + user.Ima + "!", "Уведомление", MessageBoxButton.OK, MessageBoxImage.Information);
                        NavigationService.Navigate(new MenegerTovar());
                        break;
                    case 3:
                        MessageBox.Show("Здравствуйте Клиент" + user.Ima + "!", "Уведомление", MessageBoxButton.OK, MessageBoxImage.Information);
                        NavigationService.Navigate(new KlientTovar());
                        break;
                    default:
                        MessageBox.Show("Данные не обнаружены", "Уведомление", MessageBoxButton.OK, MessageBoxImage.Warning);
                        NavigationService.Navigate(new PageTovar());
                        break;
                }
               
            }

        }
    

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            NavigationService?.Navigate(new PageTovar());
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(null);
        }
    }
}
