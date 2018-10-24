using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CasusBlok2Main.Database
{
    class Klacht
    {
        public int klachtid { get; set; }
        public int klantid { get; set; }
        public int klachttype { get; set; }
        public string data { get; set; }
    }
}
