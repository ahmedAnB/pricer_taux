using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media.Animation;

namespace WpfApp1.Models
{
    class taux_spot : taux
    {
        public taux_spot(int periode_placement, double rendement, int no): base(periode_placement, rendement, no)
        {}

        public override double Rendement_zc()
        {
            double somme = 0;
            double n = periode_placement;
            int N = base.nominal;
            double Cn = N * rendement;
            for (int i = 1; i < n-1; i++)
            {  
                somme += Math.Pow(1 + rendement, -i);
            }
            double root = 1 / n;
            double res = (N + Cn) / (N - (Cn * somme));
            Console.WriteLine(root + " " + res + " " + somme + " " + Cn + " " + N + " " + n + " ");
            double t_zc = Math.Pow(res, root) - 1;
            Console.WriteLine(t_zc + " "+ Math.Pow(res, root));
            return t_zc;
        }
    }
}
