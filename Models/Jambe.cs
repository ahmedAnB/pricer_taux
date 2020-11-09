using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfApp1.Models
{
    class Jambe
    {
        public double[] liste_taux { get; set; }
        public int frequence { get; set; }
        public double nb_composition_par_annee { get; set; }
        
        public Jambe(double[] ltaux, int lfrequence)
        {
            this.liste_taux = ltaux;
            this.frequence = lfrequence;
        }


        
    }
}
