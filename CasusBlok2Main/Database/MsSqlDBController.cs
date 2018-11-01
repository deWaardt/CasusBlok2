using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CasusBlok2Main.Main;
using System.Data;
using System.Data.SqlClient;

namespace CasusBlok2Main.Database
{
    class MsSqlDBController
    {
        //public string cs = @"server=84.28.62.177;port=33060;userid=admin;
        //    password=casus;database=casusblok2;sslmode=none;";
        public string cs = "Server = 84.28.62.177,33061; Database = casusge; User Id = Admin; Password = CasusBlok2@";



        public SqlDataReader msrdr = null;
        public SqlConnection cnn = null;

        public MsSqlDBController()
        {
            bool connection = testConnection();
            if (connection == false) { Console.WriteLine("No connection could be made!"); }
            else { Console.WriteLine("Succesfully connected."); }
        }

        public void TestMS()
        {
            try
            {

                cnn = new SqlConnection(cs);
                cnn.Open();

                string stm = "SELECT * FROM Klant";
                SqlCommand mscmd = new SqlCommand(stm, cnn);
                msrdr = mscmd.ExecuteReader();

                while (msrdr.Read())
                {
                    Console.WriteLine(msrdr[2]);
                }
            }
            catch (SqlException ex)
            {
                Console.WriteLine("SQL Exception occured");
            }
            finally
            {
                if (msrdr != null) { msrdr.Close(); }
                if (cnn != null) { cnn.Close(); }
            }
        }

        bool testConnection()
        {
            try
            {
                cnn = new SqlConnection(cs);
                cnn.Open();

                string stm = "SELECT * FROM Klant";
                SqlCommand mscmd = new SqlCommand(stm, cnn);
                msrdr = mscmd.ExecuteReader();

                while (msrdr.Read())
                {
                }

            }
            catch (SqlException ex)
            {
                return false;
            }
            finally
            {
                if (msrdr != null) { msrdr.Close(); }
                if (cnn != null) { cnn.Close(); }
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
                cnn = new SqlConnection(cs);
                cnn.Open();

                string stm = "SELECT * FROM Users";
                SqlCommand mscmd = new SqlCommand(stm, cnn);
                msrdr = mscmd.ExecuteReader();

                while (msrdr.Read())
                {
                    //Console.WriteLine(msrdr.GetString(1));
                    column1.Add(msrdr.GetString(0));
                    column2.Add(msrdr.GetString(1));
                    column3.Add(msrdr.GetString(2));

                }

            }
            catch (SqlException ex)
            {
                Console.WriteLine("Error: {0}", ex.ToString());

            }
            finally
            {
                if (msrdr != null)
                {
                    msrdr.Close();
                }

                if (cnn != null)
                {
                    cnn.Close();
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
                cnn = new SqlConnection(cs);
                cnn.Open();

                string stm = "SELECT * FROM Users";
                SqlCommand mscmd = new SqlCommand(stm, cnn);
                msrdr = mscmd.ExecuteReader();

                while (msrdr.Read())
                {
                    //Console.WriteLine(msrdr.GetString(1));
                    column1.Add(msrdr.GetString(0));
                    column2.Add(msrdr.GetString(1));
                    column3.Add(msrdr.GetString(2));

                }

            }
            catch (SqlException ex) { Console.WriteLine("Error: {0}", ex.ToString()); }
            finally
            {
                if (msrdr != null) { msrdr.Close(); }
                if (cnn != null) { cnn.Close(); }
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
                cnn = new SqlConnection(cs);
                cnn.Open();

                string stm = "SELECT * FROM Klant WHERE email = '" + usrname + "'";
                SqlCommand mscmd = new SqlCommand(stm, cnn);
                msrdr = mscmd.ExecuteReader();

                while (msrdr.Read())
                {
                    //console.writeline(msrdr.getstring(1));
                    toReturn.klantid = (msrdr.GetInt32(0));
                    toReturn.email = (msrdr.GetString(1));
                    toReturn.wachtwoord = (msrdr.GetString(2));
                    toReturn.voornaam = (msrdr.GetString(3));
                    toReturn.tussenvoegsel = (msrdr.GetString(4));
                    toReturn.achternaam = (msrdr.GetString(5));
                    toReturn.geboortedatum = (msrdr.GetString(6));
                    toReturn.telefoonnummer = (msrdr.GetString(7));

                }

            }
            catch (SqlException ex) { Console.WriteLine("Error: {0}", ex.ToString()); throw new Exception(); }
            finally
            {
                if (msrdr != null) { msrdr.Close(); }
                if (cnn != null) { cnn.Close(); }
            }


            return toReturn;
        }

        public Klant getUserByID(int usr)
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
                cnn = new SqlConnection(cs);
                cnn.Open();

                string stm = "SELECT * FROM Klant WHERE klantid = '" + usr.ToString() + "'";
                SqlCommand mscmd = new SqlCommand(stm, cnn);
                msrdr = mscmd.ExecuteReader();

                while (msrdr.Read())
                {
                    //console.writeline(msrdr.getstring(1));
                    toReturn.klantid = (msrdr.GetInt32(0));
                    toReturn.email = (msrdr.GetString(1));
                    toReturn.wachtwoord = (msrdr.GetString(2));
                    toReturn.voornaam = (msrdr.GetString(3));
                    toReturn.tussenvoegsel = (msrdr.GetString(4));
                    toReturn.achternaam = (msrdr.GetString(5));
                    toReturn.geboortedatum = (msrdr.GetString(6));
                    toReturn.telefoonnummer = (msrdr.GetString(7));

                }

            }
            catch (SqlException ex) { Console.WriteLine("Error: {0}", ex.ToString()); throw new Exception(); }
            finally
            {
                if (msrdr != null) { msrdr.Close(); }
                if (cnn != null) { cnn.Close(); }
            }


