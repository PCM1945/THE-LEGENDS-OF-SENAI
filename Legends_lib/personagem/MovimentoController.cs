using System.Collections.Generic;
using Windows.UI.Xaml.Shapes;

namespace Legends_lib
{
    public class MovimentoController
    {
     
      

        public static List<Casa> CasasAndaveis(Personagem per, Mapa map)
        {
            List<Casa> CasasAndaveis = new List<Casa>();
           
            int px = per.PosX;//deu exception aq qnd clicou varias vzs nos perso do msm time
            int py = per.PosY;
            int rg = per.MovRange;
            for (int x = rg; x >= -rg; x--)
            {
                for (int y = rg; y >= -rg; y--)
                {
                    if (y == 0 && x == 0 || px +x <0 || px+x >= 20 || py + y < 0 || py + y >= 20)
                    {
                        continue;
                    }
                    
                    if (map.casa[px+x,py+y].Andavel == true && map.casa[px + x, py + y].Personagem == null)
                    {
                        CasasAndaveis.Add(map.casa[px + x, py + y]);
                    }
                }
            }
            CasasAndaveis.Add(map.casa[px, py]);
            return CasasAndaveis;
        }
        
    }
}