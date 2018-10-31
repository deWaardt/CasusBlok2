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
    /// Interaction logic for AbonnementenInfo.xaml
    /// </summary>
    public partial class AbonnementenInfo : Window
    {
        MsSqlDBController db;

        public AbonnementenInfo()
        {
            InitializeComponent();
            db = new MsSqlDBController();
            KlantAbonnement heeftabbo = db.getKlantAbonnementVanKlant(Main.Mainframe.currentLoggedIn.klantid);
            int aboID = heeftabbo.abonnementid;
            Abonnement infoAbo = db.getAbonnement(aboID);
            string aboNaam = infoAbo.naam;
            int aboPrijs = infoAbo.prijs;
            AboinfoLbl.Content = "Uw huidige abonnement is: " + aboNaam + ". \nUw maandelijkse kosten zijn: " + aboPrijs + " euro.";
        }

        private void AboBeëindigen_Click(object sender, RoutedEventArgs e)
        {
            KlantAbonnement heeftabbo = db.getKlantAbonnementVanKlant(Main.Mainframe.currentLoggedIn.klantid);
            db.delKlantAbonnement(heeftabbo);
        }

        private void AboWijzigen_Click(object sender, RoutedEventArgs e)
        {

            Abbonementen abboscherm = new Abbonementen();
            abboscherm.Show();
            this.Close();
        }   
    }
}
