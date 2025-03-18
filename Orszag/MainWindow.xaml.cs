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
            var a = adatok.Where(x => x.Orszagnev == txt1.Text);
            if (a.Any()) {
                // létezik-e az a-nak eleme
                dtg1.ItemsSource = a;
            }
            else {
                MessageBox.Show("Nincs ilyen ország!");
            }
        }

        private void Button_Click_1(object sender, RoutedEventArgs e) {
            var a = adatok.OrderBy(x => x.Orszagnev);
            dtg1.ItemsSource = a;
        }

        private void Button_Click_2(object sender, RoutedEventArgs e) {
            var a = adatok.Select(x => new { Ország = x.Orszagnev, Főváros = x.Fovaros.ToUpper() });
            dtg1.ItemsSource = a;
        }

        private void Button_Click_3(object sender, RoutedEventArgs e) {
            // a főváros népessége páratlan
            //var a = adatok.Where(x=>x.FovarosNepesseg % 2 == 1);
            // és van a nevében 'b' betű (csak kis b!)
            //var a = adatok.Where(x=>x.FovarosNepesseg % 2 == 1 && x.Fovaros.Contains('b'));
            // kis-nagy betűre ne legyen érzékeny
            //var a = adatok.Where(x=>x.FovarosNepesseg % 2 == 1 && x.Fovaros.ToUpper().Contains('B'));
            // terület alapján csökkenő sorba rendezve
            //var a = adatok.OrderByDescending(x => x.Terulet);
            // első 3 elem
            //var a = adatok.OrderByDescending(x => x.Terulet).Take(3);
            // 2-4 elem
            var a = adatok.OrderByDescending(x => x.Terulet)
                .Skip(1)
                .Take(3);
            dtg1.ItemsSource = a;
        }

        private void Button_Click_4(object sender, RoutedEventArgs e) {
            // Mo-nál hány kisebb területű ország szerepel a listában?
            var a = adatok.Where(x => x.Orszagnev == "Magyarország").ToList();
            int terulet = a[0].Terulet;
            var kisebb = adatok.Count(x => x.Terulet < terulet);
            MessageBox.Show(kisebb.ToString()+" kisebb népességű ország van");
        }
    }
}