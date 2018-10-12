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

namespace CasusBlok2Main.Views
{
    /// <summary>
    /// Interaction logic for Home.xaml
    /// </summary>
    public partial class Home : Window
    {
        public Home()
        {
            InitializeComponent();
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
    }
}
