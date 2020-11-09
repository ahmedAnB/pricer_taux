using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfApp1.Models
{
    class IrsModel
    {
        public int Nominal { get; set; }
        public DateTime Echeance { get; set; }
        public DateTime Date { get; set; }
        public int Base_irs { get; set; }
        public int Duree { get; set; }
        public Jambe JambeFixe { get; set; }
        public Jambe_Variable JameVariable { get; set; }

        public IrsModel(int n, DateTime e, DateTime d, int Birs, int dure, Jambe jF ,Jambe jV)
        {
            this.Nominal = n;
            this.Echeance = e;
            this.Date = d;
            this.Base_irs = Birs;
            this.Duree = dure;
            this.JambeFixe = jF;
            this.JameVariable = jV;
        }




    }
}
