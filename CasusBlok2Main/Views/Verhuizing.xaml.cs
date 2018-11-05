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
// using  MySQL

namespace CasusBlok2Main.Views
{
    /// <summary>
    /// Interaction logic for Window2.xaml
    /// </summary>
    public partial class Klantverhuizing : Window
    {
        MsSqlDBController db;

        public Klantverhuizing()
        {
            InitializeComponent();
            db = new MsSqlDBController();
            Klantverhuizing klantAdres = db.getAdres(klantid);
            string klantStraat = klantAdres.straat;
            int klantHuisnummer = klantAdres.huisnummer;
            string klantToevoeging = klantAdres.toevoeging;
            string klantPostcode = klantAdres.postcode;
            string klantWoonplaats = klantAdres.woonplaats;

            // labels van het huidige adres met daarin het huidige adres ingevuld
            oudStraatlbl.Content = "Uw oude straatnaam is: " + klantStraat;
            oudHuisnummerlbl.Content = "Uw oud huisnummer is: " + klantHuisnummer;
            oudToevoeginglbl.Content = "Uw oude toevoeging is: " + klantToevoeging;
            oudPostcodelbl.Content = "Uw oude postcode is: " + klantPostcode;
            oudWoonplaatslbl.Content = "Uw oude woonplaats is: " + klantWoonplaats;
        }

        private void AdresWijzigen_Click(object sender, RoutedEventArgs e)
        {
            // Dit zijn de gegevens van het nieuwe adres
            string newStraat = newStraattextbox.Content;
            int newHuisnummer = newHuisnummertextbox.Content;
            string newToevoeging = newToevoegingtextbox.Content;
            string newPostcode = newPostcodetextbox.Content;
            string newWoonplaats = newWoonplaatstextbox.Content;

            // voer functie editAdres van MySqlDBController uit

            // Home [naam van homescherm] = new Home();
            // [naam van homescherm].Show();
            this.Close();
        }

        
        private void VerhuizingAnnuleren_Click(object sender, RoutedEventArgs e)
        {
            // Home [naam van homescherm] = new Home();
            // [naam van homescherm].Show();
            this.Close();
        }
    }
}
