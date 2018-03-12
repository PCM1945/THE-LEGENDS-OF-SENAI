using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Legends_lib.maps.mapa_geral.Controls
{
    public static class calcCasa
    {
        public static int getPosCasa(int coord)
        {
            int count=0;
            int pos=0;
            while (true)
            {
                if(pos<=coord && pos + 40 > coord)
                {
                    break;
                }
                else
                {
                    count++;
                }
            }
            return count;
        }
    }
}
