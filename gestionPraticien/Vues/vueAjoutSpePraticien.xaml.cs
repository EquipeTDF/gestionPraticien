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
            lbPraticiens.ItemsSource = Gst.GetLesPraticiens();
        }

        private void lbPraticiens_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if(lbPraticiens.SelectedItem != null)
            {
                lstSpecialiteNonPosseder.ItemsSource = gst.GetSpecialitesNonPossedesDuPraticien((lbPraticiens.SelectedItem as Praticien).NumeroPraticien);
            }
        }

        private void btnAjout_Click(object sender, RoutedEventArgs e)
        {
            if(lbPraticiens.SelectedItem == null)
            {
                
            }
            else if (lstSpecialiteNonPosseder.SelectedItems == null)
            {

            }
            else
            {
                int estDiplome = 0;
                if ((bool)rbDiplome.IsChecked)
                {
                    estDiplome = 1;
                }

                gst.AjouterSpePraticien((lbPraticiens.SelectedItem as Praticien).NumeroPraticien, (lstSpecialiteNonPosseder.SelectedItems as Specialite).NumSpe, estDiplome, Convert.ToInt16(slSpe.Value));
            }
        }
    }
}
