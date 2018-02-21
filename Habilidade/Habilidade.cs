using System.Collections.Generic;

namespace Mapa
{
    public class Habilidade
    {
        public string Nome { get; set; }
        public List<string> Efeitos { get; set; }
        public TipoHabilidade Tipo { get; set; }
        //public string Diretorio { get; set; }
    }
}