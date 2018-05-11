using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Legends_lib
{
    public class Arqueiro : Personagem
    {

        public Arqueiro(int cordx, int cordy) : base()
        {
            UrlImage = "ms-appx:///Assets/characters/Arqueiro_spt/humano/paladino/paladino-frente.png";

            Custo_Gold = 200;
            Atq = 25;
            VidaMax =55;
            VidaAtual = VidaMax;
            Mp = 30;
            Experiencia = 20;
            MovRange = 5;
            AtqRange = 4;
            MovUsados = MovRange;
            PodeMover = false;
            PosX = cordx;
            PosY = cordy;
            Nome = "Arqueiro";
        }
    }
}
