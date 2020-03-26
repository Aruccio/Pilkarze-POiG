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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Lab1
{
    /// <summary>
    /// Logika interakcji dla klasy MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        Operating Opera;
        Pilkarz ThisPerson;
        string path =  @"archiwum.txt";
        //partial oznacza że to tylko częśc implementacji klasy
        public MainWindow()
        {
            InitializeComponent();
            Opera = new Operating(this, path);
            UpdateList();
        }

        private void button_Click(object sender, RoutedEventArgs e)
        {
            //          if(sender is Button)
            //              var button = (Button)sender;
            // obiekt??drugi -> jeśli obiekt jest nullem, użyj drugiego
            // obiekt?. -> jesli obiekt nie jest nullem, wykonaj
            var button = sender as Button;
            switch(button.Name)
            {
                case "edit":
                    if (!AreEmpty(firstName, surname))
                    {
                    if (ThisPerson != null)
                       if(Opera.NotDoubled(Opera.All, new Pilkarz(firstName.Text,
                           surname.Text, Convert.ToInt32(age.Text), Convert.ToInt32(weight.Text))))

                                Opera.EditExisting(ThisPerson, firstName.Text,
                                    surname.Text, age.Text, weight.Text);
                        else MessageBox.Show("Taka osoba już istnieje.");
                    }
                    break;
                case "add":
                    if(!AreEmpty(firstName, surname))
                    {
                        if (Opera.NotDoubled(Opera.All, new Pilkarz(firstName.Text,
                            surname.Text, Convert.ToInt32(age.Text), Convert.ToInt32(weight.Text))))
                            Opera.AddNew(firstName.Text, surname.Text,
                                Convert.ToInt32(age.Text), Convert.ToInt32(weight.Text));
                        else MessageBox.Show("Taka osoba już istnieje.");
                    }

                    break;
                case "delete":
                    if(ThisPerson!=null)
                    {
                        Opera.All.Remove(ThisPerson);
                    }
                    break;
            }
            UpdateList();

        }

        private void slider_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            var slid = sender as Slider;
            switch(slid.Name)
            {
                case "ageSuw":
                    age.Text = Convert.ToString($"{MathF(slid.Value)}");
                    break;
                case "weightSuw":
                    weight.Text = Convert.ToString($"{MathF(slid.Value)}");
                    break;

            }
            
        }

        int MathF(double x) { return (int)Math.Floor(x); }

        bool AreEmpty(TextBox name, TextBox sur)
        {
            if (name.Text.Trim() == "" || sur.Text.Trim() =="") return true;
            else return false;
        }

        void UpdateList()
        {

            ListBox lb = listB;
            lb.Items.Clear();

            for (int i=0; i<Opera.All.Count;i++)
            {
                ListBoxItem lbi = new ListBoxItem();

                lbi.Background = Brushes.DarkRed;
                lbi.Foreground = Brushes.White;
                lbi.Margin= new Thickness(0, 2, 0, 2);
                lbi.Width = 425;
                lbi.Height = 20;
                lbi.HorizontalAlignment = HorizontalAlignment.Left;
                lbi.Selected += ListBoxItem_Selected;
                lbi.Content =  $"{Opera.All[i].Name} {Opera.All[i].Surname} ------ Wiek: {Opera.All[i].Age} ------- Waga: {Opera.All[i].Weight}";
                //               0                         1               2     3             4           5      6           7
                listB.Items.Add(lbi);
            }
            Opera.AllToFile(path, Opera.All);

        }

        private void ListBoxItem_Selected(object sender, RoutedEventArgs e)
        {
            ListBoxItem lbi = sender as ListBoxItem;
            string[] ns = Convert.ToString(lbi.Content).Split(' ');
            for (int i = 0; i < Opera.All.Count; i++)
            {
                if (Opera.All[i].Surname == ns[1])
                    if (Opera.All[i].Name == ns[0])
                        if (Opera.All[i].Age == Convert.ToInt32(ns[4]))
                            if (Opera.All[i].Weight == Convert.ToInt32(ns[7]))
                            {
                                LoadPerson(Opera.All[i]);
                                ThisPerson = Opera.All[i];
                            }
            }
        }

        void LoadPerson(Pilkarz p)
        {
            firstName.Text = p.Name;
            surname.Text = p.Surname;
            age.Text = Convert.ToString(p.Age);
            weight.Text = Convert.ToString(p.Weight);
            ageSuw.Value = p.Age;
            weightSuw.Value = p.Weight;
        }
    }
}
