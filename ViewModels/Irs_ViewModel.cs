using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Globalization;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using WpfApp1.Models;

namespace WpfApp1.ViewModels
{
    class Irs_ViewModel
    {
        public int nominal { get; set; }
        public int duree { get; set; }//en année
        public double periode_echeance { get; set; }
        public double lbase{ get; set;}
        public Jambe jambe_fixe { get; set; }
        public Jambe jambe_variable { get; set; }
        public  int nb_composition { get; set;}
        public int tx_variable_recu { get; set; }

        public void Affichage()
        {
            Console.WriteLine("Affichage IRS");
            Console.WriteLine("nominal" + nominal);
            Console.WriteLine("duree"+duree);
            Console.WriteLine("periode compo"+periode_echeance);
            Console.WriteLine("nb_compo"+nb_composition);
            Console.WriteLine("base"+lbase);
        }

        public Irs_ViewModel(int nb_compo, int _nominal, int _duree, double _periode_echeance, double _lbase, Jambe _jf, Jambe _jv, int _tx_var)
        {
            this.nominal = _nominal;
            this.jambe_fixe = _jf;
            this.jambe_variable = _jv;
            this.duree = _duree;
            this.periode_echeance = _periode_echeance;
            this.nb_composition = nb_compo;
             this.lbase = _lbase;
            this.tx_variable_recu = _tx_var;//-1 ou 1
        }


        public double Price()
        {
            int nb_calcul = (int)duree * nb_composition;
            double[] taux_variable = jambe_variable.liste_taux;
            double d_factor = lbase/12;
            double cf_fixe = 0.0;
            ObservableCollection<double> taux_zc = new ObservableCollection<double>();
            ObservableCollection<taux_spot> list_taux = new ObservableCollection<taux_spot>();
            Console.WriteLine("l43 " + nb_calcul);
            foreach(double t in taux_variable)
            {
                taux_spot tw = new taux_spot(duree, t, nominal);
                Console.WriteLine(duree + " " + t + " " + nominal);
                taux_zc.Add(tw.Rendement_zc());
                Console.WriteLine("48 " + tw.Rendement_zc());
            }
            int j = 0;
            for(int i = 0; i < nb_calcul-1; i++)
            { 
                cf_fixe = cf_fixe + Math.Exp(-1*taux_zc[i] *d_factor);
                d_factor = d_factor + 12 / jambe_fixe.frequence;
                Console.WriteLine("55 " + cf_fixe);
                j = i;
            }
            cf_fixe = (jambe_fixe.liste_taux[0] / jambe_fixe.frequence) * nominal * cf_fixe;
            double b_fixe = cf_fixe + (nominal + jambe_fixe.liste_taux[0] * nominal / jambe_fixe.frequence) * Math.Exp(-1 * taux_zc[j + 1] * d_factor);
            double b_variable = (nominal + taux_variable[0] * nominal / jambe_variable.frequence) * Math.Exp(-taux_zc[0] * lbase / 12);
            Console.WriteLine(b_fixe);
            return tx_variable_recu*(b_variable-b_fixe);
        }
        

    }
}
