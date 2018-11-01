using CasusBlok2Main.Database;
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

namespace CasusBlok2Main.Views.MedewerkerActies
{
    /// <summary>
    /// Interaction logic for ZieAanvragen.xaml
    /// </summary>
    public partial class ZieAanvragen : Window
    {
        MsSqlDBController db;
        public ZieAanvragen()
        {
            InitializeComponent();
            db = new MsSqlDBController();
            RefreshAanvragen();
            Aanvragendoos.SelectionChanged += Aanvragendoos_SelectionChanged;
        }

        private void Aanvragendoos_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Aanvraag aanvraag = (Aanvraag)Aanvragendoos.SelectedItem;
            Klant klant = db.getUserByID(aanvraag.klantid);

            IngevoerdDoor.Text = klant.voornaam + " " + klant.tussenvoegsel + " " + klant.achternaam;
            Telefoonnr.Text = klant.telefoonnummer;
            Email.Text = klant.email;
            Datum.Text = aanvraag.datum;
            Beschrijving.Text = aanvraag.data;
            Klachttype.Text = aanvraag.aanvraagtype.ToString();

            if (aanvraag.status == 0) { Status.Text = "✘ Onafgehandeld"; }
            if (aanvraag.status == 1) { Status.Text = "✔ Afgehandeld"; }
            //if(klacht.status == 0) { Status.Text = "Onafgehandeld"; }
        }

        public void RefreshAanvragen()
        {
            List<Aanvraag> alleAanvragen = db.getAllAanvragen();
            Aanvragendoos.ItemsSource = alleAanvragen;
        }

        private void AanvraagAfhandelButton_Click(object sender, RoutedEventArgs e)
        {
            Aanvraag a = (Aanvraag)Aanvragendoos.SelectedItem;
            MessageBoxResult messageBoxResult = System.Windows.MessageBox.Show("Weet U zeker dat U deze klacht wilt afhandelen?", "Klacht Afhandelen.", System.Windows.MessageBoxButton.YesNo);
            if (messageBoxResult == MessageBoxResult.Yes)
            {
                a.status = 1;
                db.editAanvraag(a);

                //POOR BANDAID FIX BELOW:
                ZieAanvragen zie = new ZieAanvragen();
                zie.Show();
                this.Close();
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Aanvraag a = (Aanvraag)Aanvragendoos.SelectedItem;
            Klant k = db.getUserByID(a.klantid);
            ZieKlantInfo ziek = new ZieKlantInfo(k.klantid);
            ziek.Show();
        }
    }
}
