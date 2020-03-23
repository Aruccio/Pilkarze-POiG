using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab1
{
    class Pilkarz
    {
        int age;
        int weight;
        string name;
        string surname;

        public Pilkarz(string name, string surname, int age, int weight)
        {
            this.name = name;
            this.surname= surname;
            this.age = age;
            this.weight = weight;
        }


        public string Name
        {
            get { return name; }  
            set { name = value; }
        }

        public string Surname
        {
            get { return surname; } 
            set { surname = value; }
        }

        public int Age
        {
            get { return age; }
            set { age = value; } 
        }
        public int Weight
        {
            get { return weight; }
            set { weight = value; }
        }

    }
}
