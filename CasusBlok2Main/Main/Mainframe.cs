﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CasusBlok2Main.Database;

namespace CasusBlok2Main.Main
{
    static class Mainframe
    {
        //DbController db = new DbController();
        public static User currentLoggedIn;

        //public void processLogin()
        //{

        //}

        public static void whoLoggedIn()
        {
            Console.WriteLine("Current logged in user: " + currentLoggedIn.firstName);
        }
    }
}
