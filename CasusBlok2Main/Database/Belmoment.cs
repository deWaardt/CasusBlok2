using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CasusBlok2Main.Database
{
    class Belmoment
    {
        public int belmomentid { get; set; }
        public string tijdstip { get; set; } //moet datetime worden
        public string datum { get; set; }  //moet datetime worden
        public int status { get; set; }
        public int klantid { get; set; }
        public string data { get; set; }
    }
}
