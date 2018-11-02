using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CasusBlok2Main.Database
{
    class Medewerker
    {
        public int medewerkerid { get; set; }
        public string email { get; set; }
        public string wachtwoord { get; set; }
        public string voornaam { get; set; }
        public string tussenvoegsel { get; set; }
        public string achternaam { get; set; }
        public string geboortedatum { get; set; }
        public string telefoonnummer { get; set; }
    }
}
