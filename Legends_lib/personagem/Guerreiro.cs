using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml.Media.Imaging;

namespace Legends_lib
{
    public class Guerreiro : Personagem
    {
        
        public Guerreiro(int cordx,int cordy) : base() {
            UrlImage = "ms-appx:///Assets/characters/Warrrior_spt/humano/guerreiro.png";
            Custo_Gold = 150;
            Atq = 20;
            VidaMax = 100;
            VidaAtual = 100;
            Mp = 25;
            Experiencia = 20;
            MovRange = 3;
            AtqRange = 1;
            MovUsados = MovRange;
            PodeMover=false;
            PosX = cordx;
            PosY = cordy;
            Nome = "Guerreiro";
        }
            
        
        



        //jogar a pasta


    }
}
