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
using CasusBlok2Main.Views.MedewerkerActies;

namespace CasusBlok2Main.Views.MedewerkerActies
{
    /// <summary>
    /// Interaction logic for DialogZieGebruiker.xaml
    /// </summary>
    public partial class DialogZieGebruiker : Window
    {
        MsSqlDBController db;
        public DialogZieGebruiker()
        {
            InitializeComponent();
            db = new MsSqlDBController();
        }

        private void Go_Click(object sender, RoutedEventArgs e)
        {
            int klantid = 0; ;
            try { klantid = Int32.Parse(KlantidEntry.Text); }
            catch(Exception ex) { Label.Content = "Voer een geldig klantnummer in"; KlantidEntry.Clear(); return; }

            Klant k = db.getUserByID(klantid);
            if(k.voornaam == null) { Label.Content = "Onbekend klantnummer"; KlantidEntry.Clear(); return; }

            ZieKlantInfo klantinfo = new ZieKlantInfo(k.klantid);
            klantinfo.Show();
            this.Close();
        }
    }
}
