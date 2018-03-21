using Legends_lib;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using Windows.UI.Input;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Input;
using Legends_lib.maps.mapa_geral.Controls;
using Legends_lib.Item;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml;

namespace LegendsOfSenai
{
   
    
        /// <summary>
        /// Uma página vazia que pode ser usada isoladamente ou navegada dentro de um Quadro.
        /// </summary>
        public sealed partial class Tela1_Mapa : Page
        {

        public Mapa Map = new MainMapControl().InciarMapa();
        public Personagem selecionado;
        public bool selecionou=false;
        Jogador Jogador1,Jogador2;

        Dictionary<uint, Windows.UI.Xaml.Input.Pointer> pointers;
        public Tela1_Mapa()
        {
            this.InitializeComponent();
            pointers = new Dictionary<uint, Pointer>();
            Jogador1 = new Jogador();
            Jogador2 = new Jogador();

            IniciarCastelos();

            //Setando o data biding


            Jogador1.Inventario = new List<Item>();
            Jogador1.Inventario.Add(new Item { Nome = "item1", Tipo = EItens.Consumivel });
            Jogador1.Inventario.Add(new Item { Nome = "item2", Tipo = EItens.Equipavel });
            Jogador1.Inventario.Add(new Item { Nome = "item3", Tipo = EItens.NaoUtilizavel });
            Invetario_list.ItemsSource = Jogador1.Inventario;
            Player_info.ItemsSource = new List<Jogador>() { Jogador1 };

            //TESTANDO O MAPA
        }

        private void IniciarCastelos()
        {
            Debug.WriteLine("Iniciando Castelos");

            Jogador1.Castelos.Add(new Castelo(1,7));
            Jogador1.Castelos.Add(new Castelo(2,7));
            Jogador1.Castelos.Add(new Castelo(1,8));
            Jogador1.Castelos.Add(new Castelo(2,8));

            Jogador2.Castelos.Add(new Castelo(17,7));
            Jogador2.Castelos.Add(new Castelo(18,7));
            Jogador2.Castelos.Add(new Castelo(17,8));
            Jogador2.Castelos.Add(new Castelo(18,8));
        }

      

        private void Target_PointerPressed(object sender, PointerRoutedEventArgs e)
        {
           
            e.Handled = true;

            PointerPoint ptrPt = e.GetCurrentPoint(mapa);
            Debug.WriteLine("pos X: " + ptrPt.Position.X);

            Debug.WriteLine("pos Y: " + ptrPt.Position.Y);

            Debug.WriteLine(calcCasa.getPosCasa((int)ptrPt.Position.X));
        /*    if (selecionou == false)
            {
                if (map.casa[calcCasa.getPosCasa((int)ptrPt.Position.X)][calcCasa.getPosCasa((int)ptrPt.Position.Y)].Personagem != null)
                {
                    selecionou = true;
                    selecionado = map.casa[calcCasa.getPosCasa((int)ptrPt.Position.X)][calcCasa.getPosCasa((int)ptrPt.Position.Y)].Personagem;
                   // map.casa[calcCasa.getPosCasa((int)ptrPt.Position.X)][calcCasa.getPosCasa((int)ptrPt.Position.Y)].Personagem = null;
                }
            }
            else
            {
                if (map.casa[calcCasa.getPosCasa((int)ptrPt.Position.X)][calcCasa.getPosCasa((int)ptrPt.Position.Y)].Personagem == null)
                {
                    selecionou =false;
                    map.casa[calcCasa.getPosCasa((int)ptrPt.Position.X)][calcCasa.getPosCasa((int)ptrPt.Position.Y)].Personagem=selecionado;
                    // map.casa[calcCasa.getPosCasa((int)ptrPt.Position.X)][calcCasa.getPosCasa((int)ptrPt.Position.Y)].Personagem = null;
                }
            }*/
           
            
        }

        private void Button_Click(object sender, Windows.UI.Xaml.RoutedEventArgs e)
        {

        }

        private void Inventario_Click(object sender, Windows.UI.Xaml.RoutedEventArgs e)
        {
            if (Inventario.Opacity != 0) {
                Inventario.Opacity = 0;
            }
            else
            {
                Inventario.Opacity = 100;
            }
           
        }
        private void Recrutamento(object sender, RoutedEventArgs e)
        {
            Debug.WriteLine("trewwwwwwwwwwwwqqqqqq");
            foreach (Castelo cast in Jogador1.Castelos) {
                //       try
                //     {
                if (Map.casa[cast.Cordx, cast.Cordy].Personagem == null)
                //if (Map.casa[5][5] != null)
                {

                        Debug.WriteLine("Entrou no if");
                        /* Personagem person = new Guerreiro(cast.Cordx,cast.Cordy);
                         Map.casa[cast.Cordx][cast.Cordy].Personagem = person;
                         Jogador1.Personagens.Add(person);
                         Image imgPer = new Image();*/
                        // imgPer.Source = person.UrlImage; FAZENDO
                    }
             ///   }
                /*catch (Exception)
                {
                    Debug.WriteLine("esta NULL")
                    throw;
                }*/
                
            }
         //   Personagem person = new Guerreiro();
        }
        private void AbreRecrutamento(object sender, TappedRoutedEventArgs e)
        {
            FlyoutBase.ShowAttachedFlyout((FrameworkElement) sender);
        }
        private void UpdateEventLog(string v)
        {
            throw new NotImplementedException();
        }
    }
    
}
