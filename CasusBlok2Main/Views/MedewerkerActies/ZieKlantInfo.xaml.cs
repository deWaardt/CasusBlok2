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
    /// Interaction logic for ZieKlantInfo.xaml
    /// </summary>
    public partial class ZieKlantInfo : Window
    {
        MsSqlDBController db;
        Klant k;
        public ZieKlantInfo(int klantid = -1)
        {
            InitializeComponent();
            db = new MsSqlDBController();
            k = db.getUserByID(klantid);
            FillTextBoxes();
            FillListViews();
        }

        public void FillTextBoxes()
        {
            Klantnr.Text = k.klantid.ToString();
            Voornaam.Text = k.voornaam;
            Tussenvoegsel.Text = k.tussenvoegsel;
            Achternaam.Text = k.achternaam;
            Geboortedatum.Text = k.geboortedatum;
            Email.Text = k.email;
            Telnr.Text = k.telefoonnummer;
        }

        public void FillListViews()
        {
            List<Aanvraag> alleAanvragen = db.getAllAanvragenVanKlant(k.klantid);
            Aanvragendoos.ItemsSource = alleAanvragen;

            List<Klacht> alleKlachten = db.getAllKlachtenVanKlant(k.klantid);
            Klachtendoos.ItemsSource = alleKlachten;

            List<Belmoment> alleBelmomenten = db.getAllBelmomentenVanKlant(k.klantid);
            Belmomentendoos.ItemsSource = alleBelmomenten;
        }
    }
}
