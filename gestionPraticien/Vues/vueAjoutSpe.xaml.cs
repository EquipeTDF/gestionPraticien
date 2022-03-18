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
    /// Logique d'interaction pour vueAjoutSpe.xaml
    /// </summary>
    public partial class vueAjoutSpe : Window
    {
        private GstBDD gst;
        public GstBDD Gst { get => gst; set => gst = value; }

        public vueAjoutSpe(GstBDD unGst)
        {
            //On récupère le gst passé en paramètre
            Gst = unGst;
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            // Alimentation de la liste des spécialités
            lbDesSpe.ItemsSource = Gst.GetLesSpecialite();
        }

        private void btnModifier_Click(object sender, RoutedEventArgs e)
        {
            //On vérifie si l'utilisateur à cliquer sur une spécialité dans la liste
            if (lbDesSpe.SelectedItem == null)
            {
                MessageBox.Show("Veuillez sélectionner une spécialité ", "Erreur de sélection", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            // On vérifie si l'utilisateur à mis un nom à la spécialité qu'il veut modifier
            else if(txtModifSpe.Text == "")
            {
                MessageBox.Show("Veuillez entrer un nom ", "Erreur de nom", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            else
            {
                //On met à jour la spécialité sélectionnée
                gst.UpdateSpe((lbDesSpe.SelectedItem as Specialite).IdSpe , txtModifSpe.Text);
                //On alimente la liste des spécialités suite à la modification
                lbDesSpe.ItemsSource = Gst.GetLesSpecialite();

            }
        }
        
        private void btnAjouter_Click(object sender, RoutedEventArgs e)
        {
            //On vérifie si l'utilisateur à rentrer un nom à la spécialité qu'il veut ajouter
            if (txtNomSpe.Text == "")
            {
                MessageBox.Show("Veuillez entrer un nom ", "Erreur de nom", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            else
            {
                //On ajoute la spécialité
                gst.AjouterSpe(txtNomSpe.Text);
                // On alimente la liste des spécialités suite à l'ajout
                lbDesSpe.ItemsSource = Gst.GetLesSpecialite();
            }
        }

        private void lbDesSpe_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            //On vérifie si l'utilisateur à cliquer sur une spécialité dans la liste
            if (lbDesSpe.SelectedItem != null)
            {
                //On met à jour le texte du nom de la spécialité selectionnée
                txtModifSpe.Text = ((lbDesSpe.SelectedItem as Specialite).NomSpe).ToString();
            }
        }
    }
}
