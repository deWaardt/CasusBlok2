using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data;
using MySql.Data.MySqlClient;
using CasusBlok2Main.Main;

namespace CasusBlok2Main.Database
{
    class DbController
    {
        public string cs = @"server=84.28.62.177;port=33060;userid=admin;
            password=casus;database=casusblok2;sslmode=none;";

        public MySqlConnection conn = null;
        public MySqlDataReader rdr = null;

        public DbController()
        {
            bool connection = testConnection();
            if (connection == false) { Console.WriteLine("No connection could be made!"); }
            else { Console.WriteLine("Succesfully connected."); }
        }

        bool testConnection()
        {
            try
            {
                conn = new MySqlConnection(cs);
                conn.Open();

                string stm = "SELECT * FROM Users";
                MySqlCommand cmd = new MySqlCommand(stm, conn);
                rdr = cmd.ExecuteReader();

                while (rdr.Read())
                {
                }

            }
            catch (MySqlException ex)
            {
                return false;
            }
            finally
            {
                if (rdr != null) { rdr.Close(); }
                if (conn != null) { conn.Close(); }
            }
            return true;
        }

        public void Testold()
        {
            List<string> column1 = new List<string>();
            List<string> column2 = new List<string>();
            List<string> column3 = new List<string>();

            try
            {
                conn = new MySqlConnection(cs);
                conn.Open();

                string stm = "SELECT * FROM Users";
                MySqlCommand cmd = new MySqlCommand(stm, conn);
                rdr = cmd.ExecuteReader();

                while (rdr.Read())
                {
                    //Console.WriteLine(rdr.GetString(1));
                    column1.Add(rdr.GetString(0));
                    column2.Add(rdr.GetString(1));
                    column3.Add(rdr.GetString(2));

                }

            }
            catch (MySqlException ex)
            {
                Console.WriteLine("Error: {0}", ex.ToString());

            }
            finally
            {
                if (rdr != null)
                {
                    rdr.Close();
                }

                if (conn != null)
                {
                    conn.Close();
                }

            }

            Console.WriteLine(column1[0]);
            Console.WriteLine(column2[0]);
            Console.WriteLine(column3[0]);
        }

        public void Test()
        {
            List<string> column1 = new List<string>();
            List<string> column2 = new List<string>();
            List<string> column3 = new List<string>();

            try
            {
                conn = new MySqlConnection(cs);
                conn.Open();

                string stm = "SELECT * FROM Users";
                MySqlCommand cmd = new MySqlCommand(stm, conn);
                rdr = cmd.ExecuteReader();

                while (rdr.Read())
                {
                    //Console.WriteLine(rdr.GetString(1));
                    column1.Add(rdr.GetString(0));
                    column2.Add(rdr.GetString(1));
                    column3.Add(rdr.GetString(2));

                }

            }
            catch (MySqlException ex) { Console.WriteLine("Error: {0}", ex.ToString()); }
            finally
            {
                if (rdr != null) { rdr.Close(); }
                if (conn != null) { conn.Close(); }
            }

            Console.WriteLine(column1[0]);
            Console.WriteLine(column2[0]);
            Console.WriteLine(column3[0]);
        }

        /// <summary>
        /// Vraag een specifieke gebruiker op.
        /// </summary>
        /// <param name="usrname">Het e-mailadres van de gebruiker.</param>
        /// <returns>Een "Klant" object van de opgevraagde gebruiker</returns>
        public Klant getUser(string usrname)
        {
            List<int> klantid = new List<int>();
            List<string> email = new List<string>();
            List<string> wachtwoord = new List<string>();
            List<string> voornaam = new List<string>();
            List<string> tussenvoegsel = new List<string>();
            List<string> achternaam = new List<string>();
            List<string> geboortedatum = new List<string>();
            List<string> telefoonnummer = new List<string>();


            try
            {
                conn = new MySqlConnection(cs);
                conn.Open();

                string stm = "SELECT * FROM Klant WHERE email = '" + usrname + "'";
                MySqlCommand cmd = new MySqlCommand(stm, conn);
                rdr = cmd.ExecuteReader();

                while (rdr.Read())
                {
                    //console.writeline(rdr.getstring(1));
                    klantid.Add(rdr.GetInt32(0));
                    email.Add(rdr.GetString(1));
                    wachtwoord.Add(rdr.GetString(2));
                    voornaam.Add(rdr.GetString(3));
                    tussenvoegsel.Add(rdr.GetString(4));
                    achternaam.Add(rdr.GetString(5));
                    geboortedatum.Add(rdr.GetString(6));
                    telefoonnummer.Add(rdr.GetString(7));

                }

            }
            catch (MySqlException ex) { Console.WriteLine("Error: {0}", ex.ToString()); throw new Exception(); }
            finally
            {
                if (rdr != null) { rdr.Close(); }
                if (conn != null) { conn.Close(); }
            }
            if (klantid.Count == 0)
            {
                throw new Exception("No user found");
                Klant nullReturn = new Klant();
                return nullReturn;
            }

            Klant toReturn = new Klant
            {
                klantid = klantid[0],
                email = email[0],
                wachtwoord = wachtwoord[0],
                voornaam = voornaam[0],
                tussenvoegsel = tussenvoegsel[0],
                achternaam = achternaam[0],
                geboortedatum = geboortedatum[0],
                telefoonnummer = telefoonnummer[0]
            };
            return toReturn;
        }

