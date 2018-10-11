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

namespace CasusBlok2Main.Views
{
    /// <summary>
    /// Interaction logic for Vragen.xaml
    /// </summary>
    public partial class Vragen : Window
    {
        public Vragen()
        {
            InitializeComponent();
        }

        private void VraagstelBtn_Click(object sender, RoutedEventArgs e)
        {
            VraagLbl.Visibility = Visibility.Visible;
            VraagTxtbx.Visibility = Visibility.Visible;
            VerstuurBtn.Visibility = Visibility.Visible;
            ToelichtingLbl.Visibility = Visibility.Visible;
            FAQLbl.Visibility = Visibility.Hidden;
            KlachtBtn.Visibility = Visibility.Visible;
            KlachtLbl.Visibility = Visibility.Hidden;
            KlachtTxtbx.Visibility = Visibility.Hidden;
            KlachtVerstuurBtn.Visibility = Visibility.Hidden;
            Dropdownboxcatagorie.Visibility = Visibility.Hidden;
            KlachttoelichtingLbl.Visibility = Visibility.Hidden;
            
        }

        private void FAQBtn_Click(object sender, RoutedEventArgs e)
        {
            VraagLbl.Visibility = Visibility.Hidden;
            VraagTxtbx.Visibility = Visibility.Hidden;
            VerstuurBtn.Visibility = Visibility.Hidden;
            ToelichtingLbl.Visibility = Visibility.Hidden;
            FAQLbl.Visibility = Visibility.Visible;
            KlachtBtn.Visibility = Visibility.Visible;
            KlachtLbl.Visibility = Visibility.Hidden;
            KlachtTxtbx.Visibility = Visibility.Hidden;
            KlachtVerstuurBtn.Visibility = Visibility.Hidden;
            Dropdownboxcatagorie.Visibility = Visibility.Hidden;
            KlachttoelichtingLbl.Visibility = Visibility.Hidden;
        }

        private void KlachtBtn_Click(object sender, RoutedEventArgs e)
        {
            VraagLbl.Visibility = Visibility.Hidden;
            VraagTxtbx.Visibility = Visibility.Hidden;
            VerstuurBtn.Visibility = Visibility.Hidden;
            ToelichtingLbl.Visibility = Visibility.Hidden;
            FAQLbl.Visibility = Visibility.Hidden;
            KlachtBtn.Visibility = Visibility.Visible;
            KlachtLbl.Visibility = Visibility.Visible;
            KlachtTxtbx.Visibility = Visibility.Visible;
            KlachtVerstuurBtn.Visibility = Visibility.Visible;
            Dropdownboxcatagorie.Visibility = Visibility.Visible;
            KlachttoelichtingLbl.Visibility = Visibility.Visible;

        }

        private void VerstuurBtn_Click(object sender, RoutedEventArgs e)
        {
            Aanvraag aanvraag = new Aanvraag();
            aanvraag.aanvraagtype = 2;
            aanvraag.data = VraagTxtbx.Text;
            DbController db = new DbController();
            //db.pushAanvraag(aanvraag);
        }

        private void KlachtVerstuurBtn_Click(object sender, RoutedEventArgs e)
        {
            Aanvraag klacht = new Aanvraag();
            klacht.aanvraagtype = 1;
            string categorieKlacht = Dropdownboxcatagorie.Text + ", "+ KlachtTxtbx.Text;
            klacht.data = categorieKlacht;
            DbController db = new DbController();
            //db.pushAanvraag(aanvraag);
        }

        private void ComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }
    }
}
