using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CasusBlok2Main.Database
{
    class Factuur
    {
        int factuurnummer { get; set; }
        int rekeningnummer { get; set; }
        string periode { get; set; } //ander objecttype bedenken
        int klantid { get; set; }
        int status { get; set; }
        int meterstand { get; set; }
    }
}
