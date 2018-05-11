using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Legends_lib
{
    public partial class Casa
    {
        public bool Andavel { get; set; }
        public int PosX { get; set; }
        public int PosY { get; set; }
        public Personagem Personagem { get; set; }
        public Item.Item Item { get; set; }
        public string local_imagem { get; set; }

        public Casa(int posX,int posY)
        {
            this.Andavel = true;
            this.PosX = posX;
            this.PosY = posY;
            this.Personagem = null;
            this.Item = Item;
        }

        enum Rec
        {
            left, right, up ,down
        }

        // fazer o metodo de alteração aleatoria 
    }
}
