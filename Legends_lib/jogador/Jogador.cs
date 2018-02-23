using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Legends_lib
{
    public  class Jogador
    {
    
   
          public string Nome { get; set; }
          public Int64 Gold { get; set; }
          public Int64 Experiencia { get; set; }
          public List<Habilidade> Habilidades { get; set; }
          public List<object> Inventario { get; set; }

    

}
}
