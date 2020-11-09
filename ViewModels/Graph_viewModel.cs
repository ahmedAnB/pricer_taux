using OxyPlot;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfApp1.ViewModels
{
    class Graph_viewModel
    {
        public PlotModel Model { get; private set; }
        public Graph_viewModel(PlotModel pm)
        {
            this.Model = pm;
        }
    }
}
