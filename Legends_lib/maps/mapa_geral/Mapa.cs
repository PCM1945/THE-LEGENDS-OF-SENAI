using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Legends_lib
{ 
    public class Mapa
    {
        public IEnumerable<Casa> Casa { get; set; } //Item está na casa
        public int DimX { get; set; }
        public int DimY { get; set; }

    }
}