        /// <summary>
        /// Vraag een specifieke aanvraag op.
        /// </summary>
        /// <param name="aanvraagnummer">Het aanvraagnummer</param>
        /// <returns>Een "Aanvraag" object.</returns>
        public Aanvraag getAanvraag(int aanvraagnr)
        {
            Aanvraag toReturn = new Aanvraag();
            try
            {
                conn = new MySqlConnection(cs);
                conn.Open();

                string stm = "SELECT * FROM Aanvraag WHERE aanvraagnummer = " + aanvraagnr.ToString(); ;
                MySqlCommand cmd = new MySqlCommand(stm, conn);
                rdr = cmd.ExecuteReader();

                while (rdr.Read())
                {
                    toReturn.aanvraagnummer = rdr.GetInt32(0);
                    toReturn.aanvraagtype = rdr.GetInt32(1);
                    toReturn.klantid = rdr.GetInt32(2);
                    toReturn.data = rdr.GetString(3);
                }

            }
            catch (MySqlException ex)
            {
                throw ex;
                //return null;
            }
            finally
            {
                if (rdr != null) { rdr.Close(); }
                if (conn != null) { conn.Close(); }
            }
            return toReturn;
        }
        /// <summary>
        /// Vraag alle aanvragen van een bepaalde klant op.
        /// </summary>
        /// <param name="klantid">Het klantnummer van de klant.
        /// Als er geen klantnummer meegegeven wordt, wordt het klantnummer van de huidige
        /// ingelogde gebruiker gebruikt.</param>
        /// <returns>Een list met aanvragen</returns>
        public List<Aanvraag> getAllAanvragenVanKlant(int klantid = -1)
        {
            if (klantid == -1) { klantid = Mainframe.currentLoggedIn.klantid; }

            List<int> aanvraagnummers = new List<int>();
            List<int> aanvraagtypes = new List<int>();
            List<int> klantids = new List<int>();
            List<string> datas = new List<string>();
            List<Aanvraag> toReturn = new List<Aanvraag>();

            try
            {
                conn = new MySqlConnection(cs);
                conn.Open();

                string stm = "SELECT * FROM Aanvraag WHERE klantid = " + klantid;
                MySqlCommand cmd = new MySqlCommand(stm, conn);
                rdr = cmd.ExecuteReader();

                while (rdr.Read())
                {
                    aanvraagnummers.Add(rdr.GetInt32(0));
                    aanvraagtypes.Add(rdr.GetInt32(1));
                    klantids.Add(rdr.GetInt32(2));
                    datas.Add(rdr.GetString(3));
                }

            }
            catch (MySqlException ex)
            {
                throw ex;
                //return null;
            }
            finally
            {
                if (rdr != null) { rdr.Close(); }
                if (conn != null) { conn.Close(); }
            }

            int i = 0;
            foreach (int a in aanvraagnummers)
            {
                Aanvraag toAdd = new Aanvraag();
                toAdd.aanvraagnummer = a;
                toAdd.aanvraagtype = aanvraagtypes[i];
                toAdd.klantid = klantids[i];
                toAdd.data = datas[i];
                toReturn.Add(toAdd);
                i++;
            }


            return toReturn;
        }

        public Abonnement getAbonnement(int abonnementid)
        {
            Abonnement toReturn = new Abonnement();
            try
            {
                conn = new MySqlConnection(cs);
                conn.Open();

                string stm = "SELECT * FROM Abonnement WHERE abonnementid = " + abonnementid.ToString(); ;
                MySqlCommand cmd = new MySqlCommand(stm, conn);
                rdr = cmd.ExecuteReader();

                while (rdr.Read())
                {
                    toReturn.abbonementid = rdr.GetInt32(0);
                    toReturn.naam = rdr.GetString(1);
                    toReturn.prijs = rdr.GetInt32(2);
                    toReturn.type = rdr.GetInt32(3);
                }

            }
            catch (MySqlException ex)
            {
                throw ex;
                //return null;
            }
            finally
            {
                if (rdr != null) { rdr.Close(); }
                if (conn != null) { conn.Close(); }
            }
            return toReturn;

        }

        public List<Belmoment> getAllBelmomentenVanKlant(int klantid = -1)
        {
            if (klantid == -1) { klantid = Mainframe.currentLoggedIn.klantid; }

            List<int> klantids = new List<int>();
            List<string> tijdstippen = new List<string>();
            List<string> datums = new List<string>();
            List<int> statussen = new List<int>();
            List<string> notities = new List<string>();
            List<Belmoment> toReturn = new List<Belmoment>();

            try
            {
                conn = new MySqlConnection(cs);
                conn.Open();

                string stm = "SELECT * FROM Belmoment WHERE klantid = " + klantid;
                MySqlCommand cmd = new MySqlCommand(stm, conn);
                rdr = cmd.ExecuteReader();

                while (rdr.Read())
                {
                    klantids.Add(rdr.GetInt32(0));
                    tijdstippen.Add(rdr.GetString(1));
                    datums.Add(rdr.GetString(2));
                    statussen.Add(rdr.GetInt32(3));
                    notities.Add(rdr.GetString(4));
                }

            }
            catch (MySqlException ex)
            {
                throw ex;
                //return null;
            }
            finally
            {
                if (rdr != null) { rdr.Close(); }
                if (conn != null) { conn.Close(); }
            }

            int i = 0;
            foreach (int a in klantids)
            {
                Belmoment toAdd = new Belmoment();
                toAdd.klantid = a;
                toAdd.tijdstip = tijdstippen[i];
                toAdd.datum = datums[i];
                toAdd.status = statussen[i];
                toAdd.notitie = notities[i];
                toReturn.Add(toAdd);
                i++;
            }


            return toReturn;
        }
    }
}
