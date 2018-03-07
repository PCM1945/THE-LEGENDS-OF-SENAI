

namespace Legends_lib
{
    public class Personagem : ObjetoDeJogo
    {
        //criar metodo padrão de movimento

        //criar habilidade
        public Casa Casa_atual { get; set; }
        public Habilidade Habilidade { get; set; }
       
        public int Experiencia { get; set; }
        public int Custo_Gold { get; set; }

        Personagem(int e, int g, Habilidade h)
        {
            this.Habilidade = h;
            this.Custo_Gold = g;
            this.Experiencia = e;
            
        }

       public void Mover(int xf, int yf)//f = destino
       {
            Casa final = new Casa(true, xf, yf);//ainda não faz a consideração de ser andável ou não
            Casa_atual = final;
       }


    }
}