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
            Custo_Gold = 200;
            Atq = 20;
            Vida = 100;
            Experiencia = 20;
            MovRange = 3;
            PosX = cordx;
            PosY = cordy;
        }
            
        
        



        //jogar a pasta


    }
}
