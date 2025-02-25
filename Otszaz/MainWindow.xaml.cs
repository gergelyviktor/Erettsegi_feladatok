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

        public MainWindow() {
            InitializeComponent();
            
            // 1. feladat
            List<Dictionary<string, int>> lista = new List<Dictionary<string, int>>();
            Dictionary<string, int> vasarlas = new Dictionary<string, int>();
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
            // 2. feladat
            label2.Content = lista.Count;
        }
    }
}