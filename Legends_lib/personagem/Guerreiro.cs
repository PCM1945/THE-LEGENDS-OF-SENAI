using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Legends_lib
{
    public class Guerreiro : Personagem
    {

        public Guerreiro(int corx,int cordy){
            UrlImage = @"Assets\charters\Warrrior_spt\guerreiro.png";
            Custo_Gold = 200;
            Atq = 20;
            Vida = 100;
            Experiencia = 20;
            MovRange = 4;
        }
        



        //jogar a pasta


    }
}
