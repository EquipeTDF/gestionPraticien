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
using System.Windows.Shapes;
using GstBDDPraticien;
using GstClasses;

namespace gestionPraticien.Vues
{
    /// <summary>
    /// Logique d'interaction pour vueAjoutSpePraticien.xaml
    /// </summary>
    public partial class vueAjoutSpePraticien : Window
    {
        private GstBDD gst;

        public GstBDD Gst { get => gst; set => gst = value; }
        public vueAjoutSpePraticien(GstBDD unGst)
        {
            Gst = unGst;
            InitializeComponent();
            
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            //initialisation de la liste des praticiens
            lbPraticiens.ItemsSource = Gst.GetLesPraticiens();
        }

        private void lbPraticiens_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            //Affichage de ses spécialités lorsqu'un praticien est selectionné
            if(lbPraticiens.SelectedItem != null)
            {
                lstSpecialiteNonPosseder.ItemsSource = gst.GetSpecialitesNonPossedesDuPraticien((lbPraticiens.SelectedItem as Praticien).NumeroPraticien);
                lstSpecialitePossedees.ItemsSource = gst.GetSpecialitesDuPraticien((lbPraticiens.SelectedItem as Praticien).NumeroPraticien);
            }
        }

        private void btnAjout_Click(object sender, RoutedEventArgs e)
        {
            //Ajout des spécialités au praticien selectionné
            if(lbPraticiens.SelectedItem == null)
            {
                MessageBox.Show("Veuillez sélectionner un praticien ", "Erreur de sélection", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            else if (lstSpecialiteNonPosseder.SelectedItem == null)
            {
                MessageBox.Show("Veuillez sélectionner une spécialité ", "Erreur de sélection", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            else
            {
                int estDiplome = 0;
                if ((bool)cbDiplome.IsChecked)
                {
                    estDiplome = 1;
                }
                foreach (Specialite uneSpe in lstSpecialiteNonPosseder.SelectedItems)
                {
                    gst.AjouterSpePraticien((lbPraticiens.SelectedItem as Praticien).NumeroPraticien, uneSpe.IdSpe, estDiplome, Convert.ToInt16(slSpe.Value));
                }
                if (lbPraticiens.SelectedItem != null)
                {
                    lstSpecialiteNonPosseder.ItemsSource = gst.GetSpecialitesNonPossedesDuPraticien((lbPraticiens.SelectedItem as Praticien).NumeroPraticien);
                    lstSpecialitePossedees.ItemsSource = gst.GetSpecialitesDuPraticien((lbPraticiens.SelectedItem as Praticien).NumeroPraticien);
                }
            }
        }

        private void slSpe_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            //Changement de l'affichage de la valeur du slider
            txtSliderValeur.Text =  Convert.ToInt16(slSpe.Value).ToString();
        }

        private void btnRetirer_Click(object sender, RoutedEventArgs e)
        {
            //Retire les spécialités au praticien selectionné
            if (lbPraticiens.SelectedItem == null)
            {
                MessageBox.Show("Veuillez sélectionner un praticien", "Erreur de sélection", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            else if (lstSpecialitePossedees.SelectedItem == null)
            {
                MessageBox.Show("Veuillez sélectionner une spécialité possédée", "Erreur de sélection", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            else
            {
                foreach (Specialite uneSpe in lstSpecialitePossedees.SelectedItems)
                {
                    gst.SupprimerSpePraticien((lbPraticiens.SelectedItem as Praticien).NumeroPraticien, uneSpe.IdSpe);
                }
                if (lbPraticiens.SelectedItem != null)
                {
                    lstSpecialitePossedees.ItemsSource = gst.GetSpecialitesDuPraticien((lbPraticiens.SelectedItem as Praticien).NumeroPraticien);
                    lstSpecialiteNonPosseder.ItemsSource = gst.GetSpecialitesNonPossedesDuPraticien((lbPraticiens.SelectedItem as Praticien).NumeroPraticien);
                }
            }
        }
    }
}
