using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WpfApp1.Models;

namespace WpfApp1.ViewModels
{
    class Curve_ViewModel
    {
        ObservableCollection<CurveModel> list_curves= new ObservableCollection<CurveModel>();
        ObservableCollection<YieldCurve> list_yield = new ObservableCollection<YieldCurve>();
        Dictionary<int, CurveModel> dict_curves = new Dictionary<int, CurveModel>();
        ObservableCollection<String> names = new ObservableCollection<string>();
        DataBase dataBase = new DataBase(@"../../taux_spot_cut.csv");

        public Curve_ViewModel()
        {
            String[] arrayNames = dataBase.ArrayNames; ;
            int index = 0;
            List<double> value_list = new List<double>();
            Dictionary<String, List<double>> baseDonnee = dataBase.GetBaseDonnee();
            foreach (string name in arrayNames)
            {
                //chargement des données
                baseDonnee.TryGetValue(name, out value_list);
                list_yield.Add(new YieldCurve(name, value_list));
                names.Add(name);
                index++;
            }

        }

        public List<double> GetSeries(int key)
        {
            List<double> values = list_yield[key].values;
            foreach (var e in values)
            {
                Console.WriteLine(e.ToString());
            }
            return values;
        }

        public List<String> GetDates()
        {
            List<String> dates = dataBase.Dates;
            return dates;
        }

        public ObservableCollection<CurveModel> GetCurves()
        {
            return list_curves;
        }
        public ObservableCollection<String> GetNames()
        {
            return names;
        }
    }
}
