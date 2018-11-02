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
    /// Interaction logic for Abbonementen.xaml
    /// </summary>
    public partial class Abbonementen : Window
    {
        MsSqlDBController db;

        public Abbonementen()
        {
            InitializeComponent();
            db = new MsSqlDBController();

        }

        //test

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
            Accountv2 accscherm = new Accountv2();
            accscherm.Show();
            this.Close();
        }

        private void FacturenBtn_Click(object sender, RoutedEventArgs e)
        {
            Factuurv2 facscherm = new Factuurv2();
            facscherm.Show();
            this.Close();
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
            //   Verhuizing  verhscherm = new Verhuizing();
            //   verhscherm.Show();
            //   this.Close();
        }


        private void KlachtenBtn_Click(object sender, RoutedEventArgs e)
        {
            Klachten klacht = new Klachten();
            klacht.Show();
            this.Close();
        }

        private void OptieA_Click(object sender, RoutedEventArgs e)
        {
            //check of klant abo heeft; if abo dan heeftabo >0;
            KlantAbonnement heeftabbo = db.getKlantAbonnementVanKlant(Main.Mainframe.currentLoggedIn.klantid);
            if (heeftabbo.abonnementid == 0)
            {
                //indien nog geen abo, push nieuw abo :
                KlantAbonnement abonnee = new KlantAbonnement();
                abonnee.abonnementid = 1;
                abonnee.klantid = Main.Mainframe.currentLoggedIn.klantid;
                db.pushKlantAbonnement(abonnee);
            }
            else if (heeftabbo.abonnementid != 0)
            {
                //edit functie voor abo
                KlantAbonnement editabonnee = new KlantAbonnement();
                editabonnee.abonnementid = 1;
                editabonnee.klantid = Main.Mainframe.currentLoggedIn.klantid;
                db.editKlantAbonnement(editabonnee);
            }
        }

        private void OptieB_Click(object sender, RoutedEventArgs e)
        {
            //check of klant abo heeft; if abo dan heeftabo >0;
            KlantAbonnement heeftabbo = db.getKlantAbonnementVanKlant(Main.Mainframe.currentLoggedIn.klantid);
            if (heeftabbo.abonnementid == 0)
            {
                //indien nog geen abo, push nieuw abo :
                KlantAbonnement abonnee = new KlantAbonnement();
                abonnee.abonnementid = 2;
                abonnee.klantid = Main.Mainframe.currentLoggedIn.klantid;
                db.pushKlantAbonnement(abonnee);
            }
            else if (heeftabbo.abonnementid != 0)
            {
                //edit functie voor abo
                KlantAbonnement editabonnee = new KlantAbonnement();
                editabonnee.abonnementid = 2;
                editabonnee.klantid = Main.Mainframe.currentLoggedIn.klantid;
                db.editKlantAbonnement(editabonnee);
            }
        }

        private void OptieC_Click(object sender, RoutedEventArgs e)
        {
            //check of klant abo heeft; if abo dan heeftabo >0;
            KlantAbonnement heeftabbo = db.getKlantAbonnementVanKlant(Main.Mainframe.currentLoggedIn.klantid);
            if (heeftabbo.abonnementid == 0)
            {
                //indien nog geen abo, push nieuw abo :
                KlantAbonnement abonnee = new KlantAbonnement();
                abonnee.abonnementid = 3;
                abonnee.klantid = Main.Mainframe.currentLoggedIn.klantid;
                db.pushKlantAbonnement(abonnee);
            }
            else if (heeftabbo.abonnementid != 0)
            {
                //edit functie voor abo
                KlantAbonnement editabonnee = new KlantAbonnement();
                editabonnee.abonnementid = 3;
                editabonnee.klantid = Main.Mainframe.currentLoggedIn.klantid;
                db.editKlantAbonnement(editabonnee);
            }
        }
    }
}
    
