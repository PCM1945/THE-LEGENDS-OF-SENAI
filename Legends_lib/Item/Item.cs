using System;
using System.Collections.Generic;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Media.Imaging;

namespace Legends_lib.Item
{
    public class Item : ObjetoDeJogo
    {
        public string Nome { get; set; }
        public EItens Tipo { get; set; }
        public string Descricao { get; set; }
        public BitmapImage bitmap;
        public Image Imagem { get; set; }

        public void CriarImagem()
        {
            bitmap = new BitmapImage();
            this.Imagem = new Image();
            this.Imagem.Width = this.bitmap.DecodePixelWidth = ObjetoDeJogo.DimXCasa;
            this.Imagem.Height = this.bitmap.DecodePixelHeight = ObjetoDeJogo.DimYCasa;
            this.bitmap.UriSource = new Uri(this.UrlImage);
            this.Imagem.Source = this.bitmap;
        }
    } 
}