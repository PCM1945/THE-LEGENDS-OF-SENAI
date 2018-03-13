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
                if (p.ItemEquipado.Contains(i))
                {
                    p.ItemEquipado.Remove(i);
                }
                else 
                {
                    p.ItemEquipado.Add(i);
                    p.Atq += 1;
                }
            }
            else if (EItens.NaoUtilizavel.Equals(i.Tipo))
            {
                return;
            }

        }

        public void ApagaItem(Jogador j, Item i)
        {
            if(j.Inventario.Contains(i))
                j.Inventario.Remove(i);
        }

    }
}
