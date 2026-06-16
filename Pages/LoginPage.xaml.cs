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
using WPFChitaiGorod.DataBase;
using WPFChitaiGorod.Pages.AdminPage;
using WPFChitaiGorod.Pages.ClientPage;

namespace WPFChitaiGorod.Pages
{
    /// <summary>
    /// Логика взаимодействия для LoginPage.xaml
    /// </summary>
    public partial class LoginPage : Page
    {
        public LoginPage()
        {
            InitializeComponent();
            DataBaseConnestion.bd = new DataBase.BdChitaiGorodEntities();
        }

        // Авторизация юзера. Работает через поиск первых подходящих значений введёных в текстбокс и пасворд бокс, значения ищутся из базы данных
        private void LoginClientButton(object sender, RoutedEventArgs e)
        {
            try
            {
                var user = DataBaseConnestion.bd.Users_.FirstOrDefault(X => X.Login == LoginTxt.Text && X.Password == PasswordTxt.Password);
                if(user == null)
                {
                    MessageBox.Show("Такого пользователя не существует", "Предупреждение", MessageBoxButton.OK, MessageBoxImage.Error);
                }
                else
                {
                    switch (user.IdRole)
                    {
                        case 1:
                            MessageBox.Show($"Добро пожаловать администратор {user.FirstName} {user.LastName}", "Сообщение", MessageBoxButton.OK, MessageBoxImage.Information);
                            NavigationService.Navigate(new MainPageAdmin());
                            break;
                        case 2:
                            MessageBox.Show($"Добро пожаловать менеджер {user.FirstName} {user.LastName}", "Сообщение", MessageBoxButton.OK, MessageBoxImage.Information);
                            break;
                        case 3:
                            MessageBox.Show($"Добро пожаловать клиент {user.FirstName} {user.LastName}", "Сообщение", MessageBoxButton.OK, MessageBoxImage.Information);
                            NavigationService.Navigate(new TovarClientPage());
                            break;
                    }
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show($"Ошибка авторизации {ex.Message}", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void LoginGostButton(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new TovarClientPage());
        }
    }
}
