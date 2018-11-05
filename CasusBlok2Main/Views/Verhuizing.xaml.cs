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
using CasusBlok2Main.Database;
using CasusBlok2Main.Main;

namespace CasusBlok2Main.Views
{
    /// <summary>
    /// Interaction logic for Verhuizing.xaml
    /// </summary>
    public partial class Verhuizing : Window
    {
        private void KlachtenVragenBtn_Click(object sender, RoutedEventArgs e)
        {
            Vragen vraagscherm = new Vragen();
            vraagscherm.Show();
            this.Close();
        }

        private void AbonnementenBtn_Click(object sender, RoutedEventArgs e)
        {
            Abbonementen abboscherm = new Abbonementen();
            abboscherm.Show();
            this.Close();
        }

        private void AccountBtn_Click(object sender, RoutedEventArgs e)
        {
            //Accountv2 accscherm = new Accountv2();
            //accscherm.Show();
            //this.Close();
        }

        private void FacturenBtn_Click(object sender, RoutedEventArgs e)
        {
            //Factuurv2 facscherm = new Factuurv2();
            //facscherm.Show();
            //this.Close();
        }

        private void HomeBtn_Click(object sender, RoutedEventArgs e)
        {
            Home homescherm = new Home();
            homescherm.Show();
            this.Close();
        }

        private void SettingsBtn_Click(object sender, RoutedEventArgs e)
        {
            //    Settings settscherm = new Settings();
            //    settscherm.Show();
            //    this.Close();
        }

        private void VerhuisBtn_Click(object sender, RoutedEventArgs e)
        {
            Verhuizing  verhscherm = new Verhuizing();
            verhscherm.Show();
            this.Close();
        }


        private void KlachtenBtn_Click(object sender, RoutedEventArgs e)
        {
            Klachten klacht = new Klachten();
            klacht.Show();
            this.Close();
        }

        DbController db;

        public Verhuizing()
        {
            InitializeComponent();
            db = new DbController();

            // KAN PAS UNCOMMENTED ZIJN WANNEER DIT IN MYSQL DATABASE IS TOEGEVOEGD

            //Verhuizing klantAdres = db.getAdres(klantid);
            //string klantStraat = klantAdres.straat;
            //string klantHuisnummer = klantAdres.huisnummer;
            //string klantToevoeging = klantAdres.toevoeging;
            //string klantPostcode = klantAdres.postcode;
            //string klantWoonplaats = klantAdres.woonplaats;

            // labels van het huidige adres met daarin het huidige adres ingevuld
            //oudStraatlbl.Content = klantStraat;
            //oudHuisnummerlbl.Content = klantHuisnummer;
            //oudToevoeginglbl.Content = klantToevoeging;
            //oudPostcodelbl.Content = klantPostcode;
            //oudWoonplaatslbl.Content = klantWoonplaats;
        }

        private void AdresWijzigen_Click(object sender, RoutedEventArgs e)
        {
            // Dit zijn de gegevens van het nieuwe adres
            string newStraat = newStraattextbox.Text;
            string newHuisnummer = newHuisnummertextbox.Text;
            string newToevoeging = newToevoegingtextbox.Text;
            string newPostcode = newPostcodetextbox.Text;
            string newWoonplaats = newWoonplaatstextbox.Text;

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
