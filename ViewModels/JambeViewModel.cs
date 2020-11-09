using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WpfApp1.Models;

namespace WpfApp1.ViewModels
{
    class JambeViewModel
    {
        public Jambe jambe { get; set; }

        public JambeViewModel(double[] ltaux, int _frequence)
        {
            this.jambe = new Jambe(ltaux, _frequence);
        }

    }
}
