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
        public vueAjoutSpePraticien()
        {
            InitializeComponent();
        }
        GstBDD gst;


        private void lbPraticiens_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void btnAjout_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            gst = new GstBDD();
            lbPraticiens.ItemsSource = gst.GetLesPraticiens();
        }
    }
}
