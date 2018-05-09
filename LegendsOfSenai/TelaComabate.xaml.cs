using Legends_lib;
using Legends_lib.Batalha;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Media.Imaging;
using Windows.UI.Xaml.Navigation;

// O modelo de item de Página em Branco está documentado em https://go.microsoft.com/fwlink/?LinkId=234238

namespace LegendsOfSenai
{
    /// <summary>
    /// Uma página vazia que pode ser usada isoladamente ou navegada dentro de um Quadro.
    /// </summary>
    public sealed partial class BlankPage1 : Page
    {
        //  Personagem aux1,aux2;
        public int turno;
        public BlankPage1()
        {
            turno = 1;
            this.InitializeComponent();
        
          
            Batalha();
            
        }
        //teste 
        private void Batalha()// ATT AS INFS DE BATALHA
        {
            Uri imgp1=null;
            Uri imgp2=null;
            switch (ControleBatalha.personagem1.Nome) {
                case "Guerreiro":
                    imgp1= new Uri("ms-appx:Assets/characters/Warrrior_spt/humano/guerreiro/paldino-dir.png", UriKind.Absolute);
                    break;
                case "Esqueleto":
                    imgp1 = new Uri("ms-appx:Assets/characters/Warrrior_spt/esqueleto/esqueleto guerreiro/soldado-esqueleto-parado dir.png", UriKind.Absolute);
                    break;

            }
            switch (ControleBatalha.personagem2.Nome)
            {
                case "Guerreiro":
                    imgp2 = new Uri("ms-appx:Assets/characters/Warrrior_spt/humano/guerreiro/paladino-esq.png", UriKind.Absolute);
                    break;
                case "Esqueleto":
                    imgp2 = new Uri("ms-appx:Assets/characters/Warrrior_spt/esqueleto/esqueleto guerreiro/soldado esqueleto parado -esq.png", UriKind.Absolute);
                    break;

            }
 
            imgPlayer1.Source = new BitmapImage(imgp1);
            imgPlayer2.Source = new BitmapImage(imgp2);
            TextBlock_SelectionChanged();
            verificaVencedor();
        }

        private void voltarMapa()
        {
            this.Frame.Navigate(typeof(Tela1_Mapa));
        }

        private void verificaVencedor()
        {

            if (ControleBatalha.personagem1.VidaAtual <= 0)
            {
                ControleBatalha.vencedor = 2;
                voltarMapa();
            }
            if (ControleBatalha.personagem2.VidaAtual <= 0)
            {
                ControleBatalha.vencedor = 1;
                voltarMapa();
            }
        }

        private void TextBlock_SelectionChanged()
        {
            Hp1.Text = "HP: " +ControleBatalha.personagem1.VidaAtual.ToString();
            Hp2.Text = "HP: " + ControleBatalha.personagem2.VidaAtual.ToString();
            Mp1.Text = "MP: " + ControleBatalha.personagem1.Mp.ToString();
            Mp2.Text = "MP: " + ControleBatalha.personagem2.Mp.ToString();
        }

        private void botao_AtkBas2(object sender, RoutedEventArgs e)
        {
            if (turno == 2)
            {
                ControleBatalha.personagem1.VidaAtual -= 10;
                Batalha();//botar p deixar o botão meio transparente e ativar o outro
                turno = 1;
            }
            
        }

        private void botao_AtkBas1(object sender, RoutedEventArgs e)
        {
            if (turno == 1)
            {
                ControleBatalha.personagem2.VidaAtual -= 10;
                Batalha();
                turno = 2;
            }
            
        }
    }
}
