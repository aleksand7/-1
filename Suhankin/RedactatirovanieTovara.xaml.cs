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
    /// Логика взаимодействия для RedactatirovanieTovara.xaml
    /// </summary>
    public partial class RedactatirovanieTovara : Page
    {
        private Tovar Tovar;
        public RedactatirovanieTovara(Tovar tovar)
        {
            InitializeComponent();
            Tovar = tovar;

            // Заполняем TextBox'ы данными из объекта
            ArtTovarTxt.Text = Tovar.Articul;
            NameTovarTxt.Text = Tovar.NameTovara;
            EdIzmTovarTxt.Text = Tovar.EdIzmerenia;
            PriceTovarTxt.Text = Tovar.Cena.ToString();
            PostavcikTovarTxt.Text = Tovar.Postavshik;
            ProizvoditelTovarTxt.Text = Tovar.Proizvoditel;
            SkidkaTovarTxt.Text = Tovar.DeistvSkidka.ToString();
            KolVoTovarTxt.Text = Tovar.KolvoNaSclade.ToString();
            FotoTovarTxt.Text = Tovar.Photo;

        }

       

        private void BackButton(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Page1());
        }

        private void SaveTovarButton(object sender, RoutedEventArgs e)
        {
            try
            {
                // Обновляем объект данными из полей
                Tovar.Articul = ArtTovarTxt.Text;
                Tovar.NameTovara = NameTovarTxt.Text;
                Tovar.Cena = float.Parse(PriceTovarTxt.Text);
                Tovar.Postavshik = PostavcikTovarTxt.Text;
                Tovar.Proizvoditel = ProizvoditelTovarTxt.Text;
                Tovar.KategoriaTovara = KategoryCombo.Text;
                Tovar.DeistvSkidka = int.Parse(SkidkaTovarTxt.Text);
                Tovar.KolvoNaSclade = KolVoTovarTxt.Text;
                Tovar.Photo = FotoTovarTxt.Text;
                // ... остальные поля


                MessageBox.Show("Данные обновлены!", "Успех", MessageBoxButton.OK, MessageBoxImage.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка при сохранении: {ex.Message}");
            }
        }
    }
    }

