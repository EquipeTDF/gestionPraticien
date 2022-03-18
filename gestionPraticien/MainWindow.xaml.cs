using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Forms;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
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
            //Au chargement de la fenêtre affiche la liste des praticiens
            gst = new GstBDD();
            LstPraticiens.ItemsSource = gst.GetLesPraticiens();
        }


        private void Button_ClickModifInserSpePraticien(object sender, RoutedEventArgs e)
        {
            //Lorsqu'on clique sur le bouton affiche la page Insérer/Modifier une spé à un praticien
            vueAjoutSpePraticien myNewPage = new vueAjoutSpePraticien(gst);
            myNewPage.Show();
        }

        private void Button_ClickInserPraticienToActivite(object sender, RoutedEventArgs e)
        {
            //Lorsqu'on clique sur le bouton affiche la page Insérer une activité à un praticien
            vueAjoutPraticienAUneActivite ajoutActivite = new vueAjoutPraticienAUneActivite(gst);
            ajoutActivite.Show();
        }

        private void Button_ClickCreModifSpe(object sender, RoutedEventArgs e)
        {
            //Lorsqu'on clique sur le bouton affiche la page Ajouter/Modifier une spé à un praticien
            vueAjoutSpe ajoutSpe = new vueAjoutSpe(gst);
            ajoutSpe.Show();
        }

        private void Button_ClickStatPraticien(object sender, RoutedEventArgs e)
        {
            //Lorsqu'on clique sur le bouton affiche la page des statistiques
            vueStats vueStat = new vueStats(gst);
            vueStat.Show();
        }

        private void lstPraticiens_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            //Lorsqu'on sélectionne un praticien affiche ses spé et ses activités
            LstSpeDuPraticien.ItemsSource = gst.GetSpecialitesDuPraticien((LstPraticiens.SelectedItem as Praticien).NumeroPraticien);
            LstActiviteDuPraticien.ItemsSource = gst.GetActivitesDuPraticien((LstPraticiens.SelectedItem as Praticien).NumeroPraticien);
        }
    }
}
