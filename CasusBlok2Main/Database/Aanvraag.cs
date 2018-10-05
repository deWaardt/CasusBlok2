using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CasusBlok2Main.Database
{
    class Aanvraag
    {
        public int aanvraagnummer { get; set; }
        public int aanvraagtype { get; set; }
        public int klantid { get; set; }
        public string data { get; set; }
    }
}
