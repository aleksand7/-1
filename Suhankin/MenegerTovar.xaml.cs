using Suhankin.AppConnectBD;
using System;
using System.Collections.Generic;
using System.ComponentModel;
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
    /// Логика взаимодействия для MenegerTovar.xaml
    /// </summary>
    public partial class MenegerTovar : Page
    {
        public MenegerTovar()
        {
            InitializeComponent();
            Tovar.ItemsSource = AppConnect.bd.Tovar.ToList();
        }

        private void SortUbiv(object sender, RoutedEventArgs e)
        {
            Tovar.Items.SortDescriptions.Clear();
            Tovar.Items.SortDescriptions.Add(new SortDescription("KolVoNaSclade", ListSortDirection.Descending));

        }

        private void SortVozrast(object sender, RoutedEventArgs e)
        {
            Tovar.Items.SortDescriptions.Clear();
            Tovar.Items.SortDescriptions.Add(new SortDescription("KolvoNaSclade", ListSortDirection.Ascending));
        }

        private void Delete(object sender, RoutedEventArgs e)
        {
            Tovar selectTovar = (Tovar)Tovar.SelectedItem;
            bool hasRelatedChecks = AppConnect.bd.Check.Any(c => c.Tovar.IdTovar == selectTovar.IdTovar);
            if (hasRelatedChecks)
            {
                MessageBox.Show(
                    $"Невозможно удалить товар '{selectTovar.IdTovar}', так как он используется в чеках!\n\n" +
                    "Товар не будет удален.",
                    "Удаление невозможно",
                    MessageBoxButton.OK,
                    MessageBoxImage.Warning);
                return;
            }
            try
            {
                AppConnect.bd.Tovar.Remove(selectTovar);
                AppConnect.bd.SaveChanges();
                Tovar.ItemsSource = AppConnect.bd.Tovar.ToList();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка: {ex.InnerException?.Message ?? ex.Message}",
                      "Ошибка",
                      MessageBoxButton.OK,
                      MessageBoxImage.Error);
            }
        }

        private void Redacktirovanie(object sender, RoutedEventArgs e)
        {
            var selectTovar = Tovar.SelectedItem as Tovar;
            if (selectTovar == null)
            {
                MessageBox.Show("Выберите товар для редактирования!");
                return;
            }
            NavigationService.Navigate(new RedactatirovanieTovara(selectTovar));
        }

        private void Dobavlenie(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Dobavlenie());

        }

        private void Nazad(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Page1());
        }

        private void Zakaz(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Zakaz());
        }
    }
}
