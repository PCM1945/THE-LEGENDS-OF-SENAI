using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Legends_lib
{ 
    public class Casa
    {
        public bool Andavel { get; set; }
        public int PosX { get; set; }
        public int PosY { get; set; }
        public Personagem Personagem { get; set; }
        public Item Item { get; set; }

        Casa(bool anda,int X, int Y)
        {
            PosX = X;
            PosY = Y;
            Andavel = anda;
        }
        // fazer o metodo de alteração aleatoria 
    }
}
