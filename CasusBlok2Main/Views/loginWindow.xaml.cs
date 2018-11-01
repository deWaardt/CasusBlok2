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
using CasusBlok2Main.Views.MedewerkerActies;

namespace CasusBlok2Main.Views
{
    /// <summary>
    /// Interaction logic for loginWindow.xaml
    /// </summary>
    public partial class loginWindow : Window
    {
        MsSqlDBController db;
        loginIncorrect fout;
        bool MedewerkerMode;
        public loginWindow()
        {
            InitializeComponent();
            Connecting pls = new Connecting();
            pls.Show();
            db = new MsSqlDBController();
            pls.Close();
            MedewerkerMode = false;
        }

        private void Fout_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            this.IsEnabled = true;
            this.Focusable = true;
        }

        private void LoginKlant(object sender, RoutedEventArgs e)
        {
            if(MedewerkerMode == true) { LoginMedewerker(sender, e); return; }
            Console.WriteLine("==== EXEC LOGINKLANT");
            string name = usrname.Text;
            string pass = password.Text;

            if (name == "" || pass == "") { return; }
            Klant loginuser = db.getUser(name);
            
            if (pass == loginuser.wachtwoord)
            {
                Console.WriteLine("Login success");
                Mainframe.currentLoggedIn = loginuser;
                Mainframe.whoLoggedIn();
                //Open main window
                this.Close();
            }

            else
            {
                fout = new loginIncorrect();
                fout.Closing += Fout_Closing;
                fout.Show();
                this.IsEnabled = false;
                this.Focusable = false;
                
            }
        }

        private void SwitchtoMederwerker(object sender, RoutedEventArgs e)
        {
            TerugKnop.Visibility = Visibility.Visible;
            MedewerkerKnop.Visibility = Visibility.Hidden;
            InlogKnop.Content = "Inloggen als medewerker";
            //InlogKnop.Click += LoginMedewerker;
            MedewerkerMode = true;
        }

        private void LoginMedewerker(object sender, RoutedEventArgs e)
        {
            Console.WriteLine("==== EXEC LOGINMEDEWERKER");
            string name = usrname.Text;
            string pass = password.Text;

            if (name == "" || pass == "") { return; }
            Medewerker loginuser = db.getMedewerker(name);

            if (pass == loginuser.wachtwoord)
            {
                Console.WriteLine("Login success");
                Mainframe.currentLoggedInMedewerker = loginuser;
                //Open medewerkerwindow
                MedewerkerPanel p = new MedewerkerPanel();
                p.Show();
                this.Close();
            }

            else
            {
                fout = new loginIncorrect();
                fout.Closing += Fout_Closing;
                fout.Show();
                this.IsEnabled = false;
                this.Focusable = false;

            }
        }

        private void TerugNaarKlant(object sender, RoutedEventArgs e)
        {
            TerugKnop.Visibility = Visibility.Hidden;
            MedewerkerKnop.Visibility = Visibility.Visible;
            InlogKnop.Content = "Inloggen";
            //InlogKnop.Click += LoginKlant;
            MedewerkerMode = false;

        }
    }
}
