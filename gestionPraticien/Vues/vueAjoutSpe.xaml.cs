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
            Gst = unGst;
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            lbDesSpe.ItemsSource = Gst.GetLesSpecialite();
        }

        private void btnModifier_Click(object sender, RoutedEventArgs e)
        {
            if (lbDesSpe.SelectedItem == null)
            {
                MessageBox.Show("Veuillez sélectionner une spécialité ", "Erreur de sélection", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            else if(txtModifSpe.Text == "")
            {
                MessageBox.Show("Veuillez entrer un nom ", "Erreur de nom", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            else
            {
                gst.UpdateSpe((lbDesSpe.SelectedItem as Specialite).IdSpe , txtModifSpe.Text);
                lbDesSpe.ItemsSource = Gst.GetLesSpecialite();

            }
        }
        
        private void btnAjouter_Click(object sender, RoutedEventArgs e)
        {
            if (txtNomSpe.Text == "")
            {
                MessageBox.Show("Veuillez entrer un nom ", "Erreur de nom", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            else
            {
                gst.AjouterSpe(txtNomSpe.Text);
                lbDesSpe.ItemsSource = Gst.GetLesSpecialite();
            }
        }

        private void lbDesSpe_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {   
            if (lbDesSpe.SelectedItem != null)
            {
                txtModifSpe.Text = ((lbDesSpe.SelectedItem as Specialite).NomSpe).ToString();
            }
        }

        private void lbDesSpe_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }
    }
}
