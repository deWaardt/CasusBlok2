using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CasusBlok2Main.Database
{
    class Klant
    {
        public int klantid { get; set; }
        public string email { get; set; }
        public string wachtwoord { get; set; }
        public string voornaam { get; set; }
        public string tussenvoegsel { get; set; }
        public string achternaam { get; set; }
        public string geboortedatum { get; set; }
        public string telefoonnummer { get; set; }

        // TOEGEVOEGD IN DATABASE, MOET VERWERKT WORDEN IN BETROKKEN CODE
        public string straat { get; set; }
        public string huisnummer { get; set; }
        public string toevoeging { get; set; }
        public string postcode { get; set; }
        public string woonplaats { get; set; }

    }
}
