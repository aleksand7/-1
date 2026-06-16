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
    /// Логика взаимодействия для Dobavlenie.xaml
    /// </summary>
    public partial class Dobavlenie : Page
    {
        public Dobavlenie()
        {
            InitializeComponent();
        }

        

        private void BackButton(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Page1());
        }

        private void SaveTovarButton(object sender, RoutedEventArgs e)
        {
            try
            {
                AppConnectBD.Tovar tovar = new AppConnectBD.Tovar
                {
                    Articul = ArtTovarTxt.Text,
                    NameTovara = NameTovarTxt.Text,
                    EdIzmerenia = EdIzmTovarTxt.Text,
                    Cena = float.Parse(PriceTovarTxt.Text),
                    Postavshik = PostavcikTovarTxt.Text,
                    Proizvoditel = ProizvoditelTovarTxt.Text,
                    KategoriaTovara = KategoryCombo.Text,
                    DeistvSkidka = int.Parse(SkidkaTovarTxt.Text),
                    KolvoNaSclade = KolVoTovarTxt.Text,
                    OpisanieTovara = DescTovarTxt.Text,
                    Photo = FotoTovarTxt.Text
                };
                AppConnect.bd.Tovar.Add(tovar);
                AppConnect.bd.SaveChanges();

                ArtTovarTxt.Clear();
                NameTovarTxt.Clear();
                EdIzmTovarTxt.Clear();
                PriceTovarTxt.Clear();
                PostavcikTovarTxt.Clear();
                ProizvoditelTovarTxt.Clear();
                SkidkaTovarTxt.Clear();
                KolVoTovarTxt.Clear();
                DescTovarTxt.Clear();
                MessageBox.Show("Данные успешно добавлены!", "Уведомление", MessageBoxButton.OK, MessageBoxImage.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка при добавлениее данных! {ex.Message}", "Уведомление", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
    }
}

