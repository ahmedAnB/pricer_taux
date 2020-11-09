using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfApp1.Models
{
    class CurveModel
    {
        public string curve_name { get; set; }
        
        public CurveModel(string Cname)
        {
            this.curve_name = Cname;
        }
    }   
}
