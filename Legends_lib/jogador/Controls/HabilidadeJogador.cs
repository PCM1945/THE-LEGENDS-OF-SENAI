﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Legends_lib
{
    public class HabilidadeJogador
    {
        private const int MaxInvSize = 8;
        public void MudaNivelHabilidade(Jogador j, char activity) //DESSE JEITO TODAS AS HABILIDADES PASSIVAS 
        {                                                          //SÃO MODIFICADAS AO MESMO TEMPO QUEREMOS ISSO ?
            foreach (Habilidade h in j.Habilidades)
            {
                if (activity == '+')
                {
                    //DIMINUI 1 AOS PONTOS DE DISTRIBUIÇÃO
                    h.NivelHabilidade += 1;
                }
                else if (activity == '-')
                {
                    //ADICIONA 1 AOS PONTOS DE DISTRIBUIÇÃO
                    h.NivelHabilidade -= 1;
                }
            }
        }

        /** turno  será contado no jogo*/
        public int ContaTurno(Jogador j)
        {
            return j.Turno_movimento += 1;
        }

        public string GanhaExp(Jogador j, Personagem enemy)
        {
            j.Experiencia = enemy.Experiencia; //EXPERIÊNCIA DO OPONENTE É ADQUIRIDA PELO JOGADOR
                                              // INIMIGO CARREGA EXPERIÊNCIA EM SEUS ATRIBUTOS
            return "Adquiriu " + enemy.Experiencia;
        }

        public string GanhaGold(Jogador j, Personagem enemy)
        {
            j.Gold = enemy.Custo_Gold; //EXPERIÊNCIA DO OPONENTE É ADQUIRIDA PELO JOGADOR
                                               // INIMIGO CARREGA EXPERIÊNCIA EM SEUS ATRIBUTOS
            return "Adquiriu " + enemy.Custo_Gold;
        }

        public string GanhaItem(Jogador j, Item.Item i, Casa c)
        {
            if(j.Inventario.Count < MaxInvSize)
            {
                j.Inventario.Add(i);
                c.Item = null;
                return "Adquiriu " + i.Nome;
            }
            else
            {
                return "Inventário cheio";
            }
        }
    }
}
