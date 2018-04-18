using System.Collections.Generic;

namespace Legends_lib
{
    public class Movimento
    {

        /* public int DimXCasaini { get; set; }
         public int DimYCasaini { get; set; }
         public int DimXCasafim { get; set; }
         public int DimYCasafim { get; set; }

         public Movimento (int xi, int yi, int xf, int yf)
         {
             this.DimXCasaini = xi;
             this.DimYCasaini = yi;
             this.DimXCasafim = xf;
             this.DimYCasafim = yf;
         }*/

        public static List<Casa> CasasAndaveis(Personagem per, Mapa map)
        {
            List<Casa> CasasAndaveis = new List<Casa>();
            int px = per.PosX;
            int py = per.PosY;
            int rg = per.MovRange;
            for (int x = rg; x >= -rg; x--)
            {
                for (int y = rg; y >= -rg; y--)
                {
                    if (y==0 && x == 0 || px+x <0 || px+x >= 20 || py + y < 0 || py + y >= 20)
                    {
                        continue;
                    }
                    
                    if (map.casa[px+x,py+y].Andavel == true && map.casa[px + x, py + y].Personagem == null)
                    {
                        CasasAndaveis.Add(map.casa[px + x, py + y]);
                    }
                }
            }

            return CasasAndaveis;
        }
        
    }
}