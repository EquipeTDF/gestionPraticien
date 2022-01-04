﻿using System;
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
    /// Logique d'interaction pour vueAjoutPraticienAUneActivite.xaml
    /// </summary>
    public partial class vueAjoutPraticienAUneActivite : Window
    {
        private GstBDD gst;

        public GstBDD Gst { get => gst; set => gst = value; }
        public vueAjoutPraticienAUneActivite(GstBDD unGst)
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
            if (lbPraticiens.SelectedItem != null)
            {
                lstActivitesComplementaires.ItemsSource = gst.GetActivitesNonInvitesDuPraticien((lbPraticiens.SelectedItem as Praticien).NumeroPraticien);
            }
        }

        private void btnAjout_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
