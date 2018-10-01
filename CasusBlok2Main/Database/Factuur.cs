using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CasusBlok2Main.Database
{
    class Factuur
    {
        public int factuurnummer { get; set; }
        public int rekeningnummer { get; set; }
        public string periode { get; set; } //ander objecttype bedenken
        public int klantid { get; set; }
        public int status { get; set; }
        public int meterstand { get; set; }
    }
}
