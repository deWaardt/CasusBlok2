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
    /// Interaction logic for ZieBelmomenten.xaml
    /// </summary>
    public partial class ZieBelmomenten : Window
    {
        MsSqlDBController db;
        public ZieBelmomenten()
        {
            InitializeComponent();
            db = new MsSqlDBController();
            RefreshBelmomenten();
            Belmomentendoos.SelectionChanged += Belmomentendoos_SelectionChanged;
        }

        private void Belmomentendoos_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Belmoment belmoment = (Belmoment)Belmomentendoos.SelectedItem;
            Klant klant = db.getUserByID(belmoment.klantid);

            IngevoerdDoor.Text = klant.voornaam + " " + klant.tussenvoegsel + " " + klant.achternaam;
            Telefoonnr.Text = klant.telefoonnummer;
            Email.Text = klant.email;
            Datum.Text = belmoment.datum;
            Tijdstip.Text = belmoment.tijdstip;
            Beschrijving.Text = belmoment.data;

            if (belmoment.status == 0) { Status.Text = "✘ Onafgehandeld"; }
            if (belmoment.status == 1) { Status.Text = "✔ Afgehandeld"; }
        }

        public void RefreshBelmomenten()
        {
            List<Belmoment> alleAanvragen = db.getAllBelmomenten();
            Belmomentendoos.ItemsSource = alleAanvragen;
        }

        private void BelmomentAfhandelButton_Click(object sender, RoutedEventArgs e)
        {
            Belmoment a = (Belmoment)Belmomentendoos.SelectedItem;
            MessageBoxResult messageBoxResult = System.Windows.MessageBox.Show("Weet U zeker dat U dit belmoment wilt afhandelen?", "Belmoment Afhandelen.", System.Windows.MessageBoxButton.YesNo);
            if (messageBoxResult == MessageBoxResult.Yes)
            {
                a.status = 1;
                db.editBelmoment(a);

                //POOR BANDAID FIX BELOW:
                ZieBelmomenten zie = new ZieBelmomenten();
                zie.Show();
                this.Close();
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Belmoment a = (Belmoment)Belmomentendoos.SelectedItem;
            Klant k = db.getUserByID(a.klantid);
            ZieKlantInfo ziek = new ZieKlantInfo(k.klantid);
            ziek.Show();
        }
    }
}
