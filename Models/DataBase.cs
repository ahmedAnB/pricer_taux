using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfApp1.Models
{
    class DataBase
    {
        /*
         * Classe de Gestion de la base de donnée pour l'affichage des courbes
         */
        Dictionary<String, List<double>> baseDonnee = new Dictionary<string, List<double>>();
        
        public List<String> Dates { get; set; }
        public string[] ArrayNames { get; set; }
        public Dictionary<String, List<double>> GetBaseDonnee()
        {
            return baseDonnee;
        }

        public DataBase(String filePath)
        {
            StreamReader reader = new StreamReader(File.OpenRead(filePath));
            string line = reader.ReadLine();

            if (String.IsNullOrWhiteSpace(line))
            {
                throw new NullReferenceException();
            }
            string[] names = line.Split(';');

            ArrayNames = names.Skip(1).ToArray();
            this.Dates = new List<String>();

            foreach (String name in names)
            {
                if (!name.Equals("date"))
                {
                    baseDonnee.Add(name, new List<double>());
                }
            }

            while (!reader.EndOfStream)
            {
                string line1 = reader.ReadLine();
                if (!String.IsNullOrWhiteSpace(line))
                {
                    string[] values = line1.Split(';');
                    int index = 0;
                    double x = 0;
                    List<double> value_list = new List<double>();
                    foreach(string value in values)
                    {
                        baseDonnee.TryGetValue(names[index], out value_list);
                        if (index == 0)
                        {
                            Dates.Add(value);
                        }
                        else
                        { 
                            x = Convert.ToDouble(value);
                            value_list.Add(x);
                        }
                        index++;
                    }
                }
            }
            Console.WriteLine("Importation fini");
        }



    }
}
