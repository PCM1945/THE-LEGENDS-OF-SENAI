using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Legends_lib
{
    public class Mapa
    {
        public Casa[][] casa { get; set; } //Item está na casa
        public int DimX { get; set; }
        //FON
        public int DimY { get; set; }
        
       public Mapa()
        {
            this.DimX = 20;
            this.DimX = 20;
        }
    }
}
