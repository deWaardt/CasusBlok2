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
    /// Interaction logic for Abbonementen.xaml
    /// </summary>
    public partial class Abbonementen : Window
    {
        public Abbonementen()
        {
            InitializeComponent();
        }

        //test

        private void Home_Click(object sender, RoutedEventArgs e)
        {
            
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {

        }

        private void KlachtenVragenBtn_Click(object sender, RoutedEventArgs e)
        {
            Vragen vraagscherm = new Vragen();
            vraagscherm.Show();
            this.Close();
        }
        private void Home_button_Click(object sender, RoutedEventArgs e)
        {
            Home homescherm = new Home();
            homescherm.Show();
            this.Close();
        }
    }
}
