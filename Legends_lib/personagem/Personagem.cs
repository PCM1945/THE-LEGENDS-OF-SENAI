

using System.Collections.Generic;

namespace Legends_lib
{
    public class Personagem : ObjetoDeJogo
    {
        //criar metodo padrão de movimento

        //criar habilidade
        public Casa Casa_atual { get; set; }
        public Habilidade Habilidade { get; set; }
        public List<object> ItemEquipado { get; set; }

        public int Atq { get; set; }
        public int Vida { get; set; }

        public int Experiencia { get; set; }
        public int Custo_Gold { get; set; }
        public int QtCasa { get; set; }
        Personagem(int e, int g, Habilidade h)
        {
            this.Habilidade = h;
            this.Custo_Gold = g;
            this.Experiencia = e;
           // this.Casa_atual = new Casa(true,x,y);
        }

       public void Mover(int xf, int yf)//f = destino
       {
            Casa final = new Casa(true, xf, yf);
            Casa_atual = final;
       }
        //public void PegarItem()

    }
}