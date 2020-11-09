using OxyPlot;
using OxyPlot.Axes;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
using WpfApp1.Models;
using WpfApp1.ViewModels;
using System.Text.RegularExpressions;
using WpfApp1.Views;

namespace WpfApp1.Views
{
    /// <summary>
    /// Logique d'interaction pour MainView.xaml
    /// </summary>
    public partial class MainView : UserControl
    {
        ObservableCollection<int> list_index_use { get; set; }
        ObservableCollection<string> names{ get; set; }
        Curve_ViewModel curveViewModel { get; set; }
        taux_viewModel _tvM { get; set; }
        public int pmt1 { get; set; }
        public double tx1 { get; set; }
        public int nominal1 { get; set; }
        public PlotModel pm1 { get; set; }

        public MainView()
        {
            InitializeComponent();
            Curve_ViewModel cv = new Curve_ViewModel();
            this.list_index_use = new ObservableCollection<int>();
            names = cv.GetNames();
            curveViewModel = cv;
            
            ComboBox1.ItemsSource = names;           
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            int i = ComboBox1.SelectedIndex; 
            list_index_use.Add(i);
            String str = "";
            foreach(int j in list_index_use)
            {
                str += names[j] + "\n";
            }
            MessageBox.Show(str);
            this.pm1 = donnee_affichage();

        }

        private PlotModel donnee_affichage()
        {
            PlotModel PM = new PlotModel() { Title = $"Courbes de Taux" };
            var times = curveViewModel.GetDates();
            foreach(var index in list_index_use)
            {
                Console.WriteLine("index : " + index);
                var serie = curveViewModel.GetSeries(index);
                var line = new OxyPlot.Series.LineSeries() { Title = names[index] };
                var line1 = new OxyPlot.Series.LineSeries() { Title = names[index] + " ZC" };
                int index_val = 0;
                capture_parametre();
                foreach (var val in serie)
                {
                    var dateTime = DateTime.Parse(times[index_val]);
                    int result = dateTime.Year * 10000 + dateTime.Month * 100 + dateTime.Day + dateTime.Hour + dateTime.Minute + dateTime.Second;
                    line.Points.Add(new OxyPlot.DataPoint(result, val));
                    
                    taux_viewModel tv = new taux_viewModel(0, this.pmt1, val, this.nominal1);
                    double tx = tv.GetZC();
                    line1.Points.Add(new OxyPlot.DataPoint(result, tx));
                    index_val++;
                }
                PM.Series.Add(line);  
                PM.Series.Add(line1);
            }
            return PM;
        }

        private void btn_affichage(object sender, RoutedEventArgs e)
        {
            
            //PlotModel pm = donnee_affichage();
            GraphWindowView gw = new GraphWindowView(this.pm1);
            gw.Show();
            //MessageBox.Show("Simulation");

        }

        private void btn_reset(object sender, RoutedEventArgs e)
        {
            list_index_use = new ObservableCollection<int>();
        }
        private void capture_parametre()
        {

            if (true)
            {
                try
                {
                    this.nominal1 = Int32.Parse(bx_nominal.Text);
                }
                catch (FormatException r)
                {
                    Console.WriteLine(r.Message);
                    MessageBox.Show(r.Message + " Nominal incorrecte");
                }
            }
            //entree periode attente
            if (bx_pmt.Text == "")
            {
                try
                {
                    this.pmt1 = Int32.Parse(bx_pmt1.Text);
                    
                }
                catch (FormatException r)
                {
                    Console.WriteLine(r.Message);
                    MessageBox.Show(r.Message + " periode placement incorrecte spot");
                }
            }
            else
            {
                try
                {
                    this.pmt1 = Int32.Parse(bx_pmt.Text);
                    
                }
                catch (FormatException r)
                {
                    Console.WriteLine(r.Message);
                    MessageBox.Show(r.Message + " periode placement incorrecte forward");
                }
            }
        }
        private void btn_calcul(object sender, RoutedEventArgs e)
        {
            int att=0;
            int pmt=0;
            int nominal = 0;
            double tx=0;
            //entree nominal
            if (true)
            {
                try
                {
                    nominal = Int32.Parse(bx_nominal.Text);
                    this.nominal1 = nominal;
                }
                catch (FormatException r)
                {
                    Console.WriteLine(r.Message);
                    MessageBox.Show(r.Message + " Nominal incorrecte");
                }
            }
            //entree periode attente
            if (bx_pmt.Text == "")
            {
                try
                {
                    pmt = Int32.Parse(bx_pmt1.Text);
                    this.pmt1 = pmt;
                }
                catch (FormatException r)
                {
                    Console.WriteLine(r.Message);
                    MessageBox.Show(r.Message + " periode placement incorrecte spot");
                }
            }
            else
            {
                try
                {
                    pmt = Int32.Parse(bx_pmt.Text);
                    this.pmt1 = pmt;
                }
                catch (FormatException r)
                {
                    Console.WriteLine(r.Message);
                    MessageBox.Show(r.Message + " periode placement incorrecte forward");
                }
            }

            //entree taux 
            if (bx_taux.Text == "")
            {
                try
                {
                    tx = Convert.ToDouble(bx_taux1.Text);
                    this.tx1 = tx1;
                }
                catch (FormatException r)
                {
                    Console.WriteLine(r.Message);
                    MessageBox.Show(r.Message + " taux incorrecte spot");
                }
            }
            else
            {
                try
                {
                    tx = Convert.ToDouble(bx_taux.Text);
                    this.tx1 = tx1;
                }
                catch (FormatException r)
                {
                    Console.WriteLine(r.Message);
                    this.tx1 = tx1;
                    MessageBox.Show(r.Message + " taux incorrecte forward");
                }
            }

            //entree periode placemnt
            if (bx_att.Text != "")
            {
                try
                {
                    att = Int32.Parse(bx_att.Text);
                    this._tvM = new taux_viewModel(att, pmt, tx, nominal);
                }
                catch (FormatException r)
                {
                    Console.WriteLine(r.Message);
                    MessageBox.Show(r.Message + " periode debut incorrecte");
                }
            }
            else
            {
                this._tvM = new taux_viewModel(att, pmt, tx, nominal);
            }

            bx_ZC.Text = _tvM.GetZC().ToString();
            MessageBox.Show("Le taux est de : " + _tvM.GetZC());
        }

        private void btn_resettaux(object sender, RoutedEventArgs e)
        {
            bx_taux.Text = "";
            bx_taux1.Text = "";
            bx_pmt1.Text = "";
            bx_pmt.Text = "";
            bx_att.Text = "";
            bx_ZC.Text = "";
            bx_nominal.Text = "";
        }

        private void Btn_IRSpricer(object sender, RoutedEventArgs e)
        {
            IrsView irsv = new IrsView();
            irsv.Show();
        }
    }
}
