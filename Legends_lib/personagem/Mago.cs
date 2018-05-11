using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Legends_lib
{
    public class Mago : Personagem
    {

        public Mago(int cordx, int cordy) : base()
        {
            UrlImage = "ms-appx:///Assets/characters/Mago_spt/humano/mago/mago_lado_dir.png";

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
            Nome = "Mago";
        }
    }
}
