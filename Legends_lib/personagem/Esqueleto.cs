using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Legends_lib { 
    public class Esqueleto :Personagem
    {

        public Esqueleto(int cordx, int cordy) : base()
        {
            UrlImage = "ms-appx:///Assets/characters/Warrrior_spt/esqueleto/esqueleto guerreiro/solado esqueleto-parado.png";
           
            Custo_Gold = 100;
            Atq = 25;
            VidaMax = 80;
            VidaAtual = VidaMax;
            Mp = 25;
            Experiencia = 20;
            MovRange = 3;
            AtqRange = 1;
            MovUsados = MovRange;
            PodeMover = false;
            PosX = cordx;
            PosY = cordy;
            Nome = "Guerreiro";
        }
    }
}
