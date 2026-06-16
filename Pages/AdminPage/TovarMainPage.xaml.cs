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
using WPFChitaiGorod.DataBase;
using WPFChitaiGorod.Scripts;
using System.Data.Entity;
using System.ComponentModel;

namespace WPFChitaiGorod.Pages.AdminPage
{
    /// <summary>
    /// Логика взаимодействия для TovarMainPage.xaml
    /// </summary>
    public partial class TovarMainPage : Page
    {
        public TovarMainPage()
        {
            InitializeComponent();
            TovarTableItems.ItemsSource = DataBaseConnestion.bd.Tovar_
                .Include(t => t.KategoriyTovata_)
                .ToList();
        }

        private void BackButton(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new MainPageAdmin());
        }

        private void RedTovarButton(object sender, RoutedEventArgs e)
        {
            var selectItem = TovarTableItems.SelectedItem as Tovar_;
            if (selectItem == null)
            {
                MessageBox.Show("Выберите товар для редактирования!");
                return;
            }
            NavigationService.Navigate(new RedTovarPage(selectItem));
        }

        private void DeletTovarButton(object sender, RoutedEventArgs e)
        {
            if(MessageBox.Show("Вы действительно хотите удалить товар", "Уведомление", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
            {
                var currentTovar = TovarTableItems.SelectedItem as Tovar_;
                var itemToDelet = DataBaseConnestion.bd.Tovar_.FirstOrDefault(t => t.Id == currentTovar.Id);

                if(itemToDelet != null)
                {
                    DataBaseConnestion.bd.Tovar_.Remove(itemToDelet);
                    DataBaseConnestion.bd.SaveChanges();
                }
                TovarTableItems.ItemsSource = DataBaseConnestion.bd.Tovar_.ToList();
                MessageBox.Show("Удалено");
            }
        }

        private void AddTovarPageButton(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new AddTovarPage());
        }

        private void SortUbivButton(object sender, RoutedEventArgs e)
        {
            TovarTableItems.Items.SortDescriptions.Clear();
            TovarTableItems.Items.SortDescriptions.Add(new SortDescription("FolVoNaSclade", ListSortDirection.Descending));
        }

        private void SortVozrastButton(object sender, RoutedEventArgs e)
        {
            TovarTableItems.Items.SortDescriptions.Clear();
            TovarTableItems.Items.SortDescriptions.Add(new SortDescription("FolVoNaSclade", ListSortDirection.Ascending));
        }
    }
}
