using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Legends_lib
{
    public class HabilidadeJogador
    {
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

        public int ContaTurno(Jogador j)
        {
            return j.Turno += 1;
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

        public string GanhaItem(Jogador j, Item i)
        {
            if(j.Inventario.Count < 10)
            {
                j.Inventario.Add(i);
                return "Adquiriu " + i.Nome;
            }
            else
            {
                return "Inventário cheio";
            }
        }
    }
}
