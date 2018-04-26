using Legends_lib;
using Legends_lib.Batalha;
using System;
using System.Collections.Generic;
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
using Windows.UI.Xaml.Navigation;

// O modelo de item de Página em Branco está documentado em https://go.microsoft.com/fwlink/?LinkId=234238

namespace LegendsOfSenai
{
    /// <summary>
    /// Uma página vazia que pode ser usada isoladamente ou navegada dentro de um Quadro.
    /// </summary>
    public sealed partial class BlankPage1 : Page
    {
        Personagem aux1,aux2;
        public BlankPage1()
        {
            this.InitializeComponent();
            Batalha();
            
        }

        private void Batalha()// ATT AS INFS DE BATALHA
        {
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
            Hp1.Text ="HP: " +ControleBatalha.personagem1.VidaAtual.ToString();
            Hp2.Text= "HP: " + ControleBatalha.personagem2.VidaAtual.ToString();
        }

        private void botao_AtkBas2(object sender, RoutedEventArgs e)//COLOCAR P/ BOTÃO APARECER APENAS QUANDO ACABAR A BATALHA
        {
            // voltarMapa();
            ControleBatalha.personagem1.VidaAtual -= 10;
            Batalha();
        }

        private void botao_AtkBas1(object sender, RoutedEventArgs e)//COLOCAR P/ BOTÃO APARECER APENAS QUANDO ACABAR A BATALHA
        {
            // voltarMapa();
            ControleBatalha.personagem2.VidaAtual -= 10;
            Batalha();
        }
    }
}
