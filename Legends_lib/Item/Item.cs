using System.Collections.Generic;

namespace Legends_lib.Item
{
    public class Item : ObjetoDeJogo
    {
        public string Nome { get; set; }
        public EItens Tipo { get; set; }
        public List<string> Efeitos { get; set; }
        public List<Item> ItensEquipados { get; set; }

        
    } 
}