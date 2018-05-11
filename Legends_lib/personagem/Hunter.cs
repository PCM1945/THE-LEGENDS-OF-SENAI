using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Legends_lib
{
    public class Hunter : Personagem
    {

        public Hunter(int cordx, int cordy) : base()
        {
            UrlImage = "ms-appx:///Assets/characters/Arqueiro_spt/esqueleto/esqueleto arqueiro/esqueleto arqueiro -frente.png";

            Custo_Gold = 200;
            Atq = 30;
            VidaMax = 45;
            VidaAtual = VidaMax;
            Mp = 30;
            Experiencia = 20;
            MovRange = 5;
            AtqRange = 4;
            MovUsados = MovRange;
            PodeMover = false;
            PosX = cordx;
            PosY = cordy;
            Nome = "Hunter";
        }
    }
}