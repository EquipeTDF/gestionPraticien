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
using LiveCharts;
using LiveCharts.Wpf;
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
            LbPraticienAyantJamaisParticiperAUneActivite.ItemsSource = gst.GetPraticienAyantJamaisParticiperAUneActivite();
            txtCoefSuperieur.Text = " " + gst.GetCoefNotorieteSup().ToString();
            txtCoefInferieur.Text = " " + gst.GetCoefNotorieteInf().ToString();

            //PieSeries ps = new PieSeries();
            //ChartValues<int> line = new ChartValues<int>();

            //List<String> lesNoms = new List<String>();

            foreach (GraphSpeParPraticien gp in gst.GetLeGrafNbSpeParPraticien())
            {
                PieSeries ps = new PieSeries();
                ChartValues<int> part = new ChartValues<int>();
                ps.Title = gp.NomPraticien;
                part.Add(gp.NombreSpe);
                ps.Values = part ;
                ps.DataLabels = true;
                GraphSpecialiteParPraticien.Series.Add(ps);
            }

            SetPraticienAvecLePlusDeSpeGraph();
            SetPraticienAvecLeMoinsDeSpeGraph();


        }

        public void SetPraticienAvecLePlusDeSpeGraph()
        {
            ColumnSeries cs = new ColumnSeries();
            cs.Fill = Brushes.Blue;
            ChartValues<double> line = new ChartValues<double>();

            List<string> lesNoms = new List<string>();

            foreach (Praticien praticien in gst.GetPraticienAvecLePlusDeSpe())
            {
                line.Add(praticien.NombreDeSpe);
                lesNoms.Add(praticien.NomPraticien);
            }
            cs.Values = line;

            Axis axe = new Axis();
            axe.Labels = lesNoms;

            graphPraticiensPlusDeSpe.AxisX.Add(axe);
            graphPraticiensPlusDeSpe.Series.Add(cs);
        }
        public void SetPraticienAvecLeMoinsDeSpeGraph()
        {
            RowSeries cs = new RowSeries();
            cs.Fill = Brushes.Blue;
            ChartValues<double> line = new ChartValues<double>();

            List<string> lesNoms = new List<string>();

            foreach (Praticien praticien in gst.GetPraticienAvecLeMoinsDeSpe())
            {
                line.Add(praticien.NombreDeSpe);
                lesNoms.Add(praticien.NomPraticien);
            }
            cs.Values = line;

            Axis axe = new Axis();
            axe.Labels = lesNoms;

            graphPraticiensMoinsDeSpe.AxisY.Add(axe);
            graphPraticiensMoinsDeSpe.Series.Add(cs);
        }
    }
}
