using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Legends_lib.Item.Controls
{
    public class ItemControl
    {
        private const int MaxInvSize = 8;
        public bool PodeObter(Jogador j, Item i)
        {
            j.Inventario.Add(i);
            return j.Inventario.Count > MaxInvSize;
        }

        public void UsaItem(Jogador j, Item i, Personagem p)
        {
            if (EItens.Consumivel.Equals(i.Tipo))//VERIFICA QUAL TIPO DE ITEM FOI USADO
            {                               //PARA PRIMEIRA ENTREGA O CONSUMÍVEL VAI AUMENTAR 1 DE HP
                p.Vida += 1;                
                j.Inventario.Remove(i);
            }
            else if(EItens.Equipavel.Equals(i.Tipo))//O EQUIPAVEL AUMENTA 1 DE ATK
            {
                if (p.ItemEquipado.Contains(i)) // VERIFICA SE O EQUIPÁVEL JÁ ESTÁ EQUIPADO
                {
                    p.ItemEquipado.Remove(i); // SE ESTIVER DESEQUIPA
                    p.Atq -= 1; //DIMINUI O ATQ
                }
                else 
                {
                    p.ItemEquipado.Add(i);// SE NÃO ESTIVER EQUIPA
                    p.Atq += 1;// AUMENTA O ATQ
                }
            }
            else if (EItens.NaoUtilizavel.Equals(i.Tipo))
            {
                return;// NADA FAZ SE FOR NÃO UTILIZAVEL -- PS ISSO NEM PRECISA AQUI, MAS BOTEI ASSIM MESMO
            }

        }

        public void ApagaItem(Jogador j, Item i)
        {
            if(j.Inventario.Contains(i))
                j.Inventario.Remove(i);
        }

    }
}
