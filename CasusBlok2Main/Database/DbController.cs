using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data;
using MySql.Data.MySqlClient;

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

                string stm = "SELECT * FROM Klant WHERE email = '"+usrname+"'";
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
            if(klantid.Count == 0)
            {
                throw new Exception("No user found");
                Klant nullReturn = new Klant();
                return nullReturn;
            }

            Klant toReturn = new Klant { klantid = klantid[0],
                                         email = email[0],
                                         wachtwoord = wachtwoord[0],
                                         voornaam = voornaam[0],
                                         tussenvoegsel = tussenvoegsel[0],
                                         achternaam = achternaam[0],
                                         geboortedatum = geboortedatum[0],
                                         telefoonnummer = telefoonnummer[0]};
            return toReturn;
        }

        void doSqlThings(string stm)
        {

        }
    }
}
