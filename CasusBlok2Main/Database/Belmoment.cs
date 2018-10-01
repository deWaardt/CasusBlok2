using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CasusBlok2Main.Database
{
    class Belmoment
    {
        int klantid { get; set; }
        string tijdstip { get; set; } //moet datetime worden
        string datum { get; set; }  //moet datetime worden
        int status { get; set; }
        string notitie { get; set; }
    }
}
