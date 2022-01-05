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
using gestionPraticien.Vues;
using GstBDDPraticien;
using GstClasses;

namespace gestionPraticien
{
    /// <summary>
    /// Logique d'interaction pour MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }
        GstBDD gst;
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            gst = new GstBDD();
            LstPraticiens.ItemsSource = gst.GetLesPraticiens();
        }

        private void Button_ClickModifInserSpePraticien(object sender, RoutedEventArgs e)
        {

        }

        private void Button_ClickInserPraticienToActivite(object sender, RoutedEventArgs e)
        {

        }

        private void Button_ClickCreModifSpe(object sender, RoutedEventArgs e)
        {
            vueAjoutSpe ajoutSpe = new vueAjoutSpe(gst);
            ajoutSpe.Show();
        }

        private void Button_ClickStatPraticien(object sender, RoutedEventArgs e)
        {
            vueStats pageStats = new vueStats(gst);
            pageStats.Show();
        }

        private void lstPraticiens_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            LstSpeDuPraticien.ItemsSource = gst.GetSpecialitesDuPraticien((LstPraticiens.SelectedItem as Praticien).NumeroPraticien);
            LstActiviteDuPraticien.ItemsSource = gst.GetActivitesDuPraticien((LstPraticiens.SelectedItem as Praticien).NumeroPraticien);
        }
    }
}
