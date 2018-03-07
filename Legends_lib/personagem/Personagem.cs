

namespace Legends_lib
{
    public class Personagem
    {
        //criar metodo padrão de movimento

        //criar habilidade
        public Casa casa_atual { get; set; }
        public Habilidade Habilidade { get; set; }
        public int DimXCasa { get; set; }
        public int DimYCasa { get; set; }
        public int Experiencia { get; set; }
        public int Gold { get; set; }

        Personagem(int x, int y, int e, int g, Habilidade h)
        {
            this.Habilidade = h;
            this.Gold = g;
            this.Experiencia = e;
            this.DimXCasa = x;
            this.DimYCasa = y;
            this.casa_atual = new Casa(true,x,y);
        }

       public void Mover(int xf, int yf)//f = destino
       {
            Casa final = new Casa(true, xf, yf);//ainda não faz a consideração de ser andável ou não
            casa_atual = final;
       }


    }
}