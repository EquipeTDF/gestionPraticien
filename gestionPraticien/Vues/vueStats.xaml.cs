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
    /// Logique d'interaction pour vueStats.xaml
    /// </summary>
    public partial class vueStats : Window
    {
        private GstBDD gst;

        public GstBDD Gst { get => gst; set => gst = value; }


        public vueStats(GstBDD unGst)
        {
            Gst = unGst;
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            LbSpeDuPraticien.ItemsSource = gst.GetLesSpeTotal();
            LbPraticienAyantLePlusDeSpe.ItemsSource = gst.GetPraticienAvecLePlusDeSpe();
            LbPraticienAyantLeMoinsDeSpe.ItemsSource = gst.GetPraticienAvecLeMoinsDeSpe();
            LbPraticienAyantJamaisParticiperAUneActivite.ItemsSource = gst.GetPraticienAyantJamaisParticiperAUneActivite();
            txtCoefSuperieur.Text = " " + gst.GetCoefNotorieteSup().ToString();
            txtCoefInferieur.Text = " " + gst.GetCoefNotorieteInf().ToString();

        }
    }
}
