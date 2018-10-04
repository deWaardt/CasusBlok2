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
            VraagLbl.Visibility = Visibility.Hidden;
            VraagTxtbx.Visibility = Visibility.Hidden;
            VerstuurBtn.Visibility = Visibility.Hidden;
            ToelichtingLbl.Visibility = Visibility.Hidden;

        }
    }
}
