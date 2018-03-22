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
using Windows.Media.Playback;
using Windows.Media.Core;

namespace LegendsOfSenai
{
   
    
        /// <summary>
        /// Uma página vazia que pode ser usada isoladamente ou navegada dentro de um Quadro.
        /// </summary>
        public sealed partial class Tela1_Mapa : Page
        {

        public Mapa Map = new MainMapControl().InciarMapa();
        public Personagem selecionado;
        public bool selecionou;
        Jogador Jogador1,Jogador2;
        
        Dictionary<uint, Windows.UI.Xaml.Input.Pointer> pointers;
        public Tela1_Mapa()
        {
            selecionou = false;
            this.InitializeComponent();
            pointers = new Dictionary<uint, Pointer>();
            Jogador1 = new Jogador();
            Jogador2 = new Jogador();/*
            MediaPlayer mediaPlayer = new MediaPlayer();
            mediaPlayer.Source = MediaSource.CreateFromUri(new Uri("C:\\Users\\aluno\\Source\\Repos\\THE-LEGENDS-OF-SENAI\\LegendsOfSenai\\Assets\\MusicaMain.mp3"));
            mediaPlayer.Play();*/
            BtnPlayWav();
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
        private async void BtnPlayWav()
        {
            MediaElement mysong = new MediaElement();
            Windows.Storage.StorageFolder folder = await Windows.ApplicationModel.Package.Current.InstalledLocation.GetFolderAsync("Assets");
            Windows.Storage.StorageFile file = await folder.GetFileAsync("MusicaMain.mp3");
            var stream = await file.OpenAsync(Windows.Storage.FileAccessMode.Read);
            mysong.SetSource(stream, file.ContentType);
           
           // mysong.Volume = 100;
            mysong.Play();
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
            if(Map.casa[calcCasa.getPosCasa((int)ptrPt.Position.X), calcCasa.getPosCasa((int)ptrPt.Position.Y)].Personagem != null){
                Debug.WriteLine("TEM PERSONAGEM AQUI");
            }
            if (selecionou == false)
            {
                Debug.WriteLine("entrou");
                if (Map.casa[calcCasa.getPosCasa((int)ptrPt.Position.X),calcCasa.getPosCasa((int)ptrPt.Position.Y)].Personagem != null)
                {
                    selecionou = true;
                    selecionado = Map.casa[calcCasa.getPosCasa((int)ptrPt.Position.X),calcCasa.getPosCasa((int)ptrPt.Position.Y)].Personagem;
                   // map.casa[calcCasa.getPosCasa((int)ptrPt.Position.X)][calcCasa.getPosCasa((int)ptrPt.Position.Y)].Personagem = null;
                }
            }
            else
            {
                if (Map.casa[calcCasa.getPosCasa((int)ptrPt.Position.X),calcCasa.getPosCasa((int)ptrPt.Position.Y)].Personagem == null)
                {
                    selecionou =false;
                    Map.casa[calcCasa.getPosCasa((int)ptrPt.Position.X),calcCasa.getPosCasa((int)ptrPt.Position.Y)].Personagem=selecionado;
                    // map.casa[calcCasa.getPosCasa((int)ptrPt.Position.X)][calcCasa.getPosCasa((int)ptrPt.Position.Y)].Personagem = null;
                }
            }


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
            foreach (Castelo cast in Jogador1.Castelos) {
              
                if (Map.casa[cast.Cordx, cast.Cordy].Personagem == null)
                {
                    Personagem person = new Guerreiro(cast.Cordx, cast.Cordy);
                    Image ImgPerson = new Image();
                    ImgPerson.Width = person.bitmap.DecodePixelWidth = ObjetoDeJogo.DimXCasa;
                    ImgPerson.Height = person.bitmap.DecodePixelHeight = ObjetoDeJogo.DimYCasa;
                   
                   // person.bitmap.UriSource = new Uri(ImgPerson.BaseUri,person.UrlImage);
                    person.bitmap.UriSource = new Uri(person.UrlImage);
                    ImgPerson.Source = person.bitmap;
                    mapa.Children.Add(ImgPerson);
                    Canvas.SetLeft(ImgPerson, cast.Cordx * 40);
                    Canvas.SetTop(ImgPerson, cast.Cordy * 40);
                  
                    Map.casa[cast.Cordx, cast.Cordy].Personagem = person;
                    Jogador1.Personagens.Add(person);
                    break;
                    }
               
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
