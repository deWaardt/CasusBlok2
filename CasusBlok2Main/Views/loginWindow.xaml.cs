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
        DbController db;
        public loginWindow()
        {
            InitializeComponent();
            Connecting pls = new Connecting();
            pls.Show();
            db = new DbController();
            pls.Close();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            string name = usrname.Text;
            string pass = password.Text;

            User loginuser = db.getUser(name);
            if (pass == loginuser.password)
            {
                Console.WriteLine("Login success");
                Mainframe.currentLoggedIn = loginuser;
                Mainframe.whoLoggedIn();
            }

            else { Console.WriteLine("Login unsuccesfull"); }
        }
    }
}
