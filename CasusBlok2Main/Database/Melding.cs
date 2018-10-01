using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CasusBlok2Main.Database
{
    class Melding
    {
        public int meldingnummer { get; set; }
        public int klantid { get; set; }
        public int status { get; set; }
        public int meldingtype { get; set; }
        public string data { get; set; }
    }
}
