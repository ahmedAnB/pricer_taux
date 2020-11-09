using OxyPlot;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using WpfApp1.ViewModels;

namespace WpfApp1.Views
{
    /// <summary>
    /// Logique d'interaction pour GraphWindowView.xaml
    /// </summary>
    public partial class GraphWindowView : Window
    {
        public GraphWindowView(PlotModel pm)
        {
            InitializeComponent();
            this.DataContext = new Graph_viewModel(pm);
        }
    }
}
