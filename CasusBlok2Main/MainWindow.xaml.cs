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
using System.Windows.Navigation;
using System.Windows.Shapes;
using CasusBlok2Main.Database;
using CasusBlok2Main.Views;

namespace CasusBlok2Main
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            loginWindow login = new loginWindow();
            login.Show();
            this.Close();
            //DbController db = new DbController();
            //User usr = db.getUser("superhans");
            //Console.WriteLine(usr.firstName);
        }
    }
}
