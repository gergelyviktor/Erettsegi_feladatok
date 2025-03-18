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
    }
}