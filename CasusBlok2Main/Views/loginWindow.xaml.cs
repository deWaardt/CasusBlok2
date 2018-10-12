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
    /// Interaction logic for loginWindow.xaml
    /// </summary>
    public partial class loginWindow : Window
    {
        MsSqlDBController db;
        loginIncorrect fout;
        public loginWindow()
        {
            InitializeComponent();
            Connecting pls = new Connecting();
            pls.Show();
            db = new MsSqlDBController();
            pls.Close();

        }

        private void Fout_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            this.IsEnabled = true;
            this.Focusable = true;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
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
                Home homescherm = new Home();
                homescherm.Show();
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
    }
}
