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

                string stm = "SELECT * FROM Klant";
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
            //List<int> klantid = new List<int>();
            //List<string> email = new List<string>();
            //List<string> wachtwoord = new List<string>();
            //List<string> voornaam = new List<string>();
            //List<string> tussenvoegsel = new List<string>();
            //List<string> achternaam = new List<string>();
            //List<string> geboortedatum = new List<string>();
            //List<string> telefoonnummer = new List<string>();
            Klant toReturn = new Klant();

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
                    toReturn.klantid = (rdr.GetInt32(0));
                    toReturn.email = (rdr.GetString(1));
                    toReturn.wachtwoord = (rdr.GetString(2));
                    toReturn.voornaam = (rdr.GetString(3));
                    toReturn.tussenvoegsel = (rdr.GetString(4));
                    toReturn.achternaam = (rdr.GetString(5));
                    toReturn.geboortedatum = (rdr.GetString(6));
                    toReturn.telefoonnummer = (rdr.GetString(7));

                }

            }
            catch (MySqlException ex) { Console.WriteLine("Error: {0}", ex.ToString()); throw new Exception(); }
            finally
            {
                if (rdr != null) { rdr.Close(); }
                if (conn != null) { conn.Close(); }
            }


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
                    toReturn.abonnementid = rdr.GetInt32(0);
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

        public Factuur getFactuur(int factuurnummer)
        {
            Factuur toReturn = new Factuur();
            try
            {
                conn = new MySqlConnection(cs);
                conn.Open();

                string stm = "SELECT * FROM Factuur WHERE factuurnummer = " + factuurnummer.ToString(); ;
                MySqlCommand cmd = new MySqlCommand(stm, conn);
                rdr = cmd.ExecuteReader();

                while (rdr.Read())
                {
                    toReturn.factuurnummer = rdr.GetInt32(0);
                    toReturn.rekeningnummer = rdr.GetInt32(1);
                    toReturn.periode = rdr.GetString(2);
                    toReturn.klantid = rdr.GetInt32(3);
                    toReturn.status = rdr.GetInt16(4);
                    toReturn.meterstand = rdr.GetInt32(5);
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

        public List<Factuur> getAllFacturenVanKlant(int klantid = -1)
        {
            if (klantid == -1) { klantid = Mainframe.currentLoggedIn.klantid; }

            List<int> factuurnummers = new List<int>();
            List<int> rekeningnummers = new List<int>();
            List<string> periodes = new List<string>();
            List<int> klantids = new List<int>();
            List<int> statussen = new List<int>();
            List<int> meterstanden = new List<int>();
            List<Factuur> toReturn = new List<Factuur>();

            try
            {
                conn = new MySqlConnection(cs);
                conn.Open();

                string stm = "SELECT * FROM Factuur WHERE klantid = " + klantid;
                MySqlCommand cmd = new MySqlCommand(stm, conn);
                rdr = cmd.ExecuteReader();

                while (rdr.Read())
                {
                    factuurnummers.Add(rdr.GetInt32(0));
                    rekeningnummers.Add(rdr.GetInt32(1));
                    periodes.Add(rdr.GetString(2));
                    klantids.Add(rdr.GetInt16(3));
                    statussen.Add(rdr.GetInt32(4));
                    meterstanden.Add(rdr.GetInt32(5));
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
                Factuur toAdd = new Factuur();
                toAdd.klantid = a;
                toAdd.factuurnummer = factuurnummers[i];
                toAdd.rekeningnummer = rekeningnummers[i];
                toAdd.status = statussen[i];
                toAdd.periode = periodes[i];
                toAdd.rekeningnummer = rekeningnummers[i];
                toReturn.Add(toAdd);
                i++;
            }


            return toReturn;
        }

        public Abonnement getAbonnomentVanKlant(int klantid = -1)
        {
            if (klantid == -1) { klantid = Mainframe.currentLoggedIn.klantid; }
            Abonnement toReturn = new Abonnement();
            KlantAbonnement link = new KlantAbonnement();
            try
            {
                conn = new MySqlConnection(cs);
                conn.Open();

                string stm = "SELECT * FROM KlantAbonnement WHERE klantid = " + klantid.ToString(); ;
                MySqlCommand cmd = new MySqlCommand(stm, conn);
                rdr = cmd.ExecuteReader();

                while (rdr.Read())
                {
                    link.klantid = rdr.GetInt32(0);
                    link.abonnementid = rdr.GetInt32(1);
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

            try
            {
                conn = new MySqlConnection(cs);
                conn.Open();

                string stm = "SELECT * FROM Abonnement WHERE abonnementid = " + link.abonnementid.ToString(); ;
                MySqlCommand cmd = new MySqlCommand(stm, conn);
                rdr = cmd.ExecuteReader();

                while (rdr.Read())
                {
                    toReturn.abonnementid = rdr.GetInt32(0);
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

        public Melding getMelding(int meldingnummer)
        {
            Melding toReturn = new Melding();

            try
            {
                conn = new MySqlConnection(cs);
                conn.Open();

                string stm = "SELECT * FROM Melding WHERE meldingnummer = " + meldingnummer.ToString(); ;
                MySqlCommand cmd = new MySqlCommand(stm, conn);
                rdr = cmd.ExecuteReader();

                while (rdr.Read())
                {
                    toReturn.meldingnummer = rdr.GetInt32(0);
                    toReturn.klantid = rdr.GetInt32(1);
                    toReturn.status = rdr.GetInt32(2);
                    toReturn.meldingtype = rdr.GetInt32(3);
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

        public List<Melding> getAllMeldingen()
        {
            List<int> meldingnummrs = new List<int>();
            List<int> klantids = new List<int>();
            List<int> statussen = new List<int>();
            List<int> meldingtypes = new List<int>();
            List<string> datas = new List<string>();
            List<Melding> toReturn = new List<Melding>();

            try
            {
                conn = new MySqlConnection(cs);
                conn.Open();

                string stm = "SELECT * FROM Melding";
                MySqlCommand cmd = new MySqlCommand(stm, conn);
                rdr = cmd.ExecuteReader();

                while (rdr.Read())
                {
                    meldingnummrs.Add(rdr.GetInt32(0));
                    klantids.Add(rdr.GetInt32(1));
                    statussen.Add(rdr.GetInt32(2));
                    meldingtypes.Add(rdr.GetInt16(3));
                    datas.Add(rdr.GetString(4));
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
                Melding toAdd = new Melding();
                toAdd.klantid = a;
                toAdd.meldingnummer = meldingnummrs[i];
                toAdd.status = statussen[i];
                toAdd.meldingtype = meldingtypes[i];
                toAdd.data = datas[i];
                toReturn.Add(toAdd);
                i++;
            }


            return toReturn;
        }

        public List<Melding> getAllMeldingenVanKlant(int klantid = -1)
        {
            if (klantid == -1) { klantid = Mainframe.currentLoggedIn.klantid; }

            List<int> meldingnummrs = new List<int>();
            List<int> klantids = new List<int>();
            List<int> statussen = new List<int>();
            List<int> meldingtypes = new List<int>();
            List<string> datas = new List<string>();
            List<Melding> toReturn = new List<Melding>();

            try
            {
                conn = new MySqlConnection(cs);
                conn.Open();

                string stm = "SELECT * FROM Melding WHERE klantid = " + klantid.ToString();
                MySqlCommand cmd = new MySqlCommand(stm, conn);
                rdr = cmd.ExecuteReader();

                while (rdr.Read())
                {
                    meldingnummrs.Add(rdr.GetInt32(0));
                    klantids.Add(rdr.GetInt32(1));
                    statussen.Add(rdr.GetInt32(2));
                    meldingtypes.Add(rdr.GetInt16(3));
                    datas.Add(rdr.GetString(4));
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
                Melding toAdd = new Melding();
                toAdd.klantid = a;
                toAdd.meldingnummer = meldingnummrs[i];
                toAdd.status = statussen[i];
                toAdd.meldingtype = meldingtypes[i];
                toAdd.data = datas[i];
                toReturn.Add(toAdd);
                i++;
            }


            return toReturn;
        }

        public Verbruik getVerbruik(int klantid = -1)
        {
            if (klantid == -1) { klantid = Mainframe.currentLoggedIn.klantid; }

            Verbruik toReturn = new Verbruik();

            try
            {
                conn = new MySqlConnection(cs);
                conn.Open();

                string stm = "SELECT * FROM Verbruik WHERE klantid = " + klantid.ToString(); ;
                MySqlCommand cmd = new MySqlCommand(stm, conn);
                rdr = cmd.ExecuteReader();

                while (rdr.Read())
                {
                    toReturn.klantid = rdr.GetInt32(0);
                    toReturn.meterstand = rdr.GetInt32(1);
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

        public Klacht getKlacht(int klachtid)
        {
            Klacht toReturn = new Klacht();

            try
            {
                conn = new MySqlConnection(cs);
                conn.Open();

                string stm = "SELECT * FROM Klacht WHERE klachtid = " + klachtid.ToString(); ;
                MySqlCommand cmd = new MySqlCommand(stm, conn);
                rdr = cmd.ExecuteReader();

                while (rdr.Read())
                {
                    toReturn.klachtid = rdr.GetInt32(0);
                    toReturn.klantid = rdr.GetInt32(1);
                    toReturn.klachttype = rdr.GetInt32(2);
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

        public List<Klacht> getAllKlachten()
        {
            List<int> klachtids = new List<int>();
            List<int> klantids = new List<int>();
            List<int> klachttypes = new List<int>();
            List<string> datas = new List<string>();
            List<Klacht> toReturn = new List<Klacht>();

            try
            {
                conn = new MySqlConnection(cs);
                conn.Open();

                string stm = "SELECT * FROM Klacht";
                MySqlCommand cmd = new MySqlCommand(stm, conn);
                rdr = cmd.ExecuteReader();

                while (rdr.Read())
                {
                    klachtids.Add(rdr.GetInt32(0));
                    klantids.Add(rdr.GetInt32(1));
                    klachttypes.Add(rdr.GetInt32(2));
                    datas.Add(rdr.GetString(4));
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
                Klacht toAdd = new Klacht();
                toAdd.klantid = a;
                toAdd.klachtid = klantids[i];
                toAdd.klachttype = klachttypes[i];
                toAdd.data = datas[i];
                toReturn.Add(toAdd);
                i++;
            }


            return toReturn;
        }

        public List<Klacht> getAllKlachtenVanKlant(int klantid = -1)
        {
            if (klantid == -1) { klantid = Mainframe.currentLoggedIn.klantid; }

            List<int> klachtids = new List<int>();
            List<int> klantids = new List<int>();
            List<int> klachttypes = new List<int>();
            List<string> datas = new List<string>();
            List<Klacht> toReturn = new List<Klacht>();

            try
            {
                conn = new MySqlConnection(cs);
                conn.Open();

                string stm = "SELECT * FROM Klacht WHERE klantid = " + klantid.ToString(); ;
                MySqlCommand cmd = new MySqlCommand(stm, conn);
                rdr = cmd.ExecuteReader();

                while (rdr.Read())
                {
                    klachtids.Add(rdr.GetInt32(0));
                    klantids.Add(rdr.GetInt32(1));
                    klachttypes.Add(rdr.GetInt32(2));
                    datas.Add(rdr.GetString(4));
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
                Klacht toAdd = new Klacht();
                toAdd.klantid = a;
                toAdd.klachtid = klantids[i];
                toAdd.klachttype = klachttypes[i];
                toAdd.data = datas[i];
                toReturn.Add(toAdd);
                i++;
            }


            return toReturn;
        }

        //=============================================================

        public void pushKlant(Klant usr)
        {
            string stm = "INSERT INTO Klant (email, wachtwoord, voornaam, tussenvoegsel, achternaam, geboortedatum, telefoonnummer) VALUES('"+usr.email + "','" + usr.wachtwoord+"','"+usr.voornaam + "','" +usr.tussenvoegsel
                + "','" +usr.achternaam + "','" +usr.geboortedatum + "','" +usr.telefoonnummer+"')";

            conn = new MySqlConnection(cs);
            conn.Open();

            MySqlCommand cmd = new MySqlCommand(stm, conn);
            cmd.ExecuteNonQuery();
        }

        public void pushAanvraag(Aanvraag aanvraag)
        {
            string stm = "INSERT INTO Aanvraag (aanvraagtype, klantid, data) VALUES('" + aanvraag.aanvraagtype + "','" + aanvraag.klantid + "','" + aanvraag.data + "')";

            conn = new MySqlConnection(cs);
            conn.Open();

            MySqlCommand cmd = new MySqlCommand(stm, conn);
            cmd.ExecuteNonQuery();
        }

        public void pushBelmoment(Belmoment belmoment)
        {
            string stm = "INSERT INTO Belmoment (klantid, tijstip, datum, status, notitie) VALUES('" + belmoment.klantid + "','" + belmoment.tijdstip + "','" + belmoment.datum + "','" +
                belmoment.status + "','" + belmoment.notitie + "')";

            conn = new MySqlConnection(cs);
            conn.Open();

            MySqlCommand cmd = new MySqlCommand(stm, conn);
            cmd.ExecuteNonQuery();
        }

        public void pushFactuur(Factuur factuur)
        {
            string stm = "INSERT INTO Factuur (rekeningnummer, periode, klantid, kosten, status, meterstand) VALUES('" + factuur.rekeningnummer + "','" + factuur.periode + "','" +
                factuur.klantid + "','" + factuur.kosten + "','" + factuur.status + "','" + factuur.meterstand + "')";

            conn = new MySqlConnection(cs);
            conn.Open();

            MySqlCommand cmd = new MySqlCommand(stm, conn);
            cmd.ExecuteNonQuery();
        }

        public void pushKlacht(Klacht klacht)
        {
            string stm = "INSERT INTO Klacht (klantid, klachttype, data) VALUES('" + klacht.klantid + "','" + klacht.klachttype + "','" + klacht.data + "')";

            conn = new MySqlConnection(cs);
            conn.Open();

            MySqlCommand cmd = new MySqlCommand(stm, conn);
            cmd.ExecuteNonQuery();
        }

        public void pushKlantAbonnement(KlantAbonnement ka)
        {
            string stm = "INSERT INTO KlantAbonnement (klantid, abonnementid) VALUES('" + ka.klantid + "','" + ka.abonnementid + "')";

            conn = new MySqlConnection(cs);
            conn.Open();

            MySqlCommand cmd = new MySqlCommand(stm, conn);
            cmd.ExecuteNonQuery();
        }

        public void pushMelding(Melding melding)
        {
            string stm = "INSERT INTO Melding (klantid, status, meldingtype, data) VALUES('" + melding.klantid + "','" + melding.status + "','" +
                melding.meldingtype + "','" + melding.data + "')";

            conn = new MySqlConnection(cs);
            conn.Open();

            MySqlCommand cmd = new MySqlCommand(stm, conn);
            cmd.ExecuteNonQuery();
        }

        public void pushVerbruik(Verbruik verbruik)
        {
            string stm = "INSERT INTO Verbruik (klantid, meterstand) VALUES('" + verbruik.klantid + "','" + verbruik.meterstand + "')";

            conn = new MySqlConnection(cs);
            conn.Open();

            MySqlCommand cmd = new MySqlCommand(stm, conn);
            cmd.ExecuteNonQuery();
        }
    }
}
