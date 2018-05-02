using System.Collections.Generic;

namespace Legends_lib
{
    public class Habilidade
    {
        public string Nome { get; set; }
        public List<string> Efeitos { get; set; }
        public TipoHabilidade Tipo { get; set; }
        //public string Diretorio { get; set; }
        public bool Status { get; set; } //HABILIDADE PODE SER USADA
        public int NivelHabilidade { get; set; }
        public int CustoGold { get; set; }
    }
}