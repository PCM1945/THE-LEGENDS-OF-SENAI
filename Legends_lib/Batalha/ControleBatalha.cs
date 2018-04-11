using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Legends_lib.Batalha
{
    public static class ControleBatalha
    {
        public static Personagem personagem1 { get; set; }
        public static Personagem personagem2 { get; set; }

        public static int vencedor()//COLOCAR OS GANHOS DE GOLD DE BATALHA
         {
            if (personagem1.Vida <= 0)
            {
                return 1;
            }
            if (personagem2.Vida <= 0)
            {
                return 2;
            }
            return 0;
        }

    }
}
