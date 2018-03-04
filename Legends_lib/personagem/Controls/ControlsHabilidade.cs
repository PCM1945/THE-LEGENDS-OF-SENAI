using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Legends_lib.personagem.Controls
{
    public class ControlsHabilidade
    {

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
