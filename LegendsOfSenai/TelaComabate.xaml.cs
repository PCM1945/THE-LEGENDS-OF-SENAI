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
        public BlankPage1()
        {
            this.InitializeComponent();
            Batalha();
            
        }

        private void Batalha()
        {
            ControleBatalha.ordenarBatalha();
            while (ControleBatalha.BuscarVencedor() != 0)
            {
                //COLOCAR A BATALHA
            }
            //voltarMapa(); ----- tira esse coment 
        }

        private void voltarMapa()
        {
            this.Frame.Navigate(typeof(Tela1_Mapa));
        }
        private void botao_batalha_Click(object sender, RoutedEventArgs e)
        {
            voltarMapa();
        }
    }
}
