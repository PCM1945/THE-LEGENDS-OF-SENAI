using System;
using System.Collections.Generic;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Media.Imaging;

namespace Legends_lib
{
    public class Personagem : ObjetoDeJogo
    {
        //criar metodo padrão de movimento

        //criar habilidade
        public int PosX { get; set; }
        public int PosY { get; set; }
        public Habilidade Habilidade { get; set; }
        public List<object> ItemEquipado { get; set; }
        public BitmapImage bitmap;
        public int Atq { get; set; }
        public int VidaMax { get; set; }
        public int VidaAtual { get; set; }
        public Image Imagem { get; set; }
        public int Experiencia { get; set; }
        public int Custo_Gold { get; set; }
        public int MovRange { get; set; }
        public int MovUsados { get; set; }
        public String Nome { get; set; }
        public Personagem()
        {
           

        }
     
        /// Cria a imagem no xaml, apos chamar a funcao, colocar personagem.Imagem no canvas

        public void CriarImagem()
        {
            bitmap = new BitmapImage();
            this.Imagem = new Image();
            this.Imagem.Width = this.bitmap.DecodePixelWidth = ObjetoDeJogo.DimXCasa;
            this.Imagem.Height = this.bitmap.DecodePixelHeight = ObjetoDeJogo.DimYCasa;
            this.bitmap.UriSource = new Uri(this.UrlImage);
            this.Imagem.Source = this.bitmap;
        }
      /* public void Mover(int xf, int yf)//f = destino
       {
            Casa final = new Casa(true, xf, yf);
            Casa_atual = final;
            
        }*/
        //public void PegarItem()

    }
}