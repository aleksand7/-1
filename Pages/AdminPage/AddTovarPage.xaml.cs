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
    /// Логика взаимодействия для AddTovarPage.xaml
    /// </summary>
    public partial class AddTovarPage : Page
    {
        public AddTovarPage()
        {
            InitializeComponent();
            KatCombo.ItemsSource = DataBaseConnestion.bd.KategoriyTovata_.ToList();
            KatCombo.DisplayMemberPath = "NameKategoriy";
            KatCombo.SelectedValuePath = "IdKategoriy";
        }

        private void BackPageButton(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new TovarMainPage());
        }

        private void AddTovarButton(object sender, RoutedEventArgs e)
        {
            try
            {
                DataBase.Tovar_ tovar = new DataBase.Tovar_
                {
                    Articul = ArtTxt.Text,
                    NameTovar = NameTxt.Text,
                    EdIzmereniy = EdTxt.Text,
                    Cena = float.Parse(CenaTxt.Text),
                    Postavshik = PostavshicTxt.Text,
                    Proizvoditel = ProizvodTxt.Text,
                    IdKatgoriaTovara = (int) KatCombo.SelectedValue,
                    DeistvSkidka = int.Parse(SkidkaTxt.Text),
                    FolVoNaSclade = int.Parse(KolVoTxt.Text),
                    DescriptionTovar = DescTxt.Text,
                    PhotoPath = PhotoTxt.Text
                };
                DataBaseConnestion.bd.Tovar_.Add(tovar);
                DataBaseConnestion.bd.SaveChanges();

                ArtTxt.Clear();
                NameTxt.Clear();
                EdTxt.Clear();
                CenaTxt.Clear();
                PostavshicTxt.Clear();
                ProizvodTxt.Clear();
                SkidkaTxt.Clear();
                KolVoTxt.Clear();
                DescTxt.Clear();
                PhotoTxt.Clear();
                MessageBox.Show($"Товар успешно добавлен", "Уведомление", MessageBoxButton.OK, MessageBoxImage.Information);
            }
            catch(Exception ex)
            {
                MessageBox.Show($"Ошибка добавления {ex.Message}", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
    }
}
