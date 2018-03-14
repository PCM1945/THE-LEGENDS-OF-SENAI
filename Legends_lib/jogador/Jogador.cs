using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Legends_lib
{
    public  class Jogador
    {
        public Int64 Gold { get; set; }
        public Int64 Experiencia { get; set; }
        public List<Habilidade> Habilidades { get; set; }
        public List<object> Inventario { get; set; }
        public List<Personagem> Personagens { get; set; }
        public List<Castelo> Castelos {get; set;}
        public int Turno_movimento { get; set; }
        public Jogador()
        {
            Castelos = new List<Castelo>();
            Personagens = new List<Personagem>();
        }

    }
}
