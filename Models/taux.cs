using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfApp1.Models
{
    abstract class taux
    {
        public int periode_placement { get; set; }
        public double rendement { get; set; }
        public int nominal { get; set; }

        public taux(int per, double rendement, int _nominal)
        {
            this.periode_placement = per; 
            this.rendement = rendement;
            this.nominal = _nominal;
        }
        /*
         * Methode pour le calcul du taux ZC correspondant
         */
        public abstract double Rendement_zc();

    }
}
