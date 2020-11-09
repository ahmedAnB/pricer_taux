using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfApp1.Models
{
    class YieldCurve
    {
        public String name { get; set; }
        public List<double> values { get; set; }
        public YieldCurve(string n, List<double> v)
        {
            name = n;
            values = v;
        }
    }
}
