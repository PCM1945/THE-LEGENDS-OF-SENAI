using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Legends_lib
{
    public class Necromancer : Personagem
    {

        public Necromancer(int cordx, int cordy) : base()
        {
            //UrlImage = "n achei";

            Custo_Gold = 250;
            Atq = 45;
            VidaMax = 50;
            VidaAtual = VidaMax;
            Mp = 85;
            Experiencia = 20;
            MovRange = 3;
            AtqRange = 3;
            MovUsados = MovRange;
            PodeMover = false;
            PosX = cordx;
            PosY = cordy;
            Nome = "Necromancer";
        }
    }
}
