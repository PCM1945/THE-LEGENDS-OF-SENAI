using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Legends_lib
{
    public abstract  class ObjetoDeJogo // TODAS AS CLASES DE JOGO VAO HERDAR DELA, Ex Personagem e itens
    {
        private static int dimXCasa = 40;
        private static int dimYCasa = 40;
        public string UrlImage { get; set; }
        public static int DimXCasa { get => dimXCasa; }
        public static int DimYCasa { get => dimYCasa; }
    }
}
