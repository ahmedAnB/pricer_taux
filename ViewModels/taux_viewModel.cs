using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WpfApp1.Models;

namespace WpfApp1.ViewModels
{
    class taux_viewModel
    {
        public taux tx { get; set; }
        public taux_viewModel(int periode_debut, int periode_placemnt, double rendement, int _nominal)
        {
            //Console.WriteLine("nominal vm : " + _nominal);
            if (periode_debut == 0)
            {
                this.tx = new taux_spot(periode_placemnt, rendement, _nominal);
            }
            else
            {
                this.tx = new taux_forward(periode_placemnt, periode_debut, rendement, _nominal);
            }
            
        }

        public double GetZC()
        {
            return(tx.Rendement_zc());

        }

    }
}