            return toReturn;
        }

        public Medewerker getMedewerker(string usrname)
        {
            //List<int> klantid = new List<int>();
            //List<string> email = new List<string>();
            //List<string> wachtwoord = new List<string>();
            //List<string> voornaam = new List<string>();
            //List<string> tussenvoegsel = new List<string>();
            //List<string> achternaam = new List<string>();
            //List<string> geboortedatum = new List<string>();
            //List<string> telefoonnummer = new List<string>();
            Medewerker toReturn = new Medewerker();

            try
            {
                cnn = new SqlConnection(cs);
                cnn.Open();

                string stm = "SELECT * FROM Medewerker WHERE email = '" + usrname + "'";
                SqlCommand mscmd = new SqlCommand(stm, cnn);
                msrdr = mscmd.ExecuteReader();

                while (msrdr.Read())
                {
                    //console.writeline(msrdr.getstring(1));
                    toReturn.medewerkerid = (msrdr.GetInt32(0));
                    toReturn.email = (msrdr.GetString(1));
                    toReturn.wachtwoord = (msrdr.GetString(2));
                    toReturn.voornaam = (msrdr.GetString(3));
                    toReturn.tussenvoegsel = (msrdr.GetString(4));
                    toReturn.achternaam = (msrdr.GetString(5));
                    toReturn.geboortedatum = (msrdr.GetString(6));
                    toReturn.telefoonnummer = (msrdr.GetString(7));

                }

            }
            catch (SqlException ex) { Console.WriteLine("Error: {0}", ex.ToString()); throw new Exception(); }
            finally
            {
                if (msrdr != null) { msrdr.Close(); }
                if (cnn != null) { cnn.Close(); }
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
                cnn = new SqlConnection(cs);
                cnn.Open();

                string stm = "SELECT * FROM Aanvraag WHERE aanvraagnummer = " + aanvraagnr.ToString(); ;
                SqlCommand mscmd = new SqlCommand(stm, cnn);
                msrdr = mscmd.ExecuteReader();

                while (msrdr.Read())
                {
                    toReturn.aanvraagnummer = msrdr.GetInt32(0);
                    toReturn.aanvraagtype = msrdr.GetInt32(1);
                    toReturn.klantid = msrdr.GetInt32(2);
                    toReturn.data = msrdr.GetString(3);
                    toReturn.datum = msrdr.GetString(4);
                    toReturn.status = msrdr.GetInt32(5);
                }

            }
            catch (SqlException ex)
            {
                throw ex;
                //return null;
            }
            finally
            {
                if (msrdr != null) { msrdr.Close(); }
                if (cnn != null) { cnn.Close(); }
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
            List<string> datums = new List<string>();
            List<int> statussen = new List<int>();
            List<Aanvraag> toReturn = new List<Aanvraag>();

            try
            {
                cnn = new SqlConnection(cs);
                cnn.Open();

                string stm = "SELECT * FROM Aanvraag WHERE klantid = " + klantid;
                SqlCommand mscmd = new SqlCommand(stm, cnn);
                msrdr = mscmd.ExecuteReader();

                while (msrdr.Read())
                {
                    aanvraagnummers.Add(msrdr.GetInt32(0));
                    aanvraagtypes.Add(msrdr.GetInt32(1));
                    klantids.Add(msrdr.GetInt32(2));
                    datas.Add(msrdr.GetString(3));
                    datums.Add(msrdr.GetString(4));
                    statussen.Add(msrdr.GetInt32(5));
                }

            }
            catch (SqlException ex)
            {
                throw ex;
                //return null;
            }
            finally
            {
                if (msrdr != null) { msrdr.Close(); }
                if (cnn != null) { cnn.Close(); }
            }

            int i = 0;
            foreach (int a in aanvraagnummers)
            {
                Aanvraag toAdd = new Aanvraag();
                toAdd.aanvraagnummer = aanvraagnummers[i];
                toAdd.aanvraagtype = aanvraagtypes[i];
                toAdd.klantid = klantids[i];
                toAdd.data = datas[i];
                toAdd.datum = datums[i];
                toAdd.status = statussen[i];
                toReturn.Add(toAdd);
                i++;
            }


            return toReturn;
        }
        public List<Aanvraag> getAllAanvragen()
        {
            List<int> aanvraagnummers = new List<int>();
            List<int> aanvraagtypes = new List<int>();
            List<int> klantids = new List<int>();
            List<string> datas = new List<string>();
            List<string> datums = new List<string>();
            List<int> statussen = new List<int>();
            List<Aanvraag> toReturn = new List<Aanvraag>();

            try
            {
                cnn = new SqlConnection(cs);
                cnn.Open();

                string stm = "SELECT * FROM Aanvraag";
                SqlCommand mscmd = new SqlCommand(stm, cnn);
                msrdr = mscmd.ExecuteReader();

                while (msrdr.Read())
                {
                    aanvraagnummers.Add(msrdr.GetInt32(0));
                    aanvraagtypes.Add(msrdr.GetInt32(1));
                    klantids.Add(msrdr.GetInt32(2));
                    datas.Add(msrdr.GetString(3));
                    datums.Add(msrdr.GetString(4));
                    statussen.Add(msrdr.GetInt32(5));
                }

            }
            catch (SqlException ex)
            {
                throw ex;
                //return null;
            }
            finally
            {
                if (msrdr != null) { msrdr.Close(); }
                if (cnn != null) { cnn.Close(); }
            }

            int i = 0;
            foreach (int a in aanvraagnummers)
            {
                Aanvraag toAdd = new Aanvraag();
                toAdd.aanvraagnummer = aanvraagnummers[i];
                toAdd.aanvraagtype = aanvraagtypes[i];
                toAdd.klantid = klantids[i];
                toAdd.data = datas[i];
                toAdd.datum = datums[i];
                toAdd.status = statussen[i];
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
                cnn = new SqlConnection(cs);
                cnn.Open();

                string stm = "SELECT * FROM Abonnement WHERE abonnementid = " + abonnementid.ToString(); ;
                SqlCommand mscmd = new SqlCommand(stm, cnn);
                msrdr = mscmd.ExecuteReader();

                while (msrdr.Read())
                {
                    toReturn.abonnementid = msrdr.GetInt32(0);
                    toReturn.naam = msrdr.GetString(1);
                    toReturn.prijs = msrdr.GetInt32(2);
                    toReturn.type = msrdr.GetInt32(3);
                }

            }
            catch (SqlException ex)
            {
                throw ex;
                //return null;
            }
            finally
            {
                if (msrdr != null) { msrdr.Close(); }
                if (cnn != null) { cnn.Close(); }
            }
            return toReturn;

        }

        public List<Belmoment> getAllBelmomentenVanKlant(int klantid = -1)
        {
            if (klantid == -1) { klantid = Mainframe.currentLoggedIn.klantid; }

            List<int> belmomentids = new List<int>();
            List<string> tijdstippen = new List<string>();
            List<string> datums = new List<string>();
            List<int> statussen = new List<int>();
            List<int> klantids = new List<int>();
            List<string> datas = new List<string>();
            List<Belmoment> toReturn = new List<Belmoment>();

            try
            {
                cnn = new SqlConnection(cs);
                cnn.Open();

                string stm = "SELECT * FROM Belmoment WHERE klantid = " + klantid;
                SqlCommand mscmd = new SqlCommand(stm, cnn);
                msrdr = mscmd.ExecuteReader();

                while (msrdr.Read())
                {
                    belmomentids.Add(msrdr.GetInt32(0));
                    tijdstippen.Add(msrdr.GetString(1));
                    datums.Add(msrdr.GetString(2));
                    statussen.Add(msrdr.GetInt32(3));
                    klantids.Add(msrdr.GetInt32(4));
                    datas.Add(msrdr.GetString(5));
                }

            }
            catch (SqlException ex)
            {
                throw ex;
                //return null;
            }
            finally
            {
                if (msrdr != null) { msrdr.Close(); }
                if (cnn != null) { cnn.Close(); }
            }

            int i = 0;
            foreach (int a in klantids)
            {
                Belmoment toAdd = new Belmoment();
                toAdd.belmomentid = belmomentids[i];
                toAdd.tijdstip = tijdstippen[i];
                toAdd.datum = datums[i];
                toAdd.status = statussen[i];
                toAdd.klantid = klantids[i];
                toAdd.data = datas[i];
                toReturn.Add(toAdd);
                i++;
            }


            return toReturn;
        }

        public List<Belmoment> getAllBelmomenten()
        {
            List<int> belmomentids = new List<int>();
            List<string> tijdstippen = new List<string>();
            List<string> datums = new List<string>();
            List<int> statussen = new List<int>();
            List<int> klantids = new List<int>();
            List<string> datas = new List<string>();
            List<Belmoment> toReturn = new List<Belmoment>();

            try
            {
                cnn = new SqlConnection(cs);
                cnn.Open();

                string stm = "SELECT * FROM Belmoment";
                SqlCommand mscmd = new SqlCommand(stm, cnn);
                msrdr = mscmd.ExecuteReader();

                while (msrdr.Read())
                {
                    belmomentids.Add(msrdr.GetInt32(0));
                    tijdstippen.Add(msrdr.GetString(1));
                    datums.Add(msrdr.GetString(2));
                    statussen.Add(msrdr.GetInt32(3));
                    klantids.Add(msrdr.GetInt32(4));
                    datas.Add(msrdr.GetString(5));
                }

            }
            catch (SqlException ex)
            {
                throw ex;
                //return null;
            }
            finally
            {
                if (msrdr != null) { msrdr.Close(); }
                if (cnn != null) { cnn.Close(); }
            }

            int i = 0;
            foreach (int a in klantids)
            {
                Belmoment toAdd = new Belmoment();
                toAdd.belmomentid = belmomentids[i];
                toAdd.tijdstip = tijdstippen[i];
                toAdd.datum = datums[i];
                toAdd.status = statussen[i];
                toAdd.klantid = klantids[i];
                toAdd.data = datas[i];
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
                cnn = new SqlConnection(cs);
                cnn.Open();

                string stm = "SELECT * FROM Factuur WHERE factuurnummer = " + factuurnummer.ToString(); ;
                SqlCommand mscmd = new SqlCommand(stm, cnn);
                msrdr = mscmd.ExecuteReader();

                while (msrdr.Read())
                {
                    toReturn.factuurnummer = msrdr.GetInt32(0);
                    toReturn.rekeningnummer = msrdr.GetInt32(1);
                    toReturn.periode = msrdr.GetString(2);
                    toReturn.klantid = msrdr.GetInt32(3);
                    toReturn.kosten = msrdr.GetInt32(4);
                    toReturn.status = msrdr.GetInt16(5);
                    toReturn.meterstand = msrdr.GetInt32(6);
                }

            }
            catch (SqlException ex)
            {
                throw ex;
                //return null;
            }
            finally
            {
                if (msrdr != null) { msrdr.Close(); }
                if (cnn != null) { cnn.Close(); }
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
            List<int> kostenen = new List<int>();
            List<int> statussen = new List<int>();
            List<int> meterstanden = new List<int>();
            List<Factuur> toReturn = new List<Factuur>();

            try
            {
                cnn = new SqlConnection(cs);
                cnn.Open();

                string stm = "SELECT * FROM Factuur WHERE klantid = " + klantid;
                SqlCommand mscmd = new SqlCommand(stm, cnn);
                msrdr = mscmd.ExecuteReader();

                while (msrdr.Read())
                {
                    factuurnummers.Add(msrdr.GetInt32(0));
                    rekeningnummers.Add(msrdr.GetInt32(1));
                    periodes.Add(msrdr.GetString(2));
                    klantids.Add(msrdr.GetInt16(3));
                    kostenen.Add(msrdr.GetInt32(4));
                    statussen.Add(msrdr.GetInt32(5));
                    meterstanden.Add(msrdr.GetInt32(6));
                }

            }
            catch (SqlException ex)
            {
                throw ex;
                //return null;
            }
            finally
            {
                if (msrdr != null) { msrdr.Close(); }
                if (cnn != null) { cnn.Close(); }
            }

            int i = 0;
            foreach (int a in klantids)
            {
                Factuur toAdd = new Factuur();
                toAdd.klantid = a;
                toAdd.kosten = kostenen[i];
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
                cnn = new SqlConnection(cs);
                cnn.Open();

                string stm = "SELECT * FROM KlantAbonnement WHERE klantid = " + klantid.ToString(); ;
                SqlCommand mscmd = new SqlCommand(stm, cnn);
                msrdr = mscmd.ExecuteReader();

                while (msrdr.Read())
                {
                    link.klantid = msrdr.GetInt32(0);
                    link.abonnementid = msrdr.GetInt32(1);
                }

            }
            catch (SqlException ex)
            {
                throw ex;
                //return null;
            }
            finally
            {
                if (msrdr != null) { msrdr.Close(); }
                if (cnn != null) { cnn.Close(); }
            }

            try
            {
                cnn = new SqlConnection(cs);
                cnn.Open();

                string stm = "SELECT * FROM Abonnement WHERE abonnementid = " + link.abonnementid.ToString(); ;
                SqlCommand mscmd = new SqlCommand(stm, cnn);
                msrdr = mscmd.ExecuteReader();

                while (msrdr.Read())
                {
                    toReturn.abonnementid = msrdr.GetInt32(0);
                    toReturn.naam = msrdr.GetString(1);
                    toReturn.prijs = msrdr.GetInt32(2);
                    toReturn.type = msrdr.GetInt32(3);
                }

            }
            catch (SqlException ex)
            {
                throw ex;
                //return null;
            }
            finally
            {
                if (msrdr != null) { msrdr.Close(); }
                if (cnn != null) { cnn.Close(); }
            }




            return toReturn;
        }

        public Melding getMelding(int meldingnummer)
        {
            Melding toReturn = new Melding();

            try
            {
                cnn = new SqlConnection(cs);
                cnn.Open();

                string stm = "SELECT * FROM Melding WHERE meldingnummer = " + meldingnummer.ToString(); ;
                SqlCommand mscmd = new SqlCommand(stm, cnn);
                msrdr = mscmd.ExecuteReader();

                while (msrdr.Read())
                {
                    toReturn.meldingnummer = msrdr.GetInt32(0);
                    toReturn.klantid = msrdr.GetInt32(1);
                    toReturn.status = msrdr.GetInt32(2);
                    toReturn.meldingtype = msrdr.GetInt32(3);
                    toReturn.data = msrdr.GetString(4);
                    toReturn.datum = msrdr.GetString(5);
                }

            }
            catch (SqlException ex)
            {
                throw ex;
                //return null;
            }
            finally
            {
                if (msrdr != null) { msrdr.Close(); }
                if (cnn != null) { cnn.Close(); }
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
            List<string> datums = new List<string>();
            List<Melding> toReturn = new List<Melding>();

            try
            {
                cnn = new SqlConnection(cs);
                cnn.Open();

                string stm = "SELECT * FROM Melding";
                SqlCommand mscmd = new SqlCommand(stm, cnn);
                msrdr = mscmd.ExecuteReader();

                while (msrdr.Read())
                {
                    meldingnummrs.Add(msrdr.GetInt32(0));
                    klantids.Add(msrdr.GetInt32(1));
                    statussen.Add(msrdr.GetInt32(2));
                    meldingtypes.Add(msrdr.GetInt16(3));
                    datas.Add(msrdr.GetString(4));
                    datums.Add(msrdr.GetString(5));
                }

            }
            catch (SqlException ex)
            {
                throw ex;
                //return null;
            }
            finally
            {
                if (msrdr != null) { msrdr.Close(); }
                if (cnn != null) { cnn.Close(); }
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
                toAdd.datum = datums[i];
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
            List<string> datums = new List<string>();
            List<Melding> toReturn = new List<Melding>();

            try
            {
                cnn = new SqlConnection(cs);
                cnn.Open();

                string stm = "SELECT * FROM Melding WHERE klantid = " + klantid.ToString();
                SqlCommand mscmd = new SqlCommand(stm, cnn);
                msrdr = mscmd.ExecuteReader();

                while (msrdr.Read())
                {
                    meldingnummrs.Add(msrdr.GetInt32(0));
                    klantids.Add(msrdr.GetInt32(1));
                    statussen.Add(msrdr.GetInt32(2));
                    meldingtypes.Add(msrdr.GetInt16(3));
                    datas.Add(msrdr.GetString(4));
                    datums.Add(msrdr.GetString(5));
                }

            }
            catch (SqlException ex)
            {
                throw ex;
                //return null;
            }
            finally
            {
                if (msrdr != null) { msrdr.Close(); }
                if (cnn != null) { cnn.Close(); }
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
                toAdd.data = datums[i];
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
                cnn = new SqlConnection(cs);
                cnn.Open();

                string stm = "SELECT * FROM Verbruik WHERE klantid = " + klantid.ToString(); ;
                SqlCommand mscmd = new SqlCommand(stm, cnn);
                msrdr = mscmd.ExecuteReader();

                while (msrdr.Read())
                {
                    toReturn.klantid = msrdr.GetInt32(0);
                    toReturn.meterstand = msrdr.GetInt32(1);
                }

            }
            catch (SqlException ex)
            {
                throw ex;
                //return null;
            }
            finally
            {
                if (msrdr != null) { msrdr.Close(); }
                if (cnn != null) { cnn.Close(); }
            }


            return toReturn;
        }

        public KlantAbonnement getKlantAbonnementVanKlant(int klantid)
        {
            KlantAbonnement toReturn = new KlantAbonnement();

            try
            {
                cnn = new SqlConnection(cs);
                cnn.Open();

                string stm = "SELECT * FROM KlantAbonnement WHERE klantid = " + klantid.ToString(); ;
                SqlCommand mscmd = new SqlCommand(stm, cnn);
                msrdr = mscmd.ExecuteReader();

                while (msrdr.Read())
                {
                    toReturn.klantid = msrdr.GetInt32(0);
                    toReturn.abonnementid = msrdr.GetInt32(1);
                }

            }
            catch (SqlException ex)
            {
                throw ex;
                //return null;
            }
            finally
            {
                if (msrdr != null) { msrdr.Close(); }
                if (cnn != null) { cnn.Close(); }
            }


            return toReturn;
        }

        public Klacht getKlacht(int klachtid)
        {
            Klacht toReturn = new Klacht();

            try
            {
                cnn = new SqlConnection(cs);
                cnn.Open();

                string stm = "SELECT * FROM Klacht WHERE klachtid = " + klachtid.ToString(); ;
                SqlCommand mscmd = new SqlCommand(stm, cnn);
                msrdr = mscmd.ExecuteReader();

                while (msrdr.Read())
                {
                    toReturn.klachtid = msrdr.GetInt32(0);
                    toReturn.klantid = msrdr.GetInt32(1);
                    toReturn.klachttype = msrdr.GetInt32(2);
                    toReturn.data = msrdr.GetString(3);
                    toReturn.datum = msrdr.GetString(4);
                    toReturn.status = msrdr.GetInt32(5);
                }

            }
            catch (SqlException ex)
            {
                throw ex;
                //return null;
            }
            finally
            {
                if (msrdr != null) { msrdr.Close(); }
                if (cnn != null) { cnn.Close(); }
            }


            return toReturn;
        }

        public List<Klacht> getAllKlachten()
        {
            List<int> klachtids = new List<int>();
            List<int> klantids = new List<int>();
            List<int> klachttypes = new List<int>();
            List<string> datas = new List<string>();
            List<string> datums = new List<string>();
            List<int> statussen = new List<int>();
            List<Klacht> toReturn = new List<Klacht>();

            try
            {
                cnn = new SqlConnection(cs);
                cnn.Open();

                string stm = "SELECT * FROM Klacht";
                SqlCommand mscmd = new SqlCommand(stm, cnn);
                msrdr = mscmd.ExecuteReader();

                while (msrdr.Read())
                {
                    klachtids.Add(msrdr.GetInt32(0));
                    klantids.Add(msrdr.GetInt32(1));
                    klachttypes.Add(msrdr.GetInt32(2));
                    datas.Add(msrdr.GetString(3));
                    datums.Add(msrdr.GetString(4));
                    statussen.Add(msrdr.GetInt32(5));
                }

            }
            catch (SqlException ex)
            {
                throw ex;
                //return null;
            }
            finally
            {
                if (msrdr != null) { msrdr.Close(); }
                if (cnn != null) { cnn.Close(); }
            }

            int i = 0;
            foreach (int a in klachtids)
            {
                Klacht toAdd = new Klacht();
                toAdd.klachtid = klachtids[i];
                toAdd.klantid = klantids[i];
                toAdd.klachttype = klachttypes[i];
                toAdd.data = datas[i];
                toAdd.datum = datums[i];
                toAdd.status = statussen[i];
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
            List<string> datums = new List<string>();
            List<int> statussen = new List<int>();
            List<Klacht> toReturn = new List<Klacht>();

            try
            {
                cnn = new SqlConnection(cs);
                cnn.Open();

                string stm = "SELECT * FROM Klacht WHERE klantid = " + klantid.ToString(); ;
                SqlCommand mscmd = new SqlCommand(stm, cnn);
                msrdr = mscmd.ExecuteReader();

                while (msrdr.Read())
                {
                    klachtids.Add(msrdr.GetInt32(0));
                    klantids.Add(msrdr.GetInt32(1));
                    klachttypes.Add(msrdr.GetInt32(2));
                    datas.Add(msrdr.GetString(3));
                    datums.Add(msrdr.GetString(4));
                    statussen.Add(msrdr.GetInt32(5));
                }

            }
            catch (SqlException ex)
            {
                throw ex;
                //return null;
            }
            finally
            {
                if (msrdr != null) { msrdr.Close(); }
                if (cnn != null) { cnn.Close(); }
            }

            int i = 0;
            foreach (int a in klantids)
            {
                Klacht toAdd = new Klacht();
                toAdd.klachtid = klachtids[i];
                toAdd.klantid = klantids[i];
                toAdd.klachttype = klachttypes[i];
                toAdd.data = datas[i];
                toAdd.datum = datums[i];
                toAdd.status = statussen[i];
                toReturn.Add(toAdd);
            }


            return toReturn;
        }

        //=============================================================

        public void pushKlant(Klant usr)
        {
            string stm = "INSERT INTO Klant (email, wachtwoord, voornaam, tussenvoegsel, achternaam, geboortedatum, telefoonnummer) VALUES('" + usr.email + "','" + usr.wachtwoord + "','" + usr.voornaam + "','" + usr.tussenvoegsel
                + "','" + usr.achternaam + "','" + usr.geboortedatum + "','" + usr.telefoonnummer + "')";

            cnn = new SqlConnection(cs);
            cnn.Open();

            SqlCommand mscmd = new SqlCommand(stm, cnn);
            mscmd.ExecuteNonQuery();
        }

        public void pushMedewerker(Medewerker usr)
        {
            string stm = "INSERT INTO Medewerker (email, wachtwoord, voornaam, tussenvoegsel, achternaam, geboortedatum, telefoonnummer) VALUES('" + usr.email + "','" + usr.wachtwoord + "','" + usr.voornaam + "','" + usr.tussenvoegsel
                + "','" + usr.achternaam + "','" + usr.geboortedatum + "','" + usr.telefoonnummer + "')";

            cnn = new SqlConnection(cs);
            cnn.Open();

            SqlCommand mscmd = new SqlCommand(stm, cnn);
            mscmd.ExecuteNonQuery();
        }

        public void pushAanvraag(Aanvraag aanvraag)
        {
            string stm = "INSERT INTO Aanvraag (aanvraagtype, klantid, data,, datum, status) " +
                "VALUES('" + aanvraag.aanvraagtype + "','" + aanvraag.klantid + "','" + aanvraag.data + "," + aanvraag.datum + "," + aanvraag.status + "')";

            cnn = new SqlConnection(cs);
            cnn.Open();

            SqlCommand mscmd = new SqlCommand(stm, cnn);
            mscmd.ExecuteNonQuery();
        }

        public void pushBelmoment(Belmoment belmoment)
        {
            string stm = "INSERT INTO Belmoment (klantid, tijstip, datum, status, data) VALUES('" + belmoment.klantid + "','" + belmoment.tijdstip + "','" + belmoment.datum + "','" +
                belmoment.status + "','" + belmoment.data + "')";

            cnn = new SqlConnection(cs);
            cnn.Open();

            SqlCommand mscmd = new SqlCommand(stm, cnn);
            mscmd.ExecuteNonQuery();
        }

        public void pushFactuur(Factuur factuur)
        {
            string stm = "INSERT INTO Factuur (rekeningnummer, periode, klantid, kosten, status, meterstand) VALUES('" + factuur.rekeningnummer + "','" + factuur.periode + "','" +
                factuur.klantid + "','" + factuur.kosten + "','" + factuur.status + "','" + factuur.meterstand + "')";

            cnn = new SqlConnection(cs);
            cnn.Open();

            SqlCommand mscmd = new SqlCommand(stm, cnn);
            mscmd.ExecuteNonQuery();
        }

        public void pushKlacht(Klacht klacht)
        {
            string stm = "INSERT INTO Klacht (klantid, klachttype, data) VALUES('" + klacht.klantid + "','" + klacht.klachttype + "','" + klacht.data + "')";

            cnn = new SqlConnection(cs);
            cnn.Open();

            SqlCommand mscmd = new SqlCommand(stm, cnn);
            mscmd.ExecuteNonQuery();
        }

        public void pushKlantAbonnement(KlantAbonnement ka)
        {
            string stm = "INSERT INTO KlantAbonnement (klantid, abonnementid) VALUES('" + ka.klantid + "','" + ka.abonnementid + "')";

            cnn = new SqlConnection(cs);
            cnn.Open();

            SqlCommand mscmd = new SqlCommand(stm, cnn);
            mscmd.ExecuteNonQuery();
        }

        public void pushMelding(Melding melding)
        {
            string stm = "INSERT INTO Melding (klantid, status, meldingtype, data, datum) VALUES('" + melding.klantid + "','" + melding.status + "','" +
                melding.meldingtype + "','" + melding.data + "," + melding.datum + "')";

            cnn = new SqlConnection(cs);
            cnn.Open();

            SqlCommand mscmd = new SqlCommand(stm, cnn);
            mscmd.ExecuteNonQuery();
        }

        public void pushVerbruik(Verbruik verbruik)
        {
            string stm = "INSERT INTO Verbruik (klantid, meterstand) VALUES('" + verbruik.klantid + "','" + verbruik.meterstand + "')";

            cnn = new SqlConnection(cs);
            cnn.Open();

            SqlCommand mscmd = new SqlCommand(stm, cnn);
            mscmd.ExecuteNonQuery();
        }

        //=========================================================================================

        public void editKlant(Klant usr)
        {
            string stm = "UPDATE Klant SET email='" + usr.email + "',wachtwoord='" + usr.wachtwoord + "',voornaam='" + usr.voornaam + "',tussenvoegsel='" + usr.tussenvoegsel
                + "',achternaam='" + usr.achternaam + "',geboortedatum='" + usr.geboortedatum + "',telefoonnummer='" + usr.telefoonnummer + "' WHERE klantid = '" + usr.klantid + "'";

            cnn = new SqlConnection(cs);
            cnn.Open();

            SqlCommand mscmd = new SqlCommand(stm, cnn);
            mscmd.ExecuteNonQuery();
        }
        public void editMedewerker(Medewerker usr)
        {
            string stm = "UPDATE Medewerker SET email='" + usr.email + "',wachtwoord='" + usr.wachtwoord + "',voornaam='" + usr.voornaam + "',tussenvoegsel='" + usr.tussenvoegsel
                + "',achternaam='" + usr.achternaam + "',geboortedatum='" + usr.geboortedatum + "',telefoonnummer='" + usr.telefoonnummer + "' WHERE medewerkerid = '" + usr.medewerkerid + "'";

            cnn = new SqlConnection(cs);
            cnn.Open();

            SqlCommand mscmd = new SqlCommand(stm, cnn);
            mscmd.ExecuteNonQuery();
        }

        public void editAanvraag(Aanvraag aanvraag)
        {
            string stm = "UPDATE Aanvraag SET aanvraagtype='" + aanvraag.aanvraagtype + "',klantid='" + aanvraag.klantid + "',data='" + aanvraag.data +
                "',status='" + aanvraag.status +
                "' WHERE aanvraagnummer = '" + aanvraag.aanvraagnummer + "'";

            cnn = new SqlConnection(cs);
            cnn.Open();

            SqlCommand mscmd = new SqlCommand(stm, cnn);
            mscmd.ExecuteNonQuery();
        }

        public void editBelmoment(Belmoment belmoment)
        {
            string stm = "UPDATE Belmoment SET klantid='" + belmoment.klantid + "',tijdstip='" + belmoment.tijdstip + "',datum='" + belmoment.datum + "',status='" +
                belmoment.status + "',data='" + belmoment.data + "' WHERE (tijdstip = '" + belmoment.tijdstip + "' AND datum = '" + belmoment.datum + "' AND klantid = '" + belmoment.klantid + "')";

            cnn = new SqlConnection(cs);
            cnn.Open();

            SqlCommand mscmd = new SqlCommand(stm, cnn);
            mscmd.ExecuteNonQuery();
        }

        public void editFactuur(Factuur factuur)
        {
            string stm = "UPDATE Factuur SET rekeningnummer='" + factuur.rekeningnummer + "',periode='" + factuur.periode + "',klantid='" +
                factuur.klantid + "',kosten='" + factuur.kosten + "',status='" + factuur.status + "',meterstand='" + factuur.meterstand + "'";

            cnn = new SqlConnection(cs);
            cnn.Open();

            SqlCommand mscmd = new SqlCommand(stm, cnn);
            mscmd.ExecuteNonQuery();
        }

        public void editKlacht(Klacht klacht)
        {
            string stm = "UPDATE Klacht SET klantid='" + klacht.klantid + "',klachttype='" + klacht.klachttype + "',data='" + klacht.data + "',status='" + klacht.status +
                "' WHERE klachtid='" + klacht.klachtid + "'";

            Console.WriteLine(stm);

            cnn = new SqlConnection(cs);
            cnn.Open();

            SqlCommand mscmd = new SqlCommand(stm, cnn);
            mscmd.ExecuteNonQuery();
        }

        public void editKlantAbonnement(KlantAbonnement ka)
        {
            string stm = "UPDATE KlantAbonnement SET klantid='" + ka.klantid + "',abonnementid='" + ka.abonnementid + "' WHERE klantid='" + ka.klantid + "'";

            Console.WriteLine(stm);

            cnn = new SqlConnection(cs);
            cnn.Open();

            SqlCommand mscmd = new SqlCommand(stm, cnn);
            mscmd.ExecuteNonQuery();
        }

        public void editMelding(Melding melding)
        {
            string stm = "UPDATE Melding SET klantid='" + melding.klantid + "',status='" + melding.status + "',meldingtype='" +
                melding.meldingtype + "',data='" + melding.data + "' WHERE meldingnummer = '" + melding.meldingnummer + "'";

            cnn = new SqlConnection(cs);
            cnn.Open();

            SqlCommand mscmd = new SqlCommand(stm, cnn);
            mscmd.ExecuteNonQuery();
        }

        public void editVerbruik(Verbruik verbruik)
        {
            string stm = "UPDATE Verbruik SET meterstand='" + verbruik.meterstand + "'WHERE klantid='" + verbruik.klantid + "'";

            cnn = new SqlConnection(cs);
            cnn.Open();

            SqlCommand mscmd = new SqlCommand(stm, cnn);
            mscmd.ExecuteNonQuery();
        }

        //=========================================================================================

        public void delKlant(Klant usr)
        {
            string stm = "DELETE FROM Klant WHERE klantid ='" + usr.klantid + "'";

            cnn = new SqlConnection(cs);
            cnn.Open();

            SqlCommand mscmd = new SqlCommand(stm, cnn);
            mscmd.ExecuteNonQuery();
        }

        public void delMedewerker(Medewerker usr)
        {
            string stm = "DELETE FROM Medewerker WHERE medewerkerid ='" + usr.medewerkerid + "'";

            cnn = new SqlConnection(cs);
            cnn.Open();

            SqlCommand mscmd = new SqlCommand(stm, cnn);
            mscmd.ExecuteNonQuery();
        }

        public void delAanvraag(Aanvraag av)
        {
            string stm = "DELETE FROM Aanvraag WHERE aanvraagnummer ='" + av.aanvraagnummer + "'";

            cnn = new SqlConnection(cs);
            cnn.Open();

            SqlCommand mscmd = new SqlCommand(stm, cnn);
            mscmd.ExecuteNonQuery();
        }

        public void delBelmoment(Belmoment bel)
        {
            string stm = "DELETE FROM Belmoment WHERE tijdstip ='" + bel.tijdstip + "' AND datum='" + bel.datum + "'";

            cnn = new SqlConnection(cs);
            cnn.Open();

            SqlCommand mscmd = new SqlCommand(stm, cnn);
            mscmd.ExecuteNonQuery();
        }

        public void delFactuur(Factuur f)
        {
            string stm = "DELETE FROM Factuur WHERE factuurnummer ='" + f.factuurnummer + "'";

            cnn = new SqlConnection(cs);
            cnn.Open();

            SqlCommand mscmd = new SqlCommand(stm, cnn);
            mscmd.ExecuteNonQuery();
        }

        public void delKlachtt(Klacht k)
        {
            string stm = "DELETE FROM Klacht WHERE klachtid ='" + k.klachtid + "'";

            cnn = new SqlConnection(cs);
            cnn.Open();

            SqlCommand mscmd = new SqlCommand(stm, cnn);
            mscmd.ExecuteNonQuery();
        }

        public void delKlantAbonnement(KlantAbonnement ka)
        {
            string stm = "DELETE FROM KlantAbonnement WHERE klantid ='" + ka.klantid + "'";

            cnn = new SqlConnection(cs);
            cnn.Open();

            SqlCommand mscmd = new SqlCommand(stm, cnn);
            mscmd.ExecuteNonQuery();
        }

        public void delMelding(Melding m)
        {
            string stm = "DELETE FROM Melding WHERE meldingnummer ='" + m.meldingnummer + "'";

            cnn = new SqlConnection(cs);
            cnn.Open();

            SqlCommand mscmd = new SqlCommand(stm, cnn);
            mscmd.ExecuteNonQuery();
        }

        public void delVerbruik(Verbruik v)
        {
            string stm = "DELETE FROM Verbruik WHERE klantid ='" + v.klantid + "'";

            cnn = new SqlConnection(cs);
            cnn.Open();

            SqlCommand mscmd = new SqlCommand(stm, cnn);
            mscmd.ExecuteNonQuery();
        }
    }
}
