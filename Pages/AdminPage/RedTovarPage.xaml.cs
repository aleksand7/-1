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

namespace WPFChitaiGorod.Pages.AdminPage
{
    /// <summary>
    /// Логика взаимодействия для RedTovarPage.xaml
    /// </summary>
    public partial class RedTovarPage : Page
    {
        public Tovar_ curTovar;

        public RedTovarPage(Tovar_ item)
        {
            InitializeComponent();

            KatCombo.ItemsSource = DataBaseConnestion.bd.KategoriyTovata_.ToList();
            KatCombo.DisplayMemberPath = "NameKategoriy";
            KatCombo.SelectedValuePath = "IdKategoriy";

            curTovar = item;

            ArtTxt.Text = curTovar.Articul;
            NameTxt.Text = curTovar.NameTovar;
            EdTxt.Text = curTovar.EdIzmereniy;
            CenaTxt.Text = curTovar.Cena.ToString();
            PostavshicTxt.Text = curTovar.Postavshik;
            ProizvodTxt.Text = curTovar.Proizvoditel;
            KatCombo.SelectedValue = curTovar.IdKatgoriaTovara;
            SkidkaTxt.Text = curTovar.DeistvSkidka.ToString();
            KolVoTxt.Text = curTovar.FolVoNaSclade.ToString();
            DescTxt.Text = curTovar.DescriptionTovar;
            PhotoTxt.Text = curTovar.PhotoPath;
        }

        private void RedTovarButton(object sender, RoutedEventArgs e)
        {
            try
            {
                curTovar.Articul = ArtTxt.Text;
                curTovar.NameTovar = NameTxt.Text;
                curTovar.EdIzmereniy = EdTxt.Text;
                curTovar.Cena = float.Parse(CenaTxt.Text);
                curTovar.Postavshik = PostavshicTxt.Text;
                curTovar.Proizvoditel = ProizvodTxt.Text;
                curTovar.IdKatgoriaTovara = (int)KatCombo.SelectedValue;
                curTovar.DeistvSkidka = int.Parse(SkidkaTxt.Text);
                curTovar.FolVoNaSclade = int.Parse(KolVoTxt.Text);
                curTovar.DescriptionTovar = DescTxt.Text;
                curTovar.PhotoPath = PhotoTxt.Text;

                DataBaseConnestion.bd.Entry(curTovar).State = EntityState.Modified;
                DataBaseConnestion.bd.SaveChanges();

                MessageBox.Show("Данные обновлены!", "Успех", MessageBoxButton.OK, MessageBoxImage.Information);
            }
            catch(Exception ex)
            {
                MessageBox.Show($"Ошибка при сохранении: {ex.Message}");
            }
        }

        private void BackPageButton(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new TovarMainPage());
        }
    }
}
