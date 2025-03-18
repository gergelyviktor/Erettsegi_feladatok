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

namespace Orszagok {
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window {
        List<Orszag> adatok = new List<Orszag>();
        public MainWindow() {
            InitializeComponent();
            foreach (var item in File.ReadAllLines("orszag.txt").Skip(1)) {
                var temp = new Orszag(item);
                adatok.Add(temp);
            }
            dtg1.ItemsSource = adatok;
        }

        private void Button_Click(object sender, RoutedEventArgs e) {
            var a = adatok.Where(x => x.Orszagnev == txt1.Text).ToList();
            if (a.Any()) {
                // létezik-e az a-nak eleme
                dtg1.ItemsSource = a;
            }
            else {
                MessageBox.Show("Nincs ilyen ország!");
            }
        }

        private void Button_Click_1(object sender, RoutedEventArgs e) {
            var a = adatok.OrderBy(x => x.Orszagnev).ToList();
            dtg1.ItemsSource = a;
        }

        private void Button_Click_2(object sender, RoutedEventArgs e) {
            var a = adatok.Select(x => new { Ország = x.Orszagnev, Főváros = x.Fovaros.ToUpper() }).ToList();
            dtg1.ItemsSource = a;
        }
    }
}