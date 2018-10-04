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
            //string name = usrname.Text;
            //string pass = password.Text;

            //Klant loginuser = db.getUser(name);
            //if (pass == loginuser.wachtwoord)
            //{
            //    Console.WriteLine("Login success");
            //    Mainframe.currentLoggedIn = loginuser;
            //    Mainframe.whoLoggedIn();
            //}

            //else { Console.WriteLine("Login unsuccesfull"); }

            ////Test getAanvraag;
            //Aanvraag aanvraag = db.getAanvraag(1);
            //Console.WriteLine(aanvraag.data);

            ////Test getAllAanvraagVanKlant;
            //List<Aanvraag> allAanvraag = db.getAllAanvragenVanKlant(1);
            //Console.WriteLine(allAanvraag[1].data);

            ////Test getAllBelmomentenVanKlant;
            //List<Belmoment> allBelMomenten = db.getAllBelmomentenVanKlant(1);
            //Console.WriteLine(allBelMomenten[0].notitie);

            //Factuur factuur = db.getFactuur(1);
            //Console.WriteLine(factuur.periode);

            //List<Factuur> facturen = db.getAllFacturenVanKlant(1);
            //Console.WriteLine(facturen[0].periode);

            //Abonnement abonnement = db.getAbonnomentVanKlant(1);
            //Console.WriteLine(abonnement.naam);

            //Abonnement abonnement2 = db.getAbonnement(1);
            //Console.WriteLine(abonnement2.naam);

            //Melding melding = db.getMelding(1);
            //Console.WriteLine(melding.data);

            //List<Melding> meldingen = db.getAllMeldingen();
            //Console.WriteLine(meldingen[0].data);

            //List<Melding> meldingen2 = db.getAllMeldingenVanKlant(1);
            //Console.WriteLine(meldingen2[0].data);

            //Verbruik verbruik = db.getVerbruik(1);
            //Console.WriteLine(verbruik.klantid);


        }
    }
}
