using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Windows;
using WpfApp1.ViewModels;

namespace WpfApp1.Views
{
    /// <summary>
    /// Logique d'interaction pour IrsView.xaml
    /// </summary>
    public partial class IrsView : Window
    {
        public IrsView()
        {
            InitializeComponent();
            ObservableCollection<String> so = new ObservableCollection<String>();
            so.Add("Oui");
            so.Add("Non");
            ComboBox1.ItemsSource = so;
            ObservableCollection<String> so1 = new ObservableCollection<String>();
            so1.Add("Euribor 6 mois");
            cbx_variable.ItemsSource = so1;
            


        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Appuye");
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            int freqV = 0;
            try
            {
                freqV = Int32.Parse(bx_freqV.Text);
            }
            catch (FormatException r)
            {
                Console.WriteLine(r.Message);
                MessageBox.Show(r.Message + " frequence variable");
            }
            int lbase = 0;
            try
            {
                lbase = Int32.Parse(bx_base.Text);
            }
            catch (FormatException r)
            {
                Console.WriteLine(r.Message);
                MessageBox.Show(r.Message + " Base");
            }
            int freqF = 0;
            try
            {
                freqF = Int32.Parse(bx_freqF.Text);
            }
            catch (FormatException r)
            {
                Console.WriteLine(r.Message);
                MessageBox.Show(r.Message + " frequence fixe");
            }
            Double tauxF = 0.0;
            try
            {
                tauxF = Convert.ToDouble(bx_tauxF.Text);
            }
            catch (FormatException r)
            {
                Console.WriteLine(r.Message);
                MessageBox.Show(r.Message + " taux fixe");
            }
            int echeance = 0;
            try
            {
                echeance = Int32.Parse(bx_echance.Text);
            }
            catch (FormatException r)
            {
                Console.WriteLine(r.Message);
                MessageBox.Show(r.Message + " écheance");
            }
            int duree = 0;
            try
            {
                duree = Int32.Parse(bx_duree.Text);
            }
            catch (FormatException r)
            {
                Console.WriteLine(r.Message);
                MessageBox.Show(r.Message + " Durée");
            }
            int nominal = 0;
            try
            {
                nominal = Int32.Parse(bx_nominal.Text);
            }
            catch (FormatException r)
            {
                Console.WriteLine(r.Message);
                MessageBox.Show(r.Message + " nominale");
            }

            double[] ltaux_var = new double[] { 10, 10.2, 10.4, 10.6, 11, 10.2, 10.4, 10.6, 11, 10.2, 10.4, 10.6, 11 };
            
            JambeViewModel jfVM = new JambeViewModel(new double[] { tauxF }, freqF);
            JambeViewModel jvVM = new JambeViewModel(ltaux_var, freqF);
            int taux_vx = 0;
            if(cbx_variable.Text == "Oui")
            {
                taux_vx = 1;
            }
            else
            {
                taux_vx = -1;
            }
            int nb_compo = 1;
            Irs_ViewModel irs_ = new Irs_ViewModel(nb_compo, nominal, duree, echeance, lbase, jfVM.jambe, jvVM.jambe, taux_vx);
            irs_.Affichage();
            bx_result.Text = irs_.Price().ToString();


        }
    }
}
