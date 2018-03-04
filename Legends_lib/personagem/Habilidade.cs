using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Legends_lib
{
    public  class Habilidade
    {
        public string Nome { get; set; }
        public List<string> Efeitos { get; set; }
        public TipoHabilidade Tipo { get; set; }
        public bool Status { get; set; } //HABILIDADE PODE SER USADA
        //public string Diretorio { get; set; }
        public int NivelHabilidade { get; set; }
    }
}
