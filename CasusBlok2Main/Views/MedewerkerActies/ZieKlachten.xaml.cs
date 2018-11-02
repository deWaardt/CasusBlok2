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

namespace CasusBlok2Main.Views.MedewerkerActies
{
    /// <summary>
    /// Interaction logic for ZieKlachten.xaml
    /// </summary>
    public partial class ZieKlachten : Window
    {
        MsSqlDBController db;
        public ZieKlachten()
        {
            InitializeComponent();
            db = new MsSqlDBController();
            RefreshKlachten();
            Klachtendoos.SelectionChanged += Klachtendoos_SelectionChanged;
        }

        private void Klachtendoos_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Klacht klacht = (Klacht)Klachtendoos.SelectedItem;
            Klant klant = db.getUserByID(klacht.klantid);

            IngevoerdDoor.Text = klant.voornaam + " " + klant.tussenvoegsel + " " + klant.achternaam;
            Telefoonnr.Text = klant.telefoonnummer;
            Email.Text = klant.email;
            Datum.Text = klacht.datum;
            Beschrijving.Text = klacht.data;
            Klachttype.Text = klacht.klachttype.ToString();
            
            if(klacht.status == 0) { Status.Text = "✘ Onafgehandeld"; }
            if(klacht.status == 1) { Status.Text = "✔ Afgehandeld"; }
            //if(klacht.status == 0) { Status.Text = "Onafgehandeld"; }
        }

        public void RefreshKlachten()
        {
            List<Klacht> alleKlachten = db.getAllKlachten();
            Klachtendoos.ItemsSource = alleKlachten;
        }

        private void KlachtAfhandelButton_Click(object sender, RoutedEventArgs e)
        {
            Klacht k = (Klacht)Klachtendoos.SelectedItem;
            MessageBoxResult messageBoxResult = System.Windows.MessageBox.Show("Weet U zeker dat U deze klacht wilt afhandelen?", "Klacht Afhandelen.", System.Windows.MessageBoxButton.YesNo);
            if (messageBoxResult == MessageBoxResult.Yes)
            {
                k.status = 1;
                db.editKlacht(k);

                //POOR BANDAID FIX BELOW:
                ZieKlachten zie = new ZieKlachten();
                zie.Show();
                this.Close();
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Klacht a = (Klacht)Klachtendoos.SelectedItem;
            Klant k = db.getUserByID(a.klantid);
            ZieKlantInfo ziek = new ZieKlantInfo(k.klantid);
            ziek.Show();
        }
    }
}
