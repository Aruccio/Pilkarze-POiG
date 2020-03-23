using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab1
{
    class Operating
    {
        MainWindow mw;
        List<Pilkarz> pilkarze;
        public Operating(MainWindow mw)
        {
            this.mw = mw;
            pilkarze = new List<Pilkarz>();
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

    }
}
