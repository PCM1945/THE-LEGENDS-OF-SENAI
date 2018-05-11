using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Legends_lib.Batalha
{
    public static class AtkController
    {
        public static float Atacar(int atq,int vida, Jogador jogadorAlvo)
        {
            
            jogadorAlvo.VidaCastelo -= atq;
            return jogadorAlvo.VidaCastelo;
        }

        public static int Atacar(int atq, int vida, Personagem personagemAlvo, Personagem personagemAtk)
        {
            personagemAlvo.VidaAtual -= personagemAtk.Atq;
            return personagemAlvo.VidaAtual;
        }

        public static bool Conquista(int vida,Jogador jogadorAlvo)//função que dirá se o jogador venceu ao destruir o castelo inimigo ou não
        {
            if(jogadorAlvo.VidaCastelo <= 0)//verifica se a vida do castelo zerou
            {
                return true;
            }
            return false;
        }

    }
}
