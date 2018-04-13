using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
/*
 * Classe para controlar a batalha
 * Inicia setando os jogadores e vai buscando os jogadores
 * 
 */ 
namespace Legends_lib.Batalha
{
    public static class ControleBatalha
    {
        public static Personagem personagem1 { get; set; }
        public static Personagem personagem2 { get; set; }
        public static Queue<Personagem> FilaBatalha = new Queue<Personagem>();
        public static int vencedor;
        public static void ordenarBatalha(Personagem perso1, Personagem perso2)
        {
            personagem1 = perso1;
            personagem2 = perso2;
            vencedor = 0;
            FilaBatalha.Enqueue(personagem1);
            FilaBatalha.Enqueue(personagem2);
        }

        public static int BuscarVencedor()//COLOCAR OS GANHOS DE GOLD DE BATALHA
         {
            if (personagem1.VidaAtual <= 0)
            {
                vencedor = 1;
                return 1;
            }
            if (personagem2.VidaAtual <= 0)
            {
                vencedor = 2;
                return 2;
            }
            return 0;
        }

    }
}
