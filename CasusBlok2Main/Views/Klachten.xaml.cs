﻿using System;
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
    /// Interaction logic for Klachten.xaml
    /// </summary>
    public partial class Klachten : Window
    {
        MsSqlDBController msdb;
        public Klachten()
        {
            msdb = new MsSqlDBController();
            InitializeComponent();
        }
        private void KlachtVerstuurBtn_Click(object sender, RoutedEventArgs e)
        {
            Klacht klacht = new Klacht();
            //klacht.klachttype = 1;
            if (Dropdownboxcatagorie.Text == "Stroomuitval") { klacht.klachttype = 1; }
            else if (Dropdownboxcatagorie.Text == "Incorrecte factuur") { klacht.klachttype = 2; }
            else if (Dropdownboxcatagorie.Text == "Lange wachttijd") { klacht.klachttype = 3; }
            else if (Dropdownboxcatagorie.Text == "Anders") { klacht.klachttype = 4; }
            klacht.klantid = Mainframe.currentLoggedIn.klantid;
            klacht.data = KlachtTxtbx.Text;
            //klacht.datum = DateTime.Now.ToString();
            //klacht.status = 0;
            msdb.pushKlacht(klacht);
            
        }

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
    }
}
