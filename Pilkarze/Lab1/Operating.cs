using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Lab1
{
    class Operating
    {
        MainWindow mw;
        List<Pilkarz> pilkarze;
        string path;
        public Operating(MainWindow mw, string path)
        {
            this.mw = mw;
            this.path = path;
            pilkarze = AllFromFile(path);

        }


        public void AddNew(string name, string surname, int age, int weight)
        {
            Pilkarz p = new Pilkarz(name, surname, age, weight);
            pilkarze.Add(p);
        }

        public void EditExisting(Pilkarz p,string name, string surname, string age, string weight)
        {
            p.Name = name;
            p.Surname = surname;
            p.Age = Convert.ToInt32(age);
            p.Weight = Convert.ToInt32(weight);
        }

        public List<Pilkarz> All
        {
            get { return pilkarze; }   // get method
            set { pilkarze = value; }
        }


        public void AllToFile(string file, List<Pilkarz> pilkarze)
        {
            using (StreamWriter sw = new StreamWriter(file))
            {
                foreach (var p in pilkarze)
                    sw.WriteLine(p.FileFormat());
                sw.Close();
            }
        }

        public List<Pilkarz> AllFromFile(string file)
        {
            List<Pilkarz> pilkarze = new List<Pilkarz>();

            if (File.Exists(file))
            {
                var sPilkarze = File.ReadAllLines(file);
                if (sPilkarze.Length > 0)
                {
                    pilkarze = new List<Pilkarz>();
                    int n = pilkarze.Count;
                    for (int i = 0; i < sPilkarze.Length; i++)
                        pilkarze.Add(CreateFromString(sPilkarze[i]));
                    return pilkarze;
                }

            }
            else
            {
                var myFile = File.Create(file);
                myFile.Close();
            }
                return pilkarze;
        }



        public Pilkarz CreateFromString(string st)
        {
            string name, surname;
            int age, weight;
            var pilk = st.Split(';');
            if (pilk.Length == 4)
            {
                surname = pilk[0];
                name = pilk[1];
                age = int.Parse(pilk[2]);
                weight = int.Parse(pilk[3]);

                return new Pilkarz(name, surname, age, weight);
            }
            throw new Exception("Błędny format danych z pliku");
        }

    }
}
