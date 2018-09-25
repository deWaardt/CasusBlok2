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
        public string cs = @"server=192.168.0.110;port=3306;userid=admin;
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

        public User getUser(string usrname)
        {
            List<string> username = new List<string>();
            List<string> password = new List<string>();
            List<string> firstname = new List<string>();

            try
            {
                conn = new MySqlConnection(cs);
                conn.Open();

                string stm = "SELECT * FROM Users WHERE username = '"+usrname+"'";
                MySqlCommand cmd = new MySqlCommand(stm, conn);
                rdr = cmd.ExecuteReader();

                while (rdr.Read())
                {
                    //Console.WriteLine(rdr.GetString(1));
                    username.Add(rdr.GetString(0));
                    password.Add(rdr.GetString(1));
                    firstname.Add(rdr.GetString(2));

                }

            }
            catch (MySqlException ex) { Console.WriteLine("Error: {0}", ex.ToString()); throw new Exception(); }
            finally
            {
                if (rdr != null) { rdr.Close(); }
                if (conn != null) { conn.Close(); }
            }
            if(username.Count == 0)
            {
                throw new Exception("No user found");
                User nullReturn = new User();
                return nullReturn;
            }
            
            User toReturn = new User { userName = username[0], password = password[0], firstName = firstname[0] };
            return toReturn;
        }

        void doSqlThings(string stm)
        {

        }
    }
}
