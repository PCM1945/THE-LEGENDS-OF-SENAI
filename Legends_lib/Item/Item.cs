using System.Collections.Generic;

namespace Legends_lib
{
    public class Item : ObjetoDeJogo
    {
        public string Nome { get; set; }
        public EItens Tipo { get; set; }
        public List<string> Efeitos { get; set; }

        
    } 
}