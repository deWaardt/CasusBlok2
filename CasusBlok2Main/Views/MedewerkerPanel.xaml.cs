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
using System.Windows.Shapes;
using CasusBlok2Main.Views.MedewerkerActies;

namespace CasusBlok2Main.Views
{
    /// <summary>
    /// Interaction logic for MedewerkerPanel.xaml
    /// </summary>
    public partial class MedewerkerPanel : Window
    {
        public MedewerkerPanel()
        {
            InitializeComponent();
        }

        private void OpenKlachten(object sender, RoutedEventArgs e)
        {
            ZieKlachten klachten = new ZieKlachten();
            klachten.Show();
        }

        private void Belmomenteknop_Click(object sender, RoutedEventArgs e)
        {
            ZieBelmomenten belmomenten = new ZieBelmomenten();
            belmomenten.Show();
        }

        private void Aanvragenknop_Click(object sender, RoutedEventArgs e)
        {
            ZieAanvragen aanvragen = new ZieAanvragen();
            aanvragen.Show();
        }

        private void KlantInfoKnop_Click(object sender, RoutedEventArgs e)
        {
            DialogZieGebruiker zieGebruiker = new DialogZieGebruiker();
            zieGebruiker.Show();
        }
    }
}
