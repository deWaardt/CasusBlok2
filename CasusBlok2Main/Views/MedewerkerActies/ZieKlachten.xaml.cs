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
            Beschrijving.Text = klacht.data;
        }

        public void RefreshKlachten()
        {
            List<Klacht> alleKlachten = db.getAllKlachten();
            Klachtendoos.ItemsSource = alleKlachten;
        }
    }
}
