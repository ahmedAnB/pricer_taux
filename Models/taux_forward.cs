using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfApp1.Models
{
    class taux_forward : taux
    {
        public int periode_debut { get; set; }

        public taux_forward(int periode_placement, int _periode_debut, double rendement, int no) : base(periode_placement, rendement, no)
        {
            this.periode_debut = _periode_debut;
        }

        public override double Rendement_zc()
        {
            double somme = 0;
            double n = periode_placement+periode_debut;
            if (n < 1) {
                n = 1.0; }
                
            double N = this.nominal;
            double Cn = N * rendement;

            for (int i = 1; i < n-1; i++)
            {
                somme += Math.Pow(1 + rendement, -i);
            }

            double root = 1 / n;
            double res = (N + Cn) / (N - Cn * somme);
            double t_zc = Math.Pow(res, root) - 1;
            return t_zc;
        }
    }
}
