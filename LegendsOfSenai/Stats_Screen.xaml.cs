using Legends_lib;
using Legends_lib.Item;
using Legends_lib.Item.Controls;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace LegendsOfSenai
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class Stats_Screen : Page
    {
        Jogador JogadorAtual = null;
        public Stats_Screen()
        {
            this.InitializeComponent();
            
        }
        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            base.OnNavigatedTo(e);
            //binding dos itens
             JogadorAtual = (Jogador)e.Parameter;
            StackStatsBinding.DataContext = JogadorAtual;
            StatsGenerate();

            ListPersonagens.ItemsSource = JogadorAtual.Personagens;

             ListItens.ItemsSource = JogadorAtual.Inventario;
           // ListItens.ItemsSource = new ObservableCollection<Item> (JogadorAtual.Inventario);
        }

        private void StatsGenerate()
        {
            TxtTropas.Text ="" + JogadorAtual.Personagens.Count;
            TxtItens.Text = "" + JogadorAtual.Inventario.Count;
            // TxtVilas.Text = "" + JogadorAtual.Vilas.Count;
            TxtVilas.Text = "Nao Implementado";
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            this.Frame.GoBack();
        }

        private void EquiparItem(object sender, TappedRoutedEventArgs e)
        {
            Item ItemSelecionado = ListItens.SelectedItem as Item;
            Personagem PersonSelecionado = ListPersonagens.SelectedItem as Personagem;
            ItemControl.UsaItem(JogadorAtual,ItemSelecionado,PersonSelecionado);
        }
    }
}
