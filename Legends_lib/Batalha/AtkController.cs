using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Legends_lib.Batalha
{
    public static class AtkController
    {
        public static int Atacar(int atq,int vida)
        {
            vida -= atq;
            return vida;
        }



    }
}
