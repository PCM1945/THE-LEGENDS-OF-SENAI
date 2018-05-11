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
            //JogAtual.Personagens.Add(perso1);
            //JogAtual.Personagens.Add(perso2);
            FilaBatalha.Enqueue(personagem1);
            FilaBatalha.Enqueue(personagem2);
            
        }

        public static int BuscarVencedor()//COLOCAR OS GANHOS DE GOLD DE BATALHA
         {
            if (personagem1.VidaAtual <= 0)
            {
                vencedor = 1;
              //HabilidadeJogador.GanhaGold(JogAtual, personagem2);
                return 1;
                
            }
            if (personagem2.VidaAtual <= 0)
            {
                vencedor = 2;
                return 2;
            }
            return 0;
        }

        public static List<Casa> PersonAtacaveis(Personagem per,Jogador JogAtual,Mapa map, List<Castelo> CastelosInimigos)
        {
            List<Casa> CasasAndaveis = new List<Casa>();

            int px = per.PosX;//deu exception aq qnd clicou varias vzs nos perso do msm time
            int py = per.PosY;
            int rg = per.AtqRange;
            for (int x = rg; x >= -rg; x--)
            {
                for (int y = rg; y >= -rg; y--)
                {
                    if (y == 0 && x == 0 || px + x < 0 || px + x >= 20 || py + y < 0 || py + y >= 20)
                    {
                        continue;
                    }

                    if (map.casa[px + x, py + y].Personagem != null)
                    {
                        if(!(JogAtual.Personagens.Contains(map.casa[px + x, py + y].Personagem)))
                        CasasAndaveis.Add(map.casa[px + x, py + y]);
                        
                    }
                }
            }
            foreach (Castelo Cas in CastelosInimigos)
            {
                if (((Cas.Cordx)<px+rg)&&( Cas.Cordx> px-rg)) {
                    if (((Cas.Cordy) < px + rg) && (Cas.Cordy > px - rg))
                    {
                        CasasAndaveis.Add(map.casa[Cas.Cordx,Cas.Cordy]);
                    }
                }
            }
           
            return CasasAndaveis;
        }

    }
}
