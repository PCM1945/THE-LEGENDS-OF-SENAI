using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Legends_lib
{
    public class ControlsHabilidade
    {
        public static List<Habilidade> ListaHabilidadesJogador = new List<Habilidade>()
        {
            new Habilidade{
                CustoGold = 20,
                Efeitos = new List<string>() { "ATK 1" },
                NivelHabilidade = 1,
                Nome = "ATK 1",
                Status = true, // status deve mudar conforme batalha
                Tipo = TipoHabilidade.Ativa,
                Dano = 60
            },
            new Habilidade{
                CustoGold = 10,
                Efeitos = new List<string>() { "ATK 2" },
                NivelHabilidade = 1,
                Nome = "ATK 2",
                Status = true, // status deve mudar conforme batalha
                Tipo = TipoHabilidade.Ativa,
                Dano = 40 
            },
            new Habilidade{
                CustoGold = 10,
                Efeitos = new List<string>() { "ATK 3" },
                NivelHabilidade = 1,
                Nome = "ATK 3",
                Status = true, // status deve mudar conforme batalha
                Tipo = TipoHabilidade.Ativa,
                Dano = 20
            },
            new Habilidade{
                CustoGold = 0,
                Efeitos = new List<string>() { "PASSIVA ÚNICA" },
                NivelHabilidade = 1,
                Nome = "PASSIVA ÚNICA",
                Status = true, // status deve mudar conforme batalha
                Tipo = TipoHabilidade.Passiva
            }

        };
        private bool PodeUsarHabilidade(Personagem p)
        {
            return p.Habilidade.Status;
        }

        public string UsaHabilidade(Personagem p)
        {
            if (p.Habilidade.Status && p.Habilidade.Tipo == 0)
            {
                p.Habilidade.Status = false;
            }
            else
            {
                return p.Habilidade.Nome + "Não pode ser usada no momento";
            }   
            return p.Habilidade.Nome;
        }

        public void RecarregaHabilidade(Personagem p)
        {
            //IMPLEMENTAR CONTAGEM DE TURNO COMO VALIDAÇÃO DESTE
            p.Habilidade.Status = true;
        }

        public void MudaNivelHabilidade(Personagem p, char activity)
        {
            
            if(activity == '+')
            {
                //DIMINUI 1 AOS PONTOS DE DISTRIBUIÇÃO
                p.Habilidade.NivelHabilidade += 1;
            }
            else if (activity == '-')
            {
                //ADICIONA 1 AOS PONTOS DE DISTRIBUIÇÃO
                p.Habilidade.NivelHabilidade -= 1;
            }
            
        }

    }
}
