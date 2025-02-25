using System.IO;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Otszaz {
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window {

        List<Dictionary<string, int>> lista = new List<Dictionary<string, int>>();
        Dictionary<string, int> vasarlas = new Dictionary<string, int>();
        public MainWindow() {
            InitializeComponent();

            // 1. feladat - beolvasás
            string[] sorok = File.ReadAllLines("penztar.txt");
            foreach (var item in sorok) {
                if (item != "F") {
                    if (!vasarlas.ContainsKey(item)) {
                        vasarlas.Add(item, 1);
                    }
                    else {
                        vasarlas[item]++;
                    }
                }
                else {
                    //lista.Add(vasarlas); // ez nem jó, mert a Clear innen is kiszedné az értékeket, hiszen nem értékeket töröl, hanem referenciákat
                    lista.Add(new Dictionary<string, int>(vasarlas));
                    vasarlas.Clear();
                }
            }
            // 2. feladat - hányszor fizettek a pénztárnál
            label2.Content = lista.Count;
            // 3. feladat - az első vásárlónak hány darab árucikk volt a kosarában
            //label3.Content = lista[0].Count; // ez nem jó, mert a Count csak a kulcsokat számolja, nem a darabszámot
            var db = 0;
            foreach (var item in lista[1]) {
                db += item.Value;
            }
            label3.Content = db;
            // vagy LINQ-val
            //label3.Content = lista[1].Values.Sum();
        }

        private void Button_Click(object sender, RoutedEventArgs e) {
            // 4. feladat - kérjük be egy vásárlás sorszámát, egy árucikk nevét és egy darabszámot
            var sorszam = int.Parse(textbox1.Text);
            var arucikk = textbox2.Text;
            var darabszam = int.Parse(textbox3.Text);
            // 5. feladat - EZ NEHÉZ, KIHAGYNI! Az árucikkből melyik vásárláskor vettek először és melyiknél utoljára
            // összesen hány alkalommal vásároltak
            int hanyszor = 1;
            int elso = 0;
            int utolso = 0;
            bool eloszor = true;
            int mennyi = 0;
            foreach (var i in lista) {
                foreach (var j in i) {
                    if (j.Key == arucikk && eloszor) {
                        elso = hanyszor;
                        eloszor = false; // emiatt csak az első találatnál lép be a belső ciklusba
                    }
                    if (j.Key == arucikk) {
                        utolso = hanyszor;
                        mennyi++;
                    }
                }
                hanyszor++;
            }
            label5.Content = elso + " " + utolso + " " + mennyi;
            // 6. feladat - a bekért darabszámot vásárolva a termékből mennyi a fizetendő összeg

        }
    }
}